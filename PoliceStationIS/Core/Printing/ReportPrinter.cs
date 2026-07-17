using PoliceStationIS.Reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PoliceStationIS.Core.Printing
{
    public class ReportPrinter
    {
        private readonly ReportModel _model;

        public ReportPrinter(ReportModel model)
        {
            _model = model;
        }

        public void Print()
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.DefaultPageSettings.Landscape = false;

            printDocument.PrintPage += PrintPage;

            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.Document = printDocument;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void PrintPage(
    object sender,
    PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int y = 50;

            DrawHeader(g, ref y);

            DrawTitle(g, ref y);

            DrawPeriod(g, ref y);

            DrawTable(g, ref y);

            DrawFooter(g, ref y);

            e.HasMorePages = false;
        }

        private void DrawHeader(
    Graphics g,
    ref int y)
        {
            Font titleFont =
    new Font(
        "Arial",
        14,
        FontStyle.Bold);

            StringFormat center =
                new StringFormat();

            center.Alignment =
                StringAlignment.Center;

            Rectangle rect =
                new Rectangle(
                    0,
                    y,
                    800,
                    30);

            g.DrawString(
                "Министерство внутренних дел Российской Федерации",
                titleFont,
                Brushes.Black,
                rect,
                center);

            y += 30;

            Font subFont =
                new Font(
                    "Arial",
                    11);

            g.DrawString(
                "Информационная система Police Station",
                subFont,
                Brushes.Black,
                rect = new Rectangle(
                    0,
                    y,
                    800,
                    25),
                center);

            y += 35;

            g.DrawLine(
                Pens.Black,
                60,
                y,
                740,
                y);

            y += 25;

        }

        private void DrawTitle(
    Graphics g,
    ref int y)
        {
            Font title =
    new Font(
        "Arial",
        18,
        FontStyle.Bold);

            StringFormat center =
                new StringFormat();

            center.Alignment =
                StringAlignment.Center;

            Rectangle rect =
                new Rectangle(
                    0,
                    y,
                    800,
                    35);

            g.DrawString(
                "КАДРОВЫЙ ОТЧЕТ",
                title,
                Brushes.Black,
                rect,
                center);

            y += 35;

            Font reportFont =
                new Font(
                    "Arial",
                    13);

            g.DrawString(
                _model.ReportName,
                reportFont,
                Brushes.Black,
                new Rectangle(
                    0,
                    y,
                    800,
                    25),
                center);

            y += 40;

        }
        private void DrawPeriod(
    Graphics g,
    ref int y)
        {
            Font font =
    new Font(
        "Arial",
        11);

            g.DrawString(
                $"Период: {_model.DateFrom:dd.MM.yyyy} - {_model.DateTo:dd.MM.yyyy}",
                font,
                Brushes.Black,
                60,
                y);

            y += 22;

            g.DrawString(
                $"Дата формирования: {_model.CreatedAt:dd.MM.yyyy}",
                font,
                Brushes.Black,
                60,
                y);

            y += 35;

        }

        private void DrawTable(
    Graphics g,
    ref int y)
        {
            int left = 60;

            int tableWidth = 700;

            int headerHeight = 35;

            int rowHeight = 28;

            int totalWidth = 0;

            foreach (ReportColumn column in _model.Columns)
            {
                totalWidth += column.Width;
            }
            Font headerFont =
    new Font(
        "Arial",
        10,
        FontStyle.Bold);

            Font rowFont =
                new Font(
                    "Arial",
                    10);
            StringFormat cellFormat =
    new StringFormat();

            cellFormat.Alignment =
                StringAlignment.Near;

            cellFormat.LineAlignment =
                StringAlignment.Center;

            cellFormat.FormatFlags =
                StringFormatFlags.LineLimit;
            int currentX = left;

            foreach (ReportColumn column
    in _model.Columns)
            {
                int width =
    (int)(
        (double)column.Width
        / totalWidth
        * tableWidth);
                Rectangle rect =
    new Rectangle(
        currentX,
        y,
        width,
        headerHeight);
                g.DrawRectangle(
    Pens.Black,
    rect);
                StringFormat center =
    new StringFormat();

                center.Alignment =
                    StringAlignment.Center;

                center.LineAlignment =
                    StringAlignment.Center;
                g.DrawString(
    column.Header,
    headerFont,
    Brushes.Black,
    rect,
    center);
                currentX += width;
            }
            y += headerHeight;

            foreach (List<string> row
    in _model.Rows)
            {
                currentX = left;

                int columnIndex = 0;
                int currentRowHeight = rowHeight;

                foreach (string value
    in row)
                {
                    int width =
    (int)(
        (double)_model.Columns[columnIndex].Width
        / totalWidth
        * tableWidth);

                    Rectangle rect =
     new Rectangle(
         currentX,
         y,
         width,
         currentRowHeight);
                    SizeF textSize =
    g.MeasureString(
        value,
        rowFont,
        width - 8);
                    if (textSize.Height + 6 >
    currentRowHeight)
                    {
                        currentRowHeight =
                            (int)textSize.Height + 6;
                    }
                    g.DrawRectangle(
    Pens.Black,
    rect);

                    RectangleF textRect =
    new RectangleF(
        rect.X + 4,
        rect.Y + 2,
        rect.Width - 8,
        rect.Height - 4);

                    g.DrawString(
    value,
    rowFont,
    Brushes.Black,
    textRect,
    cellFormat);

                    currentX += width;

                    columnIndex++;
                }
                y += currentRowHeight;
            }
        }

        private void DrawFooter(
    Graphics g,
    ref int y)
        {
            Font font =
                new Font(
                    "Arial",
                    11);

            Font bold =
                new Font(
                    "Arial",
                    11,
                    FontStyle.Bold);

            y += 20;

            g.DrawString(
                $"Всего записей: {_model.TotalCount}",
                bold,
                Brushes.Black,
                60,
                y);

            y += 45;

            if (!string.IsNullOrWhiteSpace(_model.DirectorPost))
            {
                g.DrawString(
                    _model.DirectorPost,
                    font,
                    Brushes.Black,
                    60,
                    y);
            }

            g.DrawLine(
                Pens.Black,
                420,
                y + 18,
                650,
                y + 18);

            y += 25;

            if (!string.IsNullOrWhiteSpace(_model.DirectorName))
            {
                g.DrawString(
                    _model.DirectorName,
                    font,
                    Brushes.Black,
                    430,
                    y);
            }
        }
    }
}