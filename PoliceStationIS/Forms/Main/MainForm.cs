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

            switch (UserSession.RoleName)
            {
                case "Кадровик":

                    page =
                        new HRDashboardPage();

                    break;

                case "Следователь":

                    // позже создадим
                    page =
                        new HRDashboardPage();

                    break;

                case "Кинолог":

                    // позже создадим
                    page =
                        new HRDashboardPage();

                    break;

                default:

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
            panelContent.Controls.Clear();

            EmployeesPage page =
                new EmployeesPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
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
    }
}