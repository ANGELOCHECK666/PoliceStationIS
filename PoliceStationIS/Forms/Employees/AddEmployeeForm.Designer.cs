using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace PoliceStationIS.Forms.Employees
{
    partial class AddEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Panel pnlTopBar;
        private Panel pnlContent;

        private PictureBox picTitleIcon;
        private Label lblTitle;
        private Button btnClose;

        // Личные данные

        private Label lblPersonalData;
        private Panel pnlPersonalLine;

        private Label lblLastName;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblSex;
        private Label lblBirthDate;
        private Label lblMaritalStatus;
        private Label lblPhone;

        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtPhone;

        private ComboBox cmbSex;
        private ComboBox cmbMaritalStatus;

        private DateTimePicker dtpBirthDate;

        private Label lblPassportData;
        private Panel pnlPassportLine;

        private Label lblPassportSeries;
        private Label lblPassportNumber;
        private Label lblIssueDate;
        private Label lblPassportIssuedBy;

        private TextBox txtPassportSeries;
        private TextBox txtPassportNumber;

        private DateTimePicker dtpIssueDate;

        private ComboBox cmbPassportIssuedBy;

        private Label lblRegistrationAddress;
        private Label lblResidentialAddress;

        private TextBox txtRegistrationAddress;
        private TextBox txtResidentialAddress;

        private Label lblServiceData;
        private Panel pnlServiceLine;

        private Label lblDepartment;
        private Label lblPost;
        private Label lblRank;
        private Label lblEmploymentStatus;
        private Label lblServiceStartDate;

        private ComboBox cmbDepartment;
        private ComboBox cmbPost;
        private ComboBox cmbRank;
        private ComboBox cmbEmploymentStatus;

        private DateTimePicker dtpServiceStartDate;

        private Label lblMilitaryData;
        private Panel pnlMilitaryLine;

        private Label lblMilitaryCategory;
        private Label lblMilitarySeries;
        private Label lblMilitaryNumber;

        private ComboBox cmbMilitaryCategory;

        private TextBox txtMilitarySeries;
        private TextBox txtMilitaryNumber;

        private Label lblAdditionalData;
        private Panel pnlAdditionalLine;

        private Label lblHeight;
        private Label lblWeight;

        private TextBox txtHeight;
        private TextBox txtWeight;

        private CheckBox chkCriminalRecord;

        private Label lblLicenseSeries;
        private Label lblLicenseNumber;
        private Label lblLicenseValidity;

        private TextBox txtLicenseSeries;
        private TextBox txtLicenseNumber;

        private DateTimePicker dtpLicenseValidity;

        private Label lblTokenSeries;
        private Label lblTokenNumber;

        private TextBox txtTokenSeries;
        private TextBox txtTokenNumber;

        private Label lblAccountData;
        private Panel pnlAccountLine;

        private Label lblLogin;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblUserRole;

        private TextBox txtLogin;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;

        private ComboBox cmbUserRole;

        private Button btnSave;
        private Button btnCancel;

        private Label lblBottomSpace;



        private void InitializeComponent()
        {
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.picTitleIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblPersonalData = new System.Windows.Forms.Label();
            this.pnlPersonalLine = new System.Windows.Forms.Panel();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPassportData = new System.Windows.Forms.Label();
            this.pnlPassportLine = new System.Windows.Forms.Panel();
            this.lblPassportSeries = new System.Windows.Forms.Label();
            this.txtPassportSeries = new System.Windows.Forms.TextBox();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.txtPassportNumber = new System.Windows.Forms.TextBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblPassportIssuedBy = new System.Windows.Forms.Label();
            this.cmbPassportIssuedBy = new System.Windows.Forms.ComboBox();
            this.lblRegistrationAddress = new System.Windows.Forms.Label();
            this.txtRegistrationAddress = new System.Windows.Forms.TextBox();
            this.lblResidentialAddress = new System.Windows.Forms.Label();
            this.txtResidentialAddress = new System.Windows.Forms.TextBox();
            this.lblServiceData = new System.Windows.Forms.Label();
            this.pnlServiceLine = new System.Windows.Forms.Panel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblPost = new System.Windows.Forms.Label();
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.lblRank = new System.Windows.Forms.Label();
            this.cmbRank = new System.Windows.Forms.ComboBox();
            this.lblEmploymentStatus = new System.Windows.Forms.Label();
            this.cmbEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.lblServiceStartDate = new System.Windows.Forms.Label();
            this.dtpServiceStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblMilitaryData = new System.Windows.Forms.Label();
            this.pnlMilitaryLine = new System.Windows.Forms.Panel();
            this.lblMilitaryCategory = new System.Windows.Forms.Label();
            this.cmbMilitaryCategory = new System.Windows.Forms.ComboBox();
            this.lblMilitarySeries = new System.Windows.Forms.Label();
            this.txtMilitarySeries = new System.Windows.Forms.TextBox();
            this.lblMilitaryNumber = new System.Windows.Forms.Label();
            this.txtMilitaryNumber = new System.Windows.Forms.TextBox();
            this.lblAdditionalData = new System.Windows.Forms.Label();
            this.pnlAdditionalLine = new System.Windows.Forms.Panel();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.chkCriminalRecord = new System.Windows.Forms.CheckBox();
            this.lblLicenseSeries = new System.Windows.Forms.Label();
            this.txtLicenseSeries = new System.Windows.Forms.TextBox();
            this.lblLicenseNumber = new System.Windows.Forms.Label();
            this.txtLicenseNumber = new System.Windows.Forms.TextBox();
            this.lblLicenseValidity = new System.Windows.Forms.Label();
            this.dtpLicenseValidity = new System.Windows.Forms.DateTimePicker();
            this.lblTokenSeries = new System.Windows.Forms.Label();
            this.txtTokenSeries = new System.Windows.Forms.TextBox();
            this.lblTokenNumber = new System.Windows.Forms.Label();
            this.txtTokenNumber = new System.Windows.Forms.TextBox();
            this.lblAccountData = new System.Windows.Forms.Label();
            this.pnlAccountLine = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBottomSpace = new System.Windows.Forms.Label();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.pnlTopBar.Controls.Add(this.picTitleIcon);
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(5);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1360, 100);
            this.pnlTopBar.TabIndex = 1;
            // 
            // picTitleIcon
            // 
            this.picTitleIcon.BackColor = System.Drawing.Color.Transparent;
            this.picTitleIcon.Image = global::PoliceStationIS.Properties.Resources.employee_add_gold_icon;
            this.picTitleIcon.Location = new System.Drawing.Point(34, 23);
            this.picTitleIcon.Margin = new System.Windows.Forms.Padding(5);
            this.picTitleIcon.Name = "picTitleIcon";
            this.picTitleIcon.Size = new System.Drawing.Size(72, 70);
            this.picTitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitleIcon.TabIndex = 0;
            this.picTitleIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 27);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(536, 59);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Добавление сотрудника";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1270, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 75);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.pnlContent.Controls.Add(this.lblPersonalData);
            this.pnlContent.Controls.Add(this.pnlPersonalLine);
            this.pnlContent.Controls.Add(this.lblLastName);
            this.pnlContent.Controls.Add(this.txtLastName);
            this.pnlContent.Controls.Add(this.lblFirstName);
            this.pnlContent.Controls.Add(this.txtFirstName);
            this.pnlContent.Controls.Add(this.lblMiddleName);
            this.pnlContent.Controls.Add(this.txtMiddleName);
            this.pnlContent.Controls.Add(this.lblSex);
            this.pnlContent.Controls.Add(this.cmbSex);
            this.pnlContent.Controls.Add(this.lblBirthDate);
            this.pnlContent.Controls.Add(this.dtpBirthDate);
            this.pnlContent.Controls.Add(this.lblMaritalStatus);
            this.pnlContent.Controls.Add(this.cmbMaritalStatus);
            this.pnlContent.Controls.Add(this.lblPhone);
            this.pnlContent.Controls.Add(this.txtPhone);
            this.pnlContent.Controls.Add(this.lblPassportData);
            this.pnlContent.Controls.Add(this.pnlPassportLine);
            this.pnlContent.Controls.Add(this.lblPassportSeries);
            this.pnlContent.Controls.Add(this.txtPassportSeries);
            this.pnlContent.Controls.Add(this.lblPassportNumber);
            this.pnlContent.Controls.Add(this.txtPassportNumber);
            this.pnlContent.Controls.Add(this.lblIssueDate);
            this.pnlContent.Controls.Add(this.dtpIssueDate);
            this.pnlContent.Controls.Add(this.lblPassportIssuedBy);
            this.pnlContent.Controls.Add(this.cmbPassportIssuedBy);
            this.pnlContent.Controls.Add(this.lblRegistrationAddress);
            this.pnlContent.Controls.Add(this.txtRegistrationAddress);
            this.pnlContent.Controls.Add(this.lblResidentialAddress);
            this.pnlContent.Controls.Add(this.txtResidentialAddress);
            this.pnlContent.Controls.Add(this.lblServiceData);
            this.pnlContent.Controls.Add(this.pnlServiceLine);
            this.pnlContent.Controls.Add(this.lblDepartment);
            this.pnlContent.Controls.Add(this.cmbDepartment);
            this.pnlContent.Controls.Add(this.lblPost);
            this.pnlContent.Controls.Add(this.cmbPost);
            this.pnlContent.Controls.Add(this.lblRank);
            this.pnlContent.Controls.Add(this.cmbRank);
            this.pnlContent.Controls.Add(this.lblEmploymentStatus);
            this.pnlContent.Controls.Add(this.cmbEmploymentStatus);
            this.pnlContent.Controls.Add(this.lblServiceStartDate);
            this.pnlContent.Controls.Add(this.dtpServiceStartDate);
            this.pnlContent.Controls.Add(this.lblMilitaryData);
            this.pnlContent.Controls.Add(this.pnlMilitaryLine);
            this.pnlContent.Controls.Add(this.lblMilitaryCategory);
            this.pnlContent.Controls.Add(this.cmbMilitaryCategory);
            this.pnlContent.Controls.Add(this.lblMilitarySeries);
            this.pnlContent.Controls.Add(this.txtMilitarySeries);
            this.pnlContent.Controls.Add(this.lblMilitaryNumber);
            this.pnlContent.Controls.Add(this.txtMilitaryNumber);
            this.pnlContent.Controls.Add(this.lblAdditionalData);
            this.pnlContent.Controls.Add(this.pnlAdditionalLine);
            this.pnlContent.Controls.Add(this.lblHeight);
            this.pnlContent.Controls.Add(this.txtHeight);
            this.pnlContent.Controls.Add(this.lblWeight);
            this.pnlContent.Controls.Add(this.txtWeight);
            this.pnlContent.Controls.Add(this.chkCriminalRecord);
            this.pnlContent.Controls.Add(this.lblLicenseSeries);
            this.pnlContent.Controls.Add(this.txtLicenseSeries);
            this.pnlContent.Controls.Add(this.lblLicenseNumber);
            this.pnlContent.Controls.Add(this.txtLicenseNumber);
            this.pnlContent.Controls.Add(this.lblLicenseValidity);
            this.pnlContent.Controls.Add(this.dtpLicenseValidity);
            this.pnlContent.Controls.Add(this.lblTokenSeries);
            this.pnlContent.Controls.Add(this.txtTokenSeries);
            this.pnlContent.Controls.Add(this.lblTokenNumber);
            this.pnlContent.Controls.Add(this.txtTokenNumber);
            this.pnlContent.Controls.Add(this.lblAccountData);
            this.pnlContent.Controls.Add(this.pnlAccountLine);
            this.pnlContent.Controls.Add(this.lblLogin);
            this.pnlContent.Controls.Add(this.txtLogin);
            this.pnlContent.Controls.Add(this.lblEmail);
            this.pnlContent.Controls.Add(this.txtEmail);
            this.pnlContent.Controls.Add(this.lblPassword);
            this.pnlContent.Controls.Add(this.txtPassword);
            this.pnlContent.Controls.Add(this.lblConfirmPassword);
            this.pnlContent.Controls.Add(this.txtConfirmPassword);
            this.pnlContent.Controls.Add(this.lblUserRole);
            this.pnlContent.Controls.Add(this.cmbUserRole);
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Controls.Add(this.lblBottomSpace);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 100);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(5);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1360, 1150);
            this.pnlContent.TabIndex = 0;
            // 
            // lblPersonalData
            // 
            this.lblPersonalData.AutoSize = true;
            this.lblPersonalData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPersonalData.ForeColor = System.Drawing.Color.White;
            this.lblPersonalData.Location = new System.Drawing.Point(69, 50);
            this.lblPersonalData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPersonalData.Name = "lblPersonalData";
            this.lblPersonalData.Size = new System.Drawing.Size(274, 45);
            this.lblPersonalData.TabIndex = 0;
            this.lblPersonalData.Text = "Личные данные";
            // 
            // pnlPersonalLine
            // 
            this.pnlPersonalLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlPersonalLine.Location = new System.Drawing.Point(69, 100);
            this.pnlPersonalLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPersonalLine.Name = "pnlPersonalLine";
            this.pnlPersonalLine.Size = new System.Drawing.Size(291, 3);
            this.pnlPersonalLine.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(64, 150);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(118, 25);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Фамилия *";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(69, 192);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(404, 31);
            this.txtLastName.TabIndex = 3;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(68, 246);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(53, 25);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "Имя";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(73, 288);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(5);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(400, 31);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.ForeColor = System.Drawing.Color.White;
            this.lblMiddleName.Location = new System.Drawing.Point(68, 345);
            this.lblMiddleName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(105, 25);
            this.lblMiddleName.TabIndex = 6;
            this.lblMiddleName.Text = "Отчество";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.ForeColor = System.Drawing.Color.White;
            this.txtMiddleName.Location = new System.Drawing.Point(69, 387);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(5);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(404, 31);
            this.txtMiddleName.TabIndex = 7;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.ForeColor = System.Drawing.Color.White;
            this.lblSex.Location = new System.Drawing.Point(528, 150);
            this.lblSex.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(65, 25);
            this.lblSex.TabIndex = 8;
            this.lblSex.Text = "Пол *";
            // 
            // cmbSex
            // 
            this.cmbSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSex.ForeColor = System.Drawing.Color.White;
            this.cmbSex.Location = new System.Drawing.Point(531, 190);
            this.cmbSex.Margin = new System.Windows.Forms.Padding(5);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(251, 33);
            this.cmbSex.TabIndex = 9;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.ForeColor = System.Drawing.Color.White;
            this.lblBirthDate.Location = new System.Drawing.Point(866, 356);
            this.lblBirthDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(180, 25);
            this.lblBirthDate.TabIndex = 10;
            this.lblBirthDate.Text = "Дата рождения *";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(866, 395);
            this.dtpBirthDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(282, 31);
            this.dtpBirthDate.TabIndex = 11;
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.ForeColor = System.Drawing.Color.White;
            this.lblMaritalStatus.Location = new System.Drawing.Point(531, 355);
            this.lblMaritalStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(245, 25);
            this.lblMaritalStatus.TabIndex = 12;
            this.lblMaritalStatus.Text = "Семейное положение *";
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbMaritalStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMaritalStatus.ForeColor = System.Drawing.Color.White;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(531, 396);
            this.cmbMaritalStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(291, 33);
            this.cmbMaritalStatus.TabIndex = 13;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(531, 246);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(116, 25);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Телефон *";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(531, 288);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(321, 31);
            this.txtPhone.TabIndex = 15;
            // 
            // lblPassportData
            // 
            this.lblPassportData.AutoSize = true;
            this.lblPassportData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPassportData.ForeColor = System.Drawing.Color.White;
            this.lblPassportData.Location = new System.Drawing.Point(60, 468);
            this.lblPassportData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassportData.Name = "lblPassportData";
            this.lblPassportData.Size = new System.Drawing.Size(343, 45);
            this.lblPassportData.TabIndex = 16;
            this.lblPassportData.Text = "Паспортные данные";
            // 
            // pnlPassportLine
            // 
            this.pnlPassportLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlPassportLine.Location = new System.Drawing.Point(66, 529);
            this.pnlPassportLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlPassportLine.Name = "pnlPassportLine";
            this.pnlPassportLine.Size = new System.Drawing.Size(377, 3);
            this.pnlPassportLine.TabIndex = 17;
            // 
            // lblPassportSeries
            // 
            this.lblPassportSeries.AutoSize = true;
            this.lblPassportSeries.ForeColor = System.Drawing.Color.White;
            this.lblPassportSeries.Location = new System.Drawing.Point(74, 585);
            this.lblPassportSeries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassportSeries.Name = "lblPassportSeries";
            this.lblPassportSeries.Size = new System.Drawing.Size(187, 25);
            this.lblPassportSeries.TabIndex = 18;
            this.lblPassportSeries.Text = "Серия паспорта *";
            // 
            // txtPassportSeries
            // 
            this.txtPassportSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtPassportSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassportSeries.ForeColor = System.Drawing.Color.White;
            this.txtPassportSeries.Location = new System.Drawing.Point(74, 626);
            this.txtPassportSeries.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassportSeries.Name = "txtPassportSeries";
            this.txtPassportSeries.Size = new System.Drawing.Size(187, 31);
            this.txtPassportSeries.TabIndex = 19;
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.ForeColor = System.Drawing.Color.White;
            this.lblPassportNumber.Location = new System.Drawing.Point(315, 585);
            this.lblPassportNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(191, 25);
            this.lblPassportNumber.TabIndex = 20;
            this.lblPassportNumber.Text = "Номер паспорта *";
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtPassportNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassportNumber.ForeColor = System.Drawing.Color.White;
            this.txtPassportNumber.Location = new System.Drawing.Point(315, 626);
            this.txtPassportNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(175, 31);
            this.txtPassportNumber.TabIndex = 21;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.ForeColor = System.Drawing.Color.White;
            this.lblIssueDate.Location = new System.Drawing.Point(73, 703);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(155, 25);
            this.lblIssueDate.TabIndex = 22;
            this.lblIssueDate.Text = "Дата выдачи *";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Location = new System.Drawing.Point(73, 744);
            this.dtpIssueDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(270, 31);
            this.dtpIssueDate.TabIndex = 23;
            // 
            // lblPassportIssuedBy
            // 
            this.lblPassportIssuedBy.AutoSize = true;
            this.lblPassportIssuedBy.ForeColor = System.Drawing.Color.White;
            this.lblPassportIssuedBy.Location = new System.Drawing.Point(532, 574);
            this.lblPassportIssuedBy.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassportIssuedBy.Name = "lblPassportIssuedBy";
            this.lblPassportIssuedBy.Size = new System.Drawing.Size(135, 25);
            this.lblPassportIssuedBy.TabIndex = 24;
            this.lblPassportIssuedBy.Text = "Кем выдан *";
            // 
            // cmbPassportIssuedBy
            // 
            this.cmbPassportIssuedBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbPassportIssuedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPassportIssuedBy.ForeColor = System.Drawing.Color.White;
            this.cmbPassportIssuedBy.Location = new System.Drawing.Point(536, 624);
            this.cmbPassportIssuedBy.Margin = new System.Windows.Forms.Padding(5);
            this.cmbPassportIssuedBy.Name = "cmbPassportIssuedBy";
            this.cmbPassportIssuedBy.Size = new System.Drawing.Size(612, 33);
            this.cmbPassportIssuedBy.TabIndex = 25;
            // 
            // lblRegistrationAddress
            // 
            this.lblRegistrationAddress.AutoSize = true;
            this.lblRegistrationAddress.ForeColor = System.Drawing.Color.White;
            this.lblRegistrationAddress.Location = new System.Drawing.Point(390, 701);
            this.lblRegistrationAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRegistrationAddress.Name = "lblRegistrationAddress";
            this.lblRegistrationAddress.Size = new System.Drawing.Size(218, 25);
            this.lblRegistrationAddress.TabIndex = 26;
            this.lblRegistrationAddress.Text = "Адрес регистрации *";
            // 
            // txtRegistrationAddress
            // 
            this.txtRegistrationAddress.AcceptsReturn = true;
            this.txtRegistrationAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtRegistrationAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegistrationAddress.ForeColor = System.Drawing.Color.White;
            this.txtRegistrationAddress.Location = new System.Drawing.Point(390, 743);
            this.txtRegistrationAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtRegistrationAddress.Multiline = true;
            this.txtRegistrationAddress.Name = "txtRegistrationAddress";
            this.txtRegistrationAddress.Size = new System.Drawing.Size(343, 111);
            this.txtRegistrationAddress.TabIndex = 27;
            // 
            // lblResidentialAddress
            // 
            this.lblResidentialAddress.AutoSize = true;
            this.lblResidentialAddress.ForeColor = System.Drawing.Color.White;
            this.lblResidentialAddress.Location = new System.Drawing.Point(771, 702);
            this.lblResidentialAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblResidentialAddress.Name = "lblResidentialAddress";
            this.lblResidentialAddress.Size = new System.Drawing.Size(200, 25);
            this.lblResidentialAddress.TabIndex = 28;
            this.lblResidentialAddress.Text = "Адрес проживания";
            // 
            // txtResidentialAddress
            // 
            this.txtResidentialAddress.AcceptsReturn = true;
            this.txtResidentialAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtResidentialAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResidentialAddress.ForeColor = System.Drawing.Color.White;
            this.txtResidentialAddress.Location = new System.Drawing.Point(771, 743);
            this.txtResidentialAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtResidentialAddress.Multiline = true;
            this.txtResidentialAddress.Name = "txtResidentialAddress";
            this.txtResidentialAddress.Size = new System.Drawing.Size(378, 111);
            this.txtResidentialAddress.TabIndex = 29;
            // 
            // lblServiceData
            // 
            this.lblServiceData.AutoSize = true;
            this.lblServiceData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblServiceData.ForeColor = System.Drawing.Color.White;
            this.lblServiceData.Location = new System.Drawing.Point(62, 949);
            this.lblServiceData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblServiceData.Name = "lblServiceData";
            this.lblServiceData.Size = new System.Drawing.Size(330, 45);
            this.lblServiceData.TabIndex = 30;
            this.lblServiceData.Text = "Служебные данные";
            // 
            // pnlServiceLine
            // 
            this.pnlServiceLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlServiceLine.Location = new System.Drawing.Point(62, 999);
            this.pnlServiceLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlServiceLine.Name = "pnlServiceLine";
            this.pnlServiceLine.Size = new System.Drawing.Size(309, 3);
            this.pnlServiceLine.TabIndex = 31;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.White;
            this.lblDepartment.Location = new System.Drawing.Point(62, 1049);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(88, 25);
            this.lblDepartment.TabIndex = 32;
            this.lblDepartment.Text = "Отдел *";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartment.ForeColor = System.Drawing.Color.White;
            this.cmbDepartment.Location = new System.Drawing.Point(62, 1091);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(5);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(514, 33);
            this.cmbDepartment.TabIndex = 33;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.ForeColor = System.Drawing.Color.White;
            this.lblPost.Location = new System.Drawing.Point(638, 1049);
            this.lblPost.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(137, 25);
            this.lblPost.TabIndex = 34;
            this.lblPost.Text = "Должность *";
            // 
            // cmbPost
            // 
            this.cmbPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPost.ForeColor = System.Drawing.Color.White;
            this.cmbPost.Location = new System.Drawing.Point(638, 1091);
            this.cmbPost.Margin = new System.Windows.Forms.Padding(5);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(506, 33);
            this.cmbPost.TabIndex = 35;
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.ForeColor = System.Drawing.Color.White;
            this.lblRank.Location = new System.Drawing.Point(425, 1162);
            this.lblRank.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(98, 25);
            this.lblRank.TabIndex = 36;
            this.lblRank.Text = "Звание *";
            // 
            // cmbRank
            // 
            this.cmbRank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRank.ForeColor = System.Drawing.Color.White;
            this.cmbRank.Location = new System.Drawing.Point(425, 1204);
            this.cmbRank.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRank.Name = "cmbRank";
            this.cmbRank.Size = new System.Drawing.Size(367, 33);
            this.cmbRank.TabIndex = 37;
            // 
            // lblEmploymentStatus
            // 
            this.lblEmploymentStatus.AutoSize = true;
            this.lblEmploymentStatus.ForeColor = System.Drawing.Color.White;
            this.lblEmploymentStatus.Location = new System.Drawing.Point(61, 1162);
            this.lblEmploymentStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmploymentStatus.Name = "lblEmploymentStatus";
            this.lblEmploymentStatus.Size = new System.Drawing.Size(216, 25);
            this.lblEmploymentStatus.TabIndex = 38;
            this.lblEmploymentStatus.Text = "Статус сотрудника *";
            // 
            // cmbEmploymentStatus
            // 
            this.cmbEmploymentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbEmploymentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmploymentStatus.ForeColor = System.Drawing.Color.White;
            this.cmbEmploymentStatus.Location = new System.Drawing.Point(61, 1204);
            this.cmbEmploymentStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            this.cmbEmploymentStatus.Size = new System.Drawing.Size(295, 33);
            this.cmbEmploymentStatus.TabIndex = 39;
            // 
            // lblServiceStartDate
            // 
            this.lblServiceStartDate.AutoSize = true;
            this.lblServiceStartDate.ForeColor = System.Drawing.Color.White;
            this.lblServiceStartDate.Location = new System.Drawing.Point(855, 1166);
            this.lblServiceStartDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblServiceStartDate.Name = "lblServiceStartDate";
            this.lblServiceStartDate.Size = new System.Drawing.Size(265, 25);
            this.lblServiceStartDate.TabIndex = 40;
            this.lblServiceStartDate.Text = "Дата приема на службу *";
            // 
            // dtpServiceStartDate
            // 
            this.dtpServiceStartDate.Location = new System.Drawing.Point(855, 1208);
            this.dtpServiceStartDate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpServiceStartDate.Name = "dtpServiceStartDate";
            this.dtpServiceStartDate.Size = new System.Drawing.Size(289, 31);
            this.dtpServiceStartDate.TabIndex = 41;
            // 
            // lblMilitaryData
            // 
            this.lblMilitaryData.AutoSize = true;
            this.lblMilitaryData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMilitaryData.ForeColor = System.Drawing.Color.White;
            this.lblMilitaryData.Location = new System.Drawing.Point(64, 1318);
            this.lblMilitaryData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMilitaryData.Name = "lblMilitaryData";
            this.lblMilitaryData.Size = new System.Drawing.Size(251, 45);
            this.lblMilitaryData.TabIndex = 42;
            this.lblMilitaryData.Text = "Воинский учет";
            // 
            // pnlMilitaryLine
            // 
            this.pnlMilitaryLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlMilitaryLine.Location = new System.Drawing.Point(64, 1368);
            this.pnlMilitaryLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlMilitaryLine.Name = "pnlMilitaryLine";
            this.pnlMilitaryLine.Size = new System.Drawing.Size(240, 3);
            this.pnlMilitaryLine.TabIndex = 43;
            // 
            // lblMilitaryCategory
            // 
            this.lblMilitaryCategory.AutoSize = true;
            this.lblMilitaryCategory.ForeColor = System.Drawing.Color.White;
            this.lblMilitaryCategory.Location = new System.Drawing.Point(64, 1418);
            this.lblMilitaryCategory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMilitaryCategory.Name = "lblMilitaryCategory";
            this.lblMilitaryCategory.Size = new System.Drawing.Size(129, 25);
            this.lblMilitaryCategory.TabIndex = 44;
            this.lblMilitaryCategory.Text = "Категория *";
            // 
            // cmbMilitaryCategory
            // 
            this.cmbMilitaryCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbMilitaryCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMilitaryCategory.ForeColor = System.Drawing.Color.White;
            this.cmbMilitaryCategory.Location = new System.Drawing.Point(64, 1459);
            this.cmbMilitaryCategory.Margin = new System.Windows.Forms.Padding(5);
            this.cmbMilitaryCategory.Name = "cmbMilitaryCategory";
            this.cmbMilitaryCategory.Size = new System.Drawing.Size(213, 33);
            this.cmbMilitaryCategory.TabIndex = 45;
            // 
            // lblMilitarySeries
            // 
            this.lblMilitarySeries.AutoSize = true;
            this.lblMilitarySeries.ForeColor = System.Drawing.Color.White;
            this.lblMilitarySeries.Location = new System.Drawing.Point(322, 1420);
            this.lblMilitarySeries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMilitarySeries.Name = "lblMilitarySeries";
            this.lblMilitarySeries.Size = new System.Drawing.Size(261, 25);
            this.lblMilitarySeries.TabIndex = 46;
            this.lblMilitarySeries.Text = "Серия военного билета *";
            // 
            // txtMilitarySeries
            // 
            this.txtMilitarySeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtMilitarySeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMilitarySeries.ForeColor = System.Drawing.Color.White;
            this.txtMilitarySeries.Location = new System.Drawing.Point(322, 1461);
            this.txtMilitarySeries.Margin = new System.Windows.Forms.Padding(5);
            this.txtMilitarySeries.Name = "txtMilitarySeries";
            this.txtMilitarySeries.Size = new System.Drawing.Size(254, 31);
            this.txtMilitarySeries.TabIndex = 47;
            // 
            // lblMilitaryNumber
            // 
            this.lblMilitaryNumber.AutoSize = true;
            this.lblMilitaryNumber.ForeColor = System.Drawing.Color.White;
            this.lblMilitaryNumber.Location = new System.Drawing.Point(638, 1420);
            this.lblMilitaryNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMilitaryNumber.Name = "lblMilitaryNumber";
            this.lblMilitaryNumber.Size = new System.Drawing.Size(265, 25);
            this.lblMilitaryNumber.TabIndex = 48;
            this.lblMilitaryNumber.Text = "Номер военного билета *";
            // 
            // txtMilitaryNumber
            // 
            this.txtMilitaryNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtMilitaryNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMilitaryNumber.ForeColor = System.Drawing.Color.White;
            this.txtMilitaryNumber.Location = new System.Drawing.Point(638, 1461);
            this.txtMilitaryNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtMilitaryNumber.Name = "txtMilitaryNumber";
            this.txtMilitaryNumber.Size = new System.Drawing.Size(265, 31);
            this.txtMilitaryNumber.TabIndex = 49;
            // 
            // lblAdditionalData
            // 
            this.lblAdditionalData.AutoSize = true;
            this.lblAdditionalData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAdditionalData.ForeColor = System.Drawing.Color.White;
            this.lblAdditionalData.Location = new System.Drawing.Point(61, 1587);
            this.lblAdditionalData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAdditionalData.Name = "lblAdditionalData";
            this.lblAdditionalData.Size = new System.Drawing.Size(503, 45);
            this.lblAdditionalData.TabIndex = 50;
            this.lblAdditionalData.Text = "Дополнительная информация";
            // 
            // pnlAdditionalLine
            // 
            this.pnlAdditionalLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlAdditionalLine.Location = new System.Drawing.Point(61, 1637);
            this.pnlAdditionalLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAdditionalLine.Name = "pnlAdditionalLine";
            this.pnlAdditionalLine.Size = new System.Drawing.Size(411, 3);
            this.pnlAdditionalLine.TabIndex = 51;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.ForeColor = System.Drawing.Color.White;
            this.lblHeight.Location = new System.Drawing.Point(61, 1687);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(119, 25);
            this.lblHeight.TabIndex = 52;
            this.lblHeight.Text = "Рост (см) *";
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeight.ForeColor = System.Drawing.Color.White;
            this.txtHeight.Location = new System.Drawing.Point(61, 1728);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(5);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(154, 31);
            this.txtHeight.TabIndex = 53;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.ForeColor = System.Drawing.Color.White;
            this.lblWeight.Location = new System.Drawing.Point(303, 1687);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(102, 25);
            this.lblWeight.TabIndex = 54;
            this.lblWeight.Text = "Вес (кг) *";
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.ForeColor = System.Drawing.Color.White;
            this.txtWeight.Location = new System.Drawing.Point(303, 1728);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(5);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(157, 31);
            this.txtWeight.TabIndex = 55;
            // 
            // chkCriminalRecord
            // 
            this.chkCriminalRecord.AutoSize = true;
            this.chkCriminalRecord.ForeColor = System.Drawing.Color.White;
            this.chkCriminalRecord.Location = new System.Drawing.Point(943, 1459);
            this.chkCriminalRecord.Margin = new System.Windows.Forms.Padding(5);
            this.chkCriminalRecord.Name = "chkCriminalRecord";
            this.chkCriminalRecord.Size = new System.Drawing.Size(201, 29);
            this.chkCriminalRecord.TabIndex = 56;
            this.chkCriminalRecord.Text = "Есть судимость";
            // 
            // lblLicenseSeries
            // 
            this.lblLicenseSeries.AutoSize = true;
            this.lblLicenseSeries.ForeColor = System.Drawing.Color.White;
            this.lblLicenseSeries.Location = new System.Drawing.Point(61, 1805);
            this.lblLicenseSeries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicenseSeries.Name = "lblLicenseSeries";
            this.lblLicenseSeries.Size = new System.Drawing.Size(121, 25);
            this.lblLicenseSeries.TabIndex = 57;
            this.lblLicenseSeries.Text = "Серия ВУ *";
            // 
            // txtLicenseSeries
            // 
            this.txtLicenseSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtLicenseSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseSeries.ForeColor = System.Drawing.Color.White;
            this.txtLicenseSeries.Location = new System.Drawing.Point(61, 1847);
            this.txtLicenseSeries.Margin = new System.Windows.Forms.Padding(5);
            this.txtLicenseSeries.Name = "txtLicenseSeries";
            this.txtLicenseSeries.Size = new System.Drawing.Size(399, 31);
            this.txtLicenseSeries.TabIndex = 58;
            // 
            // lblLicenseNumber
            // 
            this.lblLicenseNumber.AutoSize = true;
            this.lblLicenseNumber.ForeColor = System.Drawing.Color.White;
            this.lblLicenseNumber.Location = new System.Drawing.Point(61, 1904);
            this.lblLicenseNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicenseNumber.Name = "lblLicenseNumber";
            this.lblLicenseNumber.Size = new System.Drawing.Size(125, 25);
            this.lblLicenseNumber.TabIndex = 59;
            this.lblLicenseNumber.Text = "Номер ВУ *";
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtLicenseNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseNumber.ForeColor = System.Drawing.Color.White;
            this.txtLicenseNumber.Location = new System.Drawing.Point(61, 1946);
            this.txtLicenseNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(399, 31);
            this.txtLicenseNumber.TabIndex = 60;
            // 
            // lblLicenseValidity
            // 
            this.lblLicenseValidity.AutoSize = true;
            this.lblLicenseValidity.ForeColor = System.Drawing.Color.White;
            this.lblLicenseValidity.Location = new System.Drawing.Point(61, 2013);
            this.lblLicenseValidity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicenseValidity.Name = "lblLicenseValidity";
            this.lblLicenseValidity.Size = new System.Drawing.Size(206, 25);
            this.lblLicenseValidity.TabIndex = 61;
            this.lblLicenseValidity.Text = "Срок действия ВУ *";
            // 
            // dtpLicenseValidity
            // 
            this.dtpLicenseValidity.Location = new System.Drawing.Point(61, 2055);
            this.dtpLicenseValidity.Margin = new System.Windows.Forms.Padding(5);
            this.dtpLicenseValidity.Name = "dtpLicenseValidity";
            this.dtpLicenseValidity.Size = new System.Drawing.Size(293, 31);
            this.dtpLicenseValidity.TabIndex = 62;
            // 
            // lblTokenSeries
            // 
            this.lblTokenSeries.AutoSize = true;
            this.lblTokenSeries.ForeColor = System.Drawing.Color.White;
            this.lblTokenSeries.Location = new System.Drawing.Point(551, 1807);
            this.lblTokenSeries.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTokenSeries.Name = "lblTokenSeries";
            this.lblTokenSeries.Size = new System.Drawing.Size(167, 25);
            this.lblTokenSeries.TabIndex = 63;
            this.lblTokenSeries.Text = "Серия жетона *";
            // 
            // txtTokenSeries
            // 
            this.txtTokenSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtTokenSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokenSeries.ForeColor = System.Drawing.Color.White;
            this.txtTokenSeries.Location = new System.Drawing.Point(551, 1849);
            this.txtTokenSeries.Margin = new System.Windows.Forms.Padding(5);
            this.txtTokenSeries.Name = "txtTokenSeries";
            this.txtTokenSeries.Size = new System.Drawing.Size(343, 31);
            this.txtTokenSeries.TabIndex = 64;
            // 
            // lblTokenNumber
            // 
            this.lblTokenNumber.AutoSize = true;
            this.lblTokenNumber.ForeColor = System.Drawing.Color.White;
            this.lblTokenNumber.Location = new System.Drawing.Point(551, 1906);
            this.lblTokenNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTokenNumber.Name = "lblTokenNumber";
            this.lblTokenNumber.Size = new System.Drawing.Size(171, 25);
            this.lblTokenNumber.TabIndex = 65;
            this.lblTokenNumber.Text = "Номер жетона *";
            // 
            // txtTokenNumber
            // 
            this.txtTokenNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtTokenNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTokenNumber.ForeColor = System.Drawing.Color.White;
            this.txtTokenNumber.Location = new System.Drawing.Point(551, 1948);
            this.txtTokenNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtTokenNumber.Name = "txtTokenNumber";
            this.txtTokenNumber.Size = new System.Drawing.Size(343, 31);
            this.txtTokenNumber.TabIndex = 66;
            // 
            // lblAccountData
            // 
            this.lblAccountData.AutoSize = true;
            this.lblAccountData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccountData.ForeColor = System.Drawing.Color.White;
            this.lblAccountData.Location = new System.Drawing.Point(62, 2161);
            this.lblAccountData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAccountData.Name = "lblAccountData";
            this.lblAccountData.Size = new System.Drawing.Size(260, 45);
            this.lblAccountData.TabIndex = 67;
            this.lblAccountData.Text = "Учетная запись";
            // 
            // pnlAccountLine
            // 
            this.pnlAccountLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.pnlAccountLine.Location = new System.Drawing.Point(62, 2211);
            this.pnlAccountLine.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAccountLine.Name = "pnlAccountLine";
            this.pnlAccountLine.Size = new System.Drawing.Size(257, 3);
            this.pnlAccountLine.TabIndex = 68;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(62, 2261);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(85, 25);
            this.lblLogin.TabIndex = 69;
            this.lblLogin.Text = "Логин *";
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtLogin.ForeColor = System.Drawing.Color.White;
            this.txtLogin.Location = new System.Drawing.Point(62, 2303);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(5);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(365, 31);
            this.txtLogin.TabIndex = 70;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(59, 2378);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(79, 25);
            this.lblEmail.TabIndex = 71;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(59, 2420);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(511, 31);
            this.txtEmail.TabIndex = 72;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(470, 2262);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 25);
            this.lblPassword.TabIndex = 73;
            this.lblPassword.Text = "Пароль *";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(475, 2305);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(340, 31);
            this.txtPassword.TabIndex = 74;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.lblConfirmPassword.Location = new System.Drawing.Point(863, 2262);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(262, 25);
            this.lblConfirmPassword.TabIndex = 75;
            this.lblConfirmPassword.Text = "Подтверждение пароля *";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Location = new System.Drawing.Point(863, 2304);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(335, 31);
            this.txtConfirmPassword.TabIndex = 76;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.ForeColor = System.Drawing.Color.White;
            this.lblUserRole.Location = new System.Drawing.Point(645, 2376);
            this.lblUserRole.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(75, 25);
            this.lblUserRole.TabIndex = 77;
            this.lblUserRole.Text = "Роль *";
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(133)))));
            this.cmbUserRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserRole.ForeColor = System.Drawing.Color.White;
            this.cmbUserRole.Location = new System.Drawing.Point(645, 2418);
            this.cmbUserRole.Margin = new System.Windows.Forms.Padding(5);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(511, 33);
            this.cmbUserRole.TabIndex = 78;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(607, 2551);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(268, 75);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(931, 2551);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(267, 75);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;

            //
            // lblBottomSpace
            //

            this.lblBottomSpace.AutoSize = false;

            this.lblBottomSpace.Location =
                new System.Drawing.Point(0, 2400);

            this.lblBottomSpace.Size =
                new System.Drawing.Size(10, 300);

            this.lblBottomSpace.Text = "";

            this.lblBottomSpace.BackColor =
                System.Drawing.Color.Transparent;
            // 
            // AddEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1360, 1250);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление сотрудника";
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}