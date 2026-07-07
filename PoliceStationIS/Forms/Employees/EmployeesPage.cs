using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

using PoliceStationIS.Database;
using PoliceStationIS.Forms.Employees;

namespace PoliceStationIS.Forms.Employees
{
    public partial class EmployeesPage : UserControl
    {
        private DataTable employeesTable;
        public EmployeesPage()
        {
            InitializeComponent();

            ConfigureGrid();

            dgvEmployees.CellPainting += DgvEmployees_CellPainting;

            LoadDepartments();
            LoadPosts();
            LoadRanks();
            LoadStatuses();

            LoadEmployees();

            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnEditEmployee.Click += BtnEditEmployee_Click;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            btnVacation.Click += BtnVacation_Click;
            btnSickLeave.Click += BtnSickLeave_Click;
            btnChangePost.Click +=
    BtnChangePost_Click;
        }

        private void ConfigureGrid()
        {
            dgvEmployees.EnableHeadersVisualStyles = false;

            dgvEmployees.AdvancedColumnHeadersBorderStyle.Left =
    DataGridViewAdvancedCellBorderStyle.Single;

            dgvEmployees.AdvancedColumnHeadersBorderStyle.Right =
                DataGridViewAdvancedCellBorderStyle.Single;

            dgvEmployees.AdvancedColumnHeadersBorderStyle.Top =
                DataGridViewAdvancedCellBorderStyle.Single;

            dgvEmployees.AdvancedColumnHeadersBorderStyle.Bottom =
                DataGridViewAdvancedCellBorderStyle.Single;

            dgvEmployees.ColumnHeadersDefaultCellStyle.SelectionBackColor =
    Color.FromArgb(
        42,
        73,
        133);

            dgvEmployees.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);
            dgvEmployees.AutoGenerateColumns = false;

            dgvEmployees.BackgroundColor =
                Color.FromArgb(30, 58, 117);

            dgvEmployees.BorderStyle =
                BorderStyle.None;

            dgvEmployees.GridColor =
                Color.FromArgb(212, 160, 23);
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor =
    Color.FromArgb(
        45,
        75,
        130);

            dgvEmployees.RowHeadersVisible =
                false;

            dgvEmployees.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEmployees.MultiSelect =
                false;

            dgvEmployees.ReadOnly =
                true;

            dgvEmployees.AllowUserToAddRows =
                false;

            dgvEmployees.AllowUserToDeleteRows =
                false;

            dgvEmployees.AllowUserToResizeRows =
                false;

            dgvEmployees.AllowUserToResizeColumns =
                false;

            dgvEmployees.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvEmployees.ColumnHeadersHeight = 45;

            dgvEmployees.RowTemplate.Height = 36;

            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(42, 73, 133);

            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor =
    Color.FromArgb(
        212,
        160,
        23);

            dgvEmployees.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            dgvEmployees.DefaultCellStyle.BackColor =
                Color.FromArgb(30, 58, 117);

            dgvEmployees.DefaultCellStyle.ForeColor =
                Color.White;

            dgvEmployees.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(60, 90, 150);

            dgvEmployees.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvEmployees.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            dgvEmployees.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvEmployees.CellBorderStyle =
    DataGridViewCellBorderStyle.Single;
        }

        private void LoadEmployees()
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
    e.employee_id,

    e.last_name || ' ' ||
    e.name_ || ' ' ||
    COALESCE(e.middle_name, '') AS ""ФИО"",

    e.date_of_birth AS ""Дата рождения"",

    p.post_name AS ""Должность"",

    d.department_name AS ""Отдел"",

    r.rank_name AS ""Звание"",

    es.employment_status_name AS ""Статус"",

    e.phone_number AS ""Телефон"",

    e.service_start_date AS ""Дата приема""

FROM employee e

INNER JOIN department d
    ON e.department_id = d.department_id

INNER JOIN post p
    ON e.post_id = p.post_id

INNER JOIN rank_ r
    ON e.rank_id = r.rank_id

INNER JOIN employment_status es
    ON e.employment_status_id =
       es.employment_status_id

ORDER BY
    e.last_name,
    e.name_;
";

                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(
                            query,
                            connection))
                    {
                        employeesTable =
                            new DataTable();

                        adapter.Fill(
                            employeesTable);



                        dgvEmployees.DataSource =
                            employeesTable;
                        dgvEmployees.Columns[0].DataPropertyName = "ФИО";
                        dgvEmployees.Columns[1].DataPropertyName = "Дата рождения";
                        dgvEmployees.Columns[2].DataPropertyName = "Должность";
                        dgvEmployees.Columns[3].DataPropertyName = "Отдел";
                        dgvEmployees.Columns[4].DataPropertyName = "Звание";
                        dgvEmployees.Columns[5].DataPropertyName = "Статус";
                        dgvEmployees.Columns[6].DataPropertyName = "Телефон";
                        dgvEmployees.Columns[7].DataPropertyName = "Дата приема";
                        dgvEmployees.Columns["Телефон"].Visible = false;

                        dgvEmployees.Columns["ФИО"].Width = 280;

                        dgvEmployees.Columns["Дата рождения"].Width = 120;

                        dgvEmployees.Columns["Должность"].Width = 220;

                        dgvEmployees.Columns["Отдел"].Width = 220;

                        dgvEmployees.Columns["Звание"].Width = 220;

                        dgvEmployees.Columns["Статус"].Width = 180;

                        dgvEmployees.Columns["Дата приема"].Width = 120;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки сотрудников",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                cmbDepartment.Items.Clear();

                cmbDepartment.Items.Add("Все");

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        "SELECT department_name FROM department ORDER BY department_name";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbDepartment.Items.Add(
                                    reader["department_name"].ToString());
                            }
                        }
                    }
                }

                cmbDepartment.SelectedIndex = 0;
            }
            catch
            {
            }
        }
        private void LoadPosts()
        {
            try
            {
                cmbPost.Items.Clear();

                cmbPost.Items.Add("Все");

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        "SELECT post_name FROM post ORDER BY post_name";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbPost.Items.Add(
                                    reader["post_name"].ToString());
                            }
                        }
                    }
                }

                cmbPost.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void LoadRanks()
        {
            try
            {
                cmbRank.Items.Clear();

                cmbRank.Items.Add("Все");

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        "SELECT rank_name FROM rank_ ORDER BY rank_name";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbRank.Items.Add(
                                    reader["rank_name"].ToString());
                            }
                        }
                    }
                }

                cmbRank.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void LoadStatuses()
        {
            try
            {
                cmbStatus.Items.Clear();

                cmbStatus.Items.Add("Все");

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"SELECT employment_status_name
                  FROM employment_status
                  ORDER BY employment_status_id";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbStatus.Items.Add(
                                    reader["employment_status_name"].ToString());
                            }
                        }
                    }
                }

                cmbStatus.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void BtnSearch_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                string filter = "";

                if (!string.IsNullOrWhiteSpace(
                    txtSearch.Text))
                {
                    filter +=
                        $"[ФИО] LIKE '%{txtSearch.Text}%'";
                }

                if (cmbDepartment.SelectedIndex > 0)
                {
                    if (filter != "")
                        filter += " AND ";

                    filter +=
                        $"[Отдел] = '{cmbDepartment.Text}'";
                }

                if (cmbPost.SelectedIndex > 0)
                {
                    if (filter != "")
                        filter += " AND ";

                    filter +=
                        $"[Должность] = '{cmbPost.Text}'";
                }

                if (cmbRank.SelectedIndex > 0)
                {
                    if (filter != "")
                        filter += " AND ";

                    filter +=
                        $"[Звание] = '{cmbRank.Text}'";
                }

                if (cmbStatus.SelectedIndex > 0)
                {
                    if (filter != "")
                        filter += " AND ";

                    filter +=
                        $"[Статус] = '{cmbStatus.Text}'";
                }

                employeesTable.DefaultView.RowFilter =
                    filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        private void BtnReset_Click(
    object sender,
    EventArgs e)
        {
            txtSearch.Clear();

            cmbDepartment.SelectedIndex = 0;
            cmbPost.SelectedIndex = 0;
            cmbRank.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            employeesTable.DefaultView.RowFilter =
                "";
        }

        private void DgvEmployees_CellPainting(
    object sender,
    DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex != 5)
                return;

            e.Handled = true;

            e.PaintBackground(
                e.CellBounds,
                true);

            string status =
                e.FormattedValue?.ToString();

            Color circleColor =
     Color.FromArgb(108, 184, 125);

            if (status == "На больничном")
            {
                circleColor =
                    Color.FromArgb(210, 110, 110);
            }
            else if (status == "В отпуске")
            {
                circleColor =
                    Color.FromArgb(225, 190, 90);
            }
            else if (status == "Отстранен")
            {
                circleColor =
                    Color.FromArgb(170, 170, 170);
            }
            else if (status == "Уволен")
            {
                circleColor =
                    Color.FromArgb(115, 115, 115);
            }

            using (SolidBrush brush =
                new SolidBrush(circleColor))
            {
                e.Graphics.FillEllipse(
                    brush,
                    e.CellBounds.X + 10,
                    e.CellBounds.Y + 10,
                    12,
                    12);
            }

            TextRenderer.DrawText(
                e.Graphics,
                status,
                dgvEmployees.Font,
                new Rectangle(
                    e.CellBounds.X + 30,
                    e.CellBounds.Y,
                    e.CellBounds.Width - 25,
                    e.CellBounds.Height),
                Color.White,
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.Left);
        }

        private void BtnAddEmployee_Click(
    object sender,
    EventArgs e)
        {
            AddEmployeeForm form =
                new AddEmployeeForm();

            form.ShowDialog();

            LoadEmployees();
        }

        private void BtnEditEmployee_Click(
    object sender,
    EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.");
                return;
            }

            DataRowView row =
                (DataRowView)
                dgvEmployees.CurrentRow.DataBoundItem;

            int employeeId =
                Convert.ToInt32(
                    row["employee_id"]);

            AddEmployeeForm form =
                new AddEmployeeForm(
                    employeeId);

            form.ShowDialog();

            LoadEmployees();
        }
        private void BtnChangeStatus_Click(
    object sender,
    EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                (DataRowView)
                dgvEmployees.CurrentRow.DataBoundItem;

            int employeeId =
                Convert.ToInt32(
                    row["employee_id"]);

            EmployeeStatusForm form =
                new EmployeeStatusForm(
                    employeeId);

            if (form.ShowDialog() ==
                DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void BtnVacation_Click(
    object sender,
    EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataRowView row =
                (DataRowView)
                dgvEmployees.CurrentRow.DataBoundItem;

            int employeeId =
                Convert.ToInt32(
                    row["employee_id"]);

            using (EmployeeVacationForm form =
                new EmployeeVacationForm(employeeId))
            {
                if (form.ShowDialog() ==
                    DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }

        private void BtnSickLeave_Click(
    object sender,
    EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataRowView row =
                (DataRowView)
                dgvEmployees.CurrentRow.DataBoundItem;

            int employeeId =
                Convert.ToInt32(
                    row["employee_id"]);

            using (EmployeeSickLeaveForm form =
                new EmployeeSickLeaveForm(employeeId))
            {
                if (form.ShowDialog() ==
                    DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }

        private void BtnChangePost_Click(
    object sender,
    EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DataRowView row =
                 (DataRowView)
                 dgvEmployees.CurrentRow.DataBoundItem;

            int employeeId =
                Convert.ToInt32(
                    row["employee_id"]);

            using (EmployeePositionForm form =
                new EmployeePositionForm(employeeId))
            {
                if (form.ShowDialog() ==
                    DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
        }
    }
}