using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

using PoliceStationIS.Database;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Evidence
{
    public partial class EvidencePage : UserControl
    {
        private const int PageSize = 6;

        private int currentPage = 1;
        private int totalRecords;
        private int selectedEvidenceId = -1;

        public EvidencePage()
        {
            InitializeComponent();

            // Информация справа создаётся программно, потому что
            // соответствующие Label не создаются в Designer.

            CreateInfoLabels();

            ClearEvidenceInformation();

            LoadStatuses();
            LoadEvidenceNames();
            LoadCases();
            LoadEvidence();

            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;

            btnFirstPage.Click += BtnFirstPage_Click;
            btnPreviousPage.Click += BtnPreviousPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;

            btnAddEvidence.Click += BtnAddEvidence_Click;
            btnEditEvidence.Click += BtnEditEvidence_Click;

            btnViewPhoto.Click += BtnViewPhoto_Click;
            btnDeleteEvidence.Click += BtnDeleteEvidence_Click;
        }

        //============================================================
        // INFORMATION LABELS
        //============================================================

        private void CreateInfoLabels()
        {
            lblEvidenceNumberInfo = CreateInfoTitle(
                "№ доказательства:",
                240);

            lblEvidenceNumberValue = CreateInfoValue(240);

            lblEvidenceNameInfo = CreateInfoTitle(
                "Название:",
                270);

            lblEvidenceNameValue = CreateInfoValue(270);

            lblCaseInfo = CreateInfoTitle(
                "Дело:",
                300);

            lblCaseValue = CreateInfoValue(300);

            lblStatusInfo = CreateInfoTitle(
                "Статус:",
                330);

            lblStatusValue = CreateInfoValue(330);

            lblDateInfo = CreateInfoTitle(
                "Дата изъятия:",
                360);

            lblDateValue = CreateInfoValue(360);

            lblStorageInfo = CreateInfoTitle(
                "Место хранения:",
                390);

            lblStorageValue = CreateInfoValue(390);

            lblDescriptionInfo = CreateInfoTitle(
                "Описание:",
                425);

            lblDescriptionValue = CreateInfoValue(425);

            lblEvidenceNameValue.MaximumSize =
                new Size(215, 0);

            lblCaseValue.MaximumSize =
                new Size(215, 0);

            lblStorageValue.MaximumSize =
                new Size(215, 0);

            lblDescriptionValue.MaximumSize =
                new Size(215, 70);

            pnlEvidenceInfo.Controls.Add(lblEvidenceNumberInfo);
            pnlEvidenceInfo.Controls.Add(lblEvidenceNumberValue);

            pnlEvidenceInfo.Controls.Add(lblEvidenceNameInfo);
            pnlEvidenceInfo.Controls.Add(lblEvidenceNameValue);

            pnlEvidenceInfo.Controls.Add(lblCaseInfo);
            pnlEvidenceInfo.Controls.Add(lblCaseValue);

            pnlEvidenceInfo.Controls.Add(lblStatusInfo);
            pnlEvidenceInfo.Controls.Add(lblStatusValue);

            pnlEvidenceInfo.Controls.Add(lblDateInfo);
            pnlEvidenceInfo.Controls.Add(lblDateValue);

            pnlEvidenceInfo.Controls.Add(lblStorageInfo);
            pnlEvidenceInfo.Controls.Add(lblStorageValue);

            pnlEvidenceInfo.Controls.Add(lblDescriptionInfo);
            pnlEvidenceInfo.Controls.Add(lblDescriptionValue);
        }

        private void ConfigureInfoButton(IconButton button)
        {
            button.FlatStyle = FlatStyle.Flat;

            button.FlatAppearance.BorderSize = 1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 160, 23);

            button.BackColor =
                Color.FromArgb(30, 58, 117);

            button.ForeColor = Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            button.Cursor = Cursors.Hand;
        }

        private Label CreateInfoTitle(string text, int top)
        {
            Label label = new Label();

            label.AutoSize = true;
            label.Text = text;
            label.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold);
            label.ForeColor = Color.White;
            label.Location = new Point(20, top);

            return label;
        }

        private Label CreateInfoValue(int top)
        {
            Label label = new Label();

            label.AutoSize = true;
            label.Font = new Font(
                "Segoe UI",
                9F);
            label.ForeColor = Color.Gainsboro;
            label.Location = new Point(185, top);

            return label;
        }

        //============================================================
        // LOAD FILTERS
        //============================================================

        private void LoadStatuses()
        {
            // Статусы доказательств загружаются из справочника БД.
            // Подключение создаётся через DatabaseConnection.
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"SELECT
                              Evidence_status_id,
                              Evidence_status_name
                          FROM Evidence_status
                          ORDER BY Evidence_status_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            cmbEvidenceStatus.Items.Clear();

                            cmbEvidenceStatus.Items.Add(
                                new ComboItem(-1, "Все статусы"));

                            while (reader.Read())
                            {
                                cmbEvidenceStatus.Items.Add(
                                    new ComboItem(
                                        reader.GetInt32(0),
                                        reader.GetString(1)));
                            }
                        }
                    }
                }

                if (cmbEvidenceStatus.Items.Count > 0)
                {
                    cmbEvidenceStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статусы доказательств.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEvidenceNames()
        {
            // Для фильтра берём уникальные названия прямо из Evidence.
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"SELECT DISTINCT
                              Evidence_name
                          FROM Evidence
                          WHERE Evidence_name IS NOT NULL
                          ORDER BY Evidence_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            cmbEvidenceType.Items.Clear();

                            cmbEvidenceType.Items.Add(
                                "Все названия");

                            while (reader.Read())
                            {
                                cmbEvidenceType.Items.Add(
                                    reader.GetString(0));
                            }
                        }
                    }
                }

                if (cmbEvidenceType.Items.Count > 0)
                {
                    cmbEvidenceType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить названия доказательств.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCases()
        {
            // В фильтр выводятся только дела, связанные с доказательствами.
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"SELECT DISTINCT
                              cc.Criminal_case_id,
                              cc.Case_number
                          FROM Criminal_case cc
                          INNER JOIN Protocol p
                              ON p.Protocol_id = cc.Protocol_id
                          INNER JOIN Evidence ev
                              ON ev.Evidence_id = p.Evidence_id
                          ORDER BY cc.Case_number;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            cmbCase.Items.Clear();

                            cmbCase.Items.Add(
                                new ComboItem(-1, "Все дела"));

                            while (reader.Read())
                            {
                                cmbCase.Items.Add(
                                    new ComboItem(
                                        reader.GetInt32(0),
                                        reader.GetString(1)));
                            }
                        }
                    }
                }

                if (cmbCase.Items.Count > 0)
                {
                    cmbCase.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить список дел.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //============================================================
        // LOAD EVIDENCE
        //============================================================

        private void LoadEvidence()
        {
            // Сначала получаем количество записей, затем текущую страницу.
            // Это позволяет сохранить существующую пагинацию.
            try
            {
                totalRecords = GetEvidenceCount();

                int totalPages = CalculateTotalPages();

                if (totalPages == 0)
                {
                    currentPage = 1;
                }
                else if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }

                DataTable table = GetEvidencePage();

                DisplayEvidence(table);
                UpdatePagination();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить доказательства.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int GetEvidenceCount()
        {
            // COUNT выполняется отдельным параметризованным запросом,
            // чтобы корректно рассчитать количество страниц.
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string whereClause =
                    BuildWhereClause();

                string query =
                    @"SELECT COUNT(DISTINCT ev.Evidence_id)
                      FROM Evidence ev
                      INNER JOIN Evidence_status es
                          ON es.Evidence_status_id =
                             ev.Evidence_status_id
                      LEFT JOIN Protocol p
                          ON p.Evidence_id =
                             ev.Evidence_id
                      LEFT JOIN Criminal_case cc
                          ON cc.Protocol_id =
                             p.Protocol_id
                      WHERE 1 = 1 "
                    + whereClause
                    + ";";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    AddSearchParameters(command);

                    return Convert.ToInt32(
                        command.ExecuteScalar());
                }
            }
        }

        private DataTable GetEvidencePage()
        {
            // Получаем только записи текущей страницы. Все фильтры
            // передаются в запрос через параметры Npgsql.
            DataTable table = new DataTable();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string whereClause =
                    BuildWhereClause();

                string query =
                    @"SELECT
                          ev.Evidence_id,
                          ev.Evidence_number,
                          ev.Evidence_name,
                          ev.Description_evidence,
                          ev.Date_of_seizure,
                          ev.Storage_location,
                          ev.Evidence_image,
                          es.Evidence_status_name,

                          COALESCE(
                              string_agg(
                                  DISTINCT cc.Case_number,
                                  ', '
                                  ORDER BY cc.Case_number
                              ),
                              '—'
                          ) AS Case_number

                      FROM Evidence ev

                      INNER JOIN Evidence_status es
                          ON es.Evidence_status_id =
                             ev.Evidence_status_id

                      LEFT JOIN Protocol p
                          ON p.Evidence_id =
                             ev.Evidence_id

                      LEFT JOIN Criminal_case cc
                          ON cc.Protocol_id =
                             p.Protocol_id

                      WHERE 1 = 1 "
                    + whereClause
                    + @"

                      GROUP BY
                          ev.Evidence_id,
                          ev.Evidence_number,
                          ev.Evidence_name,
                          ev.Description_evidence,
                          ev.Date_of_seizure,
                          ev.Storage_location,
                          ev.Evidence_image,
                          es.Evidence_status_name

                      ORDER BY ev.Evidence_id DESC

                      LIMIT @limit
                      OFFSET @offset;";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    AddSearchParameters(command);

                    command.Parameters.AddWithValue(
                        "@limit",
                        PageSize);

                    command.Parameters.AddWithValue(
                        "@offset",
                        (currentPage - 1) * PageSize);

                    using (NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        //============================================================
        // SEARCH
        //============================================================

        private string BuildWhereClause()
        {
            // Формируем SQL-условия отдельно от пользовательских значений.
            // Это сохраняет параметризованный запрос.
            string where = "";

            if (!string.IsNullOrWhiteSpace(
                txtEvidenceNumber.Text))
            {
                where +=
                    " AND ev.Evidence_number ILIKE @number ";
            }

            if (cmbEvidenceType.SelectedIndex > 0)
            {
                where +=
                    " AND ev.Evidence_name = @name ";
            }

            ComboItem status =
                cmbEvidenceStatus.SelectedItem as ComboItem;

            if (status != null && status.Id != -1)
            {
                where +=
                    " AND ev.Evidence_status_id = @statusId ";
            }

            ComboItem caseItem =
                cmbCase.SelectedItem as ComboItem;

            if (caseItem != null && caseItem.Id != -1)
            {
                where +=
                    @" AND EXISTS
                       (
                           SELECT 1
                           FROM Protocol p2
                           INNER JOIN Criminal_case cc2
                               ON cc2.Protocol_id =
                                  p2.Protocol_id
                           WHERE p2.Evidence_id =
                                 ev.Evidence_id
                             AND cc2.Criminal_case_id =
                                 @caseId
                       ) ";
            }

            if (dtDateFrom.Checked)
            {
                where +=
                    " AND ev.Date_of_seizure >= @dateFrom ";
            }

            if (dtDateTo.Checked)
            {
                where +=
                    " AND ev.Date_of_seizure <= @dateTo ";
            }

            return where;
        }

        private void AddSearchParameters(
            NpgsqlCommand command)
        {
            // Добавляем только те параметры, для которых выбран фильтр.
            if (!string.IsNullOrWhiteSpace(
                txtEvidenceNumber.Text))
            {
                command.Parameters.AddWithValue(
                    "@number",
                    "%" +
                    txtEvidenceNumber.Text.Trim() +
                    "%");
            }

            if (cmbEvidenceType.SelectedIndex > 0)
            {
                command.Parameters.AddWithValue(
                    "@name",
                    cmbEvidenceType.SelectedItem.ToString());
            }

            ComboItem status =
                cmbEvidenceStatus.SelectedItem as ComboItem;

            if (status != null && status.Id != -1)
            {
                command.Parameters.AddWithValue(
                    "@statusId",
                    status.Id);
            }

            ComboItem caseItem =
                cmbCase.SelectedItem as ComboItem;

            if (caseItem != null && caseItem.Id != -1)
            {
                command.Parameters.AddWithValue(
                    "@caseId",
                    caseItem.Id);
            }

            if (dtDateFrom.Checked)
            {
                command.Parameters.AddWithValue(
                    "@dateFrom",
                    dtDateFrom.Value.Date);
            }

            if (dtDateTo.Checked)
            {
                command.Parameters.AddWithValue(
                    "@dateTo",
                    dtDateTo.Value.Date);
            }
        }

        //============================================================
        // EVIDENCE LIST
        //============================================================

        private void DisplayEvidence(DataTable table)
        {
            // Карточки строятся из результата SQL-запроса.
            // Сами размеры и расположение элементов не меняются.
            ClearEvidenceCards();

            if (table.Rows.Count == 0)
            {
                Label emptyLabel = new Label();

                emptyLabel.Text =
                    "Доказательства не найдены";

                emptyLabel.ForeColor =
                    Color.Gainsboro;

                emptyLabel.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Italic);

                emptyLabel.AutoSize = true;

                emptyLabel.Margin =
                    new Padding(
                        10,
                        20,
                        0,
                        0);

                flpEvidence.Controls.Add(emptyLabel);

                ClearEvidenceInformation();
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                CreateEvidenceCard(row);
            }

            int firstId =
                Convert.ToInt32(
                    table.Rows[0]["Evidence_id"]);

            SelectEvidence(firstId);
        }

        private void ClearEvidenceCards()
        {
            foreach (Control control in flpEvidence.Controls)
            {
                DisposeControlImages(control);
            }

            flpEvidence.Controls.Clear();
        }

        private void CreateEvidenceCard(DataRow row)
        {
            int evidenceId =
                Convert.ToInt32(row["Evidence_id"]);

            Panel card = new Panel();

            card.Size = new Size(805, 50);
            card.BackColor =
                Color.FromArgb(30, 58, 117);
            card.Margin =
                new Padding(0, 0, 0, 6);
            card.BorderStyle =
                BorderStyle.FixedSingle;
            card.Cursor =
                Cursors.Hand;
            card.Tag =
                evidenceId;

            PictureBox picture = new PictureBox();

            picture.Size =
                new Size(42, 42);
            picture.Location =
                new Point(4, 3);
            picture.SizeMode =
                PictureBoxSizeMode.Zoom;
            picture.BackColor =
                Color.FromArgb(25, 45, 80);
            picture.Tag =
                evidenceId;

            if (row["Evidence_image"] != DBNull.Value)
            {
                try
                {
                    byte[] imageBytes =
                        (byte[])row["Evidence_image"];

                    if (imageBytes.Length > 0)
                    {
                        picture.Image =
                            BytesToImage(imageBytes);
                    }
                }
                catch
                {
                    // Некорректное изображение не должно мешать
                    // отображению остальных данных доказательства.
                    picture.Image = null;
                }
            }

            Label number = CreateCardLabel(
                Convert.ToString(
                    row["Evidence_number"]),
                new Point(60, 8),
                new Size(80, 30),
                true);

            number.Tag = evidenceId;

            Label name = CreateCardLabel(
                Convert.ToString(
                    row["Evidence_name"]),
                new Point(145, 8),
                new Size(260, 30),
                false);

            name.Tag = evidenceId;

            string dateText = "—";

            if (row["Date_of_seizure"] != DBNull.Value)
            {
                dateText =
                    Convert.ToDateTime(
                        row["Date_of_seizure"])
                    .ToString("dd.MM.yyyy");
            }

            Label date = CreateCardLabel(
                dateText,
                new Point(420, 8),
                new Size(100, 30),
                false);

            date.Tag = evidenceId;

            Label status = CreateCardLabel(
                Convert.ToString(
                    row["Evidence_status_name"]),
                new Point(530, 8),
                new Size(160, 30),
                true);

            status.Tag = evidenceId;

            Label arrow = CreateCardLabel(
                "›",
                new Point(760, 6),
                new Size(30, 35),
                true);

            arrow.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            arrow.ForeColor =
                Color.FromArgb(212, 160, 23);

            arrow.Tag = evidenceId;

            card.Controls.Add(picture);
            card.Controls.Add(number);
            card.Controls.Add(name);
            card.Controls.Add(date);
            card.Controls.Add(status);
            card.Controls.Add(arrow);

            card.Click += EvidenceCard_Click;
            picture.Click += EvidenceCard_Click;
            number.Click += EvidenceCard_Click;
            name.Click += EvidenceCard_Click;
            date.Click += EvidenceCard_Click;
            status.Click += EvidenceCard_Click;
            arrow.Click += EvidenceCard_Click;

            flpEvidence.Controls.Add(card);
        }

        private Label CreateCardLabel(
            string text,
            Point location,
            Size size,
            bool bold)
        {
            Label label = new Label();

            label.Text = text;
            label.Location = location;
            label.Size = size;
            label.ForeColor = Color.White;
            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    bold
                        ? FontStyle.Bold
                        : FontStyle.Regular);
            label.TextAlign =
                ContentAlignment.MiddleLeft;
            label.AutoEllipsis = true;
            label.Cursor = Cursors.Hand;

            return label;
        }

        private void EvidenceCard_Click(
            object sender,
            EventArgs e)
        {
            Control control =
                sender as Control;

            if (control == null ||
                control.Tag == null)
            {
                return;
            }

            int evidenceId;

            if (!int.TryParse(
                control.Tag.ToString(),
                out evidenceId))
            {
                return;
            }

            SelectEvidence(evidenceId);
        }

        private void SelectEvidence(int evidenceId)
        {
            selectedEvidenceId = evidenceId;

            LoadSelectedEvidence();
            HighlightSelectedCard();
        }

        private void HighlightSelectedCard()
        {
            foreach (Control control in flpEvidence.Controls)
            {
                Panel card = control as Panel;

                if (card == null ||
                    card.Tag == null)
                {
                    continue;
                }

                int id;

                if (!int.TryParse(
                    card.Tag.ToString(),
                    out id))
                {
                    continue;
                }

                card.BackColor =
                    id == selectedEvidenceId
                        ? Color.FromArgb(60, 90, 150)
                        : Color.FromArgb(30, 58, 117);
            }
        }

        //============================================================
        // SELECTED EVIDENCE
        //============================================================

        private void LoadSelectedEvidence()
        {
            if (selectedEvidenceId <= 0)
            {
                ClearEvidenceInformation();
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"SELECT
                              ev.Evidence_number,
                              ev.Evidence_name,
                              ev.Description_evidence,
                              ev.Date_of_seizure,
                              ev.Storage_location,
                              ev.Evidence_image,
                              es.Evidence_status_name,

                              COALESCE(
                                  string_agg(
                                      DISTINCT cc.Case_number,
                                      ', '
                                      ORDER BY cc.Case_number
                                  ),
                                  '—'
                              ) AS Case_number

                          FROM Evidence ev

                          INNER JOIN Evidence_status es
                              ON es.Evidence_status_id =
                                 ev.Evidence_status_id

                          LEFT JOIN Protocol p
                              ON p.Evidence_id =
                                 ev.Evidence_id

                          LEFT JOIN Criminal_case cc
                              ON cc.Protocol_id =
                                 p.Protocol_id

                          WHERE ev.Evidence_id =
                                @evidenceId

                          GROUP BY
                              ev.Evidence_id,
                              ev.Evidence_number,
                              ev.Evidence_name,
                              ev.Description_evidence,
                              ev.Date_of_seizure,
                              ev.Storage_location,
                              ev.Evidence_image,
                              es.Evidence_status_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@evidenceId",
                            selectedEvidenceId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ClearEvidenceInformation();
                                return;
                            }

                            lblEvidenceNumberValue.Text =
                                GetStringValue(
                                    reader,
                                    "Evidence_number");

                            lblEvidenceNameValue.Text =
                                GetStringValue(
                                    reader,
                                    "Evidence_name");

                            lblCaseValue.Text =
                                GetStringValue(
                                    reader,
                                    "Case_number");

                            lblStatusValue.Text =
                                GetStringValue(
                                    reader,
                                    "Evidence_status_name");

                            int dateIndex =
                                reader.GetOrdinal(
                                    "Date_of_seizure");

                            lblDateValue.Text =
                                reader.IsDBNull(dateIndex)
                                    ? "—"
                                    : reader.GetDateTime(
                                        dateIndex)
                                      .ToString("dd.MM.yyyy");

                            lblStorageValue.Text =
                                GetStringValue(
                                    reader,
                                    "Storage_location");

                            lblDescriptionValue.Text =
                                GetStringValue(
                                    reader,
                                    "Description_evidence");

                            int imageIndex =
                                reader.GetOrdinal(
                                    "Evidence_image");

                            if (reader.IsDBNull(imageIndex))
                            {
                                SetEvidenceImage(null);
                                btnViewPhoto.Enabled = false;
                            }
                            else
                            {
                                byte[] imageBytes =
                                    (byte[])reader.GetValue(
                                        imageIndex);

                                SetEvidenceImage(imageBytes);

                                btnViewPhoto.Enabled =
                                    imageBytes != null &&
                                    imageBytes.Length > 0;
                            }

                            btnEditEvidence.Enabled = true;
                            btnDeleteEvidence.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить информацию о доказательстве.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string GetStringValue(
            NpgsqlDataReader reader,
            string columnName)
        {
            int index =
                reader.GetOrdinal(columnName);

            if (reader.IsDBNull(index))
            {
                return "—";
            }

            return Convert.ToString(
                reader.GetValue(index));
        }

        private void SetEvidenceImage(byte[] imageBytes)
        {
            if (picEvidence.Image != null)
            {
                Image oldImage = picEvidence.Image;

                picEvidence.Image = null;
                oldImage.Dispose();
            }

            if (imageBytes == null ||
                imageBytes.Length == 0)
            {
                return;
            }

            try
            {
                picEvidence.Image =
                    BytesToImage(imageBytes);
            }
            catch
            {
                picEvidence.Image = null;
            }
        }

        private Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream stream =
                new MemoryStream(bytes))
            {
                using (Image temporaryImage =
                    Image.FromStream(stream))
                {
                    return new Bitmap(temporaryImage);
                }
            }
        }

        private void ClearEvidenceInformation()
        {
            selectedEvidenceId = -1;

            lblEvidenceNumberValue.Text = "—";
            lblEvidenceNameValue.Text = "—";
            lblCaseValue.Text = "—";
            lblStatusValue.Text = "—";
            lblDateValue.Text = "—";
            lblStorageValue.Text = "—";
            lblDescriptionValue.Text = "—";

            SetEvidenceImage(null);

            btnEditEvidence.Enabled = false;
            btnViewPhoto.Enabled = false;
            btnDeleteEvidence.Enabled = false;
        }

        //============================================================
        // PAGINATION
        //============================================================

        private int CalculateTotalPages()
        {
            if (totalRecords <= 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(
                totalRecords /
                (double)PageSize);
        }

        private void UpdatePagination()
        {
            int totalPages =
                CalculateTotalPages();

            if (totalRecords == 0)
            {
                lblPageInfo.Text = "0–0 из 0";
            }
            else
            {
                int from =
                    ((currentPage - 1) * PageSize) + 1;

                int to =
                    Math.Min(
                        currentPage * PageSize,
                        totalRecords);

                lblPageInfo.Text =
                    from +
                    "–" +
                    to +
                    " из " +
                    totalRecords;
            }

            btnFirstPage.Enabled =
                currentPage > 1;

            btnPreviousPage.Enabled =
                currentPage > 1;

            btnNextPage.Enabled =
                currentPage < totalPages;

            btnLastPage.Enabled =
                currentPage < totalPages;
        }

        //============================================================
        // SEARCH / RESET
        //============================================================

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            // Не допускаем поиск по некорректному диапазону дат.
            if (dtDateFrom.Checked &&
                dtDateTo.Checked &&
                dtDateFrom.Value.Date >
                dtDateTo.Value.Date)
            {
                MessageBox.Show(
                    "Дата начала периода не может быть позже даты окончания.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            currentPage = 1;
            LoadEvidence();
        }

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtEvidenceNumber.Clear();

            if (cmbEvidenceType.Items.Count > 0)
            {
                cmbEvidenceType.SelectedIndex = 0;
            }

            if (cmbEvidenceStatus.Items.Count > 0)
            {
                cmbEvidenceStatus.SelectedIndex = 0;
            }

            if (cmbCase.Items.Count > 0)
            {
                cmbCase.SelectedIndex = 0;
            }

            dtDateFrom.Checked = false;
            dtDateTo.Checked = false;

            currentPage = 1;

            LoadEvidence();
        }

        //============================================================
        // PAGINATION BUTTONS
        //============================================================

        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
            {
                return;
            }

            currentPage = 1;
            LoadEvidence();
        }

        private void BtnPreviousPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
            {
                return;
            }

            currentPage--;
            LoadEvidence();
        }

        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            int totalPages =
                CalculateTotalPages();

            if (currentPage >= totalPages)
            {
                return;
            }

            currentPage++;
            LoadEvidence();
        }

        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            int totalPages =
                CalculateTotalPages();

            if (totalPages == 0 ||
                currentPage >= totalPages)
            {
                return;
            }

            currentPage = totalPages;
            LoadEvidence();
        }

        //============================================================
        // ADD / EDIT
        //============================================================

        private void BtnAddEvidence_Click(
            object sender,
            EventArgs e)
        {
            // Валидация и сохранение находятся в EvidenceEditForm.
            // После успешного сохранения фильтры-справочники и список
            // обновляются из PostgreSQL.
            using (EvidenceEditForm form =
                new EvidenceEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;

                    LoadStatuses();
                    LoadEvidenceNames();
                    LoadCases();
                    LoadEvidence();
                }
            }
        }

        private void BtnEditEvidence_Click(
            object sender,
            EventArgs e)
        {
            if (selectedEvidenceId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите доказательство.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using (EvidenceEditForm form =
                new EvidenceEditForm(
                    selectedEvidenceId))
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadEvidenceNames();
                    LoadCases();
                    LoadEvidence();
                }
            }
        }

        //============================================================
        // PHOTO
        //============================================================

        private void BtnViewPhoto_Click(
            object sender,
            EventArgs e)
        {
            if (selectedEvidenceId <= 0)
            {
                return;
            }

            byte[] imageBytes =
                GetEvidenceImage(
                    selectedEvidenceId);

            if (imageBytes == null ||
                imageBytes.Length == 0)
            {
                MessageBox.Show(
                    "Для этого доказательства фотография отсутствует.",
                    "Фотография",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            ShowPhotoViewer(imageBytes);
        }

        private byte[] GetEvidenceImage(
            int evidenceId)
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"SELECT Evidence_image
                          FROM Evidence
                          WHERE Evidence_id = @evidenceId;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@evidenceId",
                            evidenceId);

                        object result =
                            command.ExecuteScalar();

                        if (result == null ||
                            result == DBNull.Value)
                        {
                            return null;
                        }

                        return (byte[])result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить фотографию.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }
        }

        private void ShowPhotoViewer(
            byte[] imageBytes)
        {
            Form viewer = new Form();

            viewer.Text =
                "Фотография доказательства";

            viewer.StartPosition =
                FormStartPosition.CenterParent;

            viewer.Size =
                new Size(900, 700);

            viewer.MinimizeBox = false;
            viewer.MaximizeBox = true;

            PictureBox picture =
                new PictureBox();

            picture.Dock = DockStyle.Fill;
            picture.SizeMode =
                PictureBoxSizeMode.Zoom;
            picture.Image =
                BytesToImage(imageBytes);

            viewer.Controls.Add(picture);

            viewer.FormClosed +=
                delegate
                {
                    if (picture.Image != null)
                    {
                        picture.Image.Dispose();
                        picture.Image = null;
                    }
                };

            viewer.ShowDialog(
                this.FindForm());
        }

        //============================================================
        // DELETE
        //============================================================

        private void BtnDeleteEvidence_Click(
            object sender,
            EventArgs e)
        {
            // Удаление выполняется только после выбора доказательства;
            // SQL-команда использует параметр ID.
            if (selectedEvidenceId <= 0)
            {
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Вы действительно хотите удалить выбранное доказательство?\n\n" +
                    "Операция необратима.",
                    "Удаление доказательства",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query =
                        @"DELETE FROM Evidence
                          WHERE Evidence_id = @evidenceId;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@evidenceId",
                            selectedEvidenceId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Доказательство удалено.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                currentPage = 1;

                LoadEvidenceNames();
                LoadCases();
                LoadEvidence();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    "Не удалось удалить доказательство.\n\n" +
                    ex.Message,
                    "Ошибка БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось удалить доказательство.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //============================================================
        // IMAGE CLEANUP
        //============================================================

        private void DisposeControlImages(
            Control control)
        {
            PictureBox picture =
                control as PictureBox;

            if (picture != null &&
                picture.Image != null)
            {
                picture.Image.Dispose();
                picture.Image = null;
            }

            foreach (Control child in control.Controls)
            {
                DisposeControlImages(child);
            }
        }

        //============================================================
        // COMBO ITEM
        //============================================================

        private class ComboItem
        {
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboItem(
                int id,
                string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}