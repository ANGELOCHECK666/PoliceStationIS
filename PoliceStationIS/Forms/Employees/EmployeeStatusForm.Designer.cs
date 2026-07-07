using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Employees
{
    partial class EmployeeStatusForm
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

        private Label lblStatus;
        private ComboBox cmbEmploymentStatus;

        private Label lblDate;
        private DateTimePicker dtpChangeDate;

        private Label lblComment;
        private TextBox txtComment;

        private Button btnCancel;
        private Button btnChangeStatus;

        #endregion

        /// <summary>
        /// Очистка ресурсов.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpChangeDate = new System.Windows.Forms.DateTimePicker();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblEmployeeInfo = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.pnlEmployeeCard = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.picHeaderIcon = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlEmployeeCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.pnlHeader.Controls.Add(this.picHeaderIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(621, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(58, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(396, 54);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Изменение статуса";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(570, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.pnlBody.Controls.Add(this.lblEmployeeInfo);
            this.pnlBody.Controls.Add(this.pnlLine);
            this.pnlBody.Controls.Add(this.pnlEmployeeCard);
            this.pnlBody.Controls.Add(this.lblStatus);
            this.pnlBody.Controls.Add(this.cmbEmploymentStatus);
            this.pnlBody.Controls.Add(this.lblDate);
            this.pnlBody.Controls.Add(this.dtpChangeDate);
            this.pnlBody.Controls.Add(this.lblComment);
            this.pnlBody.Controls.Add(this.txtComment);
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnChangeStatus);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 68);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(651, 627);
            this.pnlBody.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(24, 175);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(186, 36);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Новый статус";

            
            // 
            // cmbEmploymentStatus
            // 
            this.cmbEmploymentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.cmbEmploymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmploymentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmploymentStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmploymentStatus.ForeColor = System.Drawing.Color.White;
            this.cmbEmploymentStatus.FormattingEnabled = true;
            this.cmbEmploymentStatus.Location = new Point(24, 198);
            this.cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            this.cmbEmploymentStatus.Size = new System.Drawing.Size(560, 36);
            this.cmbEmploymentStatus.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(24, 250);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(222, 36);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата изменения";
            // 
            // dtpChangeDate
            // 
            this.dtpChangeDate.CalendarForeColor = System.Drawing.Color.White;
            this.dtpChangeDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(117)))));
            this.dtpChangeDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpChangeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChangeDate.Location = new System.Drawing.Point(24, 273);
            this.dtpChangeDate.Name = "dtpChangeDate";
            this.dtpChangeDate.Size = new System.Drawing.Size(560, 36);
            this.dtpChangeDate.TabIndex = 6;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblComment.ForeColor = System.Drawing.Color.White;
            this.lblComment.Location = new System.Drawing.Point(24, 325);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(192, 36);
            this.lblComment.TabIndex = 7;
            this.lblComment.Text = "Комментарий";
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComment.ForeColor = System.Drawing.Color.White;
            this.txtComment.Location = new System.Drawing.Point(24, 348);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(560, 110);
            this.txtComment.TabIndex = 8;
            // 
            // lblEmployeeInfo
            // 
            this.lblEmployeeInfo.AutoSize = true;
            this.lblEmployeeInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeInfo.ForeColor = System.Drawing.Color.White;
            this.lblEmployeeInfo.Location = new System.Drawing.Point(24, 22);
            this.lblEmployeeInfo.Name = "lblEmployeeInfo";
            this.lblEmployeeInfo.Size = new System.Drawing.Size(391, 38);
            this.lblEmployeeInfo.TabIndex = 0;
            this.lblEmployeeInfo.Text = "Информация о сотруднике";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlLine.Location = new System.Drawing.Point(24, 48);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(240, 2);
            this.pnlLine.TabIndex = 1;
            // 
            // pnlEmployeeCard
            // 
            this.pnlEmployeeCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.pnlEmployeeCard.BorderStyle =
    BorderStyle.FixedSingle;
            this.pnlEmployeeCard.Controls.Add(this.picEmployee);
            
            this.pnlEmployeeCard.Controls.Add(this.lblName);
            this.pnlEmployeeCard.Controls.Add(this.lblPost);
            this.pnlEmployeeCard.Controls.Add(this.lblDepartment);
            this.pnlEmployeeCard.Location = new System.Drawing.Point(24, 66);
            this.pnlEmployeeCard.Name = "pnlEmployeeCard";
            this.pnlEmployeeCard.Size = new System.Drawing.Size(560, 82);
            this.pnlEmployeeCard.TabIndex = 2;
            
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(88, 10);
            this.lblName.MaximumSize = new System.Drawing.Size(410, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(337, 37);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Иванов Иван Иванович";
            
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblPost.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPost.Location = new System.Drawing.Point(88, 35);
            this.lblPost.MaximumSize = new System.Drawing.Size(410, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(155, 32);
            this.lblPost.TabIndex = 4;
            this.lblPost.Text = "Следователь";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 8.6F);
            this.lblDepartment.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDepartment.Location = new System.Drawing.Point(88, 55);
            this.lblDepartment.MaximumSize = new System.Drawing.Size(410, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(244, 32);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "Следственный отдел";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(84)))), ((int)(((byte)(112)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(360, 475);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.btnChangeStatus.FlatAppearance.BorderSize = 0;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangeStatus.ForeColor = System.Drawing.Color.White;
            this.btnChangeStatus.Location = new System.Drawing.Point(485, 475);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(100, 36);
            this.btnChangeStatus.TabIndex = 10;
            this.btnChangeStatus.Text = "Изменить";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            // 
            // picEmployee
            // 
            this.picEmployee.Image = global::PoliceStationIS.Properties.Resources.employee_search_gold_icon;
            this.picEmployee.Location = new System.Drawing.Point(18, 14);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(56, 56);
            this.picEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEmployee.TabIndex = 0;
            this.picEmployee.TabStop = false;
            // 
            // picHeaderIcon
            // 
            this.picHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.picHeaderIcon.Image = global::PoliceStationIS.Properties.Resources.status_change_gold_icon;
            this.picHeaderIcon.Location = new System.Drawing.Point(18, 14);
            this.picHeaderIcon.Name = "picHeaderIcon";
            this.picHeaderIcon.Size = new System.Drawing.Size(30, 30);
            this.picHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeaderIcon.TabIndex = 0;
            this.picHeaderIcon.TabStop = false;
            // 
            // EmployeeStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(620, 590);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменение статуса";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlEmployeeCard.ResumeLayout(false);
            this.pnlEmployeeCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}