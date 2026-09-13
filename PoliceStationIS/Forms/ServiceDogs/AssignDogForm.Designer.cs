using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Dogs
{
    partial class AssignDogForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlContent;

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblLine;

        private Label lblDogName;
        private Label lblDogNameValue;
        private Label lblStamp;
        private Label lblStampValue;
        private Label lblCurrentEmployee;
        private Label lblCurrentEmployeeValue;
        private Label lblEmployee;

        private ComboBox cmbEmployee;

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
                new Size(620, 440);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox =
                false;

            this.MinimizeBox =
                false;

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Name =
                "AssignDogForm";

            this.Text =
                "Закрепление служебной собаки";

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
                new Size(580, 85);

            this.pnlHeader.BackColor =
                Color.FromArgb(30, 58, 117);

            this.lblTitle =
                CreateLabel(
                    "ЗАКРЕПЛЕНИЕ СОБАКИ",
                    18F,
                    20,
                    14,
                    true);

            this.lblSubtitle =
                CreateLabel(
                    "Выберите сотрудника-кинолога",
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
                new Size(520, 2);

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
                new Size(580, 235);

            this.pnlContent.BackColor =
                Color.FromArgb(12, 35, 76);

            this.lblDogName =
                CreateLabel(
                    "Кличка:",
                    9F,
                    20,
                    20,
                    true);

            this.lblDogNameValue =
                CreateValueLabel(
                    "—",
                    125,
                    19);

            this.lblStamp =
                CreateLabel(
                    "№ клейма:",
                    9F,
                    20,
                    65,
                    true);

            this.lblStampValue =
                CreateValueLabel(
                    "—",
                    125,
                    64);

            this.lblCurrentEmployee =
                CreateLabel(
                    "Текущий сотрудник:",
                    9F,
                    20,
                    110,
                    true);

            this.lblCurrentEmployeeValue =
                CreateValueLabel(
                    "—",
                    155,
                    109);

            this.lblEmployee =
                CreateLabel(
                    "Новый сотрудник:",
                    9F,
                    20,
                    155,
                    true);

            this.cmbEmployee =
                new ComboBox();

            this.cmbEmployee.Location =
                new Point(155, 175);

            this.cmbEmployee.Size =
                new Size(380, 28);

            this.cmbEmployee.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbEmployee.BackColor =
                Color.FromArgb(5, 24, 58);

            this.cmbEmployee.ForeColor =
                Color.White;

            this.pnlContent.Controls.Add(
                this.lblDogName);

            this.pnlContent.Controls.Add(
                this.lblDogNameValue);

            this.pnlContent.Controls.Add(
                this.lblStamp);

            this.pnlContent.Controls.Add(
                this.lblStampValue);

            this.pnlContent.Controls.Add(
                this.lblCurrentEmployee);

            this.pnlContent.Controls.Add(
                this.lblCurrentEmployeeValue);

            this.pnlContent.Controls.Add(
                this.lblEmployee);

            this.pnlContent.Controls.Add(
                this.cmbEmployee);

            this.btnSave =
                CreateButton(
                    "Закрепить",
                    360);

            this.btnCancel =
                CreateButton(
                    "Отмена",
                    475);

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

        private Label CreateValueLabel(
            string text,
            int left,
            int top)
        {
            Label label =
                CreateLabel(
                    text,
                    10F,
                    left,
                    top,
                    false);

            label.MaximumSize =
                new Size(380, 0);

            return label;
        }

        private Button CreateButton(
            string text,
            int left)
        {
            Button button =
                new Button();

            button.Text = text;

            button.Location =
                new Point(left, 375);

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
