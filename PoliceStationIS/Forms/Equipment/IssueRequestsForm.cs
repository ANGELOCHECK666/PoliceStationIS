using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Equipment
{
    public partial class IssueRequestsForm : Form
    {
        private DataTable requestTable;
        private int selectedRequestId = 0;
        private int selectedEquipmentId = 0;
        private int selectedEmployeeId = 0;

        public IssueRequestsForm()
        {
            InitializeComponent();

            ConfigureControls();
            ConfigureEvents();

            LoadReferenceData();
            LoadRequests();
        }

        private void ConfigureControls()
        {
            ConfigureComboBox(cmbRequestStatus);
            ConfigureComboBox(cmbEmployee);
            ConfigureComboBox(cmbCategory);

            dtpDateFrom.Format = DateTimePickerFormat.Short;
            dtpDateTo.Format = DateTimePickerFormat.Short;
            dtpDateFrom.Value = DateTime.Today.AddMonths(-1);
            dtpDateTo.Value = DateTime.Today;

            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AllowUserToResizeRows = false;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.AutoGenerateColumns = false;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;

            ClearInformation();
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.FromArgb(30, 58, 117);
            comboBox.ForeColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnClose.Click += BtnClose_Click;

            dgvRequests.CellClick += DgvRequests_CellClick;
        }

        private void LoadReferenceData()
        {
            try
            {
                LoadRequestStatuses();
                LoadEmployees();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники заявок.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadRequestStatuses()
        {
            cmbRequestStatus.Items.Clear();
            cmbRequestStatus.Items.Add(new ComboBoxItem(0, "Все статусы"));
            cmbRequestStatus.Items.Add(new ComboBoxItem(1, "В обработке"));
            cmbRequestStatus.Items.Add(new ComboBoxItem(2, "Одобрена"));
            cmbRequestStatus.Items.Add(new ComboBoxItem(3, "Отклонена"));
            cmbRequestStatus.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query = @"
    SELECT employee_id,
           CONCAT(
               last_name, ' ',
               name_, ' ',
               COALESCE(middle_name, '')
           ) AS full_name
    FROM employee
    ORDER BY last_name, name_;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    cmbEmployee.Items.Clear();
                    cmbEmployee.Items.Add(new ComboBoxItem(0, "Все сотрудники"));

                    while (reader.Read())
                    {
                        cmbEmployee.Items.Add(
                            new ComboBoxItem(
                                Convert.ToInt32(reader["employee_id"]),
                                reader["full_name"].ToString().Trim()));
                    }
                }
            }

            cmbEmployee.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
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
                    cmbCategory.Items.Clear();
                    cmbCategory.Items.Add(new ComboBoxItem(0, "Все категории"));

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

        private void LoadRequests()
        {
            try
            {
                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            r.request_id,
                            r.employee_id,
                            r.equipment_id,
                            r.request_date,
                            r.request_status,
CASE r.request_status
    WHEN 1 THEN 'В обработке'
    WHEN 2 THEN 'Одобрена'
    WHEN 3 THEN 'Отклонена'
    ELSE 'Неизвестно'
END AS request_status_name,
                            COALESCE(r.comment, '') AS comment,
                            e.equipment_name,
                            c.equipment_category_name,
                            CONCAT(
    emp.last_name, ' ',
    emp.name_, ' ',
    COALESCE(emp.middle_name, '')
) AS employee_name
                        FROM equipment_issue_request r
                        INNER JOIN equipment e
                            ON e.equipment_id = r.equipment_id
                        INNER JOIN equipment_category c
                            ON c.equipment_category_id =
                               e.equipment_category_id
                        INNER JOIN employee emp
                            ON emp.employee_id = r.employee_id
                        WHERE r.request_date >= @date_from
                          AND r.request_date <= @date_to";

                    ComboBoxItem status =
                        cmbRequestStatus.SelectedItem as ComboBoxItem;

                    ComboBoxItem employee =
                        cmbEmployee.SelectedItem as ComboBoxItem;

                    ComboBoxItem category =
                        cmbCategory.SelectedItem as ComboBoxItem;

                    if (status != null && status.Id != 0)
                        query += " AND r.request_status = @request_status";

                    if (employee != null && employee.Id != 0)
                        query += " AND r.employee_id = @employee_id";

                    if (category != null && category.Id != 0)
                        query += " AND e.equipment_category_id = @category_id";

                    query += " ORDER BY r.request_id DESC;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@date_from", dtpDateFrom.Value.Date);

                        command.Parameters.AddWithValue(
                            "@date_to", dtpDateTo.Value.Date);

                        if (status != null && status.Id != 0)
                            command.Parameters.AddWithValue(
                                "@request_status", status.Id);

                        if (employee != null && employee.Id != 0)
                            command.Parameters.AddWithValue(
                                "@employee_id", employee.Id);

                        if (category != null && category.Id != 0)
                            command.Parameters.AddWithValue(
                                "@category_id", category.Id);

                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(command))
                        {
                            requestTable = new DataTable();
                            adapter.Fill(requestTable);
                        }
                    }
                }

                dgvRequests.DataSource = requestTable;

                lblResultCount.Text =
                    "Заявок: " + requestTable.Rows.Count;

                ClearInformation();

                if (requestTable.Rows.Count > 0)
                {
                    dgvRequests.Rows[0].Selected = true;
                    ShowSelectedInformation(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить заявки.\n\n" + ex.Message,
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DgvRequests_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ShowSelectedInformation(e.RowIndex);
        }

        private void ShowSelectedInformation(int rowIndex)
        {
            if (requestTable == null ||
                rowIndex < 0 ||
                rowIndex >= requestTable.Rows.Count)
                return;

            DataRow row = requestTable.Rows[rowIndex];

            selectedRequestId =
                Convert.ToInt32(row["request_id"]);

            selectedEquipmentId =
                Convert.ToInt32(row["equipment_id"]);

            selectedEmployeeId =
                Convert.ToInt32(row["employee_id"]);

            lblInfoRequestValue.Text =
                "З-" + selectedRequestId.ToString("D5");

            lblInfoEmployeeValue.Text =
                row["employee_name"].ToString();

            lblInfoCategoryValue.Text =
                row["equipment_category_name"].ToString();

            lblInfoEquipmentValue.Text =
                row["equipment_name"].ToString();

            lblInfoDateValue.Text =
                Convert.ToDateTime(row["request_date"])
                .ToString("dd.MM.yyyy");

            string status =
                row["request_status"].ToString();

            lblInfoStatusValue.Text =
                GetStatusName(status);

            lblInfoCommentValue.Text =
                string.IsNullOrWhiteSpace(row["comment"].ToString())
                    ? "Не указан"
                    : row["comment"].ToString();

            SetStatusColor(status);

            btnApprove.Enabled = status == "1";
            btnReject.Enabled = status == "1";
        }

        private string GetStatusName(string status)
        {
            switch (status)
            {
                case "1":
                    return "В обработке";
                case "2":
                    return "Одобрена";
                case "3":
                    return "Отклонена";
                default:
                    return status;
            }
        }

        private void SetStatusColor(string status)
        {
            if (status == "1")
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(230, 180, 60);
            else if (status == "2")
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(90, 200, 120);
            else if (status == "3")
                lblInfoStatusValue.ForeColor =
                    Color.FromArgb(220, 80, 80);
            else
                lblInfoStatusValue.ForeColor =
                    Color.Gainsboro;
        }

        private void ClearInformation()
        {
            selectedRequestId = 0;
            selectedEquipmentId = 0;
            selectedEmployeeId = 0;

            lblInfoRequestValue.Text = "—";
            lblInfoEmployeeValue.Text = "—";
            lblInfoCategoryValue.Text = "—";
            lblInfoEquipmentValue.Text = "—";
            lblInfoDateValue.Text = "—";
            lblInfoStatusValue.Text = "—";
            lblInfoCommentValue.Text = "—";

            lblInfoStatusValue.ForeColor = Color.Gainsboro;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
            {
                MessageBox.Show(
                    "Дата начала периода не может быть позже даты окончания.",
                    "Проверка периода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            LoadRequests();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbRequestStatus.SelectedIndex = 0;
            cmbEmployee.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;

            dtpDateFrom.Value = DateTime.Today.AddMonths(-1);
            dtpDateTo.Value = DateTime.Today;

            LoadRequests();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == 0 ||
                selectedEquipmentId == 0 ||
                selectedEmployeeId == 0)
                return;

            DialogResult result = MessageBox.Show(
                "Одобрить заявку и передать выбранное имущество сотруднику?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (NpgsqlTransaction transaction =
                        connection.BeginTransaction())
                    {
                        using (NpgsqlCommand issueCommand =
                            new NpgsqlCommand(
                                "CALL pr_issue_equipment(@equipment_id, @employee_id);",
                                connection,
                                transaction))
                        {
                            issueCommand.Parameters.AddWithValue(
                                "@equipment_id", selectedEquipmentId);

                            issueCommand.Parameters.AddWithValue(
                                "@employee_id", selectedEmployeeId);

                            issueCommand.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand updateCommand =
                            new NpgsqlCommand(
                                @"UPDATE equipment_issue_request
                                  SET request_status = 2
                                  WHERE request_id = @request_id;",
                                connection,
                                transaction))
                        {
                            updateCommand.Parameters.AddWithValue(
                                "@request_id", selectedRequestId);

                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    "Заявка одобрена. Имущество передано сотруднику.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось одобрить заявку.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == 0)
                return;

            DialogResult result = MessageBox.Show(
                "Отклонить выбранную заявку?",
                "Подтверждение",
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

                    const string query = @"
                        UPDATE equipment_issue_request
                        SET request_status = 3
                        WHERE request_id = @request_id;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@request_id", selectedRequestId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Заявка отклонена.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось отклонить заявку.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private sealed class ComboBoxItem
        {
            public int Id { get; }
            public string Name { get; }

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
    }
}