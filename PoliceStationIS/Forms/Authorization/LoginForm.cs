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

            MessageBox.Show(
                "Авторизация пока не подключена к базе данных.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            /*
             
            Здесь позже будет:

            UserService.Login(
                login,
                password);

            И открытие нужной
            главной формы по роли:

            Генерал
            Начальник отдела
            Администратор БД
            Следователь
            Криминалист
            Кинолог
            Инспектор
            Дежурный
            Специалист материального обеспечения

            */
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
    }
}