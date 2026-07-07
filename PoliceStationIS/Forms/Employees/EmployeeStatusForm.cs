using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Employees
{
    public partial class EmployeeStatusForm : Form
    {
        private readonly int employeeId;

        private readonly NpgsqlConnection connection;

        private int currentStatusId;

        public EmployeeStatusForm(
            int employeeId)
        {
            InitializeComponent();

            this.employeeId =
                employeeId;

            connection =
                DatabaseConnection.GetConnection();

            this.Load +=
                EmployeeStatusForm_Load;

            btnClose.Click +=
                BtnClose_Click;

            btnCancel.Click +=
                BtnCancel_Click;

            btnChangeStatus.Click +=
                BtnChangeStatus_Click;
        }

        private void EmployeeStatusForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadEmployeeInformation();

                LoadEmploymentStatuses();

                dtpChangeDate.Value =
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

e.Employment_status_id,

p.Post_name,

d.Department_name

FROM Employee e

INNER JOIN Post p
ON p.Post_id = e.Post_id

INNER JOIN Department d
ON d.Department_id = e.Department_id

WHERE e.Employee_id=@EmployeeId;
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

                        currentStatusId =
                            Convert.ToInt32(
                                reader["Employment_status_id"]);
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

        private void LoadEmploymentStatuses()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                new NpgsqlDataAdapter(
@"
SELECT
Employment_status_id,
Employment_status_name
FROM Employment_status
ORDER BY Employment_status_name;
",
                connection))
            {
                adapter.Fill(table);
            }

            cmbEmploymentStatus.DataSource =
                table;

            cmbEmploymentStatus.DisplayMember =
                "Employment_status_name";

            cmbEmploymentStatus.ValueMember =
                "Employment_status_id";

            cmbEmploymentStatus.SelectedValue =
                currentStatusId;
        }

        private void BtnChangeStatus_Click(
            object sender,
            EventArgs e)
        {
            if (cmbEmploymentStatus.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Выберите новый статус.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int newStatusId =
                Convert.ToInt32(
                    cmbEmploymentStatus.SelectedValue);

            if (newStatusId ==
                currentStatusId)
            {
                MessageBox.Show(
                    "Выбран текущий статус сотрудника.",
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            UpdateEmployeeStatus(
                newStatusId);
        }
        private void UpdateEmployeeStatus(
    int newStatusId)
        {
            NpgsqlTransaction transaction = null;

            try
            {
                connection.Open();

                transaction =
                    connection.BeginTransaction();

                string updateQuery =
@"
UPDATE Employee
SET
    Employment_status_id = @EmploymentStatusId
WHERE
    Employee_id = @EmployeeId;
";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        updateQuery,
                        connection,
                        transaction))
                {
                    command.Parameters.AddWithValue(
                        "@EmploymentStatusId",
                        newStatusId);

                    command.Parameters.AddWithValue(
                        "@EmployeeId",
                        employeeId);

                    command.ExecuteNonQuery();
                }

                AddPersonnelHistory(
                    transaction);

                transaction.Commit();

                currentStatusId =
                    newStatusId;

                MessageBox.Show(
                    "Статус сотрудника успешно изменен.",
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
                txtComment.Text))
            {
                description =
                    "Статус сотрудника изменен на \"" +
                    cmbEmploymentStatus.Text +
                    "\".";
            }
            else
            {
                description =
                    "Статус сотрудника изменен на \"" +
                    cmbEmploymentStatus.Text +
                    "\". Комментарий: " +
                    txtComment.Text.Trim();
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
                    "Изменение статуса");

                command.Parameters.AddWithValue(
                    "@EventDescription",
                    description);

                command.Parameters.AddWithValue(
                    "@EventDate",
                    dtpChangeDate.Value.Date);

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