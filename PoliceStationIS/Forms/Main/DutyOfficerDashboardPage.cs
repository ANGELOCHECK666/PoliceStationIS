using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class DutyOfficerDashboardPage : UserControl
    {
        public DutyOfficerDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnPatrols.Click += BtnPatrols_Click;
            btnCallLog.Click += BtnCallLog_Click;
            btnRegisterIncident.Click += BtnRegisterIncident_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblActivePatrolsCount.Text = "12";
                lblEmployeesShiftCount.Text = "48";
                lblIncidentsCount.Text = "9";
                lblCallsCount.Text = "27";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки статистики");
            }
        }

        private void LoadRecentEvents()
        {
            try
            {
                dgvEvents.Rows.Clear();

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "08:12",
                    "● Принят вызов",
                    "Вызов №154");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "08:18",
                    "● Наряд направлен",
                    "Наряд №12");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "09:05",
                    "● Зарегистрировано происшествие",
                    "№2026-318");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "09:47",
                    "● Наряд завершил выезд",
                    "Наряд №8");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "10:25",
                    "● Получен повторный вызов",
                    "Вызов №157");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "18:40",
                    "● Наряд направлен",
                    "Наряд №5");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "19:15",
                    "● Принят вызов",
                    "Вызов №148");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "20:30",
                    "● Зарегистрировано происшествие",
                    "№2026-311");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "21:05",
                    "● Наряд завершил выезд",
                    "Наряд №3");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "22:14",
                    "● Вызов закрыт",
                    "Вызов №148");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
        }

        private void BtnPatrols_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница активных нарядов пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnCallLog_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Журнал вызовов пока не подключен.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnRegisterIncident_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма регистрации происшествия пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}