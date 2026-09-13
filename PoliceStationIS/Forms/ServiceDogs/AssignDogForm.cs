using Npgsql;
using NpgsqlTypes;
using PoliceStationIS.Database;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Dogs
{
    public partial class AssignDogForm : Form
    {
        private readonly int serviceDogId;

        public AssignDogForm(
            int serviceDogId)
        {
            InitializeComponent();

            this.serviceDogId =
                serviceDogId;

            LoadDogInfo();
            LoadDogHandlers();
        }

        private void LoadDogInfo()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            sd.dog_name,
                            sd.stamp_number,
                            CONCAT_WS(
                                ' ',
                                e.last_name,
                                e.name_,
                                e.middle_name
                            ) AS employee_name
                        FROM Service_dog sd
                        INNER JOIN Employee e
                            ON sd.employee_id = e.employee_id
                        WHERE sd.service_dog_id = @id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@id",
                            NpgsqlDbType.Integer)
                            .Value =
                            serviceDogId;

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Служебная собака не найдена.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                Close();
                                return;
                            }

                            lblDogNameValue.Text =
                                reader["dog_name"]
                                .ToString();

                            lblStampValue.Text =
                                reader["stamp_number"]
                                .ToString()
                                .Trim();

                            lblCurrentEmployeeValue.Text =
                                reader["employee_name"]
                                .ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные собаки.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDogHandlers()
        {
            try
            {
                cmbEmployee.Items.Clear();

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            e.employee_id,
                            CONCAT_WS(
                                ' ',
                                e.last_name,
                                e.name_,
                                e.middle_name
                            ) AS employee_name
                        FROM Employee e
                        INNER JOIN Post p
                            ON e.post_id = p.post_id
                        WHERE p.post_name IN
                        (
                            'Кинолог',
                            'Инструктор-кинолог'
                        )
                        ORDER BY e.last_name, e.name_;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEmployee.Items.Add(
                                    new EmployeeItem
                                    {
                                        Id =
                                            Convert.ToInt32(
                                                reader["employee_id"]),

                                        Name =
                                            reader["employee_name"]
                                            .ToString()
                                    });
                            }
                        }
                    }
                }

                cmbEmployee.DisplayMember =
                    "Name";

                cmbEmployee.ValueMember =
                    "Id";

                if (cmbEmployee.Items.Count > 0)
                {
                    cmbEmployee.SelectedIndex =
                        0;
                }
                else
                {
                    MessageBox.Show(
                        "В системе нет сотрудников с должностью «Кинолог» или «Инструктор-кинолог».",
                        "Закрепление",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить список кинологов.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            EmployeeItem employee =
                cmbEmployee.SelectedItem
                as EmployeeItem;

            if (employee == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Закрепление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEmployee.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        UPDATE Service_dog
                        SET employee_id = @employee_id
                        WHERE service_dog_id = @dog_id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@employee_id",
                            NpgsqlDbType.Integer)
                            .Value =
                            employee.Id;

                        command.Parameters.Add(
                            "@dog_id",
                            NpgsqlDbType.Integer)
                            .Value =
                            serviceDogId;

                        int rowsAffected =
                            command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception(
                                "Служебная собака не найдена.");
                        }
                    }
                }

                MessageBox.Show(
                    "Служебная собака успешно закреплена за сотрудником.",
                    "Закрепление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось закрепить собаку за сотрудником.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private class EmployeeItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
