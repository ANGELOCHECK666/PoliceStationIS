using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class CriminalistDashboardPage : UserControl
    {
        public CriminalistDashboardPage()
        {
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

        private void LoadStatistics()
        {
            lblExpertisesCount.Text = "14";
            lblInspectionsCount.Text = "38";
            lblEvidenceCount.Text = "21";
            lblCompletedExpertisesCount.Text = "156";
        }

        // =====================================
        // RECENT EVENTS
        // =====================================

        private void LoadRecentEvents()
        {
            dgvEvents.Rows.Clear();

            dgvEvents.Rows.Add(
                "18.07.2026",
                "09:15",
                "Назначена экспертиза",
                "ЭК-1025");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "10:40",
                "Добавлено доказательство",
                "ЭК-1021");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "12:05",
                "Завершена экспертиза",
                "ЭК-1018");

            dgvEvents.Rows.Add(
                "17.07.2026",
                "16:20",
                "Осмотр места происшествия",
                "ЭК-1016");

            dgvEvents.Rows.Add(
                "17.07.2026",
                "18:00",
                "Переданы материалы следователю",
                "ЭК-1014");
        }

        // =====================================
        // BUTTONS
        // =====================================

        private void BtnExpertises_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Здесь будет открываться список назначенных экспертиз.",
                "Криминалист",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnAddReport_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Здесь будет открываться форма добавления экспертного заключения.",
                "Криминалист",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnEvidence_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Здесь будет открываться список вещественных доказательств.",
                "Криминалист",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}