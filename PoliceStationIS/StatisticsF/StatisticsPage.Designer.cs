using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Statistics
{
    partial class StatisticsPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private PictureBox picStatistics;

        private Panel panelPeriod;
        private Label lblPeriodTitle;
        private Label lblPeriodInfo;
        private Button btnToday;
        private Button btnWeek;
        private Button btnMonth;
        private Button btnYear;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private Label lblDash;

        private Panel cardEmployees;
        private Panel cardCases;
        private Panel cardClosedCases;
        private Panel cardPatrols;
        private Panel cardInspections;
        private Panel cardDogs;
        private Panel cardProtocols;
        private Panel cardEvidence;

        private Label lblEmployeesValue;
        private Label lblCasesValue;
        private Label lblClosedCasesValue;
        private Label lblPatrolsValue;
        private Label lblInspectionsValue;
        private Label lblDogsValue;
        private Label lblProtocolsValue;
        private Label lblEvidenceValue;

        private Label lblEmployeesUnit;
        private Label lblCasesUnit;
        private Label lblClosedCasesUnit;
        private Label lblPatrolsUnit;
        private Label lblInspectionsUnit;
        private Label lblDogsUnit;
        private Label lblProtocolsUnit;
        private Label lblEvidenceUnit;

        private Label lblEmployeesTitle;
        private Label lblCasesTitle;
        private Label lblClosedCasesTitle;
        private Label lblPatrolsTitle;
        private Label lblInspectionsTitle;
        private Label lblDogsTitle;
        private Label lblProtocolsTitle;
        private Label lblEvidenceTitle;

        private Panel panelCasesChart;
        private Label lblCasesChartTitle;
        private Panel chartCases;

        private Panel panelCrimeChart;
        private Label lblCrimeChartTitle;
        private Panel chartCrime;

        private Panel panelFooter;
        private Label lblUpdated;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.picStatistics = new PictureBox();

            this.panelPeriod = new Panel();
            this.lblPeriodTitle = new Label();
            this.lblPeriodInfo = new Label();
            this.btnToday = CreatePeriodButton("Сегодня");
            this.btnWeek = CreatePeriodButton("Неделя");
            this.btnMonth = CreatePeriodButton("Месяц");
            this.btnYear = CreatePeriodButton("Год");
            this.dtFrom = CreateDatePicker();
            this.dtTo = CreateDatePicker();
            this.lblDash = new Label();

            this.cardEmployees = CreateCard();
            this.cardCases = CreateCard();
            this.cardClosedCases = CreateCard();
            this.cardPatrols = CreateCard();
            this.cardInspections = CreateCard();
            this.cardDogs = CreateCard();
            this.cardProtocols = CreateCard();
            this.cardEvidence = CreateCard();

            CreateCardContent(
                cardEmployees,
                "Сотрудников",
                out lblEmployeesTitle,
                out lblEmployeesValue,
                out lblEmployeesUnit,
                "employees_gold_icon");

            CreateCardContent(
                cardCases,
                "Уголовных дел",
                out lblCasesTitle,
                out lblCasesValue,
                out lblCasesUnit,
                "case_transfer_gold_icon");

            CreateCardContent(
                cardClosedCases,
                "Завершено дел",
                out lblClosedCasesTitle,
                out lblClosedCasesValue,
                out lblClosedCasesUnit,
                "case_close");

            CreateCardContent(
                cardPatrols,
                "Нарядов сегодня",
                out lblPatrolsTitle,
                out lblPatrolsValue,
                out lblPatrolsUnit,
                "patrol_gold_icon");

            CreateCardContent(
                cardInspections,
                "Проведено экспертиз",
                out lblInspectionsTitle,
                out lblInspectionsValue,
                out lblInspectionsUnit,
                "expertise_gold_icon");

            CreateCardContent(
                cardDogs,
                "Служебных собак",
                out lblDogsTitle,
                out lblDogsValue,
                out lblDogsUnit,
                "dogs_gold_icon");

            CreateCardContent(
                cardProtocols,
                "Протоколов",
                out lblProtocolsTitle,
                out lblProtocolsValue,
                out lblProtocolsUnit,
                "protocols_gold_icon");

            CreateCardContent(
                cardEvidence,
                "Вещественных док-в",
                out lblEvidenceTitle,
                out lblEvidenceValue,
                out lblEvidenceUnit,
                "evidence_gold_icon");

            this.panelCasesChart = new Panel();
            this.lblCasesChartTitle = new Label();
            this.chartCases = new Panel();

            this.panelCrimeChart = new Panel();
            this.lblCrimeChartTitle = new Label();
            this.chartCrime = new Panel();

            this.panelFooter = new Panel();
            this.lblUpdated = new Label();
            this.btnRefresh = new Button();

            this.SuspendLayout();

            // =========================================================
            // PAGE
            // =========================================================

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.Dock =
                DockStyle.Fill;

            this.Name =
                "StatisticsPage";

            // =========================================================
            // HEADER
            // =========================================================

            this.panelHeader.BackColor =
                Color.FromArgb(15, 39, 78);

            this.panelHeader.BorderStyle =
                BorderStyle.FixedSingle;

            this.panelHeader.Location =
                new Point(20, 20);

            this.panelHeader.Size =
                new Size(1260, 100);

            this.panelHeader.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    21F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(25, 22);

            this.lblTitle.Text =
                "Статистика";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(27, 61);

            this.lblSubtitle.Text =
                "Аналитика работы полицейского участка";

            this.picStatistics.Size =
                new Size(82, 82);

            this.picStatistics.Location =
                new Point(710, 8);

            this.picStatistics.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.picStatistics.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picStatistics.BackColor =
                Color.Transparent;

            try
            {
                this.picStatistics.Image =
                    Properties.Resources.statistics_gold_icon;
            }
            catch
            {
                this.picStatistics.Image = null;
            }

            this.panelHeader.Controls.Add(
                this.lblTitle);

            this.panelHeader.Controls.Add(
                this.lblSubtitle);

            this.panelHeader.Controls.Add(
                this.picStatistics);

            // =========================================================
            // PERIOD
            // =========================================================

            this.panelPeriod.BackColor =
                Color.FromArgb(11, 31, 65);

            this.panelPeriod.BorderStyle =
                BorderStyle.FixedSingle;

            this.panelPeriod.Location =
                new Point(20, 135);

            this.panelPeriod.Size =
                new Size(1260, 95);

            this.panelPeriod.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            this.lblPeriodTitle.AutoSize = true;
            this.lblPeriodTitle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblPeriodTitle.ForeColor =
                Color.Gold;

            this.lblPeriodTitle.Location =
                new Point(18, 12);

            this.lblPeriodTitle.Text =
                "ПЕРИОД";

            this.btnToday.Location =
                new Point(18, 42);

            this.btnWeek.Location =
                new Point(110, 42);

            this.btnMonth.Location =
                new Point(202, 42);

            this.btnYear.Location =
                new Point(294, 42);

            this.dtFrom.Location =
                new Point(405, 42);

            this.dtTo.Location =
                new Point(580, 42);

            this.lblDash.AutoSize = true;
            this.lblDash.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.lblDash.ForeColor =
                Color.Gainsboro;

            this.lblDash.Location =
                new Point(563, 45);

            this.lblPeriodInfo.AutoSize = true;
            this.lblPeriodInfo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblPeriodInfo.ForeColor =
                Color.Gainsboro;

            this.lblPeriodInfo.Location =
                new Point(780, 16);

            this.lblPeriodInfo.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.panelPeriod.Controls.Add(
                this.lblPeriodTitle);

            this.panelPeriod.Controls.Add(
                this.lblPeriodInfo);

            this.panelPeriod.Controls.Add(
                this.btnToday);

            this.panelPeriod.Controls.Add(
                this.btnWeek);

            this.panelPeriod.Controls.Add(
                this.btnMonth);

            this.panelPeriod.Controls.Add(
                this.btnYear);

            this.panelPeriod.Controls.Add(
                this.dtFrom);

            this.panelPeriod.Controls.Add(
                this.dtTo);

            this.panelPeriod.Controls.Add(
                this.lblDash);

            // =========================================================
            // CARDS
            // =========================================================

            ConfigureCardLocation(
                cardEmployees,
                20, 245);

            ConfigureCardLocation(
                cardCases,
                355, 245);

            ConfigureCardLocation(
                cardClosedCases,
                690, 245);

            ConfigureCardLocation(
                cardPatrols,
                1025, 245);

            ConfigureCardLocation(
                cardInspections,
                20, 375);

            ConfigureCardLocation(
                cardDogs,
                355, 375);

            ConfigureCardLocation(
                cardProtocols,
                690, 375);

            ConfigureCardLocation(
                cardEvidence,
                1025, 375);

            // =========================================================
            // CHARTS
            // =========================================================

            ConfigureChartPanel(
                panelCasesChart,
                lblCasesChartTitle,
                chartCases,
                "Уголовные дела по месяцам");

            panelCasesChart.Location =
                new Point(20, 510);

            panelCasesChart.Size =
                new Size(790, 235);

            panelCasesChart.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            panelCasesChart.Width =
                0;

            ConfigureChartPanel(
                panelCrimeChart,
                lblCrimeChartTitle,
                chartCrime,
                "Структура преступлений");

            // Set after page is resized.
            panelCrimeChart.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            panelCrimeChart.Location =
                new Point(0, 510);

            panelCrimeChart.Size =
                new Size(450, 235);

            panelCrimeChart.Controls.Remove(
                chartCrime);

            chartCrime.Size =
                new Size(426, 195);

            chartCrime.Location =
                new Point(12, 10);

            panelCrimeChart.Controls.Add(
                chartCrime);

            // =========================================================
            // FOOTER
            // =========================================================

            this.panelFooter.BackColor =
                Color.FromArgb(5, 24, 58);

            this.panelFooter.Location =
                new Point(20, 760);

            this.panelFooter.Size =
                new Size(1260, 35);

            this.panelFooter.Anchor =
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            this.lblUpdated.AutoSize = true;
            this.lblUpdated.ForeColor =
                Color.Gainsboro;

            this.lblUpdated.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblUpdated.Location =
                new Point(5, 14);

            this.btnRefresh.Text =
                "↻   Обновить данные";

            this.btnRefresh.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnRefresh.ForeColor =
                Color.White;

            this.btnRefresh.BackColor =
                Color.FromArgb(18, 43, 84);

            this.btnRefresh.FlatStyle =
                FlatStyle.Flat;

            this.btnRefresh.FlatAppearance.BorderColor =
                Color.FromArgb(70, 96, 140);

            this.btnRefresh.Size =
                new Size(170, 34);

            this.btnRefresh.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.btnRefresh.Location =
                new Point(0, -1);

            this.panelFooter.Controls.Add(
                this.lblUpdated);

            this.panelFooter.Controls.Add(
                this.btnRefresh);

            // =========================================================
            // ADD CONTROLS
            // =========================================================

            this.Controls.Add(
                this.panelHeader);

            this.Controls.Add(
                this.panelPeriod);

            this.Controls.Add(
                this.cardEmployees);

            this.Controls.Add(
                this.cardCases);

            this.Controls.Add(
                this.cardClosedCases);

            this.Controls.Add(
                this.cardPatrols);

            this.Controls.Add(
                this.cardInspections);

            this.Controls.Add(
                this.cardDogs);

            this.Controls.Add(
                this.cardProtocols);

            this.Controls.Add(
                this.cardEvidence);

            this.Controls.Add(
                this.panelCasesChart);

            this.Controls.Add(
                this.panelCrimeChart);

            this.Controls.Add(
                this.panelFooter);

            // =========================================================
            // RESIZE
            // =========================================================

            this.Resize +=
                StatisticsPage_Resize;

            StatisticsPage_Resize(
                null,
                EventArgs.Empty);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Button CreatePeriodButton(
            string text)
        {
            Button button =
                new Button();

            button.Text = text;
            button.Size =
                new Size(84, 34);

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.ForeColor =
                Color.White;

            button.BackColor =
                Color.FromArgb(20, 48, 94);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(60, 84, 125);

            button.Cursor =
                Cursors.Hand;

            return button;
        }

        private DateTimePicker CreateDatePicker()
        {
            DateTimePicker picker =
                new DateTimePicker();

            picker.Format =
                DateTimePickerFormat.Custom;

            picker.CustomFormat =
                "dd.MM.yyyy";

            picker.Font =
                new Font(
                    "Segoe UI",
                    9F);

            picker.Size =
                new Size(150, 30);

            picker.BackColor =
                Color.White;

            picker.ForeColor =
                Color.FromArgb(20, 30, 45);

            picker.MaxDate =
                new DateTime(
                    2099,
                    12,
                    31);

            return picker;
        }

        private Panel CreateCard()
        {
            Panel panel =
                new Panel();

            panel.BackColor =
                Color.FromArgb(15, 39, 78);

            panel.BorderStyle =
                BorderStyle.FixedSingle;

            panel.Size =
                new Size(300, 125);

            return panel;
        }

        private void CreateCardContent(
            Panel card,
            string title,
            out Label titleLabel,
            out Label valueLabel,
            out Label unitLabel,
            string resourceName)
        {
            titleLabel = new Label();
            valueLabel = new Label();
            unitLabel = new Label();

            titleLabel.AutoSize = true;
            titleLabel.Text = title;
            titleLabel.ForeColor =
                Color.Gainsboro;

            titleLabel.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            titleLabel.Location =
                new Point(18, 16);

            valueLabel.AutoSize = true;
            valueLabel.Text = "0";
            valueLabel.ForeColor =
                Color.FromArgb(
                    225,
                    176,
                    61);

            valueLabel.Font =
                new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold);

            valueLabel.Location =
                new Point(20, 52);

            unitLabel.AutoSize = true;
            unitLabel.Text = "шт.";
            unitLabel.ForeColor =
                Color.White;

            unitLabel.Font =
                new Font(
                    "Segoe UI",
                    9F);

            unitLabel.Location =
                new Point(95, 69);

            PictureBox icon =
                new PictureBox();

            icon.Size =
                new Size(55, 55);

            icon.Location =
                new Point(205, 42);

            icon.SizeMode =
                PictureBoxSizeMode.Zoom;

            icon.BackColor =
                Color.Transparent;

            try
            {
                object resource =
                    Properties.Resources.ResourceManager
                        .GetObject(resourceName);

                icon.Image =
                    resource as Image;
            }
            catch
            {
                icon.Image = null;
            }

            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(unitLabel);
            card.Controls.Add(icon);
        }

        private void ConfigureCardLocation(
            Panel card,
            int x,
            int y)
        {
            card.Location =
                new Point(x, y);

            card.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;
        }

        private void ConfigureChartPanel(
            Panel panel,
            Label title,
            Panel chart,
            string titleText)
        {
            panel.BackColor =
                Color.FromArgb(11, 31, 65);

            panel.BorderStyle =
                BorderStyle.FixedSingle;

            title.AutoSize = true;
            title.Text =
                titleText;

            title.ForeColor =
                Color.White;

            title.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            title.Location =
                new Point(18, 12);

            chart.BackColor =
                Color.FromArgb(11, 31, 65);

            panel.Controls.Add(
                title);

            panel.Controls.Add(
                chart);
        }

        private void StatisticsPage_Resize(
            object sender,
            EventArgs e)
        {
            if (this.Width <= 0)
                return;

            int contentWidth =
                this.ClientSize.Width - 40;

            int cardGap = 40;

            int cardWidth =
                (contentWidth - (cardGap * 3)) / 4;

            if (cardWidth < 220)
                cardWidth = 220;

            foreach (Panel card in new[]
            {
                cardEmployees,
                cardCases,
                cardClosedCases,
                cardPatrols,
                cardInspections,
                cardDogs,
                cardProtocols,
                cardEvidence
            })
            {
                card.Width = cardWidth;
            }

            int x1 = 20;
            int x2 = x1 + cardWidth + cardGap;
            int x3 = x2 + cardWidth + cardGap;
            int x4 = x3 + cardWidth + cardGap;

            cardEmployees.Left = x1;
            cardCases.Left = x2;
            cardClosedCases.Left = x3;
            cardPatrols.Left = x4;

            cardInspections.Left = x1;
            cardDogs.Left = x2;
            cardProtocols.Left = x3;
            cardEvidence.Left = x4;

            cardEmployees.Top = 245;
            cardCases.Top = 245;
            cardClosedCases.Top = 245;
            cardPatrols.Top = 245;

            cardInspections.Top = 375;
            cardDogs.Top = 375;
            cardProtocols.Top = 375;
            cardEvidence.Top = 375;

            int chartGap = 15;
            int crimeWidth = 450;
            int casesWidth =
                contentWidth -
                crimeWidth -
                chartGap;

            if (casesWidth < 500)
                casesWidth = 500;

            panelCasesChart.Location =
                new Point(
                    20,
                    510);

            panelCasesChart.Size =
                new Size(
                    casesWidth,
                    235);

            panelCasesChart.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;

            panelCrimeChart.Location =
                new Point(
                    20 +
                    casesWidth +
                    chartGap,
                    510);

            panelCrimeChart.Size =
                new Size(
                    crimeWidth,
                    235);

            panelCrimeChart.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            chartCases.Location =
                new Point(
                    12,
                    43);

            chartCases.Size =
                new Size(
                    panelCasesChart.Width - 24,
                    150);

            chartCases.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            chartCrime.Location =
                new Point(
                    12,
                    43);

            chartCrime.Size =
                new Size(
                    panelCrimeChart.Width - 24,
                    215);

            chartCrime.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            panelFooter.Top =
                Math.Max(0, this.ClientSize.Height -
                panelFooter.Height -
                5);

            panelFooter.Width =
                this.ClientSize.Width - 40;

            btnRefresh.Left =
                panelFooter.Width -
                btnRefresh.Width -
                5;
        }
    }
}
