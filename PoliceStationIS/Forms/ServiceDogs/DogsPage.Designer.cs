using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Dogs
{
    partial class DogsPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlSearch;
        private Panel pnlDogs;
        private Panel pnlDogInfo;

        private Label lblTitle;
        private Label lblSubtitle;

        private IconButton btnAddDog;
        private IconButton btnEditDog;
        private IconButton btnAssignDog;

        private Label lblSearch;
        private Label lblStampSearch;
        private Label lblNameSearch;

        private ComboBox cmbSearchStamp;
        private TextBox txtSearchName;

        private Button btnSearch;
        private Button btnReset;

        private Label lblDogs;
        private DataGridView dgvDogs;

        private Panel pnlPagination;
        private Button btnFirstPage;
        private Button btnPreviousPage;
        private Label lblPageInfo;
        private Button btnNextPage;
        private Button btnLastPage;

        private Label lblDogInfo;

        private Label lblStampTitle;
        private Label lblStampValue;

        private Label lblNameTitle;
        private Label lblNameValue;

        private Label lblBreedTitle;
        private Label lblBreedValue;

        private Label lblSexTitle;
        private Label lblSexValue;

        private Label lblStatusTitle;
        private Label lblStatusValue;

        private Label lblSpecializationTitle;
        private Label lblSpecializationValue;

        private Label lblEmployeeTitle;
        private Label lblEmployeeValue;

        private Label lblBirthTitle;
        private Label lblBirthValue;

        private Label lblHealthTitle;
        private Label lblHealthValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.SuspendLayout();

            //========================================================
            // PAGE
            //========================================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.Name =
                "DogsPage";

            this.Size =
                new Size(
                    1560,
                    900);

            //========================================================
            // HEADER
            //========================================================

            this.pnlHeader =
                new Panel();

            this.pnlHeader.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlHeader.Location =
                new Point(
                    20,
                    20);

            this.pnlHeader.Size =
                new Size(
                    825,
                    100);

            // TITLE

            this.lblTitle =
                new Label();

            this.lblTitle.AutoSize =
                true;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(
                    22,
                    14);

            this.lblTitle.Text =
                "Служебные собаки";

            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlTitleLine.Location =
                new Point(
                    27,
                    49);

            pnlTitleLine.Size =
                new Size(
                    26,
                    3);

            // SUBTITLE

            this.lblSubtitle =
                new Label();

            this.lblSubtitle.AutoSize =
                true;

            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(
                    25,
                    57);

            this.lblSubtitle.Text =
                "Реестр служебных собак и информация о закреплении";

            // ADD

            this.btnAddDog =
                new IconButton();

            this.btnAddDog.Text =
                "Добавить собаку";

            this.btnAddDog.ButtonIcon =
                Properties.Resources.dog_add_gold_icon;

            this.btnAddDog.Size =
                new Size(
                    170,
                    42);

            this.btnAddDog.Location =
                new Point(
                    425,
                    28);

            this.btnAddDog.FlatStyle =
                FlatStyle.Flat;

            this.btnAddDog.FlatAppearance.BorderSize =
                1;

            this.btnAddDog.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnAddDog.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnAddDog.ForeColor =
                Color.White;

            this.btnAddDog.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            // EDIT

            this.btnEditDog =
                new IconButton();

            this.btnEditDog.Text =
                "Редактировать";

            this.btnEditDog.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            this.btnEditDog.Size =
                new Size(
                    150,
                    42);

            this.btnEditDog.Location =
                new Point(
                    605,
                    28);

            this.btnEditDog.FlatStyle =
                FlatStyle.Flat;

            this.btnEditDog.FlatAppearance.BorderSize =
                1;

            this.btnEditDog.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnEditDog.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnEditDog.ForeColor =
                Color.White;

            this.btnEditDog.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.pnlHeader.Controls.Add(
                pnlTitleLine);

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.btnAddDog);

            this.pnlHeader.Controls.Add(
                this.btnEditDog);

            //========================================================
            // SEARCH
            //========================================================

            this.pnlSearch =
                new Panel();

            this.pnlSearch.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlSearch.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlSearch.Location =
                new Point(
                    20,
                    140);

            this.pnlSearch.Size =
                new Size(
                    825,
                    130);

            this.lblSearch =
                new Label();

            this.lblSearch.AutoSize =
                true;

            this.lblSearch.Text =
                "ПОИСК И ФИЛЬТРЫ";

            this.lblSearch.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblSearch.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblSearch.Location =
                new Point(
                    18,
                    12);

            this.pnlSearch.Controls.Add(
                this.lblSearch);

            Panel pnlSearchLine =
                new Panel();

            pnlSearchLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlSearchLine.Location =
                new Point(
                    18,
                    38);

            pnlSearchLine.Size =
                new Size(
                    790,
                    1);

            this.pnlSearch.Controls.Add(
                pnlSearchLine);

            // STAMP

            this.lblStampSearch =
                CreateSearchLabel(
                    "№ клейма",
                    20,
                    52);

            this.cmbSearchStamp =
                new ComboBox();

            this.cmbSearchStamp.Location =
                new Point(
                    20,
                    72);

            this.cmbSearchStamp.Size =
                new Size(
                    220,
                    25);

            this.cmbSearchStamp.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbSearchStamp.BackColor =
                Color.White;

            this.cmbSearchStamp.ForeColor =
                Color.Black;

            this.cmbSearchStamp.FlatStyle =
                FlatStyle.Flat;

            // NAME

            this.lblNameSearch =
                CreateSearchLabel(
                    "Кличка",
                    260,
                    52);

            this.txtSearchName =
                CreateSearchTextBox(
                    260,
                    72,
                    220);

            // SEARCH BUTTON

            this.btnSearch =
                CreateSearchButton(
                    "Найти",
                    610,
                    68);

            // RESET BUTTON

            this.btnReset =
                CreateResetButton(
                    "Сброс",
                    715,
                    68);

            this.pnlSearch.Controls.Add(
                this.lblStampSearch);

            this.pnlSearch.Controls.Add(
                this.cmbSearchStamp);

            this.pnlSearch.Controls.Add(
                this.lblNameSearch);

            this.pnlSearch.Controls.Add(
                this.txtSearchName);

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            //========================================================
            // DOGS TABLE PANEL
            //========================================================

            this.pnlDogs =
                new Panel();

            this.pnlDogs.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlDogs.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlDogs.Location =
                new Point(
                    20,
                    285);

            this.pnlDogs.Size =
                new Size(
                    825,
                    515);

            // TABLE TITLE

            this.lblDogs =
                new Label();

            this.lblDogs.AutoSize =
                true;

            this.lblDogs.Text =
                "СПИСОК СЛУЖЕБНЫХ СОБАК";

            this.lblDogs.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblDogs.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblDogs.Location =
                new Point(
                    18,
                    12);

            this.pnlDogs.Controls.Add(
                this.lblDogs);

            Panel pnlTableLine =
                new Panel();

            pnlTableLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlTableLine.Location =
                new Point(
                    18,
                    38);

            pnlTableLine.Size =
                new Size(
                    790,
                    1);

            this.pnlDogs.Controls.Add(
                pnlTableLine);

            // GRID

            this.dgvDogs =
                new DataGridView();

            this.dgvDogs.Location =
                new Point(
                    18,
                    52);

            this.dgvDogs.Size =
                new Size(
                    790,
                    390);

            this.pnlDogs.Controls.Add(
                this.dgvDogs);

            //========================================================
            // PAGINATION
            //========================================================

            this.pnlPagination =
                new Panel();

            this.pnlPagination.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlPagination.Location =
                new Point(
                    18,
                    455);

            this.pnlPagination.Size =
                new Size(
                    790,
                    38);

            // FIRST

            this.btnFirstPage =
                CreatePageButton(
                    "<<",
                    215);

            // PREVIOUS

            this.btnPreviousPage =
                CreatePageButton(
                    "<",
                    260);

            // PAGE INFO

            this.lblPageInfo =
                new Label();

            this.lblPageInfo.AutoSize =
                true;

            this.lblPageInfo.Text =
                "Страница 1 из 1";

            this.lblPageInfo.ForeColor =
                Color.White;

            this.lblPageInfo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblPageInfo.Location =
                new Point(
                    330,
                    11);

            // NEXT

            this.btnNextPage =
                CreatePageButton(
                    ">",
                    475);

            // LAST

            this.btnLastPage =
                CreatePageButton(
                    ">>",
                    520);

            this.pnlPagination.Controls.Add(
                this.btnFirstPage);

            this.pnlPagination.Controls.Add(
                this.btnPreviousPage);

            this.pnlPagination.Controls.Add(
                this.lblPageInfo);

            this.pnlPagination.Controls.Add(
                this.btnNextPage);

            this.pnlPagination.Controls.Add(
                this.btnLastPage);

            this.pnlDogs.Controls.Add(
                this.pnlPagination);

            //========================================================
            // RIGHT INFORMATION PANEL
            //========================================================

            this.pnlDogInfo =
                new Panel();

            this.pnlDogInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlDogInfo.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlDogInfo.Location =
                new Point(
                    865,
                    20);

            this.pnlDogInfo.Size =
                new Size(
                    455,
                    780);

            // INFO TITLE

            this.lblDogInfo =
                new Label();

            this.lblDogInfo.AutoSize =
                true;

            this.lblDogInfo.Text =
                "ИНФОРМАЦИЯ О СОБАКЕ";

            this.lblDogInfo.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblDogInfo.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblDogInfo.Location =
                new Point(
                    18,
                    15);

            this.pnlDogInfo.Controls.Add(
                this.lblDogInfo);

            Panel pnlDogInfoLine =
                new Panel();

            pnlDogInfoLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlDogInfoLine.Location =
                new Point(
                    18,
                    42);

            pnlDogInfoLine.Size =
                new Size(
                    420,
                    1);

            this.pnlDogInfo.Controls.Add(
                pnlDogInfoLine);

            // ASSIGN BUTTON

            this.btnAssignDog =
                new IconButton();

            this.btnAssignDog.Text =
                "Закрепить";

            this.btnAssignDog.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            this.btnAssignDog.Size =
                new Size(
                    140,
                    38);

            this.btnAssignDog.Location =
                new Point(
                    294,
                    55);

            this.btnAssignDog.FlatStyle =
                FlatStyle.Flat;

            this.btnAssignDog.FlatAppearance.BorderSize =
                1;

            this.btnAssignDog.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnAssignDog.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnAssignDog.ForeColor =
                Color.White;

            this.btnAssignDog.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.pnlDogInfo.Controls.Add(
                this.btnAssignDog);

            // INFORMATION FIELDS

            CreateInfoField(
                "№ клейма:",
                110,
                out lblStampTitle,
                out lblStampValue);

            CreateInfoField(
                "Кличка:",
                165,
                out lblNameTitle,
                out lblNameValue);

            CreateInfoField(
                "Порода:",
                220,
                out lblBreedTitle,
                out lblBreedValue);

            CreateInfoField(
                "Пол:",
                275,
                out lblSexTitle,
                out lblSexValue);

            CreateInfoField(
                "Статус:",
                330,
                out lblStatusTitle,
                out lblStatusValue);

            CreateInfoField(
                "Специализация:",
                385,
                out lblSpecializationTitle,
                out lblSpecializationValue);

            CreateInfoField(
                "Закреплён за:",
                440,
                out lblEmployeeTitle,
                out lblEmployeeValue);

            CreateInfoField(
                "Дата рождения:",
                495,
                out lblBirthTitle,
                out lblBirthValue);

            CreateInfoField(
                "Здоровье:",
                550,
                out lblHealthTitle,
                out lblHealthValue);

            //========================================================
            // ADD CONTROLS
            //========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlDogs);

            this.Controls.Add(
                this.pnlDogInfo);

            this.ResumeLayout(false);
        }

        private Label CreateSearchLabel(
            string text,
            int left,
            int top)
        {
            Label label =
                new Label();

            label.AutoSize = true;
            label.Text = text;
            label.ForeColor = Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.Location =
                new Point(
                    left,
                    top);

            return label;
        }

        private TextBox CreateSearchTextBox(
            int left,
            int top,
            int width)
        {
            TextBox textBox =
                new TextBox();

            textBox.Location =
                new Point(
                    left,
                    top);

            textBox.Size =
                new Size(
                    width,
                    25);

            textBox.BackColor =
                Color.White;

            textBox.ForeColor =
                Color.Black;

            textBox.BorderStyle =
                BorderStyle.FixedSingle;

            return textBox;
        }

        private Button CreateSearchButton(
            string text,
            int left,
            int top)
        {
            Button button =
                new Button();

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Text =
                text;

            button.Size =
                new Size(
                    95,
                    34);

            button.Location =
                new Point(
                    left,
                    top);

            return button;
        }

        private Button CreateResetButton(
            string text,
            int left,
            int top)
        {
            Button button =
                CreateSearchButton(
                    text,
                    left,
                    top);

            button.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            return button;
        }

        private Button CreatePageButton(
            string text,
            int left)
        {
            Button button =
                new Button();

            button.Text =
                text;

            button.Size =
                new Size(
                    40,
                    28);

            button.Location =
                new Point(
                    left,
                    5);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.FlatAppearance.BorderSize =
                1;

            button.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            button.ForeColor =
                Color.White;

            return button;
        }

        private void CreateInfoField(
            string title,
            int y,
            out Label titleLabel,
            out Label valueLabel)
        {
            titleLabel =
                new Label();

            titleLabel.AutoSize =
                true;

            titleLabel.Text =
                title;

            titleLabel.ForeColor =
                Color.White;

            titleLabel.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            titleLabel.Location =
                new Point(
                    18,
                    y);

            valueLabel =
                new Label();

            valueLabel.AutoSize =
    false;

            valueLabel.Size =
                new Size(
                    215,
                    24);

            valueLabel.AutoEllipsis =
                true;

            valueLabel.Text =
                "—";

            valueLabel.ForeColor =
                Color.Gainsboro;

            valueLabel.Font =
                new Font(
                    "Segoe UI",
                    10F);

            valueLabel.Location =
                new Point(
                    220,
                    y);

            Panel line =
                new Panel();

            line.BackColor =
                Color.FromArgb(
                    50,
                    70,
                    110);

            line.Location =
                new Point(
                    18,
                    y + 30);

            line.Size =
                new Size(
                    420,
                    1);

            this.pnlDogInfo.Controls.Add(
                titleLabel);

            this.pnlDogInfo.Controls.Add(
                valueLabel);

            this.pnlDogInfo.Controls.Add(
                line);
        }
    }
}
