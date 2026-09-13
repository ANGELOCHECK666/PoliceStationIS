using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Citizens;
using PoliceStationIS.Forms.Squads;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class DutyOfficerDashboardPage : UserControl
    {
        public DutyOfficerDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnPatrols.Click += BtnPatrols_Click;
            btnCallLog.Click += BtnCallLog_Click;
            btnRegisterIncident.Click += BtnRegisterIncident_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Все активные наряды.
                    lblActivePatrolsCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM schedule
                            WHERE CURRENT_TIMESTAMP BETWEEN
                                  planned_start_date_and_time
                                  AND planned_end_date_and_time;
                            "
                        ).ToString();

                    // Сотрудники, назначенные в наряды.
                    lblEmployeesShiftCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(DISTINCT employee_id)
                            FROM employee_squad;
                            "
                        ).ToString();

                    // Зарегистрированные события патрулирования.
                    lblIncidentsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM patrol_event_log;"
                        ).ToString();

                    // Всего граждан в системе.
                    lblCallsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM citizen;"
                        ).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статистику из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка загрузки статистики",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int ExecuteCount(
            NpgsqlConnection connection,
            string query)
        {
            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void LoadRecentEvents()
        {
            try
            {
                dgvEvents.Rows.Clear();

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string sql =
                        @"
                        SELECT
                            event_timestamp,
                            event_name,
                            event_object
                        FROM
                        (
                            SELECT
                                s.planned_start_date_and_time
                                    AS event_timestamp,
                                '● Наряд направлен'
                                    AS event_name,
                                'Наряд № ' ||
                                s.schedule_id::text AS event_object
                            FROM schedule s

                            UNION ALL

                            SELECT
                                s.planned_end_date_and_time
                                    AS event_timestamp,
                                '● Наряд завершил выезд'
                                    AS event_name,
                                'Наряд № ' ||
                                s.schedule_id::text AS event_object
                            FROM schedule s

                            UNION ALL

                            SELECT
                                pel.recording_date_and_time
                                    AS event_timestamp,
                                '● Зарегистрировано происшествие'
                                    AS event_name,
                                COALESCE(
                                    pel.scene_of_the_incident,
                                    '—'
                                ) AS event_object
                            FROM patrol_event_log pel
                        ) events
                        WHERE event_timestamp IS NOT NULL
                        ORDER BY event_timestamp DESC
                        LIMIT 10;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime eventDate =
                                    reader.GetDateTime(0);

                                string eventName =
                                    reader.IsDBNull(1)
                                        ? "—"
                                        : reader.GetString(1);

                                string eventObject =
                                    reader.IsDBNull(2)
                                        ? "—"
                                        : reader.GetString(2);

                                dgvEvents.Rows.Add(
                                    eventDate.ToString("dd.MM.yyyy"),
                                    eventDate.ToString("HH:mm"),
                                    eventName,
                                    eventObject);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить последние события из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка загрузки последних событий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Просмотреть наряды
        private void BtnPatrols_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenSquadsPage();
            }
        }

        // Добавить гражданина
        private void BtnCallLog_Click(
            object sender,
            EventArgs e)
        {
            using (CitizenEditForm form =
                new CitizenEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) == DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }

        // Просмотреть граждан
        private void BtnRegisterIncident_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenCitizensPage();
            }
        }
    }
}
