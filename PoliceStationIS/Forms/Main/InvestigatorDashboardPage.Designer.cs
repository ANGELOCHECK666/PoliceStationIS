using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class InvestigatorDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picInvestigator;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlMyCases;
        private RoundedPanel pnlActiveCases;
        private RoundedPanel pnlProtocols;
        private RoundedPanel pnlExpertises;

        private Label lblMyCasesTitle;
        private Label lblMyCasesCount;
        private Label lblMyCasesUnit;

        private Label lblActiveCasesTitle;
        private Label lblActiveCasesCount;
        private Label lblActiveCasesUnit;

        private Label lblProtocolsTitle;
        private Label lblProtocolsCount;
        private Label lblProtocolsUnit;

        private Label lblExpertisesTitle;
        private Label lblExpertisesCount;
        private Label lblExpertisesUnit;

        private PictureBox picMyCases;
        private PictureBox picActiveCases;
        private PictureBox picProtocols;
        private PictureBox picExpertises;

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

        private Button btnCreateCase;
        private Button btnAddCitizen;
        private Button btnCreateProtocol;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picCreateCase;
        private PictureBox picAddCitizen;
        private PictureBox picCreateProtocol;

        private PictureBox picArrowCase;
        private PictureBox picArrowCitizen;
        private PictureBox picArrowProtocol;

        private PictureBox picInvestigatorSilhouette;

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

            this.picInvestigator =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlMyCases =
                new RoundedPanel();

            this.pnlActiveCases =
                new RoundedPanel();

            this.pnlProtocols =
                new RoundedPanel();

            this.pnlExpertises =
                new RoundedPanel();

            this.lblMyCasesTitle =
                new Label();

            this.lblMyCasesCount =
                new Label();

            this.lblMyCasesUnit =
                new Label();

            this.lblActiveCasesTitle =
                new Label();

            this.lblActiveCasesCount =
                new Label();

            this.lblActiveCasesUnit =
                new Label();

            this.lblProtocolsTitle =
                new Label();

            this.lblProtocolsCount =
                new Label();

            this.lblProtocolsUnit =
                new Label();

            this.lblExpertisesTitle =
                new Label();

            this.lblExpertisesCount =
                new Label();

            this.lblExpertisesUnit =
                new Label();

            this.picMyCases =
                new PictureBox();

            this.picActiveCases =
                new PictureBox();

            this.picProtocols =
                new PictureBox();

            this.picExpertises =
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
                "Должность: Следователь";

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
                "Работа с уголовными делами, протоколами и экспертизами";

            // =====================================
            // IMAGE
            // =====================================

            this.picInvestigator.Image =
                global::PoliceStationIS.Properties.Resources.sledovatel_main_icon;

            this.picInvestigator.Location =
                new Point(
                    980,
                    0);

            this.picInvestigator.Size =
                new Size(
                    290,
                    240);

            this.picInvestigator.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picInvestigator.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlMyCases,
                30);

            ConfigureCard(
                this.pnlActiveCases,
                360);

            ConfigureCard(
                this.pnlProtocols,
                690);

            ConfigureCard(
                this.pnlExpertises,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picMyCases,
                Properties.Resources.case_card_1);

            ConfigureCardTitle(
                this.lblMyCasesTitle,
                "Моих дел");

            ConfigureCardValue(
                this.lblMyCasesCount);

            ConfigureCardUnit(
                this.lblMyCasesUnit,
                "шт.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picActiveCases,
                Properties.Resources.case_card_2);

            ConfigureCardTitle(
                this.lblActiveCasesTitle,
                "Активных дел");

            ConfigureCardValue(
                this.lblActiveCasesCount);

            ConfigureCardUnit(
                this.lblActiveCasesUnit,
                "шт.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picProtocols,
                Properties.Resources.case_card_3);

            ConfigureCardTitle(
                this.lblProtocolsTitle,
                "Протоколов");

            ConfigureCardValue(
                this.lblProtocolsCount);

            ConfigureCardUnit(
                this.lblProtocolsUnit,
                "шт.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picExpertises,
                Properties.Resources.case_card_4);

            ConfigureCardTitle(
                this.lblExpertisesTitle,
                "Назначенных экспертиз");

            ConfigureCardValue(
                this.lblExpertisesCount);

            ConfigureCardUnit(
                this.lblExpertisesUnit,
                "шт.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlMyCases.Controls.Add(
                this.picMyCases);

            this.pnlMyCases.Controls.Add(
                this.lblMyCasesTitle);

            this.pnlMyCases.Controls.Add(
                this.lblMyCasesCount);

            this.pnlMyCases.Controls.Add(
                this.lblMyCasesUnit);

            // -------------------------------------

            this.pnlActiveCases.Controls.Add(
                this.picActiveCases);

            this.pnlActiveCases.Controls.Add(
                this.lblActiveCasesTitle);

            this.pnlActiveCases.Controls.Add(
                this.lblActiveCasesCount);

            this.pnlActiveCases.Controls.Add(
                this.lblActiveCasesUnit);

            // -------------------------------------

            this.pnlProtocols.Controls.Add(
                this.picProtocols);

            this.pnlProtocols.Controls.Add(
                this.lblProtocolsTitle);

            this.pnlProtocols.Controls.Add(
                this.lblProtocolsCount);

            this.pnlProtocols.Controls.Add(
                this.lblProtocolsUnit);

            // -------------------------------------

            this.pnlExpertises.Controls.Add(
                this.picExpertises);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesTitle);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesCount);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesUnit);

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
                this.picInvestigator);

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
                "Case",
                "Уголовное дело");

            this.dgvEvents.Columns[0].Width = 110;
            this.dgvEvents.Columns[1].Width = 90;
            this.dgvEvents.Columns[2].Width = 260;
            this.dgvEvents.Columns[3].Width = 260;

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

            this.pnlQuickActions.Controls.Add(
                this.lblQuickActions);

            // =====================================
            // BUTTONS
            // =====================================

            this.btnCreateCase =
                new Button();

            this.btnAddCitizen =
                new Button();

            this.btnCreateProtocol =
                new Button();

            this.picCreateCase =
                new PictureBox();

            this.picAddCitizen =
                new PictureBox();

            this.picCreateProtocol =
                new PictureBox();

            this.picArrowCase =
                new PictureBox();

            this.picArrowCitizen =
                new PictureBox();

            this.picArrowProtocol =
                new PictureBox();

            this.picInvestigatorSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnCreateCase,
                "Создать дело",
                50);

            ConfigureActionButton(
                this.btnAddCitizen,
                "Добавить гражданина",
                125);

            ConfigureActionButton(
                this.btnCreateProtocol,
                "Составить протокол",
                200);

            ConfigureActionIcon(
                this.picCreateCase,
                Properties.Resources.case_add_gold_icon,
                50);

            ConfigureActionIcon(
                this.picAddCitizen,
                Properties.Resources.citizen_add_gold_icon,
                125);

            ConfigureActionIcon(
                this.picCreateProtocol,
                Properties.Resources.protocol_add_gold_icon,
                200);

            ConfigureArrowIcon(
                this.picArrowCase,
                50);

            ConfigureArrowIcon(
                this.picArrowCitizen,
                125);

            ConfigureArrowIcon(
                this.picArrowProtocol,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnCreateCase);

            this.pnlQuickActions.Controls.Add(
                this.picCreateCase);

            this.pnlQuickActions.Controls.Add(
                this.picAddCitizen);

            this.pnlQuickActions.Controls.Add(
                this.picCreateProtocol);

            this.picCreateCase.BringToFront();
            this.picAddCitizen.BringToFront();
            this.picCreateProtocol.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnAddCitizen);

            this.pnlQuickActions.Controls.Add(
                this.btnCreateProtocol);

            this.pnlQuickActions.Controls.Add(
                this.picArrowCase);

            this.pnlQuickActions.Controls.Add(
                this.picArrowCitizen);

            this.pnlQuickActions.Controls.Add(
                this.picArrowProtocol);

            this.picArrowCase.BringToFront();
            this.picArrowCitizen.BringToFront();
            this.picArrowProtocol.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picInvestigatorSilhouette);

            this.picInvestigatorSilhouette.SendToBack();

            // =====================================
            // INVESTIGATOR IMAGE
            // =====================================

            this.picInvestigatorSilhouette.Image =
                Properties.Resources.investigator_silhouette_gold;

            this.picInvestigatorSilhouette.BackColor =
                Color.Transparent;

            this.picInvestigatorSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picInvestigatorSilhouette.Location =
                new Point(
                    155,
                    240);

            this.picInvestigatorSilhouette.Size =
                new Size(
                    135,
                    155);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlMyCases);

            this.Controls.Add(
                this.pnlActiveCases);

            this.Controls.Add(
                this.pnlProtocols);

            this.Controls.Add(
                this.pnlExpertises);

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
            Label label)
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

            label.Text = "шт.";
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