using System;
using System.Collections.Generic;

namespace PoliceStationIS.Reports
{
    public class ReportGenerator
    {
        private readonly ReportDataProvider _provider;

        public ReportGenerator()
        {
            _provider = new ReportDataProvider();
        }

        public ReportModel Generate(
    int reportTypeId,
    string reportName,
    DateTime dateFrom,
    DateTime dateTo,
    List<string> selectedOptions)
        {
            ReportModel model = new ReportModel();

            model.ReportName = reportName;

            model.DateFrom = dateFrom;

            model.DateTo = dateTo;

            CreateColumns(
                model,
                reportTypeId,
                selectedOptions);

            model.Rows =
                _provider.GetReportData(
                    reportTypeId,
                    dateFrom,
                    dateTo,
                    selectedOptions);

            model.TotalCount =
                model.Rows.Count;

            return model;
        }

        private void CreateColumns(
    ReportModel model,
    int reportTypeId,
    List<string> options)
        {
            
            model.Columns.Clear();

            model.Columns.Add(new ReportColumn("№", 50));

            model.Columns.Add(new ReportColumn("ФИО", 220));

            foreach (string option in options)
            {
                switch (option)
                {
                    case "Добавить старую должность":

                        model.Columns.Add(
                            new ReportColumn(
                                "Старая должность",
                                170));

                        break;

                    case "Добавить новую должность":

                        model.Columns.Add(
                            new ReportColumn(
                                "Новая должность",
                                170));

                        break;

                    case "Добавить дату изменения":

                        model.Columns.Add(
                            new ReportColumn(
                                "Дата изменения",
                                120));

                        break;

                    case "Добавить должность":

                        model.Columns.Add(
                            new ReportColumn(
                                "Должность",
                                170));

                        break;

                    case "Добавить подразделение":

                        model.Columns.Add(
                            new ReportColumn(
                                "Подразделение",
                                170));

                        break;

                    case "Добавить дату приема":

                        model.Columns.Add(
                            new ReportColumn(
                                "Дата приема",
                                120));

                        break;

                    case "Добавить количество дней":

                        model.Columns.Add(
                            new ReportColumn(
                                "Количество дней",
                                120));

                        break;

                    case "Добавить дату выхода":

                        model.Columns.Add(
                            new ReportColumn(
                                "Дата выхода",
                                120));

                        break;

                    case "Добавить период больничного":

                        model.Columns.Add(
                            new ReportColumn(
                                "Период больничного",
                                170));

                        break;

                    case "Добавить дату увольнения":

                        model.Columns.Add(
                            new ReportColumn(
                                "Дата увольнения",
                                120));

                        break;

                    case "Добавить подпись руководителя":

                        model.DirectorPost =
                            "Начальник отдела кадров";

                        model.DirectorName =
                            "Павлов А. С.";

                        break;
                }
            }

        }
    }
}