using Npgsql;
using PoliceStationIS.Database;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PoliceStationIS.Forms.Employees
{
    public partial class EmployeeSickLeaveForm : Form
    {
        private readonly int employeeId;

        private readonly NpgsqlConnection connection;

        public EmployeeSickLeaveForm(
            int employeeId)
        {
            InitializeComponent();

            this.employeeId =
                employeeId;

            connection =
                DatabaseConnection.GetConnection();

            this.Load +=
                EmployeeSickLeaveForm_Load;

            btnClose.Click +=
                BtnClose_Click;

            btnCancel.Click +=
                BtnCancel_Click;

            btnCreateSickLeave.Click +=
                BtnCreateSickLeave_Click;
        }

        private void EmployeeSickLeaveForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadEmployeeInformation();

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

        private void BtnCreateSickLeave_Click(
    object sender,
    EventArgs e)
        {
            if (dtpEndDate.Value.Date <
                dtpStartDate.Value.Date)
            {
                MessageBox.Show(
                    "Дата окончания больничного не может быть раньше даты начала.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtSickLeaveNumber.Text))
            {
                MessageBox.Show(
                    "Введите номер листка нетрудоспособности.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSickLeaveNumber.Focus();

                return;
            }

            CreateSickLeave();
        }

        private void CreateSickLeave()
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
INSERT INTO Employee_sick_leave
(
    Employee_id,
    Start_date,
    End_date,
    Sick_leave_number,
    Comment_
)
VALUES
(
    @EmployeeId,
    @StartDate,
    @EndDate,
    @SickLeaveNumber,
    @Comment
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
                        "@StartDate",
                        dtpStartDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@EndDate",
                        dtpEndDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@SickLeaveNumber",
                        txtSickLeaveNumber.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@Comment",
                        txtComment.Text.Trim());

                    command.ExecuteNonQuery();
                }

                AddPersonnelHistory(
                    transaction);

                transaction.Commit();

                MessageBox.Show(
                    "Больничный успешно оформлен.",
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
                    "Оформлен больничный. Период: " +
                    dtpStartDate.Value.ToString("dd.MM.yyyy") +
                    " - " +
                    dtpEndDate.Value.ToString("dd.MM.yyyy") +
                    ". Листок нетрудоспособности № " +
                    txtSickLeaveNumber.Text.Trim() +
                    ".";
            }
            else
            {
                description =
                    "Оформлен больничный. Период: " +
                    dtpStartDate.Value.ToString("dd.MM.yyyy") +
                    " - " +
                    dtpEndDate.Value.ToString("dd.MM.yyyy") +
                    ". Листок нетрудоспособности № " +
                    txtSickLeaveNumber.Text.Trim() +
                    ". Комментарий: " +
                    txtComment.Text.Trim() +
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
                    "Больничный");

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