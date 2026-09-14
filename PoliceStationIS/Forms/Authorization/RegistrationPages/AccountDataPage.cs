using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class AccountDataPage : UserControl
    {
        public string Login =>
            txtLogin.Text.Trim();

        public string Email =>
            txtEmail.Text.Trim();

        public string Password =>
            txtPassword.Text;

        public AccountDataPage()
        {
            InitializeComponent();

            txtLogin.Leave += TxtLogin_Leave;
            txtEmail.Leave += TxtEmail_Leave;
            txtPassword.Leave += Password_Leave;
            txtConfirmPassword.Leave += ConfirmPassword_Leave;
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void TxtLogin_Leave(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();

            if (!ValidationHelper.IsFilled(login))
                return;

            if (!ValidationHelper.IsValidLogin(login))
            {
                MessageBox.Show(
                    "Логин должен содержать от 5 до 50 символов: ", 
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLogin.Focus();
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (!ValidationHelper.IsFilled(email))
                return;

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show(
                    "Введите корректный адрес электронной почты.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsFilled(txtPassword.Text))
                return;

            if (!ValidationHelper.IsValidPassword(txtPassword.Text))
            {
                MessageBox.Show(
                    "Пароль должен содержать минимум 8 символов, " +
                    "буквы и цифры.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
            }
        }

        private void ConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsFilled(txtConfirmPassword.Text))
                return;

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Пароли не совпадают.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                panelStrength.Width = 0;
                lblStrength.Text = "Надёжность пароля: —";
                return;
            }

            int score = 0;

            if (password.Length >= 8)
                score++;

            if (password.Any(char.IsUpper))
                score++;

            if (password.Any(char.IsDigit))
                score++;

            if (password.Any(ch => !char.IsLetterOrDigit(ch)))
                score++;

            switch (score)
            {
                case 1:
                    panelStrength.Width = 60;
                    panelStrength.BackColor =
                        Color.FromArgb(120, 170, 60);
                    lblStrength.Text =
                        "Надёжность пароля: слабая";
                    break;

                case 2:
                    panelStrength.Width = 120;
                    panelStrength.BackColor =
                        Color.FromArgb(145, 190, 70);
                    lblStrength.Text =
                        "Надёжность пароля: средняя";
                    break;

                case 3:
                    panelStrength.Width = 180;
                    panelStrength.BackColor =
                        Color.FromArgb(170, 210, 80);
                    lblStrength.Text =
                        "Надёжность пароля: хорошая";
                    break;

                case 4:
                    panelStrength.Width = 240;
                    panelStrength.BackColor =
                        Color.FromArgb(190, 230, 90);
                    lblStrength.Text =
                        "Надёжность пароля: высокая";
                    break;
            }
        }
    }
}
