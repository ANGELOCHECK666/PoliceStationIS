namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    partial class PersonalDataPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
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

            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPatronymic = new System.Windows.Forms.Label();

            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();

            this.lblPosition = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();

            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatronymic = new System.Windows.Forms.TextBox();

            this.txtBirthDate = new System.Windows.Forms.TextBox();

            this.btnCalendar = new System.Windows.Forms.Button();

            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbRank = new System.Windows.Forms.ComboBox();

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
                "Личные данные";


            // ======================================
            // Фамилия
            // ======================================

            this.lblSurname.AutoSize = true;

            this.lblSurname.ForeColor =
                System.Drawing.Color.White;
            this.lblSurname.Font =
    new System.Drawing.Font(
        "Segoe UI",
        10F,
        System.Drawing.FontStyle.Regular);

            this.lblSurname.Location =
                new System.Drawing.Point(
                    20,
                    80);

            this.lblSurname.Text =
                "Фамилия";


            this.txtSurname.Location =
                new System.Drawing.Point(
                    180,
                    75);

            this.txtSurname.Size =
                new System.Drawing.Size(
                    430,
                    27);
            this.txtSurname.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.txtSurname.ForeColor =
                System.Drawing.Color.White;

            this.txtSurname.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtSurname.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Имя
            // ======================================

            this.lblName.AutoSize = true;

            this.lblName.ForeColor =
                System.Drawing.Color.White;
            this.lblName.Font =
    new System.Drawing.Font(
        "Segoe UI",
        10F,
        System.Drawing.FontStyle.Regular);

            this.lblName.Location =
                new System.Drawing.Point(
                    20,
                    120);

            this.lblName.Text =
                "Имя";


            this.txtName.Location =
                new System.Drawing.Point(
                    180,
                    115);

            this.txtName.Size =
                new System.Drawing.Size(
                    430,
                    27);
            this.txtName.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.txtName.ForeColor =
                System.Drawing.Color.White;

            this.txtName.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            // ======================================
            // Отчество
            // ======================================

            this.lblPatronymic.AutoSize = true;

            this.lblPatronymic.ForeColor =
                System.Drawing.Color.White;

            this.lblPatronymic.Font =
        new System.Drawing.Font(
            "Segoe UI",
            10F,
            System.Drawing.FontStyle.Regular);

            this.lblPatronymic.Location =
                new System.Drawing.Point(
                    20,
                    160);

            this.lblPatronymic.Text =
                "Отчество";


            this.txtPatronymic.Location =
                new System.Drawing.Point(
                    180,
                    155);

            this.txtPatronymic.Size =
                new System.Drawing.Size(
                    430,
                    27);
            this.txtPatronymic.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.txtPatronymic.ForeColor =
                System.Drawing.Color.White;

            this.txtPatronymic.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPatronymic.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            //
            // txtBirthDate
            //
            //
            // lblBirthDate
            //

            this.lblBirthDate.AutoSize = true;

            this.lblBirthDate.ForeColor =
                System.Drawing.Color.White;

            this.lblBirthDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblBirthDate.Location =
                new System.Drawing.Point(
                    20,
                    195);

            this.lblBirthDate.Name =
                "lblBirthDate";

            this.lblBirthDate.Text =
                "Дата рождения";
            this.txtBirthDate.Location =
                new System.Drawing.Point(
                    180,
                    195);

            this.txtBirthDate.Size =
                new System.Drawing.Size(
                    390,
                    27);

            this.txtBirthDate.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtBirthDate.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.txtBirthDate.ForeColor =
                System.Drawing.Color.White;

            this.txtBirthDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtBirthDate.Text =
                "15.05.1990";
            //
            // btnCalendar
            //

            this.btnCalendar.Location =
                new System.Drawing.Point(
                    570,
                    195);

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
            // Пол
            // ======================================

            this.lblGender.AutoSize = true;

            this.lblGender.ForeColor =
                System.Drawing.Color.White;

            this.lblGender.Font =
        new System.Drawing.Font(
            "Segoe UI",
            10F,
            System.Drawing.FontStyle.Regular);

            this.lblGender.Location =
                new System.Drawing.Point(
                    20,
                    240);

            this.lblGender.Text =
                "Пол";


            this.cmbGender.Location =
                new System.Drawing.Point(
                    180,
                    235);

            this.cmbGender.Size =
                new System.Drawing.Size(
                    430,
                    28);
            this.cmbGender.FlatStyle =
    System.Windows.Forms.FlatStyle.Flat;
            this.cmbGender.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.cmbGender.ForeColor =
                System.Drawing.Color.White;

            this.cmbGender.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Должность
            // ======================================

            this.lblPosition.AutoSize = true;

            this.lblPosition.ForeColor =
                System.Drawing.Color.White;

            this.lblPosition.Font =
        new System.Drawing.Font(
            "Segoe UI",
            10F,
            System.Drawing.FontStyle.Regular);

            this.lblPosition.Location =
                new System.Drawing.Point(
                    20,
                    280);

            this.lblPosition.Text =
                "Должность";


            this.cmbPosition.Location =
                new System.Drawing.Point(
                    180,
                    275);

            this.cmbPosition.Size =
                new System.Drawing.Size(
                    430,
                    28);
            this.cmbPosition.FlatStyle =
    System.Windows.Forms.FlatStyle.Flat;
            this.cmbPosition.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.cmbPosition.ForeColor =
                System.Drawing.Color.White;

            this.cmbPosition.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Подразделение
            // ======================================

            this.lblDepartment.AutoSize = true;

            this.lblDepartment.ForeColor =
                System.Drawing.Color.White;

            this.lblDepartment.Font =
        new System.Drawing.Font(
            "Segoe UI",
            10F,
            System.Drawing.FontStyle.Regular);

            this.lblDepartment.Location =
                new System.Drawing.Point(
                    20,
                    320);

            this.lblDepartment.Text =
                "Подразделение";


            this.cmbDepartment.Location =
                new System.Drawing.Point(
                    180,
                    315);

            this.cmbDepartment.Size =
                new System.Drawing.Size(
                    430,
                    28);
            this.cmbDepartment.FlatStyle =
    System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartment.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.cmbDepartment.ForeColor =
                System.Drawing.Color.White;

            this.cmbDepartment.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // ======================================
            // Звание
            // ======================================

            this.lblRank.AutoSize = true;

            this.lblRank.ForeColor =
                System.Drawing.Color.White;

            this.lblRank.Font =
        new System.Drawing.Font(
            "Segoe UI",
            10F,
            System.Drawing.FontStyle.Regular);

            this.lblRank.Location =
                new System.Drawing.Point(
                    20,
                    360);

            this.lblRank.Text =
                "Звание";


            this.cmbRank.Location =
                new System.Drawing.Point(
                    180,
                    355);

            this.cmbRank.Size =
                new System.Drawing.Size(
                    430,
                    28);
            this.cmbRank.FlatStyle =
    System.Windows.Forms.FlatStyle.Flat;
            this.cmbRank.BackColor =
    System.Drawing.Color.FromArgb(
        31,
        59,
        105);

            this.cmbRank.ForeColor =
                System.Drawing.Color.White;

            this.cmbRank.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);
            // ======================================
            // Добавляем элементы на страницу
            // ======================================

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(lblSection);

            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtSurname);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.txtPatronymic);

            this.Controls.Add(this.lblBirthDate);


            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbGender);

            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.cmbPosition);

            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbDepartment);

            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.cmbRank);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.btnCalendar);


            // ======================================
            // Настройка страницы
            // ======================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.Name =
                "PersonalDataPage";

            this.Size =
                new System.Drawing.Size(
                    770,
                    430);

            
            this.PerformLayout();

            // Настройка ComboBox
            this.cmbGender.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbPosition.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbDepartment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbRank.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Настройка страницы
            this.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.Size =
                new System.Drawing.Size(
                    770,
                    400);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPatronymic;

        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblGender;

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRank;

        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatronymic;

        private System.Windows.Forms.TextBox txtBirthDate;
        private System.Windows.Forms.Button btnCalendar;

        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbRank;

        #endregion
    }
}