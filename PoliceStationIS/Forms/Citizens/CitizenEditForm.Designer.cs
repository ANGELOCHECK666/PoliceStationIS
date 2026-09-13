using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Citizens
{
    partial class CitizenEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlMain;
        private Label lblPersonalSection;
        private Panel pnlPersonalLine;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblBirthDate;
        private Label lblGender;
        private Label lblBirthPlace;
        private Label lblCitizenship;
        private Label lblMaritalStatus;
        private Label lblCitizenRole;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private DateTimePicker dtpBirthDate;
        private ComboBox cmbGender;
        private ComboBox cmbBirthPlace;
        private ComboBox cmbCitizenship;
        private ComboBox cmbMaritalStatus;
        private ComboBox cmbCitizenRole;

        private Label lblPassportSection;
        private Panel pnlPassportLine;
        private Label lblPassportSeries;
        private Label lblPassportNumber;
        private Label lblPassportIssueDate;
        private Label lblPassportIssuance;
        private Label lblPhone;
        private Label lblEmail;
        private TextBox txtPassportSeries;
        private TextBox txtPassportNumber;
        private DateTimePicker dtpPassportIssueDate;
        private ComboBox cmbPassportIssuance;
        private TextBox txtPhone;
        private TextBox txtEmail;

        private Label lblAddressSection;
        private Panel pnlAddressLine;
        private Label lblRegistrationAddress;
        private Label lblResidentialAddress;
        private Label lblDistinguishingFeatures;
        private TextBox txtRegistrationAddress;
        private TextBox txtResidentialAddress;
        private TextBox txtDistinguishingFeatures;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlMain = new Panel();

            lblPersonalSection = new Label();
            pnlPersonalLine = new Panel();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblMiddleName = new Label();
            lblBirthDate = new Label();
            lblGender = new Label();
            lblBirthPlace = new Label();
            lblCitizenship = new Label();
            lblMaritalStatus = new Label();
            lblCitizenRole = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cmbGender = new ComboBox();
            cmbBirthPlace = new ComboBox();
            cmbCitizenship = new ComboBox();
            cmbMaritalStatus = new ComboBox();
            cmbCitizenRole = new ComboBox();

            lblPassportSection = new Label();
            pnlPassportLine = new Panel();
            lblPassportSeries = new Label();
            lblPassportNumber = new Label();
            lblPassportIssueDate = new Label();
            lblPassportIssuance = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            txtPassportSeries = new TextBox();
            txtPassportNumber = new TextBox();
            dtpPassportIssueDate = new DateTimePicker();
            cmbPassportIssuance = new ComboBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();

            lblAddressSection = new Label();
            pnlAddressLine = new Panel();
            lblRegistrationAddress = new Label();
            lblResidentialAddress = new Label();
            lblDistinguishingFeatures = new Label();
            txtRegistrationAddress = new TextBox();
            txtResidentialAddress = new TextBox();
            txtDistinguishingFeatures = new TextBox();

            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            BackColor = Color.FromArgb(5, 24, 58);
            ClientSize = new Size(900, 900);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            Text = "Добавление гражданина";
            Name = "CitizenEditForm";

            lblTitle.Text = "Добавление гражданина";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(28, 20);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "Заполнение персональных, паспортных и контактных данных";
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.Gainsboro;
            lblSubtitle.Location = new Point(30, 57);
            lblSubtitle.AutoSize = true;

            pnlMain.BackColor = Color.FromArgb(18, 38, 74);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(20, 92);
            pnlMain.Size = new Size(860, 790);

            lblPersonalSection.Text = "ПЕРСОНАЛЬНЫЕ ДАННЫЕ";
            lblPersonalSection.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPersonalSection.ForeColor = Color.FromArgb(212, 160, 23);
            lblPersonalSection.Location = new Point(20, 12);
            lblPersonalSection.AutoSize = true;

            pnlPersonalLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlPersonalLine.Location = new Point(20, 39);
            pnlPersonalLine.Size = new Size(820, 1);

            ConfigureLabel(lblLastName, "Фамилия", 22, 52);
            ConfigureTextBox(txtLastName, 22, 75, 250);
            ConfigureLabel(lblFirstName, "Имя", 294, 52);
            ConfigureTextBox(txtFirstName, 294, 75, 250);
            ConfigureLabel(lblMiddleName, "Отчество", 566, 52);
            ConfigureTextBox(txtMiddleName, 566, 75, 250);

            ConfigureLabel(lblBirthDate, "Дата рождения", 22, 112);
            ConfigureDate(dtpBirthDate, 22, 135, 180);
            ConfigureLabel(lblGender, "Пол", 222, 112);
            ConfigureCombo(cmbGender, 222, 135, 180);
            ConfigureLabel(lblBirthPlace, "Место рождения", 422, 112);
            ConfigureCombo(cmbBirthPlace, 422, 135, 394);

            ConfigureLabel(lblCitizenship, "Гражданство", 22, 175);
            ConfigureCombo(cmbCitizenship, 22, 198, 250);
            ConfigureLabel(lblMaritalStatus, "Семейное положение", 294, 175);
            ConfigureCombo(cmbMaritalStatus, 294, 198, 250);
            ConfigureLabel(lblCitizenRole, "Роль гражданина", 566, 175);
            ConfigureCombo(cmbCitizenRole, 566, 198, 250);

            lblPassportSection.Text = "ПАСПОРТ И КОНТАКТЫ";
            lblPassportSection.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassportSection.ForeColor = Color.FromArgb(212, 160, 23);
            lblPassportSection.Location = new Point(20, 242);
            lblPassportSection.AutoSize = true;

            pnlPassportLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlPassportLine.Location = new Point(20, 269);
            pnlPassportLine.Size = new Size(820, 1);

            ConfigureLabel(lblPassportSeries, "Серия паспорта", 22, 282);
            ConfigureTextBox(txtPassportSeries, 22, 305, 180);
            ConfigureLabel(lblPassportNumber, "Номер паспорта", 222, 282);
            ConfigureTextBox(txtPassportNumber, 222, 305, 180);
            ConfigureLabel(lblPassportIssueDate, "Дата выдачи", 422, 282);
            ConfigureDate(dtpPassportIssueDate, 422, 305, 180);
            ConfigureLabel(lblPassportIssuance, "Кем выдан", 622, 282);
            ConfigureCombo(cmbPassportIssuance, 622, 305, 194);

            ConfigureLabel(lblPhone, "Номер телефона", 22, 342);
            ConfigureTextBox(txtPhone, 22, 365, 250);
            ConfigureLabel(lblEmail, "Электронная почта", 294, 342);
            ConfigureTextBox(txtEmail, 294, 365, 522);

            lblAddressSection.Text = "АДРЕС И ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ";
            lblAddressSection.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAddressSection.ForeColor = Color.FromArgb(212, 160, 23);
            lblAddressSection.Location = new Point(20, 402);
            lblAddressSection.AutoSize = true;

            pnlAddressLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlAddressLine.Location = new Point(20, 429);
            pnlAddressLine.Size = new Size(820, 1);

            ConfigureLabel(lblRegistrationAddress, "Адрес регистрации", 22, 442);
            ConfigureTextBox(txtRegistrationAddress, 22, 465, 794);

            ConfigureLabel(lblResidentialAddress, "Адрес проживания", 22, 502);
            ConfigureMultiline(txtResidentialAddress, 22, 525, 794, 55);

            ConfigureLabel(lblDistinguishingFeatures, "Особые приметы", 22, 597);
            ConfigureMultiline(txtDistinguishingFeatures, 22, 620, 794, 78);

            ConfigureButton(btnSave);
            btnSave.Text = "Сохранить";
            btnSave.Location = new Point(550, 735);
            btnSave.Size = new Size(128, 38);

            ConfigureButton(btnCancel);
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(688, 735);
            btnCancel.Size = new Size(128, 38);

            pnlMain.Controls.AddRange(new Control[]
            {
                lblPersonalSection, pnlPersonalLine,
                lblLastName, txtLastName,
                lblFirstName, txtFirstName,
                lblMiddleName, txtMiddleName,
                lblBirthDate, dtpBirthDate,
                lblGender, cmbGender,
                lblBirthPlace, cmbBirthPlace,
                lblCitizenship, cmbCitizenship,
                lblMaritalStatus, cmbMaritalStatus,
                lblCitizenRole, cmbCitizenRole,

                lblPassportSection, pnlPassportLine,
                lblPassportSeries, txtPassportSeries,
                lblPassportNumber, txtPassportNumber,
                lblPassportIssueDate, dtpPassportIssueDate,
                lblPassportIssuance, cmbPassportIssuance,
                lblPhone, txtPhone,
                lblEmail, txtEmail,

                lblAddressSection, pnlAddressLine,
                lblRegistrationAddress, txtRegistrationAddress,
                lblResidentialAddress, txtResidentialAddress,
                lblDistinguishingFeatures, txtDistinguishingFeatures,
                btnSave, btnCancel
            });

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(pnlMain);

            ResumeLayout(false);
        }

        private void ConfigureLabel(Label label, string text, int x, int y)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 9F);
            label.ForeColor = Color.Gainsboro;
            label.Location = new Point(x, y);
            label.AutoSize = true;
        }

        private void ConfigureTextBox(TextBox box, int x, int y, int width)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(width, 27);
            box.BackColor = Color.FromArgb(30, 58, 117);
            box.ForeColor = Color.White;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureMultiline(TextBox box, int x, int y, int width, int height)
        {
            ConfigureTextBox(box, x, y, width);
            box.Size = new Size(width, height);
            box.Multiline = true;
            box.ScrollBars = ScrollBars.Vertical;
        }

        private void ConfigureCombo(ComboBox box, int x, int y, int width)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(width, 27);
        }

        private void ConfigureDate(DateTimePicker picker, int x, int y, int width)
        {
            picker.Location = new Point(x, y);
            picker.Size = new Size(width, 27);
            picker.Format = DateTimePickerFormat.Short;
            picker.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 160, 23);
            button.BackColor = Color.FromArgb(42, 73, 133);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }
    }
}