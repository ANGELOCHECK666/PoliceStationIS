using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;

using Npgsql;

using PdfiumViewer;

using PoliceStationIS.Database;

namespace PoliceStationIS.Services
{
    public class ExpertisePrintService
    {
        private readonly int expertiseId;

        public ExpertisePrintService(
            int expertiseId)
        {
            this.expertiseId =
                expertiseId;
        }

        // ============================================================
        // ОСНОВНОЙ МЕТОД
        // ============================================================

        public void GenerateAndPrint(
            IWin32Window owner)
        {
            try
            {
                ExpertisePrintData data =
                    LoadExpertiseData();

                if (data == null)
                {
                    MessageBox.Show(
                        owner,
                        "Выбранная экспертиза не найдена.",
                        "Печать экспертизы",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                byte[] pdfBytes =
                    GeneratePdf(data);

                if (pdfBytes == null ||
                    pdfBytes.Length == 0)
                {
                    throw new Exception(
                        "Не удалось сформировать PDF-файл.");
                }

                string filePath =
                    SavePdfToComputer(
                        data.ExpertiseNumber,
                        pdfBytes);

                SavePdfToDatabase(
                    pdfBytes);

                MessageBox.Show(
                    owner,
                    "Заключение экспертизы успешно сформировано.\n\n" +
                    "Файл сохранён:\n" +
                    filePath,
                    "Документ сформирован",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                PrintPdf(
                    owner,
                    filePath);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    owner,
                    "Ошибка базы данных:\n\n" +
                    ex.MessageText,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    owner,
                    "Не удалось сформировать или напечатать экспертизу:\n\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ЗАГРУЗКА ЭКСПЕРТИЗЫ
        // ============================================================

        private ExpertisePrintData
            LoadExpertiseData()
        {
            ExpertisePrintData data =
                null;

            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
SELECT
    i.inspection_id,

    TRIM(i.inspection_number)
        AS expertise_number,

    it.inspection_type_name
        AS expertise_type,

    ist.inspection_status_name
        AS expertise_status,

    TRIM(
        COALESCE(
            p.protocol_number,
            ''
        )
    )
        AS protocol_number,

    e.last_name
        AS employee_last_name,

    e.name_
        AS employee_name,

    e.middle_name
        AS employee_middle_name,

    i.appointment_date,

    i.research_start_date,

    i.research_end_date,

    COALESCE(
        i.conclusion,
        ''
    )
        AS conclusion

FROM inspection i

INNER JOIN inspection_type it
    ON i.inspection_type_id =
       it.inspection_type_id

INNER JOIN inspection_status ist
    ON i.inspection_status_id =
       ist.inspection_status_id

LEFT JOIN protocol p
    ON i.protocol_id =
       p.protocol_id

INNER JOIN employee e
    ON i.employee_id =
       e.employee_id

WHERE i.inspection_id =
      @inspection_id;
";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    command.Parameters.AddWithValue(
                        "@inspection_id",
                        expertiseId);

                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        data =
                            new ExpertisePrintData();

                        data.ExpertiseId =
                            Convert.ToInt32(
                                reader["inspection_id"]);

                        data.ExpertiseNumber =
                            SafeString(
                                reader["expertise_number"]);

                        data.ExpertiseType =
                            SafeString(
                                reader["expertise_type"]);

                        data.ExpertiseStatus =
                            SafeString(
                                reader["expertise_status"]);

                        data.ProtocolNumber =
                            SafeString(
                                reader["protocol_number"]);

                        data.EmployeeLastName =
                            SafeString(
                                reader["employee_last_name"]);

                        data.EmployeeName =
                            SafeString(
                                reader["employee_name"]);

                        data.EmployeeMiddleName =
                            SafeString(
                                reader["employee_middle_name"]);

                        data.AppointmentDate =
                            reader["appointment_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["appointment_date"]);

                        data.ResearchStartDate =
                            reader["research_start_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["research_start_date"]);

                        data.ResearchEndDate =
                            reader["research_end_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["research_end_date"]);

                        data.Conclusion =
                            SafeString(
                                reader["conclusion"]);
                    }
                }
            }

            return data;
        }

        // ============================================================
        // ФОРМИРОВАНИЕ PDF
        // ============================================================

        private byte[] GeneratePdf(
            ExpertisePrintData data)
        {
            using (MemoryStream stream =
                   new MemoryStream())
            {
                Document document =
                    new Document(
                        PageSize.A4,
                        55,
                        55,
                        60,
                        60);

                BaseFont baseFont =
                    CreateRussianBaseFont();

                iTextSharp.text.Font titleFont =
                    CreateFont(
                        baseFont,
                        15,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font sectionFont =
                    CreateFont(
                        baseFont,
                        13,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font normalFont =
                    CreateFont(
                        baseFont,
                        10.5f,
                        iTextSharp.text.Font.NORMAL);

                iTextSharp.text.Font boldFont =
                    CreateFont(
                        baseFont,
                        10.5f,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font smallFont =
                    CreateFont(
                        baseFont,
                        9,
                        iTextSharp.text.Font.NORMAL);

                PdfWriter writer =
                    PdfWriter.GetInstance(
                        document,
                        stream);

                writer.PageEvent =
                    new ExpertisePdfPageEvent(
                        data.ExpertiseNumber);

                document.Open();

                // ====================================================
                // ШАПКА
                // ====================================================

                Paragraph organization =
                    new Paragraph(
                        "МВД РОССИИ",
                        boldFont);

                organization.Alignment =
                    Element.ALIGN_CENTER;

                organization.SpacingAfter = 4;

                document.Add(
                    organization);

                Paragraph system =
                    new Paragraph(
                        "ИНФОРМАЦИОННАЯ СИСТЕМА " +
                        "ПОЛИЦЕЙСКОГО УЧАСТКА",
                        smallFont);

                system.Alignment =
                    Element.ALIGN_CENTER;

                system.SpacingAfter = 28;

                document.Add(
                    system);

                // ====================================================
                // ЗАГОЛОВОК
                // ====================================================

                AddSectionHeader(
                    document,
                    "ЭКСПЕРТИЗА",
                    sectionFont);

                Paragraph conclusionTitle =
                    new Paragraph(
                        "ЗАКЛЮЧЕНИЕ ЭКСПЕРТА",
                        titleFont);

                conclusionTitle.Alignment =
                    Element.ALIGN_CENTER;

                conclusionTitle.SpacingAfter = 8;

                document.Add(
                    conclusionTitle);

                Paragraph number =
                    new Paragraph(
                        "№ " +
                        SafeValue(
                            data.ExpertiseNumber),
                        boldFont);

                number.Alignment =
                    Element.ALIGN_CENTER;

                number.SpacingAfter = 20;

                document.Add(
                    number);

                // ====================================================
                // ОСНОВНЫЕ ДАННЫЕ
                // ====================================================

                AddDocumentField(
                    document,
                    "Вид экспертизы",
                    data.ExpertiseType,
                    normalFont);

                AddDocumentField(
                    document,
                    "Статус",
                    data.ExpertiseStatus,
                    normalFont);

                AddDocumentField(
                    document,
                    "Связанный протокол",
                    string.IsNullOrWhiteSpace(
                        data.ProtocolNumber)
                        ? "Не связан"
                        : data.ProtocolNumber,
                    normalFont);

                AddDocumentField(
                    document,
                    "Эксперт / сотрудник",
                    data.EmployeeFullName,
                    normalFont);

                AddDocumentField(
                    document,
                    "Дата назначения",
                    FormatDate(
                        data.AppointmentDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Начало исследования",
                    FormatDate(
                        data.ResearchStartDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Окончание исследования",
                    FormatDate(
                        data.ResearchEndDate),
                    normalFont);

                // ====================================================
                // ЗАКЛЮЧЕНИЕ
                // ====================================================

                AddDescriptionBlock(
                    document,
                    "Заключение эксперта",
                    data.Conclusion,
                    normalFont);

                // ====================================================
                // ПОДПИСЬ
                // ====================================================

                AddExpertiseSignature(
                    document,
                    data.EmployeeFullName,
                    normalFont,
                    boldFont);

                Paragraph generated =
                    new Paragraph(
                        "Документ сформирован " +
                        "информационной системой " +
                        "полицейского участка.",
                        smallFont);

                generated.SpacingBefore = 24;

                document.Add(
                    generated);

                document.Close();

                return stream.ToArray();
            }
        }

        // ============================================================
        // ПОДПИСЬ ЭКСПЕРТА
        // ============================================================

        private void AddExpertiseSignature(
            Document document,
            string employeeName,
            iTextSharp.text.Font font,
            iTextSharp.text.Font boldFont)
        {
            Paragraph title =
                new Paragraph(
                    "Ответственное лицо",
                    boldFont);

            title.SpacingBefore = 24;
            title.SpacingAfter = 10;

            document.Add(
                title);

            Paragraph signature =
                new Paragraph(
                    "______________________________    " +
                    SafeValue(employeeName),
                    font);

            signature.SpacingAfter = 8;

            document.Add(
                signature);

            document.Add(
                new Paragraph(
                    "Дата: ____________________",
                    font));
        }

        // ============================================================
        // ПОЛЯ ДОКУМЕНТА
        // ============================================================

        private void AddDocumentField(
            Document document,
            string title,
            string value,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph paragraph =
                new Paragraph();

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 9;

            paragraph.Add(
                new Chunk(
                    title + ": ",
                    bold));

            Chunk valueChunk =
                new Chunk(
                    SafeValue(value),
                    font);

            valueChunk.SetUnderline(
                0.6f,
                -1.5f);

            paragraph.Add(
                valueChunk);

            document.Add(
                paragraph);
        }

        // ============================================================
        // ТЕКСТ ЗАКЛЮЧЕНИЯ
        // ============================================================

        private void AddDescriptionBlock(
            Document document,
            string title,
            string text,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph titleParagraph =
                new Paragraph(
                    title + ":",
                    bold);

            titleParagraph.SpacingBefore = 12;
            titleParagraph.SpacingAfter = 8;

            document.Add(
                titleParagraph);

            Paragraph body =
                new Paragraph(
                    SafeValue(text),
                    font);

            body.Leading = 15;
            body.Alignment =
                Element.ALIGN_JUSTIFIED;

            body.SpacingAfter = 12;

            document.Add(
                body);
        }

        // ============================================================
        // ЗАГОЛОВК
        // ============================================================

        private void AddSectionHeader(
            Document document,
            string text,
            iTextSharp.text.Font font)
        {
            Paragraph paragraph =
                new Paragraph(
                    text,
                    font);

            paragraph.SpacingBefore = 4;
            paragraph.SpacingAfter = 10;

            document.Add(
                paragraph);

            AddSmallRule(
                document);
        }

        private void AddSmallRule(
            Document document)
        {
            PdfPTable lineTable =
                new PdfPTable(1);

            lineTable.WidthPercentage = 100;
            lineTable.SpacingAfter = 12;

            PdfPCell cell =
                new PdfPCell();

            cell.BorderWidth = 0;
            cell.BorderWidthBottom = 0.8f;
            cell.FixedHeight = 2;
            cell.Padding = 0;

            lineTable.AddCell(
                cell);

            document.Add(
                lineTable);
        }

        // ============================================================
        // СОХРАНЕНИЕ НА КОМПЬЮТЕР
        // ============================================================

        private string SavePdfToComputer(
            string expertiseNumber,
            byte[] pdfBytes)
        {
            string documents =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            string directory =
                Path.Combine(
                    documents,
                    "PoliceStationIS",
                    "Экспертизы");

            Directory.CreateDirectory(
                directory);

            string safeNumber =
                MakeSafeFileName(
                    expertiseNumber);

            string fileName =
                "Экспертиза_№_" +
                safeNumber +
                ".pdf";

            string filePath =
                Path.Combine(
                    directory,
                    fileName);

            File.WriteAllBytes(
                filePath,
                pdfBytes);

            return filePath;
        }

        // ============================================================
        // СОХРАНЕНИЕ В БД
        // ============================================================

        private void SavePdfToDatabase(
            byte[] pdfBytes)
        {
            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
UPDATE inspection
SET
    inspection_file = @file
WHERE
    inspection_id = @inspection_id;
";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    command.Parameters.Add(
                        "@file",
                        NpgsqlTypes.NpgsqlDbType.Bytea)
                        .Value = pdfBytes;

                    command.Parameters.Add(
                        "@inspection_id",
                        NpgsqlTypes.NpgsqlDbType.Integer)
                        .Value = expertiseId;

                    int rows =
                        command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        throw new Exception(
                            "Не удалось сохранить сформированный " +
                            "файл экспертизы в базу данных.");
                    }
                }
            }
        }

        // ============================================================
        // ПЕЧАТЬ PDF
        // ============================================================

        private void PrintPdf(
            IWin32Window owner,
            string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    "PDF-файл для печати не найден.",
                    filePath);
            }

            using (PdfiumViewer.PdfDocument pdf =
                   PdfiumViewer.PdfDocument.Load(
                       filePath))
            {
                using (PrintDocument printDocument =
                       pdf.CreatePrintDocument(
                           PdfiumViewer.PdfPrintMode.ShrinkToMargin))
                {
                    printDocument.DocumentName =
                        "Экспертиза № " +
                        Path.GetFileNameWithoutExtension(
                            filePath);

                    using (PrintDialog dialog =
                           new PrintDialog())
                    {
                        dialog.Document =
                            printDocument;

                        dialog.AllowSomePages = true;
                        dialog.AllowCurrentPage = false;
                        dialog.UseEXDialog = true;

                        printDocument.PrinterSettings.FromPage = 1;

                        printDocument.PrinterSettings.ToPage =
                            pdf.PageCount;

                        if (dialog.ShowDialog(owner) ==
                            DialogResult.OK)
                        {
                            printDocument.Print();
                        }
                    }
                }
            }
        }

        // ============================================================
        // КОЛОНТИТУЛ
        // ============================================================

        private class ExpertisePdfPageEvent :
            PdfPageEventHelper
        {
            private readonly string expertiseNumber;

            private BaseFont baseFont;

            public ExpertisePdfPageEvent(
                string expertiseNumber)
            {
                this.expertiseNumber =
                    expertiseNumber;
            }

            public override void OnOpenDocument(
                PdfWriter writer,
                Document document)
            {
                base.OnOpenDocument(
                    writer,
                    document);

                baseFont =
                    CreateRussianBaseFontStatic();
            }

            public override void OnEndPage(
                PdfWriter writer,
                Document document)
            {
                iTextSharp.text.Font footerFont =
                    new iTextSharp.text.Font(
                        baseFont,
                        7.5f,
                        iTextSharp.text.Font.NORMAL,
                        BaseColor.DARK_GRAY);

                PdfContentByte canvas =
                    writer.DirectContent;

                Phrase left =
                    new Phrase(
                        "Экспертиза № " +
                        SafeValueStatic(
                            expertiseNumber),
                        footerFont);

                ColumnText.ShowTextAligned(
                    canvas,
                    Element.ALIGN_LEFT,
                    left,
                    document.LeftMargin,
                    30,
                    0);

                Phrase right =
                    new Phrase(
                        "Страница " +
                        writer.PageNumber,
                        footerFont);

                ColumnText.ShowTextAligned(
                    canvas,
                    Element.ALIGN_RIGHT,
                    right,
                    PageSize.A4.Width -
                    document.RightMargin,
                    30,
                    0);
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

                if (!File.Exists(
                        arialPath))
                {
                    arialPath =
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.Windows),
                            "Fonts",
                            "arial.ttf");
                }

                return BaseFont.CreateFont(
                    arialPath,
                    BaseFont.IDENTITY_H,
                    BaseFont.EMBEDDED);
            }

            private static string SafeValueStatic(
                string value)
            {
                return string.IsNullOrWhiteSpace(
                    value)
                    ? "—"
                    : value;
            }
        }

        // ============================================================
        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
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

            if (!File.Exists(
                    arialPath))
            {
                arialPath =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Windows),
                        "Fonts",
                        "arial.ttf");
            }

            if (!File.Exists(
                    arialPath))
            {
                throw new Exception(
                    "Не найден шрифт Arial. " +
                    "Он необходим для корректного отображения " +
                    "русского текста в PDF.");
            }

            return BaseFont.CreateFont(
                arialPath,
                BaseFont.IDENTITY_H,
                BaseFont.EMBEDDED);
        }

        private iTextSharp.text.Font CreateFont(
            BaseFont baseFont,
            float size,
            int style)
        {
            return new iTextSharp.text.Font(
                baseFont,
                size,
                style,
                BaseColor.BLACK);
        }

        private string FormatDate(
            DateTime? value)
        {
            return value.HasValue
                ? value.Value.ToString(
                    "dd.MM.yyyy")
                : "—";
        }

        private string SafeString(
            object value)
        {
            if (value == null ||
                value == DBNull.Value)
            {
                return "";
            }

            return value.ToString().Trim();
        }

        private static string SafeValue(
            string value)
        {
            return string.IsNullOrWhiteSpace(
                value)
                ? "—"
                : value;
        }

        private string MakeSafeFileName(
            string fileName)
        {
            if (string.IsNullOrWhiteSpace(
                    fileName))
            {
                return "без_номера";
            }

            foreach (char c in
                     Path.GetInvalidFileNameChars())
            {
                fileName =
                    fileName.Replace(
                        c,
                        '_');
            }

            return fileName.Trim();
        }
    }

    // ================================================================
    // МОДЕЛЬ
    // ================================================================

    internal class ExpertisePrintData
    {
        public int ExpertiseId { get; set; }

        public string ExpertiseNumber { get; set; }

        public string ExpertiseType { get; set; }

        public string ExpertiseStatus { get; set; }

        public string ProtocolNumber { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeMiddleName { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public DateTime? ResearchStartDate { get; set; }

        public DateTime? ResearchEndDate { get; set; }

        public string Conclusion { get; set; }

        public string EmployeeFullName
        {
            get
            {
                string result =
                    (
                        EmployeeLastName +
                        " " +
                        EmployeeName +
                        " " +
                        EmployeeMiddleName
                    ).Trim();

                return string.IsNullOrWhiteSpace(
                    result)
                    ? "—"
                    : result;
            }
        }
    }
}