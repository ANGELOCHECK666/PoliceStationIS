using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Cases
{
    partial class CasesPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        //========================================================
        // ОСНОВНЫЕ ПАНЕЛИ
        //========================================================

        private Panel pnlHeader;

        private Panel pnlActions;

        private Panel pnlMain;

        private Panel pnlSearch;

        private Panel pnlCases;

        private Panel pnlCaseInfo;

        private Panel pnlQuickActions;

        private Panel pnlEvidence;

        private Panel pnlExpertises;

        private Panel pnlProtocols;

        private Panel pnlNotes;

        //========================================================
        // HEADER
        //========================================================

        private Label lblTitle;

        private Label lblSubtitle;

        private PictureBox picHeaderImage;

        private PictureBox picHeaderEmblem;

        //========================================================
        // ACTION BUTTONS
        //========================================================

        private IconButton btnCreateCase;

        private IconButton btnEditCase;

        private IconButton btnCloseCase;

        private IconButton btnTransferCourt;

        private IconButton btnSuspendCase;

        private IconButton btnResumeCase;

        private IconButton btnPrintCase;


        //========================================================
        // SEARCH
        //========================================================

        private Label lblSearch;

        private Label lblCaseNumber;

        private Label lblArticle;

        private Label lblStatus;

        private Label lblInvestigator;

        private Label lblDateFrom;

        private Label lblDateTo;

        private TextBox txtCaseNumber;

        private ComboBox cmbArticle;

        private ComboBox cmbStatus;

        private ComboBox cmbInvestigator;

        private DateTimePicker dtDateFrom;

        private DateTimePicker dtDateTo;

        private Button btnSearch;

        private Button btnReset;

        //========================================================
        // TABLE
        //========================================================

        private Label lblCases;

        private DataGridView dgvCases;

        //========================================================
        // PAGINATION
        //========================================================

        private Button btnFirstPage;

        private Button btnPreviousPage;

        private Button btnPage1;

        private Button btnPage2;

        private Button btnPage3;

        private Button btnNextPage;

        private Button btnLastPage;

        private Label lblPageInfo;

        //========================================================
        // CASE INFORMATION
        //========================================================

        private Label lblCaseInformation;

        private Label lblCaseNumberTitle;

        private Label lblOpenDateTitle;

        private Label lblArticleTitle;

        private Label lblCaseStatusTitle;

        private Label lblInvestigatorTitle;

        private Label lblDepartmentTitle;

        private Label lblLastUpdateTitle;

        private Label lblCaseNumberValue;

        private Label lblOpenDateValue;

        private Label lblArticleValue;

        private Label lblCaseStatusValue;

        private Label lblInvestigatorValue;

        private Label lblDepartmentValue;

        private Label lblLastUpdateValue;

        //========================================================
        // QUICK ACTIONS
        //========================================================

        private Label lblQuickActions;

        private IconButton btnAddEvidence;

        private IconButton btnAssignExpertise;

        private IconButton btnAddProtocol;


        //========================================================
        // STATUS INDICATOR
        //========================================================

        private Panel pnlStatusIndicator;

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
                "CasesPage";

            this.Size =
                new Size(
                    1560,
                    900);

            //========================================================
            // HEADER PANEL
            //========================================================

            this.pnlHeader = new Panel();

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
                    1300,
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

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.Location =
                new Point(
                    25,
                    15);

            this.lblTitle.Text =
                "Дела";

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

            pnlTitleLine.Size =
                new Size(
                    24,
                    3);

            pnlTitleLine.Location =
                new Point(
                    30,
                    50);

            //========================================================
            // SUBTITLE
            //========================================================

            this.lblSubtitle =
                new Label();

            this.lblSubtitle.AutoSize =
                true;

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.Location =
                new Point(
                    28,
                    57);

            this.lblSubtitle.Text =
                "Учет и ведение уголовных дел";

            //========================================================
            // HEADER IMAGE
            //========================================================

            this.picHeaderImage =
                new PictureBox();

            this.picHeaderImage.Image =
                Properties.Resources.case_header_image;

            this.picHeaderImage.BackColor =
                Color.Transparent;

            this.picHeaderImage.SizeMode =
                PictureBoxSizeMode.StretchImage;

            this.picHeaderImage.Location =
                new Point(
                    920,
                    -5);

            this.picHeaderImage.Size =
                new Size(
                    280,
                    105);

            //========================================================
            // HEADER EMBLEM
            //========================================================

            this.picHeaderEmblem =
                new PictureBox();

            this.picHeaderEmblem.Image =
                Properties.Resources.case_section_gold;

            this.picHeaderEmblem.BackColor =
                Color.Transparent;

            this.picHeaderEmblem.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picHeaderEmblem.Location =
                new Point(
                    1200,
                    0);

            this.picHeaderEmblem.Size =
                new Size(
                    90,
                    90);

            this.picHeaderEmblem.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

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
                this.picHeaderImage);

            this.pnlHeader.Controls.Add(
                this.picHeaderEmblem);

            this.picHeaderEmblem.BringToFront();

            //========================================================
            // ACTIONS PANEL
            //========================================================

            this.pnlActions =
                new Panel();

            this.pnlActions.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlActions.Location =
                new Point(
                    20,
                    130);

            this.pnlActions.Size =
                new Size(
                    1300,
                    60);

            this.pnlActions.BorderStyle =
                BorderStyle.FixedSingle;

            //========================================================
            // ACTION BUTTONS
            //========================================================

            this.btnCreateCase =
                new IconButton();

            this.btnEditCase =
                new IconButton();

            this.btnCloseCase =
                new IconButton();

            this.btnTransferCourt =
                new IconButton();

            this.btnSuspendCase =
                new IconButton();

            this.btnResumeCase =
                new IconButton();

            this.btnPrintCase =
                new IconButton();

            //========================================================
            // BUTTON TEXT
            //========================================================

            this.btnCreateCase.Text =
                "Создать дело";

            this.btnEditCase.Text =
                "Редактировать";

            this.btnCloseCase.Text =
                "Закрыть дело";

            this.btnTransferCourt.Text =
                "Передать в суд";

            this.btnSuspendCase.Text =
                "Приостановить";

            this.btnResumeCase.Text =
                "Возобновить";

            this.btnPrintCase.Text =
                "Печать";

            btnCreateCase.ButtonIcon =
    Properties.Resources.case_add_gold_icon;

            btnEditCase.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            btnCloseCase.ButtonIcon =
                Properties.Resources.case_close;

            btnTransferCourt.ButtonIcon =
                Properties.Resources.case_transfer_gold_icon;

            btnSuspendCase.ButtonIcon =
                Properties.Resources.case_suspend_gold_icon;

            btnResumeCase.ButtonIcon =
                Properties.Resources.case_resume_gold_icon;

            btnPrintCase.ButtonIcon =
                Properties.Resources.printer_icon;

            //========================================================
            // BUTTON SIZE
            //========================================================

            Size actionButtonSize =
                new Size(
                    168,
                    35);

            this.btnCreateCase.Size =
                actionButtonSize;

            this.btnEditCase.Size =
                actionButtonSize;

            this.btnCloseCase.Size =
                actionButtonSize;

            this.btnTransferCourt.Size =
                actionButtonSize;

            this.btnSuspendCase.Size =
                actionButtonSize;

            this.btnResumeCase.Size =
                actionButtonSize;

            this.btnPrintCase.Size =
                new Size(
                    135,
                    35);

            //========================================================
            // BUTTON LOCATION
            //========================================================

            Button[] actionButtons =
{
    btnCreateCase,
    btnEditCase,
    btnCloseCase,
    btnTransferCourt,
    btnSuspendCase,
    btnResumeCase,
    btnPrintCase
};

            foreach (Button button in actionButtons)
            {
                button.FlatStyle = FlatStyle.Flat;

                button.UseVisualStyleBackColor = false;

                button.BackColor =
                    Color.FromArgb(42, 73, 133);

                button.ForeColor =
                    Color.White;

                button.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold);

                button.FlatAppearance.BorderSize = 1;

                button.FlatAppearance.BorderColor =
                    Color.FromArgb(
                        212,
                        160,
                        23);
            }

            btnCreateCase.Location =
    new Point(15, 12);

            btnEditCase.Location =
                new Point(203, 12);

            btnCloseCase.Location =
                new Point(392, 12);

            btnTransferCourt.Location =
                new Point(580, 12);

            btnSuspendCase.Location =
                new Point(768, 12);

            btnResumeCase.Location =
                new Point(957, 12);

            btnPrintCase.Location =
                new Point(1145, 12);


            //========================================================
            // ADD BUTTONS
            //========================================================

            this.pnlActions.Controls.Add(
                this.btnCreateCase);

            this.pnlActions.Controls.Add(
                this.btnEditCase);

            this.pnlActions.Controls.Add(
                this.btnCloseCase);

            this.pnlActions.Controls.Add(
                this.btnTransferCourt);

            this.pnlActions.Controls.Add(
                this.btnSuspendCase);

            this.pnlActions.Controls.Add(
                this.btnResumeCase);

            this.pnlActions.Controls.Add(
                this.btnPrintCase);

            

            //========================================================
            // SEARCH PANEL
            //========================================================

            this.pnlSearch = new Panel();
            this.pnlSearch.Location = new Point(20, 205);
            this.pnlSearch.Size = new Size(855, 130);
            this.pnlSearch.BorderStyle = BorderStyle.FixedSingle;

            //========================================================
            // SEARCH TITLE
            //========================================================

            this.lblSearch = new Label();
            this.lblSearch.AutoSize = true;
            this.lblSearch.Text = "ПОИСК И ФИЛЬТРЫ";
            this.lblSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSearch.ForeColor = Color.FromArgb(
                    196,
                    145,
                    35);
            this.lblSearch.Location = new Point(18, 12);

            //========================================================
            // CASE NUMBER
            //========================================================

            this.lblCaseNumber = new Label();
            this.lblCaseNumber.Text = "№ дела";
            this.lblCaseNumber.AutoSize = true;
            this.lblCaseNumber.ForeColor = Color.Gainsboro;
            this.lblCaseNumber.Location = new Point(20, 36);

            this.txtCaseNumber = new TextBox();
            this.txtCaseNumber.Location = new Point(20, 55);
            this.txtCaseNumber.Size = new Size(110, 26);

            //========================================================
            // ARTICLE
            //========================================================

            this.lblArticle = new Label();
            this.lblArticle.Text = "Статья";
            this.lblArticle.AutoSize = true;
            this.lblArticle.ForeColor = Color.Gainsboro;
            this.lblArticle.Location = new Point(160, 36);

            this.cmbArticle = new ComboBox();
            this.cmbArticle.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbArticle.Location = new Point(160, 55);
            this.cmbArticle.Size = new Size(170, 26);

            //========================================================
            // STATUS
            //========================================================

            this.lblStatus = new Label();
            this.lblStatus.Text = "Статус";
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = Color.Gainsboro;
            this.lblStatus.Location = new Point(360, 36);

            this.cmbStatus = new ComboBox();
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new Point(360, 55);
            this.cmbStatus.Size = new Size(135, 26);

            //========================================================
            // INVESTIGATOR
            //========================================================

            this.lblInvestigator = new Label();
            this.lblInvestigator.Text = "Следователь";
            this.lblInvestigator.AutoSize = true;
            this.lblInvestigator.ForeColor = Color.Gainsboro;
            this.lblInvestigator.Location = new Point(515, 36);

            this.cmbInvestigator = new ComboBox();
            this.cmbInvestigator.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbInvestigator.Location = new Point(515, 55);
            this.cmbInvestigator.Size = new Size(275, 26);

            //========================================================
            // DATE FROM
            //========================================================

            this.lblDateFrom = new Label();
            this.lblDateFrom.Text = "Период:";
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.ForeColor = Color.Gainsboro;
            this.lblDateFrom.Location = new Point(20, 96);

            this.dtDateFrom = new DateTimePicker();
            this.dtDateFrom.Format = DateTimePickerFormat.Short;
            this.dtDateFrom.ShowCheckBox = true;
            this.dtDateFrom.Checked = false;
            this.dtDateFrom.Location = new Point(74, 90);
            this.dtDateFrom.Size = new Size(110, 25);

            //========================================================
            // DATE TO
            //========================================================

            this.lblDateTo = new Label();
            this.lblDateTo.Visible = false;
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.ForeColor = Color.Gainsboro;
            this.lblDateTo.Location = new Point(225, 92);

            this.dtDateTo = new DateTimePicker();
            this.dtDateTo.Format = DateTimePickerFormat.Short;
            this.dtDateTo.ShowCheckBox = true;
            this.dtDateTo.Checked = false;
            this.dtDateTo.Location = new Point(222, 90);
            this.dtDateTo.Size = new Size(110, 25);

            Label lblDash = new Label();

            lblDash.AutoSize = true;
            lblDash.Text = "—";

            lblDash.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblDash.ForeColor =
                Color.Gainsboro;

            lblDash.Location =
                new Point(
                    190,
                    90);

            this.pnlSearch.Controls.Add(lblDash);


            Panel pnlSearchLine = new Panel();

            pnlSearchLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlSearchLine.Location =
                new Point(
                    20,
                    78);

            pnlSearchLine.Size =
                new Size(
                    810,
                    1);

            this.pnlSearch.Controls.Add(pnlSearchLine);

            //========================================================
            // TABLE PANEL
            //========================================================

            this.pnlCases = new Panel();
            this.pnlCases.Location = new Point(20, 300);
            this.pnlCases.Size = new Size(855, 500);
            this.pnlCases.BorderStyle = BorderStyle.FixedSingle;

            this.lblCases = new Label();
            this.lblCases.AutoSize = true;
            this.lblCases.Text = "Список уголовных дел";
            this.lblCases.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblCases.ForeColor = Color.White;
            this.lblCases.Location = new Point(18, 15);

            //========================================================
            // DATAGRIDVIEW
            //========================================================

            this.dgvCases = new DataGridView();
            this.dgvCases.Location = new Point(20, 50);
            this.dgvCases.Size = new Size(815, 380);

            this.dgvCases.AllowUserToAddRows = false;
            this.dgvCases.AllowUserToDeleteRows = false;
            this.dgvCases.AllowUserToResizeColumns = false;
            this.dgvCases.AllowUserToResizeRows = false;

            this.dgvCases.ReadOnly = true;

            this.dgvCases.MultiSelect = false;

            this.dgvCases.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvCases.RowHeadersVisible = false;

            this.dgvCases.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCases.BackgroundColor =
                Color.FromArgb(18, 38, 74);

            this.dgvCases.BorderStyle =
                BorderStyle.None;

            this.dgvCases.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            this.dgvCases.EnableHeadersVisualStyles = false;

            this.dgvCases.ColumnHeadersDefaultCellStyle.BackColor =
    Color.FromArgb(
        34,
        60,
        112);

            this.dgvCases.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.dgvCases.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
            this.dgvCases.ColumnHeadersDefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleCenter;

            this.dgvCases.DefaultCellStyle.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            this.dgvCases.DefaultCellStyle.ForeColor =
                Color.White;

            this.dgvCases.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    48,
                    82,
                    145);

            this.dgvCases.DefaultCellStyle.SelectionForeColor =
                Color.White;

            this.dgvCases.GridColor =
                Color.FromArgb(
                    70,
                    95,
                    145);

            this.dgvCases.ColumnHeadersHeight = 42;

            this.dgvCases.RowTemplate.Height = 34;

            this.dgvCases.Columns.Add(
                "CaseNumber",
                "Номер дела");

            this.dgvCases.Columns.Add(
                "OpenDate",
                "Дата\nвозбуждения");

            this.dgvCases.Columns.Add(
                "Article",
                "Статья УК РФ");

            this.dgvCases.Columns.Add(
                "Status",
                "Статус");

            this.dgvCases.Columns.Add(
                "Investigator",
                "Следователь");

            this.dgvCases.Columns.Add(
                "LastUpdate",
                "Дата последнего\nизменения");

            this.dgvCases.Columns["CaseNumber"].FillWeight = 125;

            this.dgvCases.Columns["OpenDate"].FillWeight = 115;

            this.dgvCases.Columns["Article"].FillWeight = 95;

            this.dgvCases.Columns["Status"].FillWeight = 125;

            this.dgvCases.Columns["Investigator"].FillWeight = 175;

            this.dgvCases.Columns["LastUpdate"].FillWeight = 110;

            this.pnlCases.Controls.Add(
                this.lblCases);

            this.pnlCases.Controls.Add(
                this.dgvCases);

            //========================================================
            // PAGINATION
            //========================================================

            this.btnFirstPage =
                new Button();

            this.btnPreviousPage =
                new Button();

            this.btnPage1 =
                new Button();

            this.btnPage2 =
                new Button();

            this.btnPage3 =
                new Button();

            this.btnNextPage =
                new Button();

            this.btnLastPage =
                new Button();

            this.lblPageInfo =
                new Label();

            Button[] pages =
            {
                btnFirstPage,
                btnPreviousPage,
                btnPage1,
                btnPage2,
                btnPage3,
                btnNextPage,
                btnLastPage
            };

            foreach (Button button in pages)
            {
                button.FlatStyle =
                    FlatStyle.Flat;

                button.FlatAppearance.BorderSize = 1;

                button.FlatAppearance.BorderColor =
                    Color.FromArgb(
                        212,
                        160,
                        23);

                button.BackColor =
                    Color.FromArgb(
                        42,
                        73,
                        133);

                button.ForeColor =
                    Color.White;

                button.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold);

                button.Size =
                    new Size(
                        34,
                        32);
            }

            this.btnFirstPage.Text = "<<";
            this.btnPreviousPage.Text = "<";
            this.btnPage1.Text = "1";
            this.btnPage2.Text = "2";
            this.btnPage3.Text = "3";
            this.btnNextPage.Text = ">";
            this.btnLastPage.Text = ">>";

            this.btnPage1.BackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.btnFirstPage.Location =
                new Point(
                    20,
                    445);

            this.btnPreviousPage.Location =
                new Point(
                    60,
                    445);

            this.btnPage1.Location =
                new Point(
                    102,
                    445);

            this.btnPage2.Location =
                new Point(
                    144,
                    445);

            this.btnPage3.Location =
                new Point(
                    186,
                    445);

            this.btnNextPage.Location =
                new Point(
                    228,
                    445);

            this.btnLastPage.Location =
                new Point(
                    270,
                    445);

            this.lblPageInfo.AutoSize = true;

            this.lblPageInfo.ForeColor =
                Color.White;

            this.lblPageInfo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblPageInfo.Location =
                new Point(
                    340,
                    453);

            this.pnlCases.Controls.Add(
                this.btnFirstPage);

            this.pnlCases.Controls.Add(
                this.btnPreviousPage);

            this.pnlCases.Controls.Add(
                this.btnPage1);

            this.pnlCases.Controls.Add(
                this.btnPage2);

            this.pnlCases.Controls.Add(
                this.btnPage3);

            this.pnlCases.Controls.Add(
                this.btnNextPage);

            this.pnlCases.Controls.Add(
                this.btnLastPage);

            this.pnlCases.Controls.Add(
                this.lblPageInfo);

            //========================================================
            // RIGHT INFO PANEL
            //========================================================

            this.pnlCaseInfo =
                new Panel();

            this.pnlCaseInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlCaseInfo.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlCaseInfo.Location =
                new Point(
                    900,
                    205);

            this.pnlCaseInfo.Size =
                new Size(
                    420,
                    270);

            this.lblCaseInformation =
                new Label();

            this.lblCaseInformation.AutoSize =
                true;

            this.lblCaseInformation.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblCaseInformation.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblCaseInformation.Location =
                new Point(
                    16,
                    16);

            this.lblCaseInformation.Text =
                "ИНФОРМАЦИЯ О ДЕЛЕ";

            this.pnlCaseInfo.Controls.Add(
                this.lblCaseInformation);

            this.lblCaseNumberTitle =
                new Label();

            this.lblOpenDateTitle =
                new Label();

            this.lblArticleTitle =
                new Label();

            this.lblCaseStatusTitle =
                new Label();

            this.lblInvestigatorTitle =
                new Label();

            this.lblDepartmentTitle =
                new Label();

            this.lblLastUpdateTitle =
                new Label();

            this.lblCaseNumberValue =
                new Label();

            this.lblOpenDateValue =
                new Label();

            this.lblArticleValue =
                new Label();

            this.lblCaseStatusValue =
                new Label();

            this.lblInvestigatorValue =
                new Label();

            this.lblDepartmentValue =
                new Label();

            this.lblLastUpdateValue =
                new Label();

            Label[] titles =
            {
                lblCaseNumberTitle,
                lblOpenDateTitle,
                lblArticleTitle,
                lblCaseStatusTitle,
                lblInvestigatorTitle,
                lblDepartmentTitle,
                lblLastUpdateTitle
            };

            string[] text =
            {
                "Номер дела:",
                "Дата возбуждения:",
                "Статья УК РФ:",
                "Статус:",
                "Следователь:",
                "Отдел:",
                "Дата последнего изменения:"
            };

            int y = 58;

            for (int i = 0; i < titles.Length; i++)
            {
                titles[i].AutoSize = false;

                titles[i].Size =
                    new Size(
                        175,
                        22);

                titles[i].ForeColor =
                    Color.Gainsboro;

                titles[i].Font =
                    new Font(
                        "Segoe UI",
                        9F);

                titles[i].TextAlign =
                    ContentAlignment.MiddleLeft;

                titles[i].Location =
                    new Point(
                        16,
                        y);

                titles[i].Text =
                    text[i];

                this.pnlCaseInfo.Controls.Add(
                    titles[i]);

                y += 34;
            }

            Label[] values =
{
                lblCaseNumberValue,
                lblOpenDateValue,
                lblArticleValue,
                lblCaseStatusValue,
                lblInvestigatorValue,
                lblDepartmentValue,
                lblLastUpdateValue
            };

            string[] valueText =
{
    "",
    "",
    "",
    "",
    "",
    "",
    ""
};

            y = 58;

            for (int i = 0; i < values.Length; i++)
            {
                values[i].AutoSize = false;

                values[i].Size =
                    new Size(
                        190,
                        22);

                values[i].Location =
                    new Point(
                        195,
                        y);

                values[i].TextAlign =
                    ContentAlignment.MiddleLeft;

                values[i].Font =
                    new Font(
                        "Segoe UI",
                        9F);

                values[i].ForeColor =
                    i == 3
                    ? Color.FromArgb(138, 196, 76)
                    : Color.White;

                values[i].Text =
                    valueText[i];

                this.pnlCaseInfo.Controls.Add(
                    values[i]);

                y += 34;
            }

            //========================================================
            // QUICK ACTIONS PANEL
            //========================================================

            this.pnlQuickActions =
                new Panel();

            this.pnlQuickActions.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlQuickActions.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlQuickActions.Location =
                new Point(
                    900,
                    500);

            this.pnlQuickActions.Size =
                new Size(
                    420,
                    300);

            this.lblQuickActions =
                new Label();

            this.lblQuickActions.AutoSize =
                true;

            this.lblQuickActions.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblQuickActions.ForeColor =
                Color.White;

            this.lblQuickActions.Location =
                new Point(
                    16,
                    16);

            this.lblQuickActions.Text =
                "Быстрые действия";

            this.pnlQuickActions.Controls.Add(
                this.lblQuickActions);

            this.btnAddEvidence =
    new IconButton();

            this.btnAssignExpertise =
                new IconButton();

            this.btnAddProtocol =
                new IconButton();

            Button[] quickButtons =
            {
                btnAddEvidence,
                btnAssignExpertise,
                btnAddProtocol
            };

            string[] quickText =
            {
                "Добавить доказательство",
                "Назначить экспертизу",
                "Добавить протокол"
            };

            btnAddEvidence.ButtonIcon =
    Properties.Resources.evidence_gold_icon;

            btnAssignExpertise.ButtonIcon =
                Properties.Resources.expertise_gold;

            btnAddProtocol.ButtonIcon =
                Properties.Resources.protocol_add_gold_icon;

            int top = 48;

            for (int i = 0; i < quickButtons.Length; i++)
            {
                quickButtons[i].FlatStyle =
                    FlatStyle.Flat;

                quickButtons[i].FlatAppearance.BorderSize = 1;

                quickButtons[i].FlatAppearance.BorderColor =
                    Color.FromArgb(
                        212,
                        160,
                        23);

                quickButtons[i].BackColor =
                    Color.FromArgb(
                        30,
                        58,
                        117);

                quickButtons[i].ForeColor =
                    Color.White;

                quickButtons[i].Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold);

                quickButtons[i].TextAlign =
                    ContentAlignment.MiddleCenter;

                quickButtons[i].Text =
                    quickText[i];

                quickButtons[i].Location =
                    new Point(
                        16,
                        top);

                quickButtons[i].Size =
                    new Size(
                        386,
                        40);

                this.pnlQuickActions.Controls.Add(
                    quickButtons[i]);

                top += 56;
            }

            //========================================================
            // ADD MAIN PANELS
            //========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlActions);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlCases);

            this.Controls.Add(
                this.pnlCaseInfo);

            this.Controls.Add(
                this.pnlQuickActions);

            //========================================================
            // SEARCH CONTROLS
            //========================================================

            this.pnlSearch.Controls.Add(
                this.lblSearch);

            this.pnlSearch.Controls.Add(
                this.lblCaseNumber);

            this.pnlSearch.Controls.Add(
                this.txtCaseNumber);

            this.pnlSearch.Controls.Add(
                this.lblArticle);

            this.pnlSearch.Controls.Add(
                this.cmbArticle);

            this.pnlSearch.Controls.Add(
                this.lblStatus);

            this.pnlSearch.Controls.Add(
                this.cmbStatus);

            this.pnlSearch.Controls.Add(
                this.lblInvestigator);

            this.pnlSearch.Controls.Add(
                this.cmbInvestigator);

            this.pnlSearch.Controls.Add(
                this.lblDateFrom);

            this.pnlSearch.Controls.Add(
                this.dtDateFrom);

            this.pnlSearch.Controls.Add(
                this.lblDateTo);

            this.pnlSearch.Controls.Add(
                this.dtDateTo);

            //========================================================
            // SEARCH BUTTONS
            //========================================================

            this.btnSearch =
                new Button();

            this.btnReset =
                new Button();

            this.btnSearch.FlatStyle =
                FlatStyle.Flat;

            this.btnReset.FlatStyle =
                FlatStyle.Flat;

            this.btnSearch.FlatAppearance.BorderSize = 1;
            this.btnReset.FlatAppearance.BorderSize = 1;

            this.btnSearch.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnReset.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnSearch.BackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.btnReset.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnSearch.ForeColor =
                Color.White;

            this.btnReset.ForeColor =
                Color.White;

            this.btnSearch.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnReset.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnSearch.Size =
                new Size(
                    112, 34);

            this.btnReset.Size =
                new Size(
                    112, 34);

            this.btnSearch.Location =
                new Point(
                    560,
                    84);

            this.btnReset.Location =
                new Point(
                    680, 84);

            this.btnSearch.Text =
                "Найти";

            this.btnReset.Text =
                "Сброс";

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            //========================================================
            // STATUS INDICATOR
            //========================================================

            this.pnlStatusIndicator =
                new Panel();

            this.pnlStatusIndicator.BackColor =
                Color.FromArgb(
                    70,
                    180,
                    80);

            this.pnlStatusIndicator.Size =
                new Size(
                    6,
                    18);

            this.pnlStatusIndicator.Location =
                new Point(
                    170,
                    163);

            this.pnlCaseInfo.Controls.Add(
                this.pnlStatusIndicator);

            //========================================================
            // END
            //========================================================
            this.btnCreateCase.Click += btnCreateCase_Click;
            this.btnEditCase.Click += btnEditCase_Click;
            this.btnCloseCase.Click += btnCloseCase_Click;
            this.btnTransferCourt.Click += btnTransferCourt_Click;
            this.btnSuspendCase.Click += btnSuspendCase_Click;
            this.btnResumeCase.Click += btnResumeCase_Click;
            this.btnPrintCase.Click += btnPrintCase_Click;

            this.btnSearch.Click += btnSearch_Click;
            this.btnReset.Click += btnReset_Click;

            this.btnAddEvidence.Click += btnAddEvidence_Click;
            this.btnAssignExpertise.Click += btnAssignExpertise_Click;
            this.btnAddProtocol.Click += btnAddProtocol_Click;
            this.dgvCases.SelectionChanged += dgvCases_SelectionChanged;
            this.btnFirstPage.Click += btnFirstPage_Click;
            this.btnPreviousPage.Click += btnPreviousPage_Click;
            this.btnPage1.Click += btnPage1_Click;
            this.btnPage2.Click += btnPage2_Click;
            this.btnPage3.Click += btnPage3_Click;
            this.btnNextPage.Click += btnNextPage_Click;
            this.btnLastPage.Click += btnLastPage_Click;
            this.ResumeLayout(false);
        }

        #endregion
    }
}