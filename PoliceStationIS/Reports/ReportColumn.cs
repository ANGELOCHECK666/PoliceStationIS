namespace PoliceStationIS.Reports
{
    public class ReportColumn
    {
        // Заголовок столбца
        public string Header { get; set; }

        // Ширина столбца
        public int Width { get; set; }

        public ReportColumn()
        {

        }

        public ReportColumn(string header, int width)
        {
            Header = header;

            Width = width;
        }
    }
}