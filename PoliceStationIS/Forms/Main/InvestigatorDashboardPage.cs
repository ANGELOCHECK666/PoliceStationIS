using Npgsql;
using PoliceStationIS.Forms.Cases;
using PoliceStationIS.Forms.Citizens;
using PoliceStationIS.Forms.Protocols;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class InvestigatorDashboardPage : UserControl
    {
        private readonly string connectionString =
            @"Host=localhost;
              Port=5432;
              Database=PoliceStation;
              Username=postgres;
              Password=1234567890";

        public InvestigatorDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnCreateCase.Click += BtnCreateCase_Click;
            btnAddCitizen.Click += BtnAddCitizen_Click;
            btnCreateProtocol.Click += BtnCreateProtocol_Click;
        }

        // ============================================================
        // СТАТИСТИКА
        // ============================================================

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Все уголовные дела
                    lblMyCasesCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM Criminal_case;
                            ").ToString();

                    // Все активные уголовные дела
                    lblActiveCasesCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM Criminal_case cc
                            INNER JOIN Case_status cs
                                ON cs.Case_status_id =
                                   cc.Case_status_id
                            WHERE cs.Case_status_name IN
                            (
                                'Возбуждено',
                                'Расследуется',
                                'Приостановлено'
                            );
                            ").ToString();

                    // Все протоколы
                    lblProtocolsCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM Protocol;
                            ").ToString();

                    // Все экспертизы
                    lblExpertisesCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM Inspection;
                            ").ToString();
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
                    new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        @"
                        SELECT
                            event_timestamp,
                            event_name,
                            event_object
                        FROM
                        (
                            -- Уголовные дела
                            SELECT
                                COALESCE(
                                    cc.Case_creation_date::timestamp,
                                    cc.Date_and_time_of_crime
                                ) AS event_timestamp,
                                '● Уголовное дело' AS event_name,
                                '№ ' ||
                                TRIM(cc.Case_number) AS event_object
                            FROM Criminal_case cc

                            UNION ALL

                            -- Протоколы
                            SELECT
                                p.Date_of_preparation_protocol::timestamp
                                    AS event_timestamp,
                                '● Составлен протокол'
                                    AS event_name,
                                '№ ' ||
                                TRIM(p.Protocol_number)
                                    AS event_object
                            FROM Protocol p

                            UNION ALL

                            -- Экспертизы
                            SELECT
                                i.Appointment_date::timestamp
                                    AS event_timestamp,
                                '● Назначена экспертиза'
                                    AS event_name,
                                '№ ' ||
                                TRIM(i.Inspection_number)
                                    AS event_object
                            FROM Inspection i

                            UNION ALL

                            -- Работа с гражданами
                            SELECT
                                ch.Event_date AS event_timestamp,
                                CASE
                                    WHEN ch.Event_type = 'Создание'
                                        THEN '● Добавлен гражданин'
                                    WHEN ch.Event_type = 'Изменение'
                                        THEN '● Изменены данные гражданина'
                                    WHEN ch.Event_type = 'Удаление'
                                        THEN '● Удалён гражданин'
                                    ELSE
                                        '● Изменение гражданина'
                                END AS event_name,
                                'Гражданин № ' ||
                                ch.Citizen_id::text AS event_object
                            FROM Citizen_history ch
                        ) events
                        WHERE event_timestamp IS NOT NULL
                        ORDER BY event_timestamp DESC
                        LIMIT 10;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection))
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
        // БЫСТРЫЕ ДЕЙСТВИЯ
        // ============================================================

        private void BtnCreateCase_Click(
            object sender,
            EventArgs e)
        {
            using (CaseEditForm form =
                new CaseEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) == DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }

        private void BtnAddCitizen_Click(
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

        private void BtnCreateProtocol_Click(
            object sender,
            EventArgs e)
        {
            using (ProtocolEditForm form =
                new ProtocolEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) == DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }
    }
}
