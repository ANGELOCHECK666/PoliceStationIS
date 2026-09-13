using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Equipment
{
    public partial class WarehouseManagementForm : Form
    {
        private DataTable warehouseTable;

        public WarehouseManagementForm()
        {
            InitializeComponent();

            ConfigureControls();
            ConfigureEvents();

            LoadReferenceData();
            LoadWarehouse();
        }

        // ============================================================
        // CONFIGURATION
        // ============================================================

        private void ConfigureControls()
        {
            ConfigureComboBox(cmbCategory);
            ConfigureComboBox(cmbStatus);

            txtEquipmentName.CharacterCasing =
                CharacterCasing.Normal;

            dtpDateFrom.Format =
                DateTimePickerFormat.Short;

            dtpDateTo.Format =
                DateTimePickerFormat.Short;

            dtpDateFrom.Value =
                DateTime.Today.AddMonths(-1);

            dtpDateTo.Value =
                DateTime.Today;

            dgvWarehouse.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvWarehouse.MultiSelect = false;
            dgvWarehouse.ReadOnly = true;
            dgvWarehouse.AllowUserToAddRows = false;
            dgvWarehouse.AllowUserToDeleteRows = false;
            dgvWarehouse.AllowUserToResizeRows = false;
            dgvWarehouse.RowHeadersVisible = false;
            dgvWarehouse.AutoGenerateColumns = false;

            lblInfoNameValue.Text = "—";
            lblInfoCategoryValue.Text = "—";
            lblInfoStatusValue.Text = "—";
            lblInfoQuantityValue.Text = "—";
            lblInfoDateValue.Text = "—";
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.BackColor =
                Color.FromArgb(30, 58, 117);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;

            comboBox.Font =
                new Font("Segoe UI", 9F);
        }

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            btnClose.Click += BtnClose_Click;

            dgvWarehouse.CellClick +=
                DgvWarehouse_CellClick;

            dgvWarehouse.CellDoubleClick +=
                DgvWarehouse_CellDoubleClick;
        }

        // ============================================================
        // LOAD REFERENCE DATA
        // ============================================================

        private void LoadReferenceData()
        {
            try
            {
                LoadCategories();
                LoadStatuses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники склада.\n\n"
                    + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
                    SELECT
                        equipment_category_id,
                        equipment_category_name
                    FROM equipment_category
                    ORDER BY equipment_category_name;";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbCategory.Items.Clear();

                    cmbCategory.Items.Add(
                        new ComboBoxItem(
                            0,
                            "Все категории"));

                    while (reader.Read())
                    {
                        cmbCategory.Items.Add(
                            new ComboBoxItem(
                                Convert.ToInt32(
                                    reader["equipment_category_id"]),
                                reader[
                                    "equipment_category_name"
                                ].ToString()));
                    }
                }
            }

            cmbCategory.SelectedIndex = 0;
        }

        private void LoadStatuses()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
                    SELECT
                        equipment_status_id,
                        equipment_status_name
                    FROM equipment_status
                    ORDER BY equipment_status_name;";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbStatus.Items.Clear();

                    cmbStatus.Items.Add(
                        new ComboBoxItem(
                            0,
                            "Все статусы"));

                    while (reader.Read())
                    {
                        cmbStatus.Items.Add(
                            new ComboBoxItem(
                                Convert.ToInt32(
                                    reader["equipment_status_id"]),
                                reader[
                                    "equipment_status_name"
                                ].ToString()));
                    }
                }
            }

            cmbStatus.SelectedIndex = 0;
        }

        // ============================================================
        // LOAD WAREHOUSE
        // ============================================================

        private void LoadWarehouse()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            e.equipment_name,
                            c.equipment_category_name,
                            s.equipment_status_name,
                            COUNT(*) AS quantity,
                            MIN(e.equipment_date_of_issue)
                                AS first_issue_date
                        FROM equipment e

                        INNER JOIN equipment_category c
                            ON c.equipment_category_id =
                               e.equipment_category_id

                        INNER JOIN equipment_status s
                            ON s.equipment_status_id =
                               e.equipment_status_id

                        WHERE 1 = 1";

                    // ------------------------------------------------
                    // NAME
                    // ------------------------------------------------

                    if (!string.IsNullOrWhiteSpace(
                        txtEquipmentName.Text))
                    {
                        query +=
                            " AND e.equipment_name ILIKE @name";
                    }

                    // ------------------------------------------------
                    // CATEGORY
                    // ------------------------------------------------

                    ComboBoxItem category =
                        cmbCategory.SelectedItem
                        as ComboBoxItem;

                    if (category != null &&
                        category.Id != 0)
                    {
                        query +=
                            " AND e.equipment_category_id = @category_id";
                    }

                    // ------------------------------------------------
                    // STATUS
                    // ------------------------------------------------

                    ComboBoxItem status =
                        cmbStatus.SelectedItem
                        as ComboBoxItem;

                    if (status != null &&
                        status.Id != 0)
                    {
                        query +=
                            " AND e.equipment_status_id = @status_id";
                    }

                    // ------------------------------------------------
                    // DATE
                    // ------------------------------------------------

                    query += @"
                        AND e.equipment_date_of_issue >= @date_from
                        AND e.equipment_date_of_issue <= @date_to

                        GROUP BY
                            e.equipment_name,
                            c.equipment_category_name,
                            s.equipment_status_name

                        ORDER BY
                            e.equipment_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@name",
                            "%" +
                            txtEquipmentName.Text.Trim() +
                            "%");

                        command.Parameters.AddWithValue(
                            "@date_from",
                            dtpDateFrom.Value.Date);

                        command.Parameters.AddWithValue(
                            "@date_to",
                            dtpDateTo.Value.Date);

                        if (category != null &&
                            category.Id != 0)
                        {
                            command.Parameters.AddWithValue(
                                "@category_id",
                                category.Id);
                        }

                        if (status != null &&
                            status.Id != 0)
                        {
                            command.Parameters.AddWithValue(
                                "@status_id",
                                status.Id);
                        }

                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(command))
                        {
                            warehouseTable =
                                new DataTable();

                            adapter.Fill(
                                warehouseTable);
                        }
                    }
                }

                dgvWarehouse.DataSource = warehouseTable;

                lblResultCount.Text =
                    "Позиций: " + warehouseTable.Rows.Count;

                ClearInformation();

                if (warehouseTable.Rows.Count > 0)
                {
                    ShowSelectedInformation(0);

                    if (dgvWarehouse.Rows.Count > 0)
                    {
                        dgvWarehouse.ClearSelection();
                        dgvWarehouse.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные склада.\n\n"
                    + ex.Message,
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // TABLE SELECTION
        // ============================================================

        private void DgvWarehouse_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowSelectedInformation(
                    e.RowIndex);
            }
        }

        private void DgvWarehouse_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowSelectedInformation(
                    e.RowIndex);
            }
        }

        private void ShowSelectedInformation(int rowIndex)
        {
            if (warehouseTable == null ||
                rowIndex < 0 ||
                rowIndex >= warehouseTable.Rows.Count)
            {
                return;
            }

            DataRow row = warehouseTable.Rows[rowIndex];

            lblInfoNameValue.Text =
                row["equipment_name"].ToString();

            lblInfoCategoryValue.Text =
                row["equipment_category_name"].ToString();

            lblInfoStatusValue.Text =
                row["equipment_status_name"].ToString();

            lblInfoQuantityValue.Text =
                row["quantity"].ToString() + " шт.";

            if (row["first_issue_date"] == DBNull.Value)
            {
                lblInfoDateValue.Text = "—";
            }
            else
            {
                lblInfoDateValue.Text =
                    Convert.ToDateTime(row["first_issue_date"])
                        .ToString("dd.MM.yyyy");
            }

            SetStatusColor(lblInfoStatusValue.Text);
        }

        // ============================================================
        // STATUS COLOR
        // ============================================================

        private void SetStatusColor(
            string status)
        {
            lblInfoStatusValue.ForeColor =
                Color.Gainsboro;

            if (status.Equals(
                "Исправно",
                StringComparison.OrdinalIgnoreCase))
            {
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(
                        90,
                        200,
                        120);
            }
            else if (status.Equals(
                "На обслуживании",
                StringComparison.OrdinalIgnoreCase))
            {
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(
                        230,
                        180,
                        60);
            }
            else if (status.Equals(
                "Списано",
                StringComparison.OrdinalIgnoreCase))
            {
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(
                        220,
                        80,
                        80);
            }
        }

        // ============================================================
        // CLEAR INFORMATION
        // ============================================================

        private void ClearInformation()
        {
            lblInfoNameValue.Text = "—";
            lblInfoCategoryValue.Text = "—";
            lblInfoStatusValue.Text = "—";
            lblInfoQuantityValue.Text = "—";
            lblInfoDateValue.Text = "—";

            lblInfoStatusValue.ForeColor =
                Color.Gainsboro;
        }

        // ============================================================
        // SEARCH
        // ============================================================

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            if (dtpDateFrom.Value.Date >
                dtpDateTo.Value.Date)
            {
                MessageBox.Show(
                    "Дата начала периода не может "
                    + "быть позже даты окончания.",
                    "Проверка периода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            LoadWarehouse();
        }

        // ============================================================
        // RESET
        // ============================================================

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtEquipmentName.Clear();

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;

            dtpDateFrom.Value =
                DateTime.Today.AddMonths(-1);

            dtpDateTo.Value =
                DateTime.Today;

            LoadWarehouse();
        }

        // ============================================================
        // CLOSE
        // ============================================================

        private void BtnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // ============================================================
        // COMBO BOX ITEM
        // ============================================================

        private sealed class ComboBoxItem
        {
            public int Id { get; }

            public string Name { get; }

            public ComboBoxItem(
                int id,
                string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}