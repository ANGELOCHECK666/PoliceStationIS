using PoliceStationIS.Core;
using PoliceStationIS.Forms.Main;
using PoliceStationIS.Models;
using PoliceStationIS.Services;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PoliceStationIS.Forms.Authorization
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            txtLogin.Enter += TxtLogin_Enter;
            txtLogin.Leave += TxtLogin_Leave;

            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Leave += TxtPassword_Leave;
        }

        private void LoginForm_Load(
            object sender,
            EventArgs e)
        {

        }

        #region Placeholder Login

        private void TxtLogin_Enter(
            object sender,
            EventArgs e)
        {
            if (txtLogin.Text ==
                "Введите логин")
            {
                txtLogin.Text = "";

                txtLogin.ForeColor =
                    Color.White;
            }
        }

        private void TxtLogin_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtLogin.Text))
            {
                txtLogin.Text =
                    "Введите логин";

                txtLogin.ForeColor =
                    Color.Gray;
            }
        }

        #endregion

        #region Placeholder Password

        private void TxtPassword_Enter(
            object sender,
            EventArgs e)
        {
            if (txtPassword.Text ==
                "Введите пароль")
            {
                txtPassword.Text = "";

                txtPassword.ForeColor =
                    Color.White;

                txtPassword.UseSystemPasswordChar =
                    true;
            }
        }

        private void TxtPassword_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar =
                    false;

                txtPassword.Text =
                    "Введите пароль";

                txtPassword.ForeColor =
                    Color.Gray;
            }
        }

        #endregion

        private void btnLogin_Click(
            object sender,
            EventArgs e)
        {
            string login =
                txtLogin.Text.Trim();

            string password =
                txtPassword.Text.Trim();

            if (login ==
                "Введите логин")
            {
                login = "";
            }

            if (password ==
                "Введите пароль")
            {
                password = "";
            }

            if (string.IsNullOrWhiteSpace(
                login))
            {
                MessageBox.Show(
                    "Введите логин.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLogin.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(
                password))
            {
                MessageBox.Show(
                    "Введите пароль.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();

                return;
            }

            try
            {
                AuthorizedUser user =
                    AuthorizationService.Login(
                        login,
                        password);

                if (user == null)
                {
                    MessageBox.Show(
                        "Неверный логин или пароль.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                UserSession.EmployeeId =
    user.EmployeeId;

                UserSession.FullName =
                    user.FullName;

                UserSession.PostName =
                    user.PostName;

                UserSession.RoleName =
                    user.RoleName;

                MessageBox.Show(
                    $"Добро пожаловать, {user.Login}!\nРоль: {user.RoleName}",
                    "Успешный вход",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Здесь позже будет открытие главной формы

                this.Hide();

                MainForm mainForm =
                    new MainForm();

                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lnkForgotPassword_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Функция восстановления пароля будет добавлена позже.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void lnkRegister_LinkClicked(
    object sender,
    LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            RegisterForm registerForm =
                new RegisterForm();

            registerForm.ShowDialog();

            this.Show();
        }
    }

}