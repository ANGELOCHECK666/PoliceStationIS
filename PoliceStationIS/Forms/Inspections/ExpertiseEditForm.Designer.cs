using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Expertises
{
    partial class ExpertiseEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;

        private Label lblExpertiseNumber;
        private TextBox txtExpertiseNumber;

        private Label lblEmployee;
        private ComboBox cmbEmployee;

        private Label lblExpertiseType;
        private ComboBox cmbExpertiseType;

        private Label lblStatus;
        private ComboBox cmbStatus;

        private Label lblProtocol;
        private ComboBox cmbProtocol;

        private Label lblAppointmentDate;
        private DateTimePicker dtAppointmentDate;

        private Label lblResearchStartDate;
        private DateTimePicker dtResearchStartDate;

        private Label lblResearchEndDate;
        private DateTimePicker dtResearchEndDate;

        private Label lblConclusion;
        private TextBox txtConclusion;

        private Label lblFile;
        private Label lblFileName;
        private IconButton btnSelectFile;
        private IconButton btnClearFile;

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
            this.components =
                new System.ComponentModel.Container();

            this.SuspendLayout();

            //============================================================
            // FORM
            //============================================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(900, 780);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Name =
                "ExpertiseEditForm";

            this.Text =
                "Добавление экспертизы";

            //============================================================
            // MAIN PANEL
            //============================================================

            this.pnlMain =
                new Panel();

            this.pnlMain.BackColor =
                Color.FromArgb(18, 38, 74);

            this.pnlMain.Location =
                new Point(20, 20);

            this.pnlMain.Size =
                new Size(860, 740);

            this.pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            //============================================================
            // TITLE
            //============================================================

            this.lblTitle =
                new Label();

            this.lblTitle.AutoSize = true;

            this.lblTitle.Text =
                "ДАННЫЕ ЭКСПЕРТИЗЫ";

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(25, 18);

            this.pnlMain.Controls.Add(
                this.lblTitle);

            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTitleLine.Location =
                new Point(28, 50);

            pnlTitleLine.Size =
                new Size(35, 3);

            this.pnlMain.Controls.Add(
                pnlTitleLine);

            this.lblSubtitle =
                new Label();

            this.lblSubtitle.AutoSize = true;

            this.lblSubtitle.Text =
                "Назначение, проведение и результат экспертного исследования";

            this.lblSubtitle.Font =
                new Font("Segoe UI", 9.5F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(27, 60);

            this.pnlMain.Controls.Add(
                this.lblSubtitle);

            //============================================================
            // LEFT COLUMN
            //============================================================

            this.lblExpertiseNumber =
                CreateLabel("№ экспертизы", 35, 105);

            this.txtExpertiseNumber =
                CreateTextBox(35, 128, 240);

            this.lblEmployee =
                CreateLabel("Сотрудник", 35, 175);

            this.cmbEmployee =
                CreateComboBox(35, 198, 240);

            this.lblExpertiseType =
                CreateLabel("Тип экспертизы", 35, 245);

            this.cmbExpertiseType =
                CreateComboBox(35, 268, 240);

            this.lblStatus =
                CreateLabel("Статус", 35, 315);

            this.cmbStatus =
                CreateComboBox(35, 338, 240);

            this.lblProtocol =
                CreateLabel("Протокол", 35, 385);

            this.cmbProtocol =
                CreateComboBox(35, 408, 240);

            //============================================================
            // RIGHT COLUMN
            //============================================================

            this.lblAppointmentDate =
                CreateLabel("Дата назначения", 315, 105);

            this.dtAppointmentDate =
                CreateDatePicker(315, 128, 240);

            this.lblResearchStartDate =
                CreateLabel("Начало исследования", 315, 175);

            this.dtResearchStartDate =
                CreateDatePicker(315, 198, 240);

            this.lblResearchEndDate =
                CreateLabel("Окончание исследования", 315, 245);

            this.dtResearchEndDate =
                CreateDatePicker(315, 268, 240);

            this.lblConclusion =
                CreateLabel("Заключение", 315, 315);

            this.txtConclusion =
                new TextBox();

            this.txtConclusion.Location =
                new Point(315, 338);

            this.txtConclusion.Size =
                new Size(500, 105);

            this.txtConclusion.BackColor =
                Color.FromArgb(30, 58, 117);

            this.txtConclusion.ForeColor =
                Color.White;

            this.txtConclusion.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtConclusion.Font =
                new Font("Segoe UI", 9F);

            this.txtConclusion.Multiline = true;
            this.txtConclusion.ScrollBars =
                ScrollBars.Vertical;

            //============================================================
            // FILE
            //============================================================

            this.lblFile =
                CreateLabel("Файл экспертизы", 315, 470);

            this.lblFileName =
                new Label();

            this.lblFileName.AutoEllipsis = true;
            this.lblFileName.Location =
                new Point(315, 495);

            this.lblFileName.Size =
                new Size(300, 30);

            this.lblFileName.Text =
                "Файл не выбран";

            this.lblFileName.Font =
                new Font("Segoe UI", 9F);

            this.lblFileName.ForeColor =
                Color.Gainsboro;

            this.lblFileName.TextAlign =
                ContentAlignment.MiddleLeft;

            this.btnSelectFile =
                new IconButton();

            this.btnSelectFile.Text =
                "Выбрать файл";

            this.btnSelectFile.Size =
                new Size(150, 38);

            this.btnSelectFile.Location =
                new Point(625, 490);

            ConfigureActionButton(
                this.btnSelectFile);

            this.btnClearFile =
                new IconButton();

            this.btnClearFile.Text =
                "Убрать файл";

            this.btnClearFile.Size =
                new Size(150, 38);

            this.btnClearFile.Location =
                new Point(625, 535);

            ConfigureActionButton(
                this.btnClearFile);

            //============================================================
            // BUTTONS
            //============================================================

            this.btnSave =
                new Button();

            this.btnSave.Text =
                "Сохранить";

            this.btnSave.Size =
                new Size(170, 45);

            this.btnSave.Location =
                new Point(495, 665);

            ConfigureSaveButton(
                this.btnSave);

            this.btnCancel =
                new Button();

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.Size =
                new Size(170, 45);

            this.btnCancel.Location =
                new Point(680, 665);

            ConfigureCancelButton(
                this.btnCancel);

            //============================================================
            // ADD CONTROLS
            //============================================================

            this.pnlMain.Controls.Add(
                this.lblExpertiseNumber);

            this.pnlMain.Controls.Add(
                this.txtExpertiseNumber);

            this.pnlMain.Controls.Add(
                this.lblEmployee);

            this.pnlMain.Controls.Add(
                this.cmbEmployee);

            this.pnlMain.Controls.Add(
                this.lblExpertiseType);

            this.pnlMain.Controls.Add(
                this.cmbExpertiseType);

            this.pnlMain.Controls.Add(
                this.lblStatus);

            this.pnlMain.Controls.Add(
                this.cmbStatus);

            this.pnlMain.Controls.Add(
                this.lblProtocol);

            this.pnlMain.Controls.Add(
                this.cmbProtocol);

            this.pnlMain.Controls.Add(
                this.lblAppointmentDate);

            this.pnlMain.Controls.Add(
                this.dtAppointmentDate);

            this.pnlMain.Controls.Add(
                this.lblResearchStartDate);

            this.pnlMain.Controls.Add(
                this.dtResearchStartDate);

            this.pnlMain.Controls.Add(
                this.lblResearchEndDate);

            this.pnlMain.Controls.Add(
                this.dtResearchEndDate);

            this.pnlMain.Controls.Add(
                this.lblConclusion);

            this.pnlMain.Controls.Add(
                this.txtConclusion);

            this.pnlMain.Controls.Add(
                this.lblFile);

            this.pnlMain.Controls.Add(
                this.lblFileName);

            this.pnlMain.Controls.Add(
                this.btnSelectFile);

            this.pnlMain.Controls.Add(
                this.btnClearFile);

            this.pnlMain.Controls.Add(
                this.btnSave);

            this.pnlMain.Controls.Add(
                this.btnCancel);

            this.Controls.Add(
                this.pnlMain);

            this.ResumeLayout(false);
        }

        private Label CreateLabel(
            string text,
            int x,
            int y)
        {
            Label label =
                new Label();

            label.AutoSize = true;
            label.Text = text;
            label.Location =
                new Point(x, y);

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.Gainsboro;

            return label;
        }

        private TextBox CreateTextBox(
            int x,
            int y,
            int width)
        {
            TextBox textBox =
                new TextBox();

            textBox.Location =
                new Point(x, y);

            textBox.Size =
                new Size(width, 27);

            textBox.BackColor =
                Color.FromArgb(30, 58, 117);

            textBox.ForeColor =
                Color.White;

            textBox.BorderStyle =
                BorderStyle.FixedSingle;

            textBox.Font =
                new Font("Segoe UI", 9F);

            return textBox;
        }

        private ComboBox CreateComboBox(
            int x,
            int y,
            int width)
        {
            ComboBox comboBox =
                new ComboBox();

            comboBox.Location =
                new Point(x, y);

            comboBox.Size =
                new Size(width, 27);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.BackColor =
                Color.FromArgb(30, 58, 117);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;

            comboBox.Font =
                new Font("Segoe UI", 9F);

            return comboBox;
        }

        private DateTimePicker CreateDatePicker(
            int x,
            int y,
            int width)
        {
            DateTimePicker picker =
                new DateTimePicker();

            picker.Location =
                new Point(x, y);

            picker.Size =
                new Size(width, 27);

            picker.Format =
                DateTimePickerFormat.Short;

            return picker;
        }

        private void ConfigureActionButton(
            IconButton button)
        {
            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(25, 45, 80);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
        }

        private void ConfigureSaveButton(
            Button button)
        {
            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(212, 160, 23);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;
        }

        private void ConfigureCancelButton(
            Button button)
        {
            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(100, 120, 150);

            button.BackColor =
                Color.FromArgb(30, 58, 117);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;
        }
    }
}