namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    partial class PassportDataPage
    {
        private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblPassportSeries =
                new System.Windows.Forms.Label();

            this.lblPassportNumber =
                new System.Windows.Forms.Label();

            this.lblDepartmentCode =
                new System.Windows.Forms.Label();

            this.lblIssuedBy =
                new System.Windows.Forms.Label();

            this.lblIssueDate =
                new System.Windows.Forms.Label();

            this.lblRegistrationAddress =
                new System.Windows.Forms.Label();

            this.txtPassportSeries =
                new System.Windows.Forms.TextBox();

            this.txtPassportNumber =
                new System.Windows.Forms.TextBox();

            this.cmbDepartmentCode =
                new System.Windows.Forms.ComboBox();

            this.cmbIssuedBy =
                new System.Windows.Forms.ComboBox();

            this.txtIssueDate =
                new System.Windows.Forms.TextBox();

            this.btnCalendar =
                new System.Windows.Forms.Button();

            this.txtRegistrationAddress =
                new System.Windows.Forms.TextBox();

            this.SuspendLayout();
            // ======================================
            // Заголовок страницы
            // ======================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(
                    20,
                    15);

            this.lblTitle.Text =
                "Регистрация нового пользователя";


            // ======================================
            // Подзаголовок
            // ======================================

            System.Windows.Forms.Label lblSection =
                new System.Windows.Forms.Label();

            lblSection.AutoSize = true;

            lblSection.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            lblSection.ForeColor =
                System.Drawing.Color.White;

            lblSection.Location =
                new System.Drawing.Point(
                    20,
                    55);

            lblSection.Text =
                "Паспортные данные";


            // ======================================
            // Серия паспорта
            // ======================================

            this.lblPassportSeries.AutoSize = true;

            this.lblPassportSeries.ForeColor =
                System.Drawing.Color.White;

            this.lblPassportSeries.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPassportSeries.Location =
                new System.Drawing.Point(
                    20,
                    105);

            this.lblPassportSeries.Text =
                "Серия паспорта";


            this.txtPassportSeries.Location =
                new System.Drawing.Point(
                    180,
                    100);

            this.txtPassportSeries.Size =
                new System.Drawing.Size(
                    430,
                    27);

            this.txtPassportSeries.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.txtPassportSeries.ForeColor =
                System.Drawing.Color.White;

            this.txtPassportSeries.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPassportSeries.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Номер паспорта
            // ======================================

            this.lblPassportNumber.AutoSize = true;

            this.lblPassportNumber.ForeColor =
                System.Drawing.Color.White;

            this.lblPassportNumber.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPassportNumber.Location =
                new System.Drawing.Point(
                    20,
                    145);

            this.lblPassportNumber.Text =
                "Номер паспорта";


            this.txtPassportNumber.Location =
                new System.Drawing.Point(
                    180,
                    140);

            this.txtPassportNumber.Size =
                new System.Drawing.Size(
                    430,
                    27);

            this.txtPassportNumber.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.txtPassportNumber.ForeColor =
                System.Drawing.Color.White;

            this.txtPassportNumber.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPassportNumber.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);
            // ======================================
            // Код подразделения
            // ======================================

            this.lblDepartmentCode.AutoSize = true;

            this.lblDepartmentCode.ForeColor =
                System.Drawing.Color.White;

            this.lblDepartmentCode.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblDepartmentCode.Location =
                new System.Drawing.Point(
                    20,
                    185);

            this.lblDepartmentCode.Text =
                "Код подразделения";


            this.cmbDepartmentCode.Location =
                new System.Drawing.Point(
                    180,
                    180);

            this.cmbDepartmentCode.Size =
                new System.Drawing.Size(
                    430,
                    28);

            this.cmbDepartmentCode.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbDepartmentCode.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.cmbDepartmentCode.ForeColor =
                System.Drawing.Color.White;

            this.cmbDepartmentCode.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.cmbDepartmentCode.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;


            // ======================================
            // Кем выдан
            // ======================================

            this.lblIssuedBy.AutoSize = true;

            this.lblIssuedBy.ForeColor =
                System.Drawing.Color.White;

            this.lblIssuedBy.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblIssuedBy.Location =
                new System.Drawing.Point(
                    20,
                    225);

            this.lblIssuedBy.Text =
                "Кем выдан";


            this.cmbIssuedBy.Location =
                new System.Drawing.Point(
                    180,
                    220);

            this.cmbIssuedBy.Size =
                new System.Drawing.Size(
                    430,
                    28);

            this.cmbIssuedBy.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbIssuedBy.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.cmbIssuedBy.ForeColor =
                System.Drawing.Color.White;

            this.cmbIssuedBy.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.cmbIssuedBy.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;


            // ======================================
            // Дата выдачи
            // ======================================

            this.lblIssueDate.AutoSize = true;

            this.lblIssueDate.ForeColor =
                System.Drawing.Color.White;

            this.lblIssueDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblIssueDate.Location =
                new System.Drawing.Point(
                    20,
                    265);

            this.lblIssueDate.Text =
                "Дата выдачи";


            this.txtIssueDate.Location =
                new System.Drawing.Point(
                    180,
                    260);

            this.txtIssueDate.Size =
                new System.Drawing.Size(
                    390,
                    27);

            this.txtIssueDate.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.txtIssueDate.ForeColor =
                System.Drawing.Color.White;

            this.txtIssueDate.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtIssueDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Кнопка календаря
            // ======================================

            this.btnCalendar.Location =
                new System.Drawing.Point(
                    570,
                    260);

            this.btnCalendar.Size =
                new System.Drawing.Size(
                    40,
                    25);

            this.btnCalendar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCalendar.FlatAppearance.BorderSize = 1;

            this.btnCalendar.FlatAppearance.BorderColor =
                System.Drawing.Color.Gray;

            this.btnCalendar.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.btnCalendar.ForeColor =
                System.Drawing.Color.White;

            this.btnCalendar.Font =
                new System.Drawing.Font(
                    "Segoe UI Emoji",
                    10F);

            this.btnCalendar.Text = "📅";

            this.btnCalendar.UseVisualStyleBackColor = false;
            // ======================================
            // Адрес регистрации
            // ======================================

            this.lblRegistrationAddress.AutoSize = true;

            this.lblRegistrationAddress.ForeColor =
                System.Drawing.Color.White;

            this.lblRegistrationAddress.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblRegistrationAddress.Location =
                new System.Drawing.Point(
                    20,
                    305);

            this.lblRegistrationAddress.Text =
                "Адрес регистрации";


            this.txtRegistrationAddress.Location =
                new System.Drawing.Point(
                    180,
                    300);

            this.txtRegistrationAddress.Size =
                new System.Drawing.Size(
                    430,
                    27);

            this.txtRegistrationAddress.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.txtRegistrationAddress.ForeColor =
                System.Drawing.Color.White;

            this.txtRegistrationAddress.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtRegistrationAddress.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Добавляем элементы на страницу
            // ======================================

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(lblSection);

            this.Controls.Add(this.lblPassportSeries);
            this.Controls.Add(this.txtPassportSeries);

            this.Controls.Add(this.lblPassportNumber);
            this.Controls.Add(this.txtPassportNumber);

            this.Controls.Add(this.lblDepartmentCode);
            this.Controls.Add(this.cmbDepartmentCode);

            this.Controls.Add(this.lblIssuedBy);
            this.Controls.Add(this.cmbIssuedBy);

            this.Controls.Add(this.lblIssueDate);
            this.Controls.Add(this.txtIssueDate);

            this.Controls.Add(this.btnCalendar);

            this.Controls.Add(this.lblRegistrationAddress);
            this.Controls.Add(this.txtRegistrationAddress);


            // ======================================
            // Настройка страницы
            // ======================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.Name =
                "PassportDataPage";

            this.Size =
                new System.Drawing.Size(
                    770,
                    430);

            this.PerformLayout();

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblPassportSeries;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.Label lblDepartmentCode;
        private System.Windows.Forms.Label lblIssuedBy;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblRegistrationAddress;

        private System.Windows.Forms.TextBox txtPassportSeries;
        private System.Windows.Forms.TextBox txtPassportNumber;

        private System.Windows.Forms.ComboBox cmbDepartmentCode;
        private System.Windows.Forms.ComboBox cmbIssuedBy;

        private System.Windows.Forms.TextBox txtIssueDate;

        private System.Windows.Forms.Button btnCalendar;

        private System.Windows.Forms.TextBox txtRegistrationAddress;

        #endregion
    }

}
