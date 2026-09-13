using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Citizens
{
    partial class CitizensPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        //========================================================
        // ОСНОВНЫЕ ПАНЕЛИ
        //========================================================

        private Panel pnlHeader;

        private Panel pnlSearch;

        private Panel pnlCitizens;

        private Panel pnlCitizenInfo;

        //========================================================
        // HEADER
        //========================================================

        private Label lblTitle;

        private Label lblSubtitle;

        private IconButton btnAddCitizen;

        private IconButton btnEditCitizen;

        //========================================================
        // SEARCH
        //========================================================

        private Label lblSearch;

        private Label lblLastName;

        private Label lblFirstName;

        private Label lblMiddleName;

        private Label lblBirthDate;

        private Label lblGender;

        private Label lblPassport;

        private TextBox txtLastName;

        private TextBox txtFirstName;

        private TextBox txtMiddleName;

        private DateTimePicker dtBirthDate;

        private ComboBox cmbGender;

        private TextBox txtPassport;

        private Button btnSearch;

        private Button btnReset;

        //========================================================
        // CITIZENS TABLE
        //========================================================

        private Label lblCitizens;

        private DataGridView dgvCitizens;

        private Panel pnlPagination;

        private Button btnFirstPage;

        private Button btnPreviousPage;

        private Label lblPageInfo;

        private Button btnNextPage;

        private Button btnLastPage;

        //========================================================
        // CITIZEN INFO
        //========================================================

        private Label lblCitizenInfo;

        private Panel pnlTabs;

        private Panel pnlContent;

        private Panel pnlGeneralContent;

        private Panel pnlDocumentsContent;

        private Panel pnlCasesContent;

        private Panel pnlHistoryContent;

        private Panel pnlTabGeneral;
        private Panel pnlTabDocuments;
        private Panel pnlTabCases;
        private Panel pnlTabHistory;

        private Label lblTabGeneral;
        private Label lblTabDocuments;
        private Label lblTabCases;
        private Label lblTabHistory;

        private Panel pnlActiveTab;

        private PictureBox picCitizen;

        private Label lblCitizenNameHeader;
        private Label lblCitizenGenderHeader;
        private Label lblCitizenAgeHeader;
        private PictureBox picGenderIcon;
        private PictureBox picAgeIcon;

        //========================================================
        // GENERAL INFORMATION
        //========================================================

        private Label lblBirthTitle;
        private Label lblBirthValue;

        private Label lblGenderTitle;
        private Label lblGenderValue;

        private Label lblAgeTitle;
        private Label lblAgeValue;

        private Label lblBirthPlaceTitle;
        private Label lblBirthPlaceValue;

        private Label lblCitizenshipTitle;
        private Label lblCitizenshipValue;

        private Label lblPhoneTitle;
        private Label lblPhoneValue;

        private Label lblEmailTitle;
        private Label lblEmailValue;

        private Label lblRegistrationTitle;
        private Label lblRegistrationValue;

        private Label lblResidenceTitle;
        private Label lblResidenceValue;

        private Panel lineBirth;
        private Panel lineGender;
        private Panel lineAge;
        private Panel lineBirthPlace;
        private Panel lineCitizenship;
        private Panel linePhone;
        private Panel lineEmail;
        private Panel lineRegistration;

        //========================================================
        // PASSPORT INFORMATION
        //========================================================

        private Label lblPassportHeader;

        private Panel pnlPassportLine;

        private Label lblSeriesTitle;
        private Label lblSeriesValue;

        private Label lblNumberTitle;
        private Label lblNumberValue;

        private Label lblIssueDateTitle;
        private Label lblIssueDateValue;

        private Label lblIssuedByTitle;
        private Label lblIssuedByValue;

        private Label lblDepartmentCodeTitle;
        private Label lblDepartmentCodeValue;

        private Panel lineSeries;
        private Panel lineNumber;
        private Panel lineIssueDate;
        private Panel lineIssuedBy;

        private Label lblMaritalStatusTitle;
        private Label lblMaritalStatusValue;

        private Panel lineMaritalStatus;

        //========================================================
        // CASES
        //========================================================

        private FlowLayoutPanel flpCitizenCases;

        //========================================================
        // HISTORY
        //========================================================

        private FlowLayoutPanel flpCitizenHistory;

        //========================================================
        // INITIALIZE
        //========================================================

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.SuspendLayout();

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.Name =
                "CitizensPage";

            this.Size =
                new Size(
                    1560,
                    900);

            //========================================================
            // HEADER PANEL
            //========================================================

            this.pnlHeader =
                new Panel();

            this.pnlHeader.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlHeader.Location =
                new Point(
                    20,
                    20);

            this.pnlHeader.Size =
                new Size(
                    825,
                    100);

            this.pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            //========================================================
            // TITLE
            //========================================================

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
                "Граждане";

            //========================================================
            // GOLD LINE
            //========================================================

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

            //========================================================
            // SUBTITLE
            //========================================================

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
                "Реестр граждан и просмотр персональных данных";

            //========================================================
            // BUTTON "ADD"
            //========================================================

            this.btnAddCitizen =
                new IconButton();

            this.btnAddCitizen.Text =
                "Добавить гражданина";

            this.btnAddCitizen.ButtonIcon =
                Properties.Resources.citizen_add_gold_icon;

            this.btnAddCitizen.Size =
                new Size(
                    195,
                    42);

            this.btnAddCitizen.Location =
                new Point(
                    425,
                    28);

            this.btnAddCitizen.FlatStyle =
                FlatStyle.Flat;

            this.btnAddCitizen.FlatAppearance.BorderSize =
                1;

            this.btnAddCitizen.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnAddCitizen.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnAddCitizen.ForeColor =
                Color.White;

            this.btnAddCitizen.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            //========================================================
            // BUTTON "EDIT"
            //========================================================

            this.btnEditCitizen =
                new IconButton();

            this.btnEditCitizen.Text =
                "Редактировать";

            this.btnEditCitizen.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            this.btnEditCitizen.Size =
                new Size(
                    175,
                    42);

            this.btnEditCitizen.Location =
                new Point(
                    640,
                    28);

            this.btnEditCitizen.FlatStyle =
                FlatStyle.Flat;

            this.btnEditCitizen.FlatAppearance.BorderSize =
                1;

            this.btnEditCitizen.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnEditCitizen.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnEditCitizen.ForeColor =
                Color.White;

            this.btnEditCitizen.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            //========================================================
            // ADD HEADER CONTROLS
            //========================================================

            this.pnlHeader.Controls.Add(
                pnlTitleLine);

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.btnAddCitizen);

            this.pnlHeader.Controls.Add(
                this.btnEditCitizen);

            //========================================================
            // SEARCH PANEL (EMPTY)
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
                    160);

            //========================================================
            // SEARCH TITLE
            //========================================================

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

            //========================================================
            // LAST NAME
            //========================================================

            this.lblLastName =
                new Label();

            this.lblLastName.AutoSize =
                true;

            this.lblLastName.Text =
                "Фамилия";

            this.lblLastName.ForeColor =
                Color.Gainsboro;

            this.lblLastName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblLastName.Location =
                new Point(
                    20,
                    52);

            this.txtLastName =
                new TextBox();

            this.txtLastName.Location =
                new Point(
                    20,
                    72);

            this.txtLastName.Size =
                new Size(
                    220,
                    25);

            //========================================================
            // FIRST NAME
            //========================================================

            this.lblFirstName =
                new Label();

            this.lblFirstName.AutoSize =
                true;

            this.lblFirstName.Text =
                "Имя";

            this.lblFirstName.ForeColor =
                Color.Gainsboro;

            this.lblFirstName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblFirstName.Location =
                new Point(
                    260,
                    52);

            this.txtFirstName =
                new TextBox();

            this.txtFirstName.Location =
                new Point(
                    260,
                    72);

            this.txtFirstName.Size =
                new Size(
                    220,
                    25);

            //========================================================
            // MIDDLE NAME
            //========================================================

            this.lblMiddleName =
                new Label();

            this.lblMiddleName.AutoSize =
                true;

            this.lblMiddleName.Text =
                "Отчество";

            this.lblMiddleName.ForeColor =
                Color.Gainsboro;

            this.lblMiddleName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblMiddleName.Location =
                new Point(
                    500,
                    52);

            this.txtMiddleName =
                new TextBox();

            this.txtMiddleName.Location =
                new Point(
                    500,
                    72);

            this.txtMiddleName.Size =
                new Size(
                    290,
                    25);

            //========================================================
            // ADD FIRST ROW
            //========================================================

            this.pnlSearch.Controls.Add(
                this.lblLastName);

            this.pnlSearch.Controls.Add(
                this.txtLastName);

            this.pnlSearch.Controls.Add(
                this.lblFirstName);

            this.pnlSearch.Controls.Add(
                this.txtFirstName);

            this.pnlSearch.Controls.Add(
                this.lblMiddleName);

            this.pnlSearch.Controls.Add(
                this.txtMiddleName);

            //========================================================
            // BIRTH DATE
            //========================================================

            this.lblBirthDate =
                new Label();

            this.lblBirthDate.AutoSize =
                true;

            this.lblBirthDate.Text =
                "Дата рождения";

            this.lblBirthDate.ForeColor =
                Color.Gainsboro;

            this.lblBirthDate.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblBirthDate.Location =
                new Point(
                    20,
                    105);

            this.dtBirthDate =
                new DateTimePicker();

            this.dtBirthDate.Format =
                DateTimePickerFormat.Short;

            this.dtBirthDate.ShowCheckBox =
                true;

            this.dtBirthDate.Checked =
                false;

            this.dtBirthDate.Location =
                new Point(
                    20,
                    125);

            this.dtBirthDate.Size =
                new Size(
                    180,
                    25);

            //========================================================
            // GENDER
            //========================================================

            this.lblGender =
                new Label();

            this.lblGender.AutoSize =
                true;

            this.lblGender.Text =
                "Пол";

            this.lblGender.ForeColor =
                Color.Gainsboro;

            this.lblGender.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblGender.Location =
                new Point(
                    220,
                    105);

            this.cmbGender =
                new ComboBox();

            this.cmbGender.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbGender.Location =
                new Point(
                    220,
                    125);

            this.cmbGender.Size =
                new Size(
                    170,
                    25);

            //========================================================
            // PASSPORT
            //========================================================

            this.lblPassport =
                new Label();

            this.lblPassport.AutoSize =
                true;

            this.lblPassport.Text =
                "Паспорт";

            this.lblPassport.ForeColor =
                Color.Gainsboro;

            this.lblPassport.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblPassport.Location =
                new Point(
                    410,
                    105);

            this.txtPassport =
                new TextBox();

            this.txtPassport.Location =
                new Point(
                    410,
                    125);

            this.txtPassport.Size =
                new Size(
                    180,
                    25);

            //========================================================
            // SEARCH BUTTON
            //========================================================

            this.btnSearch =
                new Button();

            this.btnSearch.FlatStyle =
                FlatStyle.Flat;

            this.btnSearch.FlatAppearance.BorderSize =
                1;

            this.btnSearch.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnSearch.BackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.btnSearch.ForeColor =
                Color.White;

            this.btnSearch.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnSearch.Text =
                "Найти";

            this.btnSearch.Size =
                new Size(
                    95,
                    34);

            this.btnSearch.Location =
                new Point(
                    610,
                    119);

            //========================================================
            // RESET BUTTON
            //========================================================

            this.btnReset =
                new Button();

            this.btnReset.FlatStyle =
                FlatStyle.Flat;

            this.btnReset.FlatAppearance.BorderSize =
                1;

            this.btnReset.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnReset.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnReset.ForeColor =
                Color.White;

            this.btnReset.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnReset.Text =
                "Сброс";

            this.btnReset.Size =
                new Size(
                    95,
                    34);

            this.btnReset.Location =
                new Point(
                    715,
                    119);

            //========================================================
            // ADD SECOND ROW
            //========================================================

            this.pnlSearch.Controls.Add(
                this.lblBirthDate);

            this.pnlSearch.Controls.Add(
                this.dtBirthDate);

            this.pnlSearch.Controls.Add(
                this.lblGender);

            this.pnlSearch.Controls.Add(
                this.cmbGender);

            this.pnlSearch.Controls.Add(
                this.lblPassport);

            this.pnlSearch.Controls.Add(
                this.txtPassport);

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            //========================================================
            // CITIZENS PANEL (EMPTY)
            //========================================================

            this.pnlCitizens =
                new Panel();

            this.pnlCitizens.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlCitizens.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlCitizens.Location =
    new Point(
        20,
        315);

            this.pnlCitizens.Size =
                new Size(
                    825,
                    485);

            //========================================================
            // TABLE TITLE
            //========================================================

            this.lblCitizens =
                new Label();

            this.lblCitizens.AutoSize =
                true;

            this.lblCitizens.Text =
                "СПИСОК ГРАЖДАН";

            this.lblCitizens.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblCitizens.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblCitizens.Location =
                new Point(
                    18,
                    12);

            this.pnlCitizens.Controls.Add(
                this.lblCitizens);

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

            this.pnlCitizens.Controls.Add(
                pnlTableLine);

            //========================================================
            // DATA GRID
            //========================================================

            this.dgvCitizens =
                new DataGridView();

            this.dgvCitizens.Location =
                new Point(
                    18,
                    52);

            this.dgvCitizens.Size =
                new Size(
                    790,
                    360);

            this.dgvCitizens.BackgroundColor =
                Color.FromArgb(
                    12,
                    28,
                    55);

            this.dgvCitizens.BorderStyle =
                BorderStyle.None;

            this.dgvCitizens.AllowUserToAddRows =
                false;

            this.dgvCitizens.AllowUserToDeleteRows =
                false;

            this.dgvCitizens.AllowUserToResizeRows =
                false;

            this.dgvCitizens.MultiSelect =
                false;

            this.dgvCitizens.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvCitizens.RowHeadersVisible =
                false;

            this.dgvCitizens.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCitizens.ColumnHeadersHeight =
                42;

            this.dgvCitizens.EnableHeadersVisualStyles =
                false;

            this.dgvCitizens.ColumnHeadersDefaultCellStyle.BackColor =
    Color.FromArgb(
        25,
        45,
        80);

            this.dgvCitizens.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            this.dgvCitizens.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.dgvCitizens.DefaultCellStyle.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.dgvCitizens.DefaultCellStyle.ForeColor =
                Color.White;

            this.dgvCitizens.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.dgvCitizens.DefaultCellStyle.SelectionForeColor =
                Color.White;

            this.dgvCitizens.GridColor =
                Color.FromArgb(
                    45,
                    65,
                    100);


            this.dgvCitizens.Columns.Add(
                "LastName",
                "Фамилия");

            this.dgvCitizens.Columns.Add(
                "FirstName",
                "Имя");

            this.dgvCitizens.Columns.Add(
                "MiddleName",
                "Отчество");

            this.dgvCitizens.Columns.Add(
                "BirthDate",
                "Дата рождения");

            this.dgvCitizens.Columns.Add(
                "Gender",
                "Пол");

            this.dgvCitizens.Columns.Add(
                "Passport",
                "Паспорт");

            this.pnlCitizens.Controls.Add(
    this.dgvCitizens);

            //========================================================
            // PAGINATION PANEL
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
                    420);

            this.pnlPagination.Size =
                new Size(
                    790,
                    38);

            this.btnFirstPage =
    new Button();

            this.btnFirstPage.Text =
                "<<";

            this.btnFirstPage.Size =
                new Size(
                    40,
                    28);

            this.btnFirstPage.Location =
                new Point(
                    215,
                    5);

            this.btnFirstPage.FlatStyle =
                FlatStyle.Flat;

            this.btnFirstPage.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnFirstPage.FlatAppearance.BorderSize =
                1;

            this.btnFirstPage.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.btnFirstPage.ForeColor =
                Color.White;

            this.btnPreviousPage =
    new Button();

            this.btnPreviousPage.Text =
                "<";

            this.btnPreviousPage.Size =
                new Size(
                    40,
                    28);

            this.btnPreviousPage.Location =
                new Point(
                    260,
                    5);

            this.btnPreviousPage.FlatStyle =
                FlatStyle.Flat;

            this.btnPreviousPage.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnPreviousPage.FlatAppearance.BorderSize =
                1;

            this.btnPreviousPage.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.btnPreviousPage.ForeColor =
                Color.White;

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

            this.btnNextPage =
    new Button();

            this.btnNextPage.Text =
                ">";

            this.btnNextPage.Size =
                new Size(
                    40,
                    28);

            this.btnNextPage.Location =
                new Point(
                    475,
                    5);

            this.btnNextPage.FlatStyle =
                FlatStyle.Flat;

            this.btnNextPage.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnNextPage.FlatAppearance.BorderSize =
                1;

            this.btnNextPage.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.btnNextPage.ForeColor =
                Color.White;

            this.btnLastPage =
    new Button();

            this.btnLastPage.Text =
                ">>";

            this.btnLastPage.Size =
                new Size(
                    40,
                    28);

            this.btnLastPage.Location =
                new Point(
                    520,
                    5);

            this.btnLastPage.FlatStyle =
                FlatStyle.Flat;

            this.btnLastPage.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnLastPage.FlatAppearance.BorderSize =
                1;

            this.btnLastPage.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.btnLastPage.ForeColor =
                Color.White;

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

            this.pnlCitizens.Controls.Add(
                this.pnlPagination);

            //========================================================
            // RIGHT INFO PANEL (EMPTY)
            //========================================================

            this.pnlCitizenInfo =
                new Panel();

            this.pnlCitizenInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlCitizenInfo.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlCitizenInfo.Location =
    new Point(
        865,
        20);

            this.pnlCitizenInfo.Size =
                new Size(
                    455,
                    780);

            //========================================================
            // INFO TITLE
            //========================================================

            this.lblCitizenInfo =
                new Label();

            this.lblCitizenInfo.AutoSize =
                true;

            this.lblCitizenInfo.Text =
                "ИНФОРМАЦИЯ О ГРАЖДАНИНЕ";

            this.lblCitizenInfo.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblCitizenInfo.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblCitizenInfo.Location =
                new Point(
                    18,
                    15);

            this.pnlCitizenInfo.Controls.Add(
                this.lblCitizenInfo);

            Panel pnlCitizenLine =
    new Panel();

            pnlCitizenLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlCitizenLine.Location =
                new Point(
                    18,
                    42);

            pnlCitizenLine.Size =
                new Size(
                    420,
                    1);

            this.pnlCitizenInfo.Controls.Add(
                pnlCitizenLine);

            //========================================================
            // PHOTO
            //========================================================

            this.picCitizen =
                new PictureBox();

            this.picCitizen.Location =
    new Point(
        20,
        60);

            this.picCitizen.Size =
                new Size(
                    120,
                    120);

            this.picCitizen.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picCitizen.BorderStyle =
                BorderStyle.FixedSingle;

            this.picCitizen.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.picCitizen.Padding =
    new Padding(5);

            this.picCitizen.Image =
    Properties.Resources.citizen_placeholder;
            this.pnlCitizenInfo.Controls.Add(
    this.picCitizen);

            //========================================================
            // HEADER NAME
            //========================================================

            this.lblCitizenNameHeader =
                new Label();

            this.lblCitizenNameHeader.AutoSize =
                true;

            this.lblCitizenNameHeader.Font =
                new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold);

            this.lblCitizenNameHeader.ForeColor =
                Color.White;

            this.lblCitizenNameHeader.Location =
                new Point(
                    160,
                    58);

            this.lblCitizenNameHeader.Text =
                "Иванов\r\nИван\r\nИванович";

            this.pnlCitizenInfo.Controls.Add(
                this.lblCitizenNameHeader);

            //========================================================
            // GENDER ICON
            //========================================================

            this.picGenderIcon =
                new PictureBox();

            this.picGenderIcon.Size =
                new Size(
                    18,
                    18);

            this.picGenderIcon.Location =
                new Point(
                    160,
                    138);

            this.picGenderIcon.BackColor =
                Color.Transparent;

            this.picGenderIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            // Поменяешь название ресурса позже
            this.picGenderIcon.Image =
                Properties.Resources.gender_icon;

            this.pnlCitizenInfo.Controls.Add(
                this.picGenderIcon);

            //========================================================
            // GENDER TEXT
            //========================================================

            this.lblCitizenGenderHeader =
                new Label();

            this.lblCitizenGenderHeader.AutoSize =
                true;

            this.lblCitizenGenderHeader.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblCitizenGenderHeader.ForeColor =
                Color.White;

            this.lblCitizenGenderHeader.Location =
                new Point(
                    185,
                    137);

            this.lblCitizenGenderHeader.Text =
                "Мужчина";

            this.pnlCitizenInfo.Controls.Add(
                this.lblCitizenGenderHeader);

            //========================================================
            // AGE ICON
            //========================================================

            this.picAgeIcon =
                new PictureBox();

            this.picAgeIcon.Size =
                new Size(
                    20,
                    20);

            this.picAgeIcon.Location =
                new Point(
                    160,
                    166);

            this.picAgeIcon.BackColor =
                Color.Transparent;

            this.picAgeIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            
            this.picAgeIcon.Image =
                Properties.Resources.inspector_1;

            this.pnlCitizenInfo.Controls.Add(
                this.picAgeIcon);

            //========================================================
            // AGE TEXT
            //========================================================

            this.lblCitizenAgeHeader =
                new Label();

            this.lblCitizenAgeHeader.AutoSize =
                true;

            this.lblCitizenAgeHeader.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblCitizenAgeHeader.ForeColor =
                Color.White;

            this.lblCitizenAgeHeader.Location =
                new Point(
                    185,
                    165);

            this.lblCitizenAgeHeader.Text =
                "34 года";

            this.pnlCitizenInfo.Controls.Add(
                this.lblCitizenAgeHeader);

            //========================================================
            // TABS PANEL
            //========================================================

            this.pnlTabs =
                new Panel();

            this.pnlTabs.Location =
                new Point(
                    15,
                    215);

            this.pnlTabs.Size =
                new Size(
                    425,
                    36);

            this.pnlTabs.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlActiveTab =
    new Panel();

            this.pnlActiveTab.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.pnlActiveTab.Location =
                new Point(
                    0,
                    33);

            this.pnlActiveTab.Size =
                new Size(
                    120,
                    3);

            this.pnlTabs.Controls.Add(
                this.pnlActiveTab);

            //========================================================
            // TAB GENERAL
            //========================================================

            this.pnlTabGeneral =
                new Panel();

            this.pnlTabGeneral.Size =
                new Size(128, 34);

            this.pnlTabGeneral.Location =
                new Point(0, 0);

            this.pnlTabGeneral.Cursor =
                Cursors.Hand;

            this.pnlTabGeneral.BackColor =
                Color.Transparent;

            this.lblTabGeneral =
                new Label();

            this.lblTabGeneral.Text =
                "Основные данные";

            this.lblTabGeneral.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblTabGeneral.ForeColor =
                Color.White;

            this.lblTabGeneral.AutoSize =
                true;

            this.lblTabGeneral.Location =
                new Point(10, 9);

            this.lblTabGeneral.Cursor =
                Cursors.Hand;

            this.pnlTabGeneral.Controls.Add(
                this.lblTabGeneral);

            this.pnlTabs.Controls.Add(
                this.pnlTabGeneral);

            this.pnlTabDocuments =
    new Panel();

            this.pnlTabDocuments.Size =
                new Size(92, 34);

            this.pnlTabDocuments.Location =
                new Point(125, 0);

            this.pnlTabDocuments.Cursor =
                Cursors.Hand;

            this.lblTabDocuments =
                new Label();

            this.lblTabDocuments.Text =
                "Документы";

            this.lblTabDocuments.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblTabDocuments.ForeColor =
                Color.White;

            this.lblTabDocuments.AutoSize =
                true;

            this.lblTabDocuments.Location =
                new Point(10, 9);

            this.lblTabDocuments.Cursor =
                Cursors.Hand;

            this.pnlTabDocuments.Controls.Add(
                this.lblTabDocuments);

            this.pnlTabs.Controls.Add(
                this.pnlTabDocuments);

            this.pnlTabCases =
    new Panel();

            this.pnlTabCases.Size =
                new Size(108, 34);

            this.pnlTabCases.Location =
                new Point(220, 0);

            this.pnlTabCases.Cursor =
                Cursors.Hand;

            this.lblTabCases =
                new Label();

            this.lblTabCases.Text =
                "Связи и дела";

            this.lblTabCases.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblTabCases.ForeColor =
                Color.White;

            this.lblTabCases.AutoSize =
                true;

            this.lblTabCases.Location =
                new Point(10, 9);

            this.lblTabCases.Cursor =
                Cursors.Hand;

            this.pnlTabCases.Controls.Add(
                this.lblTabCases);

            this.pnlTabs.Controls.Add(
                this.pnlTabCases);

            this.pnlTabHistory =
    new Panel();

            this.pnlTabHistory.Size =
                new Size(82, 34);

            this.pnlTabHistory.Location =
                new Point(330, 0);

            this.pnlTabHistory.Cursor =
                Cursors.Hand;

            this.lblTabHistory =
                new Label();

            this.lblTabHistory.Text =
                "История";

            this.lblTabHistory.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblTabHistory.ForeColor =
                Color.White;

            this.lblTabHistory.AutoSize =
                true;

            this.lblTabHistory.Location =
                new Point(10, 9);

            this.lblTabHistory.Cursor =
                Cursors.Hand;

            this.pnlTabHistory.Controls.Add(
                this.lblTabHistory);

            this.pnlTabs.Controls.Add(
                this.pnlTabHistory);

            //========================================================
            // CONTENT PANEL
            //========================================================

            this.pnlContent =
                new Panel();

            this.pnlContent.Location =
                new Point(
                    15,
                    251);

            this.pnlContent.Size =
                new Size(
                    425,
                    500);

            this.pnlContent.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            //========================================================
            // GENERAL CONTENT PANEL
            //========================================================

            this.pnlGeneralContent =
    new Panel();

            this.pnlGeneralContent.Location =
                new Point(0, 0);

            this.pnlGeneralContent.Size =
                new Size(425, 500);

            this.pnlGeneralContent.BackColor =
                Color.Transparent;


            //========================================================
            // DOCUMENTS CONTENT PANEL
            //========================================================

            this.pnlDocumentsContent =
    new Panel();

            this.pnlDocumentsContent.Location =
                new Point(0, 0);

            this.pnlDocumentsContent.Size =
                new Size(425, 500);

            this.pnlDocumentsContent.BackColor =
                Color.Transparent;


            //========================================================
            // CASES CONTENT PANEL
            //========================================================

            this.pnlCasesContent =
                new Panel();

            this.pnlCasesContent =
    new Panel();

            this.pnlCasesContent.Location =
                new Point(0, 0);

            this.pnlCasesContent.Size =
                new Size(425, 500);

            this.pnlCasesContent.BackColor =
                Color.Transparent;


            //========================================================
            // HISTORY CONTENT PANEL
            //========================================================

            this.pnlHistoryContent =
                new Panel();

            this.pnlHistoryContent.Location =
                new Point(0, 0);

            this.pnlHistoryContent.Size =
                new Size(425, 500);

            this.pnlHistoryContent.BackColor =
                Color.Transparent;

            this.pnlCitizenInfo.Controls.Add(
                this.pnlTabs);

            this.pnlCitizenInfo.Controls.Add(
                this.pnlContent);

            this.pnlContent.Controls.Add(
    this.pnlHistoryContent);

            this.pnlContent.Controls.Add(
                this.pnlCasesContent);

            this.pnlContent.Controls.Add(
                this.pnlDocumentsContent);

            this.pnlContent.Controls.Add(
                this.pnlGeneralContent);

            CreateGeneralInformation();

            CreatePassportInformation();


            //========================================================
            // CASES FLOW PANEL
            //========================================================

            this.flpCitizenCases =
                new FlowLayoutPanel();

            this.flpCitizenCases.Location =
                new Point(
                    8,
                    8);

            this.flpCitizenCases.Size =
                new Size(
                    405,
                    485);

            this.flpCitizenCases.FlowDirection =
                FlowDirection.TopDown;

            this.flpCitizenCases.WrapContents =
                false;

            this.flpCitizenCases.AutoScroll =
                true;

            this.flpCitizenCases.BackColor =
                Color.Transparent;

            this.flpCitizenCases.Padding =
                new Padding(
                    0);

            this.flpCitizenCases.Margin =
                new Padding(
                    0);

            this.pnlCasesContent.Controls.Add(
                this.flpCitizenCases);

            //========================================================
            // HISTORY FLOW PANEL
            //========================================================

            this.flpCitizenHistory =
                new FlowLayoutPanel();

            this.flpCitizenHistory.Location =
                new Point(
                    8,
                    8);

            this.flpCitizenHistory.Size =
                new Size(
                    405,
                    485);

            this.flpCitizenHistory.FlowDirection =
                FlowDirection.TopDown;

            this.flpCitizenHistory.WrapContents =
                false;

            this.flpCitizenHistory.AutoScroll =
                true;

            this.flpCitizenHistory.BackColor =
                Color.Transparent;

            this.flpCitizenHistory.Padding =
                new Padding(
                    0);

            this.flpCitizenHistory.Margin =
                new Padding(
                    0);

            this.pnlHistoryContent.Controls.Add(
                this.flpCitizenHistory);

            //========================================================
            // ADD MAIN CONTROLS
            //========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlCitizens);

            this.Controls.Add(
                this.pnlCitizenInfo);

            //========================================================
            // END
            //========================================================

            this.ResumeLayout(false);
        }

        private Label CreateInfoTitle(
    string text,
    int y)
        {
            Label lbl =
                new Label();

            lbl.Text = text;

            lbl.ForeColor =
                Color.White;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lbl.Location =
                new Point(
                    18,
                    y);

            lbl.AutoSize = true;

            return lbl;
        }

        private Label CreateInfoValue(
            int y)
        {
            Label lbl =
                new Label();

            lbl.ForeColor =
                Color.Gainsboro;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lbl.Location =
                new Point(
                    220,
                    y);

            lbl.MaximumSize =
                new Size(
                    170,
                    0);

            lbl.AutoSize = true;

            return lbl;
        }

        private Panel CreateInfoLine(
            int y)
        {
            Panel pnl =
                new Panel();

            pnl.Location =
                new Point(
                    18,
                    y);

            pnl.Size =
                new Size(
                    390,
                    1);

            pnl.BackColor =
                Color.FromArgb(
                    50,
                    70,
                    110);

            return pnl;
        }

        private void CreateGeneralInformation()
        {

            lblBirthTitle =
    CreateInfoTitle(
        "Дата рождения:",
        20);

            lblBirthValue =
                CreateInfoValue(
                    20);

            lblBirthValue.Text =
                "12.04.1992";

            lineBirth =
                CreateInfoLine(
                    50);

            pnlGeneralContent.Controls.Add(
                lblBirthTitle);

            pnlGeneralContent.Controls.Add(
                lblBirthValue);

            pnlGeneralContent.Controls.Add(
                lineBirth);

            lblGenderTitle =
    CreateInfoTitle(
        "Пол:",
        75);

            lblGenderValue =
                CreateInfoValue(
                    75);

            lblGenderValue.Text =
                "Мужской";

            lineGender =
                CreateInfoLine(
                    105);

            pnlGeneralContent.Controls.Add(
                lblGenderTitle);

            pnlGeneralContent.Controls.Add(
                lblGenderValue);

            pnlGeneralContent.Controls.Add(
                lineGender);

            lblAgeTitle =
    CreateInfoTitle(
        "Возраст:",
        130);

            lblAgeValue =
                CreateInfoValue(
                    130);

            lblAgeValue.Text =
                "34 года";

            lineAge =
                CreateInfoLine(
                    160);

            pnlGeneralContent.Controls.Add(
                lblAgeTitle);

            pnlGeneralContent.Controls.Add(
                lblAgeValue);

            pnlGeneralContent.Controls.Add(
                lineAge);

            lblBirthPlaceTitle =
    CreateInfoTitle(
        "Место рождения:",
        185);

            lblBirthPlaceValue =
                CreateInfoValue(
                    185);

            lblBirthPlaceValue.Text =
                "г. Москва";

            lineBirthPlace =
                CreateInfoLine(
                    215);

            pnlGeneralContent.Controls.Add(
                lblBirthPlaceTitle);

            pnlGeneralContent.Controls.Add(
                lblBirthPlaceValue);

            pnlGeneralContent.Controls.Add(
                lineBirthPlace);

            lblCitizenshipTitle =
    CreateInfoTitle(
        "Гражданство:",
        240);

            lblCitizenshipValue =
                CreateInfoValue(
                    240);

            lblCitizenshipValue.Text =
                "Российская Федерация";

            lineCitizenship =
                CreateInfoLine(
                    270);

            pnlGeneralContent.Controls.Add(
                lblCitizenshipTitle);

            pnlGeneralContent.Controls.Add(
                lblCitizenshipValue);

            pnlGeneralContent.Controls.Add(
                lineCitizenship);

            lblPhoneTitle =
    CreateInfoTitle(
        "Телефон:",
        295);

            lblPhoneValue =
                CreateInfoValue(
                    295);

            lblPhoneValue.Text =
                "+7 (999) 123-45-67";

            linePhone =
                CreateInfoLine(
                    325);

            pnlGeneralContent.Controls.Add(
                lblPhoneTitle);

            pnlGeneralContent.Controls.Add(
                lblPhoneValue);

            pnlGeneralContent.Controls.Add(
                linePhone);

            lblEmailTitle =
    CreateInfoTitle(
        "E-mail:",
        350);

            lblEmailValue =
                CreateInfoValue(
                    350);

            lblEmailValue.Text =
                "ivanov@mail.ru";

            lineEmail =
                CreateInfoLine(
                    380);

            pnlGeneralContent.Controls.Add(
                lblEmailTitle);

            pnlGeneralContent.Controls.Add(
                lblEmailValue);

            pnlGeneralContent.Controls.Add(
                lineEmail);

            lblRegistrationTitle =
    CreateInfoTitle(
        "Адрес регистрации:",
        395);

            lblRegistrationValue =
                CreateInfoValue(
                    395);

            lblRegistrationValue.MaximumSize =
                new Size(
                    210,
                    0);

            lblRegistrationValue.Text =
                "г. Москва, ул. Ленина, д.15";

            lineRegistration =
                CreateInfoLine(
                    435);

            pnlGeneralContent.Controls.Add(
                lblRegistrationTitle);

            pnlGeneralContent.Controls.Add(
                lblRegistrationValue);

            pnlGeneralContent.Controls.Add(
                lineRegistration);

            lblResidenceTitle =
                CreateInfoTitle(
                    "Адрес проживания:",
                    450);

            lblResidenceValue =
                CreateInfoValue(
                    450);

            lblResidenceValue.MaximumSize =
                new Size(
                    210,
                    0);

            lblResidenceValue.Text =
                "г. Москва, ул. Пушкина, д.22";

            pnlGeneralContent.Controls.Add(
                lblResidenceTitle);

            pnlGeneralContent.Controls.Add(
                lblResidenceValue);

        }

        private void CreatePassportInformation()
        {
            lblPassportHeader = new Label();

            lblPassportHeader.Text = "ПАСПОРТНЫЕ ДАННЫЕ";

            lblPassportHeader.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblPassportHeader.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblPassportHeader.Location =
                new Point(
                    18,
                    18);

            lblPassportHeader.AutoSize = true;

            pnlDocumentsContent.Controls.Add(lblPassportHeader);

            pnlPassportLine = new Panel();

            pnlPassportLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlPassportLine.Location =
                new Point(
                    18,
                    48);

            pnlPassportLine.Size =
                new Size(
                    390,
                    1);

            pnlDocumentsContent.Controls.Add(pnlPassportLine);

            lblSeriesTitle =
    CreateInfoTitle(
        "Серия:",
        75);

            lblSeriesValue =
                CreateInfoValue(
                    75);

            lblSeriesValue.Text =
                "4512";

            lineSeries =
                CreateInfoLine(
                    105);

            pnlDocumentsContent.Controls.Add(lblSeriesTitle);
            pnlDocumentsContent.Controls.Add(lblSeriesValue);
            pnlDocumentsContent.Controls.Add(lineSeries);

            lblNumberTitle =
    CreateInfoTitle(
        "Номер:",
        130);

            lblNumberValue =
                CreateInfoValue(
                    130);

            lblNumberValue.Text =
                "456789";

            lineNumber =
                CreateInfoLine(
                    160);

            pnlDocumentsContent.Controls.Add(lblNumberTitle);
            pnlDocumentsContent.Controls.Add(lblNumberValue);
            pnlDocumentsContent.Controls.Add(lineNumber);

            lblIssueDateTitle =
    CreateInfoTitle(
        "Дата выдачи:",
        185);

            lblIssueDateValue =
                CreateInfoValue(
                    185);

            lblIssueDateValue.Text =
                "15.03.2018";

            lineIssueDate =
                CreateInfoLine(
                    215);

            pnlDocumentsContent.Controls.Add(lblIssueDateTitle);
            pnlDocumentsContent.Controls.Add(lblIssueDateValue);
            pnlDocumentsContent.Controls.Add(lineIssueDate);

            lblDepartmentCodeTitle =
    CreateInfoTitle(
        "Код подразделения:",
        240);

            lblDepartmentCodeValue =
                CreateInfoValue(
                    240);

            lblDepartmentCodeValue.Text =
                "770-001";

            lineIssuedBy =
                CreateInfoLine(
                    270);

            pnlDocumentsContent.Controls.Add(lblDepartmentCodeTitle);
            pnlDocumentsContent.Controls.Add(lblDepartmentCodeValue);
            pnlDocumentsContent.Controls.Add(lineIssuedBy);

            lblIssuedByTitle =
    CreateInfoTitle(
        "Кем выдан:",
        295);

            lblIssuedByValue =
                CreateInfoValue(
                    295);

            lblIssuedByValue.MaximumSize =
                new Size(
                    170,
                    0);

            lblIssuedByValue.Text =
                "ГУ МВД России\nпо г. Москве";

            pnlDocumentsContent.Controls.Add(lblIssuedByTitle);
            pnlDocumentsContent.Controls.Add(lblIssuedByValue);

            lblMaritalStatusTitle =
    CreateInfoTitle(
        "Семейное положение:",
        370);

            lblMaritalStatusValue =
                CreateInfoValue(
                    370);

            lblMaritalStatusValue.MaximumSize =
                new Size(
                    170,
                    0);

            lblMaritalStatusValue.Text =
                "Не состоит в браке";

            pnlDocumentsContent.Controls.Add(
                lblMaritalStatusTitle);

            pnlDocumentsContent.Controls.Add(
                lblMaritalStatusValue);

            lineMaritalStatus =
    CreateInfoLine(
        400);

            pnlDocumentsContent.Controls.Add(
                lineMaritalStatus);

        }

        #endregion
    }
}