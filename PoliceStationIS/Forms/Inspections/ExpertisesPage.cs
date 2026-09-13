using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Npgsql;

using PoliceStationIS.Database;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Expertises
{
    public partial class ExpertisesPage : UserControl
    {
        //============================================================
        // ДАННЫЕ
        //============================================================

        private DataTable expertisesTable;

        private const int PageSize = 6;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private int selectedExpertiseId = 0;

        private bool searchMode = false;


        //============================================================
        // КОНСТРУКТОР
        //============================================================

        public ExpertisesPage()
        {
            InitializeComponent();

            btnPrintExpertise.ForeColor = Color.White;
            btnPrintExpertise.UseVisualStyleBackColor = false;

            ConfigureControls();

            ConfigureEvents();

            InitializePage();

            ClearExpertiseInformation();
        }


        //============================================================
        // ИНИЦИАЛИЗАЦИЯ
        //============================================================

        private void InitializePage()
        {
            try
            {
                LoadExpertiseTypes();

                LoadExpertiseStatuses();

                LoadProtocols();

                LoadEmployees();

                LoadExpertises();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки раздела экспертиз",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // НАСТРОЙКА КОНТРОЛОВ
        //============================================================

        private void ConfigureControls()
        {
            ConfigureComboBox(
                cmbExpertiseType);

            ConfigureComboBox(
                cmbProtocol);

            ConfigureComboBox(
                cmbEmployee);

            ConfigureComboBox(
                cmbStatus);


            btnEditExpertise.Enabled =
                false;

            btnPrintExpertise.Enabled =
                false;

            btnDeleteExpertise.Enabled =
                false;
        }


        private void ConfigureComboBox(
            ComboBox comboBox)
        {
            comboBox.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;

            comboBox.Font =
                new Font(
                    "Segoe UI",
                    9F);
        }


        //============================================================
        // СОБЫТИЯ
        //============================================================

        private void ConfigureEvents()
        {
            btnSearch.Click +=
                BtnSearch_Click;

            btnReset.Click +=
                BtnReset_Click;


            btnFirstPage.Click +=
                BtnFirstPage_Click;

            btnPreviousPage.Click +=
                BtnPreviousPage_Click;

            btnNextPage.Click +=
                BtnNextPage_Click;

            btnLastPage.Click +=
                BtnLastPage_Click;


            btnAddExpertise.Click +=
                BtnAddExpertise_Click;

            btnEditExpertise.Click +=
                BtnEditExpertise_Click;

            btnPrintExpertise.Click +=
                BtnPrintExpertise_Click;

            btnDeleteExpertise.Click +=
                BtnDeleteExpertise_Click;
        }


        //============================================================
        // ЗАГРУЗКА ТИПОВ ЭКСПЕРТИЗ
        //============================================================

        private void LoadExpertiseTypes()
        {
            cmbExpertiseType.Items.Clear();

            cmbExpertiseType.Items.Add(
                new ComboBoxItem
                {
                    Id = 0,
                    Name = "Все"
                });


            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        inspection_type_id,
                        inspection_type_name
                    FROM inspection_type
                    ORDER BY inspection_type_name;
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
                            cmbExpertiseType.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "inspection_type_id"]),

                                    Name =
                                        reader[
                                            "inspection_type_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbExpertiseType.SelectedIndex =
                0;
        }


        //============================================================
        // ЗАГРУЗКА СТАТУСОВ
        //============================================================

        private void LoadExpertiseStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add(
                new ComboBoxItem
                {
                    Id = 0,
                    Name = "Все"
                });


            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        inspection_status_id,
                        inspection_status_name
                    FROM inspection_status
                    ORDER BY inspection_status_name;
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
                            cmbStatus.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "inspection_status_id"]),

                                    Name =
                                        reader[
                                            "inspection_status_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbStatus.SelectedIndex =
                0;
        }


        //============================================================
        // ЗАГРУЗКА ПРОТОКОЛОВ
        //============================================================

        private void LoadProtocols()
        {
            cmbProtocol.Items.Clear();

            cmbProtocol.Items.Add(
                new ComboBoxItem
                {
                    Id = 0,
                    Name = "Все протоколы"
                });


            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_id,
                        TRIM(protocol_number)
                            AS protocol_number
                    FROM protocol
                    ORDER BY protocol_number;
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
                            cmbProtocol.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "protocol_id"]),

                                    Name =
                                        reader[
                                            "protocol_number"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbProtocol.SelectedIndex =
                0;
        }


        //============================================================
        // ЗАГРУЗКА СОТРУДНИКОВ
        //============================================================

        private void LoadEmployees()
        {
            cmbEmployee.Items.Clear();

            cmbEmployee.Items.Add(
                new ComboBoxItem
                {
                    Id = 0,
                    Name = "Все сотрудники"
                });


            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        employee_id,

                        last_name || ' ' ||
                        LEFT(name_, 1) || '.' ||
                        CASE
                            WHEN middle_name IS NULL
                            THEN ''
                            ELSE LEFT(middle_name, 1) || '.'
                        END
                            AS employee_name

                    FROM employee

                    ORDER BY
                        last_name,
                        name_;
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
                            cmbEmployee.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "employee_id"]),

                                    Name =
                                        reader[
                                            "employee_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbEmployee.SelectedIndex =
                0;
        }


        //============================================================
        // ЗАГРУЗКА ЭКСПЕРТИЗ
        //============================================================

        private void LoadExpertises()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();


                    string fromWhere =
                        BuildSearchConditions();


                    //================================================
                    // COUNT
                    //================================================

                    string countQuery =
                        @"
                        SELECT COUNT(*)

                        FROM inspection i

                        INNER JOIN inspection_type it
                            ON i.inspection_type_id =
                               it.inspection_type_id

                        INNER JOIN inspection_status ist
                            ON i.inspection_status_id =
                               ist.inspection_status_id

                        INNER JOIN employee e
                            ON i.employee_id =
                               e.employee_id

                        LEFT JOIN protocol p
                            ON i.protocol_id =
                               p.protocol_id

                        "
                        +
                        fromWhere;


                    using (NpgsqlCommand countCommand =
                        new NpgsqlCommand(
                            countQuery,
                            connection))
                    {
                        AddSearchParameters(
                            countCommand);

                        totalRecords =
                            Convert.ToInt32(
                                countCommand.ExecuteScalar());

                        totalPages =
                            Math.Max(
                                1,
                                (int)Math.Ceiling(
                                    totalRecords /
                                    (double)PageSize));
                    }


                    //================================================
                    // DATA
                    //================================================

                    string query =
                        @"
                        SELECT

                            i.inspection_id
                                AS ""Id"",

                            TRIM(i.inspection_number)
                                AS ""ExpertiseNumber"",

                            TRIM(
                                COALESCE(
                                    p.protocol_number,
                                    ''
                                )
                            )
                                AS ""ProtocolNumber"",

                            it.inspection_type_name
                                AS ""ExpertiseType"",

                            ist.inspection_status_name
                                AS ""ExpertiseStatus"",

                            i.appointment_date
                                AS ""AppointmentDate"",

                            i.research_start_date
                                AS ""ResearchStartDate"",

                            i.research_end_date
                                AS ""ResearchEndDate"",

                            COALESCE(
                                i.conclusion,
                                ''
                            )
                                AS ""Conclusion"",

                            e.last_name || ' ' ||
                            LEFT(e.name_, 1) || '.' ||
                            CASE
                                WHEN e.middle_name IS NULL
                                THEN ''
                                ELSE LEFT(
                                    e.middle_name,
                                    1
                                ) || '.'
                            END
                                AS ""EmployeeName"",

                            CASE
                                WHEN i.inspection_file IS NULL
                                THEN FALSE
                                ELSE TRUE
                            END
                                AS ""HasFile""

                        FROM inspection i

                        INNER JOIN inspection_type it
                            ON i.inspection_type_id =
                               it.inspection_type_id

                        INNER JOIN inspection_status ist
                            ON i.inspection_status_id =
                               ist.inspection_status_id

                        INNER JOIN employee e
                            ON i.employee_id =
                               e.employee_id

                        LEFT JOIN protocol p
                            ON i.protocol_id =
                               p.protocol_id

                        "
                        +
                        fromWhere
                        +
                        @"

                        ORDER BY
                            i.appointment_date DESC,
                            i.inspection_id DESC

                        LIMIT @limit

                        OFFSET @offset;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        AddSearchParameters(
                            command);

                        command.Parameters.AddWithValue(
                            "@limit",
                            PageSize);

                        command.Parameters.AddWithValue(
                            "@offset",
                            (currentPage - 1)
                            *
                            PageSize);


                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(
                                command))
                        {
                            expertisesTable =
                                new DataTable();

                            adapter.Fill(
                                expertisesTable);
                        }
                    }
                }


                LoadExpertiseCards();

                UpdatePagination();


                if (expertisesTable.Rows.Count > 0)
                {
                    int expertiseId =
                        Convert.ToInt32(
                            expertisesTable.Rows[0]["Id"]);

                    SelectExpertise(
                        expertiseId);
                }
                else
                {
                    ClearExpertiseInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки экспертиз",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // УСЛОВИЯ ПОИСКА
        //============================================================

        private string BuildSearchConditions()
        {
            string conditions =
                @"
                WHERE 1 = 1
                ";


            if (!searchMode)
                return conditions;


            //========================================================
            // № ЭКСПЕРТИЗЫ
            //========================================================

            if (!string.IsNullOrWhiteSpace(
    txtExpertiseNumber.Text))
            {
                conditions +=
                    @"
        AND TRIM(i.inspection_number)
            ILIKE @expertise_number
        ";
            }


            //========================================================
            // ТИП
            //========================================================

            ComboBoxItem typeItem =
                cmbExpertiseType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND i.inspection_type_id =
                        @inspection_type_id
                    ";
            }


            //========================================================
            // ПРОТОКОЛ
            //========================================================

            ComboBoxItem protocolItem =
                cmbProtocol.SelectedItem
                as ComboBoxItem;

            if (protocolItem != null &&
                protocolItem.Id > 0)
            {
                conditions +=
                    @"
                    AND i.protocol_id =
                        @protocol_id
                    ";
            }


            //========================================================
            // СОТРУДНИК
            //========================================================

            ComboBoxItem employeeItem =
                cmbEmployee.SelectedItem
                as ComboBoxItem;

            if (employeeItem != null &&
                employeeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND i.employee_id =
                        @employee_id
                    ";
            }


            //========================================================
            // СТАТУС
            //========================================================

            ComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as ComboBoxItem;

            if (statusItem != null &&
                statusItem.Id > 0)
            {
                conditions +=
                    @"
                    AND i.inspection_status_id =
                        @inspection_status_id
                    ";
            }


            //========================================================
            // ДАТА С
            //========================================================

            if (dtDateFrom.Checked)
            {
                conditions +=
                    @"
                    AND i.appointment_date
                        >= @date_from
                    ";
            }


            //========================================================
            // ДАТА ПО
            //========================================================

            if (dtDateTo.Checked)
            {
                conditions +=
                    @"
                    AND i.appointment_date
                        <= @date_to
                    ";
            }


            return conditions;
        }


        //============================================================
        // ПАРАМЕТРЫ ПОИСКА
        //============================================================

        private void AddSearchParameters(
            NpgsqlCommand command)
        {
            if (!searchMode)
                return;


            if (!string.IsNullOrWhiteSpace(
                txtExpertiseNumber.Text))
            {
                command.Parameters.AddWithValue(
                    "@expertise_number",
                    "%" +
                    txtExpertiseNumber.Text.Trim() +
                    "%");
            }


            ComboBoxItem typeItem =
                cmbExpertiseType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@inspection_type_id",
                    typeItem.Id);
            }


            ComboBoxItem protocolItem =
                cmbProtocol.SelectedItem
                as ComboBoxItem;

            if (protocolItem != null &&
                protocolItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@protocol_id",
                    protocolItem.Id);
            }


            ComboBoxItem employeeItem =
                cmbEmployee.SelectedItem
                as ComboBoxItem;

            if (employeeItem != null &&
                employeeItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@employee_id",
                    employeeItem.Id);
            }


            ComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as ComboBoxItem;

            if (statusItem != null &&
                statusItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@inspection_status_id",
                    statusItem.Id);
            }


            if (dtDateFrom.Checked)
            {
                command.Parameters.AddWithValue(
                    "@date_from",
                    dtDateFrom.Value.Date);
            }


            if (dtDateTo.Checked)
            {
                command.Parameters.AddWithValue(
                    "@date_to",
                    dtDateTo.Value.Date);
            }
        }


        //============================================================
        // СОЗДАНИЕ СПИСКА
        //============================================================

        private void LoadExpertiseCards()
        {
            flpExpertises.SuspendLayout();

            flpExpertises.Controls.Clear();


            if (expertisesTable == null ||
                expertisesTable.Rows.Count == 0)
            {
                Label emptyLabel =
                    new Label();

                emptyLabel.Text =
                    "Экспертизы не найдены";

                emptyLabel.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Bold);

                emptyLabel.ForeColor =
                    Color.Gainsboro;

                emptyLabel.AutoSize =
                    true;

                emptyLabel.Margin =
                    new Padding(
                        20,
                        30,
                        0,
                        0);

                flpExpertises.Controls.Add(
                    emptyLabel);

                flpExpertises.ResumeLayout();

                return;
            }


            foreach (DataRow row
                in expertisesTable.Rows)
            {
                Panel card =
                    CreateExpertiseCard(
                        row);

                flpExpertises.Controls.Add(
                    card);
            }


            flpExpertises.ResumeLayout();
        }


        //============================================================
        // СОЗДАНИЕ ОДНОЙ ПОЛОСКИ
        //============================================================

        private Panel CreateExpertiseCard(
            DataRow row)
        {
            int expertiseId =
                Convert.ToInt32(
                    row["Id"]);


            Panel card =
                new Panel();

            card.Size =
                new Size(
                    815,
                    52);

            card.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    6);

            card.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Tag =
                expertiseId;


            //========================================================
            // ЛЕВАЯ ПОЛОСА
            //========================================================

            Panel statusBar =
                new Panel();

            statusBar.Location =
                new Point(
                    0,
                    0);

            statusBar.Size =
                new Size(
                    5,
                    52);

            statusBar.BackColor =
                GetStatusColor(
                    row["ExpertiseStatus"]
                    .ToString());

            card.Controls.Add(
                statusBar);


            //========================================================
            // НОМЕР
            //========================================================

            Label lblNumber =
                CreateCardLabel(
                    row["ExpertiseNumber"]
                    .ToString(),
                    20,
                    17,
                    95,
                    FontStyle.Bold);


            //========================================================
            // ТИП
            //========================================================

            Label lblType =
                CreateCardLabel(
                    row["ExpertiseType"]
                    .ToString(),
                    125,
                    17,
                    210,
                    FontStyle.Regular);


            //========================================================
            // ПРОТОКОЛ
            //========================================================

            string protocolText =
                string.IsNullOrWhiteSpace(
                    row["ProtocolNumber"]
                    .ToString())
                ?
                "Не связан"
                :
                row["ProtocolNumber"]
                .ToString();


            Label lblProtocol =
                CreateCardLabel(
                    "Протокол: " +
                    protocolText,
                    350,
                    17,
                    170,
                    FontStyle.Regular);


            //========================================================
            // ДАТА
            //========================================================

            string dateText =
                Convert.ToDateTime(
                    row["AppointmentDate"])
                .ToString(
                    "dd.MM.yyyy");


            Label lblDate =
                CreateCardLabel(
                    dateText,
                    540,
                    17,
                    100,
                    FontStyle.Regular);


            //========================================================
            // СТАТУС
            //========================================================

            Label lblStatus =
                CreateCardLabel(
                    row["ExpertiseStatus"]
                    .ToString(),
                    650,
                    17,
                    120,
                    FontStyle.Bold);

            lblStatus.ForeColor =
                GetStatusColor(
                    row["ExpertiseStatus"]
                    .ToString());


            //========================================================
            // СТРЕЛКА
            //========================================================

            Label lblArrow =
                new Label();

            lblArrow.Text =
                "›";

            lblArrow.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            lblArrow.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblArrow.AutoSize =
                true;

            lblArrow.Location =
                new Point(
                    780,
                    10);


            card.Controls.Add(
                lblNumber);

            card.Controls.Add(
                lblType);

            card.Controls.Add(
                lblProtocol);

            card.Controls.Add(
                lblDate);

            card.Controls.Add(
                lblStatus);

            card.Controls.Add(
                lblArrow);


            AddCardClickEvent(
                card,
                expertiseId);

            foreach (Control control
                in card.Controls)
            {
                AddCardClickEvent(
                    control,
                    expertiseId);
            }


            return card;
        }


        private Label CreateCardLabel(
            string text,
            int x,
            int y,
            int width,
            FontStyle style)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Location =
                new Point(
                    x,
                    y);

            label.Size =
                new Size(
                    width,
                    22);

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    style);

            label.TextAlign =
                ContentAlignment.MiddleLeft;

            return label;
        }


        private void AddCardClickEvent(
            Control control,
            int expertiseId)
        {
            control.Cursor =
                Cursors.Hand;

            control.Click +=
                (sender, e) =>
                {
                    SelectExpertise(
                        expertiseId);
                };
        }


        //============================================================
        // ВЫБОР ЭКСПЕРТИЗЫ
        //============================================================

        private void SelectExpertise(
            int expertiseId)
        {
            selectedExpertiseId =
                expertiseId;


            DataRow[] rows =
                expertisesTable.Select(
                    "Id = " +
                    expertiseId);


            if (rows.Length == 0)
                return;


            DataRow row =
                rows[0];


            lblExpertiseNumberValue.Text =
                row["ExpertiseNumber"]
                .ToString();

            lblProtocolValue.Text =
                string.IsNullOrWhiteSpace(
                    row["ProtocolNumber"]
                    .ToString())
                ?
                "Не связан"
                :
                row["ProtocolNumber"]
                .ToString();

            lblAppointmentDateValue.Text =
                Convert.ToDateTime(
                    row["AppointmentDate"])
                .ToString(
                    "dd.MM.yyyy");

            lblEmployeeValue.Text =
                row["EmployeeName"]
                .ToString();

            lblExpertiseTypeValue.Text =
                row["ExpertiseType"]
                .ToString();

            lblStatusValue.Text =
                row["ExpertiseStatus"]
                .ToString();


            lblResearchStartValue.Text =
                row["ResearchStartDate"] ==
                DBNull.Value
                ?
                "—"
                :
                Convert.ToDateTime(
                    row["ResearchStartDate"])
                .ToString(
                    "dd.MM.yyyy");


            lblResearchEndValue.Text =
                row["ResearchEndDate"] ==
                DBNull.Value
                ?
                "—"
                :
                Convert.ToDateTime(
                    row["ResearchEndDate"])
                .ToString(
                    "dd.MM.yyyy");


            string conclusion =
                row["Conclusion"]
                .ToString();

            lblConclusionValue.Text =
                string.IsNullOrWhiteSpace(
                    conclusion)
                ?
                "—"
                :
                conclusion;


            btnEditExpertise.Enabled =
                true;

            btnPrintExpertise.Enabled =
    true;

            btnDeleteExpertise.Enabled =
                true;


            HighlightSelectedCard();
        }


        //============================================================
        // ВЫДЕЛЕНИЕ ВЫБРАННОЙ КАРТОЧКИ
        //============================================================

        private void HighlightSelectedCard()
        {
            foreach (Control control
                in flpExpertises.Controls)
            {
                Panel card =
                    control as Panel;

                if (card == null)
                    continue;


                int cardId =
                    Convert.ToInt32(
                        card.Tag);

                if (cardId ==
                    selectedExpertiseId)
                {
                    card.BackColor =
                        Color.FromArgb(
                            55,
                            85,
                            145);
                }
                else
                {
                    card.BackColor =
                        Color.FromArgb(
                            30,
                            58,
                            117);
                }
            }
        }


        //============================================================
        // ОЧИСТКА ИНФОРМАЦИИ
        //============================================================

        private void ClearExpertiseInformation()
        {
            selectedExpertiseId =
                0;

            lblExpertiseNumberValue.Text =
                "—";

            lblProtocolValue.Text =
                "—";

            lblAppointmentDateValue.Text =
                "—";

            lblEmployeeValue.Text =
                "—";

            lblExpertiseTypeValue.Text =
                "—";

            lblStatusValue.Text =
                "—";

            lblResearchStartValue.Text =
                "—";

            lblResearchEndValue.Text =
                "—";

            lblConclusionValue.Text =
                "—";


            btnEditExpertise.Enabled =
                false;

            btnPrintExpertise.Enabled =
                false;

            btnDeleteExpertise.Enabled =
                false;
        }


        //============================================================
        // SEARCH
        //============================================================

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            currentPage =
                1;

            searchMode =
                true;

            LoadExpertises();
        }


        //============================================================
        // RESET
        //============================================================

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtExpertiseNumber.Clear();

            cmbExpertiseType.SelectedIndex =
                0;

            cmbProtocol.SelectedIndex =
                0;

            cmbEmployee.SelectedIndex =
                0;

            cmbStatus.SelectedIndex =
                0;

            dtDateFrom.Checked =
                false;

            dtDateTo.Checked =
                false;


            currentPage =
                1;

            searchMode =
                false;

            LoadExpertises();
        }


        //============================================================
        // PAGINATION
        //============================================================

        private void UpdatePagination()
        {
            int from =
                totalRecords == 0
                ?
                0
                :
                (currentPage - 1)
                *
                PageSize
                +
                1;

            int to =
                Math.Min(
                    currentPage *
                    PageSize,
                    totalRecords);


            lblPageInfo.Text =
                from +
                "–" +
                to +
                " из " +
                totalRecords;


            btnFirstPage.Enabled =
                currentPage > 1;

            btnPreviousPage.Enabled =
                currentPage > 1;

            btnNextPage.Enabled =
                currentPage < totalPages;

            btnLastPage.Enabled =
                currentPage < totalPages;
        }


        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage =
                1;

            LoadExpertises();
        }


        private void BtnPreviousPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                LoadExpertises();
            }
        }


        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;

                LoadExpertises();
            }
        }


        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage =
                totalPages;

            LoadExpertises();
        }


        //============================================================
        // ADD EXPERTISE
        //============================================================

        private void BtnAddExpertise_Click(
    object sender,
    EventArgs e)
        {
            using (ExpertiseEditForm form =
                new ExpertiseEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;
                    LoadExpertises();
                }
            }
        }


        //============================================================
        // EDIT EXPERTISE
        //============================================================

        private void BtnEditExpertise_Click(
    object sender,
    EventArgs e)
        {
            if (selectedExpertiseId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите экспертизу.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (ExpertiseEditForm form =
                new ExpertiseEditForm(selectedExpertiseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadExpertises();
                }
            }
        }

        //============================================================
        // ПЕЧАТЬ ЗАКЛЮЧЕНИЯ
        //============================================================

        private void BtnPrintExpertise_Click(
            object sender,
            EventArgs e)
        {
            if (selectedExpertiseId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите экспертизу.",
                    "Печать",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                ExpertisePrintService service =
                    new ExpertisePrintService(
                        selectedExpertiseId);

                service.GenerateAndPrint(
                    this.FindForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось выполнить печать экспертизы.\n\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //============================================================
        // УДАЛЕНИЕ
        //============================================================

        private void BtnDeleteExpertise_Click(
            object sender,
            EventArgs e)
        {
            if (selectedExpertiseId <= 0)
                return;


            DialogResult result =
                MessageBox.Show(
                    "Вы действительно хотите удалить выбранную экспертизу?\n\n" +
                    "Это действие нельзя будет отменить.",
                    "Удаление экспертизы",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            if (result !=
                DialogResult.Yes)
            {
                return;
            }


            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
                        DELETE FROM inspection

                        WHERE inspection_id =
                              @inspection_id;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@inspection_id",
                            selectedExpertiseId);

                        command.ExecuteNonQuery();
                    }
                }


                MessageBox.Show(
                    "Экспертиза успешно удалена.",
                    "Удаление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                selectedExpertiseId =
                    0;

                LoadExpertises();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    "Не удалось удалить экспертизу.\n\n" +
                    "Возможно, она связана с другими записями в базе данных.\n\n" +
                    ex.MessageText,
                    "Ошибка удаления",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при удалении экспертизы.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // ЦВЕТ СТАТУСА
        //============================================================

        private Color GetStatusColor(
            string status)
        {
            if (string.IsNullOrWhiteSpace(
                status))
            {
                return Color.Gainsboro;
            }


            string value =
                status.ToLower();


            if (value.Contains("заверш") ||
                value.Contains("готов") ||
                value.Contains("выполн"))
            {
                return Color.FromArgb(
                    110,
                    185,
                    125);
            }


            if (value.Contains("провод") ||
                value.Contains("работ") ||
                value.Contains("назнач"))
            {
                return Color.FromArgb(
                    212,
                    160,
                    23);
            }


            if (value.Contains("отмен") ||
                value.Contains("прекращ"))
            {
                return Color.FromArgb(
                    185,
                    110,
                    115);
            }


            return Color.Gainsboro;
        }


        //============================================================
        // COMBOBOX ITEM
        //============================================================

        private class ComboBoxItem
        {
            public int Id { get; set; }

            public string Name { get; set; }


            public override string ToString()
            {
                return Name;
            }
        }
    }
}