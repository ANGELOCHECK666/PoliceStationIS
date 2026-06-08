namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    partial class ConfirmationPage
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

            this.lblSubtitle =
                new System.Windows.Forms.Label();

            this.panelPersonal =
                new System.Windows.Forms.Panel();

            this.panelPassport =
                new System.Windows.Forms.Panel();

            this.lblPersonalTitle =
                new System.Windows.Forms.Label();

            this.lblPassportTitle =
                new System.Windows.Forms.Label();

            this.lblPersonalData =
                new System.Windows.Forms.Label();

            this.lblPassportData =
                new System.Windows.Forms.Label();

            this.picPersonal =
                new System.Windows.Forms.PictureBox();

            this.picPassport =
                new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)
                (this.picPersonal)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picPassport)).BeginInit();

            this.btnRegister =
    new System.Windows.Forms.Button();

            this.panelWarning =
                new System.Windows.Forms.Panel();

            this.lblWarning =
                new System.Windows.Forms.Label();

            this.SuspendLayout();

            // ======================================
            // Заголовок
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
                    20,
                    15);

            this.lblTitle.Text =
                "Подтверждение регистрации";


            // ======================================
            // Подзаголовок
            // ======================================

            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F);

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.Gainsboro;

            this.lblSubtitle.Location =
                new System.Drawing.Point(
                    22,
                    50);

            this.lblSubtitle.Text =
                "Проверьте введённые данные перед завершением регистрации";


            // ======================================
            // Личные данные
            // ======================================

            this.panelPersonal.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    68,
                    117);

            this.panelPersonal.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelPersonal.Location =
                new System.Drawing.Point(
                    20,
                    90);

            this.panelPersonal.Size =
                new System.Drawing.Size(
                    330,
                    140);

            this.picPersonal.Image =
    global::PoliceStationIS.Properties.Resources.personal_icon;

            this.picPersonal.Location =
    new System.Drawing.Point(
        10,
        10);

            this.picPersonal.Size =
                new System.Drawing.Size(
                    24,
                    24);

            this.picPersonal.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;


            this.lblPersonalTitle.AutoSize = true;

            this.lblPersonalTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblPersonalTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblPersonalTitle.Location =
                new System.Drawing.Point(
                    40,
                    12);

            this.lblPersonalTitle.Text =
                "Личные данные";

            this.lblPersonalData.ForeColor =
    System.Drawing.Color.White;

            this.lblPersonalData.Location =
                new System.Drawing.Point(
                    15,
                    45);

            this.lblPersonalData.Size =
                new System.Drawing.Size(
                    310,
                    105);

            this.lblPersonalData.Text =
                "Личные данные";

            this.panelPersonal.Controls.Add(
    this.picPersonal);

            this.panelPersonal.Controls.Add(
                this.lblPersonalTitle);

            this.panelPersonal.Controls.Add(
                this.lblPersonalData);

            // ======================================
            // Паспортные данные
            // ======================================

            this.panelPassport.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    68,
                    117);

            this.panelPassport.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelPassport.Location =
                new System.Drawing.Point(
                    380,
                    90);

            this.panelPassport.Size =
                new System.Drawing.Size(
                    330,
                    140);

            this.picPassport.Image =
    global::PoliceStationIS.Properties.Resources.passport_icon;

            this.picPassport.Location =
    new System.Drawing.Point(
        10,
        10);

            this.picPassport.Size =
                new System.Drawing.Size(
                    24,
                    24);

            this.picPassport.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblPassportTitle.AutoSize = true;

            this.lblPassportTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblPassportTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblPassportTitle.Location =
                new System.Drawing.Point(
                    40,
                    12);

            this.lblPassportTitle.Text =
                "Паспортные данные";

            this.lblPassportData.ForeColor =
    System.Drawing.Color.White;

            this.lblPassportData.Location =
                new System.Drawing.Point(
                    15,
                    45);

            this.lblPassportData.Size =
                new System.Drawing.Size(
                    310,
                    105);

            this.lblPassportData.Text =
                "Паспортные данные";

            this.panelPassport.Controls.Add(
    this.picPassport);

            this.panelPassport.Controls.Add(
                this.lblPassportTitle);

            this.panelPassport.Controls.Add(
                this.lblPassportData);


            // ======================================
            // Контактные данные
            // ======================================

            this.panelContacts =
                new System.Windows.Forms.Panel();

            this.picContacts =
                new System.Windows.Forms.PictureBox();

            this.lblContactsTitle =
                new System.Windows.Forms.Label();

            this.lblContactsData =
                new System.Windows.Forms.Label();

            this.panelContacts.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    68,
                    117);

            this.panelContacts.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelContacts.Location =
                new System.Drawing.Point(
                    20,
                    245);

            this.panelContacts.Size =
                new System.Drawing.Size(
                    330,
                    100);

            this.picContacts.Image =
    global::PoliceStationIS.Properties.Resources.contacts_icon;


            this.picContacts.Location =
                new System.Drawing.Point(
                    10,
                    10);

            this.picContacts.Size =
                new System.Drawing.Size(
                    24,
                    24);

            this.picContacts.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;


            this.lblContactsTitle.AutoSize = true;

            this.lblContactsTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblContactsTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblContactsTitle.Location =
                new System.Drawing.Point(
                    40,
                    12);

            this.lblContactsTitle.Text =
                "Контактные данные";


            this.lblContactsData.ForeColor =
                System.Drawing.Color.White;

            this.lblContactsData.Location =
                new System.Drawing.Point(
                    15,
                    45);

            this.lblContactsData.Size =
                new System.Drawing.Size(
                    310,
                    60);

            this.lblContactsData.Text =
                "Контактные данные";


            this.panelContacts.Controls.Add(
                this.picContacts);

            this.panelContacts.Controls.Add(
                this.lblContactsTitle);

            this.panelContacts.Controls.Add(
                this.lblContactsData);


            // ======================================
            // Учётная запись
            // ======================================

            this.panelAccount =
                new System.Windows.Forms.Panel();

            this.picAccount =
                new System.Windows.Forms.PictureBox();

            this.lblAccountTitle =
                new System.Windows.Forms.Label();

            this.lblAccountData =
                new System.Windows.Forms.Label();

            this.panelAccount.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    68,
                    117);

            this.panelAccount.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.panelAccount.Location =
                new System.Drawing.Point(
                    380,
                    245);

            this.panelAccount.Size =
                new System.Drawing.Size(
                    330,
                    100);

            this.picAccount.Image =
    global::PoliceStationIS.Properties.Resources.account_icon;

            this.picAccount.Location =
                new System.Drawing.Point(
                    10,
                    10);

            this.picAccount.Size =
                new System.Drawing.Size(
                    24,
                    24);

            this.picAccount.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;


            this.lblAccountTitle.AutoSize = true;

            this.lblAccountTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblAccountTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblAccountTitle.Location =
                new System.Drawing.Point(
                    40,
                    12);

            this.lblAccountTitle.Text =
                "Учётная запись";


            this.lblAccountData.ForeColor =
                System.Drawing.Color.White;

            this.lblAccountData.Location =
                new System.Drawing.Point(
                    15,
                    45);

            this.lblAccountData.Size =
                new System.Drawing.Size(
                    310,
                    60);

            this.lblAccountData.Text =
                "Учётная запись";


            this.panelAccount.Controls.Add(
                this.picAccount);

            this.panelAccount.Controls.Add(
                this.lblAccountTitle);

            this.panelAccount.Controls.Add(
                this.lblAccountData);


            // ======================================
            // Предупреждение
            // ======================================

            this.panelWarning =
                new System.Windows.Forms.Panel();

            this.lblWarning =
                new System.Windows.Forms.Label();

            this.panelWarning.BackColor =
                System.Drawing.Color.FromArgb(
                    58,
                    88,
                    138);

            this.panelWarning.Location =
                new System.Drawing.Point(
                    20,
                    355);

            this.panelWarning.Size =
                new System.Drawing.Size(
                    690,
                    45);

            this.lblWarning.ForeColor =
                System.Drawing.Color.White;
            this.lblWarning.Font =
    new System.Drawing.Font(
        "Segoe UI",
        11F,
        System.Drawing.FontStyle.Regular);

            this.lblWarning.AutoSize = true;

            this.lblWarning.Location =
                new System.Drawing.Point(
                    10,
                    10);


            this.lblWarning.Text =
                "Проверьте данные перед завершением регистрации.";

            this.panelWarning.Controls.Add(
                this.lblWarning);


            


            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);

            this.Controls.Add(this.panelPersonal);
            this.Controls.Add(this.panelPassport);

            this.Controls.Add(this.panelContacts);
            this.Controls.Add(this.panelAccount);

            this.Controls.Add(this.panelWarning);


            // ======================================
            // Настройка страницы
            // ======================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.Name =
                "ConfirmationPage";

            this.Size =
                new System.Drawing.Size(
                    770,
                    430);

            ((System.ComponentModel.ISupportInitialize)
                (this.picPersonal)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picPassport)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel panelPersonal;
        private System.Windows.Forms.Panel panelPassport;
        private System.Windows.Forms.Panel panelContacts;
        private System.Windows.Forms.Panel panelAccount;

        private System.Windows.Forms.Panel panelWarning;

        private System.Windows.Forms.PictureBox picPersonal;
        private System.Windows.Forms.PictureBox picPassport;
        private System.Windows.Forms.PictureBox picContacts;
        private System.Windows.Forms.PictureBox picAccount;

        private System.Windows.Forms.Label lblPersonalTitle;
        private System.Windows.Forms.Label lblPassportTitle;
        private System.Windows.Forms.Label lblContactsTitle;
        private System.Windows.Forms.Label lblAccountTitle;

        private System.Windows.Forms.Label lblPersonalData;
        private System.Windows.Forms.Label lblPassportData;
        private System.Windows.Forms.Label lblContactsData;
        private System.Windows.Forms.Label lblAccountData;

        private System.Windows.Forms.Label lblWarning;

        private System.Windows.Forms.Button btnRegister;

        #endregion
    }
}