using System;
using System.Collections.Generic;

namespace PoliceStationIS.Reports
{
    public class ReportModel
    {
        // Название отчета
        public string ReportName { get; set; }

        // Период
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        // Дата формирования
        public DateTime CreatedAt { get; set; }

        // Какие колонки будут в таблице
        public List<ReportColumn> Columns { get; set; }

        // Строки таблицы
        public List<List<string>> Rows { get; set; }

        // Подпись
        public string DirectorName { get; set; }

        public string DirectorPost { get; set; }

        // Количество записей
        public int TotalCount { get; set; }

        public ReportModel()
        {
            Columns = new List<ReportColumn>();

            Rows = new List<List<string>>();

            CreatedAt = DateTime.Now;
        }
    }
}