using Npgsql;
using PoliceStationIS.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Statistics
{
    public partial class StatisticsPage : UserControl
    {
        private DateTime periodFrom;
        private DateTime periodTo;

        private readonly string[] monthNames =
        {
            "Янв", "Фев", "Мар", "Апр", "Май", "Июн",
            "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"
        };

        private readonly Color navy = Color.FromArgb(5, 24, 58);
        private readonly Color panelBlue = Color.FromArgb(15, 39, 78);
        private readonly Color panelBlue2 = Color.FromArgb(20, 48, 94);
        private readonly Color inputBlue = Color.FromArgb(31, 59, 105);
        private readonly Color gold = Color.FromArgb(201, 155, 59);
        private readonly Color white = Color.White;
        private readonly Color light = Color.Gainsboro;

        private int[] monthlyCases = new int[12];
        private Dictionary<string, int> crimeStructure =
            new Dictionary<string, int>();

        public StatisticsPage()
        {
            InitializeComponent();

            periodFrom = DateTime.Today;
            periodTo = DateTime.Today;

            ConfigureEvents();
            ApplyPeriod("Сегодня");
            LoadStatistics();
        }

        private void ConfigureEvents()
        {
            chartCases.Paint += ChartCases_Paint;
            chartCrime.Paint += ChartCrime_Paint;

            btnToday.Click += (s, e) =>
            {
                ApplyPeriod("Сегодня");
                LoadStatistics();
            };

            btnWeek.Click += (s, e) =>
            {
                ApplyPeriod("Неделя");
                LoadStatistics();
            };

            btnMonth.Click += (s, e) =>
            {
                ApplyPeriod("Месяц");
                LoadStatistics();
            };

            btnYear.Click += (s, e) =>
            {
                ApplyPeriod("Год");
                LoadStatistics();
            };

            dtFrom.ValueChanged += (s, e) =>
            {
                periodFrom = dtFrom.Value.Date;

                if (periodFrom > periodTo)
                    periodTo = periodFrom;

                RefreshPeriodButtonState();
                LoadStatistics();
            };

            dtTo.ValueChanged += (s, e) =>
            {
                periodTo = dtTo.Value.Date;

                if (periodTo < periodFrom)
                    periodFrom = periodTo;

                RefreshPeriodButtonState();
                LoadStatistics();
            };

            btnRefresh.Click += (s, e) => LoadStatistics();
        }

        private void ApplyPeriod(string period)
        {
            DateTime today = DateTime.Today;

            switch (period)
            {
                case "Сегодня":
                    periodFrom = today;
                    periodTo = today;
                    break;

                case "Неделя":
                    periodTo = today;
                    periodFrom = today.AddDays(-6);
                    break;

                case "Месяц":
                    periodFrom = new DateTime(
                        today.Year,
                        today.Month,
                        1);

                    periodTo = periodFrom
                        .AddMonths(1)
                        .AddDays(-1);
                    break;

                case "Год":
                    periodFrom = new DateTime(
                        today.Year,
                        1,
                        1);

                    periodTo = new DateTime(
                        today.Year,
                        12,
                        31);
                    break;
            }

            dtFrom.Value = periodFrom;
            dtTo.Value = periodTo;

            RefreshPeriodButtonState();
        }

        private void RefreshPeriodButtonState()
        {
            ResetPeriodButtons();

            DateTime today = DateTime.Today;

            if (periodFrom == today &&
                periodTo == today)
            {
                SetSelectedPeriodButton(btnToday);
            }
            else if (periodFrom == today.AddDays(-6) &&
                     periodTo == today)
            {
                SetSelectedPeriodButton(btnWeek);
            }
            else if (periodFrom == new DateTime(
                         today.Year,
                         today.Month,
                         1) &&
                     periodTo == new DateTime(
                         today.Year,
                         today.Month,
                         1)
                         .AddMonths(1)
                         .AddDays(-1))
            {
                SetSelectedPeriodButton(btnMonth);
            }
            else if (periodFrom == new DateTime(today.Year, 1, 1) &&
                     periodTo == new DateTime(today.Year, 12, 31))
            {
                SetSelectedPeriodButton(btnYear);
            }
        }

        private void ResetPeriodButtons()
        {
            foreach (Button button in new[]
            {
                btnToday,
                btnWeek,
                btnMonth,
                btnYear
            })
            {
                button.BackColor = panelBlue2;
                button.ForeColor = white;
                button.FlatAppearance.BorderColor =
                    Color.FromArgb(60, 84, 125);
            }
        }

        private void SetSelectedPeriodButton(Button button)
        {
            button.BackColor = gold;
            button.ForeColor = Color.FromArgb(20, 30, 45);
            button.FlatAppearance.BorderColor = gold;
        }

        private void LoadStatistics()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    LoadCards(connection);
                    LoadMonthlyCases(connection);
                    LoadCrimeStructure(connection);
                }

                UpdateCards();
                chartCases.Invalidate();
                chartCrime.Invalidate();

                lblPeriodInfo.Text =
                    "Период: " +
                    periodFrom.ToString("dd.MM.yyyy") +
                    " — " +
                    periodTo.ToString("dd.MM.yyyy");

                lblUpdated.Text =
                    "Данные обновлены: " +
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статистику из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка статистики",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCards(NpgsqlConnection connection)
        {
            int employees = ExecuteCount(
                connection,
                "SELECT COUNT(*) FROM Employee;");

            int cases = ExecuteCount(
                connection,
                @"SELECT COUNT(*)
                  FROM Criminal_case
                  WHERE case_creation_date
                        BETWEEN @from AND @to;",
                true);

            int closedCases = ExecuteCount(
                connection,
                @"SELECT COUNT(*)
                  FROM Criminal_case
                  WHERE case_closing_date IS NOT NULL
                    AND case_closing_date
                        BETWEEN @from AND @to;",
                true);

            int patrolsToday = ExecuteCount(
                connection,
                @"SELECT COUNT(DISTINCT s.squad_id)
                  FROM Schedule s
                  WHERE s.planned_start_date_and_time::date
                        = CURRENT_DATE;");

            int inspections = ExecuteCount(
                connection,
                @"SELECT COUNT(*)
                  FROM Inspection
                  WHERE appointment_date
                        BETWEEN @from AND @to;",
                true);

            int dogs = ExecuteCount(
                connection,
                "SELECT COUNT(*) FROM Service_dog;");

            int protocols = ExecuteCount(
                connection,
                @"SELECT COUNT(*)
                  FROM Protocol
                  WHERE date_of_preparation_protocol
                        BETWEEN @from AND @to;",
                true);

            int evidence = ExecuteCount(
                connection,
                @"SELECT COUNT(*)
                  FROM Evidence
                  WHERE date_of_seizure
                        BETWEEN @from AND @to;",
                true);

            lblEmployeesValue.Text = employees.ToString();
            lblCasesValue.Text = cases.ToString();
            lblClosedCasesValue.Text = closedCases.ToString();
            lblPatrolsValue.Text = patrolsToday.ToString();
            lblInspectionsValue.Text = inspections.ToString();
            lblDogsValue.Text = dogs.ToString();
            lblProtocolsValue.Text = protocols.ToString();
            lblEvidenceValue.Text = evidence.ToString();
        }

        private int ExecuteCount(
            NpgsqlConnection connection,
            string query,
            bool usePeriod = false)
        {
            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                if (usePeriod)
                {
                    command.Parameters.AddWithValue(
                        "@from",
                        periodFrom.Date);

                    command.Parameters.AddWithValue(
                        "@to",
                        periodTo.Date);
                }

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private void UpdateCards()
        {
            lblEmployeesUnit.Text = "чел.";
            lblCasesUnit.Text = "шт.";
            lblClosedCasesUnit.Text = "шт.";
            lblPatrolsUnit.Text = "шт.";
            lblInspectionsUnit.Text = "шт.";
            lblDogsUnit.Text = "шт.";
            lblProtocolsUnit.Text = "шт.";
            lblEvidenceUnit.Text = "шт.";
        }

        private void LoadMonthlyCases(NpgsqlConnection connection)
        {
            monthlyCases = new int[12];

            string query =
                @"SELECT
                      EXTRACT(MONTH FROM case_creation_date)::int
                          AS month_number,
                      COUNT(*) AS case_count
                  FROM Criminal_case
                  WHERE case_creation_date
                        BETWEEN @from AND @to
                  GROUP BY
                      EXTRACT(MONTH FROM case_creation_date)
                  ORDER BY month_number;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@from",
                    periodFrom.Date);

                command.Parameters.AddWithValue(
                    "@to",
                    periodTo.Date);

                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int month =
                            Convert.ToInt32(reader["month_number"]);

                        int count =
                            Convert.ToInt32(reader["case_count"]);

                        if (month >= 1 && month <= 12)
                            monthlyCases[month - 1] = count;
                    }
                }
            }
        }

        private void LoadCrimeStructure(NpgsqlConnection connection)
        {
            crimeStructure =
                new Dictionary<string, int>
                {
                    { "Кражи", 0 },
                    { "Грабежи", 0 },
                    { "Мошенничество", 0 },
                    { "Прочее", 0 }
                };

            string query =
                @"SELECT
                      art.article_of_the_ccrf_name,
                      COUNT(*) AS case_count
                  FROM Criminal_case cc
                  INNER JOIN Article_of_the_CCRF art
                      ON art.article_of_the_ccrf_id =
                         cc.article_of_the_ccrf_id
                  WHERE cc.case_creation_date
                        BETWEEN @from AND @to
                  GROUP BY
                      art.article_of_the_ccrf_name;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@from",
                    periodFrom.Date);

                command.Parameters.AddWithValue(
                    "@to",
                    periodTo.Date);

                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string article =
                            Convert.ToString(
                                reader["article_of_the_ccrf_name"]);

                        int count =
                            Convert.ToInt32(
                                reader["case_count"]);

                        if (article.IndexOf(
                                "краж",
                                StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            crimeStructure["Кражи"] += count;
                        }
                        else if (article.IndexOf(
                                     "грабеж",
                                     StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 article.IndexOf(
                                     "разбой",
                                     StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            crimeStructure["Грабежи"] += count;
                        }
                        else if (article.IndexOf(
                                     "мошеннич",
                                     StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            crimeStructure["Мошенничество"] += count;
                        }
                        else
                        {
                            crimeStructure["Прочее"] += count;
                        }
                    }
                }
            }
        }

        private void ChartCases_Paint(
            object sender,
            PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            Rectangle area =
                new Rectangle(
                    45,
                    40,
                    chartCases.Width - 65,
                    chartCases.Height - 85);

            int maxValue =
                monthlyCases.Length == 0
                    ? 0
                    : monthlyCases.Max();

            maxValue =
                Math.Max(maxValue, 1);

            using (Pen gridPen =
                new Pen(Color.FromArgb(45, 70, 110)))
            using (Pen axisPen =
                new Pen(Color.FromArgb(75, 98, 135)))
            using (Brush textBrush =
                new SolidBrush(light))
            using (Brush barBrush =
                new SolidBrush(gold))
            {
                for (int i = 0; i <= 4; i++)
                {
                    int y =
                        area.Bottom -
                        (area.Height * i / 4);

                    g.DrawLine(
                        gridPen,
                        area.Left,
                        y,
                        area.Right,
                        y);

                    int value =
                        maxValue * i / 4;

                    g.DrawString(
                        value.ToString(),
                        new Font(
                            "Segoe UI",
                            8F),
                        textBrush,
                        8,
                        y - 8);
                }

                g.DrawLine(
                    axisPen,
                    area.Left,
                    area.Bottom,
                    area.Right,
                    area.Bottom);

                float slotWidth =
                    area.Width / 12f;

                float barWidth =
                    Math.Max(8f, slotWidth * 0.58f);

                for (int i = 0; i < 12; i++)
                {
                    float barHeight =
                        area.Height *
                        monthlyCases[i] /
                        (float)maxValue;

                    float x =
                        area.Left +
                        i * slotWidth +
                        (slotWidth - barWidth) / 2f;

                    float y =
                        area.Bottom -
                        barHeight;

                    g.FillRectangle(
                        barBrush,
                        x,
                        y,
                        barWidth,
                        barHeight);

                    SizeF textSize =
                        g.MeasureString(
                            monthNames[i],
                            new Font(
                                "Segoe UI",
                                8F));

                    g.DrawString(
                        monthNames[i],
                        new Font(
                            "Segoe UI",
                            8F),
                        textBrush,
                        x +
                        (barWidth - textSize.Width) / 2f,
                        area.Bottom + 8);
                }
            }
        }

        private void ChartCrime_Paint(
            object sender,
            PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode =
                SmoothingMode.AntiAlias;

            int total =
                crimeStructure.Values.Sum();

            Rectangle donut =
                new Rectangle(
                    35,
                    8,
                    175,
                    175);

            if (total > 0)
            {
                Color[] colors =
                {
                    Color.FromArgb(201, 155, 59),
                    Color.FromArgb(74, 96, 130),
                    Color.FromArgb(105, 121, 147),
                    Color.FromArgb(44, 62, 94)
                };

                float startAngle = -90f;
                int colorIndex = 0;

                foreach (KeyValuePair<string, int> item
                         in crimeStructure)
                {
                    float sweep =
                        360f *
                        item.Value /
                        total;

                    using (Brush brush =
                        new SolidBrush(
                            colors[colorIndex %
                                   colors.Length]))
                    {
                        g.FillPie(
                            brush,
                            donut,
                            startAngle,
                            sweep);
                    }

                    startAngle += sweep;
                    colorIndex++;
                }

                using (Brush holeBrush =
                    new SolidBrush(panelBlue))
                {
                    g.FillEllipse(
                        holeBrush,
                        donut.X + 45,
                        donut.Y + 45,
                        donut.Width - 90,
                        donut.Height - 90);
                }
            }
            else
            {
                using (Brush brush =
                    new SolidBrush(
                        Color.FromArgb(45, 65, 98)))
                {
                    g.FillEllipse(
                        brush,
                        donut);
                }

                using (Brush holeBrush =
                    new SolidBrush(panelBlue))
                {
                    g.FillEllipse(
                        holeBrush,
                        donut.X + 45,
                        donut.Y + 45,
                        donut.Width - 90,
                        donut.Height - 90);
                }
            }

            using (Brush textBrush =
                new SolidBrush(light))
            {
                int y = 38;
                Color[] colors =
                {
                    Color.FromArgb(201, 155, 59),
                    Color.FromArgb(74, 96, 130),
                    Color.FromArgb(105, 121, 147),
                    Color.FromArgb(44, 62, 94)
                };

                int colorIndex = 0;

                foreach (KeyValuePair<string, int> item
                         in crimeStructure)
                {
                    float percent =
                        total == 0
                            ? 0
                            : item.Value * 100f / total;

                    using (Brush dotBrush =
                        new SolidBrush(
                            colors[colorIndex %
                                   colors.Length]))
                    {
                        g.FillEllipse(
                            dotBrush,
                            238,
                            y + 3,
                            9,
                            9);
                    }

                    g.DrawString(
                        item.Key,
                        new Font(
                            "Segoe UI",
                            9F),
                        textBrush,
                        254,
                        y);

                    g.DrawString(
                        percent.ToString("0") + "%",
                        new Font(
                            "Segoe UI",
                            9F,
                            FontStyle.Bold),
                        textBrush,
                        350,
                        y);

                    y += 32;
                    colorIndex++;
                }

                if (total == 0)
                {
                    g.DrawString(
                        "Нет данных за выбранный период",
                        new Font(
                            "Segoe UI",
                            9F),
                        textBrush,
                        45,
                        235);
                }
            }
        }
    }
}
