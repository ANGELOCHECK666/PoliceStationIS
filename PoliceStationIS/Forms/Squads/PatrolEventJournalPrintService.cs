using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using Npgsql;

using iTextSharp.text;
using iTextSharp.text.pdf;

using PoliceStationIS.Database;

namespace PoliceStationIS.Services
{
    public class PatrolEventJournalPrintService
    {
        private readonly int patrolServiceId;
        private readonly string squadNumber;

        private JournalData journal;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================

        public PatrolEventJournalPrintService(
            int patrolServiceId,
            string squadNumber)
        {
            this.patrolServiceId = patrolServiceId;
            this.squadNumber = squadNumber;
        }

        // ============================================================
        // MAIN
        // ============================================================

        public void GenerateAndPrint(
            IWin32Window owner)
        {
            journal = LoadJournal();

            if (journal.Events.Count == 0)
            {
                MessageBox.Show(
                    "В выбранном наряде нет событий для печати.",
                    "Печать журнала",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            byte[] pdfBytes = GeneratePdf(journal);

            string filePath =
                SavePdfToComputer(
                    journal.SquadNumber,
                    pdfBytes);

            SavePdfToDatabase(pdfBytes);

            MessageBox.Show(
                "Журнал событий сформирован.\n\n" +
                "Файл сохранён:\n" +
                filePath,
                "Печать журнала",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            PrintPdf(owner, filePath);
        }

        // ============================================================
        // LOAD DATA
        // ============================================================

        private JournalData LoadJournal()
        {
            JournalData result = new JournalData();

            result.SquadNumber =
                string.IsNullOrWhiteSpace(squadNumber)
                    ? "—"
                    : squadNumber;

            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        pel.patrol_event_log_id,
                        rt.recording_type_name,
                        cr.crime_rate_name,
                        pel.scene_of_the_incident,
                        pel.recording_date_and_time,
                        pel.description_recording
                    FROM patrol_event_log pel
                    INNER JOIN recording_type rt
                        ON pel.recording_type_id =
                           rt.recording_type_id
                    INNER JOIN crime_rate cr
                        ON pel.crime_rate_id =
                           cr.crime_rate_id
                    WHERE pel.patrol_and_post_service_id =
                          @service_id
                    ORDER BY pel.recording_date_and_time ASC;";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@service_id",
                        patrolServiceId);

                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JournalEvent item =
                                new JournalEvent();

                            item.Id =
                                Convert.ToInt32(
                                    reader["patrol_event_log_id"]);

                            item.RecordingType =
                                Convert.ToString(
                                    reader["recording_type_name"]);

                            item.CrimeRate =
                                Convert.ToString(
                                    reader["crime_rate_name"]);

                            item.Scene =
                                Convert.ToString(
                                    reader["scene_of_the_incident"]);

                            item.RecordingDateTime =
                                Convert.ToDateTime(
                                    reader["recording_date_and_time"]);

                            item.Description =
                                Convert.ToString(
                                    reader["description_recording"]);

                            result.Events.Add(item);
                        }
                    }
                }
            }

            return result;
        }

        // ============================================================
        // GENERATE PDF
        // ============================================================

        private byte[] GeneratePdf(
            JournalData data)
        {
            using (MemoryStream stream =
                   new MemoryStream())
            {
                Document document =
                    new Document(
                        iTextSharp.text.PageSize.A4,
                        50,
                        50,
                        50,
                        55);

                PdfWriter writer =
                    PdfWriter.GetInstance(
                        document,
                        stream);

                writer.PageEvent =
                    new JournalPageEvent();

                document.Open();

                BaseFont baseFont =
                    CreateRussianBaseFont();

                iTextSharp.text.Font normalFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        10f,
                        iTextSharp.text.Font.NORMAL,
                        BaseColor.BLACK);

                iTextSharp.text.Font boldFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        10f,
                        iTextSharp.text.Font.BOLD,
                        BaseColor.BLACK);

                iTextSharp.text.Font titleFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        15f,
                        iTextSharp.text.Font.BOLD,
                        BaseColor.BLACK);

                iTextSharp.text.Font smallFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        8f,
                        iTextSharp.text.Font.NORMAL,
                        BaseColor.BLACK);

                // ====================================================
                // HEADER
                // ====================================================

                Paragraph mvd =
                    new Paragraph(
                        "МВД РОССИИ",
                        boldFont);

                mvd.Alignment =
                    Element.ALIGN_CENTER;

                document.Add(mvd);

                Paragraph system =
                    new Paragraph(
                        "ИНФОРМАЦИОННАЯ СИСТЕМА " +
                        "ПОЛИЦЕЙСКОГО УЧАСТКА",
                        smallFont);

                system.Alignment =
                    Element.ALIGN_CENTER;

                system.SpacingAfter = 18f;

                document.Add(system);

                Paragraph title =
                    new Paragraph(
                        "ПОЛНЫЙ ЖУРНАЛ СОБЫТИЙ",
                        titleFont);

                title.Alignment =
                    Element.ALIGN_CENTER;

                title.SpacingAfter = 18f;

                document.Add(title);

                AddSeparator(
                    document);

                // ====================================================
                // GENERAL INFORMATION
                // ====================================================

                AddSectionTitle(
                    document,
                    "ОБЩИЕ СВЕДЕНИЯ",
                    baseFont);

                AddField(
                    document,
                    "Номер наряда",
                    data.SquadNumber,
                    normalFont,
                    boldFont);

                AddField(
                    document,
                    "Количество событий",
                    data.Events.Count.ToString(),
                    normalFont,
                    boldFont);

                if (data.Events.Count > 0)
                {
                    AddField(
                        document,
                        "Период событий",
                        data.Events[0]
                            .RecordingDateTime
                            .ToString("dd.MM.yyyy HH:mm")
                        + " — " +
                        data.Events[
                            data.Events.Count - 1]
                            .RecordingDateTime
                            .ToString("dd.MM.yyyy HH:mm"),
                        normalFont,
                        boldFont);
                }

                document.Add(
                    new Paragraph(
                        " ",
                        normalFont));

                // ====================================================
                // EVENTS
                // ====================================================

                AddSectionTitle(
                    document,
                    "ЗАПИСИ ЖУРНАЛА",
                    baseFont);

                int eventNumber = 1;

                foreach (JournalEvent item
                         in data.Events)
                {
                    AddEventBlock(
                        document,
                        item,
                        eventNumber,
                        normalFont,
                        boldFont);

                    eventNumber++;
                }

                // ====================================================
                // FINAL
                // ====================================================

                document.Add(
                    new Paragraph(
                        " ",
                        normalFont));

                AddSeparator(document);

                Paragraph finalNote =
                    new Paragraph(
                        "Журнал событий сформирован " +
                        "информационной системой " +
                        "полицейского участка.",
                        smallFont);

                finalNote.SpacingBefore = 10f;

                document.Add(finalNote);

                document.Close();

                return stream.ToArray();
            }
        }

        // ============================================================
        // EVENT BLOCK
        // ============================================================

        private void AddEventBlock(
            Document document,
            JournalEvent item,
            int number,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font boldFont)
        {
            PdfPTable block =
                new PdfPTable(1);

            block.WidthPercentage = 100f;
            block.SpacingAfter = 12f;

            PdfPCell headerCell =
                new PdfPCell();

            headerCell.BackgroundColor =
                new BaseColor(
                    235,
                    235,
                    235);

            headerCell.BorderColor =
                new BaseColor(
                    160,
                    160,
                    160);

            headerCell.BorderWidth = 0.8f;
            headerCell.Padding = 8f;

            Paragraph header =
                new Paragraph(
                    "СОБЫТИЕ №" +
                    number +
                    "    " +
                    item.RecordingDateTime
                        .ToString(
                            "dd.MM.yyyy HH:mm"),
                    boldFont);

            headerCell.AddElement(header);
            block.AddCell(headerCell);

            PdfPCell bodyCell =
                new PdfPCell();

            bodyCell.BorderColor =
                new BaseColor(
                    180,
                    180,
                    180);

            bodyCell.BorderWidth = 0.8f;
            bodyCell.Padding = 10f;

            AddCellParagraph(
                bodyCell,
                "Тип записи",
                item.RecordingType,
                normalFont,
                boldFont);

            AddCellParagraph(
                bodyCell,
                "Уровень происшествия",
                item.CrimeRate,
                normalFont,
                boldFont);

            AddCellParagraph(
                bodyCell,
                "Место происшествия",
                item.Scene,
                normalFont,
                boldFont);

            AddCellParagraph(
                bodyCell,
                "Описание",
                item.Description,
                normalFont,
                boldFont);

            block.AddCell(bodyCell);

            document.Add(block);
        }

        // ============================================================
        // CELL PARAGRAPH
        // ============================================================

        private void AddCellParagraph(
            PdfPCell cell,
            string title,
            string value,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font boldFont)
        {
            Paragraph paragraph =
                new Paragraph();

            paragraph.SpacingAfter = 6f;

            paragraph.Add(
                new Chunk(
                    title + ": ",
                    boldFont));

            paragraph.Add(
                new Chunk(
                    string.IsNullOrWhiteSpace(value)
                        ? "—"
                        : value,
                    normalFont));

            cell.AddElement(paragraph);
        }

        // ============================================================
        // SECTION TITLE
        // ============================================================

        private void AddSectionTitle(
            Document document,
            string text,
            BaseFont baseFont)
        {
            iTextSharp.text.Font sectionFont =
                new iTextSharp.text.Font(
                    baseFont,
                    10f,
                    iTextSharp.text.Font.BOLD,
                    BaseColor.BLACK);

            Paragraph paragraph =
                new Paragraph(
                    text,
                    sectionFont);

            paragraph.SpacingBefore = 8f;
            paragraph.SpacingAfter = 8f;

            document.Add(paragraph);

            AddSeparator(document);
        }

        // ============================================================
        // FIELD
        // ============================================================

        private void AddField(
            Document document,
            string title,
            string value,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font boldFont)
        {
            Paragraph paragraph =
                new Paragraph();

            paragraph.SpacingAfter = 6f;

            paragraph.Add(
                new Chunk(
                    title + ": ",
                    boldFont));

            paragraph.Add(
                new Chunk(
                    string.IsNullOrWhiteSpace(value)
                        ? "—"
                        : value,
                    normalFont));

            document.Add(paragraph);
        }

        // ============================================================
        // SEPARATOR
        // ============================================================

        private void AddSeparator(
            Document document)
        {
            PdfPTable table =
                new PdfPTable(1);

            table.WidthPercentage = 100f;

            PdfPCell cell =
                new PdfPCell();

            cell.Border =
                iTextSharp.text.Rectangle.BOTTOM_BORDER;

            cell.BorderWidth = 0.8f;
            cell.BorderColor = BaseColor.BLACK;
            cell.FixedHeight = 3f;

            table.AddCell(cell);

            document.Add(table);
        }

        // ============================================================
        // RUSSIAN FONT
        // ============================================================

        private BaseFont CreateRussianBaseFont()
        {
            string fontsDirectory =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Fonts);

            string arialPath =
                Path.Combine(
                    fontsDirectory,
                    "arial.ttf");

            if (!File.Exists(arialPath))
            {
                arialPath =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Windows),
                        "Fonts",
                        "arial.ttf");
            }

            if (!File.Exists(arialPath))
            {
                throw new Exception(
                    "Не найден шрифт Arial. " +
                    "Он необходим для корректного " +
                    "отображения русского текста в PDF.");
            }

            return BaseFont.CreateFont(
                arialPath,
                BaseFont.IDENTITY_H,
                BaseFont.EMBEDDED);
        }

        // ============================================================
        // SAVE TO COMPUTER
        // ============================================================

        private string SavePdfToComputer(
            string squadNumber,
            byte[] pdfBytes)
        {
            string documents =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            string folder =
                Path.Combine(
                    documents,
                    "PoliceStationIS",
                    "Журналы событий");

            Directory.CreateDirectory(folder);

            string safeNumber =
                MakeSafeFileName(
                    string.IsNullOrWhiteSpace(
                        squadNumber)
                        ? "Без_номера"
                        : squadNumber);

            string filePath =
                Path.Combine(
                    folder,
                    "Журнал_событий_наряд_" +
                    safeNumber +
                    ".pdf");

            File.WriteAllBytes(
                filePath,
                pdfBytes);

            return filePath;
        }

        // ============================================================
        // SAVE TO DATABASE
        // ============================================================

        private void SavePdfToDatabase(
            byte[] pdfBytes)
        {
            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE patrol_event_log
                    SET patrol_event_log_file = @file
                    WHERE patrol_and_post_service_id =
                          @service_id;";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    command.Parameters.AddWithValue(
                        "@file",
                        pdfBytes);

                    command.Parameters.AddWithValue(
                        "@service_id",
                        patrolServiceId);

                    command.ExecuteNonQuery();
                }
            }
        }

        // ============================================================
        // PRINT PDF
        // ============================================================

        private void PrintPdf(
            IWin32Window owner,
            string filePath)
        {
            using (PdfiumViewer.PdfDocument pdf =
                   PdfiumViewer.PdfDocument.Load(
                       filePath))
            {
                PrintDocument printDocument =
                    pdf.CreatePrintDocument(
                        PdfiumViewer.PdfPrintMode
                            .ShrinkToMargin);

                using (PrintDialog printDialog =
                       new PrintDialog())
                {
                    printDialog.Document =
                        printDocument;

                    printDialog.AllowSomePages =
                        true;

                    printDialog.UseEXDialog =
                        true;

                    if (printDialog.ShowDialog(owner) ==
                        DialogResult.OK)
                    {
                        printDocument.Print();
                    }
                }
            }
        }

        // ============================================================
        // SAFE FILE NAME
        // ============================================================

        private string MakeSafeFileName(
            string value)
        {
            foreach (char character
                     in Path.GetInvalidFileNameChars())
            {
                value =
                    value.Replace(
                        character,
                        '_');
            }

            return value;
        }

        // ============================================================
        // DATA CLASSES
        // ============================================================

        private class JournalData
        {
            public string SquadNumber
            {
                get;
                set;
            }

            public List<JournalEvent> Events
            {
                get;
                set;
            }

            public JournalData()
            {
                Events =
                    new List<JournalEvent>();
            }
        }

        private class JournalEvent
        {
            public int Id
            {
                get;
                set;
            }

            public string RecordingType
            {
                get;
                set;
            }

            public string CrimeRate
            {
                get;
                set;
            }

            public string Scene
            {
                get;
                set;
            }

            public DateTime RecordingDateTime
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }
        }

        // ============================================================
        // FOOTER
        // ============================================================

        private class JournalPageEvent
            : PdfPageEventHelper
        {
            private BaseFont baseFont;

            public override void OnOpenDocument(
                PdfWriter writer,
                Document document)
            {
                baseFont =
                    CreateRussianBaseFontStatic();
            }

            public override void OnEndPage(
                PdfWriter writer,
                Document document)
            {
                PdfContentByte canvas =
                    writer.DirectContent;

                iTextSharp.text.Font footerFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        8f,
                        iTextSharp.text.Font.NORMAL,
                        BaseColor.BLACK);

                string text =
                    "ЖУРНАЛ СОБЫТИЙ  |  Страница " +
                    writer.PageNumber;

                ColumnText.ShowTextAligned(
                    canvas,
                    Element.ALIGN_CENTER,
                    new Phrase(
                        text,
                        footerFont),
                    (document.Left +
                     document.Right) / 2f,
                    25f,
                    0f);
            }

            private static BaseFont
                CreateRussianBaseFontStatic()
            {
                string fontsDirectory =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Fonts);

                string arialPath =
                    Path.Combine(
                        fontsDirectory,
                        "arial.ttf");

                if (!File.Exists(arialPath))
                {
                    arialPath =
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.Windows),
                            "Fonts",
                            "arial.ttf");
                }

                if (!File.Exists(arialPath))
                {
                    throw new Exception(
                        "Не найден шрифт Arial. " +
                        "Он необходим для корректного " +
                        "отображения русского текста в PDF.");
                }

                return BaseFont.CreateFont(
                    arialPath,
                    BaseFont.IDENTITY_H,
                    BaseFont.EMBEDDED);
            }
        }
    }
}
