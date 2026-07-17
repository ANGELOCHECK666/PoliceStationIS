using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class DogHandlerDashboardPage : UserControl
    {
        public DogHandlerDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnAddDog.Click += BtnAddDog_Click;
            btnViewDogs.Click += BtnViewDogs_Click;
            btnAssignPatrol.Click += BtnAssignPatrol_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblAssignedDogsCount.Text = "8";
                lblPatrolDogsCount.Text = "27";
                lblNewDogsCount.Text = "3";
                lblActiveDogsCount.Text = "5";
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
                    "17.07.2026",
                    "08:30",
                    "● Назначена на службу",
                    "Альфа");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "10:15",
                    "● Начата дрессировка",
                    "Гром");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "13:40",
                    "● Завершена дрессировка",
                    "Барс");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "15:10",
                    "● Ветеринарный осмотр",
                    "Рекс");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "09:20",
                    "● Закреплена за кинологом",
                    "Лорд");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "11:50",
                    "● Назначена на службу",
                    "Тайга");

                dgvEvents.Rows.Add(
                    "14.07.2026",
                    "16:25",
                    "● Начата дрессировка",
                    "Буран");

                dgvEvents.Rows.Add(
                    "14.07.2026",
                    "18:05",
                    "● Ветеринарный осмотр",
                    "Вега");

                dgvEvents.Rows.Add(
                    "13.07.2026",
                    "12:30",
                    "● Завершена дрессировка",
                    "Кай");

                dgvEvents.Rows.Add(
                    "13.07.2026",
                    "17:40",
                    "● Назначена на службу",
                    "Арчи");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
        }

        private void BtnAddDog_Click(
    object sender,
    EventArgs e)
        {
            MessageBox.Show(
                "Форма добавления служебной собаки пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnViewDogs_Click(
    object sender,
    EventArgs e)
        {
            MessageBox.Show(
                "Страница служебных собак пока не создана.");
        }

        private void BtnAssignPatrol_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма назначения собаки на службу пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}