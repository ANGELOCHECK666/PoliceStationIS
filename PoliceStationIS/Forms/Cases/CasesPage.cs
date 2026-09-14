using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Evidence;
using PoliceStationIS.Forms.Expertises;
using PoliceStationIS.Forms.Protocols;
using PoliceStationIS.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Cases
{
    public partial class CasesPage : UserControl
    {
        private DataTable casesTable;
        private const int PageSize = 9;

        private int currentPage = 1;

        private int totalPages = 1;

        private int totalRecords = 0;

        private bool searchMode = false;
        public CasesPage()
        {
            InitializeComponent();

            ConfigureGrid();

            InitializePage();
        }

        private void InitializePage()
        {
            // При открытии раздела сначала загружаются значения
            // справочников для фильтров, затем сами уголовные дела.
            // Все подключения к PostgreSQL создаются только через
            // общий класс DatabaseConnection.
            LoadArticles();

            LoadStatuses();

            LoadInvestigators();
            LoadCases();
        }

        private void ConfigureGrid()
        {
            dgvCases.EnableHeadersVisualStyles = false;

            dgvCases.AutoGenerateColumns = false;

            dgvCases.BackgroundColor =
                Color.FromArgb(28, 47, 92);

            dgvCases.BorderStyle =
                BorderStyle.None;

            dgvCases.GridColor =
                Color.FromArgb(212, 160, 23);

            dgvCases.RowHeadersVisible = false;

            dgvCases.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCases.MultiSelect = false;

            dgvCases.ReadOnly = true;

            dgvCases.AllowUserToAddRows = false;

            dgvCases.AllowUserToDeleteRows = false;

            dgvCases.AllowUserToResizeRows = false;

            dgvCases.AllowUserToResizeColumns = false;

            dgvCases.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvCases.ColumnHeadersHeight = 42;

            dgvCases.RowTemplate.Height = 34;

            dgvCases.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(48, 72, 125);

            dgvCases.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(212, 160, 23);

            dgvCases.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            dgvCases.DefaultCellStyle.BackColor =
                Color.FromArgb(30, 58, 117);

            dgvCases.DefaultCellStyle.ForeColor =
                Color.White;

            dgvCases.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(60, 90, 150);

            dgvCases.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvCases.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            dgvCases.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;

            dgvCases.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;
        }

        private void LoadCases()
        {
            // Основная загрузка списка дел выполняется непосредственно
            // из PostgreSQL. Здесь же рассчитывается пагинация и
            // применяются текущие параметры поиска.
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Условия и параметры поиска формируются отдельно,
                    // поэтому пользовательские значения не вставляются
                    // напрямую в SQL-запрос.
                    string fromWhere =
    BuildSearchConditions();
                    string countQuery =
"SELECT COUNT(*) " +
fromWhere;

                    using (NpgsqlCommand countCommand =
    new NpgsqlCommand(
        countQuery,
        connection))
                    {
                        AddSearchParameters(countCommand);

                        totalRecords =
                            Convert.ToInt32(
                                countCommand.ExecuteScalar());

                        totalPages =
                            Math.Max(
                                1,
                                (int)Math.Ceiling(
                                    totalRecords /
                                    (double)PageSize));
                    }

                    string query =
@"
SELECT

cc.criminal_case_id AS ""Id"",

cc.case_number AS ""Номер дела"",

cc.case_creation_date AS ""Дата возбуждения"",

art.article_of_the_ccrf_code AS ""Статья УК РФ"",

cs.case_status_name AS ""Статус"",

e.last_name || ' ' ||
LEFT(e.name_,1) || '.' ||
LEFT(COALESCE(e.middle_name,''),1) || '.'
AS ""Следователь"",

cc.last_update_date
AS ""Дата последнего изменения""

"
+
fromWhere
+
@"

ORDER BY
cc.case_creation_date DESC

LIMIT @limit

OFFSET @offset;
";

                    NpgsqlCommand command =
    new NpgsqlCommand(
        query,
        connection);

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
                        casesTable =
                            new DataTable();

                        adapter.Fill(casesTable);

                        dgvCases.DataSource =
                            casesTable;

                        casesTable.Columns["Id"].ColumnMapping =
    MappingType.Hidden;

                        dgvCases.Columns[0].DataPropertyName =
                            "Номер дела";

                        dgvCases.Columns[1].DataPropertyName =
                            "Дата возбуждения";

                        dgvCases.Columns[2].DataPropertyName =
                            "Статья УК РФ";

                        dgvCases.Columns[3].DataPropertyName =
                            "Статус";

                        dgvCases.Columns[4].DataPropertyName =
                            "Следователь";

                        dgvCases.Columns[5].DataPropertyName =
                            "Дата последнего изменения";

                        if (casesTable.Rows.Count > 0)
                        {
                            LoadCaseInformation(
                                Convert.ToInt32(
                                    casesTable.Rows[0]["Id"]));
                        }
                        int startRecord =
    ((currentPage - 1) * PageSize) + 1;

                        int endRecord =
                            startRecord +
                            casesTable.Rows.Count - 1;

                        if (casesTable.Rows.Count == 0)
                        {
                            startRecord = 0;
                            endRecord = 0;
                        }

                        lblPageInfo.Text =
                            $"{startRecord}–{endRecord} из {totalRecords} дел";

                        UpdatePaginationButtons();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки дел",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdatePaginationButtons()
        {
            int firstPage =
                ((currentPage - 1) / 3) * 3 + 1;

            btnPage1.Text =
                firstPage <= totalPages
                ? firstPage.ToString()
                : "";

            btnPage2.Text =
                firstPage + 1 <= totalPages
                ? (firstPage + 1).ToString()
                : "";

            btnPage3.Text =
                firstPage + 2 <= totalPages
                ? (firstPage + 2).ToString()
                : "";

            btnPage1.Enabled =
                btnPage1.Text != "";

            btnPage2.Enabled =
                btnPage2.Text != "";

            btnPage3.Enabled =
                btnPage3.Text != "";

            btnFirstPage.Enabled =
                currentPage > 1;

            btnPreviousPage.Enabled =
                currentPage > 1;

            btnNextPage.Enabled =
                currentPage < totalPages;

            btnLastPage.Enabled =
                currentPage < totalPages;

            btnPage1.BackColor =
    Color.FromArgb(42, 73, 133);

            btnPage2.BackColor =
                Color.FromArgb(42, 73, 133);

            btnPage3.BackColor =
                Color.FromArgb(42, 73, 133);

            if (btnPage1.Text == currentPage.ToString())
                btnPage1.BackColor =
                    Color.FromArgb(196, 145, 35);

            if (btnPage2.Text == currentPage.ToString())
                btnPage2.BackColor =
                    Color.FromArgb(196, 145, 35);

            if (btnPage3.Text == currentPage.ToString())
                btnPage3.BackColor =
                    Color.FromArgb(196, 145, 35);
        }

        private void GoToPage(int page)
        {
            if (page < 1)
                page = 1;

            if (page > totalPages)
                page = totalPages;

            currentPage = page;

            LoadCases();
        }

        private void LoadCaseInformation(int caseId)
        {
            // Загружаем подробную информацию только для выбранного
            // дела. ID передаётся как параметр SQL-запроса.
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
        @"
SELECT

cc.case_number,

cc.case_creation_date,

cc.last_update_date,

art.article_of_the_ccrf_code,

art.article_of_the_ccrf_name,

cs.case_status_name,

e.last_name,
e.name_,
e.middle_name,

d.department_name

FROM criminal_case cc

JOIN employee e
ON cc.employee_id=e.employee_id

JOIN department d
ON e.department_id=d.department_id

JOIN article_of_the_ccrf art
ON cc.article_of_the_ccrf_id=
art.article_of_the_ccrf_id

JOIN case_status cs
ON cc.case_status_id=
cs.case_status_id

WHERE cc.criminal_case_id=@id;
";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            caseId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblCaseNumberValue.Text =
                                    reader["case_number"].ToString();

                                lblOpenDateValue.Text =
                                    Convert.ToDateTime(
                                        reader["case_creation_date"])
                                    .ToString("dd.MM.yyyy");

                                lblLastUpdateValue.Text =
                                    Convert.ToDateTime(
                                        reader["last_update_date"])
                                    .ToString("dd.MM.yyyy");

                                lblCaseStatusValue.Text =
                                    "● " +
                                    reader["case_status_name"];

                                lblDepartmentValue.Text =
                                    reader["department_name"].ToString();

                                lblInvestigatorValue.Text =
                                    $"{reader["last_name"]} " +
                                    $"{reader["name_"].ToString()[0]}." +
                                    $"{reader["middle_name"].ToString()[0]}.";

                                string article =
                                    reader["article_of_the_ccrf_code"].ToString();

                                lblArticleValue.Text =
                                    $"ст. {article} УК РФ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки карточки");
            }
        }

        private void LoadArticles()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                @"SELECT
            article_of_the_ccrf_code
          FROM article_of_the_ccrf
          ORDER BY article_of_the_ccrf_code;";

                var adapter =
                    new NpgsqlDataAdapter(query, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbArticle.Items.Clear();

                cmbArticle.Items.Add("Все");

                foreach (DataRow row in table.Rows)
                    cmbArticle.Items.Add(
                        row[0].ToString());

                cmbArticle.SelectedIndex = 0;
            }
        }

        private void LoadStatuses()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                @"SELECT
            case_status_name
          FROM case_status
          ORDER BY case_status_name;";

                var adapter =
                    new NpgsqlDataAdapter(query, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbStatus.Items.Clear();

                cmbStatus.Items.Add("Все");

                foreach (DataRow row in table.Rows)
                    cmbStatus.Items.Add(
                        row[0].ToString());

                cmbStatus.SelectedIndex = 0;
            }
        }

        private void LoadInvestigators()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
        @"SELECT
last_name || ' ' ||
LEFT(name_,1) || '.' ||
LEFT(COALESCE(middle_name,''),1) || '.'
FROM employee
ORDER BY last_name;";

                var adapter =
                    new NpgsqlDataAdapter(query, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbInvestigator.Items.Clear();

                cmbInvestigator.Items.Add("Все");

                foreach (DataRow row in table.Rows)
                    cmbInvestigator.Items.Add(
                        row[0].ToString());

                cmbInvestigator.SelectedIndex = 0;
            }
        }

        private void AddSearchParameters(
    NpgsqlCommand command)
        {
            // Все значения фильтров передаются через параметры Npgsql.
            // Это безопаснее, чем собирать SQL из строк интерфейса.
            if (!searchMode)
                return;

            if (!string.IsNullOrWhiteSpace(txtCaseNumber.Text))
            {
                command.Parameters.AddWithValue(
                    "@number",
                    "%" + txtCaseNumber.Text.Trim() + "%");
            }

            if (cmbArticle.SelectedIndex > 0)
            {
                command.Parameters.AddWithValue(
                    "@article",
                    cmbArticle.Text);
            }

            if (cmbStatus.SelectedIndex > 0)
            {
                command.Parameters.AddWithValue(
                    "@status",
                    cmbStatus.Text);
            }

            if (cmbInvestigator.SelectedIndex > 0)
            {
                command.Parameters.AddWithValue(
                    "@investigator",
                    cmbInvestigator.Text);
            }

            if (dtDateFrom.Checked &&
                dtDateTo.Checked)
            {
                command.Parameters.AddWithValue(
                    "@dateFrom",
                    dtDateFrom.Value.Date);

                command.Parameters.AddWithValue(
                    "@dateTo",
                    dtDateTo.Value.Date);
            }
        }

        private string BuildSearchConditions()
        {
            // Возвращаем только SQL-условия. Значения фильтров
            // добавляются отдельно в AddSearchParameters().
            string fromWhere =
        @"

FROM criminal_case cc

INNER JOIN employee e
ON cc.employee_id = e.employee_id

INNER JOIN article_of_the_ccrf art
ON cc.article_of_the_ccrf_id =
art.article_of_the_ccrf_id

INNER JOIN case_status cs
ON cc.case_status_id =
cs.case_status_id

WHERE 1 = 1
";

            if (!searchMode)
                return fromWhere;

            if (!string.IsNullOrWhiteSpace(txtCaseNumber.Text))
            {
                fromWhere +=
                    @" AND cc.case_number ILIKE @number";
            }

            if (cmbArticle.SelectedIndex > 0)
            {
                fromWhere +=
                    @" AND art.article_of_the_ccrf_code=@article";
            }

            if (cmbStatus.SelectedIndex > 0)
            {
                fromWhere +=
                    @" AND cs.case_status_name=@status";
            }

            if (cmbInvestigator.SelectedIndex > 0)
            {
                fromWhere +=
        @" AND
(
e.last_name || ' ' ||
LEFT(e.name_,1) || '.' ||
LEFT(COALESCE(e.middle_name,''),1) || '.'
)=@investigator";
            }

            if (dtDateFrom.Checked &&
                dtDateTo.Checked)
            {
                fromWhere +=
        @" AND
cc.case_creation_date
BETWEEN @dateFrom
AND @dateTo";
            }

            return fromWhere;
        }

        #region Search

        private void SearchCases()
        {
            // После нового поиска возвращаемся на первую страницу.
            currentPage = 1;

            searchMode = true;

            LoadCases();
        }

        private void ResetFilters()
        {
            // Сбрасываем только состояние фильтров и заново
            // загружаем исходный список из базы.
            txtCaseNumber.Clear();

            cmbArticle.SelectedIndex = 0;

            cmbStatus.SelectedIndex = 0;

            cmbInvestigator.SelectedIndex = 0;

            dtDateFrom.Checked = false;

            dtDateTo.Checked = false;

            searchMode = false;

            currentPage = 1;

            LoadCases();
        }

        #endregion

        #region Case actions

        private void CreateCase()
        {
            // Проверка и сохранение данных нового дела находятся
            // в CaseEditForm. После успешного сохранения список
            // обновляется из PostgreSQL.
            using (CaseEditForm form =
                new CaseEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;
                    LoadCases();
                }
            }
        }

        private void EditCase()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите дело.",
                    "Редактирование дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Редактирование дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int caseId =
                Convert.ToInt32(row["Id"]);

            using (CaseEditForm form =
                new CaseEditForm(caseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void CloseCase()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите дело.",
                    "Закрытие дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Закрытие дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int caseId =
                Convert.ToInt32(row["Id"]);

            using (CloseCaseForm form =
                new CloseCaseForm(caseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void TransferToCourt()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите дело.",
                    "Передача дела в суд",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Передача дела в суд",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int caseId =
                Convert.ToInt32(row["Id"]);

            using (TransferToCourtForm form =
                new TransferToCourtForm(caseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void SuspendCase()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите дело.",
                    "Приостановление дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Приостановление дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int caseId =
                Convert.ToInt32(row["Id"]);

            using (SuspendCaseForm form =
                new SuspendCaseForm(caseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void ResumeCase()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите дело.",
                    "Возобновление дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Возобновление дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int caseId =
                Convert.ToInt32(row["Id"]);

            using (ResumeCaseForm form =
                new ResumeCaseForm(caseId))
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void PrintCase()
        {
            if (dgvCases.CurrentRow == null)
            {
                MessageBox.Show(
                    "Сначала выберите уголовное дело.",
                    "Печать дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
            {
                MessageBox.Show(
                    "Не удалось определить выбранное дело.",
                    "Печать дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int caseId;

            try
            {
                caseId =
                    Convert.ToInt32(row["Id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось определить идентификатор уголовного дела.\n\n" +
                    ex.Message,
                    "Печать дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            CasePrintService printService =
                new CasePrintService(caseId);

            printService.GenerateAndPrint(this);
        }

        #endregion

        #region Quick actions

        private void AddEvidence()
        {
            using (EvidenceEditForm form =
                new EvidenceEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void AssignExpertise()
        {
            using (ExpertiseEditForm form =
                new ExpertiseEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        private void AddProtocol()
        {
            using (ProtocolEditForm form =
                new ProtocolEditForm())
            {
                if (form.ShowDialog(this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadCases();
                }
            }
        }

        #endregion

        #region Events

        private void btnCreateCase_Click(object sender, EventArgs e)
        {
            CreateCase();
        }

        private void btnEditCase_Click(object sender, EventArgs e)
        {
            EditCase();
        }

        private void btnCloseCase_Click(object sender, EventArgs e)
        {
            CloseCase();
        }

        private void btnTransferCourt_Click(object sender, EventArgs e)
        {
            TransferToCourt();
        }

        private void btnSuspendCase_Click(object sender, EventArgs e)
        {
            SuspendCase();
        }

        private void btnResumeCase_Click(object sender, EventArgs e)
        {
            ResumeCase();
        }

        private void btnPrintCase_Click(object sender, EventArgs e)
        {
            PrintCase();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCases();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnAddEvidence_Click(object sender, EventArgs e)
        {
            AddEvidence();
        }

        private void btnAssignExpertise_Click(object sender, EventArgs e)
        {
            AssignExpertise();
        }

        private void btnAddProtocol_Click(object sender, EventArgs e)
        {
            AddProtocol();
        }


        private void btnFirstPage_Click(
    object sender,
    EventArgs e)
        {
            GoToPage(1);
        }

        private void btnPreviousPage_Click(
    object sender,
    EventArgs e)
        {
            GoToPage(currentPage - 1);
        }

        private void btnNextPage_Click(
    object sender,
    EventArgs e)
        {
            GoToPage(currentPage + 1);
        }

        private void btnLastPage_Click(
    object sender,
    EventArgs e)
        {
            GoToPage(totalPages);
        }

        private void btnPage1_Click(
    object sender,
    EventArgs e)
        {
            GoToPage(
                Convert.ToInt32(btnPage1.Text));
        }

        private void btnPage2_Click(
    object sender,
    EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(btnPage2.Text))
            {
                GoToPage(
                    Convert.ToInt32(btnPage2.Text));
            }
        }

        private void btnPage3_Click(
    object sender,
    EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(btnPage3.Text))
            {
                GoToPage(
                    Convert.ToInt32(btnPage3.Text));
            }
        }

        private void dgvCases_SelectionChanged(
    object sender,
    EventArgs e)
        {
            // При смене строки карточка справа обновляется
            // по ID выбранного дела из текущего DataRowView.
            if (dgvCases.CurrentRow == null)
                return;

            DataRowView row =
                dgvCases.CurrentRow.DataBoundItem
                as DataRowView;

            if (row == null)
                return;

            int caseId =
                Convert.ToInt32(row["Id"]);

            LoadCaseInformation(caseId);
        }

        #endregion
    }
}