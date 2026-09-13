using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Dogs;
using PoliceStationIS.Forms.Equipment;
using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class DogHandlerDashboardPage : UserControl
    {
        public DogHandlerDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnAddDog.Click += BtnAddDog_Click;
            btnViewDogs.Click += BtnViewDogs_Click;
            btnAssignPatrol.Click += BtnAssignPatrol_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    lblAssignedDogsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM service_dog
                              WHERE employee_id IS NOT NULL;")
                        .ToString();

                    lblPatrolDogsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM patrol_and_post_service
                              WHERE LOWER(description) LIKE '%кинолог%';")
                        .ToString();

                    lblNewDogsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM service_dog sd
                              INNER JOIN dog_status ds
                                  ON sd.dog_status_id = ds.dog_status_id
                              WHERE ds.dog_status_name = 'На обучении';")
                        .ToString();

                    lblActiveDogsCount.Text =
                        ExecuteCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM service_dog sd
                              INNER JOIN dog_status ds
                                  ON sd.dog_status_id = ds.dog_status_id
                              WHERE ds.dog_status_name = 'На службе';")
                        .ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статистику служебных собак.\n\n" +
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

        private void LoadRecentEvents()
        {
            try
            {
                dgvEvents.Rows.Clear();

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            sd.date_of_birth AS event_date,
                            '—' AS event_time,
                            '● Зарегистрирована служебная собака' AS event_name,
                            sd.dog_name AS dog_name
                        FROM service_dog sd

                        UNION ALL

                        SELECT
                            NULL AS event_date,
                            '—' AS event_time,
                            '● Патруль с кинологической группой' AS event_name,
                            COALESCE(
                                (
                                    SELECT sd.dog_name
                                    FROM service_dog sd
                                    INNER JOIN employee_squad es
                                        ON es.employee_id = sd.employee_id
                                    WHERE LOWER(es.personal_notes)
                                          LIKE '%кинолог%'
                                    LIMIT 1
                                ),
                                '—'
                            ) AS dog_name
                        FROM patrol_and_post_service pps
                        WHERE LOWER(pps.description) LIKE '%кинолог%'

                        ORDER BY event_date DESC NULLS LAST
                        LIMIT 10;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
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

                                dgvEvents.Rows.Add(
                                    date,
                                    reader["event_time"].ToString(),
                                    reader["event_name"].ToString(),
                                    reader["dog_name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить последние события.\n\n" +
                    ex.Message,
                    "Ошибка загрузки последних событий",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAddDog_Click(
            object sender,
            EventArgs e)
        {
            using (ServiceDogEditForm form =
                new ServiceDogEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }

        private void BtnViewDogs_Click(
     object sender,
     EventArgs e)
        {
            MainForm mainForm =
                this.FindForm() as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenDogsPage();
            }
        }

        private void BtnAssignPatrol_Click(object sender, EventArgs e)
        {
            using (CreateIssueRequestForm form =
                new CreateIssueRequestForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadStatistics();
                    LoadRecentEvents();
                }
            }
        }
    }
}
