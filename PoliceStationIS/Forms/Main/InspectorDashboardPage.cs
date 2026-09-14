using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Squads;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class InspectorDashboardPage : UserControl
    {
        public InspectorDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnSchedule.Click += BtnSchedule_Click;
            btnRoute.Click += BtnRoute_Click;
            btnEquipmentAction.Click += BtnEquipmentAction_Click;
        }

        // ============================================================
        // СТАТИСТИКА
        // ============================================================

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Все наряды
                    lblMyPatrolsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM schedule;"
                        ).ToString();

                    lblTodayPatrolsCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM schedule
                            WHERE planned_start_date_and_time::date =
                            (
                                SELECT MAX(
                                    planned_start_date_and_time::date
                                )
                                FROM schedule
                            );
                            "
                        ).ToString();

                    // Вся экипировка
                    lblEquipmentCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM equipment;"
                        ).ToString();

                    // Все маршруты
                    lblRoutesCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM patrol_and_post_service;"
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
                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        // ============================================================
        // ПОСЛЕДНИЕ СОБЫТИЯ
        // ============================================================

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
                            -- Получение / начало наряда
                            SELECT
                                s.planned_start_date_and_time
                                    AS event_timestamp,
                                '● Получен наряд'
                                    AS event_name,
                                'Наряд № ' ||
                                s.schedule_id::text ||
                                ', маршрут: ' ||
                                COALESCE(
                                    p.route,
                                    '—'
                                ) AS event_object
                            FROM schedule s
                            LEFT JOIN patrol_and_post_service p
                                ON p.schedule_id = s.schedule_id

                            UNION ALL

                            -- Завершение наряда
                            SELECT
                                s.planned_end_date_and_time
                                    AS event_timestamp,
                                '● Завершение наряда'
                                    AS event_name,
                                'Наряд № ' ||
                                s.schedule_id::text ||
                                ', маршрут: ' ||
                                COALESCE(
                                    p.route,
                                    '—'
                                ) AS event_object
                            FROM schedule s
                            LEFT JOIN patrol_and_post_service p
                                ON p.schedule_id = s.schedule_id

                            UNION ALL

                            -- События патрулирования
                            SELECT
                                pel.recording_date_and_time
                                    AS event_timestamp,
                                '● Событие патрулирования'
                                    AS event_name,
                                COALESCE(
                                    pel.scene_of_the_incident,
                                    '—'
                                ) AS event_object
                            FROM patrol_event_log pel

                            UNION ALL

                            -- Выдача экипировки
                            SELECT
                                e.equipment_date_of_issue::timestamp
                                    AS event_timestamp,
                                '● Получена экипировка'
                                    AS event_name,
                                e.equipment_name
                                    AS event_object
                            FROM equipment e
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

        // ============================================================
        // ПРОСМОТР СПИСКА НАРЯДОВ
        // ============================================================

        private void BtnSchedule_Click(
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

        // ============================================================
        // ДОБАВИТЬ НАРЯД
        // ============================================================

        private void BtnRoute_Click(
            object sender,
            EventArgs e)
        {
            using (SquadEditForm form =
                new SquadEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) == DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }

        // ============================================================
        // ЭКИПИРОВКА
        // ============================================================

        private void BtnEquipmentAction_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenEquipmentPage();
            }
        }
    }
}
