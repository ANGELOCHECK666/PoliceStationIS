using System;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Expertises;
using PoliceStationIS.Forms.Squads;
using PoliceStationIS.Forms.Cases;

namespace PoliceStationIS.Forms.Main
{
    public partial class DepartmentChiefDashboardPage : UserControl
    {
        public DepartmentChiefDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnAssignExpertise.Click += BtnAssignExpertise_Click;
            btnCreatePatrol.Click += BtnCreatePatrol_Click;
            btnCreateCase.Click += BtnCreateCase_Click;
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
                    LoadExpertisesCount(connection);
                    LoadPatrolsCount(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статистику.\n\n" +
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
                  FROM Criminal_case;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblCasesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        private void LoadExpertisesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Inspection i
                  INNER JOIN Inspection_status s
                      ON s.Inspection_status_id =
                         i.Inspection_status_id
                  WHERE s.Inspection_status_name IN
                        ('Назначена', 'Проводится');";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblExpertisesCount.Text =
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
                            event_object
                        FROM
                        (
                            SELECT
                                cc.date_and_time_of_crime::date AS event_date,
                                cc.date_and_time_of_crime::time AS event_time,
                                'Открыто уголовное дело' AS event_name,
                                'Дело №' || TRIM(cc.case_number) AS event_object
                            FROM Criminal_case cc
                            WHERE cc.date_and_time_of_crime IS NOT NULL

                            UNION ALL

                            SELECT
                                i.appointment_date AS event_date,
                                NULL::time AS event_time,
                                'Назначена экспертиза' AS event_name,
                                'Экспертиза №' || TRIM(i.inspection_number) AS event_object
                            FROM Inspection i

                            UNION ALL

                            SELECT
                                s.planned_start_date_and_time::date AS event_date,
                                s.planned_start_date_and_time::time AS event_time,
                                'Создан новый наряд' AS event_name,
                                'Наряд №' || s.schedule_id::text AS event_object
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

                                time = eventTime.ToString(@"hh\:mm");
                            }

                            string eventName =
                                reader["event_name"].ToString();

                            string eventObject =
                                reader["event_object"].ToString();

                            dgvEvents.Rows.Add(
                                date,
                                time,
                                eventName,
                                eventObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить последние события.\n\n" +
                    ex.Message,
                    "Ошибка подключения к БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================
        // QUICK ACTIONS
        // =====================================

        private void BtnAssignExpertise_Click(
            object sender,
            EventArgs e)
        {
            using (ExpertiseEditForm form =
                new ExpertiseEditForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnCreatePatrol_Click(
            object sender,
            EventArgs e)
        {
            using (SquadEditForm form =
                new SquadEditForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnCreateCase_Click(
            object sender,
            EventArgs e)
        {
            using (CaseEditForm form =
                new CaseEditForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }
    }
}
