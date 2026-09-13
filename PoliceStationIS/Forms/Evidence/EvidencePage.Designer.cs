using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Evidence
{
    partial class EvidencePage
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
        private Panel pnlSearch;
        private Panel pnlEvidence;
        private Panel pnlEvidenceInfo;

        //========================================================
        // HEADER
        //========================================================

        private Label lblTitle;
        private Label lblSubtitle;

        private IconButton btnAddEvidence;
        private IconButton btnEditEvidence;

        //========================================================
        // SEARCH
        //========================================================

        private Label lblSearch;

        private Label lblEvidenceNumber;
        private Label lblEvidenceType;
        private Label lblEvidenceStatus;
        private Label lblCase;
        private Label lblDateFrom;
        private Label lblDateTo;

        private TextBox txtEvidenceNumber;

        private ComboBox cmbEvidenceType;
        private ComboBox cmbEvidenceStatus;
        private ComboBox cmbCase;

        private DateTimePicker dtDateFrom;
        private DateTimePicker dtDateTo;

        private Button btnSearch;
        private Button btnReset;

        //========================================================
        // EVIDENCE LIST
        //========================================================

        private Label lblEvidenceList;

        private FlowLayoutPanel flpEvidence;

        //========================================================
        // PAGINATION
        //========================================================

        private Panel pnlPagination;

        private Button btnFirstPage;
        private Button btnPreviousPage;
        private Label lblPageInfo;
        private Button btnNextPage;
        private Button btnLastPage;

        //========================================================
        // EVIDENCE INFORMATION
        //========================================================

        private Label lblEvidenceInformation;

        private PictureBox picEvidence;

        private Label lblEvidenceNumberInfo;
        private Label lblEvidenceNameInfo;
        private Label lblCaseInfo;
        private Label lblStatusInfo;
        private Label lblDateInfo;
        private Label lblStorageInfo;
        private Label lblDescriptionInfo;

        private Label lblEvidenceNumberValue;
        private Label lblEvidenceNameValue;
        private Label lblCaseValue;
        private Label lblStatusValue;
        private Label lblDateValue;
        private Label lblStorageValue;
        private Label lblDescriptionValue;

        //========================================================
        // RIGHT BUTTONS
        //========================================================

        private IconButton btnViewPhoto;
        private IconButton btnDeleteEvidence;

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.SuspendLayout();

            //========================================================
            // ОСНОВНАЯ ФОРМА
            //========================================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.Name =
                "EvidencePage";

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

            this.lblTitle.Text =
                "Доказательства";

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(
                    25,
                    15);

            //========================================================
            // GOLD TITLE LINE
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
                    30,
                    50);

            pnlTitleLine.Size =
                new Size(
                    28,
                    3);

            //========================================================
            // SUBTITLE
            //========================================================

            this.lblSubtitle =
                new Label();

            this.lblSubtitle.AutoSize =
                true;

            this.lblSubtitle.Text =
                "Реестр вещественных доказательств";

            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(
                    28,
                    57);

            //========================================================
            // ADD EVIDENCE BUTTON
            //========================================================

            this.btnAddEvidence =
                new IconButton();

            this.btnAddEvidence.Text =
                "Добавить доказательство";

            this.btnAddEvidence.Size =
    new Size(
        240,
        42);

            this.btnAddEvidence.Location =
                new Point(
                    775,
                    28);

            this.btnAddEvidence.Padding =
                new Padding(
                    28,
                    0,
                    8,
                    0);

            this.btnAddEvidence.TextAlign =
                ContentAlignment.MiddleCenter;

            this.btnAddEvidence.ButtonIcon =
    Properties.Resources.evidence_gold_icon;

            this.btnAddEvidence.FlatStyle =
    FlatStyle.Flat;

            this.btnAddEvidence.FlatAppearance.BorderSize =
                1;

            this.btnAddEvidence.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnAddEvidence.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnAddEvidence.ForeColor =
                Color.White;

            this.btnAddEvidence.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            //========================================================
            // EDIT EVIDENCE BUTTON
            //========================================================

            this.btnEditEvidence =
                new IconButton();

            this.btnEditEvidence.Text =
                "Редактировать доказательство";

            this.btnEditEvidence.Size =
    new Size(
        240,
        42);

            this.btnEditEvidence.Location =
                new Point(
                    1025,
                    28);

            this.btnEditEvidence.Padding =
                new Padding(
                    28,
                    0,
                    8,
                    0);

            this.btnEditEvidence.TextAlign =
                ContentAlignment.MiddleCenter;

            this.btnEditEvidence.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            this.btnEditEvidence.FlatStyle =
                FlatStyle.Flat;

            this.btnEditEvidence.FlatAppearance.BorderSize =
                1;

            this.btnEditEvidence.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnEditEvidence.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnEditEvidence.ForeColor =
                Color.White;

            this.btnEditEvidence.Font =
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
                this.btnAddEvidence);

            this.pnlHeader.Controls.Add(
                this.btnEditEvidence);

            //========================================================
            // SEARCH PANEL
            //========================================================

            this.pnlSearch =
                new Panel();

            this.pnlSearch.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlSearch.Location =
                new Point(
                    20,
                    140);

            this.pnlSearch.Size =
                new Size(
                    855,
                    155);

            this.pnlSearch.BorderStyle =
                BorderStyle.FixedSingle;

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
                    815,
                    1);

            this.pnlSearch.Controls.Add(
                pnlSearchLine);

            this.lblEvidenceNumber =
    new Label();

            this.lblEvidenceNumber.Text =
                "Номер";

            this.lblEvidenceNumber.AutoSize =
                true;

            this.lblEvidenceNumber.ForeColor =
                Color.Gainsboro;

            this.lblEvidenceNumber.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblEvidenceNumber.Location =
                new Point(
                    20,
                    52);


            this.txtEvidenceNumber =
                new TextBox();

            this.txtEvidenceNumber.Location =
                new Point(
                    20,
                    72);

            this.txtEvidenceNumber.Size =
                new Size(
                    175,
                    26);

            this.lblEvidenceType =
    new Label();

            this.lblEvidenceType.Text =
                "Тип";

            this.lblEvidenceType.AutoSize =
                true;

            this.lblEvidenceType.ForeColor =
                Color.Gainsboro;

            this.lblEvidenceType.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblEvidenceType.Location =
                new Point(
                    215,
                    52);


            this.cmbEvidenceType =
                new ComboBox();

            this.cmbEvidenceType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbEvidenceType.Location =
                new Point(
                    215,
                    72);

            this.cmbEvidenceType.Size =
                new Size(
                    190,
                    26);

            this.lblEvidenceStatus =
    new Label();

            this.lblEvidenceStatus.Text =
                "Статус";

            this.lblEvidenceStatus.AutoSize =
                true;

            this.lblEvidenceStatus.ForeColor =
                Color.Gainsboro;

            this.lblEvidenceStatus.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblEvidenceStatus.Location =
                new Point(
                    425,
                    52);


            this.cmbEvidenceStatus =
                new ComboBox();

            this.cmbEvidenceStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbEvidenceStatus.Location =
                new Point(
                    425,
                    72);

            this.cmbEvidenceStatus.Size =
                new Size(
                    190,
                    26);

            this.lblCase =
    new Label();

            this.lblCase.Text =
                "Дело";

            this.lblCase.AutoSize =
                true;

            this.lblCase.ForeColor =
                Color.Gainsboro;

            this.lblCase.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblCase.Location =
                new Point(
                    635,
                    52);


            this.cmbCase =
                new ComboBox();

            this.cmbCase.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbCase.Location =
                new Point(
                    635,
                    72);

            this.cmbCase.Size =
                new Size(
                    195,
                    26);

            this.lblDateFrom =
    new Label();

            this.lblDateFrom.Text =
                "Дата с";

            this.lblDateFrom.AutoSize =
                true;

            this.lblDateFrom.ForeColor =
                Color.Gainsboro;

            this.lblDateFrom.Location =
                new Point(
                    20,
                    101);


            this.dtDateFrom =
                new DateTimePicker();

            this.dtDateFrom.Format =
                DateTimePickerFormat.Short;

            this.dtDateFrom.ShowCheckBox =
                true;

            this.dtDateFrom.Checked =
                false;

            this.dtDateFrom.Location =
                new Point(
                    20,
                    121);

            this.dtDateFrom.Size =
                new Size(
                    120,
                    25);

            this.lblDateTo =
    new Label();

            this.lblDateTo.Text =
                "Дата по";

            this.lblDateTo.AutoSize =
                true;

            this.lblDateTo.ForeColor =
                Color.Gainsboro;

            this.lblDateTo.Location =
                new Point(
                    155,
                    101);


            this.dtDateTo =
                new DateTimePicker();

            this.dtDateTo.Format =
                DateTimePickerFormat.Short;

            this.dtDateTo.ShowCheckBox =
                true;

            this.dtDateTo.Checked =
                false;

            this.dtDateTo.Location =
                new Point(
                    155,
                    121);

            this.dtDateTo.Size =
                new Size(
                    120,
                    25);

            this.btnSearch =
    new Button();

            this.btnSearch.Text =
                "Найти";

            this.btnSearch.Location =
                new Point(
                    650,
                    113);

            this.btnSearch.Size =
                new Size(
                    85,
                    32);

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

            this.btnReset =
    new Button();

            this.btnReset.Text =
                "Сброс";

            this.btnReset.Location =
                new Point(
                    745,
                    113);

            this.btnReset.Size =
                new Size(
                    85,
                    32);

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

            this.pnlSearch.Controls.Add(
    this.lblEvidenceNumber);

            this.pnlSearch.Controls.Add(
                this.txtEvidenceNumber);

            this.pnlSearch.Controls.Add(
                this.lblEvidenceType);

            this.pnlSearch.Controls.Add(
                this.cmbEvidenceType);

            this.pnlSearch.Controls.Add(
                this.lblEvidenceStatus);

            this.pnlSearch.Controls.Add(
                this.cmbEvidenceStatus);

            this.pnlSearch.Controls.Add(
                this.lblCase);

            this.pnlSearch.Controls.Add(
                this.cmbCase);

            this.pnlSearch.Controls.Add(
                this.lblDateFrom);

            this.pnlSearch.Controls.Add(
                this.dtDateFrom);

            this.pnlSearch.Controls.Add(
                this.lblDateTo);

            this.pnlSearch.Controls.Add(
                this.dtDateTo);

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            //========================================================
            // EVIDENCE PANEL
            //========================================================

            this.pnlEvidence =
                new Panel();

            this.pnlEvidence.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlEvidence.Location =
                new Point(
                    20,
                    310);

            this.pnlEvidence.Size =
                new Size(
                    855,
                    490);

            this.pnlEvidence.BorderStyle =
                BorderStyle.FixedSingle;

            this.lblEvidenceList =
    new Label();

            this.lblEvidenceList.AutoSize =
                true;

            this.lblEvidenceList.Text =
                "СПИСОК ДОКАЗАТЕЛЬСТВ";

            this.lblEvidenceList.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblEvidenceList.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblEvidenceList.Location =
                new Point(
                    18,
                    12);

            this.pnlEvidence.Controls.Add(
                this.lblEvidenceList);

            Panel pnlEvidenceLine =
    new Panel();

            pnlEvidenceLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlEvidenceLine.Location =
                new Point(
                    18,
                    38);

            pnlEvidenceLine.Size =
                new Size(
                    815,
                    1);

            this.pnlEvidence.Controls.Add(
                pnlEvidenceLine);

            this.flpEvidence =
    new FlowLayoutPanel();

            this.flpEvidence.Location =
                new Point(
                    18,
                    50);

            this.flpEvidence.Size =
                new Size(
                    819,
                    345);

            this.flpEvidence.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.flpEvidence.FlowDirection =
                FlowDirection.TopDown;

            this.flpEvidence.WrapContents =
                false;

            this.flpEvidence.AutoScroll =
                false;

            this.flpEvidence.Padding =
                new Padding(
                    0);

            this.pnlEvidence.Controls.Add(
                this.flpEvidence);

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
                    405);

            this.pnlPagination.Size =
                new Size(
                    819,
                    55);

            this.btnFirstPage =
    new Button();

            this.btnFirstPage.Text =
                "<<";

            this.btnFirstPage.Size =
                new Size(
                    40,
                    30);

            this.btnFirstPage.Location =
                new Point(
                    220,
                    10);


            this.btnPreviousPage =
                new Button();

            this.btnPreviousPage.Text =
                "<";

            this.btnPreviousPage.Size =
                new Size(
                    40,
                    30);

            this.btnPreviousPage.Location =
                new Point(
                    265,
                    10);


            this.lblPageInfo =
                new Label();

            this.lblPageInfo.AutoSize =
                true;

            this.lblPageInfo.Text =
                "1–6 из 20";

            this.lblPageInfo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblPageInfo.ForeColor =
                Color.White;

            this.lblPageInfo.Location =
                new Point(
                    330,
                    16);


            this.btnNextPage =
                new Button();

            this.btnNextPage.Text =
                ">";

            this.btnNextPage.Size =
                new Size(
                    40,
                    30);

            this.btnNextPage.Location =
                new Point(
                    455,
                    10);


            this.btnLastPage =
                new Button();

            this.btnLastPage.Text =
                ">>";

            this.btnLastPage.Size =
                new Size(
                    40,
                    30);

            this.btnLastPage.Location =
                new Point(
                    500,
                    10);

            Button[] paginationButtons =
{
    this.btnFirstPage,
    this.btnPreviousPage,
    this.btnNextPage,
    this.btnLastPage
};

            foreach (Button button in paginationButtons)
            {
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
                        25,
                        45,
                        80);

                button.ForeColor =
                    Color.White;

                button.Font =
                    new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold);
            }

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

            this.pnlEvidence.Controls.Add(
                this.pnlPagination);

            //========================================================
            // RIGHT INFORMATION PANEL
            //========================================================

            this.pnlEvidenceInfo =
                new Panel();

            this.pnlEvidenceInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlEvidenceInfo.Location =
                new Point(
                    895,
                    140);

            this.pnlEvidenceInfo.Size =
                new Size(
                    425,
                    660);

            this.pnlEvidenceInfo.BorderStyle =
                BorderStyle.FixedSingle;

            this.lblEvidenceInformation =
    new Label();

            this.lblEvidenceInformation.AutoSize =
                true;

            this.lblEvidenceInformation.Text =
                "ИНФОРМАЦИЯ О ДОКАЗАТЕЛЬСТВЕ";

            this.lblEvidenceInformation.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblEvidenceInformation.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblEvidenceInformation.Location =
                new Point(
                    18,
                    15);

            this.pnlEvidenceInfo.Controls.Add(
                this.lblEvidenceInformation);

            Panel pnlInfoLine =
    new Panel();

            pnlInfoLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlInfoLine.Location =
                new Point(
                    18,
                    43);

            pnlInfoLine.Size =
                new Size(
                    385,
                    1);

            this.pnlEvidenceInfo.Controls.Add(
                pnlInfoLine);

            //========================================================
            // EVIDENCE PHOTO
            //========================================================

            this.picEvidence =
                new PictureBox();

            this.picEvidence.Location =
                new Point(
                    18,
                    55);

            this.picEvidence.Size =
                new Size(
                    385,
                    170);

            this.picEvidence.BackColor =
                Color.FromArgb(
                    25,
                    45,
                    80);

            this.picEvidence.BorderStyle =
                BorderStyle.FixedSingle;

            this.picEvidence.SizeMode =
                PictureBoxSizeMode.Zoom;
            this.pnlEvidenceInfo.Controls.Add(
    this.picEvidence);

            this.btnViewPhoto =
    new IconButton();

            this.btnViewPhoto.Text =
                "Просмотр фотографий";

            this.btnViewPhoto.Size =
                new Size(
                    385,
                    52);

            this.btnViewPhoto.Location =
                new Point(
                    18,
                    525);

            this.btnViewPhoto.ButtonIcon =
                Properties.Resources.view_gold_icon;

            ConfigureInfoButton(
                this.btnViewPhoto);
            this.btnViewPhoto.ForeColor =
    Color.White;

            this.btnViewPhoto.TextAlign =
                ContentAlignment.MiddleCenter;

            this.btnViewPhoto.Padding =
    new Padding(
        25,
        0,
        8,
        0);

            this.btnDeleteEvidence =
    new IconButton();

            this.btnDeleteEvidence.Text =
                "Удалить доказательство";

            this.btnDeleteEvidence.Size =
                new Size(
                    385,
                    52);

            this.btnDeleteEvidence.Location =
                new Point(
                    18,
                    590);

            this.btnDeleteEvidence.ButtonIcon =
                Properties.Resources.delete_gold_icon;

            this.btnDeleteEvidence.FlatStyle =
    FlatStyle.Flat;

            this.btnDeleteEvidence.FlatAppearance.BorderSize =
                1;

            this.btnDeleteEvidence.FlatAppearance.BorderColor =
                Color.FromArgb(
                    170,
                    115,
                    120);

            this.btnDeleteEvidence.BackColor =
                Color.FromArgb(
                    125,
                    75,
                    82);

            this.btnDeleteEvidence.ForeColor =
                Color.White;

            this.btnDeleteEvidence.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.pnlEvidenceInfo.Controls.Add(
    this.btnViewPhoto);

            this.pnlEvidenceInfo.Controls.Add(
                this.btnDeleteEvidence);

            this.Controls.Add(
    this.pnlHeader);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlEvidence);

            this.Controls.Add(
                this.pnlEvidenceInfo);

            this.ResumeLayout(false);

        #endregion
        }
    }
}