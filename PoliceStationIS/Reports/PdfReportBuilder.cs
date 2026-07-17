using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;

namespace PoliceStationIS.Reports
{
    public class PdfReportBuilder
    {
        private readonly BaseFont _baseFont;

        public PdfReportBuilder()
        {
            string fontPath =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Fonts),
                    "arial.ttf");

            _baseFont =
                BaseFont.CreateFont(
                    fontPath,
                    BaseFont.IDENTITY_H,
                    BaseFont.EMBEDDED);
        }

        public string Build(
    ReportModel model,
    string filePath)
        {
            Document document =
                new Document(
                    PageSize.A4,
                    40,
                    40,
                    40,
                    40);

            PdfWriter.GetInstance(
                document,
                new FileStream(
                    filePath,
                    FileMode.Create));

            document.Open();

            AddHeader(document);

            AddTitle(document, model);

            AddReportName(document, model);

            AddPeriod(document, model);

            AddTable(document, model);

            AddFooter(document, model);

            document.Close();

            return filePath;
        }

        private void AddTitle(
    Document document,
    ReportModel model)
        {
            Font titleFont =
    new Font(
        _baseFont,
        18,
        Font.BOLD);

            Paragraph title =
                new Paragraph(
                    "КАДРОВЫЙ ОТЧЕТ",
                    titleFont);

            title.Alignment =
                Element.ALIGN_CENTER;

            title.SpacingBefore = 18;

            title.SpacingAfter = 8;

            document.Add(title);
        }

        private void AddReportName(
    Document document,
    ReportModel model)
        {
            Font subtitleFont =
    new Font(
        _baseFont,
        13);

            Paragraph subtitle =
                new Paragraph(
                    model.ReportName,
                    subtitleFont);

            subtitle.Alignment =
                Element.ALIGN_CENTER;
            subtitle.SpacingAfter = 18;

            subtitle.SpacingAfter = 20;

            document.Add(subtitle);
        }

        private void AddPeriod(
    Document document,
    ReportModel model)
        {
            Font infoFont =
    new Font(
        _baseFont,
        11);
            Paragraph period =
    new Paragraph(
        $"Период: {model.DateFrom:dd.MM.yyyy} - {model.DateTo:dd.MM.yyyy}",
        infoFont);

            period.SpacingAfter = 20;

            Paragraph created =
     new Paragraph(
         $"Дата формирования: {model.CreatedAt:dd.MM.yyyy}",
         infoFont);

            created.SpacingAfter = 20;

            document.Add(period);

            document.Add(created);

            return;
        }

        private void AddTable(
    Document document,
    ReportModel model)
        {

            PdfPTable table =
    new PdfPTable(
        model.Columns.Count);

            table.WidthPercentage = 100;
            float[] widths =
    new float[
        model.Columns.Count];
            for (int i = 0;
     i < model.Columns.Count;
     i++)
            {
                widths[i] =
                    model.Columns[i].Width;
            }
            table.SetWidths(widths);
            table.SpacingBefore = 15;
            table.SpacingAfter = 20;

            Font headerFont =
    new Font(
        _baseFont,
        10,
        Font.BOLD);

            foreach (ReportColumn column
    in model.Columns)
            {
                PdfPCell cell =
    new PdfPCell(
        new Phrase(
            column.Header,
            headerFont));
                cell.HorizontalAlignment =
    Element.ALIGN_CENTER;
                cell.VerticalAlignment =
    Element.ALIGN_MIDDLE;
                cell.MinimumHeight = 28;
                cell.PaddingTop = 6;

                cell.PaddingBottom = 6;

                cell.BackgroundColor =
    new BaseColor(232, 236, 242);
                table.AddCell(cell);
            }
            Font rowFont =
    new Font(
        _baseFont,
        10);
            foreach (List<string> row
    in model.Rows)
            {
                int columnIndex = 0;

                foreach (string value
    in row)
                {

                    PdfPCell cell =
    new PdfPCell(
        new Phrase(
            value,
            rowFont));
                    if (columnIndex == 0)
                    {
                        cell.HorizontalAlignment =
                            Element.ALIGN_CENTER;
                    }
                    else
                    {
                        cell.HorizontalAlignment =
                            Element.ALIGN_LEFT;
                    }

                    cell.VerticalAlignment =
                        Element.ALIGN_MIDDLE;
                    cell.BorderWidth = 1;

                    cell.MinimumHeight = 24;

                    cell.PaddingTop = 5;

                    cell.PaddingBottom = 5;
                    cell.NoWrap = false;

                    cell.BorderWidth = 0.5F;

                    table.AddCell(cell);

                    columnIndex++;

                }

            }
            table.HeaderRows = 1;
            document.Add(table);
        }

        private void AddHeader(
    Document document)
        {

            document.Add(new Paragraph(" "));
            Font ministryFont =
    new Font(
        _baseFont,
        13,
        Font.BOLD);

            Paragraph ministry =
                new Paragraph(
                    "Министерство внутренних дел Российской Федерации",
                    ministryFont);

            ministry.Alignment =
                Element.ALIGN_CENTER;

            document.Add(ministry);
            Font systemFont =
    new Font(
        _baseFont,
        11);

            Paragraph system =
                new Paragraph(
                    "Информационная система \"Police Station\"",
                    systemFont);

            system.Alignment =
                Element.ALIGN_CENTER;

            system.SpacingAfter = 10;

            document.Add(system);
            LineSeparator line =
    new LineSeparator();

            line.LineWidth = 1.5F;

            line.Percentage = 100;

            document.Add(
                new Chunk(line));

        }

        private void AddFooter(
    Document document,
    ReportModel model)
        {
            Font footerFont =
                new Font(
                    _baseFont,
                    11);

            document.Add(new Paragraph(" "));

            document.Add(new Paragraph(" "));

            Paragraph total =
                new Paragraph(
                    $"Всего записей: {model.TotalCount}",
                    footerFont);

            total.SpacingAfter = 25;

            document.Add(total);

            if (!string.IsNullOrWhiteSpace(model.DirectorPost))
            {
                Paragraph post =
                    new Paragraph(
                        model.DirectorPost,
                        footerFont);

                post.Alignment =
                    Element.ALIGN_RIGHT;

                document.Add(post);
            }

            if (!string.IsNullOrWhiteSpace(model.DirectorName))
            {
                Paragraph sign =
                    new Paragraph(
                        "______________   " +
                        model.DirectorName,
                        footerFont);

                sign.Alignment =
                    Element.ALIGN_RIGHT;

                sign.SpacingBefore = 15;

                document.Add(sign);
            }
        }

    }
}