using Npgsql;
using System;
using System.Windows.Forms;
using PoliceStationIS.Forms.Employees;

namespace PoliceStationIS.Forms.Main
{
    public partial class HRDashboardPage : UserControl
    {

        private readonly string connectionString =
    @"Host=localhost;
      Port=5432;
      Database=PoliceStation;
      Username=postgres;
      Password=1234567890"; 
        public HRDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentChanges();
            btnAddEmployee.Click += BtnAddEmployee_Click;
        }

        private void LoadStatistics()
        {


            try
            {
                

                using (NpgsqlConnection connection =
                    new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    LoadEmployeesCount(connection);

                    LoadNewEmployeesCount(connection);

                    LoadVacationCount(connection);

                    LoadSickLeaveCount(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки статистики");
            }
        }

        private void LoadRecentChanges()
        {
            try
            {
                dgvChanges.Rows.Clear();

                string sql =
                    @"SELECT
                ph.Event_date,
                ph.Event_type,
                e.Last_name,
                e.Name_,
                e.Middle_name
              FROM Personnel_history ph
              JOIN Employee e
                   ON ph.Employee_id =
                      e.Employee_id
              ORDER BY ph.Event_date DESC
              LIMIT 10";

                using (NpgsqlConnection connection =
                    new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime date =
                                    reader.GetDateTime(0);

                                string eventType =
                                    reader.GetString(1);

                                switch (eventType)
                                {
                                    case "Прием на работу":
                                        eventType = "● Принят";
                                        break;

                                    case "Отпуск":
                                        eventType = "● В отпуске";
                                        break;

                                    case "Больничный":
                                        eventType = "● Больничный";
                                        break;

                                    case "Изменение должности":
                                        eventType = "● Переведен";
                                        break;

                                    case "Возврат из отпуска":
                                        eventType = "● Вернулся";
                                        break;
                                }

                                string lastName =
                                    reader.GetString(2);

                                string firstName =
                                    reader.GetString(3);

                                string middleName =
                                    reader.IsDBNull(4)
                                        ? ""
                                        : reader.GetString(4);

                                string fio =
                                    $"{lastName} " +
                                    $"{firstName[0]}. ";

                                if (!string.IsNullOrEmpty(
                                    middleName))
                                {
                                    fio +=
                                        $"{middleName[0]}.";
                                }

                                dgvChanges.Rows.Add(
                                    date.ToString("dd.MM.yyyy"),
                                    date.ToString("HH:mm"),
                                    eventType,
                                    fio);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки кадровых изменений");
            }
        }

        private void LoadEmployeesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Employee
                  WHERE Employment_status_id <> 4";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblEmployeesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadNewEmployeesCount(
     NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
          FROM Personnel_history
          WHERE Event_type = 'Прием на работу'
          AND DATE_TRUNC('month', Event_date)
              = DATE_TRUNC('month', CURRENT_DATE)";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblNewEmployeesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadVacationCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Employee
                  WHERE Employment_status_id = 2";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblVacationCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadSickLeaveCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Employee
                  WHERE Employment_status_id = 3";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblSickCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void BtnAddEmployee_Click(
    object sender,
    EventArgs e)
        {
            AddEmployeeForm form =
                new AddEmployeeForm();

            form.ShowDialog();

            LoadStatistics();
            LoadRecentChanges();
        }
    }
}