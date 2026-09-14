using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Employees;
using PoliceStationIS.Forms.HR;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class HRDashboardPage : UserControl
    {
        public HRDashboardPage()
        {
            // При открытии панели загружаем актуальные данные из базы данных.

            InitializeComponent();

            LoadStatistics();
            LoadRecentChanges();

            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnViewEmployeess.Click += BtnViewEmployeess_Click;
            btnReport.Click += BtnReport_Click;

        }

        // Загрузка основных показателей панели.
        private void LoadStatistics()
        {


            try
            {


                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
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

        // Загрузка последних кадровых изменений из истории персонала.
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
                    DatabaseConnection.GetConnection())
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

        // Количество действующих сотрудников.
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

        // Количество принятых сотрудников за текущий месяц.
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

        // Количество сотрудников в отпуске.
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

        // Количество сотрудников на больничном.
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

        private void BtnViewEmployeess_Click(
    object sender,
    EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenEmployeesPage();
            }
        }

        private void BtnReport_Click(
    object sender,
    EventArgs e)
        {
            using (ReportsForm form =
    new ReportsForm())
            {
                form.ShowDialog();
            }
        }
    }
}