namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    partial class ConfirmationPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.lblTitle =
                new System.Windows.Forms.Label();

            this.richSummary =
                new System.Windows.Forms.RichTextBox();
            this.btnRegister =
    new System.Windows.Forms.Button();

            this.SuspendLayout();

            // ======================================
            // Заголовок страницы
            // ======================================

            this.lblTitle.AutoSize = true;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Location =
                new System.Drawing.Point(
                    20,
                    15);

            this.lblTitle.Text =
                "Подтверждение регистрации";


            // ======================================
            // Область просмотра данных
            // ======================================

            this.richSummary.Location =
                new System.Drawing.Point(
                    20,
                    60);

            this.richSummary.Size =
                new System.Drawing.Size(
                    700,
                    290);

            this.richSummary.ReadOnly = true;

            this.richSummary.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.richSummary.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.richSummary.ForeColor =
                System.Drawing.Color.White;

            this.richSummary.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.richSummary.Text =
                "Проверьте введённые данные перед завершением регистрации.";

            // ======================================
            // Кнопка регистрации
            // ======================================

            this.btnRegister.Location =
                new System.Drawing.Point(
                    560,
                    365);

            this.btnRegister.Size =
                new System.Drawing.Size(
                    160,
                    40);

            this.btnRegister.Text =
                "Зарегистрировать";

            this.btnRegister.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.btnRegister.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRegister.BackColor =
                System.Drawing.Color.FromArgb(
                    70,
                    115,
                    200);

            this.btnRegister.ForeColor =
                System.Drawing.Color.White;

            // ======================================
            // Добавляем элементы на страницу
            // ======================================

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.richSummary);
            this.Controls.Add(this.btnRegister);


            // ======================================
            // Настройка страницы
            // ======================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    31,
                    59,
                    105);

            this.Name =
                "ConfirmationPage";

            this.Size =
                new System.Drawing.Size(
                    770,
                    430);

            this.PerformLayout();

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.RichTextBox richSummary;

        private System.Windows.Forms.Button btnRegister;

        #endregion
    }
}