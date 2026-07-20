using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class DutyOfficerDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picDutyOfficer;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlActivePatrols;
        private RoundedPanel pnlEmployeesShift;
        private RoundedPanel pnlIncidents;
        private RoundedPanel pnlCalls;

        private Label lblActivePatrolsTitle;
        private Label lblActivePatrolsCount;
        private Label lblActivePatrolsUnit;

        private Label lblEmployeesShiftTitle;
        private Label lblEmployeesShiftCount;
        private Label lblEmployeesShiftUnit;

        private Label lblIncidentsTitle;
        private Label lblIncidentsCount;
        private Label lblIncidentsUnit;

        private Label lblCallsTitle;
        private Label lblCallsCount;
        private Label lblCallsUnit;

        private PictureBox picActivePatrols;
        private PictureBox picEmployeesShift;
        private PictureBox picIncidents;
        private PictureBox picCalls;

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

        private Button btnPatrols;
        private Button btnCallLog;
        private Button btnRegisterIncident;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picPatrols;
        private PictureBox picCallLog;
        private PictureBox picRegisterIncident;

        private PictureBox picArrowPatrols;
        private PictureBox picArrowCallLog;
        private PictureBox picArrowIncident;

        private PictureBox picDutyOfficerSilhouette;

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

            this.picDutyOfficer =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlActivePatrols =
                new RoundedPanel();

            this.pnlEmployeesShift =
                new RoundedPanel();

            this.pnlIncidents =
                new RoundedPanel();

            this.pnlCalls =
                new RoundedPanel();

            this.lblActivePatrolsTitle =
                new Label();

            this.lblActivePatrolsCount =
                new Label();

            this.lblActivePatrolsUnit =
                new Label();

            this.lblEmployeesShiftTitle =
                new Label();

            this.lblEmployeesShiftCount =
                new Label();

            this.lblEmployeesShiftUnit =
                new Label();

            this.lblIncidentsTitle =
                new Label();

            this.lblIncidentsCount =
                new Label();

            this.lblIncidentsUnit =
                new Label();

            this.lblCallsTitle =
                new Label();

            this.lblCallsCount =
                new Label();

            this.lblCallsUnit =
                new Label();

            this.picActivePatrols =
                new PictureBox();

            this.picEmployeesShift =
                new PictureBox();

            this.picIncidents =
                new PictureBox();

            this.picCalls =
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
                "Должность: Дежурный";

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
                "Координация нарядов, регистрация происшествий и прием сообщений граждан";

            // =====================================
            // IMAGE
            // =====================================

            this.picDutyOfficer.Image =
                global::PoliceStationIS.Properties.Resources.main_duty;

            this.picDutyOfficer.Location =
                new Point(
                    980,
                    10);

            this.picDutyOfficer.Size =
                new Size(
                    290,
                    240);

            this.picDutyOfficer.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picDutyOfficer.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlActivePatrols,
                30);

            ConfigureCard(
                this.pnlEmployeesShift,
                360);

            ConfigureCard(
                this.pnlIncidents,
                690);

            ConfigureCard(
                this.pnlCalls,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picActivePatrols,
                Properties.Resources.inspector_card_1);

            ConfigureCardTitle(
                this.lblActivePatrolsTitle,
                "Активных нарядов");

            ConfigureCardValue(
                this.lblActivePatrolsCount);

            ConfigureCardUnit(
                this.lblActivePatrolsUnit,
                "нар.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picEmployeesShift,
                Properties.Resources.employees_icon);

            ConfigureCardTitle(
                this.lblEmployeesShiftTitle,
                "Сотрудников на смене");

            ConfigureCardValue(
                this.lblEmployeesShiftCount);

            ConfigureCardUnit(
                this.lblEmployeesShiftUnit,
                "сотр.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picIncidents,
                Properties.Resources.duty_card_3);

            ConfigureCardTitle(
                this.lblIncidentsTitle,
                "Происшествий");

            ConfigureCardValue(
                this.lblIncidentsCount);

            ConfigureCardUnit(
                this.lblIncidentsUnit,
                "шт.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picCalls,
                Properties.Resources.duty_card_4);

            ConfigureCardTitle(
                this.lblCallsTitle,
                "Получено вызовов");

            ConfigureCardValue(
                this.lblCallsCount);

            ConfigureCardUnit(
                this.lblCallsUnit,
                "выз.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlActivePatrols.Controls.Add(
                this.picActivePatrols);

            this.pnlActivePatrols.Controls.Add(
                this.lblActivePatrolsTitle);

            this.pnlActivePatrols.Controls.Add(
                this.lblActivePatrolsCount);

            this.pnlActivePatrols.Controls.Add(
                this.lblActivePatrolsUnit);

            // -------------------------------------

            this.pnlEmployeesShift.Controls.Add(
                this.picEmployeesShift);

            this.pnlEmployeesShift.Controls.Add(
                this.lblEmployeesShiftTitle);

            this.pnlEmployeesShift.Controls.Add(
                this.lblEmployeesShiftCount);

            this.pnlEmployeesShift.Controls.Add(
                this.lblEmployeesShiftUnit);

            // -------------------------------------

            this.pnlIncidents.Controls.Add(
                this.picIncidents);

            this.pnlIncidents.Controls.Add(
                this.lblIncidentsTitle);

            this.pnlIncidents.Controls.Add(
                this.lblIncidentsCount);

            this.pnlIncidents.Controls.Add(
                this.lblIncidentsUnit);

            // -------------------------------------

            this.pnlCalls.Controls.Add(
                this.picCalls);

            this.pnlCalls.Controls.Add(
                this.lblCallsTitle);

            this.pnlCalls.Controls.Add(
                this.lblCallsCount);

            this.pnlCalls.Controls.Add(
                this.lblCallsUnit);

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
                this.picDutyOfficer);

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
                "Patrol",
                "Наряд / Вызов");

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

            this.btnPatrols =
                new Button();

            this.btnCallLog =
                new Button();

            this.btnRegisterIncident =
                new Button();

            this.picPatrols =
                new PictureBox();

            this.picCallLog =
                new PictureBox();

            this.picRegisterIncident =
                new PictureBox();

            this.picArrowPatrols =
                new PictureBox();

            this.picArrowCallLog =
                new PictureBox();

            this.picArrowIncident =
                new PictureBox();

            this.picDutyOfficerSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTION BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnPatrols,
                "Просмотреть активные наряды",
                50);

            ConfigureActionButton(
                this.btnCallLog,
                "Журнал вызовов",
                125);

            ConfigureActionButton(
                this.btnRegisterIncident,
                "Зарегистрировать происшествие",
                200);

            // =====================================
            // ICONS
            // =====================================

            ConfigureActionIcon(
                this.picPatrols,
                Properties.Resources.oform_naryd,
                50);

            ConfigureActionIcon(
                this.picCallLog,
                Properties.Resources.duty_call,
                125);

            ConfigureActionIcon(
                this.picRegisterIncident,
                Properties.Resources.protocol_add_gold_icon,
                200);

            // =====================================
            // ARROWS
            // =====================================

            ConfigureArrowIcon(
                this.picArrowPatrols,
                50);

            ConfigureArrowIcon(
                this.picArrowCallLog,
                125);

            ConfigureArrowIcon(
                this.picArrowIncident,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnPatrols);

            this.pnlQuickActions.Controls.Add(
                this.picPatrols);

            this.pnlQuickActions.Controls.Add(
                this.picCallLog);

            this.pnlQuickActions.Controls.Add(
                this.picRegisterIncident);

            this.picPatrols.BringToFront();
            this.picCallLog.BringToFront();
            this.picRegisterIncident.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnCallLog);

            this.pnlQuickActions.Controls.Add(
                this.btnRegisterIncident);

            this.pnlQuickActions.Controls.Add(
                this.picArrowPatrols);

            this.pnlQuickActions.Controls.Add(
                this.picArrowCallLog);

            this.pnlQuickActions.Controls.Add(
                this.picArrowIncident);

            this.picArrowPatrols.BringToFront();
            this.picArrowCallLog.BringToFront();
            this.picArrowIncident.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picDutyOfficerSilhouette);

            this.picDutyOfficerSilhouette.SendToBack();

            // =====================================
            // SILHOUETTE
            // =====================================

            this.picDutyOfficerSilhouette.Image =
                Properties.Resources.duty_sil;

            this.picDutyOfficerSilhouette.BackColor =
                Color.Transparent;

            this.picDutyOfficerSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picDutyOfficerSilhouette.Location =
                new Point(
                    150,
                    265);

            this.picDutyOfficerSilhouette.Size =
                new Size(
                    150,
                    115);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlActivePatrols);

            this.Controls.Add(
                this.pnlEmployeesShift);

            this.Controls.Add(
                this.pnlIncidents);

            this.Controls.Add(
                this.pnlCalls);

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

            label.Text = "нар.";
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