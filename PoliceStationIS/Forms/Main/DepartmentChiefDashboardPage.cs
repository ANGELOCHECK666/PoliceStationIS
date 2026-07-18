using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class DepartmentChiefDashboardPage : UserControl
    {
        public DepartmentChiefDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnAssignExpertise.Click += BtnAssignExpertise_Click;
            btnCreatePatrol.Click += BtnCreatePatrol_Click;
            btnCreateCase.Click += BtnCreateCase_Click;
        }

        // =====================================
        // STATISTICS
        // =====================================

        private void LoadStatistics()
        {
            lblEmployeesCount.Text = "124";
            lblCasesCount.Text = "48";
            lblExpertisesCount.Text = "17";
            lblPatrolsCount.Text = "12";
        }

        // =====================================
        // RECENT EVENTS
        // =====================================

        private void LoadRecentEvents()
        {
            dgvEvents.Rows.Clear();

            dgvEvents.Rows.Add(
                "18.07.2026",
                "08:15",
                "Назначена судебная экспертиза",
                "Дело №24158");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "08:42",
                "Создан новый наряд",
                "Наряд №153");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "09:18",
                "Открыто уголовное дело",
                "Дело №24161");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "10:05",
                "Назначен ответственный следователь",
                "Дело №24160");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "10:47",
                "Добавлен новый сотрудник",
                "Иванов И.И.");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "11:30",
                "Экспертиза завершена",
                "Экспертиза №518");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "12:12",
                "Наряд отправлен на маршрут",
                "Наряд №154");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "13:05",
                "Получено заключение эксперта",
                "Дело №24157");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "14:21",
                "Создано новое уголовное дело",
                "Дело №24162");

            dgvEvents.Rows.Add(
                "18.07.2026",
                "15:03",
                "Изменён статус расследования",
                "Дело №24156");
        }

        // =====================================
        // QUICK ACTIONS
        // =====================================

        private void BtnAssignExpertise_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма назначения экспертизы пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnCreatePatrol_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма оформления наряда пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnCreateCase_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма создания уголовного дела пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }
    }
}