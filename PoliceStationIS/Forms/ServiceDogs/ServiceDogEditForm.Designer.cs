using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Dogs
{
    partial class ServiceDogEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlContent;

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblLine;

        private Label lblStampNumber;
        private Label lblDogName;
        private Label lblSex;
        private Label lblEmployee;
        private Label lblBreed;
        private Label lblStatus;
        private Label lblSpecialization;
        private Label lblDateOfBirth;
        private Label lblHealth;

        private TextBox txtStampNumber;
        private TextBox txtDogName;
        private ComboBox cmbSex;
        private ComboBox cmbEmployee;
        private ComboBox cmbBreed;
        private ComboBox cmbStatus;
        private ComboBox cmbSpecialization;
        private DateTimePicker dtDateOfBirth;
        private TextBox txtHealth;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(720, 620);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox =
                false;

            this.MinimizeBox =
                false;

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Name =
                "ServiceDogEditForm";

            this.Text =
                "Служебная собака";

            this.pnlMain =
                new Panel();

            this.pnlMain.Dock =
                DockStyle.Fill;

            this.pnlMain.BackColor =
                Color.FromArgb(5, 24, 58);

            this.pnlHeader =
                new Panel();

            this.pnlHeader.Location =
                new Point(20, 20);

            this.pnlHeader.Size =
                new Size(680, 85);

            this.pnlHeader.BackColor =
                Color.FromArgb(30, 58, 117);

            this.lblTitle =
                CreateLabel(
                    "СЛУЖЕБНАЯ СОБАКА",
                    18F,
                    20,
                    14,
                    true);

            this.lblSubtitle =
                CreateLabel(
                    "",
                    10F,
                    22,
                    48,
                    false);

            this.lblLine =
                new Label();

            this.lblLine.BackColor =
                Color.FromArgb(201, 155, 59);

            this.lblLine.Location =
                new Point(22, 72);

            this.lblLine.Size =
                new Size(620, 2);

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            this.pnlHeader.Controls.Add(
                this.lblLine);

            this.pnlContent =
                new Panel();

            this.pnlContent.Location =
                new Point(20, 125);

            this.pnlContent.Size =
                new Size(680, 420);

            this.pnlContent.BackColor =
                Color.FromArgb(12, 35, 76);

            AddField(
                "№ клейма",
                out lblStampNumber,
                out txtStampNumber,
                20,
                20,
                250);

            AddField(
                "Кличка",
                out lblDogName,
                out txtDogName,
                350,
                20,
                250);

            AddCombo(
                "Пол",
                out lblSex,
                out cmbSex,
                20,
                90,
                250);

            AddCombo(
                "Закреплён за",
                out lblEmployee,
                out cmbEmployee,
                350,
                90,
                250);

            AddCombo(
                "Порода",
                out lblBreed,
                out cmbBreed,
                20,
                160,
                250);

            AddCombo(
                "Статус",
                out lblStatus,
                out cmbStatus,
                350,
                160,
                250);

            AddCombo(
                "Специализация",
                out lblSpecialization,
                out cmbSpecialization,
                20,
                230,
                250);

            this.lblDateOfBirth =
                CreateLabel(
                    "Дата рождения",
                    9F,
                    350,
                    230,
                    true);

            this.dtDateOfBirth =
                new DateTimePicker();

            this.dtDateOfBirth.Location =
                new Point(350, 250);

            this.dtDateOfBirth.Size =
                new Size(250, 28);

            this.dtDateOfBirth.Format =
                DateTimePickerFormat.Short;

            this.dtDateOfBirth.MaxDate =
                DateTime.Today;

            this.dtDateOfBirth.Value =
                DateTime.Today;

            this.dtDateOfBirth.CalendarMonthBackground =
                Color.White;

            this.pnlContent.Controls.Add(
                this.lblDateOfBirth);

            this.pnlContent.Controls.Add(
                this.dtDateOfBirth);

            this.lblHealth =
                CreateLabel(
                    "Состояние здоровья",
                    9F,
                    20,
                    300,
                    true);

            this.txtHealth =
                new TextBox();

            this.txtHealth.Location =
                new Point(20, 320);

            this.txtHealth.Size =
                new Size(580, 65);

            this.txtHealth.Multiline =
                true;

            this.txtHealth.ScrollBars =
                ScrollBars.Vertical;

            this.txtHealth.BackColor =
                Color.FromArgb(5, 24, 58);

            this.txtHealth.ForeColor =
                Color.White;

            this.txtHealth.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlContent.Controls.Add(
                this.lblHealth);

            this.pnlContent.Controls.Add(
                this.txtHealth);

            this.btnSave =
                CreateBottomButton(
                    "Сохранить",
                    390);

            this.btnCancel =
                CreateBottomButton(
                    "Отмена",
                    510);

            this.btnSave.Click +=
                btnSave_Click;

            this.btnCancel.Click +=
                btnCancel_Click;

            this.pnlMain.Controls.Add(
                this.pnlHeader);

            this.pnlMain.Controls.Add(
                this.pnlContent);

            this.pnlMain.Controls.Add(
                this.btnSave);

            this.pnlMain.Controls.Add(
                this.btnCancel);

            this.Controls.Add(
                this.pnlMain);
        }

        private Label CreateLabel(
            string text,
            float size,
            int left,
            int top,
            bool bold)
        {
            Label label =
                new Label();

            label.Text = text;
            label.AutoSize = true;
            label.ForeColor = Color.White;
            label.Font =
                new Font(
                    "Segoe UI",
                    size,
                    bold
                        ? FontStyle.Bold
                        : FontStyle.Regular);

            label.Location =
                new Point(left, top);

            return label;
        }

        private void AddField(
            string text,
            out Label label,
            out TextBox textBox,
            int left,
            int top,
            int width)
        {
            label =
                CreateLabel(
                    text,
                    9F,
                    left,
                    top,
                    true);

            textBox =
                new TextBox();

            textBox.Location =
                new Point(left, top + 20);

            textBox.Size =
                new Size(width, 28);

            textBox.BackColor =
                Color.FromArgb(5, 24, 58);

            textBox.ForeColor =
                Color.White;

            textBox.BorderStyle =
                BorderStyle.FixedSingle;

            pnlContent.Controls.Add(label);
            pnlContent.Controls.Add(textBox);
        }

        private void AddCombo(
            string text,
            out Label label,
            out ComboBox comboBox,
            int left,
            int top,
            int width)
        {
            label =
                CreateLabel(
                    text,
                    9F,
                    left,
                    top,
                    true);

            comboBox =
                new ComboBox();

            comboBox.Location =
                new Point(left, top + 20);

            comboBox.Size =
                new Size(width, 28);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.BackColor =
                Color.FromArgb(5, 24, 58);

            comboBox.ForeColor =
                Color.White;

            pnlContent.Controls.Add(label);
            pnlContent.Controls.Add(comboBox);
        }

        private Button CreateBottomButton(
            string text,
            int left)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Location =
                new Point(left, 565);

            button.Size =
                new Size(100, 38);

            button.BackColor =
                Color.FromArgb(30, 58, 117);

            button.ForeColor =
                Color.White;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(201, 155, 59);

            button.FlatAppearance.BorderSize =
                1;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }
    }
}
