using System.Windows.Forms;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    partial class AccountDataPage
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
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.lblLogin =
                new System.Windows.Forms.Label();

            this.lblEmail =
                new System.Windows.Forms.Label();

            this.lblPassword =
                new System.Windows.Forms.Label();

            this.lblConfirmPassword =
                new System.Windows.Forms.Label();

            this.txtLogin =
                new System.Windows.Forms.TextBox();

            this.txtEmail =
                new System.Windows.Forms.TextBox();

            this.txtPassword =
                new System.Windows.Forms.TextBox();

            this.txtConfirmPassword =
                new System.Windows.Forms.TextBox();
            this.panelGoldLine =
    new System.Windows.Forms.Panel();

            this.picAccount =
                new System.Windows.Forms.PictureBox();

            this.panelPasswordInfo =
                new System.Windows.Forms.Panel();

            this.picPasswordInfo =
                new System.Windows.Forms.PictureBox();

            this.lblPasswordInfo =
                new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.picAccount)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.picPasswordInfo)).BeginInit();

            this.SuspendLayout();

            // ======================================
            // Заголовок страницы
            // ======================================

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
                "Учётная запись";


            // ======================================
            // Золотая линия
            // ======================================

            this.panelGoldLine.BackColor =
                System.Drawing.Color.FromArgb(
                    214,
                    170,
                    74);

            this.panelGoldLine.Location =
                new System.Drawing.Point(
                    38,
                    60);

            this.panelGoldLine.Size =
                new System.Drawing.Size(
                    120,
                    3);


            // ======================================
            // Картинка
            // ======================================

            this.picAccount.Image =
                global::PoliceStationIS.Properties.Resources.ww_4;

            this.picAccount.Location =
                new System.Drawing.Point(
                    -20,
                    75);

            this.picAccount.Size =
                new System.Drawing.Size(
                    315,
                    315);

            this.picAccount.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;


            // ======================================
            // Логин
            // ======================================

            this.lblLogin.AutoSize = true;

            this.lblLogin.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblLogin.ForeColor =
                System.Drawing.Color.White;

            this.lblLogin.Location =
                new System.Drawing.Point(
                    290,
                    110);

            this.lblLogin.Text =
                "Логин";


            this.txtLogin.Location =
                new System.Drawing.Point(
                    425,
                    105);

            this.txtLogin.Size =
                new System.Drawing.Size(
                    240,
                    28);

            this.txtLogin.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtLogin.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtLogin.ForeColor =
                System.Drawing.Color.White;

            this.txtLogin.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;


            // ======================================
            // Email
            // ======================================

            this.lblEmail.AutoSize = true;

            this.lblEmail.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblEmail.ForeColor =
                System.Drawing.Color.White;

            this.lblEmail.Location =
                new System.Drawing.Point(
                    290,
                    155);

            this.lblEmail.Text =
                "Электронная почта";


            this.txtEmail.Location =
                new System.Drawing.Point(
                    425,
                    150);

            this.txtEmail.Size =
                new System.Drawing.Size(
                    240,
                    28);

            this.txtEmail.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtEmail.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtEmail.ForeColor =
                System.Drawing.Color.White;

            this.txtEmail.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtEmail.Text =
                "example@mail.ru";


            // ======================================
            // Пароль
            // ======================================

            this.lblPassword.AutoSize = true;

            this.lblPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPassword.ForeColor =
                System.Drawing.Color.White;

            this.lblPassword.Location =
                new System.Drawing.Point(
                    290,
                    205);

            this.lblPassword.Text =
                "Пароль";


            this.txtPassword.Location =
                new System.Drawing.Point(
                    425,
                    200);

            this.txtPassword.Size =
                new System.Drawing.Size(
                    240,
                    28);

            this.txtPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtPassword.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtPassword.ForeColor =
                System.Drawing.Color.White;

            this.txtPassword.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtPassword.UseSystemPasswordChar =
                true;


            // ======================================
            // Подтверждение пароля
            // ======================================

            this.lblConfirmPassword.AutoSize = true;

            this.lblConfirmPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblConfirmPassword.ForeColor =
                System.Drawing.Color.White;

            this.lblConfirmPassword.Location =
                new System.Drawing.Point(
                    290,
                    265);

            this.lblConfirmPassword.Text =
                "Подтверждение\r\nпароля";


            this.txtConfirmPassword.Location =
                new System.Drawing.Point(
                    425,
                    270);

            this.txtConfirmPassword.Size =
                new System.Drawing.Size(
                    240,
                    28);

            this.txtConfirmPassword.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.txtConfirmPassword.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.txtConfirmPassword.ForeColor =
                System.Drawing.Color.White;

            this.txtConfirmPassword.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtConfirmPassword.UseSystemPasswordChar =
                true;


            // ======================================
            // Надёжность пароля
            // ======================================

            this.panelStrengthBackground =
                new System.Windows.Forms.Panel();

            this.panelStrength =
                new System.Windows.Forms.Panel();

            this.lblStrength =
                new System.Windows.Forms.Label();


            // Серая линия (фон)

            this.panelStrengthBackground.BackColor =
                System.Drawing.Color.FromArgb(
                    80,
                    80,
                    80);

            this.panelStrengthBackground.Location =
                new System.Drawing.Point(
                    425,
                    255);

            this.panelStrengthBackground.Size =
                new System.Drawing.Size(
                    240,
                    3);


            // Заполняемая линия

            this.panelStrength.BackColor =
                System.Drawing.Color.FromArgb(
                    190,
                    230,
                    90);

            this.panelStrength.Location =
                new System.Drawing.Point(
                    425,
                    255);

            this.panelStrength.Size =
                new System.Drawing.Size(
                    0,
                    3);


            // Текст

            this.lblStrength.AutoSize = true;

            this.lblStrength.ForeColor =
                System.Drawing.Color.White;

            this.lblStrength.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    8F);

            this.lblStrength.Location =
                new System.Drawing.Point(
                    425,
                    235);

            this.lblStrength.Text =
                "Надёжность пароля";


            // Добавляем

            this.Controls.Add(
                this.panelStrengthBackground);

            this.Controls.Add(
                this.panelStrength);

            this.Controls.Add(
                this.lblStrength);

            this.panelStrength.BringToFront();


            // ======================================
            // Информационная карточка
            // ======================================

            this.panelPasswordInfo.BackColor =
                System.Drawing.Color.FromArgb(
                    39,
                    69,
                    120);

            this.panelPasswordInfo.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelPasswordInfo.Location =
                new System.Drawing.Point(
                    288,
                    315);

            this.panelPasswordInfo.Size =
                new System.Drawing.Size(
                    380,
                    70);


            this.picPasswordInfo.Image =
                global::PoliceStationIS.Properties.Resources.e_3;

            this.picPasswordInfo.Location =
                new System.Drawing.Point(
                    10,
                    15);

            this.picPasswordInfo.Size =
                new System.Drawing.Size(
                    35,
                    35);

            this.picPasswordInfo.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;


            this.lblPasswordInfo.ForeColor =
                System.Drawing.Color.White;

            this.lblPasswordInfo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPasswordInfo.Location =
                new System.Drawing.Point(
                    55,
                    12);

            this.lblPasswordInfo.Size =
                new System.Drawing.Size(
                    300,
                    45);

            this.lblPasswordInfo.Text =
                "Пароль должен содержать не менее 8 символов, включая буквы и цифры.";


            this.panelPasswordInfo.Controls.Add(
                this.picPasswordInfo);

            this.panelPasswordInfo.Controls.Add(
                this.lblPasswordInfo);

            // ======================================
            // Добавляем элементы на страницу
            // ======================================

            this.Controls.Add(this.lblTitle);

           
            this.Controls.Add(this.panelGoldLine);

            this.Controls.Add(this.picAccount);

            this.Controls.Add(this.panelPasswordInfo);

            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);

            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);

            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);


            // ======================================
            // Настройка страницы
            // ======================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.Name =
                "AccountDataPage";

            this.Size =
                new System.Drawing.Size(
                    770,
                    430);

            this.PerformLayout();

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Panel panelGoldLine;

        private System.Windows.Forms.PictureBox picAccount;

        private System.Windows.Forms.Panel panelPasswordInfo;

        private System.Windows.Forms.PictureBox picPasswordInfo;

        private System.Windows.Forms.Label lblPasswordInfo;
        private System.Windows.Forms.Panel panelStrengthBackground;

        private System.Windows.Forms.Panel panelStrength;

        private System.Windows.Forms.Label lblStrength;

        #endregion
    }
}