using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Employees
{
    partial class EmployeePositionForm
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

        private Label lblPosition;

        private ComboBox cmbPosition;

        private Label lblChangeDate;

        private DateTimePicker dtpChangeDate;

        private Label lblBasis;

        private TextBox txtBasis;

        private Button btnCancel;

        private Button btnChangePosition;

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

            this.lblPosition = new Label();

            this.cmbPosition = new ComboBox();

            this.lblChangeDate = new Label();

            this.dtpChangeDate = new DateTimePicker();

            this.lblBasis = new Label();

            this.txtBasis = new TextBox();

            this.btnCancel = new Button();

            this.btnChangePosition = new Button();

            ((ISupportInitialize)(this.picHeaderIcon)).BeginInit();
            ((ISupportInitialize)(this.picEmployee)).BeginInit();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlEmployeeCard.SuspendLayout();

            this.SuspendLayout();

            //
            // EmployeePositionForm
            //

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(620, 590);

            this.DoubleBuffered =
                true;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "EmployeePositionForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Изменение должности";

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
                global::PoliceStationIS.Properties.Resources.position_gold_icon;

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
                new Size(194, 25);

            this.lblTitle.TabIndex = 1;

            this.lblTitle.Text =
                "Изменение должности";

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
            // lblPosition
            //

            this.lblPosition.AutoSize = true;

            this.lblPosition.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblPosition.ForeColor =
                Color.White;

            this.lblPosition.Location =
                new Point(24, 175);

            this.lblPosition.Name =
                "lblPosition";

            this.lblPosition.Size =
                new Size(127, 17);

            this.lblPosition.TabIndex = 3;

            this.lblPosition.Text =
                "Новая должность";

            //
            // cmbPosition
            //

            this.cmbPosition.BackColor =
                Color.FromArgb(30, 45, 80);

            this.cmbPosition.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbPosition.FlatStyle =
                FlatStyle.Flat;

            this.cmbPosition.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.cmbPosition.ForeColor =
                Color.White;

            this.cmbPosition.FormattingEnabled =
                true;

            this.cmbPosition.Location =
                new Point(24, 198);

            this.cmbPosition.Name =
                "cmbPosition";

            this.cmbPosition.Size =
                new Size(560, 36);

            this.cmbPosition.TabIndex = 4;

            //
            // lblChangeDate
            //

            this.lblChangeDate.AutoSize = true;

            this.lblChangeDate.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblChangeDate.ForeColor =
                Color.White;

            this.lblChangeDate.Location =
                new Point(24, 250);

            this.lblChangeDate.Name =
                "lblChangeDate";

            this.lblChangeDate.Size =
                new Size(118, 17);

            this.lblChangeDate.TabIndex = 5;

            this.lblChangeDate.Text =
                "Дата изменения";

            //
            // dtpChangeDate
            //

            this.dtpChangeDate.CalendarForeColor =
                Color.White;

            this.dtpChangeDate.CalendarMonthBackground =
                Color.FromArgb(30, 58, 117);

            this.dtpChangeDate.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.dtpChangeDate.Format =
                DateTimePickerFormat.Short;

            this.dtpChangeDate.Location =
                new Point(24, 273);

            this.dtpChangeDate.Name =
                "dtpChangeDate";

            this.dtpChangeDate.Size =
                new Size(560, 36);

            this.dtpChangeDate.TabIndex = 6;

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

            this.lblBasis.TabIndex = 7;

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

            this.txtBasis.TabIndex = 8;

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

            this.btnCancel.TabIndex = 9;

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            //
            // btnChangePosition
            //

            this.btnChangePosition.BackColor =
                Color.FromArgb(212, 160, 23);

            this.btnChangePosition.FlatAppearance.BorderSize = 0;

            this.btnChangePosition.FlatStyle =
                FlatStyle.Flat;

            this.btnChangePosition.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnChangePosition.ForeColor =
                Color.White;

            this.btnChangePosition.Location =
                new Point(470, 475);

            this.btnChangePosition.Name =
                "btnChangePosition";

            this.btnChangePosition.Size =
                new Size(114, 36);

            this.btnChangePosition.TabIndex = 10;

            this.btnChangePosition.Text =
                "Изменить";

            this.btnChangePosition.UseVisualStyleBackColor =
                false;

            //
            // Добавление элементов в pnlBody
            //

            this.pnlBody.Controls.Add(this.lblEmployeeInfo);
            this.pnlBody.Controls.Add(this.pnlLine);
            this.pnlBody.Controls.Add(this.pnlEmployeeCard);

            this.pnlBody.Controls.Add(this.lblPosition);
            this.pnlBody.Controls.Add(this.cmbPosition);

            this.pnlBody.Controls.Add(this.lblChangeDate);
            this.pnlBody.Controls.Add(this.dtpChangeDate);

            this.pnlBody.Controls.Add(this.lblBasis);
            this.pnlBody.Controls.Add(this.txtBasis);

            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnChangePosition);

            //
            // Добавление панелей на форму
            //

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);

            //
            // EmployeePositionForm
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
                "EmployeePositionForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Изменение должности";

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