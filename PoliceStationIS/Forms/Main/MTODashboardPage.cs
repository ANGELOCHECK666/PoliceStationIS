using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class MTODashboardPage : UserControl
    {
        public MTODashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnWarehouse.Click += BtnWarehouse_Click;
            btnRequests.Click += BtnRequests_Click;
            btnMaintenance.Click += BtnMaintenance_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblWarehouseCount.Text = "426";
                lblIssuedCount.Text = "187";
                lblMaintenanceCount.Text = "14";
                lblRequestsCount.Text = "9";
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
                    "08:20",
                    "● Выдан бронежилет",
                    "Бронежилет");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "09:45",
                    "● Принята новая заявка",
                    "Рация");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "11:10",
                    "● Передано на обслуживание",
                    "Служебный автомобиль");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "13:35",
                    "● Возвращено на склад",
                    "Наручники");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "15:50",
                    "● Выдан сотруднику",
                    "Тактический фонарь");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "17:15",
                    "● Выполнено обслуживание",
                    "Компьютер");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "10:30",
                    "● Принята новая заявка",
                    "Бронежилет");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "14:40",
                    "● Передано на обслуживание",
                    "Служебный автомобиль");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "09:15",
                    "● Выдан сотруднику",
                    "Рация");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "16:20",
                    "● Возвращено на склад",
                    "Шлем");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
        }

        private void BtnWarehouse_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница управления складом пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnRequests_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница заявок на выдачу пока не создана.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnMaintenance_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница обслуживания имущества пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}