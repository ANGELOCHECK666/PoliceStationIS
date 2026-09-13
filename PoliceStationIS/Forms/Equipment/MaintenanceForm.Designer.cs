using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Equipment
{
    partial class MaintenanceForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlFilters;
        private Label lblFiltersTitle;
        private Label lblStatus;
        private Label lblCategory;
        private Label lblDateFrom;
        private Label lblDateTo;
        private Label lblEquipment;
        private ComboBox cmbStatus;
        private ComboBox cmbCategory;
        private ComboBox cmbEquipment;
        private DateTimePicker dtpDateFrom;
        private DateTimePicker dtpDateTo;
        private Button btnSearch;
        private Button btnReset;

        private Panel pnlList;
        private Label lblListTitle;
        private Label lblResultCount;
        private DataGridView dgvMaintenance;

        private Panel pnlInfo;
        private Label lblInfoTitle;
        private Label lblInfoEquipment;
        private Label lblInfoEquipmentValue;
        private Label lblInfoCategory;
        private Label lblInfoCategoryValue;
        private Label lblInfoEmployee;
        private Label lblInfoEmployeeValue;
        private Label lblInfoType;
        private Label lblInfoTypeValue;
        private Label lblInfoDate;
        private Label lblInfoDateValue;
        private Label lblInfoStatus;
        private Label lblInfoStatusValue;
        private Label lblInfoDescription;
        private Label lblInfoDescriptionValue;
        private Label lblInfoCompletion;
        private Label lblInfoCompletionValue;

        private Panel pnlActions;
        private Label lblActionsTitle;
        private Label lblMaintenanceType;
        private ComboBox cmbMaintenanceType;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnStart;
        private Button btnComplete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new Label();
            this.lblSubtitle = new Label();

            this.pnlFilters = new Panel();
            this.lblFiltersTitle = new Label();
            this.lblStatus = new Label();
            this.lblCategory = new Label();
            this.lblDateFrom = new Label();
            this.lblDateTo = new Label();
            this.lblEquipment = new Label();
            this.cmbStatus = new ComboBox();
            this.cmbCategory = new ComboBox();
            this.cmbEquipment = new ComboBox();
            this.dtpDateFrom = new DateTimePicker();
            this.dtpDateTo = new DateTimePicker();
            this.btnSearch = new Button();
            this.btnReset = new Button();

            this.pnlList = new Panel();
            this.lblListTitle = new Label();
            this.lblResultCount = new Label();
            this.dgvMaintenance = new DataGridView();

            this.pnlInfo = new Panel();
            this.lblInfoTitle = new Label();
            this.lblInfoEquipment = new Label();
            this.lblInfoEquipmentValue = new Label();
            this.lblInfoCategory = new Label();
            this.lblInfoCategoryValue = new Label();
            this.lblInfoEmployee = new Label();
            this.lblInfoEmployeeValue = new Label();
            this.lblInfoType = new Label();
            this.lblInfoTypeValue = new Label();
            this.lblInfoDate = new Label();
            this.lblInfoDateValue = new Label();
            this.lblInfoStatus = new Label();
            this.lblInfoStatusValue = new Label();
            this.lblInfoDescription = new Label();
            this.lblInfoDescriptionValue = new Label();
            this.lblInfoCompletion = new Label();
            this.lblInfoCompletionValue = new Label();

            this.pnlActions = new Panel();
            this.lblActionsTitle = new Label();
            this.lblMaintenanceType = new Label();
            this.cmbMaintenanceType = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnStart = new Button();
            this.btnComplete = new Button();

            this.SuspendLayout();

            // FORM
            this.BackColor = Color.FromArgb(12, 29, 58);
            this.ClientSize = new Size(1180, 760);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Обслуживание имущества";
            this.Name = "MaintenanceForm";
            this.ShowInTaskbar = false;

            // TITLE
            this.lblTitle.Text = "Обслуживание имущества";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(25, 18);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Контроль, передача и завершение обслуживания служебного имущества";
            this.lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = Color.Gainsboro;
            this.lblSubtitle.Location = new Point(27, 53);
            this.lblSubtitle.AutoSize = true;

            // FILTERS
            this.pnlFilters.BackColor = Color.FromArgb(18, 38, 74);
            this.pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            this.pnlFilters.Location = new Point(20, 82);
            this.pnlFilters.Size = new Size(1140, 145);

            this.lblFiltersTitle.Text = "ПОИСК И ФИЛЬТРЫ";
            this.lblFiltersTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFiltersTitle.ForeColor = Color.FromArgb(212, 160, 23);
            this.lblFiltersTitle.Location = new Point(15, 10);
            this.lblFiltersTitle.AutoSize = true;

            ConfigureLabel(this.lblStatus, "Статус обслуживания", 15, 42);
            ConfigureLabel(this.lblCategory, "Категория", 245, 42);
            ConfigureLabel(this.lblDateFrom, "Дата с", 475, 42);
            ConfigureLabel(this.lblDateTo, "Дата по", 625, 42);
            ConfigureLabel(this.lblEquipment, "Имущество для передачи", 15, 91);

            ConfigureCombo(this.cmbStatus, 15, 63, 215);
            ConfigureCombo(this.cmbCategory, 245, 63, 215);
            ConfigureDate(this.dtpDateFrom, 475, 63, 135);
            ConfigureDate(this.dtpDateTo, 625, 63, 135);
            ConfigureCombo(this.cmbEquipment, 15, 111, 445);

            ConfigureButton(this.btnSearch, "Найти", 785, 63, 150, 34);
            ConfigureButton(this.btnReset, "Сбросить", 950, 63, 165, 34);

            this.pnlFilters.Controls.Add(this.lblFiltersTitle);
            this.pnlFilters.Controls.Add(this.lblStatus);
            this.pnlFilters.Controls.Add(this.lblCategory);
            this.pnlFilters.Controls.Add(this.lblDateFrom);
            this.pnlFilters.Controls.Add(this.lblDateTo);
            this.pnlFilters.Controls.Add(this.lblEquipment);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.cmbCategory);
            this.pnlFilters.Controls.Add(this.cmbEquipment);
            this.pnlFilters.Controls.Add(this.dtpDateFrom);
            this.pnlFilters.Controls.Add(this.dtpDateTo);
            this.pnlFilters.Controls.Add(this.btnSearch);
            Label lblEquipmentHint = new Label();
            lblEquipmentHint.Text = "Выберите имущество из списка ниже для передачи на обслуживание";
            lblEquipmentHint.Font = new Font("Segoe UI", 8F);
            lblEquipmentHint.ForeColor = Color.Gainsboro;
            lblEquipmentHint.Location = new Point(475, 116);
            lblEquipmentHint.AutoSize = true;
            this.pnlFilters.Controls.Add(lblEquipmentHint);

            this.pnlFilters.Controls.Add(this.btnReset);

            // LIST
            this.pnlList.BackColor = Color.FromArgb(18, 38, 74);
            this.pnlList.BorderStyle = BorderStyle.FixedSingle;
            this.pnlList.Location = new Point(20, 242);
            this.pnlList.Size = new Size(765, 395);

            this.lblListTitle.Text = "ЖУРНАЛ ОБСЛУЖИВАНИЯ";
            this.lblListTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblListTitle.ForeColor = Color.FromArgb(212, 160, 23);
            this.lblListTitle.Location = new Point(15, 12);
            this.lblListTitle.AutoSize = true;

            this.lblResultCount.Text = "Записей: 0";
            this.lblResultCount.Font = new Font("Segoe UI", 9F);
            this.lblResultCount.ForeColor = Color.Gainsboro;
            this.lblResultCount.Location = new Point(640, 14);
            this.lblResultCount.AutoSize = true;

            ConfigureGrid();

            this.pnlList.Controls.Add(this.lblListTitle);
            this.pnlList.Controls.Add(this.lblResultCount);
            this.pnlList.Controls.Add(this.dgvMaintenance);

            // INFO
            this.pnlInfo.BackColor = Color.FromArgb(18, 38, 74);
            this.pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            this.pnlInfo.Location = new Point(805, 242);
            this.pnlInfo.Size = new Size(355, 395);

            this.lblInfoTitle.Text = "ИНФОРМАЦИЯ";
            this.lblInfoTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblInfoTitle.ForeColor = Color.FromArgb(212, 160, 23);
            this.lblInfoTitle.Location = new Point(15, 12);
            this.lblInfoTitle.AutoSize = true;

            ConfigureInfoPair(this.lblInfoEquipment, this.lblInfoEquipmentValue, "Имущество", 48);
            ConfigureInfoPair(this.lblInfoCategory, this.lblInfoCategoryValue, "Категория", 86);
            ConfigureInfoPair(this.lblInfoEmployee, this.lblInfoEmployeeValue, "Сотрудник", 124);
            ConfigureInfoPair(this.lblInfoType, this.lblInfoTypeValue, "Вид обслуживания", 162);
            ConfigureInfoPair(this.lblInfoDate, this.lblInfoDateValue, "Дата", 200);
            ConfigureInfoPair(this.lblInfoStatus, this.lblInfoStatusValue, "Статус", 238);
            ConfigureInfoPair(this.lblInfoCompletion, this.lblInfoCompletionValue, "Дата завершения", 276);

            this.lblInfoDescription.Text = "Описание";
            this.lblInfoDescription.Font = new Font("Segoe UI", 8.5F);
            this.lblInfoDescription.ForeColor = Color.Gainsboro;
            this.lblInfoDescription.Location = new Point(15, 314);
            this.lblInfoDescription.AutoSize = true;

            this.lblInfoDescriptionValue.Text = "—";
            this.lblInfoDescriptionValue.Font = new Font("Segoe UI", 9F);
            this.lblInfoDescriptionValue.ForeColor = Color.White;
            this.lblInfoDescriptionValue.Location = new Point(115, 314);
            this.lblInfoDescriptionValue.Size = new Size(220, 55);
            this.lblInfoDescriptionValue.AutoEllipsis = true;

            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.Controls.Add(this.lblInfoEquipment);
            this.pnlInfo.Controls.Add(this.lblInfoEquipmentValue);
            this.pnlInfo.Controls.Add(this.lblInfoCategory);
            this.pnlInfo.Controls.Add(this.lblInfoCategoryValue);
            this.pnlInfo.Controls.Add(this.lblInfoEmployee);
            this.pnlInfo.Controls.Add(this.lblInfoEmployeeValue);
            this.pnlInfo.Controls.Add(this.lblInfoType);
            this.pnlInfo.Controls.Add(this.lblInfoTypeValue);
            this.pnlInfo.Controls.Add(this.lblInfoDate);
            this.pnlInfo.Controls.Add(this.lblInfoDateValue);
            this.pnlInfo.Controls.Add(this.lblInfoStatus);
            this.pnlInfo.Controls.Add(this.lblInfoStatusValue);
            this.pnlInfo.Controls.Add(this.lblInfoCompletion);
            this.pnlInfo.Controls.Add(this.lblInfoCompletionValue);
            this.pnlInfo.Controls.Add(this.lblInfoDescription);
            this.pnlInfo.Controls.Add(this.lblInfoDescriptionValue);

            // ACTIONS
            this.pnlActions.BackColor = Color.FromArgb(18, 38, 74);
            this.pnlActions.BorderStyle = BorderStyle.FixedSingle;
            this.pnlActions.Location = new Point(20, 652);
            this.pnlActions.Size = new Size(1140, 108);

            this.lblActionsTitle.Text = "ДЕЙСТВИЯ";
            this.lblActionsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblActionsTitle.ForeColor = Color.FromArgb(212, 160, 23);
            this.lblActionsTitle.Location = new Point(15, 10);
            this.lblActionsTitle.AutoSize = true;

            ConfigureLabel(this.lblMaintenanceType, "Вид обслуживания", 150, 12);
            ConfigureCombo(this.cmbMaintenanceType, 150, 34, 235);

            ConfigureLabel(this.lblDescription, "Описание", 405, 12);

            this.txtDescription.BackColor = Color.FromArgb(30, 58, 117);
            this.txtDescription.ForeColor = Color.White;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Font = new Font("Segoe UI", 9F);
            this.txtDescription.Location = new Point(405, 34);
            this.txtDescription.Size = new Size(285, 32);
            this.txtDescription.Multiline = true;

            ConfigureButton(this.btnStart, "Передать на обслуживание", 705, 34, 190, 38);
            ConfigureButton(this.btnComplete, "Завершить обслуживание", 905, 34, 180, 38);


            this.pnlActions.Controls.Add(this.lblActionsTitle);
            this.pnlActions.Controls.Add(this.lblMaintenanceType);
            this.pnlActions.Controls.Add(this.cmbMaintenanceType);
            this.pnlActions.Controls.Add(this.lblDescription);
            this.pnlActions.Controls.Add(this.txtDescription);
            this.pnlActions.Controls.Add(this.btnStart);
            this.pnlActions.Controls.Add(this.btnComplete);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlActions);

            this.ResumeLayout(false);
        }

        private void ConfigureLabel(Label label, string text, int x, int y)
        {
            label.Text = text;
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 8.5F);
            label.ForeColor = Color.Gainsboro;
            label.Location = new Point(x, y);
        }

        private void ConfigureCombo(ComboBox combo, int x, int y, int width)
        {
            combo.Location = new Point(x, y);
            combo.Size = new Size(width, 24);
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.BackColor = Color.FromArgb(30, 58, 117);
            combo.ForeColor = Color.White;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureDate(DateTimePicker picker, int x, int y, int width)
        {
            picker.Location = new Point(x, y);
            picker.Size = new Size(width, 24);
            picker.Format = DateTimePickerFormat.Short;
            picker.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureButton(Button button, string text, int x, int y, int width, int height)
        {
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 160, 23);
            button.BackColor = Color.FromArgb(42, 73, 133);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        private void ConfigureInfoPair(Label label, Label value, string text, int y)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 8.5F);
            label.ForeColor = Color.Gainsboro;
            label.Location = new Point(15, y);
            label.AutoSize = true;

            value.Text = "—";
            value.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            value.ForeColor = Color.White;
            value.Location = new Point(115, y - 1);
            value.Size = new Size(220, 28);
            value.AutoEllipsis = true;
        }

        private void ConfigureGrid()
        {
            this.dgvMaintenance.Location = new Point(15, 45);
            this.dgvMaintenance.Size = new Size(733, 330);
            this.dgvMaintenance.BackgroundColor = Color.FromArgb(12, 29, 58);
            this.dgvMaintenance.BorderStyle = BorderStyle.None;
            this.dgvMaintenance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMaintenance.GridColor = Color.FromArgb(55, 78, 115);
            this.dgvMaintenance.RowHeadersVisible = false;
            this.dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintenance.MultiSelect = false;
            this.dgvMaintenance.ReadOnly = true;
            this.dgvMaintenance.AllowUserToAddRows = false;
            this.dgvMaintenance.AllowUserToDeleteRows = false;
            this.dgvMaintenance.AllowUserToResizeRows = false;
            this.dgvMaintenance.AutoGenerateColumns = false;
            this.dgvMaintenance.EnableHeadersVisualStyles = false;
            this.dgvMaintenance.ColumnHeadersHeight = 34;
            this.dgvMaintenance.RowTemplate.Height = 34;

            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(27, 49, 91);
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvMaintenance.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 8.5F, FontStyle.Bold);
            this.dgvMaintenance.DefaultCellStyle.BackColor =
                Color.FromArgb(18, 38, 74);
            this.dgvMaintenance.DefaultCellStyle.ForeColor = Color.White;
            this.dgvMaintenance.DefaultCellStyle.Font =
                new Font("Segoe UI", 8.5F);
            this.dgvMaintenance.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(42, 73, 133);
            this.dgvMaintenance.DefaultCellStyle.SelectionForeColor = Color.White;

            AddTextColumn("equipment_name", "Имущество", 155);
            AddTextColumn("equipment_category_name", "Категория", 105);
            AddTextColumn("employee_name", "Сотрудник", 130);
            AddTextColumn("maintenance_type", "Вид", 130);
            AddTextColumn("maintenance_date", "Дата", 75);
            AddTextColumn("maintenance_status_name", "Статус", 105);

            AddHiddenColumn("EquipmentId");
            AddHiddenColumn("MaintenanceId");
            AddHiddenColumn("MaintenanceStatusId");
            AddHiddenColumn("Description");
            AddHiddenColumn("CompletionDate");
        }

        private void AddHiddenColumn(string columnName)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = columnName;
            column.HeaderText = columnName;
            column.Visible = false;

            this.dgvMaintenance.Columns.Add(column);
        }

        private void AddTextColumn(string propertyName, string header, int width)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = propertyName;
            column.DataPropertyName = propertyName;
            column.HeaderText = header;
            column.Width = width;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;

            if (propertyName == "maintenance_date")
                column.DefaultCellStyle.Format = "dd.MM.yyyy";

            this.dgvMaintenance.Columns.Add(column);
        }
    }
}