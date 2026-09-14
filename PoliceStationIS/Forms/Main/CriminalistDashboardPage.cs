using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Evidence;
using PoliceStationIS.Forms.Expertises;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class CriminalistDashboardPage : UserControl
    {
        public CriminalistDashboardPage()
        {
            // При открытии панели загружаем актуальные данные из базы данных.

            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnExpertises.Click += BtnExpertises_Click;
            btnAddReport.Click += BtnAddReport_Click;
            btnEvidence.Click += BtnEvidence_Click;
        }

        // =====================================
        // STATISTICS
        // =====================================

        // Загрузка основных показателей панели.
        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    LoadExpertisesCount(connection);
                    LoadInspectionsCount(connection);
                    LoadEvidenceCount(connection);
                    LoadCompletedExpertisesCount(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки статистики",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Количество назначенных и проводимых экспертиз.
        private void LoadExpertisesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Inspection i
                  JOIN Inspection_status s
                    ON s.Inspection_status_id =
                       i.Inspection_status_id
                  WHERE s.Inspection_status_name IN
                        ('Назначена', 'Проводится')";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblExpertisesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        // Количество протоколов осмотра места происшествия.
        private void LoadInspectionsCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Protocol p
                  JOIN Protocol_type pt
                    ON pt.Protocol_type_id =
                       p.Protocol_type_id
                  WHERE pt.Protocol_type_name =
                        'О результатах осмотра'";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblInspectionsCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        // Общее количество зарегистрированных доказательств.
        private void LoadEvidenceCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Evidence";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblEvidenceCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        // Количество завершённых экспертиз.
        private void LoadCompletedExpertisesCount(
            NpgsqlConnection connection)
        {
            string sql =
                @"SELECT COUNT(*)
                  FROM Inspection i
                  JOIN Inspection_status s
                    ON s.Inspection_status_id =
                       i.Inspection_status_id
                  WHERE s.Inspection_status_name =
                        'Завершена'";

            using (NpgsqlCommand command =
                new NpgsqlCommand(sql, connection))
            {
                lblCompletedExpertisesCount.Text =
                    command.ExecuteScalar().ToString();
            }
        }

        // =====================================
        // RECENT EVENTS
        // =====================================

        // Загрузка последних событий по экспертизам, доказательствам и протоколам.
        private void LoadRecentEvents()
        {
            try
            {
                dgvEvents.Rows.Clear();

                string sql =
                    @"
                    SELECT
                        event_date,
                        event_type,
                        event_number
                    FROM
                    (
                        SELECT
                            i.appointment_date::timestamp
                                AS event_date,
                            CASE
                                WHEN s.inspection_status_name =
                                     'Завершена'
                                THEN 'Завершена экспертиза'

                                WHEN s.inspection_status_name =
                                     'Проводится'
                                THEN 'Проводится экспертиза'

                                WHEN s.inspection_status_name =
                                     'Приостановлена'
                                THEN 'Приостановлена экспертиза'

                                WHEN s.inspection_status_name =
                                     'Отменена'
                                THEN 'Отменена экспертиза'

                                ELSE 'Назначена экспертиза'
                            END AS event_type,
                            i.inspection_number AS event_number
                        FROM Inspection i
                        JOIN Inspection_status s
                          ON s.inspection_status_id =
                             i.inspection_status_id

                        UNION ALL

                        SELECT
                            e.date_of_seizure::timestamp
                                AS event_date,
                            'Добавлено доказательство'
                                AS event_type,
                            e.evidence_number AS event_number
                        FROM Evidence e

                        UNION ALL

                        SELECT
                            p.date_of_preparation_protocol::timestamp
                                AS event_date,
                            'Осмотр места происшествия'
                                AS event_type,
                            p.protocol_number AS event_number
                        FROM Protocol p
                        JOIN Protocol_type pt
                          ON pt.protocol_type_id =
                             p.protocol_type_id
                        WHERE pt.protocol_type_name =
                              'О результатах осмотра'
                    ) events
                    ORDER BY event_date DESC
                    LIMIT 10;
                    ";

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

                                string eventNumber =
                                    reader.IsDBNull(2)
                                        ? "—"
                                        : reader.GetString(2);

                                dgvEvents.Rows.Add(
                                    date.ToString("dd.MM.yyyy"),
                                    "—",
                                    eventType,
                                    eventNumber);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================
        // BUTTONS
        // =====================================

        private void BtnExpertises_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenExpertisesPage();
            }
        }

        private void BtnAddReport_Click(
            object sender,
            EventArgs e)
        {
            using (ExpertiseEditForm form =
                new ExpertiseEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }

        private void BtnEvidence_Click(
            object sender,
            EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenEvidencePage();
            }
        }
    }
}
