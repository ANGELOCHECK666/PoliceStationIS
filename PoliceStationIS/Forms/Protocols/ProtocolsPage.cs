using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Protocols
{
    public partial class ProtocolsPage : UserControl
    {
        //============================================================
        // ДАННЫЕ
        //============================================================

        private DataTable protocolsTable;

        private const int PageSize = 6;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private int selectedProtocolId = 0;

        private bool searchMode = false;


        //============================================================
        // КОНСТРУКТОР
        //============================================================

        public ProtocolsPage()
        {
            InitializeComponent();

            InitializePage();

            ConfigureEvents();

            ClearProtocolInformation();
        }


        //============================================================
        // ИНИЦИАЛИЗАЦИЯ СТРАНИЦЫ
        //============================================================

        // Начальная загрузка справочников и списка протоколов.
        // Подключение к PostgreSQL централизовано в DatabaseConnection.
        private void InitializePage()
        {
            try
            {
                LoadProtocolTypes();

                LoadProtocolStatuses();

                LoadEmployees();

                LoadCases();

                LoadProtocols();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки раздела протоколов",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // СОБЫТИЯ
        //============================================================

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;

            btnReset.Click += BtnReset_Click;

            btnFirstPage.Click += BtnFirstPage_Click;

            btnPreviousPage.Click += BtnPreviousPage_Click;

            btnNextPage.Click += BtnNextPage_Click;

            btnLastPage.Click += BtnLastPage_Click;

            btnCreateProtocol.Click +=
                BtnCreateProtocol_Click;

            btnEditProtocol.Click +=
                BtnEditProtocol_Click;

            btnPrintProtocol.Click +=
                BtnPrintProtocol_Click;

            btnDeleteProtocol.Click +=
                BtnDeleteProtocol_Click;
        }


        //============================================================
        // ЗАГРУЗКА ТИПОВ ПРОТОКОЛОВ
        //============================================================

        private void LoadProtocolTypes()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_type_id,
                        protocol_type_name
                    FROM protocol_type
                    ORDER BY protocol_type_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbProtocolType.Items.Clear();

                        cmbProtocolType.Items.Add(
                            new ComboBoxItem
                            {
                                Id = 0,
                                Name = "Все"
                            });

                        while (reader.Read())
                        {
                            cmbProtocolType.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "protocol_type_id"]),

                                    Name =
                                        reader[
                                            "protocol_type_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbProtocolType.SelectedIndex = 0;
        }


        //============================================================
        // ЗАГРУЗКА СТАТУСОВ
        //============================================================

        private void LoadProtocolStatuses()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_status_id,
                        protocol_status_name
                    FROM protocol_status
                    ORDER BY protocol_status_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbStatus.Items.Clear();

                        cmbStatus.Items.Add(
                            new ComboBoxItem
                            {
                                Id = 0,
                                Name = "Все"
                            });

                        while (reader.Read())
                        {
                            cmbStatus.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "protocol_status_id"]),

                                    Name =
                                        reader[
                                            "protocol_status_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbStatus.SelectedIndex = 0;
        }


        //============================================================
        // ЗАГРУЗКА СОТРУДНИКОВ
        //============================================================

        private void LoadEmployees()
        {
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
                        LEFT(
                            COALESCE(middle_name, ''),
                            1
                        ) || '.' AS employee_name

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
                        cmbEmployee.Items.Clear();

                        cmbEmployee.Items.Add(
                            new ComboBoxItem
                            {
                                Id = 0,
                                Name = "Все"
                            });

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

            cmbEmployee.SelectedIndex = 0;
        }


        //============================================================
        // ЗАГРУЗКА УГОЛОВНЫХ ДЕЛ
        //============================================================

        private void LoadCases()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        criminal_case_id,
                        TRIM(case_number) AS case_number

                    FROM criminal_case

                    ORDER BY
                        case_number;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbCase.Items.Clear();

                        cmbCase.Items.Add(
                            new ComboBoxItem
                            {
                                Id = 0,
                                Name = "Все"
                            });

                        while (reader.Read())
                        {
                            cmbCase.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "criminal_case_id"]),

                                    Name =
                                        reader[
                                            "case_number"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbCase.SelectedIndex = 0;
        }


        //============================================================
        // ЗАГРУЗКА ПРОТОКОЛОВ
        //============================================================

        // Загружаем протоколы постранично: сначала получаем количество
        // подходящих записей, затем запрашиваем только текущую страницу.
        private void LoadProtocols()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string fromWhere =
                        BuildSearchConditions();

                    string countQuery =
                        @"
                        SELECT COUNT(*)

                        FROM protocol p

                        INNER JOIN protocol_type pt
                            ON p.protocol_type_id =
                               pt.protocol_type_id

                        INNER JOIN protocol_status ps
                            ON p.protocol_status_id =
                               ps.protocol_status_id

                        INNER JOIN employee e
                            ON p.employee_id =
                               e.employee_id

                        " +
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


                    string query =
                        @"
                        SELECT

                            p.protocol_id
                                AS ""Id"",

                            TRIM(
                                p.protocol_number
                            )
                                AS ""ProtocolNumber"",

                            pt.protocol_type_name
                                AS ""ProtocolType"",

                            ps.protocol_status_name
                                AS ""ProtocolStatus"",

                            p.date_of_preparation_protocol
                                AS ""PreparationDate"",

                            p.place_of_commission
                                AS ""Place"",

                            p.description_protocol
                                AS ""Description"",

                            e.last_name || ' ' ||
                            LEFT(e.name_, 1) || '.' ||
                            LEFT(
                                COALESCE(
                                    e.middle_name,
                                    ''
                                ),
                                1
                            ) || '.'
                                AS ""EmployeeName"",

                            (
                                SELECT
                                    STRING_AGG(
                                        TRIM(
                                            cc.case_number
                                        ),
                                        ', '
                                        ORDER BY
                                            cc.case_number
                                    )

                                FROM criminal_case cc

                                WHERE
                                    cc.protocol_id =
                                    p.protocol_id
                            )
                                AS ""CaseNumbers"",

                            (
                                SELECT
                                    COUNT(*)

                                FROM protocol_citizen pc

                                WHERE
                                    pc.protocol_id =
                                    p.protocol_id
                            )
                                AS ""CitizenCount""

                        FROM protocol p

                        INNER JOIN protocol_type pt
                            ON p.protocol_type_id =
                               pt.protocol_type_id

                        INNER JOIN protocol_status ps
                            ON p.protocol_status_id =
                               ps.protocol_status_id

                        INNER JOIN employee e
                            ON p.employee_id =
                               e.employee_id

                        " +
                        fromWhere +
                        @"

                        ORDER BY
                            p.date_of_preparation_protocol DESC,
                            p.protocol_id DESC

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
                            (currentPage - 1) *
                            PageSize);


                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(
                                command))
                        {
                            protocolsTable =
                                new DataTable();

                            adapter.Fill(
                                protocolsTable);
                        }
                    }
                }


                LoadProtocolCards();

                UpdatePagination();

                if (protocolsTable.Rows.Count > 0)
                {
                    int protocolId =
                        Convert.ToInt32(
                            protocolsTable.Rows[0]["Id"]);

                    SelectProtocol(
                        protocolId);
                }
                else
                {
                    ClearProtocolInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки протоколов",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // УСЛОВИЯ ПОИСКА
        //============================================================

        // Формируем SQL-условия фильтрации. Все значения фильтров
        // передаются через параметры NpgsqlCommand.
        private string BuildSearchConditions()
        {
            string conditions =
                @"
                WHERE 1 = 1
                ";


            if (!searchMode)
                return conditions;


            //========================================================
            // НОМЕР ПРОТОКОЛА
            //========================================================

            if (!string.IsNullOrWhiteSpace(
                txtProtocolNumber.Text))
            {
                conditions +=
                    @"
                    AND p.protocol_number
                        ILIKE @protocol_number
                    ";
            }


            //========================================================
            // ТИП ПРОТОКОЛА
            //========================================================

            ComboBoxItem typeItem =
                cmbProtocolType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND p.protocol_type_id =
                        @protocol_type_id
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
                    AND p.employee_id =
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
                    AND p.protocol_status_id =
                        @protocol_status_id
                    ";
            }


            //========================================================
            // ДЕЛО
            //
            // В Protocol нет Criminal_case_id.
            // Связь идёт через Criminal_case.Protocol_id.
            //========================================================

            ComboBoxItem caseItem =
                cmbCase.SelectedItem
                as ComboBoxItem;

            if (caseItem != null &&
                caseItem.Id > 0)
            {
                conditions +=
                    @"
                    AND EXISTS
                    (
                        SELECT 1

                        FROM criminal_case cc_filter

                        WHERE
                            cc_filter.protocol_id =
                            p.protocol_id

                            AND
                            cc_filter.criminal_case_id =
                            @criminal_case_id
                    )
                    ";
            }


            //========================================================
            // ДАТА ОТ
            //========================================================

            if (dtDateFrom.Checked)
            {
                conditions +=
                    @"
                    AND
                    p.date_of_preparation_protocol
                    >= @date_from
                    ";
            }


            //========================================================
            // ДАТА ДО
            //========================================================

            if (dtDateTo.Checked)
            {
                conditions +=
                    @"
                    AND
                    p.date_of_preparation_protocol
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


            //========================================================
            // НОМЕР
            //========================================================

            if (!string.IsNullOrWhiteSpace(
                txtProtocolNumber.Text))
            {
                command.Parameters.AddWithValue(
                    "@protocol_number",
                    "%" +
                    txtProtocolNumber.Text.Trim() +
                    "%");
            }


            //========================================================
            // ТИП
            //========================================================

            ComboBoxItem typeItem =
                cmbProtocolType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@protocol_type_id",
                    typeItem.Id);
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
                command.Parameters.AddWithValue(
                    "@employee_id",
                    employeeItem.Id);
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
                command.Parameters.AddWithValue(
                    "@protocol_status_id",
                    statusItem.Id);
            }


            //========================================================
            // ДЕЛО
            //========================================================

            ComboBoxItem caseItem =
                cmbCase.SelectedItem
                as ComboBoxItem;

            if (caseItem != null &&
                caseItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@criminal_case_id",
                    caseItem.Id);
            }


            //========================================================
            // ДАТА ОТ
            //========================================================

            if (dtDateFrom.Checked)
            {
                command.Parameters.AddWithValue(
                    "@date_from",
                    dtDateFrom.Value.Date);
            }


            //========================================================
            // ДАТА ДО
            //========================================================

            if (dtDateTo.Checked)
            {
                command.Parameters.AddWithValue(
                    "@date_to",
                    dtDateTo.Value.Date);
            }
        }


        //============================================================
        // СОЗДАНИЕ КАРТОЧЕК
        //============================================================

        private void LoadProtocolCards()
        {
            flpProtocols.SuspendLayout();

            flpProtocols.Controls.Clear();


            if (protocolsTable == null ||
                protocolsTable.Rows.Count == 0)
            {
                Label emptyLabel =
                    new Label();

                emptyLabel.Text =
                    "Протоколы не найдены";

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

                flpProtocols.Controls.Add(
                    emptyLabel);

                flpProtocols.ResumeLayout();

                return;
            }


            foreach (DataRow row
                in protocolsTable.Rows)
            {
                Panel card =
                    CreateProtocolCard(
                        row);

                flpProtocols.Controls.Add(
                    card);
            }


            flpProtocols.ResumeLayout();
        }


        //============================================================
        // СОЗДАНИЕ ОДНОЙ КАРТОЧКИ
        //============================================================

        private Panel CreateProtocolCard(
            DataRow row)
        {
            Panel card =
                new Panel();


            card.Size =
                new Size(
                    255,
                    158);


            card.Margin =
                new Padding(
                    0,
                    0,
                    12,
                    12);


            card.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);


            card.BorderStyle =
                BorderStyle.FixedSingle;


            int protocolId =
                Convert.ToInt32(
                    row["Id"]);


            card.Tag =
                protocolId;


            //========================================================
            // ЦВЕТНАЯ ПОЛОСА
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
                    158);

            statusBar.BackColor =
                GetStatusColor(
                    row[
                        "ProtocolStatus"]
                    .ToString());


            card.Controls.Add(
                statusBar);


            //========================================================
            // НОМЕР
            //========================================================

            Label lblNumber =
                new Label();

            lblNumber.Text =
                "ПРОТОКОЛ № " +
                row[
                    "ProtocolNumber"]
                .ToString();

            lblNumber.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblNumber.ForeColor =
                Color.White;

            lblNumber.Location =
                new Point(
                    16,
                    12);

            lblNumber.AutoSize =
                true;


            card.Controls.Add(
                lblNumber);


            //========================================================
            // ТИП
            //========================================================

            Label lblType =
                new Label();

            lblType.Text =
                row[
                    "ProtocolType"]
                .ToString();

            lblType.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            lblType.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblType.Location =
                new Point(
                    16,
                    38);

            lblType.MaximumSize =
                new Size(
                    220,
                    0);

            lblType.AutoSize =
                true;


            card.Controls.Add(
                lblType);


            //========================================================
            // ДЕЛО
            //========================================================

            Label lblCaseTitle =
                new Label();

            lblCaseTitle.Text =
                "Дело:";

            lblCaseTitle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            lblCaseTitle.ForeColor =
                Color.Gainsboro;

            lblCaseTitle.Location =
                new Point(
                    16,
                    70);

            lblCaseTitle.AutoSize =
                true;


            card.Controls.Add(
                lblCaseTitle);


            Label lblCase =
                new Label();

            string caseNumbers =
                row["CaseNumbers"] == DBNull.Value
                    ? "Не связано"
                    : row["CaseNumbers"].ToString();


            lblCase.Text =
                caseNumbers;

            lblCase.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblCase.ForeColor =
                Color.White;

            lblCase.Location =
                new Point(
                    65,
                    70);

            lblCase.MaximumSize =
                new Size(
                    180,
                    0);

            lblCase.AutoSize =
                true;


            card.Controls.Add(
                lblCase);


            //========================================================
            // СОТРУДНИК
            //========================================================

            Label lblEmployeeTitle =
                new Label();

            lblEmployeeTitle.Text =
                "Составил:";

            lblEmployeeTitle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            lblEmployeeTitle.ForeColor =
                Color.Gainsboro;

            lblEmployeeTitle.Location =
                new Point(
                    16,
                    94);

            lblEmployeeTitle.AutoSize =
                true;


            card.Controls.Add(
                lblEmployeeTitle);


            Label lblEmployee =
                new Label();

            lblEmployee.Text =
                row[
                    "EmployeeName"]
                .ToString();

            lblEmployee.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblEmployee.ForeColor =
                Color.Silver;

            lblEmployee.Location =
                new Point(
                    82,
                    94);

            lblEmployee.AutoSize =
                true;


            card.Controls.Add(
                lblEmployee);


            //========================================================
            // ДАТА
            //========================================================

            Label lblDateTitle =
                new Label();

            lblDateTitle.Text =
                "Дата:";

            lblDateTitle.Font =
                new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold);

            lblDateTitle.ForeColor =
                Color.Gainsboro;

            lblDateTitle.Location =
                new Point(
                    16,
                    118);

            lblDateTitle.AutoSize =
                true;


            card.Controls.Add(
                lblDateTitle);


            Label lblDate =
                new Label();

            lblDate.Text =
                Convert.ToDateTime(
                    row[
                        "PreparationDate"])
                .ToString(
                    "dd.MM.yyyy");

            lblDate.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            lblDate.ForeColor =
                Color.Silver;

            lblDate.Location =
                new Point(
                    58,
                    118);

            lblDate.AutoSize =
                true;


            card.Controls.Add(
                lblDate);


            //========================================================
            // STATUS
            //========================================================

            Label lblStatus =
                new Label();

            lblStatus.Text =
                row[
                    "ProtocolStatus"]
                .ToString()
                .ToUpper();

            lblStatus.Font =
                new Font(
                    "Segoe UI",
                    7.5F,
                    FontStyle.Bold);

            lblStatus.ForeColor =
                statusBar.BackColor;

            lblStatus.Location =
                new Point(
                    145,
                    118);

            lblStatus.MaximumSize =
                new Size(
                    90,
                    0);

            lblStatus.AutoSize =
                true;


            card.Controls.Add(
                lblStatus);


            //========================================================
            // ОБРАБОТКА КЛИКА
            //========================================================

            AttachCardClick(
                card,
                protocolId);


            return card;
        }


        //============================================================
        // КЛИК ПО КАРТОЧКЕ
        //============================================================

        private void AttachCardClick(
            Control control,
            int protocolId)
        {
            control.Click +=
                (sender, e) =>
                {
                    SelectProtocol(
                        protocolId);
                };


            foreach (Control child
                in control.Controls)
            {
                AttachCardClick(
                    child,
                    protocolId);
            }
        }


        //============================================================
        // ВЫБОР ПРОТОКОЛА
        //============================================================

        private void SelectProtocol(
            int protocolId)
        {
            selectedProtocolId =
                protocolId;


            foreach (Control control
                in flpProtocols.Controls)
            {
                if (control.Tag == null)
                    continue;


                if (!int.TryParse(
                    control.Tag.ToString(),
                    out int id))
                    continue;


                if (id == protocolId)
                {
                    control.BackColor =
                        Color.FromArgb(
                            42,
                            73,
                            133);
                }
                else
                {
                    control.BackColor =
                        Color.FromArgb(
                            25,
                            45,
                            80);
                }
            }


            LoadProtocolInformation(
                protocolId);
        }


        //============================================================
        // ИНФОРМАЦИЯ О ПРОТОКОЛЕ
        //============================================================

        private void LoadProtocolInformation(
            int protocolId)
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

                            TRIM(
                                p.protocol_number
                            )
                                AS protocol_number,

                            pt.protocol_type_name
                                AS protocol_type_name,

                            ps.protocol_status_name
                                AS protocol_status_name,

                            p.date_of_preparation_protocol
                                AS preparation_date,

                            p.place_of_commission
                                AS place_of_commission,

                            p.description_protocol
                                AS description_protocol,

                            e.last_name || ' ' ||
                            LEFT(e.name_, 1) || '.' ||
                            LEFT(
                                COALESCE(
                                    e.middle_name,
                                    ''
                                ),
                                1
                            ) || '.'
                                AS employee_name,

                            (
                                SELECT
                                    STRING_AGG(
                                        TRIM(
                                            cc.case_number
                                        ),
                                        ', '
                                        ORDER BY
                                            cc.case_number
                                    )

                                FROM criminal_case cc

                                WHERE
                                    cc.protocol_id =
                                    p.protocol_id
                            )
                                AS case_numbers

                        FROM protocol p

                        INNER JOIN protocol_type pt
                            ON p.protocol_type_id =
                               pt.protocol_type_id

                        INNER JOIN protocol_status ps
                            ON p.protocol_status_id =
                               ps.protocol_status_id

                        INNER JOIN employee e
                            ON p.employee_id =
                               e.employee_id

                        WHERE
                            p.protocol_id = @id;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            protocolId);


                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ClearProtocolInformation();

                                return;
                            }


                            lblProtocolNumberValue.Text =
                                reader[
                                    "protocol_number"]
                                .ToString();


                            lblCaseValue.Text =
                                reader[
                                    "case_numbers"] ==
                                DBNull.Value
                                    ? "Не связано"
                                    : reader[
                                        "case_numbers"]
                                        .ToString();


                            lblDateValue.Text =
                                Convert.ToDateTime(
                                    reader[
                                        "preparation_date"])
                                .ToString(
                                    "dd.MM.yyyy");


                            lblEmployeeValue.Text =
                                reader[
                                    "employee_name"]
                                .ToString();


                            lblProtocolTypeValue.Text =
                                reader[
                                    "protocol_type_name"]
                                .ToString();


                            lblPlaceValue.Text =
                                reader[
                                    "place_of_commission"]
                                .ToString();


                            lblStatusValue.Text =
                                "● " +
                                reader[
                                    "protocol_status_name"]
                                .ToString();


                            lblNoteValue.Text =
                                reader[
                                    "description_protocol"]
                                .ToString();


                            lblStatusValue.ForeColor =
                                GetStatusColor(
                                    reader[
                                        "protocol_status_name"]
                                    .ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки информации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // ОЧИСТКА ИНФОРМАЦИИ
        //============================================================

        private void ClearProtocolInformation()
        {
            selectedProtocolId = 0;

            lblProtocolNumberValue.Text =
                "—";

            lblCaseValue.Text =
                "—";

            lblDateValue.Text =
                "—";

            lblEmployeeValue.Text =
                "—";

            lblProtocolTypeValue.Text =
                "—";

            lblPlaceValue.Text =
                "—";

            lblStatusValue.Text =
                "—";

            lblNoteValue.Text =
                "—";

            lblStatusValue.ForeColor =
                Color.Gainsboro;
        }


        //============================================================
        // ЦВЕТ СТАТУСА
        //============================================================

        private Color GetStatusColor(
            string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return Color.Gainsboro;


            string value =
                status.ToLower();


            if (value.Contains("заверш"))
                return Color.FromArgb(
                    55,
                    180,
                    90);


            if (value.Contains("действ"))
                return Color.FromArgb(
                    70,
                    150,
                    230);


            if (value.Contains("отмен"))
                return Color.FromArgb(
                    220,
                    80,
                    80);


            if (value.Contains("чернов"))
                return Color.FromArgb(
                    212,
                    160,
                    23);


            return Color.FromArgb(
                180,
                180,
                180);
        }


        //============================================================
        // ПОИСК
        //============================================================

        // При новом поиске начинаем с первой страницы.
        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            searchMode = true;

            currentPage = 1;

            LoadProtocols();
        }


        //============================================================
        // СБРОС
        //============================================================

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtProtocolNumber.Clear();


            if (cmbProtocolType.Items.Count > 0)
                cmbProtocolType.SelectedIndex = 0;


            if (cmbCase.Items.Count > 0)
                cmbCase.SelectedIndex = 0;


            if (cmbEmployee.Items.Count > 0)
                cmbEmployee.SelectedIndex = 0;


            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;


            dtDateFrom.Checked = false;

            dtDateTo.Checked = false;


            searchMode = false;

            currentPage = 1;

            LoadProtocols();
        }


        //============================================================
        // FIRST PAGE
        //============================================================

        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage == 1)
                return;


            currentPage = 1;

            LoadProtocols();
        }


        //============================================================
        // PREVIOUS PAGE
        //============================================================

        private void BtnPreviousPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
                return;


            currentPage--;

            LoadProtocols();
        }


        //============================================================
        // NEXT PAGE
        //============================================================

        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;


            currentPage++;

            LoadProtocols();
        }


        //============================================================
        // LAST PAGE
        //============================================================

        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;


            currentPage =
                totalPages;

            LoadProtocols();
        }


        //============================================================
        // ПАГИНАЦИЯ
        //============================================================

        private void UpdatePagination()
        {
            if (totalRecords == 0)
            {
                lblPageInfo.Text =
                    "0 из 0";

                btnFirstPage.Enabled = false;

                btnPreviousPage.Enabled = false;

                btnNextPage.Enabled = false;

                btnLastPage.Enabled = false;

                return;
            }


            int startRecord =
                ((currentPage - 1) *
                 PageSize) + 1;


            int endRecord =
                Math.Min(
                    currentPage * PageSize,
                    totalRecords);


            lblPageInfo.Text =
                startRecord +
                "–" +
                endRecord +
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


        //============================================================
        // СОЗДАТЬ
        //============================================================

        // Создание выполняется отдельной формой. После сохранения
        // перечитываем данные, чтобы новый протокол сразу появился в списке.
        private void BtnCreateProtocol_Click(
            object sender,
            EventArgs e)
        {
            using (ProtocolEditForm form =
                new ProtocolEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;
                    LoadProtocols();
                }
            }
        }


        //============================================================
        // РЕДАКТИРОВАТЬ
        //============================================================

        private void BtnEditProtocol_Click(
            object sender,
            EventArgs e)
        {
            if (selectedProtocolId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите протокол.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (ProtocolEditForm form =
                new ProtocolEditForm(selectedProtocolId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadProtocols();
                }
            }
        }

        //============================================================
        // ПЕЧАТЬ
        //============================================================

        private void BtnPrintProtocol_Click(
            object sender,
            EventArgs e)
        {
            if (selectedProtocolId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите протокол.",
                    "Печать",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                ProtocolPrintService service =
                    new ProtocolPrintService(
                        selectedProtocolId);

                service.GenerateAndPrint(
                    this.FindForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось выполнить печать протокола.\\n\\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // УДАЛЕНИЕ
        //============================================================

        private void BtnDeleteProtocol_Click(
            object sender,
            EventArgs e)
        {
            if (selectedProtocolId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите протокол.",
                    "Удаление протокола",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            if (!CanDeleteProtocol(
                selectedProtocolId))
            {
                return;
            }


            DialogResult result =
                MessageBox.Show(
                    "Вы действительно хотите удалить выбранный протокол?\n\n" +
                    "Операция необратима.",
                    "Удаление протокола",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);


            if (result != DialogResult.Yes)
                return;


            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();


                    string query =
                        @"
                        DELETE FROM protocol

                        WHERE
                            protocol_id = @id;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            selectedProtocolId);


                        command.ExecuteNonQuery();
                    }
                }


                selectedProtocolId = 0;

                LoadProtocols();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка удаления протокола",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //============================================================
        // ПРОВЕРКА ВОЗМОЖНОСТИ УДАЛЕНИЯ
        //============================================================

        private bool CanDeleteProtocol(
            int protocolId)
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

                            EXISTS
                            (
                                SELECT 1

                                FROM criminal_case

                                WHERE
                                    protocol_id =
                                    @id
                            )
                            AS has_case,

                            EXISTS
                            (
                                SELECT 1

                                FROM protocol_citizen

                                WHERE
                                    protocol_id =
                                    @id
                            )
                            AS has_citizens,

                            EXISTS
                            (
                                SELECT 1

                                FROM protocol p

                                WHERE
                                    p.protocol_id =
                                    @id

                                    AND
                                    p.evidence_id IS NOT NULL
                            )
                            AS has_evidence;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            protocolId);


                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                                return true;


                            bool hasCase =
                                Convert.ToBoolean(
                                    reader[
                                        "has_case"]);


                            bool hasCitizens =
                                Convert.ToBoolean(
                                    reader[
                                        "has_citizens"]);


                            bool hasEvidence =
                                Convert.ToBoolean(
                                    reader[
                                        "has_evidence"]);


                            if (hasCase)
                            {
                                MessageBox.Show(
                                    "Протокол нельзя удалить, " +
                                    "поскольку он связан с уголовным делом.",
                                    "Удаление невозможно",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return false;
                            }


                            if (hasCitizens)
                            {
                                MessageBox.Show(
                                    "Протокол нельзя удалить, " +
                                    "поскольку с ним связаны граждане.",
                                    "Удаление невозможно",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return false;
                            }


                            if (hasEvidence)
                            {
                                MessageBox.Show(
                                    "Протокол нельзя удалить, " +
                                    "поскольку с ним связано вещественное доказательство.",
                                    "Удаление невозможно",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                return false;
                            }
                        }
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка проверки протокола",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
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