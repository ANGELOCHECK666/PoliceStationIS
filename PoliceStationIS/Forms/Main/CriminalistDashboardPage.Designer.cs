using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class CriminalistDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picCriminalist;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlExpertises;
        private RoundedPanel pnlInspections;
        private RoundedPanel pnlEvidence;
        private RoundedPanel pnlCompletedExpertises;

        private Label lblExpertisesTitle;
        private Label lblExpertisesCount;
        private Label lblExpertisesUnit;

        private Label lblInspectionsTitle;
        private Label lblInspectionsCount;
        private Label lblInspectionsUnit;

        private Label lblEvidenceTitle;
        private Label lblEvidenceCount;
        private Label lblEvidenceUnit;

        private Label lblCompletedExpertisesTitle;
        private Label lblCompletedExpertisesCount;
        private Label lblCompletedExpertisesUnit;

        private PictureBox picExpertises;
        private PictureBox picInspections;
        private PictureBox picEvidence;
        private PictureBox picCompletedExpertises;

        // =====================================
        // RECENT EVENTS
        // =====================================

        private RoundedPanel pnlRecentEvents;

        private Label lblRecentEvents;

        private DataGridView dgvEvents;

        // =====================================
        // QUICK ACTIONS
        // =====================================

        private RoundedPanel pnlQuickActions;

        private Label lblQuickActions;

        private Button btnExpertises;
        private Button btnAddReport;
        private Button btnEvidence;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picExpertisesAction;
        private PictureBox picAddReport;
        private PictureBox picEvidenceAction;

        private PictureBox picArrowExpertises;
        private PictureBox picArrowReport;
        private PictureBox picArrowEvidence;

        private PictureBox picCriminalistSilhouette;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // =====================================
            // WELCOME PANEL
            // =====================================

            this.panelWelcome =
                new RoundedPanel();

            this.lblWelcome =
                new Label();

            this.lblPosition =
                new Label();

            this.lblDescription =
                new Label();

            this.picCriminalist =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlExpertises =
                new RoundedPanel();

            this.pnlInspections =
                new RoundedPanel();

            this.pnlEvidence =
                new RoundedPanel();

            this.pnlCompletedExpertises =
                new RoundedPanel();

            this.lblExpertisesTitle =
                new Label();

            this.lblExpertisesCount =
                new Label();

            this.lblExpertisesUnit =
                new Label();

            this.lblInspectionsTitle =
                new Label();

            this.lblInspectionsCount =
                new Label();

            this.lblInspectionsUnit =
                new Label();

            this.lblEvidenceTitle =
                new Label();

            this.lblEvidenceCount =
                new Label();

            this.lblEvidenceUnit =
                new Label();

            this.lblCompletedExpertisesTitle =
                new Label();

            this.lblCompletedExpertisesCount =
                new Label();

            this.lblCompletedExpertisesUnit =
                new Label();

            this.picExpertises =
                new PictureBox();

            this.picInspections =
                new PictureBox();

            this.picEvidence =
                new PictureBox();

            this.picCompletedExpertises =
                new PictureBox();

            this.SuspendLayout();

            // =====================================
            // USER CONTROL
            // =====================================

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.Dock =
                DockStyle.Fill;

            // =====================================
            // WELCOME PANEL
            // =====================================

            this.panelWelcome.BorderRadius = 25;

            this.panelWelcome.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.panelWelcome.Location =
                new Point(
                    30,
                    25);

            this.panelWelcome.Size =
                new Size(
                    1280,
                    230);

            // =====================================
            // WELCOME TEXT
            // =====================================

            this.lblWelcome.AutoSize = true;

            this.lblWelcome.ForeColor =
                Color.White;

            this.lblWelcome.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            this.lblWelcome.Location =
                new Point(
                    30,
                    30);

            this.lblWelcome.Text =
                "Добро пожаловать!";

            // =====================================

            this.lblPosition.AutoSize = true;

            this.lblPosition.ForeColor =
                Color.White;

            this.lblPosition.Font =
                new Font(
                    "Segoe UI",
                    14F);

            this.lblPosition.Location =
                new Point(
                    30,
                    85);

            this.lblPosition.Text =
                "Должность: Криминалист";

            // =====================================

            this.lblDescription.AutoSize = true;

            this.lblDescription.ForeColor =
                Color.White;

            this.lblDescription.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.lblDescription.Location =
                new Point(
                    30,
                    125);

            this.lblDescription.Text =
                "Проведение экспертиз, исследование вещественных доказательств и осмотр мест происшествия";

            // =====================================
            // IMAGE
            // =====================================

            this.picCriminalist.Image =
                global::PoliceStationIS.Properties.Resources.kriminalist_main_icon;

            this.picCriminalist.Location =
                new Point(
                    980,
                    10);

            this.picCriminalist.Size =
                new Size(
                    280,
                    210);

            this.picCriminalist.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picCriminalist.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlExpertises,
                30);

            ConfigureCard(
                this.pnlInspections,
                360);

            ConfigureCard(
                this.pnlEvidence,
                690);

            ConfigureCard(
                this.pnlCompletedExpertises,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picExpertises,
                Properties.Resources.criminalist_card_1);

            ConfigureCardTitle(
                this.lblExpertisesTitle,
                "Экспертиз в работе");

            ConfigureCardValue(
                this.lblExpertisesCount);

            ConfigureCardUnit(
                this.lblExpertisesUnit,
                "шт.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picInspections,
                Properties.Resources.criminalist_card_2);

            ConfigureCardTitle(
                this.lblInspectionsTitle,
                "Осмотров мест");

            ConfigureCardValue(
                this.lblInspectionsCount);

            ConfigureCardUnit(
                this.lblInspectionsUnit,
                "шт.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picEvidence,
                Properties.Resources.criminalist_card_3);

            ConfigureCardTitle(
                this.lblEvidenceTitle,
                "Доказательств");

            ConfigureCardValue(
                this.lblEvidenceCount);

            ConfigureCardUnit(
                this.lblEvidenceUnit,
                "шт.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picCompletedExpertises,
                Properties.Resources.criminalist_card_4);

            ConfigureCardTitle(
                this.lblCompletedExpertisesTitle,
                "Завершено экспертиз");

            ConfigureCardValue(
                this.lblCompletedExpertisesCount);

            ConfigureCardUnit(
                this.lblCompletedExpertisesUnit,
                "шт.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlExpertises.Controls.Add(
                this.picExpertises);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesTitle);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesCount);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesUnit);

            // -------------------------------------

            this.pnlInspections.Controls.Add(
                this.picInspections);

            this.pnlInspections.Controls.Add(
                this.lblInspectionsTitle);

            this.pnlInspections.Controls.Add(
                this.lblInspectionsCount);

            this.pnlInspections.Controls.Add(
                this.lblInspectionsUnit);

            // -------------------------------------

            this.pnlEvidence.Controls.Add(
                this.picEvidence);

            this.pnlEvidence.Controls.Add(
                this.lblEvidenceTitle);

            this.pnlEvidence.Controls.Add(
                this.lblEvidenceCount);

            this.pnlEvidence.Controls.Add(
                this.lblEvidenceUnit);

            // -------------------------------------

            this.pnlCompletedExpertises.Controls.Add(
                this.picCompletedExpertises);

            this.pnlCompletedExpertises.Controls.Add(
                this.lblCompletedExpertisesTitle);

            this.pnlCompletedExpertises.Controls.Add(
                this.lblCompletedExpertisesCount);

            this.pnlCompletedExpertises.Controls.Add(
                this.lblCompletedExpertisesUnit);

            // =====================================
            // WELCOME PANEL CONTROLS
            // =====================================

            this.panelWelcome.Controls.Add(
                this.lblWelcome);

            this.panelWelcome.Controls.Add(
                this.lblPosition);

            this.panelWelcome.Controls.Add(
                this.lblDescription);

            this.panelWelcome.Controls.Add(
                this.picCriminalist);

            // =====================================
            // RECENT EVENTS PANEL
            // =====================================

            this.pnlRecentEvents =
                new RoundedPanel();

            this.pnlRecentEvents.BorderRadius = 18;

            this.pnlRecentEvents.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.pnlRecentEvents.Location =
                new Point(
                    30,
                    430);

            this.pnlRecentEvents.Size =
                new Size(
                    780,
                    380);

            // =====================================

            this.lblRecentEvents =
                new Label();

            this.lblRecentEvents.AutoSize = true;

            this.lblRecentEvents.ForeColor =
                Color.White;

            this.lblRecentEvents.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblRecentEvents.Location =
                new Point(
                    20,
                    15);

            this.lblRecentEvents.Text =
                "Последние события";

            // =====================================
            // GRID
            // =====================================

            this.dgvEvents =
                new DataGridView();

            this.dgvEvents.Location =
                new Point(
                    20,
                    50);

            this.dgvEvents.Size =
                new Size(
                    740,
                    300);

            this.dgvEvents.BackgroundColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvEvents.BorderStyle =
                BorderStyle.None;

            this.dgvEvents.RowHeadersVisible = false;

            this.dgvEvents.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvEvents.AdvancedCellBorderStyle.Left =
                DataGridViewAdvancedCellBorderStyle.None;

            this.dgvEvents.AdvancedCellBorderStyle.Right =
                DataGridViewAdvancedCellBorderStyle.None;

            this.dgvEvents.RowTemplate.Height = 42;

            this.dgvEvents.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            this.dgvEvents.AllowUserToAddRows = false;

            this.dgvEvents.AllowUserToDeleteRows = false;

            this.dgvEvents.AllowUserToResizeRows = false;

            this.dgvEvents.ReadOnly = true;

            this.dgvEvents.MultiSelect = false;

            this.dgvEvents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvEvents.EnableHeadersVisualStyles =
                false;

            this.dgvEvents.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    35,
                    60,
                    110);

            // =====================================
            // HEADER
            // =====================================

            this.dgvEvents.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    35,
                    60,
                    110);

            this.dgvEvents.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            this.dgvEvents.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.dgvEvents.ColumnHeadersHeight = 40;

            // =====================================
            // CELLS
            // =====================================

            this.dgvEvents.DefaultCellStyle.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvEvents.DefaultCellStyle.ForeColor =
                Color.White;

            this.dgvEvents.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvEvents.DefaultCellStyle.SelectionForeColor =
                Color.White;

            this.dgvEvents.GridColor =
                Color.FromArgb(
                    60,
                    80,
                    120);

            // =====================================
            // COLUMNS
            // =====================================

            this.dgvEvents.Columns.Add(
                "Date",
                "Дата");

            this.dgvEvents.Columns.Add(
                "Time",
                "Время");

            this.dgvEvents.Columns.Add(
                "Event",
                "Событие");

            this.dgvEvents.Columns.Add(
                "Expertise",
                "Экспертиза");

            this.dgvEvents.Columns[0].Width = 110;
            this.dgvEvents.Columns[1].Width = 90;
            this.dgvEvents.Columns[2].Width = 220;
            this.dgvEvents.Columns[3].Width = 300;

            // =====================================

            this.pnlRecentEvents.Controls.Add(
                this.lblRecentEvents);

            this.pnlRecentEvents.Controls.Add(
                this.dgvEvents);

            // =====================================
            // QUICK ACTIONS PANEL
            // =====================================

            this.pnlQuickActions =
                new RoundedPanel();

            this.pnlQuickActions.BorderRadius = 18;

            this.pnlQuickActions.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.pnlQuickActions.Location =
                new Point(
                    840,
                    430);

            this.pnlQuickActions.Size =
                new Size(
                    470,
                    380);

            // =====================================

            this.lblQuickActions =
                new Label();

            this.lblQuickActions.AutoSize = true;

            this.lblQuickActions.ForeColor =
                Color.White;

            this.lblQuickActions.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblQuickActions.Location =
                new Point(
                    20,
                    15);

            this.lblQuickActions.Text =
                "Быстрые действия";

            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.lblQuickActions);

            // =====================================
            // BUTTONS
            // =====================================

            this.btnExpertises =
                new Button();

            this.btnAddReport =
                new Button();

            this.btnEvidence =
                new Button();

            this.picExpertisesAction =
                new PictureBox();

            this.picAddReport =
                new PictureBox();

            this.picEvidenceAction =
                new PictureBox();

            this.picArrowExpertises =
                new PictureBox();

            this.picArrowReport =
                new PictureBox();

            this.picArrowEvidence =
                new PictureBox();

            this.picCriminalistSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnExpertises,
                "Назначенные экспертизы",
                50);

            ConfigureActionButton(
                this.btnAddReport,
                "Добавить заключение",
                125);

            ConfigureActionButton(
                this.btnEvidence,
                "Вещественные доказательства",
                200);

            // =====================================
            // ICONS
            // =====================================

            ConfigureActionIcon(
                this.picExpertisesAction,
                Properties.Resources.expertise_list_gold_icon,
                50);

            ConfigureActionIcon(
                this.picAddReport,
                Properties.Resources.expertise_report_gold_icon,
                125);

            ConfigureActionIcon(
                this.picEvidenceAction,
                Properties.Resources.evidence_gold_icon,
                200);

            // =====================================
            // ARROWS
            // =====================================

            ConfigureArrowIcon(
                this.picArrowExpertises,
                50);

            ConfigureArrowIcon(
                this.picArrowReport,
                125);

            ConfigureArrowIcon(
                this.picArrowEvidence,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnExpertises);

            this.pnlQuickActions.Controls.Add(
                this.picExpertisesAction);

            this.pnlQuickActions.Controls.Add(
                this.picAddReport);

            this.pnlQuickActions.Controls.Add(
                this.picEvidenceAction);

            this.picExpertisesAction.BringToFront();
            this.picAddReport.BringToFront();
            this.picEvidenceAction.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnAddReport);

            this.pnlQuickActions.Controls.Add(
                this.btnEvidence);

            this.pnlQuickActions.Controls.Add(
                this.picArrowExpertises);

            this.pnlQuickActions.Controls.Add(
                this.picArrowReport);

            this.pnlQuickActions.Controls.Add(
                this.picArrowEvidence);

            this.picArrowExpertises.BringToFront();
            this.picArrowReport.BringToFront();
            this.picArrowEvidence.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picCriminalistSilhouette);

            this.picCriminalistSilhouette.SendToBack();

            // =====================================
            // CRIMINALIST IMAGE
            // =====================================

            this.picCriminalistSilhouette.Image =
                Properties.Resources.criminalist_silhouette_gold;

            this.picCriminalistSilhouette.BackColor =
                Color.Transparent;

            this.picCriminalistSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picCriminalistSilhouette.Location =
                new Point(
                    145,
                    250);

            this.picCriminalistSilhouette.Size =
                new Size(
                    160,
                    150);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlExpertises);

            this.Controls.Add(
                this.pnlInspections);

            this.Controls.Add(
                this.pnlEvidence);

            this.Controls.Add(
                this.pnlCompletedExpertises);

            this.Controls.Add(
                this.pnlRecentEvents);

            this.Controls.Add(
                this.pnlQuickActions);

            this.ResumeLayout(false);
        }

                    // =====================================
                    // CARD METHODS
                    // =====================================

        private void ConfigureCard(
            RoundedPanel panel,
            int x)
        {
            panel.BorderRadius = 18;

            panel.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            panel.Location =
                new Point(
                    x,
                    280);

            panel.Size =
                new Size(
                    290,
                    110);
        }

        private void ConfigureCardTitle(
            Label label,
            string text)
        {
            label.AutoSize = true;

            label.ForeColor =
                Color.White;

            label.Font =
                new Font(
                    "Segoe UI",
                    10F);

            label.Location =
                new Point(
                    95,
                    18);

            label.Text = text;
        }

        private void ConfigureCardValue(
            Label label)
        {
            label.AutoSize = true;

            label.ForeColor =
                Color.White;

            label.Font =
                new Font(
                    "Segoe UI",
                    24F,
                    FontStyle.Bold);

            label.Location =
                new Point(
                    95,
                    42);

            label.Text = "0";
        }

        private void ConfigureCardUnit(
            Label label,
            string text)
        {
            label.AutoSize = true;

            label.ForeColor =
                Color.White;

            label.Font =
                new Font(
                    "Segoe UI",
                    11F);

            label.Location =
                new Point(
                    190,
                    62);

            label.Text = text;
        }

        private void ConfigureCardIcon(
            PictureBox picture,
            Image image)
        {
            picture.Image = image;

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            picture.BackColor =
                Color.Transparent;

            picture.Location =
                new Point(
                    15,
                    22);

            picture.Size =
                new Size(
                    70,
                    70);
        }

        // =====================================
        // BUTTON METHODS
        // =====================================

        private void ConfigureActionButton(
            Button button,
            string text,
            int y)
        {
            button.Text = text;

            button.Location =
                new Point(
                    20,
                    y);

            button.Size =
                new Size(
                    420,
                    64);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 0;

            button.BackColor =
                Color.FromArgb(
                    40,
                    70,
                    120);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Regular);

            button.TextAlign =
                ContentAlignment.MiddleLeft;

            button.Padding =
                new Padding(
                    70,
                    0,
                    30,
                    0);

            button.Cursor =
                Cursors.Hand;
        }

        private void ConfigureActionIcon(
            PictureBox picture,
            Image image,
            int y)
        {
            picture.Image = image;

            picture.BackColor =
                Color.FromArgb(
                    40,
                    70,
                    120);

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            picture.Location =
                new Point(
                    28,
                    y + 12);

            picture.Size =
                new Size(
                    40,
                    40);
        }

        private void ConfigureArrowIcon(
            PictureBox picture,
            int y)
        {
            picture.Image =
                Properties.Resources.arrow_gold_icon;

            picture.BackColor =
                Color.FromArgb(
                    40,
                    70,
                    120);

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            picture.Location =
                new Point(
                    410,
                    y + 22);

            picture.Size =
                new Size(
                    20,
                    20);
        }

        #endregion
    }
}