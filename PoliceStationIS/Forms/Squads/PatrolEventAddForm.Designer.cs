using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Squads
{
    partial class PatrolEventAddForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblSquadTitle;
        private Label lblSquadValue;
        private Label lblRecordingType;
        private ComboBox cmbRecordingType;
        private Label lblCrimeRate;
        private ComboBox cmbCrimeRate;
        private Label lblRecordingDate;
        private DateTimePicker dtRecordingDate;
        private Label lblScene;
        private TextBox txtScene;
        private Label lblDescription;
        private TextBox txtDescription;
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
            this.SuspendLayout();

            this.BackColor = Color.FromArgb(5, 24, 58);
            this.ClientSize = new Size(680, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление события";

            pnlMain = new Panel();
            pnlMain.BackColor = Color.FromArgb(18, 38, 74);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(20, 20);
            pnlMain.Size = new Size(640, 590);

            lblTitle = new Label();
            lblTitle.Text = "ДОБАВЛЕНИЕ СОБЫТИЯ";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(22, 18);

            Panel pnlTitleLine = new Panel();
            pnlTitleLine.BackColor = Color.FromArgb(212, 160, 23);
            pnlTitleLine.Location = new Point(25, 50);
            pnlTitleLine.Size = new Size(30, 3);

            lblSubtitle = new Label();
            lblSubtitle.Text = "Регистрация события патрульно-постового обслуживания";
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.Gainsboro;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(23, 62);

            lblSquadTitle = CreateFieldLabel("Наряд", 25, 105);
            lblSquadValue = CreateValueLabel(25, 128, 590);
            lblSquadValue.BackColor = Color.FromArgb(30, 58, 117);
            lblSquadValue.Padding = new Padding(10, 6, 10, 0);

            lblRecordingType = CreateFieldLabel("Тип события", 25, 175);
            cmbRecordingType = CreateComboBox(25, 198, 280);

            lblCrimeRate = CreateFieldLabel("Уровень опасности", 330, 175);
            cmbCrimeRate = CreateComboBox(330, 198, 285);

            lblRecordingDate = CreateFieldLabel("Дата и время события", 25, 245);
            dtRecordingDate = new DateTimePicker();
            dtRecordingDate.Location = new Point(25, 268);
            dtRecordingDate.Size = new Size(280, 27);
            dtRecordingDate.Format = DateTimePickerFormat.Custom;
            dtRecordingDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtRecordingDate.ShowUpDown = true;

            lblScene = CreateFieldLabel("Место происшествия", 25, 315);
            txtScene = CreateTextBox(25, 338, 590, 28);

            lblDescription = CreateFieldLabel("Описание события", 25, 385);
            txtDescription = new TextBox();
            txtDescription.Location = new Point(25, 408);
            txtDescription.Size = new Size(590, 80);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.BackColor = Color.White;
            txtDescription.ForeColor = Color.FromArgb(30, 30, 30);
            txtDescription.Font = new Font("Segoe UI", 9F);

            btnSave = CreatePrimaryButton("Сохранить", 350, 545, 125, 34);
            btnSave.Click += BtnSave_Click;

            btnCancel = CreateSecondaryButton("Отмена", 490, 545, 125, 34);
            btnCancel.Click += BtnCancel_Click;

            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(pnlTitleLine);
            pnlMain.Controls.Add(lblSubtitle);
            pnlMain.Controls.Add(lblSquadTitle);
            pnlMain.Controls.Add(lblSquadValue);
            pnlMain.Controls.Add(lblRecordingType);
            pnlMain.Controls.Add(cmbRecordingType);
            pnlMain.Controls.Add(lblCrimeRate);
            pnlMain.Controls.Add(cmbCrimeRate);
            pnlMain.Controls.Add(lblRecordingDate);
            pnlMain.Controls.Add(dtRecordingDate);
            pnlMain.Controls.Add(lblScene);
            pnlMain.Controls.Add(txtScene);
            pnlMain.Controls.Add(lblDescription);
            pnlMain.Controls.Add(txtDescription);
            pnlMain.Controls.Add(btnSave);
            pnlMain.Controls.Add(btnCancel);

            this.Controls.Add(pnlMain);
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            this.ResumeLayout(false);
        }

        private Label CreateFieldLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.ForeColor = Color.Gainsboro;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.Location = new Point(x, y);
            return label;
        }

        private Label CreateValueLabel(int x, int y, int width)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Size = new Size(width, 30);
            label.ForeColor = Color.White;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.Location = new Point(x, y);
            return label;
        }

        private ComboBox CreateComboBox(int x, int y, int width)
        {
            ComboBox combo = new ComboBox();
            combo.Location = new Point(x, y);
            combo.Size = new Size(width, 27);
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.BackColor = Color.FromArgb(30, 58, 117);
            combo.ForeColor = Color.White;
            combo.FlatStyle = FlatStyle.Flat;
            combo.Font = new Font("Segoe UI", 9F);
            return combo;
        }

        private TextBox CreateTextBox(int x, int y, int width, int height)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(width, height);
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.FromArgb(30, 30, 30);
            textBox.Font = new Font("Segoe UI", 9F);
            return textBox;
        }

        private Button CreatePrimaryButton(
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 160, 23);
            button.BackColor = Color.FromArgb(196, 145, 35);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            return button;
        }

        private Button CreateSecondaryButton(
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 160, 23);
            button.BackColor = Color.FromArgb(42, 73, 133);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            return button;
        }
    }
}
