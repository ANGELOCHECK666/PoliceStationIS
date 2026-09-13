using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Departments
{
    partial class DepartmentsPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private PictureBox picDepartment;

        private Panel pnlMetrics;
        private Panel pnlMetricDepartments;
        private Panel pnlMetricEmployees;
        private Panel pnlMetricCases;
        private Panel pnlMetricAttention;
        private Label lblMetricDepartmentsTitle;
        private Label lblMetricEmployeesTitle;
        private Label lblMetricCasesTitle;
        private Label lblMetricAttentionTitle;
        private Label lblTotalDepartments;
        private Label lblTotalEmployees;
        private Label lblTotalActiveCases;
        private Label lblAttentionDepartments;

        private Panel pnlSearch;
        private Label lblSearchTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnReset;
        private Label lblFilter;
        private ComboBox cmbDepartmentFilter;

        private Panel pnlTable;
        private Label lblTableTitle;
        private Label lblTableSubtitle;
        private DataGridView dgvDepartments;
        private Panel pnlPagination;
        private Button btnFirst;
        private Button btnPrevious;
        private Label lblPage;
        private Button btnNext;
        private Button btnLast;
        private Label lblTotal;

        private Panel pnlInfo;
        private Label lblInfoTitle;
        private PictureBox picInfo;
        private Label lblInfoDepartment;
        private Label lblHeadCaption;
        private Label lblInfoHead;
        private Label lblEmployeesCaption;
        private Label lblInfoEmployees;
        private Label lblActiveEmployeesCaption;
        private Label lblInfoActiveEmployees;
        private Label lblActiveCasesCaption;
        private Label lblInfoActiveCases;
        private Label lblInspectionsCaption;
        private Label lblInfoInspections;
        private Label lblDogsCaption;
        private Label lblInfoDogs;
        private Label lblReadinessCaption;
        private Label lblInfoReadiness;
        private Label lblStatusCaption;
        private Label lblInfoStatus;
        private Panel pnlInfoLine;



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

            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.picDepartment = new PictureBox();

            this.pnlMetrics = new Panel();
            this.pnlMetricDepartments = new Panel();
            this.pnlMetricEmployees = new Panel();
            this.pnlMetricCases = new Panel();
            this.pnlMetricAttention = new Panel();

            this.lblMetricDepartmentsTitle = new Label();
            this.lblMetricEmployeesTitle = new Label();
            this.lblMetricCasesTitle = new Label();
            this.lblMetricAttentionTitle = new Label();

            this.lblTotalDepartments = new Label();
            this.lblTotalEmployees = new Label();
            this.lblTotalActiveCases = new Label();
            this.lblAttentionDepartments = new Label();

            this.pnlSearch = new Panel();
            this.lblSearchTitle = new Label();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnReset = new Button();
            this.lblFilter = new Label();
            this.cmbDepartmentFilter = new ComboBox();

            this.pnlTable = new Panel();
            this.lblTableTitle = new Label();
            this.lblTableSubtitle = new Label();
            this.dgvDepartments = new DataGridView();

            this.pnlPagination = new Panel();
            this.btnFirst = new Button();
            this.btnPrevious = new Button();
            this.lblPage = new Label();
            this.btnNext = new Button();
            this.btnLast = new Button();
            this.lblTotal = new Label();

            this.pnlInfo = new Panel();
            this.lblInfoTitle = new Label();
            this.picInfo = new PictureBox();
            this.lblInfoDepartment = new Label();
            this.lblHeadCaption = new Label();
            this.lblInfoHead = new Label();
            this.lblEmployeesCaption = new Label();
            this.lblInfoEmployees = new Label();
            this.lblActiveEmployeesCaption = new Label();
            this.lblInfoActiveEmployees = new Label();
            this.lblActiveCasesCaption = new Label();
            this.lblInfoActiveCases = new Label();
            this.lblInspectionsCaption = new Label();
            this.lblInfoInspections = new Label();
            this.lblDogsCaption = new Label();
            this.lblInfoDogs = new Label();
            this.lblReadinessCaption = new Label();
            this.lblInfoReadiness = new Label();
            this.lblStatusCaption = new Label();
            this.lblInfoStatus = new Label();
            this.pnlInfoLine = new Panel();

            this.SuspendLayout();

            // =========================================================
            // PAGE
            // =========================================================

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.Dock =
                DockStyle.Fill;

            this.Name =
                "DepartmentsPage";

            // =========================================================
            // HEADER
            // =========================================================

            this.pnlHeader.BackColor =
                Color.FromArgb(15, 39, 78);

            this.pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlHeader.Location =
                new Point(20, 20);

            this.pnlHeader.Size =
                new Size(0, 88);

            this.pnlHeader.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    21F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(25, 16);

            this.lblTitle.Text =
                "Подразделения";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(27, 55);

            this.lblSubtitle.Text =
                "Центр управления состоянием и работой подразделений";

            this.picDepartment.Size =
                new Size(70, 70);

            this.picDepartment.Location =
                new Point(0, 8);

            this.picDepartment.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.picDepartment.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picDepartment.BackColor =
                Color.Transparent;

            try
            {
                this.picDepartment.Image =
                    Properties.Resources.departments_gold_icon;
            }
            catch
            {
                this.picDepartment.Image = null;
            }

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.picDepartment);

            // =========================================================
            // METRICS
            // =========================================================

            this.pnlMetrics.BackColor =
                Color.Transparent;

            this.pnlMetrics.Location =
                new Point(20, 120);

            this.pnlMetrics.Size =
                new Size(0, 92);

            this.pnlMetrics.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            ConfigureMetricCard(
                this.pnlMetricDepartments,
                this.lblMetricDepartmentsTitle,
                this.lblTotalDepartments,
                "ПОДРАЗДЕЛЕНИЙ",
                0);

            ConfigureMetricCard(
                this.pnlMetricEmployees,
                this.lblMetricEmployeesTitle,
                this.lblTotalEmployees,
                "СОТРУДНИКОВ",
                1);

            ConfigureMetricCard(
                this.pnlMetricCases,
                this.lblMetricCasesTitle,
                this.lblTotalActiveCases,
                "АКТИВНЫХ ДЕЛ",
                2);

            ConfigureMetricCard(
                this.pnlMetricAttention,
                this.lblMetricAttentionTitle,
                this.lblAttentionDepartments,
                "ТРЕБУЮТ ВНИМАНИЯ",
                3);

            this.pnlMetrics.Controls.Add(
                this.pnlMetricDepartments);

            this.pnlMetrics.Controls.Add(
                this.pnlMetricEmployees);

            this.pnlMetrics.Controls.Add(
                this.pnlMetricCases);

            this.pnlMetrics.Controls.Add(
                this.pnlMetricAttention);

            // =========================================================
            // SEARCH
            // =========================================================

            this.pnlSearch.BackColor =
                Color.FromArgb(11, 31, 65);

            this.pnlSearch.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlSearch.Location =
                new Point(20, 227);

            this.pnlSearch.Size =
                new Size(0, 92);

            this.pnlSearch.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblSearchTitle.ForeColor =
                Color.Gold;

            this.lblSearchTitle.Location =
                new Point(18, 11);

            this.lblSearchTitle.Text =
                "ПОИСК И ФИЛЬТР";

            this.txtSearch.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            this.txtSearch.Location =
                new Point(18, 43);

            this.txtSearch.Size =
                new Size(320, 28);

            this.txtSearch.BackColor =
                Color.White;

            this.txtSearch.ForeColor =
                Color.FromArgb(20, 30, 45);

            this.txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            this.btnSearch.Text =
                "Найти";

            this.btnSearch.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnSearch.ForeColor =
                Color.FromArgb(5, 24, 58);

            this.btnSearch.BackColor =
                Color.FromArgb(225, 176, 61);

            this.btnSearch.FlatStyle =
                FlatStyle.Flat;

            this.btnSearch.FlatAppearance.BorderColor =
                Color.FromArgb(225, 176, 61);

            this.btnSearch.Location =
                new Point(350, 42);

            this.btnSearch.Size =
                new Size(90, 32);

            this.btnReset.Text =
                "Сброс";

            this.btnReset.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnReset.ForeColor =
                Color.White;

            this.btnReset.BackColor =
                Color.FromArgb(18, 43, 84);

            this.btnReset.FlatStyle =
                FlatStyle.Flat;

            this.btnReset.FlatAppearance.BorderColor =
                Color.FromArgb(70, 96, 140);

            this.btnReset.Location =
                new Point(445, 42);

            this.btnReset.Size =
                new Size(90, 32);

            this.lblFilter.AutoSize = true;
            this.lblFilter.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblFilter.ForeColor =
                Color.Gainsboro;

            this.lblFilter.Location =
                new Point(565, 50);

            this.lblFilter.Text =
                "Подразделение:";

            this.cmbDepartmentFilter.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbDepartmentFilter.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.cmbDepartmentFilter.Location =
                new Point(675, 44);

            this.cmbDepartmentFilter.Size =
                new Size(300, 28);

            this.cmbDepartmentFilter.BackColor =
                Color.White;

            this.cmbDepartmentFilter.ForeColor =
                Color.FromArgb(20, 30, 45);

            this.pnlSearch.Controls.Add(
                this.lblSearchTitle);

            this.pnlSearch.Controls.Add(
                this.txtSearch);

            this.pnlSearch.Controls.Add(
                this.btnSearch);

            this.pnlSearch.Controls.Add(
                this.btnReset);

            this.pnlSearch.Controls.Add(
                this.lblFilter);

            this.pnlSearch.Controls.Add(
                this.cmbDepartmentFilter);

            // =========================================================
            // TABLE
            // =========================================================

            this.pnlTable.BackColor =
                Color.FromArgb(11, 31, 65);

            this.pnlTable.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlTable.Location =
                new Point(20, 334);

            this.pnlTable.Size =
                new Size(0, 415);

            this.pnlTable.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Bottom;

            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblTableTitle.ForeColor =
                Color.White;

            this.lblTableTitle.Location =
                new Point(18, 12);

            this.lblTableTitle.Text =
                "Подразделения";

            this.lblTableSubtitle.AutoSize = true;
            this.lblTableSubtitle.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            this.lblTableSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblTableSubtitle.Location =
                new Point(170, 17);

            this.lblTableSubtitle.Text =
                "Нажмите на строку для просмотра подробной информации";

            this.dgvDepartments.Location =
                new Point(12, 48);

            this.dgvDepartments.Size =
                new Size(0, 300);

            this.dgvDepartments.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.dgvDepartments.BackgroundColor =
                Color.FromArgb(11, 31, 65);

            this.dgvDepartments.BorderStyle =
                BorderStyle.None;

            this.dgvDepartments.GridColor =
                Color.FromArgb(35, 56, 91);

            this.dgvDepartments.EnableHeadersVisualStyles =
                false;

            this.dgvDepartments.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(18, 43, 84);

            this.dgvDepartments.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Gainsboro;

            this.dgvDepartments.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.dgvDepartments.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvDepartments.ColumnHeadersHeight =
                42;

            this.dgvDepartments.DefaultCellStyle.BackColor =
                Color.FromArgb(15, 39, 78);

            this.dgvDepartments.DefaultCellStyle.ForeColor =
                Color.Gainsboro;

            this.dgvDepartments.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.dgvDepartments.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(28, 48, 84);

            this.dgvDepartments.DefaultCellStyle.SelectionForeColor =
                Color.White;

            this.dgvDepartments.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvDepartments.RowTemplate.Height =
                40;

            this.dgvDepartments.AllowUserToAddRows =
                false;

            this.dgvDepartments.AllowUserToDeleteRows =
                false;

            this.dgvDepartments.AllowUserToResizeRows =
                false;

            this.dgvDepartments.ReadOnly =
                true;

            this.dgvDepartments.MultiSelect =
                false;

            this.dgvDepartments.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvDepartments.RowHeadersVisible =
                false;

            this.dgvDepartments.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            this.pnlTable.Controls.Add(
                this.lblTableTitle);

            this.pnlTable.Controls.Add(
                this.lblTableSubtitle);

            this.pnlTable.Controls.Add(
                this.dgvDepartments);

            // =========================================================
            // PAGINATION
            // =========================================================

            this.pnlPagination.BackColor =
                Color.FromArgb(11, 31, 65);

            this.pnlPagination.Location =
                new Point(12, 355);

            this.pnlPagination.Size =
                new Size(0, 42);

            this.pnlPagination.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            ConfigurePaginationButton(
                this.btnFirst,
                "«");

            ConfigurePaginationButton(
                this.btnPrevious,
                "‹");

            ConfigurePaginationButton(
                this.btnNext,
                "›");

            ConfigurePaginationButton(
                this.btnLast,
                "»");

            this.btnFirst.Location =
                new Point(4, 3);

            this.btnPrevious.Location =
                new Point(43, 3);

            this.lblPage.AutoSize = true;
            this.lblPage.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblPage.ForeColor =
                Color.Gainsboro;

            this.lblPage.Location =
                new Point(90, 12);

            this.btnNext.Location =
                new Point(218, 3);

            this.btnLast.Location =
                new Point(257, 3);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblTotal.ForeColor =
                Color.Gainsboro;

            this.lblTotal.Location =
                new Point(330, 12);

            this.pnlPagination.Controls.Add(
                this.btnFirst);

            this.pnlPagination.Controls.Add(
                this.btnPrevious);

            this.pnlPagination.Controls.Add(
                this.lblPage);

            this.pnlPagination.Controls.Add(
                this.btnNext);

            this.pnlPagination.Controls.Add(
                this.btnLast);

            this.pnlPagination.Controls.Add(
                this.lblTotal);

            this.pnlTable.Controls.Add(
                this.pnlPagination);

            // =========================================================
            // INFO PANEL
            // =========================================================

            this.pnlInfo.BackColor =
                Color.FromArgb(11, 31, 65);

            this.pnlInfo.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlInfo.Location =
                new Point(0, 334);

            this.pnlInfo.Size =
                new Size(0, 415);

            this.pnlInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblInfoTitle.ForeColor =
                Color.White;

            this.lblInfoTitle.Location =
                new Point(18, 12);

            this.lblInfoTitle.Text =
                "Информация о подразделении";

            this.picInfo.Size =
                new Size(58, 58);

            this.picInfo.Location =
                new Point(18, 52);

            this.picInfo.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picInfo.BackColor =
                Color.Transparent;

            try
            {
                this.picInfo.Image =
                    Properties.Resources.departments_gold_icon;
            }
            catch
            {
                this.picInfo.Image = null;
            }

            this.lblInfoDepartment.AutoSize = true;
            this.lblInfoDepartment.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblInfoDepartment.ForeColor =
                Color.White;

            this.lblInfoDepartment.Location =
                new Point(88, 54);

            this.lblInfoDepartment.MaximumSize =
                new Size(330, 40);

            this.lblInfoDepartment.Text =
                "Подразделение не выбрано";

            this.pnlInfoLine.BackColor =
                Color.FromArgb(45, 64, 95);

            this.pnlInfoLine.Location =
                new Point(18, 120);

            this.pnlInfoLine.Size =
                new Size(0, 1);

            this.pnlInfoLine.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            ConfigureInfoRow(
                this.lblHeadCaption,
                this.lblInfoHead,
                "Начальник:",
                "—",
                18,
                132);

            ConfigureInfoRow(
                this.lblEmployeesCaption,
                this.lblInfoEmployees,
                "Сотрудников:",
                "—",
                18,
                160);

            ConfigureInfoRow(
                this.lblActiveEmployeesCaption,
                this.lblInfoActiveEmployees,
                "На службе:",
                "—",
                18,
                188);

            ConfigureInfoRow(
                this.lblActiveCasesCaption,
                this.lblInfoActiveCases,
                "Активных дел:",
                "—",
                18,
                216);

            ConfigureInfoRow(
                this.lblInspectionsCaption,
                this.lblInfoInspections,
                "Экспертиз:",
                "—",
                18,
                244);

            ConfigureInfoRow(
                this.lblDogsCaption,
                this.lblInfoDogs,
                "Служебных собак:",
                "—",
                18,
                272);

            ConfigureInfoRow(
                this.lblReadinessCaption,
                this.lblInfoReadiness,
                "Готовность:",
                "—",
                18,
                300);

            ConfigureInfoRow(
                this.lblStatusCaption,
                this.lblInfoStatus,
                "Состояние:",
                "—",
                18,
                328);

            this.pnlInfo.Controls.Add(
                this.lblInfoTitle);

            this.pnlInfo.Controls.Add(
                this.picInfo);

            this.pnlInfo.Controls.Add(
                this.lblInfoDepartment);

            this.pnlInfo.Controls.Add(
                this.pnlInfoLine);

            this.pnlInfo.Controls.Add(
                this.lblHeadCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoHead);

            this.pnlInfo.Controls.Add(
                this.lblEmployeesCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoEmployees);

            this.pnlInfo.Controls.Add(
                this.lblActiveEmployeesCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoActiveEmployees);

            this.pnlInfo.Controls.Add(
                this.lblActiveCasesCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoActiveCases);

            this.pnlInfo.Controls.Add(
                this.lblInspectionsCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoInspections);

            this.pnlInfo.Controls.Add(
                this.lblDogsCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoDogs);

            this.pnlInfo.Controls.Add(
                this.lblReadinessCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoReadiness);

            this.pnlInfo.Controls.Add(
                this.lblStatusCaption);

            this.pnlInfo.Controls.Add(
                this.lblInfoStatus);

            // =========================================================
            // ADD CONTROLS
            // =========================================================

            this.Controls.Add(
                this.pnlHeader);

            this.Controls.Add(
                this.pnlMetrics);

            this.Controls.Add(
                this.pnlSearch);

            this.Controls.Add(
                this.pnlTable);

            this.Controls.Add(
                this.pnlInfo);

            // =========================================================
            // RESIZE
            // =========================================================

            this.Resize +=
                DepartmentsPage_Resize;

            DepartmentsPage_Resize(
                null,
                EventArgs.Empty);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigureMetricCard(
            Panel panel,
            Label title,
            Label value,
            string titleText,
            int index)
        {
            panel.BackColor =
                Color.FromArgb(15, 39, 78);

            panel.BorderStyle =
                BorderStyle.FixedSingle;

            panel.Location =
                new Point(0, 0);

            panel.Size =
                new Size(0, 92);

            panel.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;

            title.AutoSize = true;
            title.Font =
                new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold);

            title.ForeColor =
                Color.Gainsboro;

            title.Location =
                new Point(15, 13);

            title.Text =
                titleText;

            value.AutoSize = true;
            value.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold);

            value.ForeColor =
                Color.Gold;

            value.Location =
                new Point(14, 34);

            value.Text =
                "0";

            panel.Controls.Add(title);
            panel.Controls.Add(value);
        }

        private void ConfigureInfoRow(
            Label caption,
            Label value,
            string captionText,
            string valueText,
            int x,
            int y)
        {
            caption.AutoSize = true;
            caption.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            caption.ForeColor =
                Color.Gainsboro;

            caption.Location =
                new Point(x, y);

            caption.Text =
                captionText;

            value.AutoSize = true;
            value.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            value.ForeColor =
                Color.White;

            value.Location =
                new Point(x + 140, y - 1);

            value.Text =
                valueText;

            value.MaximumSize =
                new Size(280, 35);
        }

        private void ConfigurePaginationButton(
            Button button,
            string text)
        {
            button.Text =
                text;

            button.Size =
                new Size(35, 34);

            button.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            button.ForeColor =
                Color.White;

            button.BackColor =
                Color.FromArgb(18, 43, 84);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(70, 96, 140);
        }

        private void DepartmentsPage_Resize(
            object sender,
            EventArgs e)
        {
            if (Width <= 0 ||
                Height <= 0)
                return;

            int contentWidth =
                ClientSize.Width - 40;

            int infoWidth = 455;
            int gap = 15;
            int lowerTop = 334;

            int lowerHeight =
                ClientSize.Height -
                lowerTop -
                12;

            if (lowerHeight < 300)
                lowerHeight = 300;

            // Header, cards and search occupy the full content width.
            pnlHeader.Width =
                contentWidth;

            pnlMetrics.Width =
                contentWidth;

            int metricGap = 12;
            int metricWidth =
                (contentWidth -
                 metricGap * 3) / 4;

            pnlMetricDepartments.Width =
                metricWidth;

            pnlMetricEmployees.Width =
                metricWidth;

            pnlMetricCases.Width =
                metricWidth;

            pnlMetricAttention.Width =
                metricWidth;

            pnlMetricEmployees.Left =
                metricWidth + metricGap;

            pnlMetricCases.Left =
                (metricWidth + metricGap) * 2;

            pnlMetricAttention.Left =
                (metricWidth + metricGap) * 3;

            pnlSearch.Width =
                contentWidth;

            // Main area: table + selected department information.
            pnlTable.Width =
                contentWidth -
                infoWidth -
                gap;

            pnlTable.Height =
                lowerHeight;

            pnlInfo.Width =
                infoWidth;

            pnlInfo.Height =
                lowerHeight;

            pnlInfo.Left =
                20 +
                pnlTable.Width +
                gap;

            dgvDepartments.Width =
                pnlTable.Width - 24;

            dgvDepartments.Height =
                Math.Max(
                    220,
                    pnlTable.Height - 105);

            pnlPagination.Width =
                pnlTable.Width - 24;

            pnlPagination.Top =
                pnlTable.Height - 48;
        }
    }
}
