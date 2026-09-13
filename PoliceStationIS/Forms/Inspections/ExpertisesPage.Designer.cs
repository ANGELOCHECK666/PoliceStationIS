using System;
using System.Drawing;
using System.Windows.Forms;

using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Expertises
{
    partial class ExpertisesPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        //============================================================
        // ОСНОВНЫЕ ПАНЕЛИ
        //============================================================

        private Panel pnlHeader;
        private Panel pnlSearch;
        private Panel pnlExpertises;
        private Panel pnlExpertiseInfo;

        //============================================================
        // HEADER
        //============================================================

        private Label lblTitle;
        private Label lblSubtitle;

        private IconButton btnAddExpertise;
        private IconButton btnEditExpertise;

        //============================================================
        // SEARCH
        //============================================================

        private Label lblSearch;

        private Label lblExpertiseNumber;
        private Label lblExpertiseType;
        private Label lblProtocol;
        private Label lblEmployee;
        private Label lblDateFrom;
        private Label lblDateTo;
        private Label lblStatus;

        private TextBox txtExpertiseNumber;

        private ComboBox cmbExpertiseType;
        private ComboBox cmbProtocol;
        private ComboBox cmbEmployee;
        private ComboBox cmbStatus;

        private DateTimePicker dtDateFrom;
        private DateTimePicker dtDateTo;

        private Button btnSearch;
        private Button btnReset;

        //============================================================
        // EXPERTISE LIST
        //============================================================

        private Label lblExpertises;

        private FlowLayoutPanel flpExpertises;

        //============================================================
        // PAGINATION
        //============================================================

        private Panel pnlPagination;

        private Button btnFirstPage;
        private Button btnPreviousPage;
        private Label lblPageInfo;
        private Button btnNextPage;
        private Button btnLastPage;

        //============================================================
        // INFORMATION
        //============================================================

        private Label lblExpertiseInformation;

        private Label lblExpertiseNumberInfo;
        private Label lblProtocolInfo;
        private Label lblAppointmentDateInfo;
        private Label lblEmployeeInfo;
        private Label lblExpertiseTypeInfo;
        private Label lblStatusInfo;
        private Label lblResearchStartInfo;
        private Label lblResearchEndInfo;
        private Label lblConclusionInfo;

        private Label lblExpertiseNumberValue;
        private Label lblProtocolValue;
        private Label lblAppointmentDateValue;
        private Label lblEmployeeValue;
        private Label lblExpertiseTypeValue;
        private Label lblStatusValue;
        private Label lblResearchStartValue;
        private Label lblResearchEndValue;
        private Label lblConclusionValue;

        //============================================================
        // RIGHT BUTTONS
        //============================================================

        private IconButton btnPrintExpertise;
        private IconButton btnDeleteExpertise;


        //============================================================
        // INITIALIZE
        //============================================================

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.SuspendLayout();

            //========================================================
            // ОСНОВНАЯ СТРАНИЦА
            //========================================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.Name =
                "ExpertisesPage";

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
                "Экспертизы";

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
                "Реестр назначенных и проведённых экспертиз";

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
            // ADD EXPERTISE
            //========================================================

            this.btnAddExpertise =
                new IconButton();

            this.btnAddExpertise.Text =
                "Добавить экспертизу";

            this.btnAddExpertise.Size =
                new Size(
                    205,
                    42);

            this.btnAddExpertise.Location =
                new Point(
                    855,
                    28);

            this.btnAddExpertise.ButtonIcon =
                Properties.Resources.expertise_gold;

            ConfigureHeaderButton(
                this.btnAddExpertise);


            //========================================================
            // EDIT EXPERTISE
            //========================================================

            this.btnEditExpertise =
                new IconButton();

            this.btnEditExpertise.Text =
                "Редактировать экспертизу";

            this.btnEditExpertise.Size =
                new Size(
                    220,
                    42);

            this.btnEditExpertise.Location =
                new Point(
                    1070,
                    28);

            this.btnEditExpertise.ButtonIcon =
                Properties.Resources.edit_gold_icon;

            ConfigureHeaderButton(
                this.btnEditExpertise);

            this.btnEditExpertise.ForeColor =
    Color.White;



            //========================================================
            // HEADER CONTROLS
            //========================================================

            this.pnlHeader.Controls.Add(
                pnlTitleLine);

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.btnAddExpertise);

            this.pnlHeader.Controls.Add(
                this.btnEditExpertise);


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
            // № ЭКСПЕРТИЗЫ
            //========================================================

            this.lblExpertiseNumber =
                CreateSearchLabel(
                    "№ экспертизы",
                    20,
                    52);

            this.txtExpertiseNumber =
                new TextBox();

            this.txtExpertiseNumber.Location =
                new Point(
                    20,
                    72);

            this.txtExpertiseNumber.Size =
                new Size(
                    175,
                    26);


            //========================================================
            // ТИП ЭКСПЕРТИЗЫ
            //========================================================

            this.lblExpertiseType =
                CreateSearchLabel(
                    "Тип экспертизы",
                    215,
                    52);

            this.cmbExpertiseType =
                CreateComboBox(
                    215,
                    72,
                    190);


            //========================================================
            // ПРОТОКОЛ
            //========================================================

            this.lblProtocol =
                CreateSearchLabel(
                    "Протокол",
                    425,
                    52);

            this.cmbProtocol =
                CreateComboBox(
                    425,
                    72,
                    190);


            //========================================================
            // СОТРУДНИК
            //========================================================

            this.lblEmployee =
                CreateSearchLabel(
                    "Сотрудник",
                    635,
                    52);

            this.cmbEmployee =
                CreateComboBox(
                    635,
                    72,
                    195);


            //========================================================
            // ДАТА С
            //========================================================

            this.lblDateFrom =
                CreateSearchLabel(
                    "Дата с",
                    20,
                    108);

            this.dtDateFrom =
                CreateDatePicker(
                    20,
                    128,
                    120);


            //========================================================
            // ДАТА ПО
            //========================================================

            this.lblDateTo =
                CreateSearchLabel(
                    "Дата по",
                    155,
                    108);

            this.dtDateTo =
                CreateDatePicker(
                    155,
                    128,
                    120);


            //========================================================
            // СТАТУС
            //========================================================

            this.lblStatus =
                CreateSearchLabel(
                    "Статус",
                    295,
                    108);

            this.cmbStatus =
                CreateComboBox(
                    295,
                    128,
                    185);


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
                    110);

            this.btnSearch.Size =
                new Size(
                    90,
                    35);

            ConfigureSearchButton(
                this.btnSearch);


            //========================================================
            // RESET BUTTON
            //========================================================

            this.btnReset =
                new Button();

            this.btnReset.Text =
                "Сброс";

            this.btnReset.Location =
                new Point(
                    748,
                    110);

            this.btnReset.Size =
                new Size(
                    85,
                    35);

            ConfigureResetButton(
                this.btnReset);


            //========================================================
            // ADD SEARCH CONTROLS
            //========================================================

            this.pnlSearch.Controls.Add(
                this.lblExpertiseNumber);

            this.pnlSearch.Controls.Add(
                this.txtExpertiseNumber);

            this.pnlSearch.Controls.Add(
                this.lblExpertiseType);

            this.pnlSearch.Controls.Add(
                this.cmbExpertiseType);

            this.pnlSearch.Controls.Add(
                this.lblProtocol);

            this.pnlSearch.Controls.Add(
                this.cmbProtocol);

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
            // EXPERTISES PANEL
            //========================================================

            this.pnlExpertises =
                new Panel();

            this.pnlExpertises.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlExpertises.Location =
                new Point(
                    20,
                    310);

            this.pnlExpertises.Size =
                new Size(
                    855,
                    490);

            this.pnlExpertises.BorderStyle =
                BorderStyle.FixedSingle;


            //========================================================
            // LIST TITLE
            //========================================================

            this.lblExpertises =
                new Label();

            this.lblExpertises.AutoSize =
                true;

            this.lblExpertises.Text =
                "СПИСОК ЭКСПЕРТИЗ";

            this.lblExpertises.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblExpertises.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblExpertises.Location =
                new Point(
                    18,
                    12);

            this.pnlExpertises.Controls.Add(
                this.lblExpertises);


            Panel pnlExpertisesLine =
                new Panel();

            pnlExpertisesLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlExpertisesLine.Location =
                new Point(
                    18,
                    38);

            pnlExpertisesLine.Size =
                new Size(
                    815,
                    1);

            this.pnlExpertises.Controls.Add(
                pnlExpertisesLine);


            //========================================================
            // FLOW PANEL
            //========================================================

            this.flpExpertises =
                new FlowLayoutPanel();

            this.flpExpertises.Location =
                new Point(
                    18,
                    50);

            this.flpExpertises.Size =
                new Size(
                    819,
                    345);

            this.flpExpertises.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.flpExpertises.FlowDirection =
                FlowDirection.TopDown;

            this.flpExpertises.WrapContents =
                false;

            this.flpExpertises.AutoScroll =
                false;

            this.flpExpertises.Padding =
                new Padding(
                    0);

            this.pnlExpertises.Controls.Add(
                this.flpExpertises);


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
                    405);

            this.pnlPagination.Size =
                new Size(
                    819,
                    55);

            this.pnlExpertises.Controls.Add(
                this.pnlPagination);


            this.btnFirstPage =
                CreatePaginationButton(
                    "<<",
                    220);

            this.btnPreviousPage =
                CreatePaginationButton(
                    "<",
                    265);

            this.lblPageInfo =
                new Label();

            this.lblPageInfo.AutoSize =
                true;

            this.lblPageInfo.Text =
                "0–0 из 0";

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
                CreatePaginationButton(
                    ">",
                    455);

            this.btnLastPage =
                CreatePaginationButton(
                    ">>",
                    500);


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

            this.pnlExpertiseInfo =
                new Panel();

            this.pnlExpertiseInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlExpertiseInfo.Location =
                new Point(
                    895,
                    140);

            this.pnlExpertiseInfo.Size =
                new Size(
                    425,
                    660);

            this.pnlExpertiseInfo.BorderStyle =
                BorderStyle.FixedSingle;


            //========================================================
            // INFORMATION TITLE
            //========================================================

            this.lblExpertiseInformation =
                new Label();

            this.lblExpertiseInformation.AutoSize =
                true;

            this.lblExpertiseInformation.Text =
                "ИНФОРМАЦИЯ ОБ ЭКСПЕРТИЗЕ";

            this.lblExpertiseInformation.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblExpertiseInformation.ForeColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            this.lblExpertiseInformation.Location =
                new Point(
                    18,
                    15);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblExpertiseInformation);


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

            this.pnlExpertiseInfo.Controls.Add(
                pnlInfoLine);


            //========================================================
            // INFORMATION LABELS
            //========================================================

            CreateInfoLabels();

            //========================================================
            // PRINT
            //========================================================

            this.btnPrintExpertise =
                new IconButton();

            this.btnPrintExpertise.Text =
                "Печать заключения";

            this.btnPrintExpertise.ForeColor =
    Color.White;

            this.btnPrintExpertise.ButtonIcon =
                Properties.Resources.printer_icon;

            this.btnPrintExpertise.Size =
                new Size(
                    385,
                    52);

            this.btnPrintExpertise.Location =
                new Point(
                    18,
                    465);

            this.btnPrintExpertise.FlatStyle =
                FlatStyle.Flat;

            this.btnPrintExpertise.FlatAppearance.BorderSize =
                1;

            this.btnPrintExpertise.ForeColor =
                Color.White;

            this.btnPrintExpertise.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            ConfigureInfoButton(
                this.btnPrintExpertise);
            this.btnPrintExpertise.ForeColor =
    Color.White;


            //========================================================
            // DELETE
            //========================================================

            this.btnDeleteExpertise =
                new IconButton();

            this.btnDeleteExpertise.Text =
                "Удалить экспертизу";

            this.btnDeleteExpertise.ButtonIcon =
                Properties.Resources.delete_gold_icon;

            this.btnDeleteExpertise.Size =
                new Size(
                    385,
                    52);

            this.btnDeleteExpertise.Location =
                new Point(
                    18,
                    527);

            this.btnDeleteExpertise.FlatStyle =
                FlatStyle.Flat;

            this.btnDeleteExpertise.FlatAppearance.BorderSize =
                1;

            this.btnDeleteExpertise.FlatAppearance.BorderColor =
                Color.FromArgb(
                    170,
                    115,
                    120);

            this.btnDeleteExpertise.BackColor =
                Color.FromArgb(
                    125,
                    75,
                    82);

            this.btnDeleteExpertise.ForeColor =
                Color.White;

            this.btnDeleteExpertise.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.pnlExpertiseInfo.Controls.Add(
                this.btnPrintExpertise);

            this.pnlExpertiseInfo.Controls.Add(
                this.btnDeleteExpertise);


            //========================================================
            // ADD MAIN PANELS
            //========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlExpertises);

            this.Controls.Add(
                this.pnlExpertiseInfo);


            this.ResumeLayout(false);
        }


        //============================================================
        // CREATE INFORMATION LABELS
        //============================================================

        private void CreateInfoLabels()
        {
            this.lblExpertiseNumberInfo =
                CreateInfoTitle(
                    "№ экспертизы:",
                    70);

            this.lblExpertiseNumberValue =
                CreateInfoValue(
                    70);


            this.lblProtocolInfo =
                CreateInfoTitle(
                    "№ протокола:",
                    108);

            this.lblProtocolValue =
                CreateInfoValue(
                    108);


            this.lblAppointmentDateInfo =
                CreateInfoTitle(
                    "Дата назначения:",
                    146);

            this.lblAppointmentDateValue =
                CreateInfoValue(
                    146);


            this.lblEmployeeInfo =
                CreateInfoTitle(
                    "Сотрудник:",
                    184);

            this.lblEmployeeValue =
                CreateInfoValue(
                    184);


            this.lblExpertiseTypeInfo =
                CreateInfoTitle(
                    "Тип экспертизы:",
                    222);

            this.lblExpertiseTypeValue =
                CreateInfoValue(
                    222);


            this.lblStatusInfo =
                CreateInfoTitle(
                    "Статус:",
                    260);

            this.lblStatusValue =
                CreateInfoValue(
                    260);


            this.lblResearchStartInfo =
                CreateInfoTitle(
                    "Начало исследования:",
                    298);

            this.lblResearchStartValue =
                CreateInfoValue(
                    298);


            this.lblResearchEndInfo =
                CreateInfoTitle(
                    "Окончание:",
                    336);

            this.lblResearchEndValue =
                CreateInfoValue(
                    336);


            this.lblConclusionInfo =
                CreateInfoTitle(
                    "Заключение:",
                    378);

            this.lblConclusionValue =
                CreateInfoValue(
                    378);

            this.lblConclusionValue.MaximumSize =
                new Size(
                    210,
                    70);

            this.lblConclusionValue.AutoSize =
                true;


            this.pnlExpertiseInfo.Controls.Add(
                this.lblExpertiseNumberInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblExpertiseNumberValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblProtocolInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblProtocolValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblAppointmentDateInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblAppointmentDateValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblEmployeeInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblEmployeeValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblExpertiseTypeInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblExpertiseTypeValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblStatusInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblStatusValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblResearchStartInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblResearchStartValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblResearchEndInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblResearchEndValue);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblConclusionInfo);

            this.pnlExpertiseInfo.Controls.Add(
                this.lblConclusionValue);
        }


        //============================================================
        // HELPERS
        //============================================================

        private Label CreateSearchLabel(
            string text,
            int x,
            int y)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.AutoSize =
                true;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.Location =
                new Point(
                    x,
                    y);

            return label;
        }


        private ComboBox CreateComboBox(
            int x,
            int y,
            int width)
        {
            ComboBox comboBox =
                new ComboBox();

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.Location =
                new Point(
                    x,
                    y);

            comboBox.Size =
                new Size(
                    width,
                    26);

            return comboBox;
        }


        private DateTimePicker CreateDatePicker(
            int x,
            int y,
            int width)
        {
            DateTimePicker picker =
                new DateTimePicker();

            picker.Format =
                DateTimePickerFormat.Short;

            picker.ShowCheckBox =
                true;

            picker.Checked =
                false;

            picker.Location =
                new Point(
                    x,
                    y);

            picker.Size =
                new Size(
                    width,
                    25);

            return picker;
        }


        private Button CreatePaginationButton(
            string text,
            int x)
        {
            Button button =
                new Button();

            button.Text =
                text;

            button.Size =
                new Size(
                    40,
                    30);

            button.Location =
                new Point(
                    x,
                    10);

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

            return button;
        }


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


        private void ConfigureHeaderButton(
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
        }


        private void ConfigureSearchButton(
            Button button)
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
        }


        private void ConfigureResetButton(
            Button button)
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
        }


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
    }
}