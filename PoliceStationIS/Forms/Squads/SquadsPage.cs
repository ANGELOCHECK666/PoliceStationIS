using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Squads
{

    public class ComboBoxItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    public partial class SquadsPage : UserControl
    {
        // ============================================================
        // CONSTANTS
        // ============================================================

        private const int PageSize = 6;


        // ============================================================
        // DATA
        // ============================================================

        private DataTable squadsTable;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private int selectedSquadId = 0;

        private int selectedPatrolServiceId = 0;

        private bool searchMode = false;

        private string activeTab = "MAIN";


        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public SquadsPage()
        {
            InitializeComponent();

            ConfigureControls();

            ConfigureEvents();

            InitializePage();

            ClearSquadInformation();
        }


        // ============================================================
        // INITIALIZATION
        // ============================================================

        private void InitializePage()
        {
            try
            {
                LoadSquadTypes();

                LoadSquadStatuses();

                LoadEmployees();

                LoadSquads();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки раздела нарядов",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // CONTROLS CONFIGURATION
        // ============================================================

        private void ConfigureControls()
        {
            cmbSquadType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbEmployee.DropDownStyle =
                ComboBoxStyle.DropDownList;

            ConfigureComboBox(cmbSquadType);
            ConfigureComboBox(cmbStatus);
            ConfigureComboBox(cmbEmployee);

            txtSquadNumber.CharacterCasing =
                CharacterCasing.Upper;

            lblPageInfo.Text =
                "0–0 из 0";
        }


        private void ConfigureComboBox(
            ComboBox comboBox)
        {
            comboBox.BackColor =
                Color.FromArgb(30, 58, 117);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;

            comboBox.Font =
                new Font(
                    "Segoe UI",
                    9F);
        }


        // ============================================================
        // EVENTS
        // ============================================================

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;

            btnReset.Click += BtnReset_Click;

            btnFirstPage.Click += BtnFirstPage_Click;

            btnPreviousPage.Click +=
                BtnPreviousPage_Click;

            btnNextPage.Click +=
                BtnNextPage_Click;

            btnLastPage.Click +=
                BtnLastPage_Click;


            btnAddSquad.Click +=
                BtnAddSquad_Click;

            btnEditSquad.Click +=
                BtnEditSquad_Click;

            btnAddEvent.Click +=
                BtnAddEvent_Click;


            lblTabMain.Click +=
                (s, e) =>
                {
                    activeTab = "MAIN";

                    UpdateSquadInformation();
                };


            lblTabComposition.Click +=
                (s, e) =>
                {
                    activeTab = "COMPOSITION";

                    UpdateSquadInformation();
                };


            lblTabSchedule.Click +=
                (s, e) =>
                {
                    activeTab = "SCHEDULE";

                    UpdateSquadInformation();
                };


            lblTabRoute.Click +=
                (s, e) =>
                {
                    activeTab = "ROUTE";

                    UpdateSquadInformation();
                };


            btnOpenFullJournal.Click +=
                BtnOpenFullJournal_Click;
        }


        // ============================================================
        // LOAD SQUAD TYPES
        // ============================================================

        private void LoadSquadTypes()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        squad_type_id,
                        squad_type_name
                    FROM squad_type
                    ORDER BY squad_type_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbSquadType.Items.Clear();

                        cmbSquadType.Items.Add(
                            new ComboBoxItem
                            {
                                Id = 0,
                                Name = "Все типы"
                            });

                        while (reader.Read())
                        {
                            cmbSquadType.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "squad_type_id"]),

                                    Name =
                                        reader[
                                            "squad_type_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbSquadType.SelectedIndex = 0;
        }


        // ============================================================
        // LOAD STATUSES
        // ============================================================

        private void LoadSquadStatuses()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        squad_status_id,
                        squad_status_name
                    FROM squad_status
                    ORDER BY squad_status_name;
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
                                Name = "Все статусы"
                            });

                        while (reader.Read())
                        {
                            cmbStatus.Items.Add(
                                new ComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "squad_status_id"]),

                                    Name =
                                        reader[
                                            "squad_status_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbStatus.SelectedIndex = 0;
        }


        // ============================================================
        // LOAD EMPLOYEES
        // ============================================================

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
                        name_ || ' ' ||
                        COALESCE(
                            middle_name,
                            ''
                        )
                            AS full_name

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
                                Name = "Все сотрудники"
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
                                            "full_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbEmployee.SelectedIndex = 0;
        }


        // ============================================================
        // LOAD SQUADS
        // ============================================================

        private void LoadSquads()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string conditions =
                        BuildSearchConditions();


                    // ------------------------------------------------
                    // COUNT
                    // ------------------------------------------------

                    string countQuery =
                        @"
                        SELECT COUNT(*)

                        FROM squad s

                        INNER JOIN squad_type st
                            ON s.squad_type_id =
                               st.squad_type_id

                        INNER JOIN squad_status ss
                            ON s.squad_status_id =
                               ss.squad_status_id

                        " +
                        conditions;


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            countQuery,
                            connection))
                    {
                        AddSearchParameters(command);

                        totalRecords =
                            Convert.ToInt32(
                                command.ExecuteScalar());

                        totalPages =
                            Math.Max(
                                1,
                                (int)Math.Ceiling(
                                    totalRecords /
                                    (double)PageSize));
                    }


                    // ------------------------------------------------
                    // MAIN QUERY
                    // ------------------------------------------------

                    string query =
                        @"
                        SELECT

                            s.squad_id
                                AS ""Id"",

                            'Н-' ||
                            LPAD(
                                s.squad_id::TEXT,
                                3,
                                '0'
                            )
                                AS ""SquadNumber"",

                            st.squad_type_name
                                AS ""SquadType"",

                            ss.squad_status_name
                                AS ""SquadStatus"",

                            s.number_of_people
                                AS ""NumberOfPeople"",

                            schedule_data.schedule_id
                                AS ""ScheduleId"",

                            schedule_data.type_of_duty_name
                                AS ""DutyType"",

                            schedule_data.start_date
                                AS ""StartDate"",

                            schedule_data.end_date
                                AS ""EndDate"",

                            service_data.patrol_and_post_service_id
                                AS ""PatrolServiceId""

                        FROM squad s

                        INNER JOIN squad_type st
                            ON s.squad_type_id =
                               st.squad_type_id

                        INNER JOIN squad_status ss
                            ON s.squad_status_id =
                               ss.squad_status_id


                        LEFT JOIN LATERAL
                        (
                            SELECT

                                sch.schedule_id,

                                td.type_of_duty_name,

                                sch.planned_start_date_and_time
                                    AS start_date,

                                sch.planned_end_date_and_time
                                    AS end_date

                            FROM schedule sch

                            INNER JOIN type_of_duty td
                                ON sch.type_of_duty_id =
                                   td.type_of_duty_id

                            WHERE
                                sch.squad_id =
                                s.squad_id

                            ORDER BY
                                sch.planned_start_date_and_time DESC

                            LIMIT 1

                        )
                        schedule_data ON TRUE


                        LEFT JOIN LATERAL
                        (
                            SELECT
                                pps.patrol_and_post_service_id

                            FROM patrol_and_post_service pps

                            WHERE
                                pps.schedule_id =
                                schedule_data.schedule_id

                            LIMIT 1

                        )
                        service_data ON TRUE

                        " +
                        conditions +
                        @"

                        ORDER BY
                            s.squad_id DESC

                        LIMIT @limit

                        OFFSET @offset;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        AddSearchParameters(command);

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
                            squadsTable =
                                new DataTable();

                            adapter.Fill(
                                squadsTable);
                        }
                    }
                }


                LoadSquadCards();

                UpdatePagination();


                if (squadsTable.Rows.Count > 0)
                {
                    int squadId =
                        Convert.ToInt32(
                            squadsTable.Rows[0]["Id"]);

                    SelectSquad(squadId);
                }
                else
                {
                    ClearSquadInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки нарядов",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // SEARCH CONDITIONS
        // ============================================================

        private string BuildSearchConditions()
        {
            string conditions =
                @"
                WHERE 1 = 1
                ";


            if (!searchMode)
                return conditions;


            // NUMBER

            if (!string.IsNullOrWhiteSpace(
                txtSquadNumber.Text))
            {
                conditions +=
                    @"
                    AND
                    (
                        s.squad_id::TEXT
                        ILIKE @squad_number

                        OR

                        ('Н-' ||
                        LPAD(
                            s.squad_id::TEXT,
                            3,
                            '0'
                        ))
                        ILIKE @squad_number
                    )
                    ";
            }


            // TYPE

            ComboBoxItem typeItem =
                cmbSquadType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND
                    s.squad_type_id =
                    @squad_type_id
                    ";
            }


            // STATUS

            ComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as ComboBoxItem;

            if (statusItem != null &&
                statusItem.Id > 0)
            {
                conditions +=
                    @"
                    AND
                    s.squad_status_id =
                    @squad_status_id
                    ";
            }


            // EMPLOYEE

            ComboBoxItem employeeItem =
                cmbEmployee.SelectedItem
                as ComboBoxItem;

            if (employeeItem != null &&
                employeeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND EXISTS
                    (
                        SELECT 1

                        FROM employee_squad es

                        WHERE
                            es.squad_id =
                            s.squad_id

                            AND

                            es.employee_id =
                            @employee_id
                    )
                    ";
            }


            // DATE FROM

            if (dtDateFrom.Checked)
            {
                conditions +=
                    @"
                    AND EXISTS
                    (
                        SELECT 1

                        FROM schedule sch

                        WHERE
                            sch.squad_id =
                            s.squad_id

                            AND

                            sch.planned_start_date_and_time::DATE
                            >= @date_from
                    )
                    ";
            }


            // DATE TO

            if (dtDateTo.Checked)
            {
                conditions +=
                    @"
                    AND EXISTS
                    (
                        SELECT 1

                        FROM schedule sch

                        WHERE
                            sch.squad_id =
                            s.squad_id

                            AND

                            sch.planned_start_date_and_time::DATE
                            <= @date_to
                    )
                    ";
            }


            return conditions;
        }


        // ============================================================
        // SEARCH PARAMETERS
        // ============================================================

        private void AddSearchParameters(
            NpgsqlCommand command)
        {
            if (!searchMode)
                return;


            if (!string.IsNullOrWhiteSpace(
                txtSquadNumber.Text))
            {
                command.Parameters.AddWithValue(
                    "@squad_number",

                    "%" +
                    txtSquadNumber.Text.Trim() +
                    "%");
            }


            ComboBoxItem typeItem =
                cmbSquadType.SelectedItem
                as ComboBoxItem;

            if (typeItem != null &&
                typeItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@squad_type_id",
                    typeItem.Id);
            }


            ComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as ComboBoxItem;

            if (statusItem != null &&
                statusItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@squad_status_id",
                    statusItem.Id);
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


        // ============================================================
        // CREATE SQUAD CARDS
        // ============================================================

        private void LoadSquadCards()
        {
            flpSquads.SuspendLayout();

            flpSquads.Controls.Clear();


            if (squadsTable == null ||
                squadsTable.Rows.Count == 0)
            {
                Label emptyLabel =
                    new Label();

                emptyLabel.Text =
                    "Наряды не найдены";

                emptyLabel.ForeColor =
                    Color.Gainsboro;

                emptyLabel.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Bold);

                emptyLabel.AutoSize =
                    true;

                emptyLabel.Margin =
                    new Padding(
                        20,
                        30,
                        0,
                        0);

                flpSquads.Controls.Add(
                    emptyLabel);

                flpSquads.ResumeLayout();

                return;
            }


            foreach (DataRow row
                in squadsTable.Rows)
            {
                Panel card =
                    CreateSquadCard(row);

                flpSquads.Controls.Add(card);
            }


            flpSquads.ResumeLayout();
        }


        // ============================================================
        // CREATE ONE CARD
        // ============================================================

        private Panel CreateSquadCard(
            DataRow row)
        {
            int squadId =
                Convert.ToInt32(
                    row["Id"]);


            Panel card =
                new Panel();

            card.Size =
                new Size(
                    780,
                    58);

            card.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    8);

            card.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.Tag =
                squadId;


            // STATUS STRIPE

            Panel statusStripe =
                new Panel();

            statusStripe.Location =
                new Point(0, 0);

            statusStripe.Size =
                new Size(5, 58);

            statusStripe.BackColor =
                GetStatusColor(
                    row["SquadStatus"]
                    .ToString());

            card.Controls.Add(statusStripe);


            // NUMBER

            Label lblNumber =
                CreateCardLabel(
                    row["SquadNumber"].ToString(),
                    20,
                    15,
                    90,
                    FontStyle.Bold);


            // TYPE

            Label lblType =
                CreateCardLabel(
                    row["SquadType"].ToString(),
                    115,
                    10,
                    190,
                    FontStyle.Regular);


            // DATE

            string dateText =
                GetScheduleText(row);


            Label lblDate =
                CreateCardLabel(
                    dateText,
                    310,
                    10,
                    215,
                    FontStyle.Regular);


            // EMPLOYEE COUNT

            Label lblCount =
                CreateCardLabel(
                    row["NumberOfPeople"] +
                    " сотрудника",
                    530,
                    10,
                    105,
                    FontStyle.Regular);


            // STATUS

            Label lblStatus =
                CreateCardLabel(
                    row["SquadStatus"].ToString(),
                    645,
                    10,
                    90,
                    FontStyle.Bold);

            lblStatus.ForeColor =
                GetStatusColor(
                    row["SquadStatus"]
                    .ToString());


            // ARROW

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
                    745,
                    13);


            card.Controls.Add(lblNumber);
            card.Controls.Add(lblType);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblCount);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblArrow);


            // CLICK

            card.Click +=
                (s, e) =>
                {
                    SelectSquad(squadId);
                };


            foreach (Control control
                in card.Controls)
            {
                control.Click +=
                    (s, e) =>
                    {
                        SelectSquad(squadId);
                    };
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
                new Point(x, y);

            label.Size =
                new Size(width, 38);

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    style);

            return label;
        }


        private string GetScheduleText(
            DataRow row)
        {
            if (row["StartDate"] == DBNull.Value)
            {
                return
                    "График не назначен";
            }


            DateTime start =
                Convert.ToDateTime(
                    row["StartDate"]);


            if (row["EndDate"] == DBNull.Value)
            {
                return
                    start.ToString(
                        "dd.MM.yyyy HH:mm");
            }


            DateTime end =
                Convert.ToDateTime(
                    row["EndDate"]);


            return
                start.ToString(
                    "dd.MM.yyyy HH:mm") +

                " – " +

                end.ToString(
                    "dd.MM.yyyy HH:mm");
        }


        // ============================================================
        // SELECT SQUAD
        // ============================================================

        private void SelectSquad(
            int squadId)
        {
            selectedSquadId =
                squadId;

            DataRow selectedRow =
                null;


            foreach (DataRow row
                in squadsTable.Rows)
            {
                if (Convert.ToInt32(
                    row["Id"]) == squadId)
                {
                    selectedRow =
                        row;

                    break;
                }
            }


            if (selectedRow == null)
            {
                ClearSquadInformation();

                return;
            }


            selectedPatrolServiceId =
                selectedRow["PatrolServiceId"] ==
                DBNull.Value

                    ? 0

                    : Convert.ToInt32(
                        selectedRow[
                            "PatrolServiceId"]);


            UpdateSquadInformation();

            LoadRecentEvents();
        }


        // ============================================================
        // UPDATE RIGHT INFORMATION
        // ============================================================

        private void UpdateSquadInformation()
        {
            if (selectedSquadId <= 0)
                return;


            ResetInfoFields();

            UpdateTabAppearance();


            switch (activeTab)
            {
                case "MAIN":

                    LoadMainInformation();

                    break;


                case "COMPOSITION":

                    LoadCompositionInformation();

                    break;


                case "SCHEDULE":

                    LoadScheduleInformation();

                    break;


                case "ROUTE":

                    LoadRouteInformation();

                    break;
            }
        }


        // ============================================================
        // MAIN TAB
        // ============================================================

        private void LoadMainInformation()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT

                        'Н-' ||
                        LPAD(
                            s.squad_id::TEXT,
                            3,
                            '0'
                        )
                            AS squad_number,

                        st.squad_type_name,

                        ss.squad_status_name,

                        s.number_of_people,

                        (
                            SELECT COUNT(*)

                            FROM employee_squad es

                            WHERE
                                es.squad_id =
                                s.squad_id
                        )
                            AS actual_people

                    FROM squad s

                    INNER JOIN squad_type st
                        ON s.squad_type_id =
                           st.squad_type_id

                    INNER JOIN squad_status ss
                        ON s.squad_status_id =
                           ss.squad_status_id

                    WHERE
                        s.squad_id =
                        @squad_id;
                    ";


                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id",
                        selectedSquadId);


                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return;


                        lblInfo1Title.Text =
                            "№ наряда:";

                        lblInfo1Value.Text =
                            reader["squad_number"]
                            .ToString();


                        lblInfo2Title.Text =
                            "Тип наряда:";

                        lblInfo2Value.Text =
                            reader["squad_type_name"]
                            .ToString();


                        lblInfo3Title.Text =
                            "Статус:";

                        lblInfo3Value.Text =
                            reader["squad_status_name"]
                            .ToString();


                        lblInfo4Title.Text =
                            "Количество:";

                        lblInfo4Value.Text =
                            reader[
                                "number_of_people"] +
                            " человек";


                        lblInfo5Title.Text =
                            "В составе:";

                        lblInfo5Value.Text =
                            reader[
                                "actual_people"] +
                            " сотрудников";
                    }
                }
            }
        }


        // ============================================================
        // COMPOSITION TAB
        // ============================================================

        private void LoadCompositionInformation()
        {
            lblInfo1Title.Text =
                "Состав:";

            lblInfo1Value.Text =
                "";


            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT

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

                        p.post_name

                    FROM employee_squad es

                    INNER JOIN employee e
                        ON es.employee_id =
                           e.employee_id

                    LEFT JOIN post p
                        ON e.post_id =
                           p.post_id

                    WHERE
                        es.squad_id =
                        @squad_id

                    ORDER BY
                        e.last_name;
                    ";


                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id",
                        selectedSquadId);


                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        int index = 1;


                        while (reader.Read() &&
                            index <= 7)
                        {
                            SetInfoRow(
                                index,

                                reader[
                                    "employee_name"]
                                .ToString(),

                                reader["post_name"] ==
                                DBNull.Value

                                    ? ""

                                    : reader[
                                        "post_name"]
                                      .ToString());

                            index++;
                        }


                        if (index == 1)
                        {
                            lblInfo1Value.Text =
                                "Сотрудники не назначены";
                        }
                    }
                }
            }
        }


        // ============================================================
        // SCHEDULE TAB
        // ============================================================

        private void LoadScheduleInformation()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT

                        td.type_of_duty_name,

                        sch.planned_start_date_and_time,

                        sch.planned_end_date_and_time

                    FROM schedule sch

                    INNER JOIN type_of_duty td
                        ON sch.type_of_duty_id =
                           td.type_of_duty_id

                    WHERE
                        sch.squad_id =
                        @squad_id

                    ORDER BY
                        sch.planned_start_date_and_time DESC

                    LIMIT 1;
                    ";


                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id",
                        selectedSquadId);


                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            lblInfo1Title.Text =
                                "График:";

                            lblInfo1Value.Text =
                                "Не назначен";

                            return;
                        }


                        lblInfo1Title.Text =
                            "Тип службы:";

                        lblInfo1Value.Text =
                            reader[
                                "type_of_duty_name"]
                            .ToString();


                        lblInfo2Title.Text =
                            "Начало:";

                        lblInfo2Value.Text =
                            Convert.ToDateTime(
                                reader[
                                    "planned_start_date_and_time"])
                            .ToString(
                                "dd.MM.yyyy HH:mm");


                        lblInfo3Title.Text =
                            "Окончание:";

                        lblInfo3Value.Text =
                            Convert.ToDateTime(
                                reader[
                                    "planned_end_date_and_time"])
                            .ToString(
                                "dd.MM.yyyy HH:mm");
                    }
                }
            }
        }


        // ============================================================
        // ROUTE TAB
        // ============================================================

        private void LoadRouteInformation()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT

                        tom.type_of_movement_name,

                        cr.crime_rate_name,

                        pps.description,

                        pps.length_of_the_route_km,

                        pps.estimated_time,

                        pps.route

                    FROM patrol_and_post_service pps

                    INNER JOIN schedule sch
                        ON pps.schedule_id =
                           sch.schedule_id

                    INNER JOIN type_of_movement tom
                        ON pps.type_of_movement_id =
                           tom.type_of_movement_id

                    INNER JOIN crime_rate cr
                        ON pps.crime_rate_id =
                           cr.crime_rate_id

                    WHERE
                        sch.squad_id =
                        @squad_id

                    ORDER BY
                        sch.planned_start_date_and_time DESC

                    LIMIT 1;
                    ";


                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id",
                        selectedSquadId);


                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            lblInfo1Title.Text =
                                "Маршрут:";

                            lblInfo1Value.Text =
                                "Не назначен";

                            return;
                        }


                        lblInfo1Title.Text =
                            "Передвижение:";

                        lblInfo1Value.Text =
                            reader[
                                "type_of_movement_name"]
                            .ToString();


                        lblInfo2Title.Text =
                            "Уровень:";

                        lblInfo2Value.Text =
                            reader[
                                "crime_rate_name"]
                            .ToString();


                        lblInfo3Title.Text =
                            "Длина маршрута:";

                        lblInfo3Value.Text =
                            reader[
                                "length_of_the_route_km"] +
                            " км";


                        lblInfo4Title.Text =
                            "Расчётное время:";

                        lblInfo4Value.Text =
                            reader[
                                "estimated_time"]
                            .ToString();


                        lblInfo5Title.Text =
                            "Маршрут:";

                        lblInfo5Value.Text =
                            reader["route"]
                            .ToString();


                        lblInfo6Title.Text =
                            "Описание:";

                        lblInfo6Value.Text =
                            reader["description"]
                            .ToString();
                    }
                }
            }
        }


        // ============================================================
        // SET INFO ROW
        // ============================================================

        private void SetInfoRow(
            int index,
            string title,
            string value)
        {
            switch (index)
            {
                case 1:

                    lblInfo1Title.Text = title;
                    lblInfo1Value.Text = value;

                    break;

                case 2:

                    lblInfo2Title.Text = title;
                    lblInfo2Value.Text = value;

                    break;

                case 3:

                    lblInfo3Title.Text = title;
                    lblInfo3Value.Text = value;

                    break;

                case 4:

                    lblInfo4Title.Text = title;
                    lblInfo4Value.Text = value;

                    break;

                case 5:

                    lblInfo5Title.Text = title;
                    lblInfo5Value.Text = value;

                    break;

                case 6:

                    lblInfo6Title.Text = title;
                    lblInfo6Value.Text = value;

                    break;

                case 7:

                    lblInfo7Title.Text = title;
                    lblInfo7Value.Text = value;

                    break;
            }
        }


        // ============================================================
        // RESET INFORMATION
        // ============================================================

        private void ResetInfoFields()
        {
            Label[] titles =
            {
                lblInfo1Title,
                lblInfo2Title,
                lblInfo3Title,
                lblInfo4Title,
                lblInfo5Title,
                lblInfo6Title,
                lblInfo7Title
            };


            Label[] values =
            {
                lblInfo1Value,
                lblInfo2Value,
                lblInfo3Value,
                lblInfo4Value,
                lblInfo5Value,
                lblInfo6Value,
                lblInfo7Value
            };


            foreach (Label label in titles)
            {
                label.Text = "";
            }


            foreach (Label label in values)
            {
                label.Text = "";
            }
        }


        // ============================================================
        // TABS APPEARANCE
        // ============================================================

        private void UpdateTabAppearance()
        {
            lblTabMain.ForeColor =
                Color.Gainsboro;

            lblTabComposition.ForeColor =
                Color.Gainsboro;

            lblTabSchedule.ForeColor =
                Color.Gainsboro;

            lblTabRoute.ForeColor =
                Color.Gainsboro;


            switch (activeTab)
            {
                case "MAIN":

                    lblTabMain.ForeColor =
                        Color.FromArgb(
                            212,
                            160,
                            23);

                    pnlTabLine.Location =
                        new Point(18, 80);

                    break;


                case "COMPOSITION":

                    lblTabComposition.ForeColor =
                        Color.FromArgb(
                            212,
                            160,
                            23);

                    pnlTabLine.Location =
                        new Point(110, 80);

                    break;


                case "SCHEDULE":

                    lblTabSchedule.ForeColor =
                        Color.FromArgb(
                            212,
                            160,
                            23);

                    pnlTabLine.Location =
                        new Point(185, 80);

                    break;


                case "ROUTE":

                    lblTabRoute.ForeColor =
                        Color.FromArgb(
                            212,
                            160,
                            23);

                    pnlTabLine.Location =
                        new Point(270, 80);

                    break;
            }
        }


        // ============================================================
        // RECENT EVENTS
        // ============================================================

        private void LoadRecentEvents()
        {
            flpEvents.Controls.Clear();


            if (selectedPatrolServiceId <= 0)
            {
                AddEmptyEventsMessage(
                    "Для этого наряда событий пока нет.");

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
                        SELECT

                            pel.patrol_event_log_id,

                            rt.recording_type_name,

                            cr.crime_rate_name,

                            pel.scene_of_the_incident,

                            pel.recording_date_and_time,

                            pel.description_recording,

                            pel.patrol_event_log_file

                        FROM patrol_event_log pel

                        INNER JOIN recording_type rt
                            ON pel.recording_type_id =
                               rt.recording_type_id

                        INNER JOIN crime_rate cr
                            ON pel.crime_rate_id =
                               cr.crime_rate_id

                        WHERE
                            pel.patrol_and_post_service_id =
                            @service_id

                        ORDER BY
                            pel.recording_date_and_time DESC

                        LIMIT 3;
                        ";


                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@service_id",
                            selectedPatrolServiceId);


                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(
                                command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);


                            if (table.Rows.Count == 0)
                            {
                                AddEmptyEventsMessage(
                                    "Для этого наряда событий пока нет.");

                                return;
                            }


                            foreach (DataRow row
                                in table.Rows)
                            {
                                flpEvents.Controls.Add(
                                    CreateEventCard(row));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddEmptyEventsMessage(
                    "Не удалось загрузить события.");
            }
        }


        // ============================================================
        // EVENT CARD
        // ============================================================

        private Panel CreateEventCard(
            DataRow row)
        {
            Panel panel =
                new Panel();

            panel.Size =
                new Size(370, 45);

            panel.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    5);

            panel.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            panel.BorderStyle =
                BorderStyle.FixedSingle;


            Label lblDate =
                new Label();

            lblDate.Text =
                Convert.ToDateTime(
                    row["recording_date_and_time"])
                .ToString(
                    "dd.MM HH:mm");

            lblDate.ForeColor =
                Color.Gainsboro;

            lblDate.Location =
                new Point(8, 13);

            lblDate.Size =
                new Size(75, 20);


            Label lblType =
                new Label();

            lblType.Text =
                row["recording_type_name"]
                .ToString();

            lblType.ForeColor =
                Color.White;

            lblType.Location =
                new Point(85, 13);

            lblType.Size =
                new Size(90, 20);


            Label lblPlace =
                new Label();

            lblPlace.Text =
                row["scene_of_the_incident"]
                .ToString();

            lblPlace.ForeColor =
                Color.Gainsboro;

            lblPlace.Location =
                new Point(180, 13);

            lblPlace.Size =
                new Size(120, 20);


            Label lblLevel =
                new Label();

            lblLevel.Text =
                row["crime_rate_name"]
                .ToString();

            lblLevel.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold);

            lblLevel.ForeColor =
                GetCrimeRateColor(
                    row["crime_rate_name"]
                    .ToString());

            lblLevel.Location =
                new Point(305, 13);

            lblLevel.Size =
                new Size(60, 20);


            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblType);
            panel.Controls.Add(lblPlace);
            panel.Controls.Add(lblLevel);


            return panel;
        }


        private void AddEmptyEventsMessage(
            string text)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.AutoSize =
                true;

            label.Margin =
                new Padding(
                    10,
                    20,
                    0,
                    0);

            flpEvents.Controls.Add(label);
        }


        // ============================================================
        // STATUS COLOR
        // ============================================================

        private Color GetStatusColor(
            string status)
        {
            status =
                status.ToLower();


            if (status.Contains("служб") ||
                status.Contains("актив"))
            {
                return
                    Color.FromArgb(
                        120,
                        190,
                        120);
            }


            if (status.Contains("заверш"))
            {
                return
                    Color.FromArgb(
                        120,
                        190,
                        120);
            }


            if (status.Contains("назнач"))
            {
                return
                    Color.FromArgb(
                        212,
                        160,
                        23);
            }


            if (status.Contains("отмен"))
            {
                return
                    Color.FromArgb(
                        190,
                        100,
                        100);
            }


            return
                Color.FromArgb(
                    212,
                    160,
                    23);
        }


        private Color GetCrimeRateColor(
            string level)
        {
            level =
                level.ToLower();


            if (level.Contains("низк"))
            {
                return
                    Color.LightGreen;
            }


            if (level.Contains("средн"))
            {
                return
                    Color.FromArgb(
                        235,
                        190,
                        70);
            }


            if (level.Contains("высок"))
            {
                return
                    Color.Salmon;
            }


            return
                Color.Gainsboro;
        }


        // ============================================================
        // PAGINATION
        // ============================================================

        private void UpdatePagination()
        {
            int from =
                totalRecords == 0

                    ? 0

                    : ((currentPage - 1) *
                       PageSize) + 1;


            int to =
                Math.Min(
                    currentPage * PageSize,
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


        // ============================================================
        // SEARCH EVENTS
        // ============================================================

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            searchMode = true;

            currentPage = 1;

            LoadSquads();
        }


        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtSquadNumber.Clear();

            cmbSquadType.SelectedIndex = 0;

            cmbStatus.SelectedIndex = 0;

            cmbEmployee.SelectedIndex = 0;

            dtDateFrom.Checked = false;

            dtDateTo.Checked = false;

            searchMode = false;

            currentPage = 1;

            LoadSquads();
        }


        // ============================================================
        // PAGINATION EVENTS
        // ============================================================

        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage = 1;

            LoadSquads();
        }


        private void BtnPreviousPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
                return;

            currentPage--;

            LoadSquads();
        }


        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;

            currentPage++;

            LoadSquads();
        }


        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage =
                totalPages;

            LoadSquads();
        }


        // ============================================================
        // ADD SQUAD
        // ============================================================

        private void BtnAddSquad_Click(
    object sender,
    EventArgs e)
        {
            using (SquadEditForm form =
                new SquadEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;
                    LoadSquads();
                }
            }
        }


        // ============================================================
        // EDIT SQUAD
        // ============================================================

        private void BtnEditSquad_Click(
    object sender,
    EventArgs e)
        {
            if (selectedSquadId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите наряд.",
                    "Редактирование наряда",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (SquadEditForm form =
                new SquadEditForm(selectedSquadId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadSquads();
                }
            }
        }


        // ============================================================
        // ADD EVENT
        // ============================================================

        private void BtnAddEvent_Click(
            object sender,
            EventArgs e)
        {
            // Событие можно добавить только для выбранного наряда
            // с уже созданным патрульно-постовым обслуживанием.
            if (selectedSquadId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите наряд из списка.",
                    "Добавление события",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (selectedPatrolServiceId <= 0)
            {
                MessageBox.Show(
                    "Для выбранного наряда не назначено патрульно-постовое обслуживание.",
                    "Добавление события",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            string squadNumber =
                "Н-" + selectedSquadId.ToString("000");

            using (PatrolEventAddForm form =
                new PatrolEventAddForm(
                    selectedPatrolServiceId,
                    squadNumber))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    // После сохранения сразу обновляем события
                    // в правой панели текущего наряда.
                    LoadRecentEvents();
                }
            }
        }


        // ============================================================
        // FULL JOURNAL
        // ============================================================

        private void BtnOpenFullJournal_Click(
     object sender,
     EventArgs e)
        {
            if (selectedPatrolServiceId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите наряд с назначенным патрульно-постовым обслуживанием.",
                    "Журнал событий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            try
            {
                string squadNumber =
                    "Н-" +
                    selectedSquadId
                        .ToString("000");


                using (
                    PatrolEventJournalForm form =
                    new PatrolEventJournalForm(
                        selectedPatrolServiceId,
                        squadNumber))
                {
                    form.ShowDialog(
                        this.FindForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось открыть полный журнал событий.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // CLEAR INFORMATION
        // ============================================================

        private void ClearSquadInformation()
        {
            selectedSquadId = 0;

            selectedPatrolServiceId = 0;

            ResetInfoFields();

            lblInfo1Title.Text =
                "Наряд:";

            lblInfo1Value.Text =
                "—";


            lblInfo2Title.Text =
                "Статус:";

            lblInfo2Value.Text =
                "—";


            flpEvents.Controls.Clear();

            AddEmptyEventsMessage(
                "Выберите наряд для просмотра событий.");
        }
    }
}