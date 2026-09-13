using PoliceStationIS.Core;
using PoliceStationIS.Forms.Cases;
using PoliceStationIS.Forms.Citizens;
using PoliceStationIS.Forms.Employees;
using PoliceStationIS.Forms.Equipment;
using PoliceStationIS.Forms.Evidence;
using PoliceStationIS.Forms.Expertises;
using PoliceStationIS.Forms.Main;
using PoliceStationIS.Forms.Protocols;
using PoliceStationIS.Forms.Squads;
using PoliceStationIS.Forms.Dogs;
using PoliceStationIS.Forms.Statistics;
using PoliceStationIS.Forms.Departments;
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
            btnCases.Click += BtnCases_Click;
            btnCitizens.Click += BtnCitizens_Click;
            btnProtocols.Click += BtnProtocols_Click;
            btnEvidence.Click += BtnEvidence_Click;
            btnExpertise.Click += BtnExpertises_Click;
            btnDuty.Click += BtnSquads_Click;
            btnEquipment.Click += BtnEquipment_Click;
            btnStatistics.Click += BtnStatistics_Click;
            btnDepartments.Click += BtnDepartments_Click;
            btnDogs.Click += BtnDogs_Click;
            btnExit.Click += BtnExit_Click;


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
            // Все пункты меню остаются видимыми для всех пользователей.
            // Проверка выполняется непосредственно при попытке открыть раздел.
        }

        private bool HasAccess(string pageName)
        {
            string postName = UserSession.PostName;

            switch (postName)
            {
                // Генерал — полный доступ ко всем разделам.
                case "Генерал полиции":
                    return true;

                // Начальник отдела и приравненные должности:
                // доступ ко всему, кроме DepartmentsPage и StatisticsPage.
                case "Начальник отдела":
                case "Заместитель начальника отдела":
                case "Командир отделения":
                case "Командир взвода":
                    return pageName != "DepartmentsPage"
                        && pageName != "StatisticsPage";

                // Кадровая группа — только CitizensPage.
                case "Архивариус":
                case "Специалист по кадрам":
                case "Кадровик":
                    return pageName == "EmployeesPage";

                // Следственная группа:
                // доступ ко всем основным рабочим разделам,
                // кроме DepartmentsPage, StatisticsPage, DogsPage и SquadsPage.
                case "Следователь":
                case "Старший следователь":
                case "Оперуполномоченный":
                case "Старший оперуполномоченный":
                case "Дознаватель":
                case "Помощник следователя":
                case "Полицейский":
                case "Старший полицейский":
                    return pageName != "DepartmentsPage"
                        && pageName != "StatisticsPage"
                        && pageName != "DogsPage"
                        && pageName != "SquadsPage";

                // Криминалистическая группа — только ExpertisesPage и EvidencePage.
                case "Эксперт-криминалист":
                case "Старший эксперт-криминалист":
                case "Техник-криминалист":
                case "Специалист-криминалист":
                    return pageName == "ExpertisesPage"
                        || pageName == "EvidencePage";

                // Кинологическая группа — DogsPage, SquadsPage, EquipmentPage.
                case "Кинолог":
                case "Инструктор-кинолог":
                    return pageName == "DogsPage"
                        || pageName == "SquadsPage"
                        || pageName == "EquipmentPage";

                // Дежурная группа — CitizensPage и SquadsPage.
                case "Дежурный":
                case "Помощник дежурного":
                case "Оперативный дежурный":
                case "Специалист связи":
                    return pageName == "CitizensPage"
                        || pageName == "SquadsPage";

                // Инспекторская группа — SquadsPage и EquipmentPage.
                case "Инспектор":
                case "Старший инспектор":
                case "Участковый уполномоченный полиции":
                case "Сотрудник ППС":
                case "Сотрудник конвоя":
                case "Инспектор ДПС":
                    return pageName == "SquadsPage"
                        || pageName == "EquipmentPage";

                // МТО — только EquipmentPage.
                case "Инженер":
                case "Специалист по материально-техническому обеспечению":
                case "Старший специалист по материально-техническому обеспечению":
                case "Заведующий складом":
                    return pageName == "EquipmentPage";

                default:
                    return false;
            }
        }

        private void ShowAccessDeniedMessage()
        {
            MessageBox.Show(
                "У вас недостаточно прав доступа к данному разделу.",
                "Доступ запрещён",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
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

                    page =
                        new InspectorDashboardPage();

                    break;

                case "Инженер":
                case "Специалист по материально-техническому обеспечению":
                case "Старший специалист по материально-техническому обеспечению":
                case "Заведующий складом":

                    page =
                        new MTODashboardPage();

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

                    page =
                        new DutyOfficerDashboardPage();

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
            if (!HasAccess("EmployeesPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenEmployeesPage();
        }

        private void BtnCases_Click(
    object sender,
    EventArgs e)
        {
            if (!HasAccess("CasesPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenCasesPage();
        }

        private void BtnCitizens_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("CitizensPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenCitizensPage();
        }

        private void BtnProtocols_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("ProtocolsPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenProtocolsPage();
        }

        private void BtnEvidence_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("EvidencePage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenEvidencePage();
        }

        private void BtnExpertises_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("ExpertisesPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenExpertisesPage();
        }

        private void BtnSquads_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("SquadsPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenSquadsPage();
        }

        private void BtnEquipment_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("EquipmentPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenEquipmentPage();
        }

        private void BtnDogs_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("DogsPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenDogsPage();
        }

        private void BtnStatistics_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("StatisticsPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenStatisticsPage();
        }

        private void BtnDepartments_Click(
            object sender,
            EventArgs e)
        {
            if (!HasAccess("DepartmentsPage"))
            {
                ShowAccessDeniedMessage();
                return;
            }

            OpenDepartmentsPage();
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
        public void OpenCasesPage()
        {
            panelContent.Controls.Clear();

            CasesPage page =
                new CasesPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenCitizensPage()
        {
            panelContent.Controls.Clear();

            CitizensPage page =
                new CitizensPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenProtocolsPage()
        {
            panelContent.Controls.Clear();

            ProtocolsPage page =
                new ProtocolsPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenEvidencePage()
        {
            panelContent.Controls.Clear();

            EvidencePage page =
                new EvidencePage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenExpertisesPage()
        {
            panelContent.Controls.Clear();

            ExpertisesPage page =
                new ExpertisesPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenSquadsPage()
        {
            panelContent.Controls.Clear();

            SquadsPage page =
                new SquadsPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenEquipmentPage()
        {
            panelContent.Controls.Clear();

            EquipmentPage page =
                new EquipmentPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenDogsPage()
        {
            panelContent.Controls.Clear();

            DogsPage page =
                new DogsPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenStatisticsPage()
        {
            panelContent.Controls.Clear();

            StatisticsPage page =
                new StatisticsPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        public void OpenDepartmentsPage()
        {
            panelContent.Controls.Clear();

            DepartmentsPage page =
                new DepartmentsPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        private void BtnExit_Click(
    object sender,
    EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Вы действительно хотите выйти из системы?",
                    "Выход",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result ==
                DialogResult.Yes)
            {
                if (clockTimer != null)
                {
                    clockTimer.Stop();
                }

                Close();
            }
        }
    }
}