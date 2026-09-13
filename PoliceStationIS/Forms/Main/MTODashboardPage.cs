using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Equipment;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class MTODashboardPage : UserControl
    {
        public MTODashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnWarehouse.Click += BtnWarehouse_Click;
            btnRequests.Click += BtnRequests_Click;
            btnMaintenance.Click += BtnMaintenance_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Всего имущества на складе / в системе.
                    lblWarehouseCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*) FROM equipment;"
                        ).ToString();

                    // Имущество, выданное сотрудникам.
                    lblIssuedCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM equipment e
                            INNER JOIN equipment_status s
                                ON s.equipment_status_id =
                                   e.equipment_status_id
                            WHERE s.equipment_status_name = 'Выдано';
                            "
                        ).ToString();

                    // Имущество, находящееся на обслуживании.
                    lblMaintenanceCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM equipment_maintenance
                            WHERE maintenance_status = 1;
                            "
                        ).ToString();

                    // Заявки на выдачу в обработке.
                    lblRequestsCount.Text =
                        ExecuteCount(
                            connection,
                            @"
                            SELECT COUNT(*)
                            FROM equipment_issue_request
                            WHERE request_status = 1;
                            "
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
                            event_date,
                            event_time,
                            event_name,
                            event_object
                        FROM
                        (
                            -- Выдача имущества сотруднику.
                            SELECT
                                e.equipment_date_of_issue AS event_date,
                                '00:00' AS event_time,
                                '● Выдано сотруднику' AS event_name,
                                e.equipment_name AS event_object
                            FROM equipment e
                            WHERE e.employee_id IS NOT NULL

                            UNION ALL

                            -- Новые заявки на выдачу.
                            SELECT
                                r.request_date AS event_date,
                                '00:00' AS event_time,
                                '● Принята новая заявка' AS event_name,
                                e.equipment_name AS event_object
                            FROM equipment_issue_request r
                            INNER JOIN equipment e
                                ON e.equipment_id = r.equipment_id

                            UNION ALL

                            -- Передача имущества на обслуживание.
                            SELECT
                                m.maintenance_date AS event_date,
                                '00:00' AS event_time,
                                '● Передано на обслуживание' AS event_name,
                                e.equipment_name AS event_object
                            FROM equipment_maintenance m
                            INNER JOIN equipment e
                                ON e.equipment_id = m.equipment_id

                            UNION ALL

                            -- Выполненное обслуживание.
                            SELECT
                                m.completion_date AS event_date,
                                '00:00' AS event_time,
                                '● Выполнено обслуживание' AS event_name,
                                e.equipment_name AS event_object
                            FROM equipment_maintenance m
                            INNER JOIN equipment e
                                ON e.equipment_id = m.equipment_id
                            WHERE m.completion_date IS NOT NULL

                            UNION ALL

                            -- Возвращение имущества на склад:
                            -- оборудование без закрепленного сотрудника.
                            SELECT
                                e.equipment_date_of_issue AS event_date,
                                '00:00' AS event_time,
                                '● Возвращено на склад' AS event_name,
                                e.equipment_name AS event_object
                            FROM equipment e
                            INNER JOIN equipment_status s
                                ON s.equipment_status_id =
                                   e.equipment_status_id
                            WHERE e.employee_id IS NULL
                              AND s.equipment_status_name = 'Исправно'
                        ) events
                        WHERE event_date IS NOT NULL
                        ORDER BY event_date DESC
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

                            string eventTime =
                                reader.IsDBNull(1)
                                    ? "—"
                                    : reader.GetString(1);

                            string eventName =
                                reader.IsDBNull(2)
                                    ? "—"
                                    : reader.GetString(2);

                            string eventObject =
                                reader.IsDBNull(3)
                                    ? "—"
                                    : reader.GetString(3);

                            dgvEvents.Rows.Add(
                                eventDate.ToString("dd.MM.yyyy"),
                                eventTime,
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

        private void BtnWarehouse_Click(
            object sender,
            EventArgs e)
        {
            using (WarehouseManagementForm form =
                new WarehouseManagementForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnRequests_Click(
            object sender,
            EventArgs e)
        {
            using (CreateIssueRequestForm form =
                new CreateIssueRequestForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnMaintenance_Click(
            object sender,
            EventArgs e)
        {
            using (MaintenanceForm form =
                new MaintenanceForm())
            {
                form.ShowDialog(this.FindForm());
            }

            LoadStatistics();
            LoadRecentEvents();
        }
    }
}
