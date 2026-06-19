using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class HRDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picHR;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlEmployees;
        private RoundedPanel pnlNewEmployees;
        private RoundedPanel pnlVacation;
        private RoundedPanel pnlSickLeave;

        private Label lblEmployeesTitle;
        private Label lblEmployeesCount;
        private Label lblEmployeesUnit;

        private Label lblNewEmployeesTitle;
        private Label lblNewEmployeesCount;
        private Label lblNewEmployeesUnit;

        private Label lblVacationTitle;
        private Label lblVacationCount;
        private Label lblVacationUnit;

        private Label lblSickTitle;
        private Label lblSickCount;
        private Label lblSickUnit;

        private PictureBox picEmployees;
        private PictureBox picNewEmployees;
        private PictureBox picVacation;
        private PictureBox picSickLeave;

        // =====================================
        // RECENT CHANGES
        // =====================================

        private RoundedPanel pnlRecentChanges;

        private Label lblRecentChanges;

        private DataGridView dgvChanges;

        // =====================================
        // QUICK ACTIONS
        // =====================================

        private RoundedPanel pnlQuickActions;

        private Label lblQuickActions;

        private Button btnAddEmployee;
        private Button btnViewEmployeess;
        private Button btnVacation;
        private Button btnSickLeave;
        private Button btnChangePosition;
        private Button btnReport;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        // QUICK ACTIONS ICONS

        private PictureBox picAddEmployee;
        private PictureBox picViewEmployeesAction;
        private PictureBox picVacationAction;
        private PictureBox picSickLeaveAction;
        private PictureBox picChangePosition;
        private PictureBox picReport;

        private PictureBox picArrowAdd;
        private PictureBox picArrowView;
        private PictureBox picArrowVacation;
        private PictureBox picArrowSick;
        private PictureBox picArrowPost;
        private PictureBox picArrowReport;

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

            this.picHR =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlEmployees =
                new RoundedPanel();

            this.pnlNewEmployees =
                new RoundedPanel();

            this.pnlVacation =
                new RoundedPanel();

            this.pnlSickLeave =
                new RoundedPanel();

            this.lblEmployeesTitle =
                new Label();

            this.lblEmployeesCount =
                new Label();

            this.lblEmployeesUnit =
                new Label();

            this.lblNewEmployeesTitle =
                new Label();

            this.lblNewEmployeesCount =
                new Label();

            this.lblNewEmployeesUnit =
                new Label();

            this.lblVacationTitle =
                new Label();

            this.lblVacationCount =
                new Label();

            this.lblVacationUnit =
                new Label();

            this.lblSickTitle =
                new Label();

            this.lblSickCount =
                new Label();

            this.lblSickUnit =
                new Label();

            this.picEmployees =
                new PictureBox();

            this.picNewEmployees =
                new PictureBox();

            this.picVacation =
                new PictureBox();

            this.picSickLeave =
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
                "Должность: Кадровик";

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
                "Управление персоналом и кадровой документацией";

            // =====================================
            // IMAGE
            // =====================================

            this.picHR.Image =
                global::PoliceStationIS.Properties.Resources.personnel_image;

            this.picHR.Location =
                new Point(
                    980,
                    0);

            this.picHR.Size =
                new Size(
                    280,
                    230);

            this.picHR.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picHR.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlEmployees,
                30);

            ConfigureCard(
                this.pnlNewEmployees,
                360);

            ConfigureCard(
                this.pnlVacation,
                690);

            ConfigureCard(
                this.pnlSickLeave,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picEmployees,
                Properties.Resources.p_1);

            ConfigureCardTitle(
                this.lblEmployeesTitle,
                "Всего сотрудников");

            ConfigureCardValue(
                this.lblEmployeesCount);

            ConfigureCardUnit(
                this.lblEmployeesUnit);

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picNewEmployees,
                Properties.Resources.p_2);

            ConfigureCardTitle(
                this.lblNewEmployeesTitle,
                "Принято за месяц");

            ConfigureCardValue(
                this.lblNewEmployeesCount);

            ConfigureCardUnit(
                this.lblNewEmployeesUnit);

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picVacation,
                Properties.Resources.p_3);

            ConfigureCardTitle(
                this.lblVacationTitle,
                "В отпуске");

            ConfigureCardValue(
                this.lblVacationCount);

            ConfigureCardUnit(
                this.lblVacationUnit);

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picSickLeave,
                Properties.Resources.p_4);

            ConfigureCardTitle(
                this.lblSickTitle,
                "На больничном");

            ConfigureCardValue(
                this.lblSickCount);

            ConfigureCardUnit(
                this.lblSickUnit);

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

            this.pnlNewEmployees.Controls.Add(
                this.picNewEmployees);

            this.pnlNewEmployees.Controls.Add(
                this.lblNewEmployeesTitle);

            this.pnlNewEmployees.Controls.Add(
                this.lblNewEmployeesCount);

            this.pnlNewEmployees.Controls.Add(
                this.lblNewEmployeesUnit);

            // -------------------------------------

            this.pnlVacation.Controls.Add(
                this.picVacation);

            this.pnlVacation.Controls.Add(
                this.lblVacationTitle);

            this.pnlVacation.Controls.Add(
                this.lblVacationCount);

            this.pnlVacation.Controls.Add(
                this.lblVacationUnit);

            // -------------------------------------

            this.pnlSickLeave.Controls.Add(
                this.picSickLeave);

            this.pnlSickLeave.Controls.Add(
                this.lblSickTitle);

            this.pnlSickLeave.Controls.Add(
                this.lblSickCount);

            this.pnlSickLeave.Controls.Add(
                this.lblSickUnit);

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
                this.picHR);


            // =====================================
            // RECENT CHANGES PANEL
            // =====================================

            this.pnlRecentChanges =
                new RoundedPanel();

            this.pnlRecentChanges.BorderRadius = 18;

            this.pnlRecentChanges.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.pnlRecentChanges.Location =
                new Point(
                    30,
                    430);

            this.pnlRecentChanges.Size =
                new Size(
                    780,
                    380);

            // =====================================

            this.lblRecentChanges =
                new Label();

            this.lblRecentChanges.AutoSize = true;

            this.lblRecentChanges.ForeColor =
                Color.White;

            this.lblRecentChanges.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblRecentChanges.Location =
                new Point(
                    20,
                    15);

            this.lblRecentChanges.Text =
                "Последние кадровые изменения";

            // =====================================
            // GRID
            // =====================================

            this.dgvChanges =
                new DataGridView();

            this.dgvChanges.Location =
                new Point(
                    20,
                    50);

            this.dgvChanges.Size =
                new Size(
                    740,
                    300);

            this.dgvChanges.BackgroundColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvChanges.BorderStyle =
                BorderStyle.None;

            this.dgvChanges.RowHeadersVisible = false;

            this.dgvChanges.CellBorderStyle =
    DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvChanges.AdvancedCellBorderStyle.Left =
    DataGridViewAdvancedCellBorderStyle.None;

            this.dgvChanges.AdvancedCellBorderStyle.Right =
                DataGridViewAdvancedCellBorderStyle.None;

            this.dgvChanges.RowTemplate.Height = 42;

            this.dgvChanges.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            this.dgvChanges.AllowUserToAddRows = false;

            this.dgvChanges.AllowUserToDeleteRows = false;

            this.dgvChanges.AllowUserToResizeRows = false;

            this.dgvChanges.ReadOnly = true;

            this.dgvChanges.MultiSelect = false;

            this.dgvChanges.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvChanges.EnableHeadersVisualStyles =
                false;

            this.dgvChanges.ColumnHeadersDefaultCellStyle.SelectionBackColor =
    Color.FromArgb(
        35,
        60,
        110);

            // =====================================
            // HEADER
            // =====================================

            this.dgvChanges.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    35,
                    60,
                    110);

            this.dgvChanges.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            this.dgvChanges.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.dgvChanges.ColumnHeadersHeight = 40;

            // =====================================
            // CELLS
            // =====================================

            this.dgvChanges.DefaultCellStyle.BackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvChanges.DefaultCellStyle.ForeColor =
                Color.White;

            this.dgvChanges.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    22,
                    47,
                    94);

            this.dgvChanges.DefaultCellStyle.SelectionForeColor =
                Color.White;

            this.dgvChanges.GridColor =
                Color.FromArgb(
                    60,
                    80,
                    120);

            // =====================================
            // COLUMNS
            // =====================================

            this.dgvChanges.Columns.Add(
                "Date",
                "Дата");

            this.dgvChanges.Columns.Add(
                "Time",
                "Время");

            this.dgvChanges.Columns.Add(
                "Event",
                "Событие");

            this.dgvChanges.Columns.Add(
                "Employee",
                "Сотрудник");

            this.dgvChanges.Columns[0].Width = 110;
            this.dgvChanges.Columns[1].Width = 90;
            this.dgvChanges.Columns[2].Width = 220;
            this.dgvChanges.Columns[3].Width = 300;

            

            // =====================================

            this.pnlRecentChanges.Controls.Add(
                this.lblRecentChanges);

            this.pnlRecentChanges.Controls.Add(
                this.dgvChanges);

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

            this.btnAddEmployee =
                new Button();

            this.btnViewEmployeess =
                new Button();

            this.btnVacation =
                new Button();

            this.btnSickLeave =
                new Button();

            this.btnChangePosition =
                new Button();

            this.btnReport =
                new Button();

            this.picAddEmployee = new PictureBox();
            this.picViewEmployeesAction = new PictureBox();
            this.picVacationAction = new PictureBox();
            this.picSickLeaveAction = new PictureBox();
            this.picChangePosition = new PictureBox();
            this.picReport = new PictureBox();

            this.picArrowAdd = new PictureBox();
            this.picArrowView = new PictureBox();
            this.picArrowVacation = new PictureBox();
            this.picArrowSick = new PictureBox();
            this.picArrowPost = new PictureBox();
            this.picArrowReport = new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnAddEmployee,
                "Добавить сотрудника",
                55);

            ConfigureActionButton(
                this.btnViewEmployeess,
                "Просмотреть сотрудников",
                105);

            ConfigureActionButton(
                this.btnVacation,
                "Оформить отпуск",
                155);

            ConfigureActionButton(
                this.btnSickLeave,
                "Оформить больничный",
                205);

            ConfigureActionButton(
                this.btnChangePosition,
                "Изменить должность",
                255);

            ConfigureActionButton(
                this.btnReport,
                "Сформировать отчет",
                305);

            ConfigureActionIcon(
    this.picAddEmployee,
    Properties.Resources.employee_add_gold_icon,
    55);

            ConfigureActionIcon(
                this.picViewEmployeesAction,
                Properties.Resources.employee_search_gold_icon,
                105);

            ConfigureActionIcon(
                this.picVacationAction,
                Properties.Resources.vacation_gold_icon,
                155);

            ConfigureActionIcon(
                this.picSickLeaveAction,
                Properties.Resources.sick_leave_gold_icon,
                205);

            ConfigureActionIcon(
                this.picChangePosition,
                Properties.Resources.position_gold_icon,
                255);

            ConfigureActionIcon(
                this.picReport,
                Properties.Resources.reports_gold_icon,
                305);

            ConfigureArrowIcon(this.picArrowAdd, 55);
            ConfigureArrowIcon(this.picArrowView, 105);
            ConfigureArrowIcon(this.picArrowVacation, 155);
            ConfigureArrowIcon(this.picArrowSick, 205);
            ConfigureArrowIcon(this.picArrowPost, 255);
            ConfigureArrowIcon(this.picArrowReport, 305);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnAddEmployee);

            this.pnlQuickActions.Controls.Add(
    this.picAddEmployee);

            this.pnlQuickActions.Controls.Add(
                this.picViewEmployeesAction);

            this.pnlQuickActions.Controls.Add(
                this.picVacationAction);

            this.pnlQuickActions.Controls.Add(
                this.picSickLeaveAction);

            this.pnlQuickActions.Controls.Add(
                this.picChangePosition);

            this.pnlQuickActions.Controls.Add(
                this.picReport);

            this.picAddEmployee.BringToFront();
            this.picViewEmployeesAction.BringToFront();
            this.picVacationAction.BringToFront();
            this.picSickLeaveAction.BringToFront();
            this.picChangePosition.BringToFront();
            this.picReport.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnViewEmployeess);

            this.pnlQuickActions.Controls.Add(
                this.btnVacation);

            this.pnlQuickActions.Controls.Add(
                this.btnSickLeave);

            this.pnlQuickActions.Controls.Add(
                this.btnChangePosition);

            this.pnlQuickActions.Controls.Add(
                this.btnReport);

            this.pnlQuickActions.Controls.Add(this.picArrowAdd);
            this.pnlQuickActions.Controls.Add(this.picArrowView);
            this.pnlQuickActions.Controls.Add(this.picArrowVacation);
            this.pnlQuickActions.Controls.Add(this.picArrowSick);
            this.pnlQuickActions.Controls.Add(this.picArrowPost);
            this.pnlQuickActions.Controls.Add(this.picArrowReport);

            this.picArrowAdd.BringToFront();
            this.picArrowView.BringToFront();
            this.picArrowVacation.BringToFront();
            this.picArrowSick.BringToFront();
            this.picArrowPost.BringToFront();
            this.picArrowReport.BringToFront();

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlEmployees);

            this.Controls.Add(
                this.pnlNewEmployees);

            this.Controls.Add(
                this.pnlVacation);

            this.Controls.Add(
                this.pnlSickLeave);

            this.Controls.Add(
                this.pnlRecentChanges);

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

            label.Text = "чел.";
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
                    48);

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
                    10F);

            button.TextAlign =
    ContentAlignment.MiddleLeft;

            button.Padding =
                new Padding(
                    55,
                    0,
                    25,
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
                    24,
                    y + 8);

            picture.Size =
                new Size(
                    32,
                    32);
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
                    415,
                    y + 12);

            picture.Size =
                new Size(
                    20,
                    20);
        }

        #endregion
    }
}
