using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoliceStationIS.Models;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class ConfirmationPage : UserControl
    {
        public event EventHandler RegisterClicked;
        public ConfirmationPage()
        {
            InitializeComponent();

            btnRegister.Click +=
                BtnRegister_Click;
        }
        private void BtnRegister_Click(
    object sender,
    EventArgs e)
        {
            RegisterClicked?.Invoke(
                this,
                EventArgs.Empty);
        }

        public void LoadData(
            RegistrationData data)
        {
            richSummary.Text =
                "Проверьте введённые данные перед завершением регистрации.\r\n\r\n" +

                "ЛИЧНЫЕ ДАННЫЕ\r\n" +
                "----------------------------------------\r\n" +

                $"Фамилия: {data.LastName}\r\n" +
                $"Имя: {data.FirstName}\r\n" +
                $"Отчество: {data.MiddleName}\r\n" +
                $"Дата рождения: {data.BirthDate}\r\n" +
                $"Пол: {data.Gender}\r\n" +
                $"Должность: {data.Position}\r\n" +
                $"Подразделение: {data.Department}\r\n" +
                $"Звание: {data.Rank}\r\n\r\n" +

                "ПАСПОРТНЫЕ ДАННЫЕ\r\n" +
                "----------------------------------------\r\n" +

                $"Серия паспорта: {data.PassportSeries}\r\n" +
                $"Номер паспорта: {data.PassportNumber}\r\n" +
                $"Код подразделения: {data.DepartmentCode}\r\n" +
                $"Кем выдан: {data.IssuedBy}\r\n" +
                $"Дата выдачи: {data.IssueDate}\r\n" +
                $"Адрес регистрации: {data.RegistrationAddress}\r\n\r\n" +

                "КОНТАКТНЫЕ ДАННЫЕ\r\n" +
                "----------------------------------------\r\n" +

                $"Телефон: {data.Phone}\r\n" +
                $"Адрес проживания: {data.ResidentialAddress}\r\n\r\n" +

                "УЧЁТНАЯ ЗАПИСЬ\r\n" +
                "----------------------------------------\r\n" +

                $"Логин: {data.Login}\r\n" +
                $"Email: {data.Email}";
        }
    }
}
