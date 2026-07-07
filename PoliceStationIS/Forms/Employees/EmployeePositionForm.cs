using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Employees
{
    public partial class EmployeePositionForm : Form
    {
        private readonly int employeeId;

        private readonly NpgsqlConnection connection;

        public EmployeePositionForm(
            int employeeId)
        {
            InitializeComponent();

            this.employeeId =
                employeeId;

            connection =
                DatabaseConnection.GetConnection();

            this.Load +=
                EmployeePositionForm_Load;

            btnClose.Click +=
                BtnClose_Click;

            btnCancel.Click +=
                BtnCancel_Click;

            btnChangePosition.Click +=
                BtnChangePosition_Click;
        }

        private void EmployeePositionForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                LoadEmployeeInformation();

                LoadPositions();

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

        private void LoadPositions()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                new NpgsqlDataAdapter(
@"
SELECT
    Post_id,
    Post_name
FROM Post
ORDER BY Post_name;
",
                connection))
            {
                adapter.Fill(table);
            }

            cmbPosition.DataSource =
                table;

            cmbPosition.DisplayMember =
                "Post_name";

            cmbPosition.ValueMember =
                "Post_id";

            cmbPosition.SelectedIndex =
                -1;
        }

        private void BtnChangePosition_Click(
            object sender,
            EventArgs e)
        {
            if (cmbPosition.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Выберите новую должность.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            ChangeEmployeePosition();
        }

        private void ChangeEmployeePosition()
        {
            NpgsqlTransaction transaction =
                null;

            try
            {
                connection.Open();

                transaction =
                    connection.BeginTransaction();

                string updateQuery =
@"
UPDATE Employee
SET
    Post_id = @PostId
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
                        "@PostId",
                        Convert.ToInt32(
                            cmbPosition.SelectedValue));

                    command.Parameters.AddWithValue(
                        "@EmployeeId",
                        employeeId);

                    command.ExecuteNonQuery();
                }

                AddPersonnelHistory(
                    transaction);

                transaction.Commit();

                MessageBox.Show(
                    "Должность успешно изменена.",
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
                    "Изменена должность на \"" +
                    cmbPosition.Text +
                    "\".";
            }
            else
            {
                description =
                    "Изменена должность на \"" +
                    cmbPosition.Text +
                    "\". Основание: " +
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
                    "Изменение должности");

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