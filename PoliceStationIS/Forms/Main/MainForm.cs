using PoliceStationIS.Core;
using PoliceStationIS.Forms.Employees;
using PoliceStationIS.Forms.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class MainForm : Form
    {
        private Timer clockTimer;

        public MainForm()
        {
            InitializeComponent();

            ConfigureHeader();

            ConfigureAccess();

            OpenDashboard();

            btnEmployees.Click += BtnEmployees_Click;
            btnDashboard.Click += BtnDashboard_Click;

            StartClock();
        }


        private void ConfigureHeader()
        {
            lblUserName.Text =
                UserSession.FullName;

            lblPosition.Text =
                UserSession.PostName;
        }

        private void ConfigureAccess()
        {
            switch (UserSession.RoleName)
            {
                case "Кадровик":

                    btnCases.Visible = false;
                    btnCitizens.Visible = false;
                    btnProtocols.Visible = false;
                    btnEvidence.Visible = false;
                    btnExpertise.Visible = false;
                    btnDuty.Visible = false;
                    btnEquipment.Visible = false;
                    btnDogs.Visible = false;

                    break;
            }
        }

        private void OpenDashboard()
        {
            UserControl page = null;

            switch (UserSession.PostName)
            {
                case "Архивариус":
                case "Специалист по кадрам":
                case "Кадровик":

                    page =
                        new HRDashboardPage();

                    break;

                case "Следователь":
                case "Старший следователь":
                case "Оперуполномоченный":
                case "Старший оперуполномоченный":
                case "Дознаватель":
                case "Помощник следователя":
                case "Полицейский":
                case "Старший полицейский":

                    page =
                        new InvestigatorDashboardPage();

                    break;

                case "Кинолог":
                case "Инструктор-кинолог":

                    page =
                        new DogHandlerDashboardPage();

                    break;

                case "Инспектор":
                case "Старший инспектор":
                case "Участковый уполномоченный полиции":
                case "Сотрудник ППС":
                case "Сотрудник конвоя":
                case "Инспектор ДПС":

                    // позже создадим
                    page =
                        new HRDashboardPage();

                    break;

                case "Инженер":
                case "Специалист по материально-техническому обеспечению":
                case "Старший специалист по материально-техническому обеспечению":
                case "Заведующий складом":

                    // позже создадим
                    page =
                        new HRDashboardPage();

                    break;

                case "Начальник отдела":
                case "Заместитель начальника отдела":
                case "Командир отделения":
                case "Командир взвода":

                    page =
                        new DepartmentChiefDashboardPage();

                    break;

                case "Генерал полиции":

                    page =
                        new GeneralPoliceDashboardPage();

                    break;

                case "Эксперт-криминалист":
                case "Старший эксперт-криминалист":
                case "Техник-криминалист":
                case "Специалист-криминалист":

                    page =
                        new CriminalistDashboardPage();

                    break;

                case "Дежурный":
                case "Помощник дежурного":
                case "Оперативный дежурный":
                case "Специалист связи":

                    // позже создадим
                    page =
                        new HRDashboardPage();

                    break;
            }

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(
                page);
        }

        private void BtnEmployees_Click(
    object sender,
    EventArgs e)
        {
            OpenEmployeesPage();
        }

        private void StartClock()
        {
            clockTimer =
                new Timer();

            clockTimer.Interval = 1000;

            clockTimer.Tick += ClockTimer_Tick;

            ClockTimer_Tick(
                null,
                EventArgs.Empty);

            clockTimer.Start();
        }

        private void ClockTimer_Tick(
            object sender,
            EventArgs e)
        {
            lblTime.Text =
                DateTime.Now.ToString(
                    "HH:mm:ss");

            lblDate.Text =
                DateTime.Now.ToString(
                    "dd.MM.yyyy");
        }

        private void BtnDashboard_Click(
    object sender,
    EventArgs e)
        {
            OpenDashboard();
        }

        public void OpenEmployeesPage()
        {
            panelContent.Controls.Clear();

            EmployeesPage page =
                new EmployeesPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }
    }
}