using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Protocols
{
    partial class ProtocolEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblSubtitle;

        private Label lblProtocolNumber;
        private Label lblProtocolType;
        private Label lblArticle;
        private Label lblStatus;
        private Label lblEmployee;
        private Label lblEvidence;
        private Label lblPreparationDate;
        private Label lblPlace;
        private Label lblDescription;

        private TextBox txtProtocolNumber;
        private ComboBox cmbProtocolType;
        private ComboBox cmbArticle;
        private ComboBox cmbStatus;
        private ComboBox cmbEmployee;
        private ComboBox cmbEvidence;
        private DateTimePicker dtPreparationDate;
        private TextBox txtPlace;
        private TextBox txtDescription;

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

            this.pnlMain = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();

            this.lblProtocolNumber = new Label();
            this.lblProtocolType = new Label();
            this.lblArticle = new Label();
            this.lblStatus = new Label();
            this.lblEmployee = new Label();
            this.lblEvidence = new Label();
            this.lblPreparationDate = new Label();
            this.lblPlace = new Label();
            this.lblDescription = new Label();

            this.txtProtocolNumber = new TextBox();
            this.cmbProtocolType = new ComboBox();
            this.cmbArticle = new ComboBox();
            this.cmbStatus = new ComboBox();
            this.cmbEmployee = new ComboBox();
            this.cmbEvidence = new ComboBox();
            this.dtPreparationDate = new DateTimePicker();
            this.txtPlace = new TextBox();
            this.txtDescription = new TextBox();

            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            //========================================================
            // FORM
            //========================================================

            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(5, 24, 58);
            this.ClientSize = new Size(900, 760);
            this.Name = "ProtocolEditForm";
            this.Text = "Протокол";
            this.StartPosition =
                FormStartPosition.CenterParent;
            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            //========================================================
            // MAIN PANEL
            //========================================================

            this.pnlMain.BackColor =
                Color.FromArgb(18, 38, 74);

            this.pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlMain.Location =
                new Point(20, 20);

            this.pnlMain.Size =
                new Size(860, 700);

            //========================================================
            // TITLE
            //========================================================

            this.lblTitle.AutoSize = true;
            this.lblTitle.Text = "ПРОТОКОЛ";
            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location =
                new Point(28, 22);

            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTitleLine.Location =
                new Point(32, 58);

            pnlTitleLine.Size =
                new Size(35, 3);

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Text =
                "Данные протокола и основные сведения";
            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);
            this.lblSubtitle.ForeColor =
                Color.Gainsboro;
            this.lblSubtitle.Location =
                new Point(30, 68);

            //========================================================
            // LABELS
            //========================================================

            ConfigureLabel(
                this.lblProtocolNumber,
                "№ протокола",
                30,
                115);

            ConfigureLabel(
                this.lblProtocolType,
                "Тип протокола",
                440,
                115);

            ConfigureLabel(
                this.lblArticle,
                "Статья КоАП РФ",
                30,
                195);

            ConfigureLabel(
                this.lblStatus,
                "Статус",
                440,
                195);

            ConfigureLabel(
                this.lblEmployee,
                "Сотрудник",
                30,
                275);

            ConfigureLabel(
                this.lblEvidence,
                "Вещественное доказательство",
                440,
                275);

            ConfigureLabel(
                this.lblPreparationDate,
                "Дата составления",
                30,
                355);

            ConfigureLabel(
                this.lblPlace,
                "Место составления",
                440,
                355);

            ConfigureLabel(
                this.lblDescription,
                "Описание протокола",
                30,
                435);

            //========================================================
            // TEXTBOX NUMBER
            //========================================================

            ConfigureTextBox(
                this.txtProtocolNumber,
                30,
                138,
                365,
                30);

            //========================================================
            // COMBOBOXES
            //========================================================

            ConfigureComboBox(
                this.cmbProtocolType,
                440,
                138,
                365,
                30);

            ConfigureComboBox(
                this.cmbArticle,
                30,
                218,
                365,
                30);

            ConfigureComboBox(
                this.cmbStatus,
                440,
                218,
                365,
                30);

            ConfigureComboBox(
                this.cmbEmployee,
                30,
                298,
                365,
                30);

            ConfigureComboBox(
                this.cmbEvidence,
                440,
                298,
                365,
                30);

            //========================================================
            // DATE
            //========================================================

            this.dtPreparationDate.Format =
                DateTimePickerFormat.Short;

            this.dtPreparationDate.Location =
                new Point(30, 378);

            this.dtPreparationDate.Size =
                new Size(365, 30);

            this.dtPreparationDate.Font =
                new Font(
                    "Segoe UI",
                    10F);

            //========================================================
            // PLACE
            //========================================================

            ConfigureTextBox(
                this.txtPlace,
                440,
                378,
                365,
                30);

            //========================================================
            // DESCRIPTION
            //========================================================

            this.txtDescription.Location =
                new Point(30, 458);

            this.txtDescription.Size =
                new Size(775, 145);

            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars =
                ScrollBars.Vertical;

            this.txtDescription.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtDescription.BackColor =
                Color.FromArgb(7, 27, 62);

            this.txtDescription.ForeColor =
                Color.White;

            this.txtDescription.BorderStyle =
                BorderStyle.FixedSingle;

            //========================================================
            // SAVE BUTTON
            //========================================================

            ConfigureButton(
                this.btnSave,
                "Сохранить",
                535,
                630,
                130,
                42,
                Color.FromArgb(196, 145, 35));

            //========================================================
            // CANCEL BUTTON
            //========================================================

            ConfigureButton(
                this.btnCancel,
                "Отмена",
                675,
                630,
                130,
                42,
                Color.FromArgb(42, 73, 133));

            //========================================================
            // ADD CONTROLS
            //========================================================

            this.pnlMain.Controls.Add(
                pnlTitleLine);

            this.pnlMain.Controls.Add(
                this.lblTitle);

            this.pnlMain.Controls.Add(
                this.lblSubtitle);

            this.pnlMain.Controls.Add(
                this.lblProtocolNumber);

            this.pnlMain.Controls.Add(
                this.lblProtocolType);

            this.pnlMain.Controls.Add(
                this.lblArticle);

            this.pnlMain.Controls.Add(
                this.lblStatus);

            this.pnlMain.Controls.Add(
                this.lblEmployee);

            this.pnlMain.Controls.Add(
                this.lblEvidence);

            this.pnlMain.Controls.Add(
                this.lblPreparationDate);

            this.pnlMain.Controls.Add(
                this.lblPlace);

            this.pnlMain.Controls.Add(
                this.lblDescription);

            this.pnlMain.Controls.Add(
                this.txtProtocolNumber);

            this.pnlMain.Controls.Add(
                this.cmbProtocolType);

            this.pnlMain.Controls.Add(
                this.cmbArticle);

            this.pnlMain.Controls.Add(
                this.cmbStatus);

            this.pnlMain.Controls.Add(
                this.cmbEmployee);

            this.pnlMain.Controls.Add(
                this.cmbEvidence);

            this.pnlMain.Controls.Add(
                this.dtPreparationDate);

            this.pnlMain.Controls.Add(
                this.txtPlace);

            this.pnlMain.Controls.Add(
                this.txtDescription);

            this.pnlMain.Controls.Add(
                this.btnSave);

            this.pnlMain.Controls.Add(
                this.btnCancel);

            this.Controls.Add(
                this.pnlMain);

            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();

            this.ResumeLayout(false);
        }

        private void ConfigureLabel(
            Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Text = text;
            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
            label.ForeColor =
                Color.Gainsboro;
            label.Location =
                new Point(x, y);
        }

        private void ConfigureTextBox(
            TextBox textBox,
            int x,
            int y,
            int width,
            int height)
        {
            textBox.Location =
                new Point(x, y);

            textBox.Size =
                new Size(width, height);

            textBox.Font =
                new Font(
                    "Segoe UI",
                    10F);

            textBox.BackColor =
                Color.FromArgb(7, 27, 62);

            textBox.ForeColor =
                Color.White;

            textBox.BorderStyle =
                BorderStyle.FixedSingle;
        }

        private void ConfigureComboBox(
            ComboBox comboBox,
            int x,
            int y,
            int width,
            int height)
        {
            comboBox.Location =
                new Point(x, y);

            comboBox.Size =
                new Size(width, height);

            comboBox.Font =
                new Font(
                    "Segoe UI",
                    10F);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.BackColor =
                Color.FromArgb(7, 27, 62);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;
        }

        private void ConfigureButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height,
            Color backColor)
        {
            button.Text = text;

            button.Location =
                new Point(x, y);

            button.Size =
                new Size(width, height);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                backColor;

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;
        }
    }
}