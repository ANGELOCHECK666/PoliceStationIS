using PoliceStationIS.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    partial class DogHandlerDashboardPage
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================
        // WELCOME PANEL
        // =====================================

        private RoundedPanel panelWelcome;

        private Label lblWelcome;
        private Label lblPosition;
        private Label lblDescription;

        private PictureBox picDogHandler;

        // =====================================
        // STATISTICS CARDS
        // =====================================

        private RoundedPanel pnlAssignedDogs;
        private RoundedPanel pnlPatrolDogs;
        private RoundedPanel pnlNewDogs;
        private RoundedPanel pnlActiveDogs;

        private Label lblAssignedDogsTitle;
        private Label lblAssignedDogsCount;
        private Label lblAssignedDogsUnit;

        private Label lblPatrolDogsTitle;
        private Label lblPatrolDogsCount;
        private Label lblPatrolDogsUnit;

        private Label lblNewDogsTitle;
        private Label lblNewDogsCount;
        private Label lblNewDogsUnit;

        private Label lblActiveDogsTitle;
        private Label lblActiveDogsCount;
        private Label lblActiveDogsUnit;

        private PictureBox picAssignedDogs;
        private PictureBox picPatrolDogs;
        private PictureBox picNewDogs;
        private PictureBox picActiveDogs;

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

        private Button btnAddDog;
        private Button btnViewDogs;
        private Button btnAssignPatrol;

        // =====================================
        // QUICK ACTIONS ICONS
        // =====================================

        private PictureBox picAddDog;
        private PictureBox picViewDogs;
        private PictureBox picAssignPatrol;

        private PictureBox picArrowAdd;
        private PictureBox picArrowView;
        private PictureBox picArrowPatrol;

        private PictureBox picDog;

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

            this.picDogHandler =
                new PictureBox();

            // =====================================
            // STATISTIC CARDS
            // =====================================

            this.pnlAssignedDogs =
                new RoundedPanel();

            this.pnlPatrolDogs =
                new RoundedPanel();

            this.pnlNewDogs =
                new RoundedPanel();

            this.pnlActiveDogs =
                new RoundedPanel();

            this.lblAssignedDogsTitle =
                new Label();

            this.lblAssignedDogsCount =
                new Label();

            this.lblAssignedDogsUnit =
                new Label();

            this.lblPatrolDogsTitle =
                new Label();

            this.lblPatrolDogsCount =
                new Label();

            this.lblPatrolDogsUnit =
                new Label();

            this.lblNewDogsTitle =
                new Label();

            this.lblNewDogsCount =
                new Label();

            this.lblNewDogsUnit =
                new Label();

            this.lblActiveDogsTitle =
                new Label();

            this.lblActiveDogsCount =
                new Label();

            this.lblActiveDogsUnit =
                new Label();

            this.picAssignedDogs =
                new PictureBox();

            this.picPatrolDogs =
                new PictureBox();

            this.picNewDogs =
                new PictureBox();

            this.picActiveDogs =
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
                "Должность: Кинолог";

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
                "Работа со служебными собаками и кинологическими нарядами";

            // =====================================
            // IMAGE
            // =====================================

            this.picDogHandler.Image =
                global::PoliceStationIS.Properties.Resources.dog_main_icon;

            this.picDogHandler.Location =
                new Point(
                    980,
                    0);

            this.picDogHandler.Size =
                new Size(
                    280,
                    230);

            this.picDogHandler.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picDogHandler.BackColor =
                Color.Transparent;

            // =====================================
            // CARD SETTINGS
            // =====================================

            ConfigureCard(
                this.pnlAssignedDogs,
                30);

            ConfigureCard(
                this.pnlPatrolDogs,
                360);

            ConfigureCard(
                this.pnlNewDogs,
                690);

            ConfigureCard(
                this.pnlActiveDogs,
                1020);

            // =====================================
            // CARD 1
            // =====================================

            ConfigureCardIcon(
                this.picAssignedDogs,
                Properties.Resources.dog_card_1);

            ConfigureCardTitle(
                this.lblAssignedDogsTitle,
                "Закреплено собак");

            ConfigureCardValue(
                this.lblAssignedDogsCount);

            ConfigureCardUnit(
    this.lblAssignedDogsUnit,
    "соб.");

            // =====================================
            // CARD 2
            // =====================================

            ConfigureCardIcon(
                this.picPatrolDogs,
                Properties.Resources.dog_card_2);

            ConfigureCardTitle(
                this.lblPatrolDogsTitle,
                "Нарядов с собаками");

            ConfigureCardValue(
                this.lblPatrolDogsCount);

            ConfigureCardUnit(
    this.lblPatrolDogsUnit,
    "нар.");

            // =====================================
            // CARD 3
            // =====================================

            ConfigureCardIcon(
                this.picNewDogs,
                Properties.Resources.dog_card_3);

            ConfigureCardTitle(
                this.lblNewDogsTitle,
                "Новых собак");

            ConfigureCardValue(
                this.lblNewDogsCount);

            ConfigureCardUnit(
    this.lblNewDogsUnit,
    "соб.");

            // =====================================
            // CARD 4
            // =====================================

            ConfigureCardIcon(
                this.picActiveDogs,
                Properties.Resources.dog_card_4);

            ConfigureCardTitle(
                this.lblActiveDogsTitle,
                "Готовы к службе");

            ConfigureCardValue(
                this.lblActiveDogsCount);

            ConfigureCardUnit(
    this.lblActiveDogsUnit,
    "соб.");

            // =====================================
            // ADD TO CARDS
            // =====================================

            this.pnlAssignedDogs.Controls.Add(
                this.picAssignedDogs);

            this.pnlAssignedDogs.Controls.Add(
                this.lblAssignedDogsTitle);

            this.pnlAssignedDogs.Controls.Add(
                this.lblAssignedDogsCount);

            this.pnlAssignedDogs.Controls.Add(
                this.lblAssignedDogsUnit);

            // -------------------------------------

            this.pnlPatrolDogs.Controls.Add(
                this.picPatrolDogs);

            this.pnlPatrolDogs.Controls.Add(
                this.lblPatrolDogsTitle);

            this.pnlPatrolDogs.Controls.Add(
                this.lblPatrolDogsCount);

            this.pnlPatrolDogs.Controls.Add(
                this.lblPatrolDogsUnit);

            // -------------------------------------

            this.pnlNewDogs.Controls.Add(
                this.picNewDogs);

            this.pnlNewDogs.Controls.Add(
                this.lblNewDogsTitle);

            this.pnlNewDogs.Controls.Add(
                this.lblNewDogsCount);

            this.pnlNewDogs.Controls.Add(
                this.lblNewDogsUnit);

            // -------------------------------------

            this.pnlActiveDogs.Controls.Add(
                this.picActiveDogs);

            this.pnlActiveDogs.Controls.Add(
                this.lblActiveDogsTitle);

            this.pnlActiveDogs.Controls.Add(
                this.lblActiveDogsCount);

            this.pnlActiveDogs.Controls.Add(
                this.lblActiveDogsUnit);

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
                this.picDogHandler);

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
                "Dog",
                "Служебная собака");

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

            this.btnAddDog =
                new Button();

            this.btnViewDogs =
                new Button();

            this.btnAssignPatrol =
                new Button();

            this.picAddDog =
                new PictureBox();

            this.picViewDogs =
                new PictureBox();

            this.picAssignPatrol =
                new PictureBox();

            this.picArrowAdd =
                new PictureBox();

            this.picArrowView =
                new PictureBox();

            this.picArrowPatrol =
                new PictureBox();

            this.picDog =
                new PictureBox();

            // =====================================
            // QUICK ACTIONS BUTTONS
            // =====================================

            ConfigureActionButton(
                this.btnAddDog,
                "Добавить собаку",
                50);

            ConfigureActionButton(
                this.btnViewDogs,
                "Просмотреть собак",
                125);

            ConfigureActionButton(
                this.btnAssignPatrol,
                "Назначить на службу",
                200);

            ConfigureActionIcon(
                this.picAddDog,
                Properties.Resources.dog_add_gold_icon,
                50);

            ConfigureActionIcon(
                this.picViewDogs,
                Properties.Resources.dog_search_gold_icon,
                125);

            ConfigureActionIcon(
                this.picAssignPatrol,
                Properties.Resources.dog_patrol_gold_icon,
                200);

            ConfigureArrowIcon(
                this.picArrowAdd,
                50);

            ConfigureArrowIcon(
                this.picArrowView,
                125);

            ConfigureArrowIcon(
                this.picArrowPatrol,
                200);

            // =====================================
            // ADD BUTTONS
            // =====================================

            this.pnlQuickActions.Controls.Add(
                this.btnAddDog);

            this.pnlQuickActions.Controls.Add(
                this.picAddDog);

            this.pnlQuickActions.Controls.Add(
                this.picViewDogs);

            this.pnlQuickActions.Controls.Add(
                this.picAssignPatrol);

            this.picAddDog.BringToFront();
            this.picViewDogs.BringToFront();
            this.picAssignPatrol.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.btnViewDogs);

            this.pnlQuickActions.Controls.Add(
                this.btnAssignPatrol);

            this.pnlQuickActions.Controls.Add(
                this.picArrowAdd);

            this.pnlQuickActions.Controls.Add(
                this.picArrowView);

            this.pnlQuickActions.Controls.Add(
                this.picArrowPatrol);

            this.picArrowAdd.BringToFront();
            this.picArrowView.BringToFront();
            this.picArrowPatrol.BringToFront();

            this.pnlQuickActions.Controls.Add(
                this.picDog);

            this.picDog.SendToBack();

            // =====================================
            // DOG IMAGE
            // =====================================

            this.picDog.Image =
                Properties.Resources.dog_sil_gold_icon;

            this.picDog.BackColor =
                Color.Transparent;

            this.picDog.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picDog.Location =
                new Point(
                    145,
                    235);

            this.picDog.Size =
                new Size(
                    180,
                    190);

            // =====================================
            // ADD MAIN CONTROLS
            // =====================================

            this.Controls.Add(
                this.panelWelcome);

            this.Controls.Add(
                this.pnlAssignedDogs);

            this.Controls.Add(
                this.pnlPatrolDogs);

            this.Controls.Add(
                this.pnlNewDogs);

            this.Controls.Add(
                this.pnlActiveDogs);

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

            label.Text = "соб.";
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