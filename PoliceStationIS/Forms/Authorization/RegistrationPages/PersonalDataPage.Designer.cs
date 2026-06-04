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
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.lblSurname =
                new System.Windows.Forms.Label();

            this.lblName =
                new System.Windows.Forms.Label();

            this.lblPatronymic =
                new System.Windows.Forms.Label();

            this.lblBirthDate =
                new System.Windows.Forms.Label();

            this.lblGender =
                new System.Windows.Forms.Label();

            this.lblPosition =
                new System.Windows.Forms.Label();

            this.lblDepartment =
                new System.Windows.Forms.Label();

            this.lblRank =
                new System.Windows.Forms.Label();

            this.txtSurname =
                new System.Windows.Forms.TextBox();

            this.txtName =
                new System.Windows.Forms.TextBox();

            this.txtPatronymic =
                new System.Windows.Forms.TextBox();

            this.txtBirthDate =
                new System.Windows.Forms.TextBox();

            this.btnCalendar =
                new System.Windows.Forms.Button();

            this.cmbGender =
                new System.Windows.Forms.ComboBox();

            this.cmbPosition =
                new System.Windows.Forms.ComboBox();

            this.cmbDepartment =
                new System.Windows.Forms.ComboBox();

            this.cmbRank =
                new System.Windows.Forms.ComboBox();

            this.picPersonal =
                new System.Windows.Forms.PictureBox();

            this.panelGoldLine =
                new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.picPersonal)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // PAGE
            // =====================================

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
                    500);

            // =====================================
            // TITLE
            // =====================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    16F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(
                    35,
                    25);

            this.lblTitle.Text =
                "Регистрация нового пользователя";

            // =====================================
            // SECTION
            // =====================================

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
                    38,
                    75);

            lblSection.Text =
                "Личные данные";

            // =====================================
            // GOLD LINE
            // =====================================

            this.panelGoldLine.BackColor =
                System.Drawing.Color.FromArgb(
                    214,
                    170,
                    74);

            this.panelGoldLine.Location =
                new System.Drawing.Point(
                    40,
                    105);

            this.panelGoldLine.Size =
                new System.Drawing.Size(
                    120,
                    3);

            // =====================================
            // PICTURE
            // =====================================

            this.picPersonal.Location =
                new System.Drawing.Point(
                    30,
                    140);

            this.picPersonal.Size =
                new System.Drawing.Size(
                    190,
                    250);

            this.picPersonal.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.picPersonal.Image =
                global::PoliceStationIS.Properties.Resources.ww_1;

            // =====================================
            // ФАМИЛИЯ
            // =====================================

            this.lblSurname.AutoSize = true;

            this.lblSurname.ForeColor =
                System.Drawing.Color.White;

            this.lblSurname.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblSurname.Location =
                new System.Drawing.Point(
                    270,
                    75);

            this.lblSurname.Text =
                "Фамилия";

            this.txtSurname.Location =
                new System.Drawing.Point(
                    390,
                    70);

            this.txtSurname.Size =
                new System.Drawing.Size(
                    280,
                    27);

            this.txtSurname.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtSurname.ForeColor =
                System.Drawing.Color.White;

            this.txtSurname.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtSurname.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ИМЯ
            // =====================================

            this.lblName.AutoSize = true;

            this.lblName.ForeColor =
                System.Drawing.Color.White;

            this.lblName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblName.Location =
                new System.Drawing.Point(
                    270,
                    115);

            this.lblName.Text =
                "Имя";

            this.txtName.Location =
                new System.Drawing.Point(
                    390,
                    110);

            this.txtName.Size =
                new System.Drawing.Size(
                    280,
                    27);

            this.txtName.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtName.ForeColor =
                System.Drawing.Color.White;

            this.txtName.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ОТЧЕСТВО
            // =====================================

            this.lblPatronymic.AutoSize = true;

            this.lblPatronymic.ForeColor =
                System.Drawing.Color.White;

            this.lblPatronymic.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPatronymic.Location =
                new System.Drawing.Point(
                    270,
                    165);

            this.lblPatronymic.Text =
                "Отчество";

            this.txtPatronymic.Location =
                new System.Drawing.Point(
                    390,
                    160);

            this.txtPatronymic.Size =
                new System.Drawing.Size(
                    280,
                    27);

            this.txtPatronymic.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtPatronymic.ForeColor =
                System.Drawing.Color.White;

            this.txtPatronymic.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPatronymic.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ДАТА РОЖДЕНИЯ
            // =====================================

            this.lblBirthDate.AutoSize = true;

            this.lblBirthDate.ForeColor =
                System.Drawing.Color.White;

            this.lblBirthDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblBirthDate.Location =
                new System.Drawing.Point(
                    270,
                    215);

            this.lblBirthDate.Text =
                "Дата рождения";

            this.txtBirthDate.Location =
                new System.Drawing.Point(
                    390,
                    210);

            this.txtBirthDate.Size =
                new System.Drawing.Size(
                    240,
                    27);

            this.txtBirthDate.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtBirthDate.ForeColor =
                System.Drawing.Color.White;

            this.txtBirthDate.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtBirthDate.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.btnCalendar.Location =
                new System.Drawing.Point(
                    590,
                    210);

            this.btnCalendar.Size =
                new System.Drawing.Size(
                    40,
                    27);

            this.btnCalendar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCalendar.FlatAppearance.BorderSize = 1;

            this.btnCalendar.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.btnCalendar.ForeColor =
                System.Drawing.Color.White;

            this.btnCalendar.Text = "📅";


            //
            // btnCalendar
            //

            this.btnCalendar.Location =
                new System.Drawing.Point(
                    630,
                    210);

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


            // =====================================
            // ПОЛ
            // =====================================

            this.lblGender.AutoSize = true;

            this.lblGender.ForeColor =
                System.Drawing.Color.White;

            this.lblGender.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblGender.Location =
                new System.Drawing.Point(
                    270,
                    265);

            this.lblGender.Text =
                "Пол";

            this.cmbGender.Location =
                new System.Drawing.Point(
                    390,
                    260);

            this.cmbGender.Size =
                new System.Drawing.Size(
                    280,
                    28);

            this.cmbGender.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbGender.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.cmbGender.ForeColor =
                System.Drawing.Color.White;

            this.cmbGender.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ДОЛЖНОСТЬ
            // =====================================

            this.lblPosition.AutoSize = true;

            this.lblPosition.ForeColor =
                System.Drawing.Color.White;

            this.lblPosition.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPosition.Location =
                new System.Drawing.Point(
                    270,
                    305);

            this.lblPosition.Text =
                "Должность";

            this.cmbPosition.Location =
                new System.Drawing.Point(
                    390,
                    300);

            this.cmbPosition.Size =
                new System.Drawing.Size(
                    280,
                    28);

            this.cmbPosition.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbPosition.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.cmbPosition.ForeColor =
                System.Drawing.Color.White;

            this.cmbPosition.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ПОДРАЗДЕЛЕНИЕ
            // =====================================

            this.lblDepartment.AutoSize = true;

            this.lblDepartment.ForeColor =
                System.Drawing.Color.White;

            this.lblDepartment.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblDepartment.Location =
                new System.Drawing.Point(
                    270,
                    345);

            this.lblDepartment.Text =
                "Подразделение";

            this.cmbDepartment.Location =
                new System.Drawing.Point(
                    390,
                    340);

            this.cmbDepartment.Size =
                new System.Drawing.Size(
                    280,
                    28);

            this.cmbDepartment.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbDepartment.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.cmbDepartment.ForeColor =
                System.Drawing.Color.White;

            this.cmbDepartment.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ЗВАНИЕ
            // =====================================

            this.lblRank.AutoSize = true;

            this.lblRank.ForeColor =
                System.Drawing.Color.White;

            this.lblRank.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblRank.Location =
                new System.Drawing.Point(
                    270,
                    385);

            this.lblRank.Text =
                "Звание";

            this.cmbRank.Location =
                new System.Drawing.Point(
                    390,
                    380);

            this.cmbRank.Size =
                new System.Drawing.Size(
                    280,
                    28);

            this.cmbRank.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.cmbRank.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.cmbRank.ForeColor =
                System.Drawing.Color.White;

            this.cmbRank.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);


            // =====================================
            // ДОБАВЛЕНИЕ ЭЛЕМЕНТОВ
            // =====================================

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(lblSection);

            this.Controls.Add(this.panelGoldLine);

            this.Controls.Add(this.picPersonal);

            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtSurname);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.txtPatronymic);

            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.txtBirthDate);
            this.Controls.Add(this.btnCalendar);

            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbGender);

            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.cmbPosition);

            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbDepartment);

            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.cmbRank);


            // =====================================
            // COMBOBOX
            // =====================================

            this.cmbGender.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbPosition.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbDepartment.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbRank.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;


            // =====================================
            // FINISH
            // =====================================

            ((System.ComponentModel.ISupportInitialize)(this.picPersonal)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
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
        private System.Windows.Forms.PictureBox picPersonal;

        private System.Windows.Forms.Panel panelGoldLine;

        #endregion
    }
}