using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Cases
{
    partial class CaseEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel pnlMain, pnlBasicLine, pnlCrimeLine, pnlFileLine;
        private Label lblBasicTitle, lblCrimeTitle, lblFileTitle;
        private Label lblCaseNumber, lblStatus, lblArticle, lblEmployee, lblProtocol;
        private TextBox txtCaseNumber, txtCrimeScene, txtDescription;
        private ComboBox cmbStatus, cmbArticle, cmbEmployee, cmbProtocol;
        private Label lblCrimeDate, lblCrimeScene, lblDescription;
        private DateTimePicker dtCrimeDate;
        private Button btnChooseFile, btnRemoveFile, btnSave, btnCancel;
        private Label lblFileName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            pnlMain = new Panel();
            pnlBasicLine = new Panel();
            pnlCrimeLine = new Panel();
            pnlFileLine = new Panel();
            lblBasicTitle = new Label();
            lblCrimeTitle = new Label();
            lblFileTitle = new Label();
            lblCaseNumber = new Label();
            lblStatus = new Label();
            lblArticle = new Label();
            lblEmployee = new Label();
            lblProtocol = new Label();
            txtCaseNumber = new TextBox();
            cmbStatus = new ComboBox();
            cmbArticle = new ComboBox();
            cmbEmployee = new ComboBox();
            cmbProtocol = new ComboBox();
            lblCrimeDate = new Label();
            lblCrimeScene = new Label();
            lblDescription = new Label();
            dtCrimeDate = new DateTimePicker();
            txtCrimeScene = new TextBox();
            txtDescription = new TextBox();
            btnChooseFile = new Button();
            btnRemoveFile = new Button();
            lblFileName = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(5, 24, 58);
            ClientSize = new Size(900, 790);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Создание дела";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(35, 25);
            lblTitle.Text = "Создание дела";

            pnlMain.BackColor = Color.FromArgb(18, 38, 74);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(20, 75);
            pnlMain.Size = new Size(860, 625);

            lblBasicTitle.AutoSize = true;
            lblBasicTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBasicTitle.ForeColor = Color.FromArgb(212, 160, 23);
            lblBasicTitle.Location = new Point(25, 18);
            lblBasicTitle.Text = "Основные данные";
            pnlBasicLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlBasicLine.Location = new Point(25, 48);
            pnlBasicLine.Size = new Size(808, 2);

            ConfigureLabel(lblCaseNumber, "№ дела", 25, 65);
            ConfigureLabel(lblStatus, "Статус", 455, 65);
            ConfigureTextBox(txtCaseNumber, 25, 88, 350, 27);
            ConfigureComboBox(cmbStatus, 455, 88, 350, 27);

            ConfigureLabel(lblArticle, "Статья УК РФ", 25, 130);
            ConfigureLabel(lblEmployee, "Следователь", 455, 130);
            ConfigureComboBox(cmbArticle, 25, 153, 350, 27);
            ConfigureComboBox(cmbEmployee, 455, 153, 350, 27);

            ConfigureLabel(lblProtocol, "Протокол", 25, 195);
            ConfigureComboBox(cmbProtocol, 25, 218, 350, 27);

            lblCrimeTitle.AutoSize = true;
            lblCrimeTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCrimeTitle.ForeColor = Color.FromArgb(212, 160, 23);
            lblCrimeTitle.Location = new Point(25, 265);
            lblCrimeTitle.Text = "Сведения о преступлении";
            pnlCrimeLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlCrimeLine.Location = new Point(25, 295);
            pnlCrimeLine.Size = new Size(808, 2);

            ConfigureLabel(lblCrimeDate, "Дата и время преступления", 25, 315);
            ConfigureLabel(lblCrimeScene, "Место совершения", 455, 315);
            dtCrimeDate.Format = DateTimePickerFormat.Custom;
            dtCrimeDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtCrimeDate.ShowCheckBox = true;
            dtCrimeDate.Location = new Point(25, 338);
            dtCrimeDate.Size = new Size(350, 27);
            dtCrimeDate.Font = new Font("Segoe UI", 9F);
            ConfigureTextBox(txtCrimeScene, 455, 338, 350, 27);

            ConfigureLabel(lblDescription, "Описание дела", 25, 380);
            ConfigureTextBox(txtDescription, 25, 403, 780, 105);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            lblFileTitle.AutoSize = true;
            lblFileTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFileTitle.ForeColor = Color.FromArgb(212, 160, 23);
            lblFileTitle.Location = new Point(25, 530);
            lblFileTitle.Text = "Файл уголовного дела";
            pnlFileLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlFileLine.Location = new Point(25, 560);
            pnlFileLine.Size = new Size(808, 2);

            ConfigureButton(btnChooseFile, "Выбрать файл", 25, 578, 135, 36, true);
            ConfigureButton(btnRemoveFile, "Удалить файл", 170, 578, 135, 36, false);
            lblFileName.AutoSize = false;
            lblFileName.Font = new Font("Segoe UI", 9F);
            lblFileName.ForeColor = Color.Gainsboro;
            lblFileName.Location = new Point(325, 585);
            lblFileName.Size = new Size(480, 24);
            lblFileName.Text = "Файл не выбран";

            pnlMain.Controls.Add(lblBasicTitle);
            pnlMain.Controls.Add(pnlBasicLine);
            pnlMain.Controls.Add(lblCaseNumber);
            pnlMain.Controls.Add(txtCaseNumber);
            pnlMain.Controls.Add(lblStatus);
            pnlMain.Controls.Add(cmbStatus);
            pnlMain.Controls.Add(lblArticle);
            pnlMain.Controls.Add(cmbArticle);
            pnlMain.Controls.Add(lblEmployee);
            pnlMain.Controls.Add(cmbEmployee);
            pnlMain.Controls.Add(lblProtocol);
            pnlMain.Controls.Add(cmbProtocol);
            pnlMain.Controls.Add(lblCrimeTitle);
            pnlMain.Controls.Add(pnlCrimeLine);
            pnlMain.Controls.Add(lblCrimeDate);
            pnlMain.Controls.Add(dtCrimeDate);
            pnlMain.Controls.Add(lblCrimeScene);
            pnlMain.Controls.Add(txtCrimeScene);
            pnlMain.Controls.Add(lblDescription);
            pnlMain.Controls.Add(txtDescription);
            pnlMain.Controls.Add(lblFileTitle);
            pnlMain.Controls.Add(pnlFileLine);
            pnlMain.Controls.Add(btnChooseFile);
            pnlMain.Controls.Add(btnRemoveFile);
            pnlMain.Controls.Add(lblFileName);

            ConfigureButton(btnSave, "Сохранить", 610, 720, 135, 40, true);
            ConfigureButton(btnCancel, "Отмена", 755, 720, 110, 40, false);

            Controls.Add(lblTitle);
            Controls.Add(pnlMain);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            btnChooseFile.Click += BtnChooseFile_Click;
            btnRemoveFile.Click += BtnRemoveFile_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureLabel(Label label, string text, int x, int y)
        {
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = Color.Gainsboro;
            label.Location = new Point(x, y);
            label.Text = text;
        }

        private void ConfigureTextBox(TextBox box, int x, int y, int width, int height)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(width, height);
            box.BackColor = Color.FromArgb(38, 70, 130);
            box.ForeColor = Color.White;
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureComboBox(ComboBox box, int x, int y, int width, int height)
        {
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.Location = new Point(x, y);
            box.Size = new Size(width, height);
            box.BackColor = Color.FromArgb(38, 70, 130);
            box.ForeColor = Color.White;
            box.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureButton(Button button, string text, int x, int y,
            int width, int height, bool gold)
        {
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 160, 23);
            button.BackColor = gold
                ? Color.FromArgb(42, 73, 133)
                : Color.FromArgb(30, 58, 117);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.UseVisualStyleBackColor = false;
        }
    }
}