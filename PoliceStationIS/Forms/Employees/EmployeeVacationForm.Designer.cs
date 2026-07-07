using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Employees
{
    partial class EmployeeVacationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        #region Поля формы

        private Panel pnlHeader;

        private PictureBox picHeaderIcon;

        private Label lblTitle;

        private Button btnClose;

        private Panel pnlBody;

        private Label lblEmployeeInfo;

        private Panel pnlLine;

        private Panel pnlEmployeeCard;

        private PictureBox picEmployee;

        private Label lblName;

        private Label lblPost;

        private Label lblDepartment;

        private Label lblVacationType;

        private ComboBox cmbVacationType;

        private Label lblStartDate;

        private DateTimePicker dtpStartDate;

        private Label lblEndDate;

        private DateTimePicker dtpEndDate;

        private Label lblBasis;

        private TextBox txtBasis;

        private Button btnCancel;

        private Button btnCreateVacation;

        #endregion

        /// <summary>
        /// Освободить используемые ресурсы.
        /// </summary>
        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();

            this.picHeaderIcon = new PictureBox();

            this.lblTitle = new Label();

            this.btnClose = new Button();

            this.pnlBody = new Panel();

            this.lblEmployeeInfo = new Label();

            this.pnlLine = new Panel();

            this.pnlEmployeeCard = new Panel();

            this.picEmployee = new PictureBox();

            this.lblName = new Label();

            this.lblPost = new Label();

            this.lblDepartment = new Label();

            this.lblVacationType = new Label();

            this.cmbVacationType = new ComboBox();

            this.lblStartDate = new Label();

            this.dtpStartDate = new DateTimePicker();

            this.lblEndDate = new Label();

            this.dtpEndDate = new DateTimePicker();

            this.lblBasis = new Label();

            this.txtBasis = new TextBox();

            this.btnCancel = new Button();

            this.btnCreateVacation = new Button();

            ((ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            ((ISupportInitialize)(this.picEmployee)).BeginInit();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlEmployeeCard.SuspendLayout();

            this.SuspendLayout();

            //
            // EmployeeVacationForm
            //

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(620, 590);

            this.DoubleBuffered = true;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "EmployeeVacationForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Отпуск";

            //
            // pnlHeader
            //

            this.pnlHeader.BackColor =
                Color.FromArgb(24, 38, 70);

            this.pnlHeader.Controls.Add(this.picHeaderIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);

            this.pnlHeader.Dock =
                DockStyle.Top;

            this.pnlHeader.Location =
                new Point(0, 0);

            this.pnlHeader.Name =
                "pnlHeader";

            this.pnlHeader.Size =
                new Size(620, 60);

            this.pnlHeader.TabIndex = 0;

            //
            // picHeaderIcon
            //

            this.picHeaderIcon.BackColor =
                Color.Transparent;

            this.picHeaderIcon.Image =
                global::PoliceStationIS.Properties.Resources.vacation_gold_icon;

            this.picHeaderIcon.Location =
                new Point(18, 14);

            this.picHeaderIcon.Name =
                "picHeaderIcon";

            this.picHeaderIcon.Size =
                new Size(30, 30);

            this.picHeaderIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picHeaderIcon.TabIndex = 0;

            this.picHeaderIcon.TabStop = false;

            //
            // lblTitle
            //

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(58, 14);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Size =
                new Size(205, 25);

            this.lblTitle.TabIndex = 1;

            this.lblTitle.Text =
                "Оформление отпуска";

            //
            // btnClose
            //

            this.btnClose.BackColor =
                Color.Transparent;

            this.btnClose.FlatAppearance.BorderSize = 0;

            this.btnClose.FlatStyle =
                FlatStyle.Flat;

            this.btnClose.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.btnClose.ForeColor =
                Color.White;

            this.btnClose.Location =
                new Point(570, 10);

            this.btnClose.Name =
                "btnClose";

            this.btnClose.Size =
                new Size(34, 34);

            this.btnClose.TabIndex = 2;

            this.btnClose.Text = "✕";

            this.btnClose.UseVisualStyleBackColor =
                false;

            //
            // pnlBody
            //

            this.pnlBody.BackColor =
                Color.FromArgb(30, 45, 80);

            this.pnlBody.Dock =
                DockStyle.Fill;

            this.pnlBody.Location =
                new Point(0, 60);

            this.pnlBody.Name =
                "pnlBody";

            this.pnlBody.Size =
                new Size(620, 530);

            this.pnlBody.TabIndex = 1;

            //
            // lblEmployeeInfo
            //

            this.lblEmployeeInfo.AutoSize = true;

            this.lblEmployeeInfo.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold);

            this.lblEmployeeInfo.ForeColor =
                Color.White;

            this.lblEmployeeInfo.Location =
                new Point(24, 22);

            this.lblEmployeeInfo.Name =
                "lblEmployeeInfo";

            this.lblEmployeeInfo.Size =
                new Size(205, 19);

            this.lblEmployeeInfo.TabIndex = 0;

            this.lblEmployeeInfo.Text =
                "Информация о сотруднике";

            //
            // pnlLine
            //

            this.pnlLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.pnlLine.Location =
                new Point(24, 48);

            this.pnlLine.Name =
                "pnlLine";

            this.pnlLine.Size =
                new Size(240, 2);

            this.pnlLine.TabIndex = 1;

            //
            // pnlEmployeeCard
            //

            this.pnlEmployeeCard.BackColor =
                Color.FromArgb(
                    30,
                    45,
                    80);

            this.pnlEmployeeCard.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlEmployeeCard.Location =
                new Point(24, 66);

            this.pnlEmployeeCard.Name =
                "pnlEmployeeCard";

            this.pnlEmployeeCard.Size =
                new Size(560, 82);

            this.pnlEmployeeCard.TabIndex = 2;

            //
            // picEmployee
            //

            this.picEmployee.Image =
                global::PoliceStationIS.Properties.Resources.employee_search_gold_icon;

            this.picEmployee.Location =
                new Point(18, 14);

            this.picEmployee.Name =
                "picEmployee";

            this.picEmployee.Size =
                new Size(56, 56);

            this.picEmployee.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picEmployee.TabIndex = 0;

            this.picEmployee.TabStop = false;

            //
            // lblName
            //

            this.lblName.AutoSize = true;

            this.lblName.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblName.ForeColor =
                Color.White;

            this.lblName.Location =
                new Point(88, 10);

            this.lblName.MaximumSize =
                new Size(410, 0);

            this.lblName.Name =
                "lblName";

            this.lblName.Size =
                new Size(170, 19);

            this.lblName.TabIndex = 1;

            this.lblName.Text =
                "Иванов Иван Иванович";

            //
            // lblPost
            //

            this.lblPost.AutoSize = true;

            this.lblPost.Font =
                new Font(
                    "Segoe UI",
                    8.8F);

            this.lblPost.ForeColor =
                Color.Gainsboro;

            this.lblPost.Location =
                new Point(88, 35);

            this.lblPost.MaximumSize =
                new Size(410, 0);

            this.lblPost.Name =
                "lblPost";

            this.lblPost.Size =
                new Size(90, 15);

            this.lblPost.TabIndex = 2;

            this.lblPost.Text =
                "Следователь";

            //
            // lblDepartment
            //

            this.lblDepartment.AutoSize = true;

            this.lblDepartment.Font =
                new Font(
                    "Segoe UI",
                    8.6F);

            this.lblDepartment.ForeColor =
                Color.Gainsboro;

            this.lblDepartment.Location =
                new Point(88, 55);

            this.lblDepartment.MaximumSize =
                new Size(410, 0);

            this.lblDepartment.Name =
                "lblDepartment";

            this.lblDepartment.Size =
                new Size(140, 15);

            this.lblDepartment.TabIndex = 3;

            this.lblDepartment.Text =
                "Следственный отдел";

            this.pnlEmployeeCard.Controls.Add(this.picEmployee);
            this.pnlEmployeeCard.Controls.Add(this.lblName);
            this.pnlEmployeeCard.Controls.Add(this.lblPost);
            this.pnlEmployeeCard.Controls.Add(this.lblDepartment);

            //
            // lblVacationType
            //

            this.lblVacationType.AutoSize = true;

            this.lblVacationType.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblVacationType.ForeColor =
                Color.White;

            this.lblVacationType.Location =
                new Point(24, 175);

            this.lblVacationType.Name =
                "lblVacationType";

            this.lblVacationType.Size =
                new Size(102, 17);

            this.lblVacationType.TabIndex = 3;

            this.lblVacationType.Text =
                "Тип отпуска";

            //
            // cmbVacationType
            //

            this.cmbVacationType.BackColor =
                Color.FromArgb(30, 45, 80);

            this.cmbVacationType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbVacationType.FlatStyle =
                FlatStyle.Flat;

            this.cmbVacationType.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.cmbVacationType.ForeColor =
                Color.White;

            this.cmbVacationType.FormattingEnabled =
                true;

            this.cmbVacationType.Location =
                new Point(24, 198);

            this.cmbVacationType.Name =
                "cmbVacationType";

            this.cmbVacationType.Size =
                new Size(560, 36);

            this.cmbVacationType.TabIndex = 4;

            //
            // lblStartDate
            //

            this.lblStartDate.AutoSize = true;

            this.lblStartDate.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblStartDate.ForeColor =
                Color.White;

            this.lblStartDate.Location =
                new Point(24, 250);

            this.lblStartDate.Name =
                "lblStartDate";

            this.lblStartDate.Size =
                new Size(98, 17);

            this.lblStartDate.TabIndex = 5;

            this.lblStartDate.Text =
                "Дата начала";

            //
            // lblEndDate
            //

            this.lblEndDate.AutoSize = true;

            this.lblEndDate.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblEndDate.ForeColor =
                Color.White;

            this.lblEndDate.Location =
                new Point(312, 250);

            this.lblEndDate.Name =
                "lblEndDate";

            this.lblEndDate.Size =
                new Size(118, 17);

            this.lblEndDate.TabIndex = 6;

            this.lblEndDate.Text =
                "Дата окончания";

            //
            // dtpStartDate
            //

            this.dtpStartDate.CalendarForeColor =
                Color.White;

            this.dtpStartDate.CalendarMonthBackground =
                Color.FromArgb(30, 58, 117);

            this.dtpStartDate.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.dtpStartDate.Format =
                DateTimePickerFormat.Short;

            this.dtpStartDate.Location =
                new Point(24, 273);

            this.dtpStartDate.Name =
                "dtpStartDate";

            this.dtpStartDate.Size =
                new Size(260, 36);

            this.dtpStartDate.TabIndex = 7;

            //
            // dtpEndDate
            //

            this.dtpEndDate.CalendarForeColor =
                Color.White;

            this.dtpEndDate.CalendarMonthBackground =
                Color.FromArgb(30, 58, 117);

            this.dtpEndDate.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.dtpEndDate.Format =
                DateTimePickerFormat.Short;

            this.dtpEndDate.Location =
                new Point(324, 273);

            this.dtpEndDate.Name =
                "dtpEndDate";

            this.dtpEndDate.Size =
                new Size(260, 36);

            this.dtpEndDate.TabIndex = 8;

            //
            // lblBasis
            //

            this.lblBasis.AutoSize = true;

            this.lblBasis.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblBasis.ForeColor =
                Color.White;

            this.lblBasis.Location =
                new Point(24, 325);

            this.lblBasis.Name =
                "lblBasis";

            this.lblBasis.Size =
                new Size(84, 17);

            this.lblBasis.TabIndex = 9;

            this.lblBasis.Text =
                "Основание";

            //
            // txtBasis
            //

            this.txtBasis.BackColor =
                Color.FromArgb(30, 45, 80);

            this.txtBasis.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtBasis.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtBasis.ForeColor =
                Color.White;

            this.txtBasis.Location =
                new Point(24, 348);

            this.txtBasis.Multiline =
                true;

            this.txtBasis.Name =
                "txtBasis";

            this.txtBasis.ScrollBars =
                ScrollBars.Vertical;

            this.txtBasis.Size =
                new Size(560, 110);

            this.txtBasis.TabIndex = 10;

            //
            // btnCancel
            //

            this.btnCancel.BackColor =
                Color.FromArgb(70, 84, 112);

            this.btnCancel.FlatAppearance.BorderSize = 0;

            this.btnCancel.FlatStyle =
                FlatStyle.Flat;

            this.btnCancel.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnCancel.ForeColor =
                Color.White;

            this.btnCancel.Location =
                new Point(360, 475);

            this.btnCancel.Name =
                "btnCancel";

            this.btnCancel.Size =
                new Size(100, 36);

            this.btnCancel.TabIndex = 11;

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            //
            // btnCreateVacation
            //

            this.btnCreateVacation.BackColor =
                Color.FromArgb(212, 160, 23);

            this.btnCreateVacation.FlatAppearance.BorderSize = 0;

            this.btnCreateVacation.FlatStyle =
                FlatStyle.Flat;

            this.btnCreateVacation.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnCreateVacation.ForeColor =
                Color.White;

            this.btnCreateVacation.Location =
                new Point(470, 475);

            this.btnCreateVacation.Name =
                "btnCreateVacation";

            this.btnCreateVacation.Size =
                new Size(114, 36);

            this.btnCreateVacation.TabIndex = 12;

            this.btnCreateVacation.Text =
                "Оформить";

            this.btnCreateVacation.UseVisualStyleBackColor =
                false;

            //
            // Добавление элементов в pnlBody
            //

            this.pnlBody.Controls.Add(this.lblEmployeeInfo);
            this.pnlBody.Controls.Add(this.pnlLine);
            this.pnlBody.Controls.Add(this.pnlEmployeeCard);

            this.pnlBody.Controls.Add(this.lblVacationType);
            this.pnlBody.Controls.Add(this.cmbVacationType);

            this.pnlBody.Controls.Add(this.lblStartDate);
            this.pnlBody.Controls.Add(this.dtpStartDate);

            this.pnlBody.Controls.Add(this.lblEndDate);
            this.pnlBody.Controls.Add(this.dtpEndDate);

            this.pnlBody.Controls.Add(this.lblBasis);
            this.pnlBody.Controls.Add(this.txtBasis);

            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnCreateVacation);

            //
            // Добавление панелей на форму
            //

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            //
            // EmployeeVacationForm
            //

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(620, 590);

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            this.DoubleBuffered =
                true;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "EmployeeVacationForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Оформление отпуска";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();

            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();

            this.pnlEmployeeCard.ResumeLayout(false);
            this.pnlEmployeeCard.PerformLayout();

            ((ISupportInitialize)(this.picEmployee)).EndInit();
            ((ISupportInitialize)(this.picHeaderIcon)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}