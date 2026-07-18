using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class DepartmentChiefDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picChief;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlEmployees;
        private RoundedPanel pnlCases;
        private RoundedPanel pnlExpertises;
        private RoundedPanel pnlPatrols;

        private Label lblEmployeesTitle;
        private Label lblEmployeesCount;
        private Label lblEmployeesUnit;

        private Label lblCasesTitle;
        private Label lblCasesCount;
        private Label lblCasesUnit;

        private Label lblExpertisesTitle;
        private Label lblExpertisesCount;
        private Label lblExpertisesUnit;

        private Label lblPatrolsTitle;
        private Label lblPatrolsCount;
        private Label lblPatrolsUnit;

        private PictureBox picEmployees;
        private PictureBox picCases;
        private PictureBox picExpertises;
        private PictureBox picPatrols;

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

        private Button btnAssignExpertise;
        private Button btnCreatePatrol;
        private Button btnCreateCase;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picAssignExpertise;
        private PictureBox picCreatePatrol;
        private PictureBox picCreateCase;

        private PictureBox picArrowExpertise;
        private PictureBox picArrowPatrol;
        private PictureBox picArrowCase;

        private PictureBox picChiefSilhouette;

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

            this.picChief =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlEmployees =
                new RoundedPanel();

            this.pnlCases =
                new RoundedPanel();

            this.pnlExpertises =
                new RoundedPanel();

            this.pnlPatrols =
                new RoundedPanel();

            this.lblEmployeesTitle =
                new Label();

            this.lblEmployeesCount =
                new Label();

            this.lblEmployeesUnit =
                new Label();

            this.lblCasesTitle =
                new Label();

            this.lblCasesCount =
                new Label();

            this.lblCasesUnit =
                new Label();

            this.lblExpertisesTitle =
                new Label();

            this.lblExpertisesCount =
                new Label();

            this.lblExpertisesUnit =
                new Label();

            this.lblPatrolsTitle =
                new Label();

            this.lblPatrolsCount =
                new Label();

            this.lblPatrolsUnit =
                new Label();

            this.picEmployees =
                new PictureBox();

            this.picCases =
                new PictureBox();

            this.picExpertises =
                new PictureBox();

            this.picPatrols =
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
                "Должность: Начальник отдела";

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
                "Управление подразделением и контроль оперативной деятельности";

            // =====================================
            // IMAGE
            // =====================================

            this.picChief.Image =
                global::PoliceStationIS.Properties.Resources.nachalnik_main_icon;

            this.picChief.Location =
                new Point(
                    980,
                    0);

            this.picChief.Size =
                new Size(
                    280,
                    230);

            this.picChief.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picChief.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlEmployees,
                30);

            ConfigureCard(
                this.pnlCases,
                360);

            ConfigureCard(
                this.pnlExpertises,
                690);

            ConfigureCard(
                this.pnlPatrols,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picEmployees,
                Properties.Resources.employees_icon);

            ConfigureCardTitle(
                this.lblEmployeesTitle,
                "Сотрудников");

            ConfigureCardValue(
                this.lblEmployeesCount);

            ConfigureCardUnit(
    this.lblEmployeesUnit,
    "чел.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picCases,
                Properties.Resources.case_card_1);

            ConfigureCardTitle(
                this.lblCasesTitle,
                "Уголовных дел");

            ConfigureCardValue(
                this.lblCasesCount);

            ConfigureCardUnit(
    this.lblCasesUnit,
    "шт.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picExpertises,
                Properties.Resources.case_card_2);

            ConfigureCardTitle(
                this.lblExpertisesTitle,
                "Экспертиз в работе");

            ConfigureCardValue(
                this.lblExpertisesCount);

            ConfigureCardUnit(
    this.lblExpertisesUnit,
    "шт.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picPatrols,
                Properties.Resources.nachal_card_4);

            ConfigureCardTitle(
                this.lblPatrolsTitle,
                "Нарядов сегодня");

            ConfigureCardValue(
                this.lblPatrolsCount);

            ConfigureCardUnit(
    this.lblPatrolsUnit,
    "шт.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlEmployees.Controls.Add(
                this.picEmployees);

            this.pnlEmployees.Controls.Add(
                this.lblEmployeesTitle);

            this.pnlEmployees.Controls.Add(
                this.lblEmployeesCount);

            this.pnlEmployees.Controls.Add(
                this.lblEmployeesUnit);

            // -------------------------------------

            this.pnlCases.Controls.Add(
                this.picCases);

            this.pnlCases.Controls.Add(
                this.lblCasesTitle);

            this.pnlCases.Controls.Add(
                this.lblCasesCount);

            this.pnlCases.Controls.Add(
                this.lblCasesUnit);

            // -------------------------------------

            this.pnlExpertises.Controls.Add(
                this.picExpertises);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesTitle);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesCount);

            this.pnlExpertises.Controls.Add(
                this.lblExpertisesUnit);

            // -------------------------------------

            this.pnlPatrols.Controls.Add(
                this.picPatrols);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsTitle);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsCount);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsUnit);

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
                this.picChief);

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
                "Object",
                "Объект");

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

            this.pnlQuickActions.Controls.Add(
                this.lblQuickActions);

            // =====================================
            // BUTTONS
            // =====================================

            this.btnAssignExpertise =
                new Button();

            this.btnCreatePatrol =
                new Button();

            this.btnCreateCase =
                new Button();

            this.picAssignExpertise =
                new PictureBox();

            this.picCreatePatrol =
                new PictureBox();

            this.picCreateCase =
                new PictureBox();

            this.picArrowExpertise =
                new PictureBox();

            this.picArrowPatrol =
                new PictureBox();

            this.picArrowCase =
                new PictureBox();

            this.picChiefSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnAssignExpertise,
                "Назначить экспертизу",
                50);

            ConfigureActionButton(
                this.btnCreatePatrol,
                "Оформить наряд",
                125);

            ConfigureActionButton(
                this.btnCreateCase,
                "Создать дело",
                200);

            ConfigureActionIcon(
                this.picAssignExpertise,
                Properties.Resources.expertise_gold,
                50);

            ConfigureActionIcon(
                this.picCreatePatrol,
                Properties.Resources.oform_naryd,
                125);

            ConfigureActionIcon(
                this.picCreateCase,
                Properties.Resources.case_add_gold_icon,
                200);

            ConfigureArrowIcon(
                this.picArrowExpertise,
                50);

            ConfigureArrowIcon(
                this.picArrowPatrol,
                125);

            ConfigureArrowIcon(
                this.picArrowCase,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnAssignExpertise);

            this.pnlQuickActions.Controls.Add(
                this.picAssignExpertise);

            this.pnlQuickActions.Controls.Add(
                this.picCreatePatrol);

            this.pnlQuickActions.Controls.Add(
                this.picCreateCase);

            this.picAssignExpertise.BringToFront();
            this.picCreatePatrol.BringToFront();
            this.picCreateCase.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnCreatePatrol);

            this.pnlQuickActions.Controls.Add(
                this.btnCreateCase);

            this.pnlQuickActions.Controls.Add(
                this.picArrowExpertise);

            this.pnlQuickActions.Controls.Add(
                this.picArrowPatrol);

            this.pnlQuickActions.Controls.Add(
                this.picArrowCase);

            this.picArrowExpertise.BringToFront();
            this.picArrowPatrol.BringToFront();
            this.picArrowCase.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picChiefSilhouette);

            this.picChiefSilhouette.SendToBack();

            // =====================================
            // CHIEF IMAGE
            // =====================================

            this.picChiefSilhouette.Image =
                Properties.Resources.nachal_1;

            this.picChiefSilhouette.BackColor =
                Color.Transparent;

            this.picChiefSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picChiefSilhouette.Location =
                new Point(
                    145,
                    265);

            this.picChiefSilhouette.Size =
                new Size(
                    170,
                    115);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlEmployees);

            this.Controls.Add(
                this.pnlCases);

            this.Controls.Add(
                this.pnlExpertises);

            this.Controls.Add(
                this.pnlPatrols);

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
        // ACTION BUTTON
        // =====================================

        private void ConfigureActionButton(
            Button button,
            string text,
            int y)
        {
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

            button.Location =
                new Point(
                    20,
                    y);

            button.Size =
                new Size(
                    420,
                    64);

            button.Text = text;

            button.Cursor =
                Cursors.Hand;
        }

        // =====================================

        private void ConfigureActionIcon(
            PictureBox picture,
            Image image,
            int y)
        {
            picture.Image = image;

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            picture.BackColor =
                Color.FromArgb(
                    40,
                    70,
                    120);

            picture.Location =
                new Point(
                    28,
                    y + 12);

            picture.Size =
                new Size(
                    40,
                    40);
        }

        // =====================================

        private void ConfigureArrowIcon(
            PictureBox picture,
            int y)
        {
            picture.Image =
                Properties.Resources.arrow_gold_icon;

            picture.SizeMode =
                PictureBoxSizeMode.Zoom;

            picture.BackColor =
                Color.FromArgb(
                    40,
                    70,
                    120);

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