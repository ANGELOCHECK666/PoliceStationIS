using System;
using System.Collections.Generic;
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
    public class ProtocolPrintService
    {
        private readonly int protocolId;

        public ProtocolPrintService(
            int protocolId)
        {
            this.protocolId = protocolId;
        }

        // ============================================================
        // ОСНОВНОЙ МЕТОД
        // ============================================================

        public void GenerateAndPrint(
            IWin32Window owner)
        {
            try
            {
                ProtocolPrintData data =
                    LoadProtocolData();

                if (data == null)
                {
                    MessageBox.Show(
                        owner,
                        "Выбранный протокол не найден.",
                        "Печать протокола",
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
                        data.ProtocolNumber,
                        pdfBytes);

                SavePdfToDatabase(
                    pdfBytes);

                MessageBox.Show(
                    owner,
                    "Протокол успешно сформирован.\n\n" +
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
                    "Не удалось сформировать или напечатать протокол:\n\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ЗАГРУЗКА ДАННЫХ ПРОТОКОЛА
        // ============================================================

        private ProtocolPrintData LoadProtocolData()
        {
            ProtocolPrintData data = null;

            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
SELECT
    p.protocol_id,
    TRIM(p.protocol_number)
        AS protocol_number,

    pt.protocol_type_name
        AS protocol_type_name,

    ps.protocol_status_name
        AS protocol_status_name,

    p.date_of_preparation_protocol
        AS preparation_date,

    p.place_of_commission
        AS place_of_commission,

    p.description_protocol
        AS description_protocol,

    e.last_name
        AS employee_last_name,

    e.name_
        AS employee_name,

    e.middle_name
        AS employee_middle_name,

    (
        SELECT
            STRING_AGG(
                TRIM(cc.case_number),
                ', '
                ORDER BY cc.case_number
            )
        FROM criminal_case cc
        WHERE cc.protocol_id =
              p.protocol_id
    )
        AS case_numbers

FROM protocol p

INNER JOIN protocol_type pt
    ON p.protocol_type_id =
       pt.protocol_type_id

INNER JOIN protocol_status ps
    ON p.protocol_status_id =
       ps.protocol_status_id

INNER JOIN employee e
    ON p.employee_id =
       e.employee_id

WHERE p.protocol_id = @protocol_id;
";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    command.Parameters.AddWithValue(
                        "@protocol_id",
                        protocolId);

                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        data =
                            new ProtocolPrintData();

                        data.ProtocolId =
                            Convert.ToInt32(
                                reader["protocol_id"]);

                        data.ProtocolNumber =
                            SafeString(
                                reader["protocol_number"]);

                        data.ProtocolType =
                            SafeString(
                                reader["protocol_type_name"]);

                        data.ProtocolStatus =
                            SafeString(
                                reader["protocol_status_name"]);

                        data.PreparationDate =
                            reader["preparation_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["preparation_date"]);

                        data.Place =
                            SafeString(
                                reader["place_of_commission"]);

                        data.Description =
                            SafeString(
                                reader["description_protocol"]);

                        data.EmployeeLastName =
                            SafeString(
                                reader["employee_last_name"]);

                        data.EmployeeName =
                            SafeString(
                                reader["employee_name"]);

                        data.EmployeeMiddleName =
                            SafeString(
                                reader["employee_middle_name"]);

                        data.CaseNumbers =
                            SafeString(
                                reader["case_numbers"]);
                    }
                }

                LoadProtocolCitizens(
                    connection,
                    data);
            }

            return data;
        }

        // ============================================================
        // ЛИЦА, УКАЗАННЫЕ В ПРОТОКОЛЕ
        // ============================================================

        private void LoadProtocolCitizens(
            NpgsqlConnection connection,
            ProtocolPrintData data)
        {
            string query = @"
SELECT
    c.last_name,
    c.name_,
    c.middle_name,
    c.passport_series,
    c.passport_number,
    c.phone_number,
    pc.was_warned

FROM protocol_citizen pc

INNER JOIN citizen c
    ON c.citizen_id =
       pc.citizen_id

WHERE pc.protocol_id =
      @protocol_id

ORDER BY
    c.last_name,
    c.name_,
    c.middle_name;
";

            using (NpgsqlCommand command =
                   new NpgsqlCommand(
                       query,
                       connection))
            {
                command.Parameters.AddWithValue(
                    "@protocol_id",
                    data.ProtocolId);

                using (NpgsqlDataReader reader =
                       command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocolPrintCitizen citizen =
                            new ProtocolPrintCitizen();

                        citizen.LastName =
                            SafeString(
                                reader["last_name"]);

                        citizen.FirstName =
                            SafeString(
                                reader["name_"]);

                        citizen.MiddleName =
                            SafeString(
                                reader["middle_name"]);

                        citizen.PassportSeries =
                            SafeString(
                                reader["passport_series"]);

                        citizen.PassportNumber =
                            SafeString(
                                reader["passport_number"]);

                        citizen.Phone =
                            SafeString(
                                reader["phone_number"]);

                        citizen.WasWarned =
                            reader["was_warned"] !=
                            DBNull.Value &&
                            Convert.ToBoolean(
                                reader["was_warned"]);

                        data.Citizens.Add(
                            citizen);
                    }
                }
            }
        }

        // ============================================================
        // ФОРМИРОВАНИЕ PDF
        // ============================================================

        private byte[] GeneratePdf(
            ProtocolPrintData data)
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
                    new ProtocolPdfPageEvent(
                        data.ProtocolNumber);

                document.Open();

                // ====================================================
                // ЗАГОЛОВОК
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

                AddSectionHeader(
                    document,
                    "ПРОТОКОЛ",
                    sectionFont);

                Paragraph protocolTitle =
                    new Paragraph(
                        string.IsNullOrWhiteSpace(
                            data.ProtocolType)
                            ? "ПРОТОКОЛ"
                            : data.ProtocolType.ToUpper(),
                        titleFont);

                protocolTitle.Alignment =
                    Element.ALIGN_CENTER;

                protocolTitle.SpacingAfter = 8;

                document.Add(
                    protocolTitle);

                Paragraph number =
                    new Paragraph(
                        "№ " +
                        SafeValue(
                            data.ProtocolNumber),
                        boldFont);

                number.Alignment =
                    Element.ALIGN_CENTER;

                number.SpacingAfter = 20;

                document.Add(
                    number);

                // ====================================================
                // МЕСТО И ДАТА
                // ====================================================

                AddProtocolIntroLine(
                    document,
                    data.Place,
                    data.PreparationDate,
                    normalFont);

                AddSmallRule(
                    document);

                // ====================================================
                // СВЯЗЬ С ДЕЛОМ
                // ====================================================

                AddDocumentField(
                    document,
                    "Уголовное дело",
                    string.IsNullOrWhiteSpace(
                        data.CaseNumbers)
                        ? "Не связано"
                        : data.CaseNumbers,
                    normalFont);

                AddDocumentField(
                    document,
                    "Статус протокола",
                    data.ProtocolStatus,
                    normalFont);

                // ====================================================
                // СОДЕРЖАНИЕ
                // ====================================================

                AddDescriptionBlock(
                    document,
                    "Содержание протокола",
                    data.Description,
                    normalFont);

                // ====================================================
                // ЛИЦА
                // ====================================================

                if (data.Citizens.Count > 0)
                {
                    AddPersonHeader(
                        document,
                        "ЛИЦА, УКАЗАННЫЕ В ПРОТОКОЛЕ",
                        boldFont);

                    for (int i = 0;
                         i < data.Citizens.Count;
                         i++)
                    {
                        AddProtocolPerson(
                            document,
                            data.Citizens[i],
                            i + 1,
                            smallFont);
                    }
                }

                // ====================================================
                // ПОДПИСЬ
                // ====================================================

                AddProtocolSignatureBlock(
                    document,
                    BuildEmployeeName(data),
                    normalFont);

                // ====================================================
                // ЗАКЛЮЧИТЕЛЬНАЯ СТРОКА
                // ====================================================

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
        // МЕСТО И ДАТА
        // ============================================================

        private void AddProtocolIntroLine(
            Document document,
            string place,
            DateTime? date,
            iTextSharp.text.Font font)
        {
            Paragraph paragraph =
                new Paragraph();

            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            paragraph.Add(
                new Chunk(
                    "Место составления: ",
                    bold));

            Chunk placeValue =
                new Chunk(
                    SafeValue(place),
                    font);

            placeValue.SetUnderline(
                0.6f,
                -1.5f);

            paragraph.Add(
                placeValue);

            paragraph.Add(
                new Chunk(
                    "     ",
                    font));

            paragraph.Add(
                new Chunk(
                    "Дата: ",
                    bold));

            Chunk dateValue =
                new Chunk(
                    FormatDate(date),
                    font);

            dateValue.SetUnderline(
                0.6f,
                -1.5f);

            paragraph.Add(
                dateValue);

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 12;

            document.Add(
                paragraph);
        }

        // ============================================================
        // ЛИЦО ПРОТОКОЛА
        // ============================================================

        private void AddProtocolPerson(
            Document document,
            ProtocolPrintCitizen citizen,
            int number,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph person =
                new Paragraph();

            person.Add(
                new Chunk(
                    number + ". ",
                    bold));

            Chunk name =
                new Chunk(
                    SafeValue(
                        citizen.FullName),
                    font);

            name.SetUnderline(
                0.6f,
                -1.5f);

            person.Add(name);

            person.Add(
                new Chunk(
                    "     Паспорт: ",
                    bold));

            Chunk passport =
                new Chunk(
                    BuildPassport(
                        citizen.PassportSeries,
                        citizen.PassportNumber),
                    font);

            passport.SetUnderline(
                0.6f,
                -1.5f);

            person.Add(
                passport);

            person.Leading = 14;
            person.SpacingAfter = 5;

            document.Add(
                person);

            Paragraph additional =
                new Paragraph(
                    "Телефон: " +
                    SafeValue(
                        citizen.Phone) +
                    "     Предупреждён: " +
                    (
                        citizen.WasWarned
                            ? "Да"
                            : "Нет"
                    ),
                    font);

            additional.IndentationLeft = 17;
            additional.SpacingAfter = 8;

            document.Add(
                additional);
        }

        // ============================================================
        // ПОДПИСЬ
        // ============================================================

        private void AddProtocolSignatureBlock(
            Document document,
            string employeeName,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph title =
                new Paragraph(
                    "Подпись должностного лица:",
                    bold);

            title.SpacingBefore = 22;
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
                    "М.П.",
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
        // БОЛЬШОЙ ТЕКСТОВЫЙ БЛОК
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

            titleParagraph.SpacingBefore = 8;
            titleParagraph.SpacingAfter = 7;

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
        // ЗАГОЛОВОК РАЗДЕЛА
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

        private void AddPersonHeader(
            Document document,
            string text,
            iTextSharp.text.Font font)
        {
            Paragraph paragraph =
                new Paragraph(
                    text,
                    font);

            paragraph.SpacingBefore = 18;
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
            string protocolNumber,
            byte[] pdfBytes)
        {
            string documents =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            string directory =
                Path.Combine(
                    documents,
                    "PoliceStationIS",
                    "Протоколы");

            Directory.CreateDirectory(
                directory);

            string safeNumber =
                MakeSafeFileName(
                    protocolNumber);

            string fileName =
                "Протокол_№_" +
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
UPDATE protocol
SET
    protocol_file = @file
WHERE
    protocol_id = @protocol_id;
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
                        "@protocol_id",
                        NpgsqlTypes.NpgsqlDbType.Integer)
                        .Value = protocolId;

                    int rows =
                        command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        throw new Exception(
                            "Не удалось сохранить сформированный " +
                            "файл протокола в базу данных.");
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
                        "Протокол № " +
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

        private class ProtocolPdfPageEvent :
            PdfPageEventHelper
        {
            private readonly string protocolNumber;

            private BaseFont baseFont;

            public ProtocolPdfPageEvent(
                string protocolNumber)
            {
                this.protocolNumber =
                    protocolNumber;
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
                        "Протокол № " +
                        SafeValueStatic(
                            protocolNumber),
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

        private string BuildEmployeeName(
            ProtocolPrintData data)
        {
            string result =
                (
                    data.EmployeeLastName +
                    " " +
                    data.EmployeeName +
                    " " +
                    data.EmployeeMiddleName
                ).Trim();

            return string.IsNullOrWhiteSpace(
                result)
                ? "—"
                : result;
        }

        private string BuildPassport(
            string series,
            string number)
        {
            string value =
                (
                    series +
                    " " +
                    number
                ).Trim();

            return string.IsNullOrWhiteSpace(
                value)
                ? "—"
                : value;
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
    // МОДЕЛИ
    // ================================================================

    internal class ProtocolPrintData
    {
        public int ProtocolId { get; set; }

        public string ProtocolNumber { get; set; }

        public string ProtocolType { get; set; }

        public string ProtocolStatus { get; set; }

        public DateTime? PreparationDate { get; set; }

        public string Place { get; set; }

        public string Description { get; set; }

        public string CaseNumbers { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeMiddleName { get; set; }

        public List<ProtocolPrintCitizen> Citizens { get; set; }
            = new List<ProtocolPrintCitizen>();
    }

    internal class ProtocolPrintCitizen
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }

        public string PassportNumber { get; set; }

        public string Phone { get; set; }

        public bool WasWarned { get; set; }

        public string FullName
        {
            get
            {
                return (
                    LastName +
                    " " +
                    FirstName +
                    " " +
                    MiddleName
                ).Trim();
            }
        }
    }
}