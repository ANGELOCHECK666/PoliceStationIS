using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Services
{
    public class CasePrintService
    {
        private readonly int caseId;

        public CasePrintService(int caseId)
        {
            this.caseId = caseId;
        }

        // ============================================================
        // ОСНОВНОЙ МЕТОД
        // ============================================================

        public void GenerateAndPrint(IWin32Window owner)
        {
            try
            {
                CasePrintData data = LoadCaseData();

                if (data == null)
                {
                    MessageBox.Show(
                        owner,
                        "Выбранное уголовное дело не найдено.",
                        "Печать дела",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                byte[] pdfBytes = GeneratePdf(data);

                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    throw new Exception(
                        "Не удалось сформировать PDF-файл.");
                }

                string filePath = SavePdfToComputer(
                    data.CaseNumber,
                    pdfBytes);

                SavePdfToDatabase(pdfBytes);

                MessageBox.Show(
                    owner,
                    "Уголовное дело успешно сформировано.\n\n" +
                    "Файл сохранён:\n" +
                    filePath,
                    "Документ сформирован",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                PrintPdf(owner, filePath);
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
                    "Не удалось сформировать или напечатать дело:\n\n" +
                    ex.Message,
                    "Ошибка печати",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // ЗАГРУЗКА ДАННЫХ ДЕЛА
        // ============================================================

        private CasePrintData LoadCaseData()
        {
            CasePrintData data = null;

            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
SELECT
    cc.criminal_case_id,
    cc.case_number,
    cc.description_case,
    cc.date_and_time_of_crime,
    cc.crime_scene,
    cc.case_closing_date,

    cc.case_creation_date,
    cc.last_update_date,

    art.article_of_the_ccrf_code,
    art.article_of_the_ccrf_name,

    cs.case_status_name,

    e.last_name AS employee_last_name,
    e.name_ AS employee_name,
    e.middle_name AS employee_middle_name,

    p.protocol_id,
    p.protocol_number,
    p.description_protocol,
    p.place_of_commission,
    p.date_of_preparation_protocol,

    pt.protocol_type_name,
    ps.protocol_status_name,

    ev.evidence_id,
    ev.evidence_number,
    ev.evidence_name,
    ev.description_evidence,
    ev.date_of_seizure,
    ev.storage_location,
    ev.evidence_image,

    (
        SELECT COUNT(*)
        FROM criminal_case_citizen ccc
        WHERE ccc.criminal_case_id = cc.criminal_case_id
    ) AS case_citizen_count

FROM criminal_case cc

LEFT JOIN article_of_the_ccrf art
    ON art.article_of_the_ccrf_id =
       cc.article_of_the_ccrf_id

LEFT JOIN case_status cs
    ON cs.case_status_id =
       cc.case_status_id

LEFT JOIN employee e
    ON e.employee_id =
       cc.employee_id

LEFT JOIN protocol p
    ON p.protocol_id =
       cc.protocol_id

LEFT JOIN protocol_type pt
    ON pt.protocol_type_id =
       p.protocol_type_id

LEFT JOIN protocol_status ps
    ON ps.protocol_status_id =
       p.protocol_status_id

LEFT JOIN evidence ev
    ON ev.evidence_id =
       p.evidence_id

WHERE cc.criminal_case_id = @case_id;
";

                using (NpgsqlCommand command =
                       new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@case_id",
                        caseId);

                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        data = new CasePrintData();

                        data.CaseId =
                            Convert.ToInt32(
                                reader["criminal_case_id"]);

                        data.CaseNumber =
                            SafeString(reader["case_number"]);

                        data.Description =
                            SafeString(reader["description_case"]);

                        data.CrimeScene =
                            SafeString(reader["crime_scene"]);

                        data.CrimeDateTime =
                            reader["date_and_time_of_crime"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["date_and_time_of_crime"]);

                        data.CaseClosingDate =
                            reader["case_closing_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["case_closing_date"]);

                        data.CaseCreationDate =
                            reader["case_creation_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["case_creation_date"]);

                        data.LastUpdateDate =
                            reader["last_update_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["last_update_date"]);

                        data.ArticleCode =
                            SafeString(
                                reader["article_of_the_ccrf_code"]);

                        data.ArticleName =
                            SafeString(
                                reader["article_of_the_ccrf_name"]);

                        data.Status =
                            SafeString(
                                reader["case_status_name"]);

                        data.EmployeeLastName =
                            SafeString(
                                reader["employee_last_name"]);

                        data.EmployeeName =
                            SafeString(
                                reader["employee_name"]);

                        data.EmployeeMiddleName =
                            SafeString(
                                reader["employee_middle_name"]);

                        data.ProtocolId =
                            reader["protocol_id"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(
                                    reader["protocol_id"]);

                        data.ProtocolNumber =
                            SafeString(
                                reader["protocol_number"]);

                        data.ProtocolDescription =
                            SafeString(
                                reader["description_protocol"]);

                        data.ProtocolPlace =
                            SafeString(
                                reader["place_of_commission"]);

                        data.ProtocolDate =
                            reader["date_of_preparation_protocol"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["date_of_preparation_protocol"]);

                        data.ProtocolType =
                            SafeString(
                                reader["protocol_type_name"]);

                        data.ProtocolStatus =
                            SafeString(
                                reader["protocol_status_name"]);

                        if (reader["evidence_id"] != DBNull.Value)
                        {
                            data.EvidenceId =
                                Convert.ToInt32(
                                    reader["evidence_id"]);

                            data.EvidenceNumber =
                                SafeString(
                                    reader["evidence_number"]);

                            data.EvidenceName =
                                SafeString(
                                    reader["evidence_name"]);

                            data.EvidenceDescription =
                                SafeString(
                                    reader["description_evidence"]);

                            data.EvidenceDate =
                                reader["date_of_seizure"] ==
                                DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(
                                        reader["date_of_seizure"]);

                            data.EvidenceStorage =
                                SafeString(
                                    reader["storage_location"]);

                            if (reader["evidence_image"] != DBNull.Value)
                            {
                                data.EvidenceImage =
                                    (byte[])reader["evidence_image"];
                            }
                        }
                    }
                }

                LoadCaseCitizens(
                    connection,
                    data);

                if (data.ProtocolId > 0)
                {
                    LoadProtocolCitizens(
                        connection,
                        data);
                }

                LoadCaseExpertises(
                    connection,
                    data);
            }

            return data;
        }

        // ============================================================
        // ГРАЖДАНЕ ДЕЛА
        // ============================================================

        private void LoadCaseCitizens(
            NpgsqlConnection connection,
            CasePrintData data)
        {
            string query = @"
SELECT
    c.citizen_id,
    c.last_name,
    c.name_,
    c.middle_name,
    c.passport_series,
    c.passport_number,
    c.phone_number,
    c.date_of_birth,
    c.registration_address,
    c.residential_address,
    c.distinguishing_features,
    ccc.date_and_time_of_initiation

FROM criminal_case_citizen ccc

INNER JOIN citizen c
    ON c.citizen_id = ccc.citizen_id

WHERE ccc.criminal_case_id = @case_id

ORDER BY
    c.last_name,
    c.name_,
    c.middle_name;
";

            using (NpgsqlCommand command =
                   new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@case_id",
                    caseId);

                using (NpgsqlDataReader reader =
                       command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CaseCitizen citizen =
                            new CaseCitizen();

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

                        citizen.DateOfBirth =
                            reader["date_of_birth"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["date_of_birth"]);

                        citizen.RegistrationAddress =
                            SafeString(
                                reader["registration_address"]);

                        citizen.ResidentialAddress =
                            SafeString(
                                reader["residential_address"]);

                        citizen.DistinguishingFeatures =
                            SafeString(
                                reader["distinguishing_features"]);

                        citizen.InitiationDate =
                            reader["date_and_time_of_initiation"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["date_and_time_of_initiation"]);

                        data.CaseCitizens.Add(citizen);
                    }
                }
            }
        }

        // ============================================================
        // ГРАЖДАНЕ ПРОТОКОЛА
        // ============================================================

        private void LoadProtocolCitizens(
            NpgsqlConnection connection,
            CasePrintData data)
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
    ON c.citizen_id = pc.citizen_id

WHERE pc.protocol_id = @protocol_id

ORDER BY
    c.last_name,
    c.name_,
    c.middle_name;
";

            using (NpgsqlCommand command =
                   new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@protocol_id",
                    data.ProtocolId);

                using (NpgsqlDataReader reader =
                       command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocolCitizen citizen =
                            new ProtocolCitizen();

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
                            reader["was_warned"] != DBNull.Value &&
                            Convert.ToBoolean(
                                reader["was_warned"]);

                        data.ProtocolCitizens.Add(citizen);
                    }
                }
            }
        }

        // ============================================================
        // ЭКСПЕРТИЗЫ ДЕЛА
        // ============================================================

        private void LoadCaseExpertises(
            NpgsqlConnection connection,
            CasePrintData data)
        {
            if (data.ProtocolId <= 0)
            {
                return;
            }

            string query = @"
SELECT
    i.inspection_id,
    TRIM(i.inspection_number) AS inspection_number,
    it.inspection_type_name,
    ist.inspection_status_name,
    TRIM(p.protocol_number) AS protocol_number,

    e.last_name AS employee_last_name,
    e.name_ AS employee_name,
    e.middle_name AS employee_middle_name,

    i.appointment_date,
    i.research_start_date,
    i.research_end_date,

    COALESCE(
        i.conclusion,
        ''
    ) AS conclusion,

    CASE
        WHEN i.inspection_file IS NULL
        THEN FALSE
        ELSE TRUE
    END AS has_file

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

WHERE i.protocol_id = @protocol_id

ORDER BY
    i.appointment_date,
    i.inspection_id;
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
                        CaseExpertise expertise =
                            new CaseExpertise();

                        expertise.ExpertiseId =
                            Convert.ToInt32(
                                reader["inspection_id"]);

                        expertise.ExpertiseNumber =
                            SafeString(
                                reader["inspection_number"]);

                        expertise.ExpertiseType =
                            SafeString(
                                reader["inspection_type_name"]);

                        expertise.ExpertiseStatus =
                            SafeString(
                                reader["inspection_status_name"]);

                        expertise.ProtocolNumber =
                            SafeString(
                                reader["protocol_number"]);

                        expertise.EmployeeLastName =
                            SafeString(
                                reader["employee_last_name"]);

                        expertise.EmployeeName =
                            SafeString(
                                reader["employee_name"]);

                        expertise.EmployeeMiddleName =
                            SafeString(
                                reader["employee_middle_name"]);

                        expertise.AppointmentDate =
                            reader["appointment_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["appointment_date"]);

                        expertise.ResearchStartDate =
                            reader["research_start_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["research_start_date"]);

                        expertise.ResearchEndDate =
                            reader["research_end_date"] ==
                            DBNull.Value
                                ? (DateTime?)null
                                : Convert.ToDateTime(
                                    reader["research_end_date"]);

                        expertise.Conclusion =
                            SafeString(
                                reader["conclusion"]);

                        expertise.HasFile =
                            reader["has_file"] != DBNull.Value &&
                            Convert.ToBoolean(
                                reader["has_file"]);

                        data.Expertises.Add(
                            expertise);
                    }
                }
            }
        }

        // ============================================================
        // ФОРМИРОВАНИЕ PDF
        // ============================================================

        private byte[] GeneratePdf(CasePrintData data)
        {
            using (MemoryStream stream =
                   new MemoryStream())
            {
                Document document =
                    new Document(
                        PageSize.A4,
                        60,
                        60,
                        65,
                        60);

                PdfWriter writer =
                    PdfWriter.GetInstance(
                        document,
                        stream);

                writer.PageEvent =
                    new CasePdfPageEvent(
                        data.CaseNumber);

                document.AddTitle(
                    "Уголовное дело № " +
                    data.CaseNumber);

                document.AddAuthor(
                    "PoliceStationIS");

                document.AddSubject(
                    "Материалы уголовного дела");

                document.Open();

                BaseFont baseFont =
                    CreateRussianBaseFont();

                iTextSharp.text.Font smallFont =
                    CreateFont(
                        baseFont,
                        8.5f,
                        iTextSharp.text.Font.NORMAL);

                iTextSharp.text.Font normalFont =
                    CreateFont(
                        baseFont,
                        10,
                        iTextSharp.text.Font.NORMAL);

                iTextSharp.text.Font boldFont =
                    CreateFont(
                        baseFont,
                        10,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font sectionFont =
                    CreateFont(
                        baseFont,
                        13,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font titleFont =
                    CreateFont(
                        baseFont,
                        19,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font caseNumberFont =
                    CreateFont(
                        baseFont,
                        13,
                        iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font protocolTitleFont =
                    CreateFont(
                        baseFont,
                        15,
                        iTextSharp.text.Font.BOLD);

                // ----------------------------------------------------
                // 1. ТИТУЛЬНЫЙ ЛИСТ
                // ----------------------------------------------------

                AddCoverPage(
                    document,
                    data,
                    smallFont,
                    titleFont,
                    caseNumberFont,
                    boldFont);

                // ----------------------------------------------------
                // 2. ОБЩИЕ СВЕДЕНИЯ
                // ----------------------------------------------------

                document.NewPage();

                AddSectionHeader(
                    document,
                    "1. ОБЩИЕ СВЕДЕНИЯ О ДЕЛЕ",
                    sectionFont);

                AddDocumentField(
                    document,
                    "Номер дела",
                    data.CaseNumber,
                    normalFont);

                AddDocumentField(
                    document,
                    "Статья УК РФ",
                    BuildArticleText(data),
                    normalFont);

                AddDocumentField(
                    document,
                    "Статус дела",
                    data.Status,
                    normalFont);

                AddDocumentField(
                    document,
                    "Следователь",
                    BuildEmployeeName(data),
                    normalFont);

                AddDocumentField(
                    document,
                    "Дата создания",
                    FormatDate(data.CaseCreationDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Последнее изменение",
                    FormatDate(data.LastUpdateDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Дата закрытия",
                    FormatDate(data.CaseClosingDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Дата и время преступления",
                    FormatDateTime(data.CrimeDateTime),
                    normalFont);

                AddDocumentField(
                    document,
                    "Место преступления",
                    data.CrimeScene,
                    normalFont);

                AddDescriptionBlock(
                    document,
                    "Описание дела",
                    data.Description,
                    normalFont);

                // ----------------------------------------------------
                // 3. УЧАСТНИКИ
                // ----------------------------------------------------

                if (data.CaseCitizens.Count == 0)
                {
                    document.NewPage();

                    AddSectionHeader(
                        document,
                        "2. УЧАСТНИКИ ДЕЛА",
                        sectionFont);

                    AddPlainText(
                        document,
                        "Сведения об участниках дела отсутствуют.",
                        normalFont);
                }
                else
                {
                    for (int i = 0;
                         i < data.CaseCitizens.Count;
                         i++)
                    {
                        document.NewPage();

                        AddSectionHeader(
                            document,
                            "2. УЧАСТНИКИ ДЕЛА",
                            sectionFont);

                        AddPersonHeader(
                            document,
                            "УЧАСТНИК № " +
                            (i + 1),
                            boldFont);

                        AddPersonFields(
                            document,
                            data.CaseCitizens[i],
                            normalFont);

                        AddBottomSignatureLine(
                            document,
                            "Участник",
                            data.CaseCitizens[i].FullName,
                            normalFont);
                    }
                }

                // ----------------------------------------------------
                // 4. ПРОТОКОЛ
                // ----------------------------------------------------

                document.NewPage();

                AddProtocolPage(
                    document,
                    data,
                    protocolTitleFont,
                    sectionFont,
                    normalFont,
                    smallFont,
                    boldFont);

                // ----------------------------------------------------
                // 5. ЭКСПЕРТИЗЫ
                // ----------------------------------------------------

                AddExpertisesSection(
                    document,
                    data,
                    sectionFont,
                    normalFont,
                    boldFont);

                // ----------------------------------------------------
                // 6. ДОКАЗАТЕЛЬСТВО
                // ----------------------------------------------------

                document.NewPage();

                AddEvidencePage(
                    document,
                    data,
                    sectionFont,
                    normalFont,
                    boldFont);

                // ----------------------------------------------------
                // 7. ЗАКЛЮЧИТЕЛЬНАЯ ЧАСТЬ
                // ----------------------------------------------------

                document.NewPage();

                AddSectionHeader(
                    document,
                    "7. ЗАКЛЮЧИТЕЛЬНАЯ ЧАСТЬ",
                    sectionFont);

                AddPlainText(
                    document,
                    "Настоящий документ сформирован " +
                    "информационной системой полицейского участка " +
                    "на основании сведений, содержащихся в базе данных.",
                    normalFont,
                    true);

                AddDocumentField(
                    document,
                    "Дата формирования",
                    DateTime.Now.ToString(
                        "dd.MM.yyyy HH:mm"),
                    normalFont);

                document.Add(
                    new Paragraph(
                        " ",
                        normalFont));

                AddSignatureBlock(
                    document,
                    BuildEmployeeName(data),
                    normalFont,
                    boldFont);

                document.Close();
                writer.Close();

                return stream.ToArray();
            }
        }

        // ============================================================
        // ТИТУЛЬНЫЙ ЛИСТ
        // ============================================================

        private void AddCoverPage(
            Document document,
            CasePrintData data,
            iTextSharp.text.Font smallFont,
            iTextSharp.text.Font titleFont,
            iTextSharp.text.Font caseNumberFont,
            iTextSharp.text.Font boldFont)
        {
            Paragraph ministry =
                new Paragraph(
                    "МВД РОССИИ",
                    boldFont);

            ministry.Alignment =
                Element.ALIGN_CENTER;

            ministry.SpacingBefore = 70;
            ministry.SpacingAfter = 5;

            document.Add(ministry);

            Paragraph system =
                new Paragraph(
                    "Информационная система\n" +
                    "полицейского участка",
                    smallFont);

            system.Alignment =
                Element.ALIGN_CENTER;

            system.SpacingAfter = 80;

            document.Add(system);

            Paragraph title =
                new Paragraph(
                    "УГОЛОВНОЕ ДЕЛО",
                    titleFont);

            title.Alignment =
                Element.ALIGN_CENTER;

            title.SpacingAfter = 14;

            document.Add(title);

            Paragraph caseNumber =
                new Paragraph(
                    "№ " +
                    SafeValue(data.CaseNumber),
                    caseNumberFont);

            caseNumber.Alignment =
                Element.ALIGN_CENTER;

            caseNumber.SpacingAfter = 28;

            document.Add(caseNumber);

            AddCoverLine(document);

            Paragraph volume =
                new Paragraph(
                    "ТОМ № 1",
                    boldFont);

            volume.Alignment =
                Element.ALIGN_CENTER;

            volume.SpacingBefore = 25;

            document.Add(volume);

            Paragraph created =
                new Paragraph(
                    "Сформировано: " +
                    DateTime.Now.ToString(
                        "dd.MM.yyyy"),
                    smallFont);

            created.Alignment =
                Element.ALIGN_CENTER;

            created.SpacingBefore = 180;

            document.Add(created);
        }

        // ============================================================
        // ОБЫЧНОЕ ПОЛЕ ДОКУМЕНТА
        // ============================================================

        private void AddDocumentField(
            Document document,
            string label,
            string value,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font labelFont =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph paragraph =
                new Paragraph();

            Chunk labelChunk =
                new Chunk(
                    label + ": ",
                    labelFont);

            Chunk valueChunk =
                new Chunk(
                    SafeValue(value),
                    font);

            valueChunk.SetUnderline(
                0.6f,
                -1.5f);

            paragraph.Add(labelChunk);
            paragraph.Add(valueChunk);

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 8;

            document.Add(paragraph);
        }

        private void AddDescriptionBlock(
            Document document,
            string title,
            string value,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font titleFont =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph heading =
                new Paragraph(
                    title + ":",
                    titleFont);

            heading.SpacingBefore = 10;
            heading.SpacingAfter = 6;

            document.Add(heading);

            Paragraph paragraph =
                new Paragraph(
                    SafeValue(value),
                    font);

            paragraph.Alignment =
                Element.ALIGN_JUSTIFIED;

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 12;

            document.Add(paragraph);
        }

        // ============================================================
        // УЧАСТНИК
        // ============================================================

        private void AddPersonHeader(
            Document document,
            string text,
            iTextSharp.text.Font font)
        {
            Paragraph paragraph =
                new Paragraph(
                    text,
                    font);

            paragraph.SpacingBefore = 5;
            paragraph.SpacingAfter = 8;

            document.Add(paragraph);

            AddSmallRule(document);
        }

        private void AddPersonFields(
            Document document,
            CaseCitizen citizen,
            iTextSharp.text.Font font)
        {
            AddDocumentField(
                document,
                "ФИО",
                citizen.FullName,
                font);

            AddDocumentField(
                document,
                "Дата рождения",
                FormatDate(citizen.DateOfBirth),
                font);

            AddDocumentField(
                document,
                "Паспорт",
                BuildPassport(
                    citizen.PassportSeries,
                    citizen.PassportNumber),
                font);

            AddDocumentField(
                document,
                "Телефон",
                citizen.Phone,
                font);

            AddDocumentField(
                document,
                "Адрес регистрации",
                citizen.RegistrationAddress,
                font);

            AddDocumentField(
                document,
                "Адрес проживания",
                citizen.ResidentialAddress,
                font);

            AddDocumentField(
                document,
                "Особые приметы",
                citizen.DistinguishingFeatures,
                font);

            AddDocumentField(
                document,
                "Дата привлечения к делу",
                FormatDateTime(citizen.InitiationDate),
                font);
        }

        // ============================================================
        // ПРОТОКОЛ
        //
        // Этот стиль является основой для будущего ProtocolForm:
        // отдельный заголовок, номер, место/дата, текст протокола,
        // участники и подписи.
        // ============================================================

        private void AddProtocolPage(
            Document document,
            CasePrintData data,
            iTextSharp.text.Font titleFont,
            iTextSharp.text.Font sectionFont,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font smallFont,
            iTextSharp.text.Font boldFont)
        {
            if (data.ProtocolId <= 0)
            {
                AddSectionHeader(
                    document,
                    "3. ПРОТОКОЛ",
                    sectionFont);

                AddPlainText(
                    document,
                    "Протокол по делу не указан.",
                    normalFont);

                return;
            }

            Paragraph section =
                new Paragraph(
                    "3. ПРОТОКОЛ",
                    sectionFont);

            section.SpacingAfter = 18;

            document.Add(section);

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

            document.Add(protocolTitle);

            Paragraph number =
                new Paragraph(
                    "№ " +
                    SafeValue(data.ProtocolNumber),
                    boldFont);

            number.Alignment =
                Element.ALIGN_CENTER;

            number.SpacingAfter = 20;

            document.Add(number);

            AddProtocolIntroLine(
                document,
                data.ProtocolPlace,
                data.ProtocolDate,
                normalFont);

            AddSmallRule(document);

            AddDocumentField(
                document,
                "Статус протокола",
                data.ProtocolStatus,
                normalFont);

            AddDescriptionBlock(
                document,
                "Содержание протокола",
                data.ProtocolDescription,
                normalFont);

            if (data.ProtocolCitizens.Count > 0)
            {
                AddPersonHeader(
                    document,
                    "ЛИЦА, УКАЗАННЫЕ В ПРОТОКОЛЕ",
                    boldFont);

                for (int i = 0;
                     i < data.ProtocolCitizens.Count;
                     i++)
                {
                    AddProtocolPerson(
                        document,
                        data.ProtocolCitizens[i],
                        i + 1,
                        smallFont);
                }
            }

            AddProtocolSignatureBlock(
                document,
                BuildEmployeeName(data),
                normalFont);
        }

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

            paragraph.Add(placeValue);

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

            paragraph.Add(dateValue);

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 12;

            document.Add(paragraph);
        }

        private void AddProtocolPerson(
            Document document,
            ProtocolCitizen citizen,
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
                    SafeValue(citizen.FullName),
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

            person.Add(passport);

            person.Leading = 14;
            person.SpacingAfter = 5;

            document.Add(person);

            Paragraph additional =
                new Paragraph(
                    "Телефон: " +
                    SafeValue(citizen.Phone) +
                    "     Предупреждён: " +
                    (citizen.WasWarned ? "Да" : "Нет"),
                    font);

            additional.IndentationLeft = 17;
            additional.SpacingAfter = 8;

            document.Add(additional);
        }

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

            title.SpacingBefore = 18;
            title.SpacingAfter = 8;

            document.Add(title);

            Paragraph signature =
                new Paragraph(
                    "______________________________    " +
                    SafeValue(employeeName),
                    font);

            signature.SpacingAfter = 8;

            document.Add(signature);

            document.Add(
                new Paragraph(
                    "М.П.",
                    font));
        }

        // ============================================================
        // ЭКСПЕРТИЗЫ
        // ============================================================

        private void AddExpertisesSection(
            Document document,
            CasePrintData data,
            iTextSharp.text.Font sectionFont,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font boldFont)
        {
            document.NewPage();

            AddSectionHeader(
                document,
                "5. ЭКСПЕРТИЗЫ",
                sectionFont);

            if (data.Expertises.Count == 0)
            {
                AddPlainText(
                    document,
                    "Экспертизы по данному уголовному делу отсутствуют.",
                    normalFont);

                return;
            }

            for (int i = 0;
                 i < data.Expertises.Count;
                 i++)
            {
                if (i > 0)
                {
                    document.NewPage();

                    AddSectionHeader(
                        document,
                        "5. ЭКСПЕРТИЗЫ",
                        sectionFont);
                }

                CaseExpertise expertise =
                    data.Expertises[i];

                AddPersonHeader(
                    document,
                    "ЭКСПЕРТИЗА № " +
                    (i + 1),
                    boldFont);

                Paragraph title =
                    new Paragraph(
                        "ЗАКЛЮЧЕНИЕ ЭКСПЕРТА",
                        new iTextSharp.text.Font(
                            normalFont.BaseFont,
                            15,
                            iTextSharp.text.Font.BOLD));

                title.Alignment =
                    Element.ALIGN_CENTER;

                title.SpacingAfter = 8;

                document.Add(title);

                Paragraph number =
                    new Paragraph(
                        "№ " +
                        SafeValue(
                            expertise.ExpertiseNumber),
                        boldFont);

                number.Alignment =
                    Element.ALIGN_CENTER;

                number.SpacingAfter = 18;

                document.Add(number);

                AddDocumentField(
                    document,
                    "Вид экспертизы",
                    expertise.ExpertiseType,
                    normalFont);

                AddDocumentField(
                    document,
                    "Статус",
                    expertise.ExpertiseStatus,
                    normalFont);

                AddDocumentField(
                    document,
                    "Связанный протокол",
                    expertise.ProtocolNumber,
                    normalFont);

                AddDocumentField(
                    document,
                    "Эксперт / сотрудник",
                    expertise.EmployeeFullName,
                    normalFont);

                AddDocumentField(
                    document,
                    "Дата назначения",
                    FormatDate(
                        expertise.AppointmentDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Начало исследования",
                    FormatDate(
                        expertise.ResearchStartDate),
                    normalFont);

                AddDocumentField(
                    document,
                    "Окончание исследования",
                    FormatDate(
                        expertise.ResearchEndDate),
                    normalFont);

                AddDescriptionBlock(
                    document,
                    "Заключение эксперта",
                    expertise.Conclusion,
                    normalFont);

                AddDocumentField(
                    document,
                    "Файл заключения",
                    expertise.HasFile
                        ? "Приложен в базе данных"
                        : "Отсутствует",
                    normalFont);

                AddExpertiseSignature(
                    document,
                    expertise.EmployeeFullName,
                    normalFont,
                    boldFont);
            }
        }

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

            title.SpacingBefore = 20;
            title.SpacingAfter = 10;

            document.Add(title);

            Paragraph signature =
                new Paragraph(
                    "______________________________    " +
                    SafeValue(employeeName),
                    font);

            signature.SpacingAfter = 8;

            document.Add(signature);

            document.Add(
                new Paragraph(
                    "Дата: ____________________",
                    font));
        }

        // ============================================================
        // ДОКАЗАТЕЛЬСТВО
        //
        // Информация находится на одной странице.
        // Если есть фотография, перед ней принудительно начинается
        // новая страница. Поэтому заголовок фотографии и сама
        // фотография гарантированно находятся рядом.
        // ============================================================

        private void AddEvidencePage(
            Document document,
            CasePrintData data,
            iTextSharp.text.Font sectionFont,
            iTextSharp.text.Font normalFont,
            iTextSharp.text.Font boldFont)
        {
            AddSectionHeader(
                document,
                "4. ДОКАЗАТЕЛЬСТВО",
                sectionFont);

            if (data.EvidenceId <= 0)
            {
                AddPlainText(
                    document,
                    "Доказательство, связанное с протоколом, отсутствует.",
                    normalFont);

                return;
            }

            AddDocumentField(
                document,
                "Номер доказательства",
                data.EvidenceNumber,
                normalFont);

            AddDocumentField(
                document,
                "Наименование",
                data.EvidenceName,
                normalFont);

            AddDocumentField(
                document,
                "Дата изъятия",
                FormatDate(data.EvidenceDate),
                normalFont);

            AddDocumentField(
                document,
                "Место хранения",
                data.EvidenceStorage,
                normalFont);

            AddDescriptionBlock(
                document,
                "Описание доказательства",
                data.EvidenceDescription,
                normalFont);

            if (data.EvidenceImage != null &&
                data.EvidenceImage.Length > 0)
            {
                // Фото начинается с отдельной страницы.
                // Это специально сделано, чтобы оно никогда
                // не «уезжало» от собственного заголовка.
                document.NewPage();

                Paragraph photoTitle =
                    new Paragraph(
                        "ФОТОГРАФИЯ ДОКАЗАТЕЛЬСТВА",
                        boldFont);

                photoTitle.SpacingBefore = 4;
                photoTitle.SpacingAfter = 15;

                document.Add(photoTitle);

                AddEvidenceImage(
                    document,
                    data.EvidenceImage);
            }
        }

        private void AddEvidenceImage(
            Document document,
            byte[] imageBytes)
        {
            try
            {
                using (MemoryStream stream =
                       new MemoryStream(imageBytes))
                {
                    using (System.Drawing.Image image =
                           System.Drawing.Image.FromStream(stream))
                    {
                        using (MemoryStream imageStream =
                               new MemoryStream())
                        {
                            image.Save(
                                imageStream,
                                ImageFormat.Png);

                            imageStream.Position = 0;

                            iTextSharp.text.Image pdfImage =
                                iTextSharp.text.Image.GetInstance(
                                    imageStream);

                            pdfImage.Alignment =
                                Element.ALIGN_CENTER;

                            // Увеличиваем фото по сравнению
                            // со старым вариантом, но сохраняем
                            // поля страницы.
                            pdfImage.ScaleToFit(
                                460,
                                560);

                            document.Add(pdfImage);

                            Paragraph caption =
                                new Paragraph(
                                    "Фото № 1",
                                    new iTextSharp.text.Font(
                                        CreateRussianBaseFont(),
                                        8.5f,
                                        iTextSharp.text.Font.ITALIC));

                            caption.Alignment =
                                Element.ALIGN_CENTER;

                            caption.SpacingBefore = 7;

                            document.Add(caption);
                        }
                    }
                }
            }
            catch
            {
                document.Add(
                    new Paragraph(
                        "Фотография доказательства " +
                        "не может быть отображена.",
                        new iTextSharp.text.Font(
                            CreateRussianBaseFont(),
                            9)));
            }
        }

        // ============================================================
        // ЗАКЛЮЧИТЕЛЬНАЯ ЧАСТЬ
        // ============================================================

        private void AddSignatureBlock(
            Document document,
            string employeeName,
            iTextSharp.text.Font font,
            iTextSharp.text.Font boldFont)
        {
            Paragraph title =
                new Paragraph(
                    "Ответственное должностное лицо",
                    boldFont);

            title.SpacingBefore = 20;
            title.SpacingAfter = 14;

            document.Add(title);

            AddDocumentField(
                document,
                "Следователь",
                employeeName,
                font);

            Paragraph signature =
                new Paragraph(
                    "Подпись: ______________________________",
                    font);

            signature.SpacingAfter = 15;

            document.Add(signature);

            document.Add(
                new Paragraph(
                    "М.П.",
                    font));
        }

        private void AddBottomSignatureLine(
            Document document,
            string role,
            string name,
            iTextSharp.text.Font font)
        {
            iTextSharp.text.Font bold =
                new iTextSharp.text.Font(
                    font.BaseFont,
                    font.Size,
                    iTextSharp.text.Font.BOLD);

            Paragraph block =
                new Paragraph();

            block.SpacingBefore = 28;
            block.SpacingAfter = 10;

            block.Add(
                new Chunk(
                    role + ": ",
                    bold));

            Chunk value =
                new Chunk(
                    SafeValue(name),
                    font);

            value.SetUnderline(
                0.6f,
                -1.5f);

            block.Add(value);

            document.Add(block);

            document.Add(
                new Paragraph(
                    "Подпись: ______________________________",
                    font));
        }

        // ============================================================
        // ЗАГОЛОВКИ / ЛИНИИ
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

            document.Add(paragraph);

            AddSmallRule(document);
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

            lineTable.AddCell(cell);

            document.Add(lineTable);
        }

        private void AddCoverLine(
            Document document)
        {
            PdfPTable lineTable =
                new PdfPTable(1);

            lineTable.WidthPercentage = 75;

            PdfPCell cell =
                new PdfPCell();

            cell.BorderWidth = 0;
            cell.BorderWidthBottom = 1.2f;
            cell.FixedHeight = 2;
            cell.Padding = 0;

            lineTable.AddCell(cell);

            document.Add(lineTable);
        }

        private void AddPlainText(
            Document document,
            string text,
            iTextSharp.text.Font font,
            bool justified = false)
        {
            Paragraph paragraph =
                new Paragraph(
                    SafeValue(text),
                    font);

            paragraph.Leading = 15;
            paragraph.SpacingAfter = 12;

            if (justified)
            {
                paragraph.Alignment =
                    Element.ALIGN_JUSTIFIED;
            }

            document.Add(paragraph);
        }

        // ============================================================
        // СОХРАНЕНИЕ PDF НА КОМПЬЮТЕР
        // ============================================================

        private string SavePdfToComputer(
            string caseNumber,
            byte[] pdfBytes)
        {
            string documents =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            string directory =
                Path.Combine(
                    documents,
                    "PoliceStationIS",
                    "Уголовные дела");

            Directory.CreateDirectory(directory);

            string safeCaseNumber =
                MakeSafeFileName(caseNumber);

            string fileName =
                "Уголовное_дело_№_" +
                safeCaseNumber +
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
        // СОХРАНЕНИЕ PDF В БД
        // ============================================================

        private void SavePdfToDatabase(
            byte[] pdfBytes)
        {
            using (NpgsqlConnection connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
UPDATE criminal_case
SET
    criminal_case_file = @file,
    last_update_date = CURRENT_DATE
WHERE criminal_case_id = @case_id;
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
                        "@case_id",
                        NpgsqlTypes.NpgsqlDbType.Integer)
                        .Value = caseId;

                    int rows =
                        command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        throw new Exception(
                            "Не удалось сохранить сформированный " +
                            "файл в базу данных.");
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
                   PdfiumViewer.PdfDocument.Load(filePath))
            {
                using (PrintDocument printDocument =
                       pdf.CreatePrintDocument(
                           PdfiumViewer.PdfPrintMode.ShrinkToMargin))
                {
                    printDocument.DocumentName =
                        "Уголовное дело № " +
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

        private class CasePdfPageEvent :
            PdfPageEventHelper
        {
            private readonly string caseNumber;
            private BaseFont baseFont;

            public CasePdfPageEvent(
                string caseNumber)
            {
                this.caseNumber = caseNumber;
            }

            public override void OnOpenDocument(
                PdfWriter writer,
                Document document)
            {
                baseFont =
                    BaseFont.CreateFont(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.Fonts),
                            "arial.ttf"),
                        BaseFont.IDENTITY_H,
                        BaseFont.EMBEDDED);
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
                        "Уголовное дело № " +
                        SafeValue(caseNumber),
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
        }

        // ============================================================
        // PDF — ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
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

        private string BuildArticleText(
            CasePrintData data)
        {
            if (string.IsNullOrWhiteSpace(
                    data.ArticleCode) &&
                string.IsNullOrWhiteSpace(
                    data.ArticleName))
            {
                return "—";
            }

            if (string.IsNullOrWhiteSpace(
                    data.ArticleName))
            {
                return data.ArticleCode;
            }

            if (string.IsNullOrWhiteSpace(
                    data.ArticleCode))
            {
                return data.ArticleName;
            }

            return data.ArticleCode +
                   " — " +
                   data.ArticleName;
        }

        private string BuildEmployeeName(
            CasePrintData data)
        {
            string result =
                (
                    data.EmployeeLastName + " " +
                    data.EmployeeName + " " +
                    data.EmployeeMiddleName
                ).Trim();

            return string.IsNullOrWhiteSpace(result)
                ? "—"
                : result;
        }

        private string BuildPassport(
            string series,
            string number)
        {
            string value =
                (
                    series + " " +
                    number
                ).Trim();

            return string.IsNullOrWhiteSpace(value)
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

        private string FormatDateTime(
            DateTime? value)
        {
            return value.HasValue
                ? value.Value.ToString(
                    "dd.MM.yyyy HH:mm")
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
            return string.IsNullOrWhiteSpace(value)
                ? "—"
                : value;
        }

        private string MakeSafeFileName(
            string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
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
    // МОДЕЛЬ ДАННЫХ ДЛЯ ПЕЧАТИ
    // ================================================================

    internal class CasePrintData
    {
        public int CaseId { get; set; }

        public string CaseNumber { get; set; }
        public string Description { get; set; }
        public string CrimeScene { get; set; }

        public DateTime? CrimeDateTime { get; set; }
        public DateTime? CaseClosingDate { get; set; }
        public DateTime? CaseCreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Status { get; set; }

        public string EmployeeLastName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMiddleName { get; set; }

        public int ProtocolId { get; set; }
        public string ProtocolNumber { get; set; }
        public string ProtocolDescription { get; set; }
        public string ProtocolPlace { get; set; }
        public DateTime? ProtocolDate { get; set; }
        public string ProtocolType { get; set; }
        public string ProtocolStatus { get; set; }

        public int EvidenceId { get; set; }
        public string EvidenceNumber { get; set; }
        public string EvidenceName { get; set; }
        public string EvidenceDescription { get; set; }
        public DateTime? EvidenceDate { get; set; }
        public string EvidenceStorage { get; set; }
        public byte[] EvidenceImage { get; set; }

        public List<CaseCitizen> CaseCitizens { get; set; }
            = new List<CaseCitizen>();

        public List<ProtocolCitizen> ProtocolCitizens { get; set; }
            = new List<ProtocolCitizen>();

        public List<CaseExpertise> Expertises { get; set; }
            = new List<CaseExpertise>();
    }

    internal class CaseExpertise
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

        public bool HasFile { get; set; }

        public string EmployeeFullName
        {
            get
            {
                string result =
                    (
                        EmployeeLastName + " " +
                        EmployeeName + " " +
                        EmployeeMiddleName
                    ).Trim();

                return string.IsNullOrWhiteSpace(result)
                    ? "—"
                    : result;
            }
        }
    }

    internal class CaseCitizen
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }

        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string RegistrationAddress { get; set; }
        public string ResidentialAddress { get; set; }

        public string DistinguishingFeatures { get; set; }

        public DateTime? InitiationDate { get; set; }

        public string FullName
        {
            get
            {
                return (
                    LastName + " " +
                    FirstName + " " +
                    MiddleName
                ).Trim();
            }
        }
    }

    internal class ProtocolCitizen
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
                    LastName + " " +
                    FirstName + " " +
                    MiddleName
                ).Trim();
            }
        }
    }
}