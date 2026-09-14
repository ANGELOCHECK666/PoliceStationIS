using System;
using System.Windows.Forms;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class ContactDataPage : UserControl
    {
        public string Phone =>
            ValidationHelper.FormatPhone(txtPhone.Text);

        public string ResidentialAddress =>
            txtAddress.Text.Trim();

        public ContactDataPage()
        {
            InitializeComponent();

            // Телефон форматируется только после завершения ввода,
            // чтобы пользователь мог сначала спокойно ввести цифры подряд.
            txtPhone.KeyDown += TxtPhone_KeyDown;
            txtPhone.Leave += TxtPhone_Leave;

            // Адрес проверяем при переходе к следующему полю.
            txtAddress.Leave += TxtAddress_Leave;
        }

        private void TxtPhone_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            // Enter и пробел считаем завершением ввода номера.
            if (e.KeyCode == Keys.Enter ||
                e.KeyCode == Keys.Space)
            {
                FormatPhoneField();
                e.SuppressKeyPress = true;
            }
        }

        private void TxtPhone_Leave(
            object sender,
            EventArgs e)
        {
            FormatPhoneField();
        }

        private void FormatPhoneField()
        {
            string phone = txtPhone.Text.Trim();

            if (!ValidationHelper.IsFilled(phone))
                return;

            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show(
                    "Введите номер телефона из 10 цифр " +
                    "или 11 цифр с кодом 7 или 8.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            txtPhone.Text =
                ValidationHelper.FormatPhone(phone);

            txtPhone.SelectionStart =
                txtPhone.Text.Length;
        }

        private void TxtAddress_Leave(
            object sender,
            EventArgs e)
        {
            txtAddress.Text =
                txtAddress.Text.Trim();

            if (!ValidationHelper.IsFilled(
                    txtAddress.Text))
            {
                MessageBox.Show(
                    "Введите адрес проживания.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAddress.Focus();
            }
        }
    }
}