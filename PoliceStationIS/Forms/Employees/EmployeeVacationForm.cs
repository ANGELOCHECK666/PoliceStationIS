using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Employees
{
    public partial class EmployeeVacationForm : Form
    {
        private readonly int employeeId;

        private readonly NpgsqlConnection connection;

        public EmployeeVacationForm(
            int employeeId)
        {
            InitializeComponent();

            this.employeeId =
                employeeId;

            connection =
                DatabaseConnection.GetConnection();

            this.Load +=
                EmployeeVacationForm_Load;

            btnClose.Click +=
                BtnClose_Click;

            btnCancel.Click +=
                BtnCancel_Click;

            btnCreateVacation.Click +=
                BtnCreateVacation_Click;
        }

        private void EmployeeVacationForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadEmployeeInformation();

                LoadVacationTypes();

                dtpStartDate.Value =
                    DateTime.Today;

                dtpEndDate.Value =
                    DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeInformation()
        {
            string query =
@"
SELECT

e.Employee_id,

e.Last_name,
e.Name_,
e.Middle_name,

p.Post_name,

d.Department_name

FROM Employee e

INNER JOIN Post p
ON p.Post_id = e.Post_id

INNER JOIN Department d
ON d.Department_id = e.Department_id

WHERE e.Employee_id = @EmployeeId;
";

            try
            {
                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@EmployeeId",
                        employeeId);

                    connection.Open();

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            throw new Exception(
                                "Сотрудник не найден.");
                        }

                        string middleName = "";

                        if (reader["Middle_name"] != DBNull.Value)
                        {
                            middleName =
                                reader["Middle_name"]
                                .ToString();
                        }

                        lblName.Text =
                            reader["Last_name"] +
                            " " +
                            reader["Name_"] +
                            " " +
                            middleName;

                        lblPost.Text =
                            reader["Post_name"]
                            .ToString();

                        lblDepartment.Text =
                            reader["Department_name"]
                            .ToString();
                    }
                }
            }
            finally
            {
                if (connection.State ==
                    ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void LoadVacationTypes()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                new NpgsqlDataAdapter(
@"
SELECT
    Vacation_type_id,
    Vacation_type_name
FROM Vacation_type
ORDER BY Vacation_type_name;
",
                connection))
            {
                adapter.Fill(table);
            }

            cmbVacationType.DataSource =
                table;

            cmbVacationType.DisplayMember =
                "Vacation_type_name";

            cmbVacationType.ValueMember =
                "Vacation_type_id";

            cmbVacationType.SelectedIndex =
                -1;
        }

        private void BtnCreateVacation_Click(
            object sender,
            EventArgs e)
        {
            if (cmbVacationType.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Выберите тип отпуска.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dtpEndDate.Value.Date <
                dtpStartDate.Value.Date)
            {
                MessageBox.Show(
                    "Дата окончания отпуска не может быть раньше даты начала.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CreateVacation();
        }

        private void CreateVacation()
        {
            NpgsqlTransaction transaction =
                null;

            try
            {
                connection.Open();

                transaction =
                    connection.BeginTransaction();

                string insertQuery =
@"
INSERT INTO Employee_vacation
(
    Employee_id,
    Vacation_type_id,
    Start_date,
    End_date,
    Basis
)
VALUES
(
    @EmployeeId,
    @VacationTypeId,
    @StartDate,
    @EndDate,
    @Basis
);
";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        insertQuery,
                        connection,
                        transaction))
                {
                    command.Parameters.AddWithValue(
                        "@EmployeeId",
                        employeeId);

                    command.Parameters.AddWithValue(
                        "@VacationTypeId",
                        Convert.ToInt32(
                            cmbVacationType.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@StartDate",
                        dtpStartDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@EndDate",
                        dtpEndDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@Basis",
                        txtBasis.Text.Trim());

                    command.ExecuteNonQuery();
                }

                AddPersonnelHistory(
                    transaction);

                transaction.Commit();

                MessageBox.Show(
                    "Отпуск успешно оформлен.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch
                    {

                    }
                }

                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State ==
                    ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void AddPersonnelHistory(
    NpgsqlTransaction transaction)
        {
            string description;

            if (string.IsNullOrWhiteSpace(
                txtBasis.Text))
            {
                description =
                    "Оформлен отпуск. Тип отпуска: \"" +
                    cmbVacationType.Text +
                    "\". Период: " +
                    dtpStartDate.Value.ToString("dd.MM.yyyy") +
                    " - " +
                    dtpEndDate.Value.ToString("dd.MM.yyyy") +
                    ".";
            }
            else
            {
                description =
                    "Оформлен отпуск. Тип отпуска: \"" +
                    cmbVacationType.Text +
                    "\". Период: " +
                    dtpStartDate.Value.ToString("dd.MM.yyyy") +
                    " - " +
                    dtpEndDate.Value.ToString("dd.MM.yyyy") +
                    ". Основание: " +
                    txtBasis.Text.Trim() +
                    ".";
            }

            string historyQuery =
@"
INSERT INTO Personnel_history
(
    Employee_id,
    Event_type,
    Event_description,
    Event_date
)
VALUES
(
    @EmployeeId,
    @EventType,
    @EventDescription,
    @EventDate
);
";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    historyQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@EmployeeId",
                    employeeId);

                command.Parameters.AddWithValue(
                    "@EventType",
                    "Отпуск");

                command.Parameters.AddWithValue(
                    "@EventDescription",
                    description);

                command.Parameters.AddWithValue(
                    "@EventDate",
                    DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        private void BtnClose_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}