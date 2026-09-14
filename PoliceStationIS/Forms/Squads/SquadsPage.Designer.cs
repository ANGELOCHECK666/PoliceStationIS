using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Squads
{
    partial class SquadsPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlSearch;
        private Panel pnlSquads;
        private Panel pnlInfo;
        private Panel pnlEvents;

        private Label lblTitle;
        private Label lblSubtitle;

        private Button btnAddSquad;
        private Button btnEditSquad;
        private Button btnAddEvent;
        private PictureBox picAddSquadIcon;
        private PictureBox picEditSquadIcon;

        private Label lblSearchTitle;

        private Label lblSquadNumber;
        private Label lblSquadType;
        private Label lblStatus;
        private Label lblEmployee;

        private Label lblDateFrom;
        private Label lblDateTo;

        private TextBox txtSquadNumber;

        private ComboBox cmbSquadType;
        private ComboBox cmbStatus;
        private ComboBox cmbEmployee;

        private DateTimePicker dtDateFrom;
        private DateTimePicker dtDateTo;

        private Button btnSearch;
        private Button btnReset;

        private Label lblSquadsTitle;

        private FlowLayoutPanel flpSquads;

        private Button btnFirstPage;
        private Button btnPreviousPage;
        private Label lblPageInfo;
        private Button btnNextPage;
        private Button btnLastPage;

        private Label lblInfoTitle;

        private Label lblTabMain;
        private Label lblTabComposition;
        private Label lblTabSchedule;
        private Label lblTabRoute;

        private Panel pnlTabLine;

        private Label lblInfo1Title;
        private Label lblInfo1Value;

        private Label lblInfo2Title;
        private Label lblInfo2Value;

        private Label lblInfo3Title;
        private Label lblInfo3Value;

        private Label lblInfo4Title;
        private Label lblInfo4Value;

        private Label lblInfo5Title;
        private Label lblInfo5Value;

        private Label lblInfo6Title;
        private Label lblInfo6Value;

        private Label lblInfo7Title;
        private Label lblInfo7Value;

        private Label lblEventsTitle;

        private FlowLayoutPanel flpEvents;

        private Button btnOpenFullJournal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ========================================================
            // ОСНОВНАЯ СТРАНИЦА
            // ========================================================

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.Name =
                "SquadsPage";

            this.Size =
                new Size(1560, 900);


            // ========================================================
            // HEADER
            // ========================================================

            pnlHeader = new Panel();

            pnlHeader.BackColor =
                Color.FromArgb(30, 58, 117);

            pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            pnlHeader.Location =
                new Point(20, 20);

            pnlHeader.Size =
                new Size(1300, 100);


            // TITLE

            lblTitle = new Label();

            lblTitle.Text =
                "Наряды";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(25, 15);


            // GOLD LINE

            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTitleLine.Location =
                new Point(30, 50);

            pnlTitleLine.Size =
                new Size(28, 3);


            // SUBTITLE

            lblSubtitle = new Label();

            lblSubtitle.Text =
                "Управление нарядами, графиком службы и патрульными событиями";

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblSubtitle.ForeColor =
                Color.Gainsboro;

            lblSubtitle.AutoSize =
                true;

            lblSubtitle.Location =
                new Point(28, 58);


            // ADD BUTTON

            btnAddSquad = CreateHeaderButton(
                "Добавить наряд");

            btnAddSquad.Location =
                new Point(660, 28);

            btnAddSquad.Size =
                new Size(200, 42);

            btnAddSquad.TextAlign =
                ContentAlignment.MiddleLeft;

            btnAddSquad.Padding =
                new Padding(
                    42,
                    0,
                    10,
                    0);


            // ADD BUTTON ICON

            picAddSquadIcon =
                new PictureBox();

            picAddSquadIcon.Image =
                Properties.Resources.oform_naryd;

            picAddSquadIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            picAddSquadIcon.BackColor =
                Color.Transparent;
            picAddSquadIcon.Visible =
    true;

            picAddSquadIcon.Size =
                new Size(
                    22,
                    22);

            picAddSquadIcon.Location =
                new Point(
                    672,
                    38);


            // EDIT BUTTON

            btnEditSquad = CreateHeaderButton(
                "Редактировать наряд");

            btnEditSquad.Location =
                new Point(870, 28);

            btnEditSquad.Size =
                new Size(200, 42);

            btnEditSquad.TextAlign =
                ContentAlignment.MiddleLeft;

            btnEditSquad.Padding =
                new Padding(
                    42,
                    0,
                    10,
                    0);


            // ADD EVENT BUTTON

            btnAddEvent = CreateHeaderButton(
                "Добавить событие");

            btnAddEvent.Location =
                new Point(1080, 28);

            btnAddEvent.Size =
                new Size(200, 42);

            btnAddEvent.TextAlign =
                ContentAlignment.MiddleCenter;


            // EDIT BUTTON ICON

            picEditSquadIcon =
                new PictureBox();

            picEditSquadIcon.Image =
                Properties.Resources.edit_gold_icon;

            picEditSquadIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            picEditSquadIcon.BackColor =
                Color.Transparent;
            picEditSquadIcon.Visible =
    true;

            picEditSquadIcon.Size =
                new Size(
                    22,
                    22);

            picEditSquadIcon.Location =
                new Point(
                    882,
                    38);


            pnlHeader.Controls.Add(pnlTitleLine);

            pnlHeader.Controls.Add(lblTitle);

            pnlHeader.Controls.Add(lblSubtitle);

            pnlHeader.Controls.Add(btnAddSquad);
            pnlHeader.Controls.Add(picAddSquadIcon);

            pnlHeader.Controls.Add(btnEditSquad);
            pnlHeader.Controls.Add(picEditSquadIcon);
            pnlHeader.Controls.Add(btnAddEvent);

            picAddSquadIcon.BringToFront();
            picEditSquadIcon.BringToFront();


            // ========================================================
            // SEARCH PANEL
            // ========================================================

            pnlSearch = new Panel();

            pnlSearch.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlSearch.BorderStyle =
                BorderStyle.FixedSingle;

            pnlSearch.Location =
                new Point(20, 140);

            pnlSearch.Size =
                new Size(855, 155);


            lblSearchTitle = new Label();

            lblSearchTitle.Text =
                "ПОИСК И ФИЛЬТРЫ";

            lblSearchTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblSearchTitle.ForeColor =
                Color.FromArgb(212, 160, 23);

            lblSearchTitle.AutoSize =
                true;

            lblSearchTitle.Location =
                new Point(18, 12);


            Panel pnlSearchLine =
                new Panel();

            pnlSearchLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlSearchLine.Location =
                new Point(18, 38);

            pnlSearchLine.Size =
                new Size(815, 1);


            // NUMBER

            lblSquadNumber = CreateFieldLabel(
                "№ наряда",
                20,
                52);

            txtSquadNumber = new TextBox();

            txtSquadNumber.Location =
                new Point(20, 72);

            txtSquadNumber.Size =
                new Size(175, 26);


            // TYPE

            lblSquadType = CreateFieldLabel(
                "Тип наряда",
                215,
                52);

            cmbSquadType = CreateComboBox(
                215,
                72,
                190);


            // STATUS

            lblStatus = CreateFieldLabel(
                "Статус",
                425,
                52);

            cmbStatus = CreateComboBox(
                425,
                72,
                190);


            // EMPLOYEE

            lblEmployee = CreateFieldLabel(
                "Сотрудник",
                635,
                52);

            cmbEmployee = CreateComboBox(
                635,
                72,
                195);


            // DATE FROM

            lblDateFrom = CreateFieldLabel(
                "Дата службы с",
                20,
                108);

            dtDateFrom = CreateDatePicker(
                20,
                128,
                125);


            // DATE TO

            lblDateTo = CreateFieldLabel(
                "Дата службы по",
                160,
                108);

            dtDateTo = CreateDatePicker(
                160,
                128,
                125);


            // SEARCH

            btnSearch = CreateSearchButton(
                "Найти");

            btnSearch.Location =
                new Point(650, 112);


            // RESET

            btnReset = CreateResetButton(
                "Сброс");

            btnReset.Location =
                new Point(745, 112);


            pnlSearch.Controls.Add(lblSearchTitle);
            pnlSearch.Controls.Add(pnlSearchLine);

            pnlSearch.Controls.Add(lblSquadNumber);
            pnlSearch.Controls.Add(txtSquadNumber);

            pnlSearch.Controls.Add(lblSquadType);
            pnlSearch.Controls.Add(cmbSquadType);

            pnlSearch.Controls.Add(lblStatus);
            pnlSearch.Controls.Add(cmbStatus);

            pnlSearch.Controls.Add(lblEmployee);
            pnlSearch.Controls.Add(cmbEmployee);

            pnlSearch.Controls.Add(lblDateFrom);
            pnlSearch.Controls.Add(dtDateFrom);

            pnlSearch.Controls.Add(lblDateTo);
            pnlSearch.Controls.Add(dtDateTo);

            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnReset);


            // ========================================================
            // SQUADS LIST
            // ========================================================

            pnlSquads = new Panel();

            pnlSquads.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlSquads.BorderStyle =
                BorderStyle.FixedSingle;

            pnlSquads.Location =
                new Point(20, 310);

            pnlSquads.Size =
                new Size(855, 520);


            lblSquadsTitle = new Label();

            lblSquadsTitle.Text =
                "СПИСОК НАРЯДОВ";

            lblSquadsTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblSquadsTitle.ForeColor =
                Color.FromArgb(212, 160, 23);

            lblSquadsTitle.AutoSize =
                true;

            lblSquadsTitle.Location =
                new Point(18, 12);


            Panel pnlSquadsLine =
                new Panel();

            pnlSquadsLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlSquadsLine.Location =
                new Point(18, 38);

            pnlSquadsLine.Size =
                new Size(815, 1);


            flpSquads = new FlowLayoutPanel();

            flpSquads.Location =
                new Point(18, 50);

            flpSquads.Size =
                new Size(815, 390);

            flpSquads.AutoScroll =
                true;

            flpSquads.FlowDirection =
                FlowDirection.TopDown;

            flpSquads.WrapContents =
                false;

            flpSquads.BackColor =
                Color.Transparent;


            // PAGINATION

            btnFirstPage =
                CreatePaginationButton("<<");

            btnFirstPage.Location =
                new Point(240, 450);

            btnPreviousPage =
                CreatePaginationButton("<");

            btnPreviousPage.Location =
                new Point(285, 450);

            lblPageInfo = new Label();

            lblPageInfo.Text =
                "0–0 из 0";

            lblPageInfo.ForeColor =
                Color.Gainsboro;

            lblPageInfo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblPageInfo.AutoSize =
                true;

            lblPageInfo.Location =
                new Point(385, 458);

            btnNextPage =
                CreatePaginationButton(">");

            btnNextPage.Location =
                new Point(625, 450);

            btnLastPage =
                CreatePaginationButton(">>");

            btnLastPage.Location =
                new Point(670, 450);


            pnlSquads.Controls.Add(lblSquadsTitle);
            pnlSquads.Controls.Add(pnlSquadsLine);
            pnlSquads.Controls.Add(flpSquads);

            pnlSquads.Controls.Add(btnFirstPage);
            pnlSquads.Controls.Add(btnPreviousPage);
            pnlSquads.Controls.Add(lblPageInfo);
            pnlSquads.Controls.Add(btnNextPage);
            pnlSquads.Controls.Add(btnLastPage);


            // ========================================================
            // INFORMATION PANEL
            // ========================================================

            pnlInfo = new Panel();

            pnlInfo.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlInfo.BorderStyle =
                BorderStyle.FixedSingle;

            pnlInfo.Location =
                new Point(895, 140);

            pnlInfo.Size =
                new Size(425, 385);


            lblInfoTitle = new Label();

            lblInfoTitle.Text =
                "ИНФОРМАЦИЯ О НАРЯДЕ";

            lblInfoTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblInfoTitle.ForeColor =
                Color.FromArgb(212, 160, 23);

            lblInfoTitle.AutoSize =
                true;

            lblInfoTitle.Location =
                new Point(18, 12);


            Panel pnlInfoLine =
                new Panel();

            pnlInfoLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlInfoLine.Location =
                new Point(18, 38);

            pnlInfoLine.Size =
                new Size(385, 1);


            // TABS

            lblTabMain =
                CreateTab("Основное", 20);

            lblTabComposition =
                CreateTab("Состав", 115);

            lblTabSchedule =
                CreateTab("График", 190);

            lblTabRoute =
                CreateTab("Маршрут", 275);


            pnlTabLine = new Panel();

            pnlTabLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTabLine.Location =
                new Point(18, 80);

            pnlTabLine.Size =
                new Size(75, 2);


            // INFORMATION FIELDS

            lblInfo1Title = CreateInfoTitle(20, 105);
            lblInfo1Value = CreateInfoValue(175, 105);

            lblInfo2Title = CreateInfoTitle(20, 145);
            lblInfo2Value = CreateInfoValue(175, 145);

            lblInfo3Title = CreateInfoTitle(20, 185);
            lblInfo3Value = CreateInfoValue(175, 185);

            lblInfo4Title = CreateInfoTitle(20, 225);
            lblInfo4Value = CreateInfoValue(175, 225);

            lblInfo5Title = CreateInfoTitle(20, 265);
            lblInfo5Value = CreateInfoValue(175, 265);

            lblInfo6Title = CreateInfoTitle(20, 305);
            lblInfo6Value = CreateInfoValue(175, 305);

            lblInfo7Title = CreateInfoTitle(20, 345);
            lblInfo7Value = CreateInfoValue(175, 345);


            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Controls.Add(pnlInfoLine);

            pnlInfo.Controls.Add(lblTabMain);
            pnlInfo.Controls.Add(lblTabComposition);
            pnlInfo.Controls.Add(lblTabSchedule);
            pnlInfo.Controls.Add(lblTabRoute);

            pnlInfo.Controls.Add(pnlTabLine);

            pnlInfo.Controls.Add(lblInfo1Title);
            pnlInfo.Controls.Add(lblInfo1Value);

            pnlInfo.Controls.Add(lblInfo2Title);
            pnlInfo.Controls.Add(lblInfo2Value);

            pnlInfo.Controls.Add(lblInfo3Title);
            pnlInfo.Controls.Add(lblInfo3Value);

            pnlInfo.Controls.Add(lblInfo4Title);
            pnlInfo.Controls.Add(lblInfo4Value);

            pnlInfo.Controls.Add(lblInfo5Title);
            pnlInfo.Controls.Add(lblInfo5Value);

            pnlInfo.Controls.Add(lblInfo6Title);
            pnlInfo.Controls.Add(lblInfo6Value);

            pnlInfo.Controls.Add(lblInfo7Title);
            pnlInfo.Controls.Add(lblInfo7Value);


            // ========================================================
            // EVENTS PANEL
            // ========================================================

            pnlEvents = new Panel();

            pnlEvents.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlEvents.BorderStyle =
                BorderStyle.FixedSingle;

            pnlEvents.Location =
                new Point(895, 540);

            pnlEvents.Size =
                new Size(425, 285);


            lblEventsTitle = new Label();

            lblEventsTitle.Text =
                "ПОСЛЕДНИЕ СОБЫТИЯ НАРЯДА";

            lblEventsTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblEventsTitle.ForeColor =
                Color.FromArgb(212, 160, 23);

            lblEventsTitle.AutoSize =
                true;

            lblEventsTitle.Location =
                new Point(18, 12);


            Panel pnlEventsLine =
                new Panel();

            pnlEventsLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlEventsLine.Location =
                new Point(18, 38);

            pnlEventsLine.Size =
                new Size(385, 1);


            flpEvents = new FlowLayoutPanel();

            flpEvents.Location =
                new Point(15, 50);

            flpEvents.Size =
                new Size(390, 160);

            flpEvents.AutoScroll =
                true;

            flpEvents.FlowDirection =
                FlowDirection.TopDown;

            flpEvents.WrapContents =
                false;


            btnOpenFullJournal =
                CreateJournalButton(
                    "☰   Открыть полный журнал событий");

            btnOpenFullJournal.Location =
                new Point(15, 225);

            btnOpenFullJournal.Size =
                new Size(390, 42);


            pnlEvents.Controls.Add(lblEventsTitle);
            pnlEvents.Controls.Add(pnlEventsLine);
            pnlEvents.Controls.Add(flpEvents);
            pnlEvents.Controls.Add(btnOpenFullJournal);


            // ========================================================
            // ADD ALL PANELS
            // ========================================================

            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlSearch);
            this.Controls.Add(pnlSquads);
            this.Controls.Add(pnlInfo);
            this.Controls.Add(pnlEvents);

            this.ResumeLayout(false);
        }


        // ========================================================
        // HELPERS
        // ========================================================

        private Button CreateHeaderButton(string text)
        {
            Button button = new Button();

            button.Text = text;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(42, 73, 133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;

            button.UseVisualStyleBackColor =
        false;

            return button;
        }

        private Label CreateFieldLabel(
            string text,
            int x,
            int y)
        {
            Label label = new Label();

            label.Text = text;

            label.AutoSize = true;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.Location =
                new Point(x, y);

            return label;
        }

        private ComboBox CreateComboBox(
            int x,
            int y,
            int width)
        {
            ComboBox comboBox =
                new ComboBox();

            comboBox.Location =
                new Point(x, y);

            comboBox.Size =
                new Size(width, 26);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            return comboBox;
        }

        private DateTimePicker CreateDatePicker(
            int x,
            int y,
            int width)
        {
            DateTimePicker picker =
                new DateTimePicker();

            picker.Location =
                new Point(x, y);

            picker.Size =
                new Size(width, 25);

            picker.Format =
                DateTimePickerFormat.Short;

            picker.ShowCheckBox =
                true;

            picker.Checked =
                false;

            return picker;
        }

        private Button CreateSearchButton(string text)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Size =
                new Size(85, 32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(196, 145, 35);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }

        private Button CreateResetButton(string text)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Size =
                new Size(85, 32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(42, 73, 133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }

        private Button CreatePaginationButton(string text)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Size =
                new Size(40, 32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(18, 38, 74);

            button.ForeColor =
                Color.White;

            return button;
        }

        private Label CreateTab(
            string text,
            int x)
        {
            Label label =
                new Label();

            label.Text = text;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.AutoSize =
                true;

            label.Location =
                new Point(x, 58);

            label.Cursor =
                Cursors.Hand;

            return label;
        }

        private Label CreateInfoTitle(
            int x,
            int y)
        {
            Label label =
                new Label();

            label.AutoSize =
                true;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.White;

            label.Location =
                new Point(x, y);

            return label;
        }

        private Label CreateInfoValue(
            int x,
            int y)
        {
            Label label =
                new Label();

            label.AutoSize =
                false;

            label.Size =
                new Size(220, 32);

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.ForeColor =
                Color.Gainsboro;

            label.Location =
                new Point(x, y);

            return label;
        }

        private Button CreateJournalButton(
            string text)
        {
            Button button =
                new Button();

            button.Text = text;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(42, 73, 133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }
    }
}
