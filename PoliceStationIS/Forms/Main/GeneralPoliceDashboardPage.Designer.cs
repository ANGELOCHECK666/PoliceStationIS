using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class GeneralPoliceDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picGeneral;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlEmployees;
        private RoundedPanel pnlCases;
        private RoundedPanel pnlPatrols;
        private RoundedPanel pnlDepartments;

        private Label lblEmployeesTitle;
        private Label lblEmployeesCount;
        private Label lblEmployeesUnit;

        private Label lblCasesTitle;
        private Label lblCasesCount;
        private Label lblCasesUnit;

        private Label lblPatrolsTitle;
        private Label lblPatrolsCount;
        private Label lblPatrolsUnit;

        private Label lblDepartmentsTitle;
        private Label lblDepartmentsCount;
        private Label lblDepartmentsUnit;

        private PictureBox picEmployees;
        private PictureBox picCases;
        private PictureBox picPatrols;
        private PictureBox picDepartments;

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

        private Button btnReports;
        private Button btnStatistics;
        private Button btnDepartments;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picReports;
        private PictureBox picStatistics;
        private PictureBox picDepartmentsAction;

        private PictureBox picArrowReports;
        private PictureBox picArrowStatistics;
        private PictureBox picArrowDepartments;

        private PictureBox picGeneralSilhouette;

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

            this.picGeneral =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlEmployees =
                new RoundedPanel();

            this.pnlCases =
                new RoundedPanel();

            this.pnlPatrols =
                new RoundedPanel();

            this.pnlDepartments =
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

            this.lblPatrolsTitle =
                new Label();

            this.lblPatrolsCount =
                new Label();

            this.lblPatrolsUnit =
                new Label();

            this.lblDepartmentsTitle =
                new Label();

            this.lblDepartmentsCount =
                new Label();

            this.lblDepartmentsUnit =
                new Label();

            this.picEmployees =
                new PictureBox();

            this.picCases =
                new PictureBox();

            this.picPatrols =
                new PictureBox();

            this.picDepartments =
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
                "Должность: Генерал полиции";

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
                "Общий контроль подразделений, статистики и деятельности полиции";

            // =====================================
            // IMAGE
            // =====================================

            this.picGeneral.Image =
                global::PoliceStationIS.Properties.Resources.general_main_icon;

            this.picGeneral.Location =
                new Point(
                    980,
                    10);

            this.picGeneral.Size =
                new Size(
                    290,
                    240);

            this.picGeneral.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picGeneral.BackColor =
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
                this.pnlPatrols,
                690);

            ConfigureCard(
                this.pnlDepartments,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picEmployees,
                Properties.Resources.general_card_1);

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
                Properties.Resources.general_card_2);

            ConfigureCardTitle(
                this.lblCasesTitle,
                "Активных дел");

            ConfigureCardValue(
                this.lblCasesCount);

            ConfigureCardUnit(
                this.lblCasesUnit,
                "шт.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picPatrols,
                Properties.Resources.general_card_3);

            ConfigureCardTitle(
                this.lblPatrolsTitle,
                "Нарядов сегодня");

            ConfigureCardValue(
                this.lblPatrolsCount);

            ConfigureCardUnit(
                this.lblPatrolsUnit,
                "шт.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picDepartments,
                Properties.Resources.general_card_4);

            ConfigureCardTitle(
                this.lblDepartmentsTitle,
                "Подразделений");

            ConfigureCardValue(
                this.lblDepartmentsCount);

            ConfigureCardUnit(
                this.lblDepartmentsUnit,
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

            this.pnlPatrols.Controls.Add(
                this.picPatrols);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsTitle);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsCount);

            this.pnlPatrols.Controls.Add(
                this.lblPatrolsUnit);

            // -------------------------------------

            this.pnlDepartments.Controls.Add(
                this.picDepartments);

            this.pnlDepartments.Controls.Add(
                this.lblDepartmentsTitle);

            this.pnlDepartments.Controls.Add(
                this.lblDepartmentsCount);

            this.pnlDepartments.Controls.Add(
                this.lblDepartmentsUnit);

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
                this.picGeneral);

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
                "Department",
                "Подразделение");

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

            this.btnReports =
                new Button();

            this.btnStatistics =
                new Button();

            this.btnDepartments =
                new Button();

            this.picReports =
                new PictureBox();

            this.picStatistics =
                new PictureBox();

            this.picDepartmentsAction =
                new PictureBox();

            this.picArrowReports =
                new PictureBox();

            this.picArrowStatistics =
                new PictureBox();

            this.picArrowDepartments =
                new PictureBox();

            this.picGeneralSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnReports,
                "Просмотреть сотрудников",
                50);

            ConfigureActionButton(
                this.btnStatistics,
                "Просмотреть статистику",
                125);

            ConfigureActionButton(
                this.btnDepartments,
                "Контроль подразделений",
                200);

            // =====================================
            // ICONS
            // =====================================

            ConfigureActionIcon(
                this.picReports,
                Properties.Resources.reportss_gold_icon,
                50);

            ConfigureActionIcon(
                this.picStatistics,
                Properties.Resources.statistics_gold_icon,
                125);

            ConfigureActionIcon(
                this.picDepartmentsAction,
                Properties.Resources.departments_gold_icon,
                200);

            // =====================================
            // ARROWS
            // =====================================

            ConfigureArrowIcon(
                this.picArrowReports,
                50);

            ConfigureArrowIcon(
                this.picArrowStatistics,
                125);

            ConfigureArrowIcon(
                this.picArrowDepartments,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnReports);

            this.pnlQuickActions.Controls.Add(
                this.picReports);

            this.pnlQuickActions.Controls.Add(
                this.picStatistics);

            this.pnlQuickActions.Controls.Add(
                this.picDepartmentsAction);

            this.picReports.BringToFront();
            this.picStatistics.BringToFront();
            this.picDepartmentsAction.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnStatistics);

            this.pnlQuickActions.Controls.Add(
                this.btnDepartments);

            this.pnlQuickActions.Controls.Add(
                this.picArrowReports);

            this.pnlQuickActions.Controls.Add(
                this.picArrowStatistics);

            this.pnlQuickActions.Controls.Add(
                this.picArrowDepartments);

            this.picArrowReports.BringToFront();
            this.picArrowStatistics.BringToFront();
            this.picArrowDepartments.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picGeneralSilhouette);

            this.picGeneralSilhouette.SendToBack();

            // =====================================
            // GENERAL IMAGE
            // =====================================

            this.picGeneralSilhouette.Image =
                Properties.Resources.general_silhouette_gold;

            this.picGeneralSilhouette.BackColor =
                Color.Transparent;

            this.picGeneralSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picGeneralSilhouette.Location =
                new Point(
                    150,
                    260);

            this.picGeneralSilhouette.Size =
                new Size(
                    145,
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
                this.pnlPatrols);

            this.Controls.Add(
                this.pnlDepartments);

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