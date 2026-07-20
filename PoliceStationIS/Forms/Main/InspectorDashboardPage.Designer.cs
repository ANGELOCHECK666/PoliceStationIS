using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class InspectorDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picInspector;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlMyPatrols;
        private RoundedPanel pnlTodayPatrols;
        private RoundedPanel pnlEquipment;
        private RoundedPanel pnlRoutes;

        private Label lblMyPatrolsTitle;
        private Label lblMyPatrolsCount;
        private Label lblMyPatrolsUnit;

        private Label lblTodayPatrolsTitle;
        private Label lblTodayPatrolsCount;
        private Label lblTodayPatrolsUnit;

        private Label lblEquipmentTitle;
        private Label lblEquipmentCount;
        private Label lblEquipmentUnit;

        private Label lblRoutesTitle;
        private Label lblRoutesCount;
        private Label lblRoutesUnit;

        private PictureBox picMyPatrols;
        private PictureBox picTodayPatrols;
        private PictureBox picEquipment;
        private PictureBox picRoutes;

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

        private Button btnSchedule;
        private Button btnRoute;
        private Button btnEquipmentAction;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picSchedule;
        private PictureBox picRoute;
        private PictureBox picEquipmentAction;

        private PictureBox picArrowSchedule;
        private PictureBox picArrowRoute;
        private PictureBox picArrowEquipment;

        private PictureBox picInspectorSilhouette;

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

            this.picInspector =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlMyPatrols =
                new RoundedPanel();

            this.pnlTodayPatrols =
                new RoundedPanel();

            this.pnlEquipment =
                new RoundedPanel();

            this.pnlRoutes =
                new RoundedPanel();

            this.lblMyPatrolsTitle =
                new Label();

            this.lblMyPatrolsCount =
                new Label();

            this.lblMyPatrolsUnit =
                new Label();

            this.lblTodayPatrolsTitle =
                new Label();

            this.lblTodayPatrolsCount =
                new Label();

            this.lblTodayPatrolsUnit =
                new Label();

            this.lblEquipmentTitle =
                new Label();

            this.lblEquipmentCount =
                new Label();

            this.lblEquipmentUnit =
                new Label();

            this.lblRoutesTitle =
                new Label();

            this.lblRoutesCount =
                new Label();

            this.lblRoutesUnit =
                new Label();

            this.picMyPatrols =
                new PictureBox();

            this.picTodayPatrols =
                new PictureBox();

            this.picEquipment =
                new PictureBox();

            this.picRoutes =
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
                "Должность: Инспектор ППС";

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
                "Патрулирование территории, выполнение нарядов и обеспечение общественного порядка";

            // =====================================
            // IMAGE
            // =====================================

            this.picInspector.Image =
                global::PoliceStationIS.Properties.Resources.car_main_icon_icon;

            this.picInspector.Location =
                new Point(
                    980,
                    0);

            this.picInspector.Size =
                new Size(
                    300,
                    270);

            this.picInspector.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picInspector.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlMyPatrols,
                30);

            ConfigureCard(
                this.pnlTodayPatrols,
                360);

            ConfigureCard(
                this.pnlEquipment,
                690);

            ConfigureCard(
                this.pnlRoutes,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picMyPatrols,
                Properties.Resources.inspector_card_1);

            ConfigureCardTitle(
                this.lblMyPatrolsTitle,
                "Мои наряды");

            ConfigureCardValue(
                this.lblMyPatrolsCount);

            ConfigureCardUnit(
                this.lblMyPatrolsUnit,
                "шт.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picTodayPatrols,
                Properties.Resources.inspector_card_2);

            ConfigureCardTitle(
                this.lblTodayPatrolsTitle,
                "Нарядов сегодня");

            ConfigureCardValue(
                this.lblTodayPatrolsCount);

            ConfigureCardUnit(
                this.lblTodayPatrolsUnit,
                "шт.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picEquipment,
                Properties.Resources.inspector_card_3);

            ConfigureCardTitle(
                this.lblEquipmentTitle,
                "Выданная экипировка");

            ConfigureCardValue(
                this.lblEquipmentCount);

            ConfigureCardUnit(
                this.lblEquipmentUnit,
                "ед.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picRoutes,
                Properties.Resources.inspector_card_4);

            ConfigureCardTitle(
                this.lblRoutesTitle,
                "Маршрутов патрулирования");

            ConfigureCardValue(
                this.lblRoutesCount);

            ConfigureCardUnit(
                this.lblRoutesUnit,
                "шт.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlMyPatrols.Controls.Add(
                this.picMyPatrols);

            this.pnlMyPatrols.Controls.Add(
                this.lblMyPatrolsTitle);

            this.pnlMyPatrols.Controls.Add(
                this.lblMyPatrolsCount);

            this.pnlMyPatrols.Controls.Add(
                this.lblMyPatrolsUnit);

            // -------------------------------------

            this.pnlTodayPatrols.Controls.Add(
                this.picTodayPatrols);

            this.pnlTodayPatrols.Controls.Add(
                this.lblTodayPatrolsTitle);

            this.pnlTodayPatrols.Controls.Add(
                this.lblTodayPatrolsCount);

            this.pnlTodayPatrols.Controls.Add(
                this.lblTodayPatrolsUnit);

            // -------------------------------------

            this.pnlEquipment.Controls.Add(
                this.picEquipment);

            this.pnlEquipment.Controls.Add(
                this.lblEquipmentTitle);

            this.pnlEquipment.Controls.Add(
                this.lblEquipmentCount);

            this.pnlEquipment.Controls.Add(
                this.lblEquipmentUnit);

            // -------------------------------------

            this.pnlRoutes.Controls.Add(
                this.picRoutes);

            this.pnlRoutes.Controls.Add(
                this.lblRoutesTitle);

            this.pnlRoutes.Controls.Add(
                this.lblRoutesCount);

            this.pnlRoutes.Controls.Add(
                this.lblRoutesUnit);

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
                this.picInspector);

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
                "Route",
                "Маршрут");

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

            this.btnSchedule =
                new Button();

            this.btnRoute =
                new Button();

            this.btnEquipmentAction =
                new Button();

            this.picSchedule =
                new PictureBox();

            this.picRoute =
                new PictureBox();

            this.picEquipmentAction =
                new PictureBox();

            this.picArrowSchedule =
                new PictureBox();

            this.picArrowRoute =
                new PictureBox();

            this.picArrowEquipment =
                new PictureBox();

            this.picInspectorSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTION BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnSchedule,
                "Просмотреть график нарядов",
                50);

            ConfigureActionButton(
                this.btnRoute,
                "Просмотреть маршрут",
                125);

            ConfigureActionButton(
                this.btnEquipmentAction,
                "Моя экипировка",
                200);

            // =====================================
            // ICONS
            // =====================================

            ConfigureActionIcon(
                this.picSchedule,
                Properties.Resources.inspector_1,
                50);

            ConfigureActionIcon(
                this.picRoute,
                Properties.Resources.inspector_2,
                125);

            ConfigureActionIcon(
                this.picEquipmentAction,
                Properties.Resources.inspector_3,
                200);

            // =====================================
            // ARROWS
            // =====================================

            ConfigureArrowIcon(
                this.picArrowSchedule,
                50);

            ConfigureArrowIcon(
                this.picArrowRoute,
                125);

            ConfigureArrowIcon(
                this.picArrowEquipment,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnSchedule);

            this.pnlQuickActions.Controls.Add(
                this.picSchedule);

            this.pnlQuickActions.Controls.Add(
                this.picRoute);

            this.pnlQuickActions.Controls.Add(
                this.picEquipmentAction);

            this.picSchedule.BringToFront();
            this.picRoute.BringToFront();
            this.picEquipmentAction.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnRoute);

            this.pnlQuickActions.Controls.Add(
                this.btnEquipmentAction);

            this.pnlQuickActions.Controls.Add(
                this.picArrowSchedule);

            this.pnlQuickActions.Controls.Add(
                this.picArrowRoute);

            this.pnlQuickActions.Controls.Add(
                this.picArrowEquipment);

            this.picArrowSchedule.BringToFront();
            this.picArrowRoute.BringToFront();
            this.picArrowEquipment.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picInspectorSilhouette);

            this.picInspectorSilhouette.SendToBack();

            // =====================================
            // INSPECTOR IMAGE
            // =====================================

            this.picInspectorSilhouette.Image =
                Properties.Resources.inspector_4;

            this.picInspectorSilhouette.BackColor =
                Color.Transparent;

            this.picInspectorSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picInspectorSilhouette.Location =
                new Point(
                    150,
                    270);

            this.picInspectorSilhouette.Size =
                new Size(
                    160,
                    140);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlMyPatrols);

            this.Controls.Add(
                this.pnlTodayPatrols);

            this.Controls.Add(
                this.pnlEquipment);

            this.Controls.Add(
                this.pnlRoutes);

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