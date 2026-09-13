using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Cases
{
    partial class CloseCaseForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Panel pnlMain;
        private Label lblCaseNumber;
        private Label lblCaseNumberValue;
        private Label lblCurrentStatus;
        private Label lblCurrentStatusValue;
        private Label lblTarget;
        private Label lblTargetStatus;
        private Label lblQuestion;
        private Button btnConfirm;
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblTitle = new Label();
            this.pnlMain = new Panel();

            this.lblCaseNumber = new Label();
            this.lblCaseNumberValue = new Label();

            this.lblCurrentStatus = new Label();
            this.lblCurrentStatusValue = new Label();

            this.lblTarget = new Label();
            this.lblTargetStatus = new Label();

            this.lblQuestion = new Label();

            this.btnConfirm = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            //========================================================
            // FORM
            //========================================================

            this.AutoScaleMode =
                AutoScaleMode.None;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.ClientSize =
                new Size(
                    540,
                    330);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Закрытие дела";

            //========================================================
            // TITLE
            //========================================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    17F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(
                    28,
                    22);

            this.lblTitle.Text =
                "Закрытие дела";

            //========================================================
            // MAIN PANEL
            //========================================================

            this.pnlMain.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            this.pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlMain.Location =
                new Point(
                    20,
                    68);

            this.pnlMain.Size =
                new Size(
                    500,
                    190);

            //========================================================
            // CASE NUMBER
            //========================================================

            ConfigureLabel(
                this.lblCaseNumber,
                "Номер дела:",
                20,
                20);

            ConfigureValueLabel(
                this.lblCaseNumberValue,
                180,
                20);

            //========================================================
            // CURRENT STATUS
            //========================================================

            ConfigureLabel(
                this.lblCurrentStatus,
                "Текущий статус:",
                20,
                58);

            ConfigureValueLabel(
                this.lblCurrentStatusValue,
                180,
                58);

            //========================================================
            // TARGET STATUS
            //========================================================

            ConfigureLabel(
                this.lblTarget,
                "Новый статус:",
                20,
                96);

            this.lblTargetStatus.AutoSize = false;

            this.lblTargetStatus.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.lblTargetStatus.ForeColor =
                Color.FromArgb(
                    138,
                    196,
                    76);

            this.lblTargetStatus.Location =
                new Point(
                    180,
                    96);

            this.lblTargetStatus.Size =
                new Size(
                    280,
                    25);

            this.lblTargetStatus.Text =
                "Закрыто";

            this.lblQuestion.AutoSize = false;

            this.lblQuestion.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblQuestion.ForeColor =
                Color.Gainsboro;

            this.lblQuestion.Location =
                new Point(
                    20,
                    135);

            this.lblQuestion.Size =
                new Size(
                    455,
                    42);

            this.lblQuestion.Text =
                "Изменить статус выбранного дела?";

            //========================================================
            // ADD PANEL CONTROLS
            //========================================================

            this.pnlMain.Controls.Add(
                this.lblCaseNumber);

            this.pnlMain.Controls.Add(
                this.lblCaseNumberValue);

            this.pnlMain.Controls.Add(
                this.lblCurrentStatus);

            this.pnlMain.Controls.Add(
                this.lblCurrentStatusValue);

            this.pnlMain.Controls.Add(
                this.lblTarget);

            this.pnlMain.Controls.Add(
                this.lblTargetStatus);

            this.pnlMain.Controls.Add(
                this.lblQuestion);

            //========================================================
            // CONFIRM BUTTON
            //========================================================

            ConfigureButton(
                this.btnConfirm,
                "Закрыть дело",
                270,
                275,
                135,
                38,
                true);

            //========================================================
            // CANCEL BUTTON
            //========================================================

            ConfigureButton(
                this.btnCancel,
                "Отмена",
                415,
                275,
                105,
                38,
                false);

            //========================================================
            // FORM CONTROLS
            //========================================================

            this.Controls.Add(
                this.lblTitle);

            this.Controls.Add(
                this.pnlMain);

            this.Controls.Add(
                this.btnConfirm);

            this.Controls.Add(
                this.btnCancel);

            //========================================================
            // EVENTS
            //========================================================

            this.btnConfirm.Click +=
                BtnConfirm_Click;

            this.btnCancel.Click +=
                BtnCancel_Click;

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

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.Gainsboro;

            label.Location =
                new Point(
                    x,
                    y);

            label.Text =
                text;
        }

        private void ConfigureValueLabel(
            Label label,
            int x,
            int y)
        {
            label.AutoSize = false;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.White;

            label.Location =
                new Point(
                    x,
                    y);

            label.Size =
                new Size(
                    290,
                    25);

            label.Text =
                "";
        }

        private void ConfigureButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height,
            bool confirm)
        {
            button.Text = text;

            button.Location =
                new Point(
                    x,
                    y);

            button.Size =
                new Size(
                    width,
                    height);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                confirm
                ? Color.FromArgb(
                    42,
                    73,
                    133)
                : Color.FromArgb(
                    30,
                    58,
                    117);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.UseVisualStyleBackColor = false;
        }

        #endregion
    }
}