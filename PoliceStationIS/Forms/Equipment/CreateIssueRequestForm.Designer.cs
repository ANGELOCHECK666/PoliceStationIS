using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Equipment
{
    partial class CreateIssueRequestForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlForm;
        private Label lblFormTitle;

        private Label lblEmployee;
        private ComboBox cmbEmployee;

        private Label lblCategory;
        private ComboBox cmbCategory;

        private Label lblEquipment;
        private ComboBox cmbEquipment;
        private Label lblEquipmentHint;

        private Label lblRequestDate;
        private DateTimePicker dtpRequestDate;

        private Label lblComment;
        private TextBox txtComment;

        private Button btnCreate;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new Label();
            this.lblSubtitle = new Label();

            this.pnlForm = new Panel();
            this.lblFormTitle = new Label();

            this.lblEmployee = new Label();
            this.cmbEmployee = new ComboBox();

            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();

            this.lblEquipment = new Label();
            this.cmbEquipment = new ComboBox();
            this.lblEquipmentHint = new Label();

            this.lblRequestDate = new Label();
            this.dtpRequestDate = new DateTimePicker();

            this.lblComment = new Label();
            this.txtComment = new TextBox();

            this.btnCreate = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // FORM
            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(11, 27, 58);

            this.ClientSize =
                new Size(760, 610);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);

            this.Font =
                new Font("Segoe UI", 9F);

            this.FormBorderStyle =
                FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Name =
                "CreateIssueRequestForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Создание заявки на выдачу";

            this.ShowInTaskbar = false;

            // TITLE
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(28, 22);

            this.lblTitle.Text =
                "Создание заявки на выдачу";

            // SUBTITLE
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(31, 58);

            this.lblSubtitle.Text =
                "Оформление заявки на выдачу служебного имущества сотруднику";

            // FORM PANEL
            this.pnlForm.BackColor =
                Color.FromArgb(18, 38, 74);

            this.pnlForm.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlForm.Location =
                new Point(25, 95);

            this.pnlForm.Size =
                new Size(710, 420);

            // FORM TITLE
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold);

            this.lblFormTitle.ForeColor =
                Color.FromArgb(212, 160, 23);

            this.lblFormTitle.Location =
                new Point(20, 16);

            this.lblFormTitle.Text =
                "ДАННЫЕ ЗАЯВКИ";

            // EMPLOYEE LABEL
            ConfigureLabel(
                this.lblEmployee,
                "Сотрудник",
                22,
                58);

            // EMPLOYEE COMBO
            ConfigureComboBox(
                this.cmbEmployee,
                22,
                82,
                665);

            // CATEGORY LABEL
            ConfigureLabel(
                this.lblCategory,
                "Категория имущества",
                22,
                130);

            // CATEGORY COMBO
            ConfigureComboBox(
                this.cmbCategory,
                22,
                154,
                665);

            // EQUIPMENT LABEL
            ConfigureLabel(
                this.lblEquipment,
                "Имущество",
                22,
                202);

            // EQUIPMENT COMBO
            ConfigureComboBox(
                this.cmbEquipment,
                22,
                226,
                665);

            this.lblEquipmentHint.AutoSize = true;

            this.lblEquipmentHint.Font =
                new Font(
                    "Segoe UI",
                    8.5F);

            this.lblEquipmentHint.ForeColor =
                Color.Gainsboro;

            this.lblEquipmentHint.Location =
                new Point(24, 262);

            this.lblEquipmentHint.Text =
                "Сначала выберите категорию.";

            // DATE LABEL
            ConfigureLabel(
                this.lblRequestDate,
                "Дата заявки",
                22,
                292);

            // DATE PICKER
            this.dtpRequestDate.Location =
                new Point(22, 316);

            this.dtpRequestDate.Size =
                new Size(200, 23);

            this.dtpRequestDate.Format =
                DateTimePickerFormat.Short;

            this.dtpRequestDate.CalendarMonthBackground =
                Color.White;

            // COMMENT LABEL
            ConfigureLabel(
                this.lblComment,
                "Комментарий",
                250,
                292);

            // COMMENT TEXTBOX
            this.txtComment.Location =
                new Point(250, 316);

            this.txtComment.Size =
                new Size(437, 65);

            this.txtComment.BackColor =
                Color.FromArgb(30, 58, 117);

            this.txtComment.ForeColor =
                Color.White;

            this.txtComment.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtComment.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.txtComment.Multiline = true;

            this.txtComment.ScrollBars =
                ScrollBars.Vertical;

            // ADD TO PANEL
            this.pnlForm.Controls.Add(
                this.lblFormTitle);

            this.pnlForm.Controls.Add(
                this.lblEmployee);

            this.pnlForm.Controls.Add(
                this.cmbEmployee);

            this.pnlForm.Controls.Add(
                this.lblCategory);

            this.pnlForm.Controls.Add(
                this.cmbCategory);

            this.pnlForm.Controls.Add(
                this.lblEquipment);

            this.pnlForm.Controls.Add(
                this.cmbEquipment);

            this.pnlForm.Controls.Add(
                this.lblEquipmentHint);

            this.pnlForm.Controls.Add(
                this.lblRequestDate);

            this.pnlForm.Controls.Add(
                this.dtpRequestDate);

            this.pnlForm.Controls.Add(
                this.lblComment);

            this.pnlForm.Controls.Add(
                this.txtComment);

            // CREATE BUTTON
            this.btnCreate.BackColor =
                Color.FromArgb(212, 160, 23);

            this.btnCreate.FlatStyle =
                FlatStyle.Flat;

            this.btnCreate.FlatAppearance.BorderSize = 1;

            this.btnCreate.FlatAppearance.BorderColor =
                Color.FromArgb(235, 190, 65);

            this.btnCreate.ForeColor =
                Color.White;

            this.btnCreate.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.btnCreate.Location =
                new Point(465, 540);

            this.btnCreate.Size =
                new Size(145, 36);

            this.btnCreate.Text =
                "Создать заявку";

            this.btnCreate.Cursor =
                Cursors.Hand;

            // CANCEL BUTTON
            this.btnCancel.BackColor =
                Color.FromArgb(42, 73, 133);

            this.btnCancel.FlatStyle =
                FlatStyle.Flat;

            this.btnCancel.FlatAppearance.BorderSize = 1;

            this.btnCancel.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            this.btnCancel.ForeColor =
                Color.White;

            this.btnCancel.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.btnCancel.Location =
                new Point(625, 540);

            this.btnCancel.Size =
                new Size(110, 36);

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.Cursor =
                Cursors.Hand;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigureLabel(
            Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.Location =
                new Point(x, y);

            label.Text = text;
        }

        private void ConfigureComboBox(
            ComboBox comboBox,
            int x,
            int y,
            int width)
        {
            comboBox.Location =
                new Point(x, y);

            comboBox.Size =
                new Size(width, 28);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.BackColor =
                Color.FromArgb(30, 58, 117);

            comboBox.ForeColor =
                Color.White;

            comboBox.FlatStyle =
                FlatStyle.Flat;

            comboBox.Font =
                new Font(
                    "Segoe UI",
                    9F);
        }
    }
}