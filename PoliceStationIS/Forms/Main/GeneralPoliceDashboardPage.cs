using System;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Main
{
    public partial class GeneralPoliceDashboardPage : UserControl
    {
        public GeneralPoliceDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnReports.Click += BtnReports_Click;
            btnStatistics.Click += BtnStatistics_Click;
            btnDepartments.Click += BtnDepartments_Click;
        }

        // =====================================
        // STATISTICS
        // =====================================

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    LoadEmployeesCount(connection);
                    LoadCasesCount(connection);
                    LoadPatrolsCount(connection);
                    LoadDepartmentsCount(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статистику из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка подключения к БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Employee;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblEmployeesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadCasesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Criminal_case cc
                  INNER JOIN Case_status cs
                      ON cs.Case_status_id =
                         cc.Case_status_id
                  WHERE cs.Case_status_name IN
                        ('Возбуждено', 'Расследуется');";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblCasesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadPatrolsCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Schedule
                  WHERE Planned_start_date_and_time::date =
                        CURRENT_DATE;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblPatrolsCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadDepartmentsCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Department;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblDepartmentsCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        // =====================================
        // RECENT EVENTS
        // =====================================

        private void LoadRecentEvents()
        {
            try
            {
                dgvEvents.Rows.Clear();

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string sql =
                        @"
                        SELECT
                            event_date,
                            event_time,
                            event_name,
                            department_name
                        FROM
                        (
                            SELECT
                                ph.event_date::date AS event_date,
                                ph.event_date::time AS event_time,
                                CASE
                                    WHEN ph.event_type = 'Прием на работу'
                                        THEN 'Принят новый сотрудник'
                                    WHEN ph.event_type = 'Изменение должности'
                                        THEN 'Изменена должность сотрудника'
                                    WHEN ph.event_type = 'Отпуск'
                                        THEN 'Оформлен отпуск'
                                    WHEN ph.event_type = 'Больничный'
                                        THEN 'Оформлен больничный'
                                    WHEN ph.event_type = 'Возврат из отпуска'
                                        THEN 'Сотрудник вернулся из отпуска'
                                    ELSE ph.event_type
                                END AS event_name,
                                d.department_name
                            FROM Personnel_history ph
                            INNER JOIN Employee e
                                ON e.employee_id = ph.employee_id
                            INNER JOIN Department d
                                ON d.department_id = e.department_id

                            UNION ALL

                            SELECT
                                cc.date_and_time_of_crime::date AS event_date,
                                cc.date_and_time_of_crime::time AS event_time,
                                'Открыто уголовное дело' AS event_name,
                                d.department_name
                            FROM Criminal_case cc
                            LEFT JOIN Employee e
                                ON e.employee_id = cc.employee_id
                            LEFT JOIN Department d
                                ON d.department_id = e.department_id
                            WHERE cc.date_and_time_of_crime IS NOT NULL

                            UNION ALL

                            SELECT
                                i.appointment_date AS event_date,
                                NULL::time AS event_time,
                                'Назначена экспертиза' AS event_name,
                                d.department_name
                            FROM Inspection i
                            LEFT JOIN Employee e
                                ON e.employee_id = i.employee_id
                            LEFT JOIN Department d
                                ON d.department_id = e.department_id

                            UNION ALL

                            SELECT
                                s.planned_start_date_and_time::date AS event_date,
                                s.planned_start_date_and_time::time AS event_time,
                                'Создан новый наряд' AS event_name,
                                (
                                    SELECT d2.department_name
                                    FROM Employee_squad es
                                    INNER JOIN Employee e2
                                        ON e2.employee_id = es.employee_id
                                    INNER JOIN Department d2
                                        ON d2.department_id = e2.department_id
                                    WHERE es.squad_id = s.squad_id
                                    ORDER BY e2.employee_id
                                    LIMIT 1
                                ) AS department_name
                            FROM Schedule s
                        ) events
                        ORDER BY
                            event_date DESC,
                            event_time DESC NULLS LAST
                        LIMIT 10;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string date =
                                reader["event_date"] == DBNull.Value
                                    ? "—"
                                    : Convert.ToDateTime(
                                        reader["event_date"])
                                        .ToString("dd.MM.yyyy");

                            string time = "—";

                            if (reader["event_time"] != DBNull.Value)
                            {
                                TimeSpan eventTime =
                                    (TimeSpan)reader["event_time"];

                                time =
                                    eventTime.ToString(@"hh\:mm");
                            }

                            string eventName =
                                reader["event_name"] == DBNull.Value
                                    ? "—"
                                    : reader["event_name"].ToString();

                            string department =
                                reader["department_name"] == DBNull.Value
                                    ? "—"
                                    : reader["department_name"].ToString();

                            dgvEvents.Rows.Add(
                                date,
                                time,
                                "● " + eventName,
                                department);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить последние события из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка подключения к БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================
        // QUICK ACTIONS
        // =====================================

        // Кнопка "Просмотреть сотрудников"
        private void BtnReports_Click(
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

        // Кнопка "Просмотреть статистику"
        private void BtnStatistics_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenStatisticsPage();
            }
        }

        // Кнопка "Контроль подразделений"
        private void BtnDepartments_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenDepartmentsPage();
            }
        }
    }
}
