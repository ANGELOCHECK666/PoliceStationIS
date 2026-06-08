namespace PoliceStationIS.Forms.Authorization
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picBuilding;

        private System.Windows.Forms.Label lblSystemName;

        private System.Windows.Forms.Panel panelLogin;

        private System.Windows.Forms.Label lblLoginTitle;

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.CheckBox chkRemember;

        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.LinkLabel lnkRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picBuilding = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.picBuilding);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblSystemName);
            this.picBuilding.SendToBack();

            this.picLogo.BringToFront();

            this.lblSystemName.BringToFront();
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1520, 230);
            this.panelHeader.TabIndex = 1;
            // 
            // picBuilding
            // 
            this.picBuilding.Image = global::PoliceStationIS.Properties.Resources.police_building_dark;
            this.picBuilding.Location = new System.Drawing.Point(0, 0);
            this.picBuilding.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picBuilding.Name = "picBuilding";
            this.picBuilding.Size = new System.Drawing.Size(1520, 230);
            this.picBuilding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuilding.TabIndex = 0;
            this.picBuilding.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::PoliceStationIS.Properties.Resources.gerb_mvd;
            this.picLogo.Location = new System.Drawing.Point(36, 36);
            this.picLogo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(144, 144);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Location = new System.Drawing.Point(210, 50);
            this.lblSystemName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(375, 74);
            this.lblSystemName.TabIndex = 2;
            this.lblSystemName.Text = "Информационная система\r\nполицейского участка";
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(39)))), ((int)(((byte)(77)))));
            this.panelLogin.Controls.Add(this.lblLoginTitle);
            this.panelLogin.Controls.Add(this.lblLogin);
            this.panelLogin.Controls.Add(this.txtLogin);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.chkRemember);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.lnkForgotPassword);
            this.panelLogin.Controls.Add(
    this.lnkRegister);
            this.panelLogin.Location = new System.Drawing.Point(410, 260);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(700, 700);
            this.panelLogin.TabIndex = 0;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.ForeColor = System.Drawing.Color.White;
            this.lblLoginTitle.Location = new System.Drawing.Point(200, 36);
            this.lblLoginTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(320, 54);
            this.lblLoginTitle.TabIndex = 0;
            this.lblLoginTitle.Text = "Вход в систему";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(70, 125);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(93, 37);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Логин";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.ForeColor = System.Drawing.Color.Gray;
            this.txtLogin.Location = new System.Drawing.Point(70, 175);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(558, 43);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Text = "Введите логин";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(70, 255);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(110, 37);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(70, 305);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(558, 43);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "Введите пароль";
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRemember.ForeColor = System.Drawing.Color.White;
            this.chkRemember.Location = new System.Drawing.Point(70, 420);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(229, 36);
            this.chkRemember.TabIndex = 5;
            this.chkRemember.Text = "Запомнить меня";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(145)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(70, 479);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(558, 84);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "ВОЙТИ";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.lnkForgotPassword.Location = new System.Drawing.Point(250, 360);
            this.lnkForgotPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(194, 32);
            this.lnkForgotPassword.TabIndex = 7;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Забыли пароль?";
            this.lnkForgotPassword.VisitedLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);

            // =====================================
            // REGISTER LINK
            // =====================================

            this.lnkRegister.ActiveLinkColor =
                System.Drawing.Color.White;

            this.lnkRegister.AutoSize = true;

            this.lnkRegister.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lnkRegister.LinkColor =
                System.Drawing.Color.Gold;

            this.lnkRegister.Location =
                new System.Drawing.Point(
                    170,
                    590);

            this.lnkRegister.Name =
                "lnkRegister";

            this.lnkRegister.Size =
                new System.Drawing.Size(
                    250,
                    32);

            this.lnkRegister.TabStop = true;

            this.lnkRegister.Text =
                "Нет аккаунта? Зарегистрироваться";

            this.lnkRegister.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(
                    this.lnkRegister_LinkClicked);

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(24)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1520, 1040);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}