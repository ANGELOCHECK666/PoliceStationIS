using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Equipment
{
    public class EquipmentComboBoxItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


    public partial class EquipmentPage : UserControl
    {
        private const int PageSize = 6;

        private DataTable equipmentTable;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private int selectedEquipmentId = 0;

        private bool searchMode = false;


        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public EquipmentPage()
        {
            InitializeComponent();

            ConfigureControls();

            ConfigureEvents();

            InitializePage();

            ClearEquipmentInformation();
        }


        // ============================================================
        // CONTROLS
        // ============================================================

        private void ConfigureControls()
        {
            ConfigureComboBox(
                cmbCategory);

            ConfigureComboBox(
                cmbStatus);

            ConfigureComboBox(
                cmbEmployee);

            txtEquipmentName.CharacterCasing =
                CharacterCasing.Normal;

            lblPageInfo.Text =
                "0–0 из 0";
        }


        private void ConfigureComboBox(
            ComboBox comboBox)
        {
            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

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


        // ============================================================
        // EVENTS
        // ============================================================

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


            btnAddEquipment.Click +=
                BtnAddEquipment_Click;

            btnEditEquipment.Click +=
                BtnEditEquipment_Click;


            btnWarehouse.Click +=
                BtnWarehouse_Click;

            btnIssueRequests.Click +=
                BtnIssueRequests_Click;

            btnMaintenance.Click +=
                BtnMaintenance_Click;
        }


        // ============================================================
        // INITIALIZATION
        // ============================================================

        private void InitializePage()
        {
            try
            {
                LoadCategories();

                LoadStatuses();

                LoadEmployees();

                LoadEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки раздела экипировки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // LOAD CATEGORIES
        // ============================================================

        private void LoadCategories()
        {
            using (
                NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
                    SELECT
                        equipment_category_id,
                        equipment_category_name
                    FROM equipment_category
                    ORDER BY equipment_category_name;
                ";

                using (
                    NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                {
                    using (
                        NpgsqlDataReader reader =
                            command.ExecuteReader())
                    {
                        cmbCategory.Items.Clear();

                        cmbCategory.Items.Add(
                            new EquipmentComboBoxItem
                            {
                                Id = 0,
                                Name = "Все категории"
                            });

                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(
                                new EquipmentComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "equipment_category_id"]),

                                    Name =
                                        reader[
                                            "equipment_category_name"]
                                        .ToString()
                                });
                        }
                    }
                }
            }

            cmbCategory.SelectedIndex = 0;
        }


        // ============================================================
        // LOAD STATUSES
        // ============================================================

        private void LoadStatuses()
        {
            using (
                NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
                    SELECT
                        equipment_status_id,
                        equipment_status_name
                    FROM equipment_status
                    ORDER BY equipment_status_name;
                ";

                using (
                    NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                {
                    using (
                        NpgsqlDataReader reader =
                            command.ExecuteReader())
                    {
                        cmbStatus.Items.Clear();

                        cmbStatus.Items.Add(
                            new EquipmentComboBoxItem
                            {
                                Id = 0,
                                Name = "Все статусы"
                            });

                        while (reader.Read())
                        {
                            cmbStatus.Items.Add(
                                new EquipmentComboBoxItem
                                {
                                    Id =
                                        Convert.ToInt32(
                                            reader[
                                                "equipment_status_id"]),

                                    Name =
                                        reader[
                                            "equipment_status_name"]
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
            using (
                NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
                    SELECT
                        employee_id,

                        last_name || ' ' ||
                        name_ || ' ' ||
                        COALESCE(
                            middle_name,
                            ''
                        ) AS full_name

                    FROM employee

                    ORDER BY
                        last_name,
                        name_;
                ";

                using (
                    NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                {
                    using (
                        NpgsqlDataReader reader =
                            command.ExecuteReader())
                    {
                        cmbEmployee.Items.Clear();

                        cmbEmployee.Items.Add(
                            new EquipmentComboBoxItem
                            {
                                Id = 0,
                                Name = "Все сотрудники"
                            });

                        while (reader.Read())
                        {
                            cmbEmployee.Items.Add(
                                new EquipmentComboBoxItem
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
        // LOAD EQUIPMENT
        // ============================================================

        private void LoadEquipment()
        {
            try
            {
                using (
                    NpgsqlConnection connection =
                        DatabaseConnection.GetConnection())
                {
                    connection.Open();


                    string conditions =
                        BuildSearchConditions();


                    // ------------------------------------------------
                    // COMMON JOINS
                    // ------------------------------------------------

                    string fromJoin = @"
                        FROM equipment e

                        INNER JOIN equipment_category ec
                            ON e.equipment_category_id =
                               ec.equipment_category_id

                        INNER JOIN equipment_status es
                            ON e.equipment_status_id =
                               es.equipment_status_id

                        INNER JOIN employee emp
                            ON e.employee_id =
                               emp.employee_id


                        LEFT JOIN special_equipment se
                            ON se.equipment_id =
                               e.equipment_id

                        LEFT JOIN special_equipment_type setype
                            ON setype.special_equipment_type_id =
                               se.special_equipment_type_id


                        LEFT JOIN weapon w
                            ON w.equipment_id =
                               e.equipment_id

                        LEFT JOIN weapon_type wt
                            ON wt.weapon_type_id =
                               w.weapon_type_id

                        LEFT JOIN weapon_model wm
                            ON wm.weapon_model_id =
                               w.weapon_model_id


                        LEFT JOIN dog_gear dg
                            ON dg.equipment_id =
                               e.equipment_id

                        LEFT JOIN gear_type gt
                            ON gt.gear_type_id =
                               dg.gear_type_id


                        LEFT JOIN vehicle v
                            ON v.equipment_id =
                               e.equipment_id

                        LEFT JOIN vehicle_brand vb
                            ON vb.vehicle_brand_id =
                               v.vehicle_brand_id
                    ";


                    // ------------------------------------------------
                    // COUNT
                    // ------------------------------------------------

                    string countQuery =
                        "SELECT COUNT(*) " +
                        fromJoin +
                        conditions;


                    using (
                        NpgsqlCommand countCommand =
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


                    if (currentPage >
                        totalPages)
                    {
                        currentPage =
                            totalPages;
                    }


                    // ------------------------------------------------
                    // MAIN QUERY
                    // ------------------------------------------------

                    string query = @"
                        SELECT

                            e.equipment_id
                                AS ""Id"",

                            e.equipment_name
                                AS ""EquipmentName"",

                            ec.equipment_category_name
                                AS ""CategoryName"",

                            es.equipment_status_name
                                AS ""StatusName"",

                            emp.employee_id
                                AS ""EmployeeId"",

                            emp.last_name || ' ' ||
                            emp.name_ || ' ' ||
                            COALESCE(
                                emp.middle_name,
                                ''
                            )
                                AS ""EmployeeName"",

                            e.equipment_date_of_issue
                                AS ""IssueDate"",


                            COALESCE(
                                setype.special_equipment_type_name,
                                wt.weapon_type_name,
                                gt.gear_type_name,
                                vb.vehicle_brand_name,
                                ''
                            )
                                AS ""SubtypeName"",


                            COALESCE(
                                se.special_equipment_number,
                                w.serial_number,
                                dg.gear_serial_number,
                                v.plate_number,
                                ''
                            )
                                AS ""Identifier"",


                            COALESCE(
                                wm.weapon_model_name,
                                ''
                            )
                                AS ""WeaponModel"",


                            COALESCE(
                                w.caliber,
                                ''
                            )
                                AS ""Caliber"",


                            COALESCE(
                                v.vin_number,
                                ''
                            )
                                AS ""VinNumber"",


                            v.mileage_km
                                AS ""Mileage""

                        " +
                        fromJoin +
                        conditions +
                        @"

                        ORDER BY
                            e.equipment_id DESC

                        LIMIT @limit

                        OFFSET @offset;
                    ";


                    using (
                        NpgsqlCommand command =
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


                        using (
                            NpgsqlDataAdapter adapter =
                                new NpgsqlDataAdapter(
                                    command))
                        {
                            equipmentTable =
                                new DataTable();

                            adapter.Fill(
                                equipmentTable);
                        }
                    }
                }


                LoadEquipmentRows();

                UpdatePagination();


                if (equipmentTable.Rows.Count > 0)
                {
                    SelectEquipment(
                        Convert.ToInt32(
                            equipmentTable.Rows[0]["Id"]));
                }
                else
                {
                    ClearEquipmentInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки экипировки",
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


            // NAME

            if (!string.IsNullOrWhiteSpace(
                txtEquipmentName.Text))
            {
                conditions +=
                    @"
                    AND
                    e.equipment_name
                    ILIKE @equipment_name
                    ";
            }


            // CATEGORY

            EquipmentComboBoxItem categoryItem =
                cmbCategory.SelectedItem
                as EquipmentComboBoxItem;

            if (
                categoryItem != null &&
                categoryItem.Id > 0)
            {
                conditions +=
                    @"
                    AND
                    e.equipment_category_id =
                    @category_id
                    ";
            }


            // STATUS

            EquipmentComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as EquipmentComboBoxItem;

            if (
                statusItem != null &&
                statusItem.Id > 0)
            {
                conditions +=
                    @"
                    AND
                    e.equipment_status_id =
                    @status_id
                    ";
            }


            // EMPLOYEE

            EquipmentComboBoxItem employeeItem =
                cmbEmployee.SelectedItem
                as EquipmentComboBoxItem;

            if (
                employeeItem != null &&
                employeeItem.Id > 0)
            {
                conditions +=
                    @"
                    AND
                    e.employee_id =
                    @employee_id
                    ";
            }


            // DATE FROM

            if (dtDateFrom.Checked)
            {
                conditions +=
                    @"
                    AND
                    e.equipment_date_of_issue >=
                    @date_from
                    ";
            }


            // DATE TO

            if (dtDateTo.Checked)
            {
                conditions +=
                    @"
                    AND
                    e.equipment_date_of_issue <=
                    @date_to
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
                txtEquipmentName.Text))
            {
                command.Parameters.AddWithValue(
                    "@equipment_name",
                    "%" +
                    txtEquipmentName.Text.Trim() +
                    "%");
            }


            EquipmentComboBoxItem categoryItem =
                cmbCategory.SelectedItem
                as EquipmentComboBoxItem;

            if (
                categoryItem != null &&
                categoryItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@category_id",
                    categoryItem.Id);
            }


            EquipmentComboBoxItem statusItem =
                cmbStatus.SelectedItem
                as EquipmentComboBoxItem;

            if (
                statusItem != null &&
                statusItem.Id > 0)
            {
                command.Parameters.AddWithValue(
                    "@status_id",
                    statusItem.Id);
            }


            EquipmentComboBoxItem employeeItem =
                cmbEmployee.SelectedItem
                as EquipmentComboBoxItem;

            if (
                employeeItem != null &&
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
        // LIST
        // ============================================================

        private void LoadEquipmentRows()
        {
            flpEquipment.SuspendLayout();

            flpEquipment.Controls.Clear();


            if (
                equipmentTable == null ||
                equipmentTable.Rows.Count == 0)
            {
                Label empty =
                    new Label();

                empty.Text =
                    "Имущество не найдено";

                empty.ForeColor =
                    Color.Gainsboro;

                empty.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Bold);

                empty.AutoSize =
                    true;

                empty.Margin =
                    new Padding(
                        20,
                        30,
                        0,
                        0);

                flpEquipment.Controls.Add(
                    empty);

                flpEquipment.ResumeLayout();

                return;
            }


            foreach (
                DataRow row
                in equipmentTable.Rows)
            {
                flpEquipment.Controls.Add(
                    CreateEquipmentRow(
                        row));
            }


            flpEquipment.ResumeLayout();
        }


        // ============================================================
        // ONE EQUIPMENT ROW
        // ============================================================

        private Panel CreateEquipmentRow(
            DataRow row)
        {
            int equipmentId =
                Convert.ToInt32(
                    row["Id"]);


            Panel rowPanel =
                new Panel();

            rowPanel.Size =
                new Size(
                    780,
                    58);

            rowPanel.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    8);

            rowPanel.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            rowPanel.BorderStyle =
                BorderStyle.FixedSingle;

            rowPanel.Tag =
                equipmentId;


            // STATUS STRIPE

            Panel stripe =
                new Panel();

            stripe.Location =
                new Point(
                    0,
                    0);

            stripe.Size =
                new Size(
                    5,
                    58);

            stripe.BackColor =
                GetStatusColor(
                    row["StatusName"]
                    .ToString());


            // NAME

            Label number =
                CreateRowLabel(
                    row["EquipmentName"]
                        .ToString(),

                    20,
                    9,
                    205,

                    FontStyle.Bold);


            // CATEGORY

            Label category =
                CreateRowLabel(
                    row["CategoryName"]
                        .ToString(),

                    225,
                    9,
                    150,

                    FontStyle.Regular);


            // EMPLOYEE

            Label employee =
                CreateRowLabel(
                    row["EmployeeName"]
                        .ToString(),

                    375,
                    9,
                    175,

                    FontStyle.Regular);


            // DATE

            Label date =
                CreateRowLabel(
                    Convert.ToDateTime(
                        row["IssueDate"])
                    .ToString(
                        "dd.MM.yyyy"),

                    550,
                    9,
                    95,

                    FontStyle.Regular);


            // STATUS

            Label status =
                CreateRowLabel(
                    row["StatusName"]
                        .ToString(),

                    645,
                    9,
                    95,

                    FontStyle.Bold);


            status.ForeColor =
                GetStatusColor(
                    row["StatusName"]
                    .ToString());


            // ARROW

            Label arrow =
                new Label();

            arrow.Text =
                "›";

            arrow.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            arrow.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            arrow.AutoSize =
                true;

            arrow.Location =
                new Point(
                    748,
                    12);


            rowPanel.Controls.Add(
                stripe);

            rowPanel.Controls.Add(
                number);

            rowPanel.Controls.Add(
                category);

            rowPanel.Controls.Add(
                employee);

            rowPanel.Controls.Add(
                date);

            rowPanel.Controls.Add(
                status);

            rowPanel.Controls.Add(
                arrow);


            rowPanel.Click +=
                (s, e) =>
                {
                    SelectEquipment(
                        equipmentId);
                };


            foreach (
                Control control
                in rowPanel.Controls)
            {
                control.Click +=
                    (s, e) =>
                    {
                        SelectEquipment(
                            equipmentId);
                    };
            }


            return rowPanel;
        }


        private Label CreateRowLabel(
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
                    38);

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    style);

            label.AutoEllipsis =
                true;

            return label;
        }


        // ============================================================
        // SELECT EQUIPMENT
        // ============================================================

        private void SelectEquipment(
            int equipmentId)
        {
            selectedEquipmentId =
                equipmentId;


            if (equipmentTable == null)
            {
                ClearEquipmentInformation();

                return;
            }


            foreach (
                DataRow row
                in equipmentTable.Rows)
            {
                if (
                    Convert.ToInt32(
                        row["Id"]) ==
                    equipmentId)
                {
                    UpdateEquipmentInformation(
                        row);

                    return;
                }
            }


            ClearEquipmentInformation();
        }


        // ============================================================
        // INFORMATION
        // ============================================================

        private void UpdateEquipmentInformation(
            DataRow row)
        {
            lblInfo1Title.Text =
                "Наименование:";

            lblInfo1Value.Text =
                row["EquipmentName"]
                .ToString();


            lblInfo2Title.Text =
                "Категория:";

            lblInfo2Value.Text =
                row["CategoryName"]
                .ToString();


            lblInfo3Title.Text =
                "Статус:";

            lblInfo3Value.Text =
                row["StatusName"]
                .ToString();

            lblInfo3Value.ForeColor =
                GetStatusColor(
                    row["StatusName"]
                    .ToString());


            lblInfo4Title.Text =
                "Выдано сотруднику:";

            lblInfo4Value.Text =
                row["EmployeeName"]
                .ToString();


            lblInfo5Title.Text =
                "Дата выдачи:";

            lblInfo5Value.Text =
                Convert.ToDateTime(
                    row["IssueDate"])
                .ToString(
                    "dd.MM.yyyy");


            lblInfo6Title.Text =
                "Номер / идентификатор:";


            string identifier =
                row["Identifier"] ==
                DBNull.Value

                    ? ""

                    : row["Identifier"]
                        .ToString();


            lblInfo6Value.Text =
                string.IsNullOrWhiteSpace(
                    identifier)

                    ? "—"

                    : identifier;


            lblInfo7Title.Text =
                "Дополнительно:";

            lblInfo7Value.Text =
                BuildAdditionalInfo(
                    row);
        }


        // ============================================================
        // ADDITIONAL INFORMATION
        // ============================================================

        private string BuildAdditionalInfo(
            DataRow row)
        {
            string category =
                row["CategoryName"]
                .ToString();

            string subtype =
                row["SubtypeName"] ==
                DBNull.Value

                    ? ""

                    : row["SubtypeName"]
                        .ToString();


            string result =
                subtype;


            // WEAPON

            if (
                category.ToLower()
                    .Contains("оруж"))
            {
                string model =
                    row["WeaponModel"]
                    .ToString();

                string caliber =
                    row["Caliber"]
                    .ToString();


                if (!string.IsNullOrWhiteSpace(
                    model))
                {
                    result +=
                        (
                            string.IsNullOrWhiteSpace(
                                result)

                                ? ""

                                : ", "
                        ) +
                        model;
                }


                if (!string.IsNullOrWhiteSpace(
                    caliber))
                {
                    result +=
                        (
                            string.IsNullOrWhiteSpace(
                                result)

                                ? ""

                                : ", "
                        ) +
                        "калибр " +
                        caliber;
                }
            }


            // VEHICLE

            if (
                category.ToLower()
                    .Contains("транспорт"))
            {
                string vin =
                    row["VinNumber"]
                    .ToString();


                if (!string.IsNullOrWhiteSpace(
                    vin))
                {
                    result +=
                        (
                            string.IsNullOrWhiteSpace(
                                result)

                                ? ""

                                : ", "
                        ) +
                        "VIN " +
                        vin;
                }


                if (
                    row["Mileage"] !=
                    DBNull.Value)
                {
                    result +=
                        (
                            string.IsNullOrWhiteSpace(
                                result)

                                ? ""

                                : ", "
                        ) +
                        "пробег " +
                        row["Mileage"] +
                        " км";
                }
            }


            if (
                string.IsNullOrWhiteSpace(
                    result))
            {
                return "—";
            }


            return result;
        }


        // ============================================================
        // STATUS COLOR
        // ============================================================

        private Color GetStatusColor(
            string status)
        {
            string value =
                (status ?? "")
                .ToLower();


            if (
                value.Contains("исправ") ||
                value.Contains("складе") ||
                value.Contains("свобод"))
            {
                return
                    Color.FromArgb(
                        120,
                        190,
                        120);
            }


            if (
                value.Contains("обслуж") ||
                value.Contains("выдан") ||
                value.Contains("резерв"))
            {
                return
                    Color.FromArgb(
                        235,
                        190,
                        70);
            }


            if (
                value.Contains("спис") ||
                value.Contains("неисправ"))
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


        // ============================================================
        // SEARCH
        // ============================================================

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            searchMode = true;

            currentPage = 1;

            LoadEquipment();
        }


        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtEquipmentName.Clear();

            cmbCategory.SelectedIndex =
                0;

            cmbStatus.SelectedIndex =
                0;

            cmbEmployee.SelectedIndex =
                0;

            dtDateFrom.Checked =
                false;

            dtDateTo.Checked =
                false;


            searchMode = false;

            currentPage = 1;

            LoadEquipment();
        }


        // ============================================================
        // PAGINATION EVENTS
        // ============================================================

        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage = 1;

            LoadEquipment();
        }


        private void BtnPreviousPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
                return;

            currentPage--;

            LoadEquipment();
        }


        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;

            currentPage++;

            LoadEquipment();
        }


        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            currentPage =
                totalPages;

            LoadEquipment();
        }


        // ============================================================
        // ADD
        // ============================================================

        private void BtnAddEquipment_Click(object sender, EventArgs e)
        {
            using (EquipmentEditForm form =
                new EquipmentEditForm())
            {
                if (form.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadEquipment();
                }
            }
        }


        // ============================================================
        // EDIT
        // ============================================================

        private void BtnEditEquipment_Click(object sender, EventArgs e)
        {
            if (selectedEquipmentId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите имущество.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (EquipmentEditForm form =
                new EquipmentEditForm(selectedEquipmentId))
            {
                if (form.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    LoadEquipment();
                }
            }
        }


        // ============================================================
        // WAREHOUSE
        // ============================================================

        private void BtnWarehouse_Click(
    object sender,
    EventArgs e)
        {
            using (WarehouseManagementForm form =
                new WarehouseManagementForm())
            {
                form.ShowDialog(
                    this.FindForm());
            }
        }


        // ============================================================
        // ISSUE REQUESTS
        // ============================================================

        private void BtnIssueRequests_Click(
    object sender,
    EventArgs e)
        {
            using (IssueRequestsForm form =
                new IssueRequestsForm())
            {
                form.ShowDialog(
                    this.FindForm());
            }
        }


        // ============================================================
        // MAINTENANCE
        // ============================================================

        private void BtnMaintenance_Click(
            object sender,
            EventArgs e)
        {
            using (MaintenanceForm form =
                new MaintenanceForm())
            {
                form.ShowDialog(
                    this.FindForm());
            }
        }


        // ============================================================
        // CLEAR INFORMATION
        // ============================================================

        private void ClearEquipmentInformation()
        {
            selectedEquipmentId = 0;


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


            foreach (
                Label label
                in titles)
            {
                label.Text = "";
            }


            foreach (
                Label label
                in values)
            {
                label.Text =
                    "—";

                label.ForeColor =
                    Color.Gainsboro;
            }


            lblInfo1Title.Text =
                "Имущество:";
        }
    }
}