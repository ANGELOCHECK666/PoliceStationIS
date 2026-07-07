using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Employees
{
    partial class EmployeeSickLeaveForm
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

        private Label lblStartDate;

        private DateTimePicker dtpStartDate;

        private Label lblEndDate;

        private DateTimePicker dtpEndDate;

        private Label lblSickLeaveNumber;

        private TextBox txtSickLeaveNumber;

        private Label lblComment;

        private TextBox txtComment;

        private Button btnCancel;

        private Button btnCreateSickLeave;

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

            this.lblStartDate = new Label();

            this.dtpStartDate = new DateTimePicker();

            this.lblEndDate = new Label();

            this.dtpEndDate = new DateTimePicker();

            this.lblSickLeaveNumber = new Label();

            this.txtSickLeaveNumber = new TextBox();

            this.lblComment = new Label();

            this.txtComment = new TextBox();

            this.btnCancel = new Button();

            this.btnCreateSickLeave = new Button();

            ((ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            ((ISupportInitialize)(this.picEmployee)).BeginInit();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlEmployeeCard.SuspendLayout();

            this.SuspendLayout();

            //
            // EmployeeSickLeaveForm
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
                "EmployeeSickLeaveForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Оформление больничного";

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
                global::PoliceStationIS.Properties.Resources.sick_leave_gold_icon;

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
                new Size(239, 25);

            this.lblTitle.TabIndex = 1;

            this.lblTitle.Text =
                "Оформление больничного";

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
                new Point(24, 175);

            this.lblStartDate.Name =
                "lblStartDate";

            this.lblStartDate.Size =
                new Size(98, 17);

            this.lblStartDate.TabIndex = 3;

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
                new Point(312, 175);

            this.lblEndDate.Name =
                "lblEndDate";

            this.lblEndDate.Size =
                new Size(118, 17);

            this.lblEndDate.TabIndex = 4;

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
                new Point(24, 198);

            this.dtpStartDate.Name =
                "dtpStartDate";

            this.dtpStartDate.Size =
                new Size(260, 36);

            this.dtpStartDate.TabIndex = 5;

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
                new Point(324, 198);

            this.dtpEndDate.Name =
                "dtpEndDate";

            this.dtpEndDate.Size =
                new Size(260, 36);

            this.dtpEndDate.TabIndex = 6;

            //
            // lblSickLeaveNumber
            //

            this.lblSickLeaveNumber.AutoSize = true;

            this.lblSickLeaveNumber.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblSickLeaveNumber.ForeColor =
                Color.White;

            this.lblSickLeaveNumber.Location =
                new Point(24, 250);

            this.lblSickLeaveNumber.Name =
                "lblSickLeaveNumber";

            this.lblSickLeaveNumber.Size =
                new Size(212, 17);

            this.lblSickLeaveNumber.TabIndex = 7;

            this.lblSickLeaveNumber.Text =
                "Номер листка нетрудоспособности";

            //
            // txtSickLeaveNumber
            //

            this.txtSickLeaveNumber.BackColor =
                Color.FromArgb(30, 45, 80);

            this.txtSickLeaveNumber.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtSickLeaveNumber.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtSickLeaveNumber.ForeColor =
                Color.White;

            this.txtSickLeaveNumber.Location =
                new Point(24, 273);

            this.txtSickLeaveNumber.Name =
                "txtSickLeaveNumber";

            this.txtSickLeaveNumber.Size =
                new Size(560, 25);

            this.txtSickLeaveNumber.TabIndex = 8;

            //
            // lblComment
            //

            this.lblComment.AutoSize = true;

            this.lblComment.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblComment.ForeColor =
                Color.White;

            this.lblComment.Location =
                new Point(24, 315);

            this.lblComment.Name =
                "lblComment";

            this.lblComment.Size =
                new Size(93, 17);

            this.lblComment.TabIndex = 9;

            this.lblComment.Text =
                "Комментарий";

            //
            // txtComment
            //

            this.txtComment.BackColor =
                Color.FromArgb(30, 45, 80);

            this.txtComment.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtComment.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtComment.ForeColor =
                Color.White;

            this.txtComment.Location =
                new Point(24, 338);

            this.txtComment.Multiline =
                true;

            this.txtComment.Name =
                "txtComment";

            this.txtComment.ScrollBars =
                ScrollBars.Vertical;

            this.txtComment.Size =
                new Size(560, 120);

            this.txtComment.TabIndex = 10;

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
                new Point(340, 475);

            this.btnCancel.Name =
                "btnCancel";

            this.btnCancel.Size =
                new Size(96, 34);

            this.btnCancel.TabIndex = 11;

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            //
            // btnCreateSickLeave
            //

            this.btnCreateSickLeave.BackColor =
                Color.FromArgb(212, 160, 23);

            this.btnCreateSickLeave.FlatAppearance.BorderSize = 0;

            this.btnCreateSickLeave.FlatStyle =
                FlatStyle.Flat;

            this.btnCreateSickLeave.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnCreateSickLeave.ForeColor =
                Color.White;

            this.btnCreateSickLeave.Location =
                new Point(444, 475);

            this.btnCreateSickLeave.Name =
                "btnCreateSickLeave";

            this.btnCreateSickLeave.Size =
                new Size(140, 34);

            this.btnCreateSickLeave.TabIndex = 12;

            this.btnCreateSickLeave.Text =
                "Оформить";

            this.btnCreateSickLeave.UseVisualStyleBackColor =
                false;

            //
            // Добавление элементов в pnlBody
            //

            this.pnlBody.Controls.Add(this.lblEmployeeInfo);
            this.pnlBody.Controls.Add(this.pnlLine);
            this.pnlBody.Controls.Add(this.pnlEmployeeCard);

            this.pnlBody.Controls.Add(this.lblStartDate);
            this.pnlBody.Controls.Add(this.dtpStartDate);

            this.pnlBody.Controls.Add(this.lblEndDate);
            this.pnlBody.Controls.Add(this.dtpEndDate);

            this.pnlBody.Controls.Add(this.lblSickLeaveNumber);
            this.pnlBody.Controls.Add(this.txtSickLeaveNumber);

            this.pnlBody.Controls.Add(this.lblComment);
            this.pnlBody.Controls.Add(this.txtComment);

            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnCreateSickLeave);

            //
            // Добавление панелей на форму
            //

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            //
            // EmployeeSickLeaveForm
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

            this.DoubleBuffered = true;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "EmployeeSickLeaveForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Оформление больничного";

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