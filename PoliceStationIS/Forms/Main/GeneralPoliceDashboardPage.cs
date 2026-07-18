using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class GeneralPoliceDashboardPage : UserControl
    {
        public GeneralPoliceDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnReports.Click += BtnReports_Click;
            btnStatistics.Click += BtnStatistics_Click;
            btnDepartments.Click += BtnDepartments_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblEmployeesCount.Text = "284";
                lblCasesCount.Text = "91";
                lblPatrolsCount.Text = "36";
                lblDepartmentsCount.Text = "12";
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
                    "08:15",
                    "● Зарегистрировано новое уголовное дело",
                    "Следственный отдел");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "09:40",
                    "● Назначен дополнительный наряд",
                    "ППС");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "11:10",
                    "● Завершена судебная экспертиза",
                    "Криминалистика");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "13:25",
                    "● Принят новый сотрудник",
                    "Отдел кадров");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "15:30",
                    "● Обновлена служебная техника",
                    "Отдел имущества");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "16:45",
                    "● Назначен кинологический наряд",
                    "Кинологическая служба");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "10:20",
                    "● Закрыто уголовное дело",
                    "Следственный отдел");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "14:10",
                    "● Проведена инвентаризация",
                    "Отдел имущества");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "09:35",
                    "● Обновлена статистика преступности",
                    "Аналитический отдел");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "17:00",
                    "● Сформирован ежедневный отчёт",
                    "Главное управление");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
        }

        private void BtnReports_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница отчётов пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnStatistics_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница статистики пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnDepartments_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница контроля подразделений пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}