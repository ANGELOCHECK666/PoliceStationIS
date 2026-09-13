using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Protocols
{
    partial class ProtocolsPage
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
        private Panel pnlProtocols;
        private Panel pnlProtocolInfo;

        //========================================================
        // HEADER
        //========================================================

        private Label lblTitle;
        private Label lblSubtitle;

        private IconButton btnCreateProtocol;
        private IconButton btnEditProtocol;

        //========================================================
        // SEARCH
        //========================================================

        private Label lblSearch;

        private Label lblProtocolNumber;
        private Label lblProtocolType;
        private Label lblCase;
        private Label lblEmployee;
        private Label lblDateFrom;
        private Label lblDateTo;
        private Label lblStatus;

        private TextBox txtProtocolNumber;

        private ComboBox cmbProtocolType;
        private ComboBox cmbCase;
        private ComboBox cmbEmployee;
        private ComboBox cmbStatus;

        private DateTimePicker dtDateFrom;
        private DateTimePicker dtDateTo;

        private Button btnSearch;
        private Button btnReset;

        //========================================================
        // PROTOCOL CARDS
        //========================================================

        private Label lblProtocols;

        private FlowLayoutPanel flpProtocols;

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
        // PROTOCOL INFORMATION
        //========================================================

        private Label lblProtocolInformation;

        private Label lblProtocolNumberInfo;
        private Label lblCaseInfo;
        private Label lblDateInfo;
        private Label lblEmployeeInfo;
        private Label lblProtocolTypeInfo;
        private Label lblPlaceInfo;
        private Label lblStatusInfo;
        private Label lblNoteInfo;

        private Label lblProtocolNumberValue;
        private Label lblCaseValue;
        private Label lblDateValue;
        private Label lblEmployeeValue;
        private Label lblProtocolTypeValue;
        private Label lblPlaceValue;
        private Label lblStatusValue;
        private Label lblNoteValue;

        //========================================================
        // RIGHT PANEL BUTTONS
        //========================================================

        private IconButton btnPrintProtocol;
        private IconButton btnDeleteProtocol;

        //========================================================
        // INITIALIZE
        //========================================================

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
                "ProtocolsPage";

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
                "Протоколы";

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
                "Реестр протоколов и материалов по уголовным делам";

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
            // CREATE PROTOCOL BUTTON
            //========================================================

            this.btnCreateProtocol =
                new IconButton();

            this.btnCreateProtocol.Text =
                "Создать протокол";

            this.btnCreateProtocol.Size =
                new Size(
                    205,
                    42);

            this.btnCreateProtocol.Location =
                new Point(
                    855,
                    28);

            this.btnCreateProtocol.ButtonIcon =
                Properties.Resources.protocol_add_gold_icon;

            this.btnCreateProtocol.FlatStyle =
                FlatStyle.Flat;

            this.btnCreateProtocol.FlatAppearance.BorderSize =
                1;

            this.btnCreateProtocol.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnCreateProtocol.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnCreateProtocol.ForeColor =
                Color.White;

            this.btnCreateProtocol.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            //========================================================
            // EDIT PROTOCOL BUTTON
            //========================================================

            this.btnEditProtocol =
                new IconButton();

            this.btnEditProtocol.Text =
                "Редактировать протокол";

            this.btnEditProtocol.Size =
                new Size(
                    205,
                    42);

            this.btnEditProtocol.Location =
                new Point(
                    1070,
                    28);

            this.btnEditProtocol.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            this.btnEditProtocol.FlatStyle =
                FlatStyle.Flat;

            this.btnEditProtocol.FlatAppearance.BorderSize =
                1;

            this.btnEditProtocol.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnEditProtocol.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnEditProtocol.ForeColor =
                Color.White;

            this.btnEditProtocol.Font =
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
                this.btnCreateProtocol);

            this.pnlHeader.Controls.Add(
                this.btnEditProtocol);

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

            //========================================================
            // SEARCH GOLD LINE
            //========================================================

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

            //========================================================
            // № ПРОТОКОЛА
            //========================================================

            this.lblProtocolNumber =
                new Label();

            this.lblProtocolNumber.Text =
                "№ протокола";

            this.lblProtocolNumber.AutoSize =
                true;

            this.lblProtocolNumber.ForeColor =
                Color.Gainsboro;

            this.lblProtocolNumber.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblProtocolNumber.Location =
                new Point(
                    20,
                    52);

            this.txtProtocolNumber =
                new TextBox();

            this.txtProtocolNumber.Location =
                new Point(
                    20,
                    72);

            this.txtProtocolNumber.Size =
                new Size(
                    175,
                    26);

            //========================================================
            // ТИП ПРОТОКОЛА
            //========================================================

            this.lblProtocolType =
                new Label();

            this.lblProtocolType.Text =
                "Тип протокола";

            this.lblProtocolType.AutoSize =
                true;

            this.lblProtocolType.ForeColor =
                Color.Gainsboro;

            this.lblProtocolType.Location =
                new Point(
                    215,
                    52);

            this.cmbProtocolType =
                new ComboBox();

            this.cmbProtocolType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbProtocolType.Location =
                new Point(
                    215,
                    72);

            this.cmbProtocolType.Size =
                new Size(
                    190,
                    26);

            //========================================================
            // ДЕЛО
            //========================================================

            this.lblCase =
                new Label();

            this.lblCase.Text =
                "Дело";

            this.lblCase.AutoSize =
                true;

            this.lblCase.ForeColor =
                Color.Gainsboro;

            this.lblCase.Location =
                new Point(
                    425,
                    52);

            this.cmbCase =
                new ComboBox();

            this.cmbCase.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbCase.Location =
                new Point(
                    425,
                    72);

            this.cmbCase.Size =
                new Size(
                    190,
                    26);

            //========================================================
            // СОТРУДНИК
            //========================================================

            this.lblEmployee =
                new Label();

            this.lblEmployee.Text =
                "Сотрудник";

            this.lblEmployee.AutoSize =
                true;

            this.lblEmployee.ForeColor =
                Color.Gainsboro;

            this.lblEmployee.Location =
                new Point(
                    635,
                    52);

            this.cmbEmployee =
                new ComboBox();

            this.cmbEmployee.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbEmployee.Location =
                new Point(
                    635,
                    72);

            this.cmbEmployee.Size =
                new Size(
                    195,
                    26);

            //========================================================
            // ДАТА ОТ
            //========================================================

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
                    108);

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
                    128);

            this.dtDateFrom.Size =
                new Size(
                    120,
                    25);

            //========================================================
            // ДАТА ДО
            //========================================================

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
                    108);

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
                    128);

            this.dtDateTo.Size =
                new Size(
                    120,
                    25);

            //========================================================
            // STATUS
            //========================================================

            this.lblStatus =
                new Label();

            this.lblStatus.Text =
                "Статус";

            this.lblStatus.AutoSize =
                true;

            this.lblStatus.ForeColor =
                Color.Gainsboro;

            this.lblStatus.Location =
                new Point(
                    290,
                    108);

            this.cmbStatus =
                new ComboBox();

            this.cmbStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbStatus.Location =
                new Point(
                    290,
                    128);

            this.cmbStatus.Size =
                new Size(
                    180,
                    26);

            //========================================================
            // SEARCH BUTTON
            //========================================================

            this.btnSearch =
                new Button();

            this.btnSearch.Text =
                "Найти";

            this.btnSearch.Location =
                new Point(
                    650,
                    115);

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

            //========================================================
            // RESET BUTTON
            //========================================================

            this.btnReset =
                new Button();

            this.btnReset.Text =
                "Сброс";

            this.btnReset.Location =
                new Point(
                    745,
                    115);

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

            //========================================================
            // ADD SEARCH CONTROLS
            //========================================================

            this.pnlSearch.Controls.Add(
                this.lblProtocolNumber);

            this.pnlSearch.Controls.Add(
                this.txtProtocolNumber);

            this.pnlSearch.Controls.Add(
                this.lblProtocolType);

            this.pnlSearch.Controls.Add(
                this.cmbProtocolType);

            this.pnlSearch.Controls.Add(
                this.lblCase);

            this.pnlSearch.Controls.Add(
                this.cmbCase);

            this.pnlSearch.Controls.Add(
                this.lblEmployee);

            this.pnlSearch.Controls.Add(
                this.cmbEmployee);

            this.pnlSearch.Controls.Add(
                this.lblDateFrom);

            this.pnlSearch.Controls.Add(
                this.dtDateFrom);

            this.pnlSearch.Controls.Add(
                this.lblDateTo);

            this.pnlSearch.Controls.Add(
                this.dtDateTo);

            this.pnlSearch.Controls.Add(
                this.lblStatus);

            this.pnlSearch.Controls.Add(
                this.cmbStatus);

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            //========================================================
            // PROTOCOLS PANEL
            //========================================================

            this.pnlProtocols =
                new Panel();

            this.pnlProtocols.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlProtocols.Location =
                new Point(
                    20,
                    310);

            this.pnlProtocols.Size =
                new Size(
                    855,
                    490);

            this.pnlProtocols.BorderStyle =
                BorderStyle.FixedSingle;

            //========================================================
            // PROTOCOLS TITLE
            //========================================================

            this.lblProtocols =
                new Label();

            this.lblProtocols.AutoSize =
                true;

            this.lblProtocols.Text =
                "СПИСОК ПРОТОКОЛОВ";

            this.lblProtocols.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblProtocols.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblProtocols.Location =
                new Point(
                    18,
                    12);

            this.pnlProtocols.Controls.Add(
                this.lblProtocols);

            //========================================================
            // PROTOCOLS GOLD LINE
            //========================================================

            Panel pnlProtocolsLine =
                new Panel();

            pnlProtocolsLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlProtocolsLine.Location =
                new Point(
                    18,
                    38);

            pnlProtocolsLine.Size =
                new Size(
                    815,
                    1);

            this.pnlProtocols.Controls.Add(
                pnlProtocolsLine);

            //========================================================
            // FLOW LAYOUT — CARDS
            //========================================================

            this.flpProtocols =
                new FlowLayoutPanel();

            this.flpProtocols.Location =
                new Point(
                    18,
                    50);

            this.flpProtocols.Size =
                new Size(
                    819,
                    345);

            this.flpProtocols.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.flpProtocols.FlowDirection =
                FlowDirection.LeftToRight;

            this.flpProtocols.WrapContents =
                true;

            this.flpProtocols.AutoScroll =
                false;

            this.flpProtocols.Padding =
                new Padding(
                    0);

            this.pnlProtocols.Controls.Add(
                this.flpProtocols);

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
                    405);

            this.pnlPagination.Size =
                new Size(
                    819,
                    55);

            this.pnlProtocols.Controls.Add(
                this.pnlPagination);

            //========================================================
            // FIRST PAGE
            //========================================================

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

            //========================================================
            // PREVIOUS PAGE
            //========================================================

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

            //========================================================
            // PAGE INFO
            //========================================================

            this.lblPageInfo =
                new Label();

            this.lblPageInfo.AutoSize =
                true;

            this.lblPageInfo.Text =
                "1–6 из 24";

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

            //========================================================
            // NEXT PAGE
            //========================================================

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

            //========================================================
            // LAST PAGE
            //========================================================

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

            //========================================================
            // PAGINATION STYLE
            //========================================================

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

            //========================================================
            // RIGHT INFORMATION PANEL
            //========================================================

            this.pnlProtocolInfo =
                new Panel();

            this.pnlProtocolInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlProtocolInfo.Location =
                new Point(
                    895,
                    140);

            this.pnlProtocolInfo.Size =
                new Size(
                    425,
                    660);

            this.pnlProtocolInfo.BorderStyle =
                BorderStyle.FixedSingle;

            //========================================================
            // INFORMATION TITLE
            //========================================================

            this.lblProtocolInformation =
                new Label();

            this.lblProtocolInformation.AutoSize =
                true;

            this.lblProtocolInformation.Text =
                "ИНФОРМАЦИЯ О ПРОТОКОЛЕ";

            this.lblProtocolInformation.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblProtocolInformation.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblProtocolInformation.Location =
                new Point(
                    18,
                    15);

            this.pnlProtocolInfo.Controls.Add(
                this.lblProtocolInformation);

            //========================================================
            // INFORMATION GOLD LINE
            //========================================================

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

            this.pnlProtocolInfo.Controls.Add(
                pnlInfoLine);

            //========================================================
            // INFORMATION LABELS
            //========================================================

            CreateInfoLabels();

            //========================================================
            // RIGHT BUTTONS
            //========================================================

            this.btnPrintProtocol =
                new IconButton();

            this.btnPrintProtocol.Text =
                "Печать протокола";

            this.btnPrintProtocol.ButtonIcon =
                Properties.Resources.printer_icon;

            this.btnPrintProtocol.Size =
                new Size(
                    385,
                    52);

            this.btnPrintProtocol.Location =
                new Point(
                    18,
                    465);

            this.btnDeleteProtocol =
                new IconButton();

            this.btnDeleteProtocol.Text =
                "Удалить протокол";

            this.btnDeleteProtocol.ButtonIcon =
                Properties.Resources.delete_gold_icon;

            this.btnDeleteProtocol.Size =
                new Size(
                    385,
                    52);

            this.btnDeleteProtocol.Location =
                new Point(
                    18,
                    527);

            //========================================================
            // BUTTON STYLE
            //========================================================

            ConfigureInfoButton(
                this.btnPrintProtocol);

            this.btnDeleteProtocol.FlatStyle =
    FlatStyle.Flat;

            this.btnDeleteProtocol.FlatAppearance.BorderSize =
                1;

            this.btnDeleteProtocol.FlatAppearance.BorderColor =
                Color.FromArgb(
                    170,
                    115,
                    120);

            this.btnDeleteProtocol.BackColor =
                Color.FromArgb(
                    125,
                    75,
                    82);

            this.btnDeleteProtocol.ForeColor =
                Color.White;

            this.btnDeleteProtocol.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.pnlProtocolInfo.Controls.Add(
                this.btnPrintProtocol);

            this.pnlProtocolInfo.Controls.Add(
                this.btnDeleteProtocol);

            //========================================================
            // ADD MAIN PANELS
            //========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlProtocols);

            this.Controls.Add(
                this.pnlProtocolInfo);

            this.ResumeLayout(false);
        }

        //============================================================
        // INFORMATION LABELS
        //============================================================

        private void CreateInfoLabels()
        {
            int titleX = 20;
            int valueX = 185;

            //========================================================
            // № ПРОТОКОЛА
            //========================================================

            this.lblProtocolNumberInfo =
                CreateInfoTitle(
                    "№ протокола:",
                    70);

            this.lblProtocolNumberValue =
                CreateInfoValue(
                    70);

            //========================================================
            // ДЕЛО
            //========================================================

            this.lblCaseInfo =
                CreateInfoTitle(
                    "Дело:",
                    115);

            this.lblCaseValue =
                CreateInfoValue(
                    115);

            //========================================================
            // ДАТА СОСТАВЛЕНИЯ
            //========================================================

            this.lblDateInfo =
                CreateInfoTitle(
                    "Дата составления:",
                    160);

            this.lblDateValue =
                CreateInfoValue(
                    160);

            //========================================================
            // СОСТАВИЛ
            //========================================================

            this.lblEmployeeInfo =
                CreateInfoTitle(
                    "Составил:",
                    205);

            this.lblEmployeeValue =
                CreateInfoValue(
                    205);

            //========================================================
            // ТИП ПРОТОКОЛА
            //========================================================

            this.lblProtocolTypeInfo =
                CreateInfoTitle(
                    "Тип протокола:",
                    250);

            this.lblProtocolTypeValue =
                CreateInfoValue(
                    250);

            this.lblProtocolTypeValue.MaximumSize =
                new Size(
                    210,
                    0);

            //========================================================
            // МЕСТО СОСТАВЛЕНИЯ
            //========================================================

            this.lblPlaceInfo =
                CreateInfoTitle(
                    "Место составления:",
                    300);

            this.lblPlaceValue =
                CreateInfoValue(
                    300);

            this.lblPlaceValue.MaximumSize =
                new Size(
                    210,
                    0);

            //========================================================
            // СТАТУС
            //========================================================

            this.lblStatusInfo =
                CreateInfoTitle(
                    "Статус:",
                    360);

            this.lblStatusValue =
                CreateInfoValue(
                    360);

            //========================================================
            // ПРИМЕЧАНИЕ
            //========================================================

            this.lblNoteInfo =
                CreateInfoTitle(
                    "Примечание:",
                    410);

            this.lblNoteValue =
                CreateInfoValue(
                    410);

            this.lblNoteValue.MaximumSize =
                new Size(
                    210,
                    0);

            //========================================================
            // ADD
            //========================================================

            this.pnlProtocolInfo.Controls.Add(
                this.lblProtocolNumberInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblProtocolNumberValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblCaseInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblCaseValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblDateInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblDateValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblEmployeeInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblEmployeeValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblProtocolTypeInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblProtocolTypeValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblPlaceInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblPlaceValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblStatusInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblStatusValue);

            this.pnlProtocolInfo.Controls.Add(
                this.lblNoteInfo);

            this.pnlProtocolInfo.Controls.Add(
                this.lblNoteValue);
        }

        //============================================================
        // INFO TITLE
        //============================================================

        private Label CreateInfoTitle(
            string text,
            int top)
        {
            Label label =
                new Label();

            label.AutoSize =
                true;

            label.Text =
                text;

            label.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.White;

            label.Location =
                new Point(
                    20,
                    top);

            return label;
        }

        //============================================================
        // INFO VALUE
        //============================================================

        private Label CreateInfoValue(
            int top)
        {
            Label label =
                new Label();

            label.AutoSize =
                true;

            label.Font =
                new Font(
                    "Segoe UI",
                    10F);

            label.ForeColor =
                Color.Gainsboro;

            label.Location =
                new Point(
                    185,
                    top);

            return label;
        }

        //============================================================
        // INFO BUTTON STYLE
        //============================================================

        private void ConfigureInfoButton(
            IconButton button)
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
                    30,
                    58,
                    117);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);
        }

        #endregion
    }
}