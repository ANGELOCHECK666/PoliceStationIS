using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Equipment
{
    public partial class MaintenanceForm : Form
    {
        private int selectedMaintenanceId = 0;
        private int selectedEquipmentId = 0;

        public MaintenanceForm()
        {
            InitializeComponent();

            ConfigureControls();
            ConfigureEvents();

            LoadReferenceData();
            LoadMaintenance();
        }

        private void ConfigureControls()
        {
            ConfigureComboBox(cmbStatus);
            ConfigureComboBox(cmbCategory);
            ConfigureComboBox(cmbEquipment);
            ConfigureComboBox(cmbMaintenanceType);

            dtpDateFrom.Format = DateTimePickerFormat.Short;
            dtpDateTo.Format = DateTimePickerFormat.Short;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-1);
            dtpDateTo.Value = DateTime.Today;

            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.MultiSelect = false;
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.AllowUserToAddRows = false;
            dgvMaintenance.AllowUserToDeleteRows = false;
            dgvMaintenance.AllowUserToResizeRows = false;
            dgvMaintenance.RowHeadersVisible = false;
            dgvMaintenance.AutoGenerateColumns = false;

            btnStart.Enabled = false;
            btnComplete.Enabled = false;

            ClearInformation();
        }

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            btnStart.Click += BtnStart_Click;
            btnComplete.Click += BtnComplete_Click;

            dgvMaintenance.CellClick += DgvMaintenance_CellClick;
            cmbEquipment.SelectedIndexChanged += CmbEquipment_SelectedIndexChanged;
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.FromArgb(30, 58, 117);
            comboBox.ForeColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 9F);
        }

        private void LoadReferenceData()
        {
            LoadStatuses();
            LoadCategories();
            LoadEquipment();
            LoadMaintenanceTypes();
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add(new ComboBoxItem(0, "Все статусы"));
            cmbStatus.Items.Add(new ComboBoxItem(1, "На обслуживании"));
            cmbStatus.Items.Add(new ComboBoxItem(2, "Завершено"));

            cmbStatus.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add(new ComboBoxItem(0, "Все категории"));

                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT equipment_category_id,
                               equipment_category_name
                        FROM equipment_category
                        ORDER BY equipment_category_name;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(
                                new ComboBoxItem(
                                    Convert.ToInt32(reader["equipment_category_id"]),
                                    reader["equipment_category_name"].ToString()));
                        }
                    }
                }

                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить категории имущества.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEquipment()
        {
            try
            {
                cmbEquipment.Items.Clear();
                cmbEquipment.Items.Add(new EquipmentComboItem(0, "Выберите имущество"));

                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            e.equipment_id,
                            e.equipment_name,
                            c.equipment_category_name,
                            es.equipment_status_name
                        FROM equipment e
                        INNER JOIN equipment_category c
                            ON c.equipment_category_id = e.equipment_category_id
                        INNER JOIN equipment_status es
                            ON es.equipment_status_id = e.equipment_status_id
                        WHERE es.equipment_status_name NOT IN ('Списано', 'Утеряно')
                          AND es.equipment_status_name <> 'В ремонте'
                          AND NOT EXISTS
                          (
                              SELECT 1
                              FROM equipment_maintenance m
                              WHERE m.equipment_id = e.equipment_id
                                AND m.maintenance_status = 1
                          )
                        ORDER BY e.equipment_name, e.equipment_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int equipmentId =
                                Convert.ToInt32(reader["equipment_id"]);

                            string text =
                                reader["equipment_name"].ToString() +
                                " — " +
                                reader["equipment_category_name"].ToString() +
                                " — " +
                                reader["equipment_status_name"].ToString();

                            cmbEquipment.Items.Add(
                                new EquipmentComboItem(equipmentId, text));
                        }
                    }
                }

                cmbEquipment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить список имущества.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadMaintenanceTypes()
        {
            cmbMaintenanceType.Items.Clear();

            cmbMaintenanceType.Items.Add("Техническое обслуживание");
            cmbMaintenanceType.Items.Add("Ремонт");
            cmbMaintenanceType.Items.Add("Проверка");

            cmbMaintenanceType.SelectedIndex = 0;
        }

        private void LoadMaintenance()
        {
            try
            {
                dgvMaintenance.Rows.Clear();

                int statusId = GetComboBoxId(cmbStatus);
                int categoryId = GetComboBoxId(cmbCategory);

                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date;

                if (dateFrom > dateTo)
                {
                    MessageBox.Show(
                        "Дата «с» не может быть позже даты «по».",
                        "Проверка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            e.equipment_id,
                            e.equipment_name,
                            c.equipment_category_name,

                            CASE
                                WHEN e.employee_id IS NULL THEN 'На складе'
                                ELSE CONCAT(
                                    emp.last_name, ' ',
                                    emp.name_, ' ',
                                    COALESCE(emp.middle_name, '')
                                )
                            END AS employee_name,

                            m.maintenance_id,
                            m.maintenance_type,
                            m.maintenance_date,
                            m.maintenance_status,
                            m.completion_date,
                            m.description

                        FROM equipment e

                        INNER JOIN equipment_category c
                            ON c.equipment_category_id = e.equipment_category_id

                        LEFT JOIN employee emp
                            ON emp.employee_id = e.employee_id

                        LEFT JOIN LATERAL
                        (
                            SELECT
                                em.maintenance_id,
                                em.maintenance_type,
                                em.maintenance_date,
                                em.maintenance_status,
                                em.completion_date,
                                em.description
                            FROM equipment_maintenance em
                            WHERE em.equipment_id = e.equipment_id
                            ORDER BY
                                em.maintenance_date DESC,
                                em.maintenance_id DESC
                            LIMIT 1
                        ) m ON TRUE

                        WHERE
                            (@status_id = 0 OR m.maintenance_status = @status_id)
                            AND
                            (@category_id = 0 OR e.equipment_category_id = @category_id)
                            AND
                            (
                                m.maintenance_id IS NULL
                                OR
                                (
                                    m.maintenance_date >= @date_from
                                    AND m.maintenance_date <= @date_to
                                )
                            )

                        ORDER BY e.equipment_name, e.equipment_id;";

                    using (NpgsqlCommand command =
                           new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status_id", statusId);
                        command.Parameters.AddWithValue("@category_id", categoryId);
                        command.Parameters.AddWithValue("@date_from", dateFrom);
                        command.Parameters.AddWithValue("@date_to", dateTo);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int equipmentId =
                                    Convert.ToInt32(reader["equipment_id"]);

                                string equipmentName =
                                    reader["equipment_name"].ToString();

                                string category =
                                    reader["equipment_category_name"].ToString();

                                string employee =
                                    reader["employee_name"].ToString();

                                string maintenanceType = "—";
                                string maintenanceDate = "—";
                                string maintenanceStatus = "—";
                                int maintenanceId = 0;
                                int maintenanceStatusId = 0;
                                string description = "";
                                object completionDate = DBNull.Value;

                                if (reader["maintenance_id"] != DBNull.Value)
                                {
                                    maintenanceId =
                                        Convert.ToInt32(reader["maintenance_id"]);

                                    maintenanceType =
                                        reader["maintenance_type"].ToString();

                                    maintenanceDate =
                                        Convert.ToDateTime(
                                            reader["maintenance_date"])
                                        .ToString("dd.MM.yyyy");

                                    maintenanceStatusId =
                                        Convert.ToInt32(
                                            reader["maintenance_status"]);

                                    if (maintenanceStatusId == 1)
                                        maintenanceStatus = "На обслуживании";
                                    else if (maintenanceStatusId == 2)
                                        maintenanceStatus = "Завершено";

                                    if (reader["description"] != DBNull.Value)
                                        description =
                                            reader["description"].ToString();

                                    if (reader["completion_date"] != DBNull.Value)
                                        completionDate =
                                            reader["completion_date"];
                                }

                                int rowIndex = dgvMaintenance.Rows.Add(
                                    equipmentName,
                                    category,
                                    employee,
                                    maintenanceType,
                                    maintenanceDate,
                                    maintenanceStatus);

                                DataGridViewRow row =
                                    dgvMaintenance.Rows[rowIndex];

                                row.Cells["EquipmentId"].Value = equipmentId;
                                row.Cells["MaintenanceId"].Value = maintenanceId;
                                row.Cells["MaintenanceStatusId"].Value =
                                    maintenanceStatusId;
                                row.Cells["Description"].Value = description;
                                row.Cells["CompletionDate"].Value =
                                    completionDate;
                            }
                        }
                    }
                }

                lblResultCount.Text =
                    "Записей: " + dgvMaintenance.Rows.Count;

                ClearInformation();

                if (dgvMaintenance.Rows.Count > 0)
                {
                    dgvMaintenance.ClearSelection();
                    dgvMaintenance.Rows[0].Selected = true;
                    dgvMaintenance.CurrentCell =
                        dgvMaintenance.Rows[0].Cells["equipment_name"];
                    ShowSelectedInformation(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить журнал обслуживания.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DgvMaintenance_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ShowSelectedInformation(e.RowIndex);
        }

        private void ShowSelectedInformation(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvMaintenance.Rows.Count)
            {
                ClearInformation();
                return;
            }

            DataGridViewRow row = dgvMaintenance.Rows[rowIndex];

            // Имена колонок здесь должны совпадать с Name в Designer.
            selectedEquipmentId = GetCellInt(row, "EquipmentId");
            selectedMaintenanceId = GetCellInt(row, "MaintenanceId");

            lblInfoEquipmentValue.Text =
                GetCellText(row, "equipment_name");

            lblInfoCategoryValue.Text =
                GetCellText(row, "equipment_category_name");

            lblInfoEmployeeValue.Text =
                GetCellText(row, "employee_name");

            lblInfoTypeValue.Text =
                GetCellText(row, "maintenance_type");

            lblInfoDateValue.Text =
                GetCellText(row, "maintenance_date");

            lblInfoStatusValue.Text =
                GetCellText(row, "maintenance_status_name");

            string description =
                GetCellText(row, "Description");

            lblInfoDescriptionValue.Text =
                string.IsNullOrWhiteSpace(description)
                    ? "—"
                    : description;

            object completion =
                row.Cells["CompletionDate"].Value;

            if (completion == null ||
                completion == DBNull.Value ||
                string.IsNullOrWhiteSpace(completion.ToString()))
            {
                lblInfoCompletionValue.Text = "—";
            }
            else
            {
                lblInfoCompletionValue.Text =
                    Convert.ToDateTime(completion)
                    .ToString("dd.MM.yyyy");
            }

            int statusId =
                GetCellInt(row, "MaintenanceStatusId");

            if (statusId == 1)
            {
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(230, 180, 60);
            }
            else if (statusId == 2)
            {
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(90, 200, 120);
            }
            else
            {
                lblInfoStatusValue.ForeColor =
                    Color.Gainsboro;
            }

            btnComplete.Enabled =
                selectedMaintenanceId > 0 &&
                statusId == 1;

            btnStart.Enabled =
                cmbEquipment.SelectedIndex > 0;
        }

        private void ClearInformation()
        {
            selectedMaintenanceId = 0;
            selectedEquipmentId = 0;

            lblInfoEquipmentValue.Text = "—";
            lblInfoCategoryValue.Text = "—";
            lblInfoEmployeeValue.Text = "—";
            lblInfoTypeValue.Text = "—";
            lblInfoDateValue.Text = "—";
            lblInfoStatusValue.Text = "—";
            lblInfoDescriptionValue.Text = "—";
            lblInfoCompletionValue.Text = "—";

            lblInfoStatusValue.ForeColor = Color.Gainsboro;

            btnComplete.Enabled = false;
            btnStart.Enabled =
                cmbEquipment != null &&
                cmbEquipment.SelectedIndex > 0;
        }

        private void CmbEquipment_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            EquipmentComboItem item =
                cmbEquipment.SelectedItem as EquipmentComboItem;

            btnStart.Enabled =
                item != null &&
                item.Id > 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadMaintenance();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;

            dtpDateFrom.Value =
                DateTime.Today.AddMonths(-1);

            dtpDateTo.Value =
                DateTime.Today;

            cmbMaintenanceType.SelectedIndex = 0;
            txtDescription.Clear();

            LoadEquipment();
            LoadMaintenance();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            EquipmentComboItem equipment =
                cmbEquipment.SelectedItem as EquipmentComboItem;

            if (equipment == null || equipment.Id == 0)
            {
                MessageBox.Show(
                    "Выберите имущество, которое необходимо передать на обслуживание.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbMaintenanceType.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Выберите вид обслуживания.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                "Передать выбранное имущество на обслуживание?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (NpgsqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        const string checkQuery = @"
                            SELECT COUNT(*)
                            FROM equipment_maintenance
                            WHERE equipment_id = @equipment_id
                              AND maintenance_status = 1;";

                        using (NpgsqlCommand command =
                               new NpgsqlCommand(
                                   checkQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@equipment_id",
                                equipment.Id);

                            int activeCount =
                                Convert.ToInt32(command.ExecuteScalar());

                            if (activeCount > 0)
                            {
                                transaction.Rollback();

                                MessageBox.Show(
                                    "Это имущество уже находится на обслуживании.",
                                    "Проверка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                LoadEquipment();
                                return;
                            }
                        }

                        const string insertQuery = @"
                            INSERT INTO equipment_maintenance
                            (
                                equipment_id,
                                maintenance_date,
                                maintenance_type,
                                description,
                                maintenance_status
                            )
                            VALUES
                            (
                                @equipment_id,
                                CURRENT_DATE,
                                @maintenance_type,
                                @description,
                                1
                            );";

                        using (NpgsqlCommand command =
                               new NpgsqlCommand(
                                   insertQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@equipment_id",
                                equipment.Id);

                            command.Parameters.AddWithValue(
                                "@maintenance_type",
                                cmbMaintenanceType.SelectedItem.ToString());

                            command.Parameters.AddWithValue(
                                "@description",
                                string.IsNullOrWhiteSpace(txtDescription.Text)
                                    ? (object)DBNull.Value
                                    : txtDescription.Text.Trim());

                            command.ExecuteNonQuery();
                        }

                        const string updateEquipmentQuery = @"
                            UPDATE equipment
                            SET equipment_status_id =
                            (
                                SELECT equipment_status_id
                                FROM equipment_status
                                WHERE equipment_status_name = 'В ремонте'
                                LIMIT 1
                            )
                            WHERE equipment_id = @equipment_id;";

                        using (NpgsqlCommand command =
                               new NpgsqlCommand(
                                   updateEquipmentQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@equipment_id",
                                equipment.Id);

                            if (command.ExecuteNonQuery() == 0)
                            {
                                throw new Exception(
                                    "Не удалось изменить статус имущества на «В ремонте».");
                            }
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    "Имущество передано на обслуживание.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtDescription.Clear();

                LoadEquipment();
                LoadMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось передать имущество на обслуживание.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (selectedMaintenanceId == 0 ||
                selectedEquipmentId == 0)
            {
                MessageBox.Show(
                    "Выберите активную запись обслуживания.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                "Завершить обслуживание выбранного имущества?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (NpgsqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        const string updateMaintenanceQuery = @"
                            UPDATE equipment_maintenance
                            SET maintenance_status = 2,
                                completion_date = CURRENT_DATE
                            WHERE maintenance_id = @maintenance_id
                              AND maintenance_status = 1;";

                        using (NpgsqlCommand command =
                               new NpgsqlCommand(
                                   updateMaintenanceQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@maintenance_id",
                                selectedMaintenanceId);

                            if (command.ExecuteNonQuery() == 0)
                            {
                                throw new Exception(
                                    "Запись уже завершена или не найдена.");
                            }
                        }

                        const string updateEquipmentQuery = @"
                            UPDATE equipment
                            SET equipment_status_id =
                            (
                                SELECT equipment_status_id
                                FROM equipment_status
                                WHERE equipment_status_name =
                                    CASE
                                        WHEN employee_id IS NULL
                                            THEN 'Исправно'
                                        ELSE 'Выдано'
                                    END
                                LIMIT 1
                            )
                            WHERE equipment_id = @equipment_id;";

                        using (NpgsqlCommand command =
                               new NpgsqlCommand(
                                   updateEquipmentQuery,
                                   connection,
                                   transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@equipment_id",
                                selectedEquipmentId);

                            if (command.ExecuteNonQuery() == 0)
                            {
                                throw new Exception(
                                    "Не удалось восстановить статус имущества.");
                            }
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    "Обслуживание завершено. Состояние имущества обновлено.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEquipment();
                LoadMaintenance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось завершить обслуживание.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int GetComboBoxId(ComboBox comboBox)
        {
            ComboBoxItem item =
                comboBox.SelectedItem as ComboBoxItem;

            return item == null ? 0 : item.Id;
        }

        private int GetCellInt(DataGridViewRow row, string columnName)
        {
            object value = row.Cells[columnName].Value;

            if (value == null ||
                value == DBNull.Value ||
                string.IsNullOrWhiteSpace(value.ToString()))
            {
                return 0;
            }

            int result;

            return int.TryParse(value.ToString(), out result)
                ? result
                : 0;
        }

        private string GetCellText(
            DataGridViewRow row,
            string columnName)
        {
            object value = row.Cells[columnName].Value;

            if (value == null || value == DBNull.Value)
                return "—";

            string text = value.ToString();

            return string.IsNullOrWhiteSpace(text)
                ? "—"
                : text;
        }

        private sealed class ComboBoxItem
        {
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboBoxItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private sealed class EquipmentComboItem
        {
            public int Id { get; private set; }
            public string Text { get; private set; }

            public EquipmentComboItem(int id, string text)
            {
                Id = id;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}