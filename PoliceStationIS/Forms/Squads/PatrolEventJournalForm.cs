using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Squads
{
    public partial class PatrolEventJournalForm : Form
    {
        private readonly int patrolServiceId;
        private readonly string squadNumber;

        private DataTable eventsTable;


        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public PatrolEventJournalForm(
            int patrolServiceId,
            string squadNumber)
        {
            InitializeComponent();

            this.patrolServiceId =
                patrolServiceId;

            this.squadNumber =
                squadNumber;

            ConfigureEvents();

            LoadJournal();
        }


        // ============================================================
        // EVENTS
        // ============================================================

        private void ConfigureEvents()
        {
            btnPrintJournal.Click +=
                BtnPrintJournal_Click;

            btnClose.Click +=
                BtnClose_Click;
        }


        private void BtnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }


        // ============================================================
        // LOAD JOURNAL
        // ============================================================

        private void LoadJournal()
        {
            lblSquadValue.Text =
                string.IsNullOrWhiteSpace(
                    squadNumber)
                ? "—"
                : squadNumber;

            flpEvents.Controls.Clear();

            if (patrolServiceId <= 0)
            {
                lblEventsCountValue.Text =
                    "0";

                AddEmptyMessage(
                    "Для выбранного наряда журнал событий недоступен.");

                btnPrintJournal.Enabled =
                    false;

                return;
            }


            try
            {
                using (
                    NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();


                    string query =
                        @"
                        SELECT

                            pel.patrol_event_log_id
                                AS ""Id"",

                            rt.recording_type_name
                                AS ""RecordingType"",

                            cr.crime_rate_name
                                AS ""CrimeRate"",

                            pel.scene_of_the_incident
                                AS ""Scene"",

                            pel.recording_date_and_time
                                AS ""RecordingDateTime"",

                            pel.description_recording
                                AS ""Description"",

                            CASE
                                WHEN pel.patrol_event_log_file
                                    IS NULL
                                THEN FALSE
                                ELSE TRUE
                            END
                                AS ""HasFile""

                        FROM patrol_event_log pel

                        INNER JOIN recording_type rt
                            ON pel.recording_type_id =
                               rt.recording_type_id

                        INNER JOIN crime_rate cr
                            ON pel.crime_rate_id =
                               cr.crime_rate_id

                        WHERE
                            pel.patrol_and_post_service_id =
                            @service_id

                        ORDER BY
                            pel.recording_date_and_time DESC;
                        ";


                    using (
                        NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@service_id",
                            patrolServiceId);


                        using (
                            NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(
                                command))
                        {
                            eventsTable =
                                new DataTable();

                            adapter.Fill(
                                eventsTable);
                        }
                    }
                }


                lblEventsCountValue.Text =
                    eventsTable.Rows.Count
                    .ToString();


                if (eventsTable.Rows.Count == 0)
                {
                    AddEmptyMessage(
                        "Для этого наряда событий пока нет.");

                    btnPrintJournal.Enabled =
                        false;

                    return;
                }


                foreach (
                    DataRow row
                    in eventsTable.Rows)
                {
                    flpEvents.Controls.Add(
                        CreateEventCard(row));
                }


                btnPrintJournal.Enabled =
                    true;
            }
            catch (Exception ex)
            {
                AddEmptyMessage(
                    "Не удалось загрузить журнал событий.");

                btnPrintJournal.Enabled =
                    false;

                MessageBox.Show(
                    "Не удалось загрузить журнал событий.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // EVENT CARD
        // ============================================================

        private Panel CreateEventCard(
            DataRow row)
        {
            Panel card =
                new Panel();

            card.Size =
                new Size(
                    790,
                    105);

            card.Margin =
                new Padding(
                    0,
                    0,
                    0,
                    8);

            card.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            card.BorderStyle =
                BorderStyle.FixedSingle;


            // ========================================================
            // DATE
            // ========================================================

            Label lblDate =
                CreateLabel(
                    Convert.ToDateTime(
                        row["RecordingDateTime"])
                    .ToString(
                        "dd.MM.yyyy HH:mm"),
                    15,
                    12,
                    140,
                    Color.White,
                    FontStyle.Bold);


            // ========================================================
            // TYPE
            // ========================================================

            Label lblType =
                CreateLabel(
                    row["RecordingType"]
                        .ToString(),
                    170,
                    12,
                    220,
                    Color.Gainsboro,
                    FontStyle.Bold);


            // ========================================================
            // CRIME RATE
            // ========================================================

            Label lblRate =
                CreateLabel(
                    "Уровень: " +
                    row["CrimeRate"]
                        .ToString(),
                    405,
                    12,
                    180,
                    Color.Gainsboro,
                    FontStyle.Regular);


            // ========================================================
            // SCENE
            // ========================================================

            Label lblSceneTitle =
                CreateLabel(
                    "Место:",
                    15,
                    42,
                    55,
                    Color.White,
                    FontStyle.Bold);


            Label lblScene =
                CreateLabel(
                    row["Scene"]
                        .ToString(),
                    75,
                    42,
                    690,
                    Color.Gainsboro,
                    FontStyle.Regular);


            // ========================================================
            // DESCRIPTION
            // ========================================================

            string description =
                row["Description"]
                    .ToString();


            if (description.Length > 115)
            {
                description =
                    description.Substring(
                        0,
                        112)
                    + "...";
            }


            Label lblDescriptionTitle =
                CreateLabel(
                    "Описание:",
                    15,
                    70,
                    75,
                    Color.White,
                    FontStyle.Bold);


            Label lblDescription =
                CreateLabel(
                    description,
                    95,
                    70,
                    665,
                    Color.Gainsboro,
                    FontStyle.Regular);


            card.Controls.Add(
                lblDate);

            card.Controls.Add(
                lblType);

            card.Controls.Add(
                lblRate);

            card.Controls.Add(
                lblSceneTitle);

            card.Controls.Add(
                lblScene);

            card.Controls.Add(
                lblDescriptionTitle);

            card.Controls.Add(
                lblDescription);


            return card;
        }


        // ============================================================
        // LABEL
        // ============================================================

        private Label CreateLabel(
            string text,
            int x,
            int y,
            int width,
            Color color,
            FontStyle style)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.Location =
                new Point(
                    x,
                    y);

            label.Size =
                new Size(
                    width,
                    22);

            label.ForeColor =
                color;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    style);

            label.AutoEllipsis =
                true;

            return label;
        }


        // ============================================================
        // EMPTY MESSAGE
        // ============================================================

        private void AddEmptyMessage(
            string text)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            label.AutoSize =
                true;

            label.Margin =
                new Padding(
                    20,
                    25,
                    0,
                    0);

            flpEvents.Controls.Add(
                label);
        }


        // ============================================================
        // PRINT
        // ============================================================

        private void BtnPrintJournal_Click(
            object sender,
            EventArgs e)
        {
            if (patrolServiceId <= 0)
            {
                MessageBox.Show(
                    "Журнал не выбран.",
                    "Печать",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            try
            {
                PatrolEventJournalPrintService service =
                    new PatrolEventJournalPrintService(
                        patrolServiceId,
                        squadNumber);

                service.GenerateAndPrint(
                    this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось выполнить печать журнала.\n\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}