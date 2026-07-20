using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class InspectorDashboardPage : UserControl
    {
        public InspectorDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnSchedule.Click += BtnSchedule_Click;
            btnRoute.Click += BtnRoute_Click;
            btnEquipmentAction.Click += BtnEquipmentAction_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblMyPatrolsCount.Text = "18";
                lblTodayPatrolsCount.Text = "4";
                lblEquipmentCount.Text = "16";
                lblRoutesCount.Text = "12";
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
                    "07:30",
                    "● Получен наряд",
                    "Маршрут №12");

                dgvEvents.Rows.Add(
                    "18.07.2026",
                    "09:10",
                    "● Начато патрулирование",
                    "Маршрут №12");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "18:20",
                    "● Завершено патрулирование",
                    "Маршрут №8");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "14:40",
                    "● Получена экипировка",
                    "Склад №1");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "08:00",
                    "● Получен наряд",
                    "Маршрут №5");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "19:10",
                    "● Смена завершена",
                    "Маршрут №5");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "07:45",
                    "● Получен наряд",
                    "Маршрут №3");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "13:35",
                    "● Проверка маршрута",
                    "Маршрут №10");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "08:15",
                    "● Начато патрулирование",
                    "Маршрут №10");

                dgvEvents.Rows.Add(
                    "14.07.2026",
                    "18:50",
                    "● Смена завершена",
                    "Маршрут №7");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
        }

        private void BtnSchedule_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница графика нарядов пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadStatistics();
            LoadRecentEvents();
        }

        private void BtnRoute_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница маршрутов патрулирования пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnEquipmentAction_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Страница экипировки пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}