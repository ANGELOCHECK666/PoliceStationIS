using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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

        private Panel panelHeader;
        private Panel panelMenu;
        private Panel panelContent;

        private Panel panelBorder;
        private Panel panelHeaderBorder;
        private Panel panelGoldSeparator;
        private Panel panelExitSeparator;

        private PictureBox picLogo;
        private PictureBox picUserIcon;
        private PictureBox picRoleIcon;
        private PictureBox picClockIcon;
        private PictureBox picCalendarIcon;

        private Label lblSystemName;

        private Label lblUserName;
        private Label lblPosition;
        private Label lblDate;
        private Label lblTime;

        private Button btnDashboard;
        private Button btnEmployees;
        private Button btnCases;
        private Button btnCitizens;
        private Button btnProtocols;
        private Button btnEvidence;
        private Button btnExpertise;
        private Button btnDuty;
        private Button btnEquipment;
        private Button btnDogs;
        private Button btnReports;
        private Button btnExit;

        private void InitializeComponent()
        {
            this.panelHeader =
                new Panel();

            this.panelMenu =
                new Panel();

            this.panelContent =
                new Panel();

            this.panelBorder =
                new Panel();

            this.panelHeaderBorder =
                new Panel();

            this.panelGoldSeparator =
    new Panel();

            this.panelExitSeparator =
                new Panel();

            this.picLogo =
                new PictureBox();
            this.picUserIcon =
    new PictureBox();

            this.picRoleIcon =
                new PictureBox();

            this.picClockIcon =
                new PictureBox();

            this.lblSystemName =
                new Label();

            this.lblUserName =
                new Label();

            this.lblPosition =
    new Label();

            this.lblDate =
                new Label();

            this.lblTime =
                new Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // MainForm
            // =====================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.ClientSize =
                new Size(
                    1600,
                    900);

            this.MinimumSize =
                new Size(
                    1400,
                    850);

            this.WindowState =
                FormWindowState.Maximized;

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.Name =
                "MainForm";

            this.Text =
                "Информационная система полицейского участка";

            // =====================================
            // HEADER
            // =====================================

            this.panelHeader.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.panelHeader.Dock =
                DockStyle.Top;

            this.panelHeader.Height =
                110;

            // =====================================
            // HEADER BORDER
            // =====================================

            this.panelHeaderBorder.BackColor =
    Color.FromArgb(
        201,
        155,
        59);

            this.panelHeaderBorder.Dock =
                DockStyle.Top;

            this.panelHeaderBorder.Height =
                2;

            // GOLD SEPARATOR

            this.panelGoldSeparator.BackColor =
                Color.FromArgb(
                    201,
                    155,
                    59);

            this.panelGoldSeparator.Location =
                new Point(
                    950,
                    15);

            this.panelGoldSeparator.Size =
                new Size(
                    1,
                    60);

            // =====================================
            // LOGO
            // =====================================

            this.picLogo.Image =
                global::PoliceStationIS.Properties.Resources.gerb_mvd;

            this.picLogo.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picLogo.Location =
                new Point(
                    15,
                    10);

            this.picLogo.Size =
                new Size(
                    90,
                    90);

            // USER ICON

            this.picUserIcon.Image =
                Properties.Resources.user_gold_icon;

            this.picUserIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picUserIcon.Size =
                new Size(32, 32);

            this.picUserIcon.Location =
                new Point(1015, 16);

            this.picUserIcon.BackColor =
                Color.Transparent;

            // ROLE ICON

            this.picRoleIcon.Image =
                Properties.Resources.role_gold_icon;

            this.picRoleIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picRoleIcon.Size =
                new Size(32, 32);

            this.picRoleIcon.Location =
                new Point(1015, 50);

            this.picRoleIcon.BackColor =
                Color.Transparent;

            // CLOCK ICON

            this.picClockIcon.Image =
                Properties.Resources.clock_gold_icon;

            this.picClockIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picClockIcon.Size =
                new Size(52, 52);

            this.picClockIcon.Location =
                new Point(1375, 18);

            this.picClockIcon.BackColor =
                Color.Transparent;

            

            // =====================================
            // SYSTEM NAME
            // =====================================

            this.lblSystemName.AutoSize =
                true;

            this.lblSystemName.ForeColor =
                Color.White;

            this.lblSystemName.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblSystemName.Location =
                new Point(
                    120,
                    30);

            this.lblSystemName.Text =
                "Информационная система полицейского участка";

            // =====================================
            // USER NAME
            // =====================================

            this.lblUserName.AutoSize =
                true;

            this.lblUserName.ForeColor =
                Color.White;

            this.lblUserName.Font =
    new Font(
        "Segoe UI",
        11F,
        FontStyle.Regular);

            this.lblUserName.Location =
    new Point(
        1060,
        24);

            this.lblUserName.Text =
                "Пользователь:";

            // POSITION

            this.lblPosition.AutoSize =
                true;

            this.lblPosition.ForeColor =
                Color.White;

            this.lblPosition.Font =
    new Font(
        "Segoe UI",
        11F,
        FontStyle.Regular);

            this.lblPosition.Location =
                new Point(
                    1060,
                    58);

            this.lblPosition.Text =
                "Должность:";

            // DATE

            this.lblDate.AutoSize =
                true;

            this.lblDate.ForeColor =
                Color.White;

            this.lblDate.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblDate.Location =
                new Point(
                    1435,
                    52);

            this.lblDate.Text =
                "00.00.0000";

            // TIME

            this.lblTime.AutoSize =
                true;

            this.lblTime.ForeColor =
                Color.White;

            this.lblTime.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            this.lblTime.Location =
    new Point(1430, 12);

            this.lblTime.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTime.Text =
                "00:00";

            // =====================================
            // HEADER CONTROLS
            // =====================================

            this.panelHeader.Controls.Add(
                this.picLogo);

            this.panelHeader.Controls.Add(
                this.lblSystemName);
            this.panelHeader.Controls.Add(
    this.picUserIcon);

            this.panelHeader.Controls.Add(
                this.picRoleIcon);

            this.panelHeader.Controls.Add(
                this.picClockIcon);

            this.panelHeader.Controls.Add(
                this.lblUserName);

            this.panelHeader.Controls.Add(
    this.lblPosition);

            this.panelHeader.Controls.Add(
                this.lblDate);

            this.panelHeader.Controls.Add(
                this.lblTime);

            // =====================================
            // MENU
            // =====================================

            this.panelMenu.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.panelMenu.Dock =
                DockStyle.Left;

            this.panelMenu.Width =
                250;

            // =====================================
            // MENU BORDER
            // =====================================

            this.panelBorder.BackColor =
                Color.FromArgb(
                    201,
        155,
        59);

            this.panelBorder.Dock =
                DockStyle.Left;

            this.panelBorder.Width =
                1;

            // =====================================
            // CONTENT
            // =====================================

            this.panelContent.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.panelContent.Dock =
                DockStyle.Fill;

            // =====================================
            // EXIT SEPARATOR
            // =====================================

            this.panelExitSeparator.BackColor =
                Color.FromArgb(
                    201,
        155,
        59);

            this.panelExitSeparator.Size =
                new Size(
                    220,
                    1);

            this.panelExitSeparator.Location =
                new Point(
                    15,
                    735);

            // =====================================
            // MENU BUTTONS
            // =====================================

            this.btnDashboard =
                CreateMenuButton(
                    "Главная",
                    Properties.Resources.home_gold_icon,
                    15);

            this.btnEmployees =
                CreateMenuButton(
                    "Сотрудники",
                    Properties.Resources.employees_gold_icon,
                    60);

            this.btnCases =
                CreateMenuButton(
                    "Дела",
                    Properties.Resources.cases_gold_icon,
                    105);

            this.btnCitizens =
                CreateMenuButton(
                    "Граждане",
                    Properties.Resources.citizens_gold_icon,
                    150);

            this.btnProtocols =
                CreateMenuButton(
                    "Протоколы",
                    Properties.Resources.protocols_gold_icon,
                    195);

            this.btnEvidence =
                CreateMenuButton(
                    "Доказательства",
                    Properties.Resources.evidence_gold_icon,
                    240);

            this.btnExpertise =
                CreateMenuButton(
                    "Экспертизы",
                    Properties.Resources.expertise_gold_icon,
                    285);

            this.btnDuty =
                CreateMenuButton(
                    "Наряды",
                    Properties.Resources.patrol_gold_icon,
                    330);

            this.btnEquipment =
                CreateMenuButton(
                    "Экипировка",
                    Properties.Resources.equipment_gold_icon,
                    375);

            this.btnDogs =
                CreateMenuButton(
                    "Служебные собаки",
                    Properties.Resources.dogs_gold_icon,
                    420);

            this.btnReports =
                CreateMenuButton(
                    "Отчеты",
                    Properties.Resources.reports_gold_icon,
                    465);

            this.btnExit =
                CreateMenuButton(
                    "Выход",
                    Properties.Resources.logout_gold_icon,
                    755);

            // =====================================
            // MENU CONTROLS
            // =====================================

            this.panelMenu.Controls.Add(
                this.btnDashboard);

            this.panelMenu.Controls.Add(
                this.btnEmployees);

            this.panelMenu.Controls.Add(
                this.btnCases);

            this.panelMenu.Controls.Add(
                this.btnCitizens);

            this.panelMenu.Controls.Add(
                this.btnProtocols);

            this.panelMenu.Controls.Add(
                this.btnEvidence);

            this.panelMenu.Controls.Add(
                this.btnExpertise);

            this.panelMenu.Controls.Add(
                this.btnDuty);

            this.panelMenu.Controls.Add(
                this.btnEquipment);

            this.panelMenu.Controls.Add(
                this.btnDogs);

            this.panelMenu.Controls.Add(
                this.btnReports);

            this.panelMenu.Controls.Add(
                this.btnExit);

            this.panelMenu.Controls.Add(
                this.panelExitSeparator);


            // =====================================
            // FORM CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelContent);

            this.Controls.Add(
                this.panelBorder);

            this.Controls.Add(
                this.panelMenu);

            this.Controls.Add(
                this.panelHeaderBorder);
            this.panelHeader.Controls.Add(
    this.panelGoldSeparator);

            this.Controls.Add(
                this.panelHeader);

            ((System.ComponentModel.ISupportInitialize)
                (this.picLogo)).EndInit();

            this.ResumeLayout(false);
        }


        private Button CreateMenuButton(
    string text,
    Image icon,
    int top)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Image =
                new Bitmap(
                    icon,
                    new Size(
                        28,
                        28));

            button.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            button.ImageAlign =
                ContentAlignment.MiddleLeft;

            button.TextAlign =
                ContentAlignment.MiddleLeft;

            button.Padding =
                new Padding(
                    18,
                    0,
                    0,
                    0);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 0;

            button.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Regular);

            button.Size =
                new Size(
                    230,
                    42);

            button.Location =
                new Point(
                    10,
                    top);

            button.Cursor =
                Cursors.Hand;

            return button;
        }
    }

        #endregion
}