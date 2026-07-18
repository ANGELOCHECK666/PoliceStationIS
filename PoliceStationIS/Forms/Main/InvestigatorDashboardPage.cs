using System;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Main
{
    public partial class InvestigatorDashboardPage : UserControl
    {
        public InvestigatorDashboardPage()
        {
            InitializeComponent();

            LoadStatistics();
            LoadRecentEvents();

            btnCreateCase.Click += BtnCreateCase_Click;
            btnAddCitizen.Click += BtnAddCitizen_Click;
            btnCreateProtocol.Click += BtnCreateProtocol_Click;
        }

        private void LoadStatistics()
        {
            try
            {
                lblMyCasesCount.Text = "18";
                lblActiveCasesCount.Text = "11";
                lblProtocolsCount.Text = "42";
                lblExpertisesCount.Text = "7";
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
                    "09:10",
                    "● Создано уголовное дело",
                    "№ 24158");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "10:35",
                    "● Добавлен гражданин",
                    "№ 24158");

                dgvEvents.Rows.Add(
                    "17.07.2026",
                    "13:20",
                    "● Назначена экспертиза",
                    "№ 24146");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "09:40",
                    "● Составлен протокол",
                    "№ 24141");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "12:15",
                    "● Допрошен свидетель",
                    "№ 24139");

                dgvEvents.Rows.Add(
                    "16.07.2026",
                    "16:50",
                    "● Добавлено вещественное доказательство",
                    "№ 24137");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "08:45",
                    "● Назначена экспертиза",
                    "№ 24131");

                dgvEvents.Rows.Add(
                    "15.07.2026",
                    "14:30",
                    "● Получено заключение эксперта",
                    "№ 24128");

                dgvEvents.Rows.Add(
                    "14.07.2026",
                    "11:05",
                    "● Составлен протокол осмотра",
                    "№ 24122");

                dgvEvents.Rows.Add(
                    "14.07.2026",
                    "17:40",
                    "● Уголовное дело завершено",
                    "№ 24110");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки последних событий");
            }
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

        private void BtnAddCitizen_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма добавления гражданина пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnCreateProtocol_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Форма составления протокола пока не подключена.",
                "Информация",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}