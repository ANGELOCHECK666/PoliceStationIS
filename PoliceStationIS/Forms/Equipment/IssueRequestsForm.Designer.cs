namespace PoliceStationIS.Forms.Equipment
{
    partial class IssueRequestsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFiltersTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.ComboBox cmbRequestStatus;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;

        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.DataGridView dgvRequests;

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfoRequest;
        private System.Windows.Forms.Label lblInfoRequestValue;
        private System.Windows.Forms.Label lblInfoEmployee;
        private System.Windows.Forms.Label lblInfoEmployeeValue;
        private System.Windows.Forms.Label lblInfoCategory;
        private System.Windows.Forms.Label lblInfoCategoryValue;
        private System.Windows.Forms.Label lblInfoEquipment;
        private System.Windows.Forms.Label lblInfoEquipmentValue;
        private System.Windows.Forms.Label lblInfoDate;
        private System.Windows.Forms.Label lblInfoDateValue;
        private System.Windows.Forms.Label lblInfoStatus;
        private System.Windows.Forms.Label lblInfoStatusValue;
        private System.Windows.Forms.Label lblInfoComment;
        private System.Windows.Forms.Label lblInfoCommentValue;

        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
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

            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblFiltersTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.cmbRequestStatus = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();

            this.pnlList = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();

            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblInfoRequest = new System.Windows.Forms.Label();
            this.lblInfoRequestValue = new System.Windows.Forms.Label();
            this.lblInfoEmployee = new System.Windows.Forms.Label();
            this.lblInfoEmployeeValue = new System.Windows.Forms.Label();
            this.lblInfoCategory = new System.Windows.Forms.Label();
            this.lblInfoCategoryValue = new System.Windows.Forms.Label();
            this.lblInfoEquipment = new System.Windows.Forms.Label();
            this.lblInfoEquipmentValue = new System.Windows.Forms.Label();
            this.lblInfoDate = new System.Windows.Forms.Label();
            this.lblInfoDateValue = new System.Windows.Forms.Label();
            this.lblInfoStatus = new System.Windows.Forms.Label();
            this.lblInfoStatusValue = new System.Windows.Forms.Label();
            this.lblInfoComment = new System.Windows.Forms.Label();
            this.lblInfoCommentValue = new System.Windows.Forms.Label();

            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.pnlFilters.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(12, 29, 58);
            this.ClientSize = new System.Drawing.Size(1060, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заявки на выдачу";
            this.Name = "IssueRequestsForm";

            this.lblTitle.Text = "Заявки на выдачу";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Обработка заявок на выдачу имущества сотрудникам";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubtitle.Location = new System.Drawing.Point(27, 53);
            this.lblSubtitle.AutoSize = true;

            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilters.Location = new System.Drawing.Point(20, 82);
            this.pnlFilters.Size = new System.Drawing.Size(1020, 150);

            this.lblFiltersTitle.Text = "ПОИСК И ФИЛЬТРЫ";
            this.lblFiltersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiltersTitle.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblFiltersTitle.Location = new System.Drawing.Point(15, 10);
            this.lblFiltersTitle.AutoSize = true;

            this.lblStatus.Text = "Статус заявки";
            this.lblStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.Location = new System.Drawing.Point(15, 42);
            this.lblStatus.AutoSize = true;

            this.lblEmployee.Text = "Сотрудник";
            this.lblEmployee.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEmployee.Location = new System.Drawing.Point(215, 42);
            this.lblEmployee.AutoSize = true;

            this.lblCategory.Text = "Категория";
            this.lblCategory.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCategory.Location = new System.Drawing.Point(415, 42);
            this.lblCategory.AutoSize = true;

            this.lblDateFrom.Text = "Дата заявки с";
            this.lblDateFrom.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateFrom.Location = new System.Drawing.Point(615, 42);
            this.lblDateFrom.AutoSize = true;

            this.lblDateTo.Text = "Дата заявки по";
            this.lblDateTo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDateTo.Location = new System.Drawing.Point(765, 42);
            this.lblDateTo.AutoSize = true;

            this.cmbRequestStatus.Location = new System.Drawing.Point(15, 63);
            this.cmbRequestStatus.Size = new System.Drawing.Size(185, 25);

            this.cmbEmployee.Location = new System.Drawing.Point(215, 63);
            this.cmbEmployee.Size = new System.Drawing.Size(185, 25);

            this.cmbCategory.Location = new System.Drawing.Point(415, 63);
            this.cmbCategory.Size = new System.Drawing.Size(185, 25);

            this.dtpDateFrom.Location = new System.Drawing.Point(615, 63);
            this.dtpDateFrom.Size = new System.Drawing.Size(135, 23);

            this.dtpDateTo.Location = new System.Drawing.Point(765, 63);
            this.dtpDateTo.Size = new System.Drawing.Size(135, 23);

            this.btnSearch.Text = "Найти";
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(615, 103);
            this.btnSearch.Size = new System.Drawing.Size(135, 30);
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnReset.Text = "Сброс";
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(42, 73, 133);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(765, 103);
            this.btnReset.Size = new System.Drawing.Size(135, 30);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlFilters.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblFiltersTitle, this.lblStatus, this.lblEmployee,
                this.lblCategory, this.lblDateFrom, this.lblDateTo,
                this.cmbRequestStatus, this.cmbEmployee, this.cmbCategory,
                this.dtpDateFrom, this.dtpDateTo, this.btnSearch, this.btnReset
            });

            this.pnlList.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlList.Location = new System.Drawing.Point(20, 247);
            this.pnlList.Size = new System.Drawing.Size(675, 395);

            this.lblListTitle.Text = "СПИСОК ЗАЯВОК";
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblListTitle.Location = new System.Drawing.Point(15, 10);
            this.lblListTitle.AutoSize = true;

            this.lblResultCount.Text = "Заявок: 0";
            this.lblResultCount.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblResultCount.Location = new System.Drawing.Point(560, 12);
            this.lblResultCount.AutoSize = true;

            this.dgvRequests.Location = new System.Drawing.Point(12, 42);
            this.dgvRequests.Size = new System.Drawing.Size(649, 337);
            this.dgvRequests.BackgroundColor = System.Drawing.Color.FromArgb(14, 31, 62);
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.GridColor = System.Drawing.Color.FromArgb(50, 75, 115);
            this.dgvRequests.EnableHeadersVisualStyles = false;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(35, 64, 112);
            this.dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRequests.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvRequests.ColumnHeadersHeight = 34;
            this.dgvRequests.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(24, 47, 88);
            this.dgvRequests.DefaultCellStyle.ForeColor = System.Drawing.Color.Gainsboro;
            this.dgvRequests.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(42, 73, 133);
            this.dgvRequests.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRequests.RowTemplate.Height = 34;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;

            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colRequest",
                HeaderText = "№ заявки",
                DataPropertyName = "request_id",
                Width = 80
            });
            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colEmployee",
                HeaderText = "Сотрудник",
                DataPropertyName = "employee_name",
                Width = 150
            });
            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Категория",
                DataPropertyName = "equipment_category_name",
                Width = 110
            });
            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colEquipment",
                HeaderText = "Имущество",
                DataPropertyName = "equipment_name",
                Width = 125
            });
            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Дата заявки",
                DataPropertyName = "request_date",
                Width = 90
            });
            this.dgvRequests.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Статус",
                DataPropertyName = "request_status_name",
                Width = 90
            });

            this.pnlList.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblListTitle, this.lblResultCount, this.dgvRequests
            });

            this.pnlInfo.BackColor = System.Drawing.Color.FromArgb(18, 38, 74);
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Location = new System.Drawing.Point(710, 247);
            this.pnlInfo.Size = new System.Drawing.Size(330, 395);

            this.lblInfoTitle.Text = "ИНФОРМАЦИЯ О ЗАЯВКЕ";
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.lblInfoTitle.Location = new System.Drawing.Point(15, 10);
            this.lblInfoTitle.AutoSize = true;

            CreateInfoLabel(this.lblInfoRequest, "№ заявки:", 18, 50);
            CreateInfoLabel(this.lblInfoEmployee, "Сотрудник:", 18, 85);
            CreateInfoLabel(this.lblInfoCategory, "Категория:", 18, 120);
            CreateInfoLabel(this.lblInfoEquipment, "Имущество:", 18, 155);
            CreateInfoLabel(this.lblInfoDate, "Дата заявки:", 18, 190);
            CreateInfoLabel(this.lblInfoStatus, "Статус:", 18, 225);
            CreateInfoLabel(this.lblInfoComment, "Комментарий:", 18, 260);

            CreateInfoValue(this.lblInfoRequestValue, 125, 50);
            CreateInfoValue(this.lblInfoEmployeeValue, 125, 85);
            CreateInfoValue(this.lblInfoCategoryValue, 125, 120);
            CreateInfoValue(this.lblInfoEquipmentValue, 125, 155);
            CreateInfoValue(this.lblInfoDateValue, 125, 190);
            CreateInfoValue(this.lblInfoStatusValue, 125, 225);
            CreateInfoValue(this.lblInfoCommentValue, 125, 260);

            this.lblInfoCommentValue.MaximumSize = new System.Drawing.Size(185, 45);
            this.lblInfoCommentValue.AutoSize = false;
            this.lblInfoCommentValue.Height = 45;

            StyleActionButton(this.btnApprove, "Одобрить", 15, 315);
            StyleActionButton(this.btnReject, "Отклонить", 115, 315);

            this.pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblInfoTitle,
                this.lblInfoRequest, this.lblInfoRequestValue,
                this.lblInfoEmployee, this.lblInfoEmployeeValue,
                this.lblInfoCategory, this.lblInfoCategoryValue,
                this.lblInfoEquipment, this.lblInfoEquipmentValue,
                this.lblInfoDate, this.lblInfoDateValue,
                this.lblInfoStatus, this.lblInfoStatusValue,
                this.lblInfoComment, this.lblInfoCommentValue,
            });

            this.btnClose.Text = "Закрыть";
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(212, 160, 23);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(42, 73, 133);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(910, 655);
            this.btnClose.Size = new System.Drawing.Size(130, 32);
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;

            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblTitle,
                this.lblSubtitle,
                this.pnlFilters,
                this.pnlList,
                this.pnlInfo,
                this.btnClose
            });

            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreateInfoLabel(
            System.Windows.Forms.Label label,
            string text,
            int x,
            int y)
        {
            label.Text = text;
            label.ForeColor = System.Drawing.Color.Gainsboro;
            label.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            label.Location = new System.Drawing.Point(x, y);
            label.AutoSize = true;
        }

        private void CreateInfoValue(
            System.Windows.Forms.Label label,
            int x,
            int y)
        {
            label.Text = "—";
            label.ForeColor = System.Drawing.Color.White;
            label.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(185, 25);
            label.AutoEllipsis = true;
        }

        private void StyleActionButton(
            System.Windows.Forms.Button button,
            string text,
            int x,
            int y)
        {
            button.Text = text;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(212, 160, 23);
            button.BackColor = System.Drawing.Color.FromArgb(42, 73, 133);
            button.ForeColor = System.Drawing.Color.White;
            button.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            button.Location = new System.Drawing.Point(x, y);
            button.Size = new System.Drawing.Size(90, 32);
            button.UseVisualStyleBackColor = false;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}