namespace PoliceStationIS.Forms.Authorization
{
    partial class RegisterForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();

            this.picBuilding = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();

            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();

            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();

            this.btnPersonalData = new System.Windows.Forms.Button();
            this.btnPassportData = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnConfirmation = new System.Windows.Forms.Button();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStep5 = new System.Windows.Forms.Label();

            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // RegisterForm

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    8,
                    24,
                    48);

            this.ClientSize =
                new System.Drawing.Size(
                    1180,
                    680);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Name = "RegisterForm";

            this.Text = "Регистрация пользователя";
            //
            // panelHeader
            //

            this.panelHeader.Location =
                new System.Drawing.Point(
                    0,
                    0);

            this.panelHeader.Name =
                "panelHeader";

            this.panelHeader.Size =
                new System.Drawing.Size(
                    1180,
                    120);

            this.panelHeader.BackColor =
                System.Drawing.Color.FromArgb(
                    8,
                    24,
                    48);


            //
            // picBuilding
            //

            this.picBuilding.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.picBuilding.Image =
                global::PoliceStationIS.Properties.Resources.police_building_dark;

            this.picBuilding.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.StretchImage;


            //
            // picLogo
            //

            this.picLogo.Location =
                new System.Drawing.Point(
                    20,
                    20);

            this.picLogo.Name =
                "picLogo";

            this.picLogo.Size =
                new System.Drawing.Size(
                    85,
                    85);

            this.picLogo.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.picLogo.Image =
                global::PoliceStationIS.Properties.Resources.gerb_mvd;


            //
            // lblSystemName
            //

            this.lblSystemName.AutoSize = true;

            this.lblSystemName.BackColor =
                System.Drawing.Color.Transparent;

            this.lblSystemName.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    15F,
                    System.Drawing.FontStyle.Bold);

            this.lblSystemName.ForeColor =
                System.Drawing.Color.White;

            this.lblSystemName.Location =
                new System.Drawing.Point(
                    110,
                    25);

            this.lblSystemName.Name =
                "lblSystemName";

            this.lblSystemName.Text =
                "Информационная система\r\nполицейского участка";


            //
            // lblTitle
            //

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(
                    515,
                    150);

            this.lblTitle.Name =
                "lblTitle";

            this.lblTitle.Text =
                "Регистрация пользователя";
            this.panelHeader.Controls.Add(this.picBuilding);

            this.panelHeader.Controls.Add(this.picLogo);

            this.panelHeader.Controls.Add(this.lblSystemName);

            this.picBuilding.SendToBack();

            this.picLogo.BringToFront();

            this.lblSystemName.BringToFront();
            //
            // panelMenu
            //

            this.panelMenu.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.panelMenu.Location =
                new System.Drawing.Point(
                    30,
                    200);

            this.panelMenu.Name =
                "panelMenu";

            this.panelMenu.Size =
                new System.Drawing.Size(
                    330,
                    400);


            //
            // panelContent
            //

            this.panelContent.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.panelContent.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelContent.Location =
                new System.Drawing.Point(
                    390,
                    200);

            this.panelContent.Name =
                "panelContent";

            this.panelContent.Size =
                new System.Drawing.Size(
                    730,
                    400);

            //
            // lblStep1
            //

            this.lblStep1.AutoSize = false;

            this.lblStep1.Size =
                new System.Drawing.Size(
                    32,
                    32);

            this.lblStep1.Location =
                new System.Drawing.Point(
                    22,
                    20);

            this.lblStep1.Text = "1";

            this.lblStep1.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            this.lblStep1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                   11F,
                    System.Drawing.FontStyle.Bold);

            this.lblStep1.ForeColor =
                System.Drawing.Color.White;

            this.lblStep1.BackColor =
                System.Drawing.Color.FromArgb(
                    66,
                    113,
                    198);

            this.lblStep1.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            //
            // lblStep2
            //

            this.lblStep2.AutoSize = false;
            this.lblStep2.Size = new System.Drawing.Size(32, 32);
            this.lblStep2.Location = new System.Drawing.Point(22, 75);
            this.lblStep2.Text = "2";
            this.lblStep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStep2.ForeColor = System.Drawing.Color.White;
            this.lblStep2.BackColor = System.Drawing.Color.FromArgb(15, 35, 70);
            this.lblStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //
            // lblStep3
            //

            this.lblStep3.AutoSize = false;
            this.lblStep3.Size = new System.Drawing.Size(32, 32);
            this.lblStep3.Location = new System.Drawing.Point(22, 130);
            this.lblStep3.Text = "3";
            this.lblStep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStep3.ForeColor = System.Drawing.Color.White;
            this.lblStep3.BackColor = System.Drawing.Color.FromArgb(15, 35, 70);
            this.lblStep3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //
            // lblStep4
            //

            this.lblStep4.AutoSize = false;
            this.lblStep4.Size = new System.Drawing.Size(32, 32);
            this.lblStep4.Location = new System.Drawing.Point(22, 185);
            this.lblStep4.Text = "4";
            this.lblStep4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStep4.ForeColor = System.Drawing.Color.White;
            this.lblStep4.BackColor = System.Drawing.Color.FromArgb(15, 35, 70);
            this.lblStep4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //
            // lblStep5
            //

            this.lblStep5.AutoSize = false;
            this.lblStep5.Size = new System.Drawing.Size(32, 32);
            this.lblStep5.Location = new System.Drawing.Point(22, 240);
            this.lblStep5.Text = "5";
            this.lblStep5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStep5.ForeColor = System.Drawing.Color.White;
            this.lblStep5.BackColor = System.Drawing.Color.FromArgb(15, 35, 70);
            this.lblStep5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //
            // btnPersonalData
            //

            this.btnPersonalData.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnPersonalData.FlatAppearance.BorderSize = 0;

            this.btnPersonalData.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnPersonalData.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnPersonalData.ForeColor =
                System.Drawing.Color.White;

            this.btnPersonalData.Location =
                new System.Drawing.Point(
                    10,
                    15);

            this.btnPersonalData.Name =
                "btnPersonalData";

            this.btnPersonalData.Size =
                new System.Drawing.Size(
                    260,
                    58);

            this.btnPersonalData.Text =
                "Личные данные";

            this.btnPersonalData.TextAlign =
    System.Drawing.ContentAlignment.MiddleLeft;

            this.btnPersonalData.Padding =
                new System.Windows.Forms.Padding(
                    50,
                    0,
                    0,
                    0);

            this.btnPersonalData.UseVisualStyleBackColor = false;
            //
            // btnPassportData
            //

            this.btnPassportData.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnPassportData.FlatAppearance.BorderSize = 0;

            this.btnPassportData.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnPassportData.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnPassportData.ForeColor =
                System.Drawing.Color.White;

            this.btnPassportData.Location =
                new System.Drawing.Point(
                    10,
                    70);

            this.btnPassportData.Name =
                "btnPassportData";

            this.btnPassportData.Size =
                new System.Drawing.Size(
                    260,
                    58);

            this.btnPassportData.Text =
                "Паспортные данные";

            this.btnPassportData.TextAlign =
     System.Drawing.ContentAlignment.MiddleLeft;

            this.btnPassportData.Padding =
                new System.Windows.Forms.Padding(
                    50,
                    0,
                    0,
                    0);

            this.btnPassportData.UseVisualStyleBackColor = false;
            //
            // btnContacts
            //

            this.btnContacts.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnContacts.FlatAppearance.BorderSize = 0;

            this.btnContacts.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnContacts.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnContacts.ForeColor =
                System.Drawing.Color.White;

            this.btnContacts.Location =
                new System.Drawing.Point(
                    10,
                    125);

            this.btnContacts.Name =
                "btnContacts";

            this.btnContacts.Size =
                new System.Drawing.Size(
                    260,
                    58);

            this.btnContacts.Text =
                "Контактные данные";

            this.btnContacts.TextAlign =
    System.Drawing.ContentAlignment.MiddleLeft;

            this.btnContacts.Padding =
                new System.Windows.Forms.Padding(
                    50,
                    0,
                    0,
                    0);

            this.btnContacts.UseVisualStyleBackColor = false;


            //
            // btnAccount
            //

            this.btnAccount.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnAccount.FlatAppearance.BorderSize = 0;

            this.btnAccount.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAccount.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnAccount.ForeColor =
                System.Drawing.Color.White;

            this.btnAccount.Location =
                new System.Drawing.Point(
                    10,
                    180);

            this.btnAccount.Name =
                "btnAccount";

            this.btnAccount.Size =
                new System.Drawing.Size(
                    260,
                    58);

            this.btnAccount.Text =
                "Учётная запись";

            this.btnAccount.TextAlign =
    System.Drawing.ContentAlignment.MiddleLeft;

            this.btnAccount.Padding =
                new System.Windows.Forms.Padding(
                    50,
                    0,
                    0,
                    0);

            this.btnAccount.UseVisualStyleBackColor = false;


            //
            // btnConfirmation
            //

            this.btnConfirmation.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnConfirmation.FlatAppearance.BorderSize = 0;

            this.btnConfirmation.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnConfirmation.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnConfirmation.ForeColor =
                System.Drawing.Color.White;

            this.btnConfirmation.Location =
                new System.Drawing.Point(
                    10,
                    235);

            this.btnConfirmation.Name =
                "btnConfirmation";

            this.btnConfirmation.Size =
                new System.Drawing.Size(
                    260,
                    58);

            this.btnConfirmation.Text =
                "Подтверждение";

            this.btnConfirmation.TextAlign =
    System.Drawing.ContentAlignment.MiddleLeft;

            this.btnConfirmation.Padding =
                new System.Windows.Forms.Padding(
                    50,
                    0,
                    0,
                    0);

            this.btnConfirmation.UseVisualStyleBackColor = false;

            this.panelMenu.Controls.Add(this.lblStep1);
            this.panelMenu.Controls.Add(this.lblStep2);
            this.panelMenu.Controls.Add(this.lblStep3);
            this.panelMenu.Controls.Add(this.lblStep4);
            this.panelMenu.Controls.Add(this.lblStep5);
            this.panelMenu.Controls.Add(
    this.btnPersonalData);

            this.panelMenu.Controls.Add(
                this.btnPassportData);

            this.panelMenu.Controls.Add(
                this.btnContacts);

            this.panelMenu.Controls.Add(
                this.btnAccount);

            this.panelMenu.Controls.Add(
                this.btnConfirmation);
            //
            // btnBack
            //

            this.btnBack.BackColor =
                System.Drawing.Color.FromArgb(
                    26,
                    53,
                    96);

            this.btnBack.FlatAppearance.BorderSize = 0;

            this.btnBack.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBack.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnBack.ForeColor =
                System.Drawing.Color.White;

            this.btnBack.Location =
                new System.Drawing.Point(
                    770,
                    615);

            this.btnBack.Name =
                "btnBack";

            this.btnBack.Size =
                new System.Drawing.Size(
                    170,
                    40);

            this.btnBack.Text =
                "Назад";

            this.btnBack.UseVisualStyleBackColor = false;


            //
            // btnNext
            //

            this.btnNext.BackColor =
                System.Drawing.Color.FromArgb(
                    40,
                    78,
                    145);

            this.btnNext.FlatAppearance.BorderSize = 0;

            this.btnNext.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnNext.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnNext.ForeColor =
                System.Drawing.Color.White;

            this.btnNext.Location =
                new System.Drawing.Point(
                    950,
                    615);

            this.btnNext.Name =
                "btnNext";

            this.btnNext.Size =
                new System.Drawing.Size(
                    170,
                    40);

            this.btnNext.Text =
                "Далее";

            this.btnNext.UseVisualStyleBackColor = false;
            this.Controls.Add(this.panelHeader);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.panelMenu);

            this.Controls.Add(this.panelContent);

            this.Controls.Add(this.btnBack);

            this.Controls.Add(this.btnNext);
            this.ResumeLayout(false);

            this.PerformLayout();
        }
        private System.Windows.Forms.Panel panelHeader;

        private System.Windows.Forms.PictureBox picBuilding;
        private System.Windows.Forms.PictureBox picLogo;

        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Button btnPersonalData;
        private System.Windows.Forms.Button btnPassportData;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnConfirmation;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStep5;

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        #endregion
    }
}