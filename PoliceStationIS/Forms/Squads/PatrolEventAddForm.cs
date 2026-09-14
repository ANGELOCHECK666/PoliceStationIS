using System;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Squads
{
    public partial class PatrolEventAddForm : Form
    {
        private readonly int patrolServiceId;
        private readonly string squadNumber;

        public PatrolEventAddForm(
            int patrolServiceId,
            string squadNumber)
        {
            InitializeComponent();

            this.patrolServiceId = patrolServiceId;
            this.squadNumber = squadNumber;

            ConfigureControls();
            LoadRecordingTypes();
            LoadCrimeRates();
        }

        private void ConfigureControls()
        {
            cmbRecordingType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCrimeRate.DropDownStyle = ComboBoxStyle.DropDownList;

            dtRecordingDate.Value = DateTime.Now;
            lblSquadValue.Text = squadNumber;
        }

        private void LoadRecordingTypes()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            recording_type_id,
                            recording_type_name
                        FROM recording_type
                        ORDER BY recording_type_name;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbRecordingType.Items.Clear();

                        while (reader.Read())
                        {
                            cmbRecordingType.Items.Add(
                                new ComboBoxItem
                                {
                                    Id = Convert.ToInt32(
                                        reader["recording_type_id"]),
                                    Name = reader[
                                        "recording_type_name"].ToString()
                                });
                        }
                    }
                }

                if (cmbRecordingType.Items.Count > 0)
                    cmbRecordingType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить типы событий.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCrimeRates()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            crime_rate_id,
                            crime_rate_name
                        FROM crime_rate
                        ORDER BY crime_rate_id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbCrimeRate.Items.Clear();

                        while (reader.Read())
                        {
                            cmbCrimeRate.Items.Add(
                                new ComboBoxItem
                                {
                                    Id = Convert.ToInt32(
                                        reader["crime_rate_id"]),
                                    Name = reader[
                                        "crime_rate_name"].ToString()
                                });
                        }
                    }
                }

                if (cmbCrimeRate.Items.Count > 0)
                    cmbCrimeRate.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить уровни опасности.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            if (patrolServiceId <= 0)
            {
                MessageBox.Show(
                    "Для добавления события не выбран наряд.",
                    "Добавление события",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ComboBoxItem typeItem =
                cmbRecordingType.SelectedItem as ComboBoxItem;

            ComboBoxItem rateItem =
                cmbCrimeRate.SelectedItem as ComboBoxItem;

            if (typeItem == null)
            {
                MessageBox.Show(
                    "Выберите тип события.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (rateItem == null)
            {
                MessageBox.Show(
                    "Выберите уровень опасности.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string scene = txtScene.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(scene))
            {
                MessageBox.Show(
                    "Укажите место происшествия.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtScene.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Введите описание события.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO patrol_event_log
                        (
                            patrol_and_post_service_id,
                            recording_type_id,
                            crime_rate_id,
                            scene_of_the_incident,
                            recording_date_and_time,
                            description_recording
                        )
                        VALUES
                        (
                            @service_id,
                            @recording_type_id,
                            @crime_rate_id,
                            @scene,
                            @recording_date,
                            @description
                        );
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@service_id",
                            patrolServiceId);

                        command.Parameters.AddWithValue(
                            "@recording_type_id",
                            typeItem.Id);

                        command.Parameters.AddWithValue(
                            "@crime_rate_id",
                            rateItem.Id);

                        command.Parameters.AddWithValue(
                            "@scene",
                            scene);

                        command.Parameters.AddWithValue(
                            "@recording_date",
                            dtRecordingDate.Value);

                        command.Parameters.AddWithValue(
                            "@description",
                            description);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Событие успешно добавлено.",
                    "Добавление события",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить событие.\n\n" + ex.Message,
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
