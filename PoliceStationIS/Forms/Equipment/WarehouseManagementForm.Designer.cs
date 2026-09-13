namespace PoliceStationIS.Forms.Equipment
{
    partial class WarehouseManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;

        private System.Windows.Forms.TextBox txtEquipmentName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.DataGridView dgvWarehouse;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Panel pnlInfoLine;

        private System.Windows.Forms.Label lblInfoNameTitle;
        private System.Windows.Forms.Label lblInfoNameValue;
        private System.Windows.Forms.Label lblInfoCategoryTitle;
        private System.Windows.Forms.Label lblInfoCategoryValue;
        private System.Windows.Forms.Label lblInfoStatusTitle;
        private System.Windows.Forms.Label lblInfoStatusValue;
        private System.Windows.Forms.Label lblInfoQuantityTitle;
        private System.Windows.Forms.Label lblInfoQuantityValue;
        private System.Windows.Forms.Label lblInfoDateTitle;
        private System.Windows.Forms.Label lblInfoDateValue;

        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();

            this.txtEquipmentName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.pnlList = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.pnlInfoLine = new System.Windows.Forms.Panel();

            this.lblInfoNameTitle = new System.Windows.Forms.Label();
            this.lblInfoNameValue = new System.Windows.Forms.Label();
            this.lblInfoCategoryTitle = new System.Windows.Forms.Label();
            this.lblInfoCategoryValue = new System.Windows.Forms.Label();
            this.lblInfoStatusTitle = new System.Windows.Forms.Label();
            this.lblInfoStatusValue = new System.Windows.Forms.Label();
            this.lblInfoQuantityTitle = new System.Windows.Forms.Label();
            this.lblInfoQuantityValue = new System.Windows.Forms.Label();
            this.lblInfoDateTitle = new System.Windows.Forms.Label();
            this.lblInfoDateValue = new System.Windows.Forms.Label();

            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(11, 27, 58);
            this.ClientSize = new System.Drawing.Size(1060, 700);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WarehouseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление складом";
            this.ShowInTaskbar = false;

            // TITLE
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Управление складом";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font(
                "Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(31, 58);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text =
                "Просмотр и управление остатками имущества";

            // SEARCH PANEL
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Location = new System.Drawing.Point(25, 90);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1010, 145);

            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblSearchTitle.Location = new System.Drawing.Point(17, 10);
            this.lblSearchTitle.Text = "ПОИСК И ФИЛЬТРЫ";

            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblName.Location = new System.Drawing.Point(18, 43);
            this.lblName.Text = "Наименование";

            this.txtEquipmentName.BackColor =
                System.Drawing.Color.FromArgb(30, 58, 117);
            this.txtEquipmentName.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEquipmentName.ForeColor = System.Drawing.Color.White;
            this.txtEquipmentName.Location = new System.Drawing.Point(18, 63);
            this.txtEquipmentName.Size = new System.Drawing.Size(210, 23);

            this.lblCategory.AutoSize = true;
            this.lblCategory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCategory.Location = new System.Drawing.Point(244, 43);
            this.lblCategory.Text = "Категория";

            this.cmbCategory.Location = new System.Drawing.Point(244, 63);
            this.cmbCategory.Size = new System.Drawing.Size(175, 23);

            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.Location = new System.Drawing.Point(435, 43);
            this.lblStatus.Text = "Статус";

            this.cmbStatus.Location = new System.Drawing.Point(435, 63);
            this.cmbStatus.Size = new System.Drawing.Size(165, 23);

            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateFrom.Location = new System.Drawing.Point(615, 43);
            this.lblDateFrom.Text = "Дата выдачи с";

            this.dtpDateFrom.Location = new System.Drawing.Point(615, 63);
            this.dtpDateFrom.Size = new System.Drawing.Size(145, 23);

            this.lblDateTo.AutoSize = true;
            this.lblDateTo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateTo.Location = new System.Drawing.Point(775, 43);
            this.lblDateTo.Text = "Дата выдачи по";

            this.dtpDateTo.Location = new System.Drawing.Point(775, 63);
            this.dtpDateTo.Size = new System.Drawing.Size(145, 23);

            this.btnSearch.BackColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(690, 101);
            this.btnSearch.Size = new System.Drawing.Size(105, 31);
            this.btnSearch.Text = "Найти";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnReset.BackColor =
                System.Drawing.Color.FromArgb(42, 73, 133);
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderSize = 1;
            this.btnReset.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(805, 101);
            this.btnReset.Size = new System.Drawing.Size(105, 31);
            this.btnReset.Text = "Сброс";
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Controls.Add(this.lblName);
            this.pnlSearch.Controls.Add(this.txtEquipmentName);
            this.pnlSearch.Controls.Add(this.lblCategory);
            this.pnlSearch.Controls.Add(this.cmbCategory);
            this.pnlSearch.Controls.Add(this.lblStatus);
            this.pnlSearch.Controls.Add(this.cmbStatus);
            this.pnlSearch.Controls.Add(this.lblDateFrom);
            this.pnlSearch.Controls.Add(this.dtpDateFrom);
            this.pnlSearch.Controls.Add(this.lblDateTo);
            this.pnlSearch.Controls.Add(this.dtpDateTo);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.btnReset);

            // LIST PANEL
            this.pnlList.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Location = new System.Drawing.Point(25, 250);
            this.pnlList.Size = new System.Drawing.Size(675, 385);

            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblListTitle.Location = new System.Drawing.Point(17, 10);
            this.lblListTitle.Text = "ОСТАТКИ НА СКЛАДЕ";

            this.lblResultCount.AutoSize = true;
            this.lblResultCount.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblResultCount.Location = new System.Drawing.Point(500, 13);
            this.lblResultCount.Text = "Позиций: 0";

            this.dgvWarehouse.BackgroundColor =
                System.Drawing.Color.FromArgb(18, 38, 74);
            this.dgvWarehouse.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.dgvWarehouse.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvWarehouse.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(30, 58, 117);
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 8.5F,
                    System.Drawing.FontStyle.Bold);
            this.dgvWarehouse.ColumnHeadersHeight = 34;
            this.dgvWarehouse.DefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(24, 47, 91);
            this.dgvWarehouse.DefaultCellStyle.ForeColor =
                System.Drawing.Color.Gainsboro;
            this.dgvWarehouse.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(42, 73, 133);
            this.dgvWarehouse.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;
            this.dgvWarehouse.EnableHeadersVisualStyles = false;
            this.dgvWarehouse.GridColor =
                System.Drawing.Color.FromArgb(42, 73, 133);
            this.dgvWarehouse.Location = new System.Drawing.Point(17, 42);
            this.dgvWarehouse.RowTemplate.Height = 35;
            this.dgvWarehouse.Size = new System.Drawing.Size(638, 325);
            this.dgvWarehouse.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;

            this.dgvWarehouse.Columns.Add(
                CreateTextColumn(
                    "colName",
                    "Наименование",
                    "equipment_name",
                    185));
            this.dgvWarehouse.Columns.Add(
                CreateTextColumn(
                    "colCategory",
                    "Категория",
                    "equipment_category_name",
                    120));
            this.dgvWarehouse.Columns.Add(
                CreateTextColumn(
                    "colStatus",
                    "Статус",
                    "equipment_status_name",
                    105));
            this.dgvWarehouse.Columns.Add(
                CreateTextColumn(
                    "colQuantity",
                    "Количество",
                    "quantity",
                    95));
            this.dgvWarehouse.Columns.Add(
                CreateTextColumn(
                    "colDate",
                    "Дата",
                    "first_issue_date",
                    105));
            // ADD LIST CONTROLS TO LIST PANEL
            this.pnlList.Controls.Add(this.dgvWarehouse);
            this.pnlList.Controls.Add(this.lblResultCount);
            this.pnlList.Controls.Add(this.lblListTitle);

            // INFO PANEL
            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Location = new System.Drawing.Point(720, 250);
            this.pnlInfo.Size = new System.Drawing.Size(315, 385);

            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font(
                "Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblInfoTitle.Location = new System.Drawing.Point(17, 10);
            this.lblInfoTitle.Text = "ИНФОРМАЦИЯ ОБ ИМУЩЕСТВЕ";

            this.pnlInfoLine.BackColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.pnlInfoLine.Location = new System.Drawing.Point(17, 38);
            this.pnlInfoLine.Size = new System.Drawing.Size(278, 1);

            CreateInfoPair(
                this.lblInfoNameTitle,
                this.lblInfoNameValue,
                "Наименование:",
                20, 62);

            CreateInfoPair(
                this.lblInfoCategoryTitle,
                this.lblInfoCategoryValue,
                "Категория:",
                20, 120);

            CreateInfoPair(
                this.lblInfoStatusTitle,
                this.lblInfoStatusValue,
                "Статус:",
                20, 178);

            CreateInfoPair(
                this.lblInfoQuantityTitle,
                this.lblInfoQuantityValue,
                "Количество единиц:",
                20, 236);

            CreateInfoPair(
                this.lblInfoDateTitle,
                this.lblInfoDateValue,
                "Дата выдачи:",
                20, 294);

            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.Controls.Add(this.pnlInfoLine);
            this.pnlInfo.Controls.Add(this.lblInfoNameTitle);
            this.pnlInfo.Controls.Add(this.lblInfoNameValue);
            this.pnlInfo.Controls.Add(this.lblInfoCategoryTitle);
            this.pnlInfo.Controls.Add(this.lblInfoCategoryValue);
            this.pnlInfo.Controls.Add(this.lblInfoStatusTitle);
            this.pnlInfo.Controls.Add(this.lblInfoStatusValue);
            this.pnlInfo.Controls.Add(this.lblInfoQuantityTitle);
            this.pnlInfo.Controls.Add(this.lblInfoQuantityValue);
            this.pnlInfo.Controls.Add(this.lblInfoDateTitle);
            this.pnlInfo.Controls.Add(this.lblInfoDateValue);

            // CLOSE
            this.btnClose.BackColor =
                System.Drawing.Color.FromArgb(42, 73, 133);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatAppearance.BorderColor =
                System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(910, 650);
            this.btnClose.Size = new System.Drawing.Size(125, 32);
            this.btnClose.Text = "Закрыть";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.ResumeLayout(false);
            this.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTextColumn(
            string name,
            string header,
            string dataProperty,
            int width)
        {
            return new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty,
                Width = width,
                SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
            };
        }

        private void CreateInfoPair(
            System.Windows.Forms.Label title,
            System.Windows.Forms.Label value,
            string titleText,
            int x,
            int y)
        {
            title.AutoSize = true;
            title.ForeColor = System.Drawing.Color.Gainsboro;
            title.Font = new System.Drawing.Font("Segoe UI", 9F);
            title.Location = new System.Drawing.Point(x, y);
            title.Text = titleText;

            value.AutoSize = false;
            value.ForeColor = System.Drawing.Color.Gainsboro;
            value.Font = new System.Drawing.Font(
                "Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            value.Location = new System.Drawing.Point(x, y + 23);
            value.Size = new System.Drawing.Size(275, 25);
            value.Text = "—";
        }
    }
}