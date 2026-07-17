using Npgsql;
using PoliceStationIS.Core.Printing;
using PoliceStationIS.Database;
using PoliceStationIS.Models;
using PoliceStationIS.Reports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;


namespace PoliceStationIS.Forms.HR
{
    public partial class ReportsForm : Form
    {

        private ReportModel _currentReport;

        private string _currentPdfPath;
        public ReportsForm()
        {
            InitializeComponent();

            StyleCard(pnlSaveCard);

            StyleCard(pnlPrintCard);

            AddCardHover(pnlSaveCard);

            AddCardHover(pnlPrintCard);
            pnlSaveCard.Click += SaveCard_Click;

            pnlPrintCard.Click += PrintCard_Click;

            InitializeForm();

            SubscribeEvents();
            LoadReportTypes();

        }
        /// <summary>
        /// Первоначальная настройка формы.
        /// </summary>
        private void InitializeForm()
        {
            this.Text =
                "Формирование отчетов";

            dtpDateFrom.Value =
                DateTime.Today.AddMonths(-1);

            dtpDateTo.Value =
                DateTime.Today;
        }
        /// <summary>
        /// Подписка на события.
        /// </summary>
        private void SubscribeEvents()
        {
            this.Load += ReportsForm_Load;

            btnClose.Click += BtnClose_Click;

            btnCancel.Click += BtnCancel_Click;

            btnGenerate.Click += BtnGenerate_Click;

            cmbReportType.SelectedIndexChanged +=
                cmbReportType_SelectedIndexChanged;
        }

        private void ReportsForm_Load(
    object sender,
    EventArgs e)
        {

        }

        private void BtnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void BtnGenerate_Click(
    object sender,
    EventArgs e)
        {
            GenerateReport();

        }

        private void LoadReportTypes()
        {
            cmbReportType.Items.Clear();

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"SELECT
                    Report_type_id,
                    Report_type_name
                  FROM Report_type
                  ORDER BY Report_type_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbReportType.Items.Add(
                                    new ReportTypeItem
                                    {
                                        Id = reader.GetInt32(0),
                                        Name = reader.GetString(1)
                                    });
                            }
                        }
                    }
                }

                if (cmbReportType.Items.Count > 0)
                    cmbReportType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbReportType_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            LoadOptions();
        }

        private void LoadOptions()
        {
            pnlDynamicOptions.Controls.Clear();

            ReportTypeItem reportType =
    cmbReportType.SelectedItem as ReportTypeItem;

            if (reportType == null)
                return;

            switch (reportType.Name)
            {
                case "Список сотрудников":

                    CreateEmployeeListOptions();

                    break;

                case "Новые сотрудники":

                    CreateAcceptedEmployeesOptions();

                    break;

                case "Уволенные сотрудники":

                    CreateDismissedEmployeesOptions();

                    break;

                case "Сотрудники в отпуске":

                    CreateVacationOptions();

                    break;

                case "Сотрудники на больничном":

                    CreateHospitalOptions();

                    break;

                case "Кадровые изменения":

                    CreateChangesOptions();

                    break;
            }
        }
        private void AddOption(string text, int top)
        {
            Label lblBox = new Label();

            lblBox.Text = "☐";
            lblBox.Tag = false;

            lblBox.Font = new Font(
                "Segoe UI Symbol",
                15F,
                FontStyle.Regular);

            lblBox.ForeColor =
                Color.FromArgb(212, 160, 23);

            lblBox.BackColor = Color.Transparent;

            lblBox.Location =
                new Point(15, top);

            lblBox.AutoSize = true;

            lblBox.Cursor = Cursors.Hand;



            Label lblText = new Label();

            lblText.Text = text;

            lblText.Font = new Font(
                "Segoe UI",
                9.5F,
                FontStyle.Regular);

            lblText.ForeColor = Color.White;

            lblText.BackColor = Color.Transparent;

            lblText.Location =
                new Point(45, top + 4);

            lblText.AutoSize = true;

            lblText.Cursor = Cursors.Hand;
            lblText.Tag = lblBox;


            bool isChecked = false;



            void Toggle()
            {
                isChecked = !isChecked;

                lblBox.Tag = isChecked;

                lblBox.Text =
                    isChecked
                    ? "☑"
                    : "☐";
            }



            lblBox.Click += (s, e) =>
            {
                Toggle();
            };

            lblText.Click += (s, e) =>
            {
                Toggle();
            };



            pnlDynamicOptions.Controls.Add(lblBox);

            pnlDynamicOptions.Controls.Add(lblText);
        }

        private bool OptionChecked(string optionText)
        {
            foreach (Control control in pnlDynamicOptions.Controls)
            {
                if (control is Label lblText &&
                    lblText.Text == optionText)
                {
                    if (lblText.Tag is Label lblBox)
                    {
                        return (bool)lblBox.Tag;
                    }
                }
            }

            return false;
        }

        private void CreateEmployeeListOptions()
        {
            AddOption(
                "Добавить должность",
                10);

            AddOption(
                "Добавить подразделение",
                45);

            AddOption(
                "Добавить дату приема",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private void CreateAcceptedEmployeesOptions()
        {
            AddOption(
                "Добавить подразделение",
                10);

            AddOption(
                "Добавить должность",
                45);

            AddOption(
                "Добавить дату приема",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private void CreateDismissedEmployeesOptions()
        {
            AddOption(
                "Добавить подразделение",
                10);

            AddOption(
                "Добавить должность",
                45);

            AddOption(
                "Добавить дату увольнения",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private void CreateVacationOptions()
        {
            AddOption(
                "Добавить подразделение",
                10);

            AddOption(
                "Добавить количество дней",
                45);

            AddOption(
                "Добавить дату выхода",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private void CreateHospitalOptions()
        {
            AddOption(
                "Добавить подразделение",
                10);

            AddOption(
                "Добавить должность",
                45);

            AddOption(
                "Добавить период больничного",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private void CreateChangesOptions()
        {
            AddOption(
                "Добавить старую должность",
                10);

            AddOption(
                "Добавить новую должность",
                45);

            AddOption(
                "Добавить дату изменения",
                80);

            AddOption(
                "Добавить подпись руководителя",
                115);
        }

        private GraphicsPath CreateRoundedRectangle(
    Rectangle rectangle,
    int radius)
        {
            GraphicsPath path = new GraphicsPath();

            int diameter = radius * 2;

            path.AddArc(
                rectangle.X,
                rectangle.Y,
                diameter,
                diameter,
                180,
                90);

            path.AddArc(
                rectangle.Right - diameter,
                rectangle.Y,
                diameter,
                diameter,
                270,
                90);

            path.AddArc(
                rectangle.Right - diameter,
                rectangle.Bottom - diameter,
                diameter,
                diameter,
                0,
                90);

            path.AddArc(
                rectangle.X,
                rectangle.Bottom - diameter,
                diameter,
                diameter,
                90,
                90);

            path.CloseFigure();

            return path;
        }

        private void StyleCard(Panel panel)
        {
            panel.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode =
                    SmoothingMode.AntiAlias;

                Rectangle rect =
                    new Rectangle(
                        1,
                        1,
                        panel.Width - 3,
                        panel.Height - 3);

                using (GraphicsPath path =
                       CreateRoundedRectangle(rect, 18))
                {
                    using (Pen pen =
                           new Pen(
                               Color.FromArgb(212, 160, 23),
                               2))
                    {
                        e.Graphics.DrawPath(
                            pen,
                            path);
                    }

                    panel.Region =
                        new Region(path);
                }
            };
        }

        private void AddCardHover(Panel panel)
        {
            panel.MouseEnter += (s, e) =>
            {
                panel.BackColor =
                    Color.FromArgb(30, 58, 98);

                panel.Cursor =
                    Cursors.Hand;
            };

            panel.MouseLeave += (s, e) =>
            {
                panel.BackColor =
                    Color.FromArgb(22, 45, 78);
            };
        }

        private void GenerateReport()
        {

            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите тип отчета.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            List<string> selectedOptions =
     new List<string>();

            foreach (Control control in pnlDynamicOptions.Controls)
            {
                if (control is Label lblText)
                {
                    if (OptionChecked(lblText.Text))
                    {
                        selectedOptions.Add(
                            lblText.Text);
                    }
                }
            }
            ReportGenerator generator =
    new ReportGenerator();
            ReportTypeItem reportType =
(ReportTypeItem)cmbReportType.SelectedItem;

            _currentReport =
                generator.Generate(
                    reportType.Id,
                    reportType.Name,
                    dtpDateFrom.Value,
                    dtpDateTo.Value,
                    selectedOptions);
                PdfReportBuilder builder =
    new PdfReportBuilder();

            try
            {
                _currentPdfPath =
                    Path.Combine(
                        Path.GetTempPath(),
                        "PoliceStationReport.pdf");

                _currentPdfPath =
    builder.Build(
        _currentReport,
        _currentPdfPath);
                if (!File.Exists(_currentPdfPath))
                {
                    throw new Exception(
                        "PDF-файл не был создан.");
                }
                System.Diagnostics.Process.Start(
    new System.Diagnostics.ProcessStartInfo
    {
        FileName = _currentPdfPath,
        UseShellExecute = true
    });

                pnlSaveCard.Enabled = true;

                pnlPrintCard.Enabled = true;
                pnlSaveCard.Cursor =
    Cursors.Hand;

                pnlPrintCard.Cursor =
                    Cursors.Hand;

                MessageBox.Show(
                    "Отчет успешно сформирован.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка формирования отчета",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

                pnlPrintCard.Enabled = true;
                pnlSaveCard.BackColor =
    Color.FromArgb(22, 45, 78);

                pnlPrintCard.BackColor =
                    Color.FromArgb(22, 45, 78);
        }
        private void SaveCard_Click(
    object sender,
    EventArgs e)
        {

            if (_currentReport == null)
            {
                MessageBox.Show(
                    "Сначала сформируйте отчет.");

                return;
            }
            SaveFileDialog dialog =
    new SaveFileDialog();
            dialog.Filter =
    "PDF (*.pdf)|*.pdf";
            dialog.FileName =
    _currentReport.ReportName + ".pdf";
            if (dialog.ShowDialog()
    == DialogResult.OK)
            {
                File.Copy(
    _currentPdfPath,
    dialog.FileName,
    true);

                MessageBox.Show(
                    "Отчет успешно сохранен.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void PrintCard_Click(
    object sender,
    EventArgs e)
        {
            if (_currentReport == null)
            {
                MessageBox.Show(
                    "Сначала сформируйте отчет.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                ReportPrinter printer =
                    new ReportPrinter(
                        _currentReport);

                printer.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}