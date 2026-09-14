using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Citizens
{
    public partial class CitizensPage : UserControl
    {

        private DataTable citizensTable;

        private const int PageSize = 9;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private bool isLoadingCitizens = false;
        private enum CitizenTab
        {
            General,
            Documents,
            Cases,
            History
        }

        private CitizenTab currentTab = CitizenTab.General;

        private int selectedCitizenId = 0;

        private readonly List<CitizenCaseModel> citizenCases =
    new List<CitizenCaseModel>();

        private class CitizenHistoryModel
        {
            public DateTime EventDate { get; set; }

            public string EventType { get; set; }

            public string Description { get; set; }

            public string EmployeeName { get; set; }
        }
        public CitizensPage()
        {
            InitializeComponent();

            ConfigureGrid();

            // Справочник пола загружается из БД при открытии раздела.
            // Само подключение создаётся через общий DatabaseConnection,
            // поэтому строка подключения не дублируется в странице.
            LoadGenders();

            dgvCitizens.SelectionChanged += DgvCitizens_SelectionChanged;

            // После загрузки справочника получаем реальные записи граждан.
            LoadCitizens();

            InitializeTabs();

            btnAddCitizen.Click += BtnAddCitizen_Click;
            btnEditCitizen.Click += BtnEditCitizen_Click;

            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;

            btnFirstPage.Click += BtnFirstPage_Click;
            btnPreviousPage.Click += BtnPreviousPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;
        }

        private void LoadGenders()
        {
            try
            {
                cmbGender.Items.Clear();

                cmbGender.Items.Add("Все");

                // Для каждого отдельного обращения к БД используется
                // общий фабричный метод DatabaseConnection.GetConnection().
                // Страница не хранит собственную строку подключения.
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
SELECT
    sex_name
FROM sex
ORDER BY
    sex_name;
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbGender.Items.Add(
                                    reader["sex_name"].ToString());
                            }
                        }
                    }
                }

                cmbGender.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки пола",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvCitizens.EnableHeadersVisualStyles = false;

            dgvCitizens.AutoGenerateColumns = false;

            dgvCitizens.BackgroundColor =
                Color.FromArgb(28, 47, 92);

            dgvCitizens.BorderStyle =
                BorderStyle.None;

            dgvCitizens.GridColor =
                Color.FromArgb(212, 160, 23);

            dgvCitizens.RowHeadersVisible = false;

            dgvCitizens.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCitizens.MultiSelect = false;

            dgvCitizens.ReadOnly = true;

            dgvCitizens.AllowUserToAddRows = false;

            dgvCitizens.AllowUserToDeleteRows = false;

            dgvCitizens.AllowUserToResizeRows = false;

            dgvCitizens.AllowUserToResizeColumns = false;

            dgvCitizens.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;

            dgvCitizens.Columns["LastName"].FillWeight = 18;
            dgvCitizens.Columns["FirstName"].FillWeight = 14;
            dgvCitizens.Columns["MiddleName"].FillWeight = 18;
            dgvCitizens.Columns["BirthDate"].FillWeight = 16;
            dgvCitizens.Columns["Gender"].FillWeight = 10;
            dgvCitizens.Columns["Passport"].FillWeight = 24;

            dgvCitizens.ColumnHeadersHeight = 42;

            dgvCitizens.RowTemplate.Height = 34;

            dgvCitizens.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(48, 72, 125);

            dgvCitizens.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(212, 160, 23);

            dgvCitizens.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            dgvCitizens.DefaultCellStyle.BackColor =
                Color.FromArgb(30, 58, 117);

            dgvCitizens.DefaultCellStyle.ForeColor =
                Color.White;

            dgvCitizens.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(60, 90, 150);

            dgvCitizens.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvCitizens.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            dgvCitizens.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvCitizens.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;
        }

        private void LoadCitizens()
        {
            try
            {
                isLoadingCitizens = true;

                // Основная загрузка страницы также выполняется через
                // общий класс DatabaseConnection. Соединение гарантированно
                // освобождается после завершения работы блока using.
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    //--------------------------------------------------
                    // СНАЧАЛА ПОЛУЧАЕМ КОЛИЧЕСТВО ЗАПИСЕЙ
                    // С УЧЁТОМ ТЕКУЩИХ ФИЛЬТРОВ
                    //--------------------------------------------------

                    string countQuery =
                        @"
SELECT COUNT(*)
FROM citizen c
LEFT JOIN sex s
    ON c.sex_id = s.sex_id
";

                    using (NpgsqlCommand countCommand =
                        new NpgsqlCommand(
                            countQuery,
                            connection))
                    {
                        string whereClause =
                            BuildCitizenFilter(
                                countCommand);

                        countCommand.CommandText +=
                            whereClause;

                        totalRecords =
                            Convert.ToInt32(
                                countCommand.ExecuteScalar());
                    }

                    //--------------------------------------------------
                    // КОЛИЧЕСТВО СТРАНИЦ
                    //--------------------------------------------------

                    totalPages =
                        Math.Max(
                            1,
                            (int)Math.Ceiling(
                                (double)totalRecords /
                                PageSize));

                    if (currentPage > totalPages)
                        currentPage = totalPages;

                    //--------------------------------------------------
                    // ПОЛУЧЕНИЕ ГРАЖДАН
                    //
                    // Здесь используется тот же набор фильтров, что и
                    // для COUNT(*), поэтому количество страниц и список
                    // записей всегда соответствуют друг другу.
                    //--------------------------------------------------

                    string query =
                        @"
SELECT
    c.citizen_id AS ""Id"",

    c.last_name AS ""Фамилия"",

    c.name_ AS ""Имя"",

    c.middle_name AS ""Отчество"",

    c.date_of_birth AS ""Дата рождения"",

    s.sex_name AS ""Пол"",

    TRIM(c.passport_series) ||
    ' ' ||
    TRIM(c.passport_number)
        AS ""Паспорт""

FROM citizen c

LEFT JOIN sex s
    ON c.sex_id = s.sex_id
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        //--------------------------------------------------
                        // ФИЛЬТРЫ
                        //--------------------------------------------------

                        string whereClause =
                            BuildCitizenFilter(
                                command);

                        command.CommandText +=
                            whereClause;

                        //--------------------------------------------------
                        // СОРТИРОВКА
                        //--------------------------------------------------

                        command.CommandText +=
                            @"
ORDER BY
    c.last_name,
    c.name_,
    c.middle_name
";

                        //--------------------------------------------------
                        // ПАГИНАЦИЯ
                        //--------------------------------------------------

                        int offset =
                            (currentPage - 1) *
                            PageSize;

                        command.CommandText +=
                            @"
LIMIT @limit
OFFSET @offset;
";

                        command.Parameters.AddWithValue(
                            "@limit",
                            PageSize);

                        command.Parameters.AddWithValue(
                            "@offset",
                            offset);

                        //--------------------------------------------------
                        // ЗАГРУЗКА ТАБЛИЦЫ
                        //--------------------------------------------------

                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvCitizens.Rows.Clear();

                            foreach (DataRow row in table.Rows)
                            {
                                int rowIndex =
                                    dgvCitizens.Rows.Add(
                                        row["Фамилия"],
                                        row["Имя"],
                                        row["Отчество"],
                                        Convert.ToDateTime(
                                            row["Дата рождения"])
                                            .ToString("dd.MM.yyyy"),
                                        row["Пол"],
                                        row["Паспорт"]);

                                dgvCitizens.Rows[rowIndex].Tag =
                                    Convert.ToInt32(row["Id"]);
                            }
                        }
                    }
                }

                //--------------------------------------------------
                // ОБНОВЛЯЕМ ПАГИНАЦИЮ
                //--------------------------------------------------

                // После получения данных пересчитываем пагинацию.
                UpdatePagination();

                //--------------------------------------------------
                // ВЫБИРАЕМ ПЕРВОГО ГРАЖДАНИНА
                //
                // Это позволяет сразу заполнить правую информационную
                // панель, не заставляя пользователя повторно нажимать
                // на первую строку.
                //--------------------------------------------------

                if (dgvCitizens.Rows.Count > 0)
                {
                    dgvCitizens.Rows[0].Selected = true;

                    dgvCitizens.CurrentCell =
                        dgvCitizens.Rows[0].Cells[0];
                }

                if (dgvCitizens.Rows.Count > 0)
                {
                    object value =
                        dgvCitizens.Rows[0].Tag;

                    if (value != null &&
                        int.TryParse(
                            value.ToString(),
                            out int citizenId))
                    {
                        selectedCitizenId =
                            citizenId;

                        LoadCitizenInfo(
                            selectedCitizenId);

                        LoadCitizenCases();

                        LoadCitizenHistory();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки граждан",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            finally
            {
                isLoadingCitizens = false;
            }
        }

        private string BuildCitizenFilter(
    NpgsqlCommand command)
        {
            List<string> conditions =
                new List<string>();

            //--------------------------------------------------
            // ФАМИЛИЯ
            //--------------------------------------------------

            if (!string.IsNullOrWhiteSpace(
                txtLastName.Text))
            {
                conditions.Add(
                    "c.last_name ILIKE @last_name");

                command.Parameters.AddWithValue(
                    "@last_name",
                    "%" +
                    txtLastName.Text.Trim() +
                    "%");
            }

            //--------------------------------------------------
            // ИМЯ
            //--------------------------------------------------

            if (!string.IsNullOrWhiteSpace(
                txtFirstName.Text))
            {
                conditions.Add(
                    "c.name_ ILIKE @first_name");

                command.Parameters.AddWithValue(
                    "@first_name",
                    "%" +
                    txtFirstName.Text.Trim() +
                    "%");
            }

            //--------------------------------------------------
            // ОТЧЕСТВО
            //--------------------------------------------------

            if (!string.IsNullOrWhiteSpace(
                txtMiddleName.Text))
            {
                conditions.Add(
                    "c.middle_name ILIKE @middle_name");

                command.Parameters.AddWithValue(
                    "@middle_name",
                    "%" +
                    txtMiddleName.Text.Trim() +
                    "%");
            }

            //--------------------------------------------------
            // ДАТА РОЖДЕНИЯ
            //--------------------------------------------------

            if (dtBirthDate.Checked)
            {
                conditions.Add(
                    "c.date_of_birth = @birth_date");

                command.Parameters.AddWithValue(
                    "@birth_date",
                    dtBirthDate.Value.Date);
            }

            //--------------------------------------------------
            // ПОЛ
            //--------------------------------------------------

            if (cmbGender.SelectedIndex > 0 &&
                !string.IsNullOrWhiteSpace(
                    cmbGender.Text))
            {
                conditions.Add(
                    "s.sex_name = @gender");

                command.Parameters.AddWithValue(
                    "@gender",
                    cmbGender.Text);
            }

            //--------------------------------------------------
            // ПАСПОРТ
            //--------------------------------------------------

            if (!string.IsNullOrWhiteSpace(
                txtPassport.Text))
            {
                conditions.Add(
                    @"(
                TRIM(c.passport_series) ||
                ' ' ||
                TRIM(c.passport_number)
              ) ILIKE @passport");

                command.Parameters.AddWithValue(
                    "@passport",
                    "%" +
                    txtPassport.Text.Trim() +
                    "%");
            }

            //--------------------------------------------------
            // СОБИРАЕМ WHERE
            //--------------------------------------------------

            if (conditions.Count == 0)
                return string.Empty;

            return
                "WHERE " +
                string.Join(
                    " AND ",
                    conditions) +
                "\n";
        }

        private void UpdatePagination()
        {
            if (totalRecords == 0)
            {
                lblPageInfo.Text = "Нет записей";
            }
            else
            {
                int firstRecord =
                    ((currentPage - 1) * PageSize) + 1;

                int lastRecord =
                    Math.Min(
                        currentPage * PageSize,
                        totalRecords);

                lblPageInfo.Text =
                    $"{firstRecord}-{lastRecord} из {totalRecords}";
            }

            btnFirstPage.Enabled =
                currentPage > 1;

            btnPreviousPage.Enabled =
                currentPage > 1;

            btnNextPage.Enabled =
                currentPage < totalPages;

            btnLastPage.Enabled =
                currentPage < totalPages;
        }

        private void InitializeTabs()
        {
            pnlTabGeneral.Click += (s, e) => SelectTab(CitizenTab.General);
            pnlTabDocuments.Click += (s, e) => SelectTab(CitizenTab.Documents);
            pnlTabCases.Click += (s, e) => SelectTab(CitizenTab.Cases);
            pnlTabHistory.Click += (s, e) => SelectTab(CitizenTab.History);

            lblTabGeneral.Click += (s, e) => SelectTab(CitizenTab.General);
            lblTabDocuments.Click += (s, e) => SelectTab(CitizenTab.Documents);
            lblTabCases.Click += (s, e) => SelectTab(CitizenTab.Cases);
            lblTabHistory.Click += (s, e) => SelectTab(CitizenTab.History);

            SelectTab(CitizenTab.General);
        }

        private void SelectTab(CitizenTab tab)
        {
            currentTab = tab;

            //--------------------------------------------------
            // Сбрасываем шрифт вкладок
            //--------------------------------------------------

            lblTabGeneral.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            lblTabDocuments.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            lblTabCases.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            lblTabHistory.Font =
                new Font("Segoe UI", 9F, FontStyle.Regular);

            //--------------------------------------------------
            // Скрываем все панели
            //--------------------------------------------------

            pnlGeneralContent.Visible = false;

            pnlDocumentsContent.Visible = false;

            pnlCasesContent.Visible = false;

            pnlHistoryContent.Visible = false;

            //--------------------------------------------------
            // Переключаем вкладку
            //--------------------------------------------------

            switch (tab)
            {
                case CitizenTab.General:

                    lblTabGeneral.Font =
                        new Font("Segoe UI", 9F, FontStyle.Bold);

                    pnlActiveTab.Width =
                        pnlTabGeneral.Width;

                    pnlActiveTab.Left =
                        pnlTabGeneral.Left;

                    pnlGeneralContent.Visible = true;

                    break;

                case CitizenTab.Documents:

                    lblTabDocuments.Font =
                        new Font("Segoe UI", 9F, FontStyle.Bold);

                    pnlActiveTab.Width =
                        pnlTabDocuments.Width;

                    pnlActiveTab.Left =
                        pnlTabDocuments.Left;

                    pnlDocumentsContent.Visible = true;

                    break;

                case CitizenTab.Cases:

                    lblTabCases.Font =
                        new Font("Segoe UI", 9F, FontStyle.Bold);

                    pnlActiveTab.Width =
                        pnlTabCases.Width;

                    pnlActiveTab.Left =
                        pnlTabCases.Left;

                    pnlCasesContent.Visible = true;

                    break;

                case CitizenTab.History:

                    lblTabHistory.Font =
                        new Font("Segoe UI", 9F, FontStyle.Bold);

                    pnlActiveTab.Width =
                        pnlTabHistory.Width;

                    pnlActiveTab.Left =
                        pnlTabHistory.Left;

                    pnlHistoryContent.Visible = true;

                    break;
            }
        }

        private void DgvCitizens_SelectionChanged(
     object sender,
     EventArgs e)
        {
            if (isLoadingCitizens)
                return;

            if (dgvCitizens.CurrentRow == null)
                return;

            object value =
                dgvCitizens.CurrentRow.Tag;

            if (value == null)
                return;

            if (!int.TryParse(
                value.ToString(),
                out int citizenId))
            {
                return;
            }

            selectedCitizenId =
                citizenId;

            LoadCitizenInfo(
                selectedCitizenId);

            LoadCitizenCases();

            LoadCitizenHistory();
        }

        private void LoadCitizenInfo(
    int citizenId)
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
SELECT
    c.citizen_id,

    c.last_name,
    c.name_,
    c.middle_name,

    c.date_of_birth,

    s.sex_name,

    bp.birth_place_name,

    cs.citizenship_name,

    c.phone_number,
    c.email,

    c.registration_address,
    c.residential_address,

    c.passport_series,
    c.passport_number,

    c.date_of_issue,

    pi.passport_issuance_name,
    pi.code,

    ms.marital_status_name

FROM citizen c

LEFT JOIN sex s
    ON c.sex_id = s.sex_id

LEFT JOIN birth_place bp
    ON c.birth_place_id =
       bp.birth_place_id

LEFT JOIN citizenship cs
    ON c.citizenship_id =
       cs.citizenship_id

LEFT JOIN passport_issuance pi
    ON c.passport_issuance_id =
       pi.passport_issuance_id

LEFT JOIN marital_status ms
    ON c.marital_status_id =
       ms.marital_status_id

WHERE c.citizen_id =
      @citizen_id;
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@citizen_id",
                            citizenId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                                return;

                            //--------------------------------------------------
                            // ФИО
                            //--------------------------------------------------

                            string lastName =
                                reader["last_name"]
                                .ToString();

                            string firstName =
                                reader["name_"]
                                .ToString();

                            string middleName =
                                reader["middle_name"]
                                .ToString();

                            string fullName =
    lastName +
    Environment.NewLine +
    firstName +
    Environment.NewLine +
    middleName;


                            //--------------------------------------------------
                            // ДАТА РОЖДЕНИЯ
                            //--------------------------------------------------

                            DateTime birthDate =
                                Convert.ToDateTime(
                                    reader["date_of_birth"]);


                            //--------------------------------------------------
                            // ПОЛ
                            //--------------------------------------------------

                            string gender =
                                reader["sex_name"]
                                .ToString();


                            //--------------------------------------------------
                            // ВОЗРАСТ
                            //--------------------------------------------------

                            int age =
                                CalculateAge(
                                    birthDate);


                            //--------------------------------------------------
                            // ШАПКА КАРТОЧКИ
                            //--------------------------------------------------

                            lblCitizenNameHeader.Text =
                                fullName;

                            lblCitizenGenderHeader.Text =
                                gender;

                            lblCitizenAgeHeader.Text =
                                age + " " +
                                GetAgeWord(age);


                            //--------------------------------------------------
                            // ОСНОВНЫЕ ДАННЫЕ
                            //--------------------------------------------------

                            lblBirthValue.Text =
                                birthDate.ToString(
                                    "dd.MM.yyyy");

                            lblGenderValue.Text =
                                gender;

                            lblAgeValue.Text =
                                age + " " +
                                GetAgeWord(age);

                            lblBirthPlaceValue.Text =
                                reader["birth_place_name"]
                                .ToString();

                            lblCitizenshipValue.Text =
                                reader["citizenship_name"]
                                .ToString();

                            lblPhoneValue.Text =
                                reader["phone_number"]
                                .ToString();

                            lblEmailValue.Text =
                                reader["email"]
                                .ToString();

                            lblRegistrationValue.Text =
                                reader["registration_address"]
                                .ToString();

                            lblResidenceValue.Text =
                                reader["residential_address"]
                                .ToString();


                            //--------------------------------------------------
                            // ПАСПОРТ
                            //--------------------------------------------------

                            lblSeriesValue.Text =
                                reader["passport_series"]
                                .ToString();

                            lblNumberValue.Text =
                                reader["passport_number"]
                                .ToString();

                            lblIssueDateValue.Text =
                                Convert.ToDateTime(
                                    reader["date_of_issue"])
                                    .ToString(
                                        "dd.MM.yyyy");

                            lblIssuedByValue.Text =
                                reader["passport_issuance_name"]
                                .ToString();

                            lblDepartmentCodeValue.Text =
                                reader["code"]
                                .ToString();

                            lblMaritalStatusValue.Text =
                                reader["marital_status_name"]
                                .ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки данных гражданина",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int CalculateAge(
    DateTime birthDate)
        {
            DateTime today =
                DateTime.Today;

            int age =
                today.Year -
                birthDate.Year;

            if (birthDate.Date >
                today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private string GetAgeWord(
    int age)
        {
            int lastTwo =
                age % 100;

            if (lastTwo >= 11 &&
                lastTwo <= 14)
            {
                return "лет";
            }

            switch (age % 10)
            {
                case 1:
                    return "год";

                case 2:
                case 3:
                case 4:
                    return "года";

                default:
                    return "лет";
            }
        }

        private void LoadCitizenHistory()
        {
            if (selectedCitizenId <= 0)
            {
                flpCitizenHistory.Controls.Clear();
                return;
            }

            List<CitizenHistoryModel> history =
                GetCitizenHistoryFromDatabase(selectedCitizenId);

            LoadHistoryCards(history);
        }

        private void LoadHistoryCards(
    List<CitizenHistoryModel> history)
        {
            flpCitizenHistory.SuspendLayout();

            flpCitizenHistory.Controls.Clear();

            foreach (CitizenHistoryModel item in history)
            {
                Panel card =
                    CreateHistoryCard(item);

                flpCitizenHistory.Controls.Add(
                    card);
            }

            flpCitizenHistory.ResumeLayout();
        }

        private Panel CreateHistoryCard(
    CitizenHistoryModel item)
        {
            Panel card =
                new Panel();

            card.Size =
                new Size(
                    380,
                    115);

            card.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    12);

            card.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            card.BorderStyle =
                BorderStyle.FixedSingle;


            //--------------------------------------------------
            // ЦВЕТНАЯ ПОЛОСА
            //--------------------------------------------------

            Panel eventBar =
                new Panel();

            eventBar.Location =
                new Point(
                    0,
                    0);

            eventBar.Size =
                new Size(
                    5,
                    115);


            switch (item.EventType)
            {
                case "Создание":

                    eventBar.BackColor =
                        Color.FromArgb(
                            55,
                            180,
                            90);

                    break;


                case "Изменение":

                    eventBar.BackColor =
                        Color.Goldenrod;

                    break;


                case "Удаление":

                    eventBar.BackColor =
                        Color.FromArgb(
                            220,
                            70,
                            70);

                    break;


                default:

                    eventBar.BackColor =
                        Color.FromArgb(
                            100,
                            130,
                            180);

                    break;
            }


            card.Controls.Add(
                eventBar);


            //--------------------------------------------------
            // ДАТА И ВРЕМЯ
            //--------------------------------------------------

            Label lblDate =
                new Label();

            lblDate.Text =
                item.EventDate.ToString(
                    "dd.MM.yyyy  HH:mm");

            lblDate.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblDate.ForeColor =
                Color.Silver;

            lblDate.Location =
                new Point(
                    18,
                    10);

            lblDate.AutoSize =
                true;

            card.Controls.Add(
                lblDate);


            //--------------------------------------------------
            // ТИП СОБЫТИЯ
            //--------------------------------------------------

            Label lblEventType =
                new Label();

            lblEventType.Text =
                item.EventType.ToUpper();

            lblEventType.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblEventType.ForeColor =
                eventBar.BackColor;

            lblEventType.Location =
                new Point(
                    265,
                    10);

            lblEventType.AutoSize =
                true;

            card.Controls.Add(
                lblEventType);


            //--------------------------------------------------
            // ОПИСАНИЕ
            //--------------------------------------------------

            Label lblDescription =
                new Label();

            lblDescription.Text =
                item.Description;

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblDescription.ForeColor =
                Color.White;

            lblDescription.Location =
                new Point(
                    18,
                    38);

            lblDescription.MaximumSize =
                new Size(
                    340,
                    0);

            lblDescription.AutoSize =
                true;

            card.Controls.Add(
                lblDescription);


            //--------------------------------------------------
            // СОТРУДНИК
            //--------------------------------------------------

            Label lblEmployeeTitle =
                new Label();

            lblEmployeeTitle.Text =
                "Сотрудник:";

            lblEmployeeTitle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            lblEmployeeTitle.ForeColor =
                Color.Gainsboro;

            lblEmployeeTitle.Location =
                new Point(
                    18,
                    78);

            lblEmployeeTitle.AutoSize =
                true;

            card.Controls.Add(
                lblEmployeeTitle);


            Label lblEmployee =
                new Label();

            lblEmployee.Text =
                item.EmployeeName;

            lblEmployee.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblEmployee.ForeColor =
                Color.Silver;

            lblEmployee.Location =
                new Point(
                    90,
                    78);

            lblEmployee.AutoSize =
                true;

            card.Controls.Add(
                lblEmployee);


            return card;
        }

        private List<CitizenHistoryModel> GetCitizenHistoryFromDatabase(
    int citizenId)
        {
            List<CitizenHistoryModel> history =
                new List<CitizenHistoryModel>();

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
SELECT
    ch.event_date,
    ch.event_type,
    ch.description,

    CASE
        WHEN e.employee_id IS NULL
        THEN 'Система'
        ELSE
            e.last_name || ' ' ||
            LEFT(e.name_, 1) || '.' ||
            LEFT(COALESCE(e.middle_name, ''), 1) || '.'
    END AS employee_name

FROM citizen_history ch

LEFT JOIN employee e
    ON ch.employee_id = e.employee_id

WHERE ch.citizen_id = @citizen_id

ORDER BY
    ch.event_date DESC;
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@citizen_id",
                            citizenId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                history.Add(
                                    new CitizenHistoryModel
                                    {
                                        EventDate =
                                            Convert.ToDateTime(
                                                reader["event_date"]),

                                        EventType =
                                            reader["event_type"]
                                            .ToString(),

                                        Description =
                                            reader["description"]
                                            .ToString(),

                                        EmployeeName =
                                            reader["employee_name"]
                                            .ToString()
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки истории",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return history;
        }

        private void BtnAddCitizen_Click(object sender, EventArgs e)
        {
            // Форма добавления отвечает только за ввод и сохранение
            // данных. После успешного закрытия обновляем список из БД.
            using (CitizenEditForm form =
                new CitizenEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCitizens();
                }
            }
        }

        private void BtnEditCitizen_Click(object sender, EventArgs e)
        {
            if (selectedCitizenId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите гражданина.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Редактирование выполняется для выбранного ID.
            // После сохранения повторно читаем данные из БД, чтобы список
            // сразу показывал актуальное состояние.
            using (CitizenEditForm form =
                new CitizenEditForm(selectedCitizenId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCitizens();
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            // Новый поиск всегда начинается с первой страницы.
            currentPage = 1;

            LoadCitizens();

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();

            dtBirthDate.Checked = false;

            if (cmbGender.Items.Count > 0)
                cmbGender.SelectedIndex = 0;

            txtPassport.Clear();

            // После сброса фильтров снова показываем первую страницу.
            currentPage = 1;

            LoadCitizens();

        }

        private void BtnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;

            LoadCitizens();

        }

        private void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                LoadCitizens();
            }

        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;

                LoadCitizens();
            }

        }

        private void BtnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;

            LoadCitizens();

        }

        private void HidePassportInformation()
        {
            lblPassportHeader.Visible = false;
            pnlPassportLine.Visible = false;

            lblSeriesTitle.Visible = false;
            lblSeriesValue.Visible = false;
            lineSeries.Visible = false;

            lblNumberTitle.Visible = false;
            lblNumberValue.Visible = false;
            lineNumber.Visible = false;

            lblIssueDateTitle.Visible = false;
            lblIssueDateValue.Visible = false;
            lineIssueDate.Visible = false;

            lblDepartmentCodeTitle.Visible = false;
            lblDepartmentCodeValue.Visible = false;

            lblIssuedByTitle.Visible = false;
            lblIssuedByValue.Visible = false;

            lblMaritalStatusTitle.Visible = false;
            lblMaritalStatusValue.Visible = false;
            lineMaritalStatus.Visible = false;
        }

        private void ShowPassportInformation()
        {
            lblPassportHeader.Visible = true;
            pnlPassportLine.Visible = true;

            lblSeriesTitle.Visible = true;
            lblSeriesValue.Visible = true;
            lineSeries.Visible = true;

            lblNumberTitle.Visible = true;
            lblNumberValue.Visible = true;
            lineNumber.Visible = true;

            lblIssueDateTitle.Visible = true;
            lblIssueDateValue.Visible = true;
            lineIssueDate.Visible = true;

            lblDepartmentCodeTitle.Visible = true;
            lblDepartmentCodeValue.Visible = true;

            lblIssuedByTitle.Visible = true;
            lblIssuedByValue.Visible = true;

            lblMaritalStatusTitle.Visible = true;
            lblMaritalStatusValue.Visible = true;
            lineMaritalStatus.Visible = true;
        }

        private class CitizenCaseModel
        {
            public string CaseNumber { get; set; }

            public string Role { get; set; }

            public string Status { get; set; }

            public string Article { get; set; }

            public string Investigator { get; set; }

            public DateTime CaseDate { get; set; }
        }

        private void LoadCitizenCases()
        {
            List<CitizenCaseModel> cases =
                new List<CitizenCaseModel>();

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
SELECT
    cc.case_number,

    cr.citizen_role_name,

    cs.case_status_name,

    art.article_of_the_ccrf_code,
    art.article_of_the_ccrf_name,

    e.last_name,
    e.name_,
    e.middle_name,

    cc.date_and_time_of_crime

FROM criminal_case_citizen ccc

INNER JOIN criminal_case cc
    ON ccc.criminal_case_id =
       cc.criminal_case_id

INNER JOIN citizen c
    ON ccc.citizen_id =
       c.citizen_id

LEFT JOIN citizen_role cr
    ON c.citizen_role_id =
       cr.citizen_role_id

INNER JOIN case_status cs
    ON cc.case_status_id =
       cs.case_status_id

INNER JOIN article_of_the_ccrf art
    ON cc.article_of_the_ccrf_id =
       art.article_of_the_ccrf_id

INNER JOIN employee e
    ON cc.employee_id =
       e.employee_id

WHERE ccc.citizen_id =
      @citizen_id

ORDER BY
    cc.date_and_time_of_crime DESC;
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@citizen_id",
                            selectedCitizenId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string investigator =
                                    reader["last_name"].ToString();

                                string employeeName =
                                    reader["name_"].ToString();

                                string middleName =
                                    reader["middle_name"].ToString();

                                if (!string.IsNullOrWhiteSpace(
                                    employeeName))
                                {
                                    investigator +=
                                        " "
                                        + employeeName.Substring(0, 1)
                                        + ".";
                                }

                                if (!string.IsNullOrWhiteSpace(
                                    middleName))
                                {
                                    investigator +=
                                        middleName.Substring(0, 1)
                                        + ".";
                                }

                                string article =
                                    "ст. "
                                    + reader[
                                        "article_of_the_ccrf_code"]
                                        .ToString()
                                    + " УК РФ — "
                                    + reader[
                                        "article_of_the_ccrf_name"]
                                        .ToString();

                                cases.Add(
                                    new CitizenCaseModel
                                    {
                                        CaseNumber =
                                            reader[
                                                "case_number"]
                                                .ToString()
                                                .Trim(),

                                        Role =
                                            reader[
                                                "citizen_role_name"]
                                                .ToString(),

                                        Status =
                                            reader[
                                                "case_status_name"]
                                                .ToString(),

                                        Article =
                                            article,

                                        Investigator =
                                            investigator,

                                        CaseDate =
                                            Convert.ToDateTime(
                                                reader[
                                                    "date_and_time_of_crime"])
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки дел гражданина",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            //--------------------------------------------------
            // ОТОБРАЖЕНИЕ КАРТОЧЕК
            //--------------------------------------------------

            flpCitizenCases.SuspendLayout();

            flpCitizenCases.Controls.Clear();

            foreach (CitizenCaseModel item in cases)
            {
                Panel card =
                    CreateCaseCard(item);

                flpCitizenCases.Controls.Add(card);
            }

            flpCitizenCases.ResumeLayout();
        }

        private Panel CreateCaseCard(CitizenCaseModel item)
        {
            Panel card = new Panel();

            card.Size =
                new Size(
                    380,
                    155);

            card.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    12);

            card.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            //--------------------------------------------------
            // Цветная полоса статуса
            //--------------------------------------------------

            Panel statusBar =
                new Panel();

            statusBar.Location =
                new Point(
                    0,
                    0);

            statusBar.Size =
                new Size(
                    5,
                    155);

            switch (item.Status)
            {
                case "Активно":

                    statusBar.BackColor =
                        Color.FromArgb(
                            55,
                            180,
                            90);

                    break;

                case "Закрыто":

                    statusBar.BackColor =
                        Color.FromArgb(
                            220,
                            70,
                            70);

                    break;

                default:

                    statusBar.BackColor =
                        Color.Goldenrod;

                    break;
            }

            card.Controls.Add(statusBar);

            //--------------------------------------------------
            // Номер дела
            //--------------------------------------------------

            Label lblCaseNumber =
                new Label();

            lblCaseNumber.Text =
                "№ " + item.CaseNumber;

            lblCaseNumber.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblCaseNumber.ForeColor =
                Color.White;

            lblCaseNumber.Location =
                new Point(
                    18,
                    12);

            lblCaseNumber.AutoSize =
                true;

            card.Controls.Add(lblCaseNumber);

            //--------------------------------------------------
            // Статус
            //--------------------------------------------------

            Label lblStatus =
                new Label();

            lblStatus.Text =
                item.Status;

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblStatus.ForeColor =
                statusBar.BackColor;

            lblStatus.AutoSize =
                true;

            lblStatus.Location =
                new Point(
                    275,
                    15);

            card.Controls.Add(lblStatus);

            //--------------------------------------------------
            // Роль
            //--------------------------------------------------

            Label lblRoleTitle =
                new Label();

            lblRoleTitle.Text =
                "Роль:";

            lblRoleTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblRoleTitle.ForeColor =
                Color.White;

            lblRoleTitle.Location =
                new Point(
                    18,
                    45);

            lblRoleTitle.AutoSize =
                true;

            card.Controls.Add(lblRoleTitle);

            Label lblRole =
                new Label();

            lblRole.Text =
                item.Role;

            lblRole.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblRole.ForeColor =
                Color.Gainsboro;

            lblRole.Location =
                new Point(
                    85,
                    45);

            lblRole.AutoSize =
                true;

            card.Controls.Add(lblRole);

            //--------------------------------------------------
            // Статья
            //--------------------------------------------------

            Label lblArticleTitle =
                new Label();

            lblArticleTitle.Text =
                "Статья:";

            lblArticleTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblArticleTitle.ForeColor =
                Color.White;

            lblArticleTitle.Location =
                new Point(
                    18,
                    70);

            lblArticleTitle.AutoSize =
                true;

            card.Controls.Add(lblArticleTitle);

            Label lblArticle =
                new Label();

            lblArticle.Text =
                item.Article;

            lblArticle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblArticle.ForeColor =
                Color.Gainsboro;

            lblArticle.Location =
                new Point(
                    85,
                    70);

            lblArticle.AutoSize =
                true;

            card.Controls.Add(lblArticle);

            //--------------------------------------------------
            // Следователь
            //--------------------------------------------------

            Label lblInvestigatorTitle =
                new Label();

            lblInvestigatorTitle.Text =
                "Следователь:";

            lblInvestigatorTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblInvestigatorTitle.ForeColor =
                Color.White;

            lblInvestigatorTitle.Location =
                new Point(
                    18,
                    95);

            lblInvestigatorTitle.AutoSize =
                true;

            card.Controls.Add(lblInvestigatorTitle);

            Label lblInvestigator =
                new Label();

            lblInvestigator.Text =
                item.Investigator;

            lblInvestigator.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblInvestigator.ForeColor =
                Color.Gainsboro;

            lblInvestigator.Location =
                new Point(
                    115,
                    95);

            lblInvestigator.AutoSize =
                true;

            card.Controls.Add(lblInvestigator);

            //--------------------------------------------------
            // Дата
            //--------------------------------------------------

            Label lblDate =
                new Label();

            lblDate.Text =
                item.CaseDate.ToString("dd.MM.yyyy");

            lblDate.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblDate.ForeColor =
                Color.Silver;

            lblDate.AutoSize =
                true;

            lblDate.Location =
                new Point(
                    18,
                    125);

            card.Controls.Add(lblDate);

            return card;
        }
    }
}