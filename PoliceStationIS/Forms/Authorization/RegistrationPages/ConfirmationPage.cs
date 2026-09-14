using System;
using System.Windows.Forms;
using PoliceStationIS.Models;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class ConfirmationPage : UserControl
    {
        public event EventHandler RegisterClicked;

        public ConfirmationPage()
        {
            InitializeComponent();

            btnRegister.Click += BtnRegister_Click;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterClicked?.Invoke(this, EventArgs.Empty);
        }

        public void LoadData(RegistrationData data)
        {
            lblPersonalData.Text =
                $"Фамилия: {data.LastName}\r\n" +
                $"Имя: {data.FirstName}\r\n" +
                $"Отчество: {data.MiddleName}\r\n" +
                $"Дата рождения: {data.BirthDate:d}\r\n" +
                $"Пол: {data.Gender}\r\n" +
                $"Звание: {data.Rank}";

            lblPassportData.Text =
                $"Серия: {data.PassportSeries}\r\n" +
                $"Номер: {data.PassportNumber}\r\n" +
                $"Код подразделения: {data.DepartmentCode}\r\n" +
                $"Кем выдан: {data.IssuedBy}\r\n" +
                $"Дата выдачи: {data.IssueDate:d}";

            lblContactsData.Text =
                $"Телефон: {data.Phone}\r\n\r\n" +
                $"Адрес: {data.ResidentialAddress}";

            lblAccountData.Text =
                $"Логин: {data.Login}\r\n\r\n" +
                $"Email: {data.Email}";
        }
    }
}
