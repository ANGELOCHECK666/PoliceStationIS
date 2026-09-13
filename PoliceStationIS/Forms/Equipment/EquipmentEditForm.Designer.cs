using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Equipment
{
    partial class EquipmentEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlMain;

        private Label lblEquipmentName;
        private TextBox txtEquipmentName;

        private Label lblCategory;
        private ComboBox cmbCategory;

        private Label lblStatus;
        private ComboBox cmbStatus;

        private Label lblEmployee;
        private ComboBox cmbEmployee;

        private Label lblIssueDate;
        private DateTimePicker dtpIssueDate;

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

            this.lblTitle = new Label();
            this.lblSubtitle = new Label();

            this.pnlMain = new Panel();

            this.lblEquipmentName = new Label();
            this.txtEquipmentName = new TextBox();

            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();

            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();

            this.lblEmployee = new Label();
            this.cmbEmployee = new ComboBox();

            this.lblIssueDate = new Label();
            this.dtpIssueDate = new DateTimePicker();

            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // FORM
            this.BackColor =
                Color.FromArgb(12, 29, 58);

            this.ClientSize =
                new Size(650, 470);

            this.FormBorderStyle =
                FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Добавление имущества";

            this.Name =
                "EquipmentEditForm";

            this.ShowInTaskbar = false;

            // TITLE
            this.lblTitle.Text =
                "Добавление имущества";

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(28, 22);

            this.lblTitle.AutoSize =
                true;

            // SUBTITLE
            this.lblSubtitle.Text =
                "Заполнение данных служебного имущества";

            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(30, 59);

            this.lblSubtitle.AutoSize =
                true;

            // MAIN PANEL
            this.pnlMain.BackColor =
                Color.FromArgb(18, 38, 74);

            this.pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlMain.Location =
                new Point(20, 95);

            this.pnlMain.Size =
                new Size(610, 350);

            // NAME
            this.lblEquipmentName.Text =
                "Наименование";

            this.lblEquipmentName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblEquipmentName.ForeColor =
                Color.Gainsboro;

            this.lblEquipmentName.Location =
                new Point(22, 20);

            this.lblEquipmentName.AutoSize =
                true;

            this.txtEquipmentName.Location =
                new Point(22, 45);

            this.txtEquipmentName.Size =
                new Size(566, 27);

            this.txtEquipmentName.BackColor =
                Color.FromArgb(30, 58, 117);

            this.txtEquipmentName.ForeColor =
                Color.White;

            this.txtEquipmentName.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtEquipmentName.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // CATEGORY
            this.lblCategory.Text =
                "Категория";

            this.lblCategory.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblCategory.ForeColor =
                Color.Gainsboro;

            this.lblCategory.Location =
                new Point(22, 88);

            this.lblCategory.AutoSize =
                true;

            this.cmbCategory.Location =
                new Point(22, 113);

            this.cmbCategory.Size =
                new Size(275, 27);

            // STATUS
            this.lblStatus.Text =
                "Статус";

            this.lblStatus.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblStatus.ForeColor =
                Color.Gainsboro;

            this.lblStatus.Location =
                new Point(313, 88);

            this.lblStatus.AutoSize =
                true;

            this.cmbStatus.Location =
                new Point(313, 113);

            this.cmbStatus.Size =
                new Size(275, 27);

            // EMPLOYEE
            this.lblEmployee.Text =
                "Выдано сотруднику";

            this.lblEmployee.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblEmployee.ForeColor =
                Color.Gainsboro;

            this.lblEmployee.Location =
                new Point(22, 156);

            this.lblEmployee.AutoSize =
                true;

            this.cmbEmployee.Location =
                new Point(22, 181);

            this.cmbEmployee.Size =
                new Size(566, 27);

            // DATE
            this.lblIssueDate.Text =
                "Дата выдачи";

            this.lblIssueDate.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblIssueDate.ForeColor =
                Color.Gainsboro;

            this.lblIssueDate.Location =
                new Point(22, 224);

            this.lblIssueDate.AutoSize =
                true;

            this.dtpIssueDate.Location =
                new Point(22, 249);

            this.dtpIssueDate.Size =
                new Size(200, 27);

            this.dtpIssueDate.Format =
                DateTimePickerFormat.Short;

            // SAVE
            this.btnSave.Text =
                "Сохранить";

            this.btnSave.Location =
                new Point(325, 300);

            this.btnSave.Size =
                new Size(125, 36);

            ConfigureButton(this.btnSave);

            // CANCEL
            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.Location =
                new Point(463, 300);

            this.btnCancel.Size =
                new Size(125, 36);

            ConfigureButton(this.btnCancel);

            // PANEL CONTROLS
            this.pnlMain.Controls.Add(
                this.lblEquipmentName);

            this.pnlMain.Controls.Add(
                this.txtEquipmentName);

            this.pnlMain.Controls.Add(
                this.lblCategory);

            this.pnlMain.Controls.Add(
                this.cmbCategory);

            this.pnlMain.Controls.Add(
                this.lblStatus);

            this.pnlMain.Controls.Add(
                this.cmbStatus);

            this.pnlMain.Controls.Add(
                this.lblEmployee);

            this.pnlMain.Controls.Add(
                this.cmbEmployee);

            this.pnlMain.Controls.Add(
                this.lblIssueDate);

            this.pnlMain.Controls.Add(
                this.dtpIssueDate);

            this.pnlMain.Controls.Add(
                this.btnSave);

            this.pnlMain.Controls.Add(
                this.btnCancel);

            // FORM CONTROLS
            this.Controls.Add(
                this.lblTitle);

            this.Controls.Add(
                this.lblSubtitle);

            this.Controls.Add(
                this.pnlMain);

            this.ResumeLayout(false);
        }

        private void ConfigureButton(Button button)
        {
            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(42, 73, 133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;

            button.UseVisualStyleBackColor =
                false;
        }
    }
}