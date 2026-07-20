using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class MTODashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picMTO;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlWarehouse;
        private RoundedPanel pnlIssued;
        private RoundedPanel pnlMaintenance;
        private RoundedPanel pnlRequests;

        private Label lblWarehouseTitle;
        private Label lblWarehouseCount;
        private Label lblWarehouseUnit;

        private Label lblIssuedTitle;
        private Label lblIssuedCount;
        private Label lblIssuedUnit;

        private Label lblMaintenanceTitle;
        private Label lblMaintenanceCount;
        private Label lblMaintenanceUnit;

        private Label lblRequestsTitle;
        private Label lblRequestsCount;
        private Label lblRequestsUnit;

        private PictureBox picWarehouse;
        private PictureBox picIssued;
        private PictureBox picMaintenance;
        private PictureBox picRequests;

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

        private Button btnWarehouse;
        private Button btnRequests;
        private Button btnMaintenance;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picWarehouseAction;
        private PictureBox picRequestsAction;
        private PictureBox picMaintenanceAction;

        private PictureBox picArrowWarehouse;
        private PictureBox picArrowRequests;
        private PictureBox picArrowMaintenance;

        private PictureBox picMTOSilhouette;

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

            this.picMTO =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlWarehouse =
                new RoundedPanel();

            this.pnlIssued =
                new RoundedPanel();

            this.pnlMaintenance =
                new RoundedPanel();

            this.pnlRequests =
                new RoundedPanel();

            this.lblWarehouseTitle =
                new Label();

            this.lblWarehouseCount =
                new Label();

            this.lblWarehouseUnit =
                new Label();

            this.lblIssuedTitle =
                new Label();

            this.lblIssuedCount =
                new Label();

            this.lblIssuedUnit =
                new Label();

            this.lblMaintenanceTitle =
                new Label();

            this.lblMaintenanceCount =
                new Label();

            this.lblMaintenanceUnit =
                new Label();

            this.lblRequestsTitle =
                new Label();

            this.lblRequestsCount =
                new Label();

            this.lblRequestsUnit =
                new Label();

            this.picWarehouse =
                new PictureBox();

            this.picIssued =
                new PictureBox();

            this.picMaintenance =
                new PictureBox();

            this.picRequests =
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
                "Должность: Специалист материально-технического обеспечения";

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
                "Учет, выдача и контроль состояния служебного имущества, оборудования, транспорта и специальных средств подразделения";

            // =====================================
            // IMAGE
            // =====================================

            this.picMTO.Image =
                global::PoliceStationIS.Properties.Resources.mto_main;

            this.picMTO.Location =
                new Point(
                    980,
                    5);

            this.picMTO.Size =
                new Size(
                    280,
                    220);

            this.picMTO.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picMTO.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlWarehouse,
                30);

            ConfigureCard(
                this.pnlIssued,
                360);

            ConfigureCard(
                this.pnlMaintenance,
                690);

            ConfigureCard(
                this.pnlRequests,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picWarehouse,
                Properties.Resources.mto_card_1);

            ConfigureCardTitle(
                this.lblWarehouseTitle,
                "Имущества на складе");

            ConfigureCardValue(
                this.lblWarehouseCount);

            ConfigureCardUnit(
                this.lblWarehouseUnit,
                "ед.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picIssued,
                Properties.Resources.mto_card_2);

            ConfigureCardTitle(
                this.lblIssuedTitle,
                "Выдано сотрудникам");

            ConfigureCardValue(
                this.lblIssuedCount);

            ConfigureCardUnit(
                this.lblIssuedUnit,
                "ед.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picMaintenance,
                Properties.Resources.mto_card_3);

            ConfigureCardTitle(
                this.lblMaintenanceTitle,
                "Требует обслуживания");

            ConfigureCardValue(
                this.lblMaintenanceCount);

            ConfigureCardUnit(
                this.lblMaintenanceUnit,
                "ед.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picRequests,
                Properties.Resources.criminalist_card_4);

            ConfigureCardTitle(
                this.lblRequestsTitle,
                "Новых заявок");

            ConfigureCardValue(
                this.lblRequestsCount);

            ConfigureCardUnit(
                this.lblRequestsUnit,
                "заяв.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlWarehouse.Controls.Add(
                this.picWarehouse);

            this.pnlWarehouse.Controls.Add(
                this.lblWarehouseTitle);

            this.pnlWarehouse.Controls.Add(
                this.lblWarehouseCount);

            this.pnlWarehouse.Controls.Add(
                this.lblWarehouseUnit);

            // -------------------------------------

            this.pnlIssued.Controls.Add(
                this.picIssued);

            this.pnlIssued.Controls.Add(
                this.lblIssuedTitle);

            this.pnlIssued.Controls.Add(
                this.lblIssuedCount);

            this.pnlIssued.Controls.Add(
                this.lblIssuedUnit);

            // -------------------------------------

            this.pnlMaintenance.Controls.Add(
                this.picMaintenance);

            this.pnlMaintenance.Controls.Add(
                this.lblMaintenanceTitle);

            this.pnlMaintenance.Controls.Add(
                this.lblMaintenanceCount);

            this.pnlMaintenance.Controls.Add(
                this.lblMaintenanceUnit);

            // -------------------------------------

            this.pnlRequests.Controls.Add(
                this.picRequests);

            this.pnlRequests.Controls.Add(
                this.lblRequestsTitle);

            this.pnlRequests.Controls.Add(
                this.lblRequestsCount);

            this.pnlRequests.Controls.Add(
                this.lblRequestsUnit);

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
                this.picMTO);

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
                "Equipment",
                "Имущество");

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

            this.btnWarehouse =
                new Button();

            this.btnRequests =
                new Button();

            this.btnMaintenance =
                new Button();

            this.picWarehouseAction =
                new PictureBox();

            this.picRequestsAction =
                new PictureBox();

            this.picMaintenanceAction =
                new PictureBox();

            this.picArrowWarehouse =
                new PictureBox();

            this.picArrowRequests =
                new PictureBox();

            this.picArrowMaintenance =
                new PictureBox();

            this.picMTOSilhouette =
                new PictureBox();

            // =====================================
            // QUICK ACTION BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnWarehouse,
                "Управление складом",
                50);

            ConfigureActionButton(
                this.btnRequests,
                "Заявки на выдачу",
                125);

            ConfigureActionButton(
                this.btnMaintenance,
                "Обслуживание имущества",
                200);

            // =====================================
            // ICONS
            // =====================================

            ConfigureActionIcon(
                this.picWarehouseAction,
                Properties.Resources.mto_card_gold_1,
                50);

            ConfigureActionIcon(
                this.picRequestsAction,
                Properties.Resources.mto_card_gold_2,
                125);

            ConfigureActionIcon(
                this.picMaintenanceAction,
                Properties.Resources.mto_card_gold_3,
                200);

            // =====================================
            // ARROWS
            // =====================================

            ConfigureArrowIcon(
                this.picArrowWarehouse,
                50);

            ConfigureArrowIcon(
                this.picArrowRequests,
                125);

            ConfigureArrowIcon(
                this.picArrowMaintenance,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnWarehouse);

            this.pnlQuickActions.Controls.Add(
                this.picWarehouseAction);

            this.pnlQuickActions.Controls.Add(
                this.picRequestsAction);

            this.pnlQuickActions.Controls.Add(
                this.picMaintenanceAction);

            this.picWarehouseAction.BringToFront();
            this.picRequestsAction.BringToFront();
            this.picMaintenanceAction.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnRequests);

            this.pnlQuickActions.Controls.Add(
                this.btnMaintenance);

            this.pnlQuickActions.Controls.Add(
                this.picArrowWarehouse);

            this.pnlQuickActions.Controls.Add(
                this.picArrowRequests);

            this.pnlQuickActions.Controls.Add(
                this.picArrowMaintenance);

            this.picArrowWarehouse.BringToFront();
            this.picArrowRequests.BringToFront();
            this.picArrowMaintenance.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picMTOSilhouette);

            this.picMTOSilhouette.SendToBack();

            // =====================================
            // SILHOUETTE
            // =====================================

            this.picMTOSilhouette.Image =
                Properties.Resources.mto_sil;

            this.picMTOSilhouette.BackColor =
                Color.Transparent;

            this.picMTOSilhouette.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picMTOSilhouette.Location =
                new Point(
                    155,
                    230);

            this.picMTOSilhouette.Size =
                new Size(
                    170,
                    180);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlWarehouse);

            this.Controls.Add(
                this.pnlIssued);

            this.Controls.Add(
                this.pnlMaintenance);

            this.Controls.Add(
                this.pnlRequests);

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

            label.Text = "ед.";
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