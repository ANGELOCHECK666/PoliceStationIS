using Npgsql;
using PoliceStationIS.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Departments
{
    public partial class DepartmentsPage : UserControl
    {
        private int currentPage = 1;
        private int totalPages = 1;
        private int totalRecords = 0;
        private const int PageSize = 7;

        private int selectedDepartmentId = 0;
        private bool isLoadingFilter = false;

        private readonly Color navy = Color.FromArgb(5, 24, 58);
        private readonly Color panelBlue = Color.FromArgb(15, 39, 78);
        private readonly Color panelBlue2 = Color.FromArgb(20, 48, 94);
        private readonly Color inputBlue = Color.FromArgb(11, 31, 65);
        private readonly Color gold = Color.FromArgb(225, 176, 61);
        private readonly Color white = Color.White;
        private readonly Color light = Color.Gainsboro;
        private readonly Color green = Color.FromArgb(126, 181, 72);
        private readonly Color yellow = Color.FromArgb(225, 176, 61);
        private readonly Color red = Color.FromArgb(192, 72, 72);
        private readonly Color blue = Color.FromArgb(52, 126, 202);

        private DataTable departmentsTable = new DataTable();


        public DepartmentsPage()
        {
            InitializeComponent();

            ConfigureEvents();
            ConfigureGrid();

            LoadDepartments();
        }

        private void ConfigureEvents()
        {
            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            cmbDepartmentFilter.SelectedIndexChanged +=
                CmbDepartmentFilter_SelectedIndexChanged;

            dgvDepartments.SelectionChanged +=
                DgvDepartments_SelectionChanged;

            btnFirst.Click += BtnFirst_Click;
            btnPrevious.Click += BtnPrevious_Click;
            btnNext.Click += BtnNext_Click;
            btnLast.Click += BtnLast_Click;

        }

        private void ConfigureGrid()
        {
            dgvDepartments.Columns.Clear();
            dgvDepartments.AutoGenerateColumns = false;

            AddGridColumn("Department", "Подразделение", 0);
            AddGridColumn("Head", "Начальник", 1);
            AddGridColumn("Employees", "Сотрудников", 2);
            AddGridColumn("ActiveCases", "Активных дел", 3);
            AddGridColumn("Status", "Состояние", 4);

            dgvDepartments.CellPainting +=
                DgvDepartments_CellPainting;
        }

        private void AddGridColumn(
            string property,
            string header,
            int index)
        {
            DataGridViewTextBoxColumn column =
                new DataGridViewTextBoxColumn();

            column.Name = property;
            column.HeaderText = header;
            column.DataPropertyName = property;
            column.SortMode =
                DataGridViewColumnSortMode.NotSortable;
            column.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvDepartments.Columns.Insert(index, column);
        }

        private void LoadDepartments()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    LoadDepartmentFilter(connection);

                    totalRecords =
                        GetTotalRecords(connection);

                    totalPages =
                        Math.Max(
                            1,
                            (int)Math.Ceiling(
                                totalRecords /
                                (double)PageSize));

                    if (currentPage > totalPages)
                        currentPage = totalPages;

                    LoadDepartmentPage(connection);
                    LoadDashboardMetrics(connection);
                }

                UpdatePagination();

                if (dgvDepartments.Rows.Count > 0)
                {
                    dgvDepartments.ClearSelection();
                    dgvDepartments.Rows[0].Selected = true;
                    LoadSelectedDepartment();
                }
                else
                {
                    ClearDepartmentInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить подразделения из базы данных.\n\n" +
                    ex.Message,
                    "Ошибка подразделений",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDashboardMetrics(
            NpgsqlConnection connection)
        {
            lblTotalDepartments.Text =
                ExecuteScalarInt(
                    connection,
                    "SELECT COUNT(*) FROM Department;")
                .ToString();

            lblTotalEmployees.Text =
                ExecuteScalarInt(
                    connection,
                    "SELECT COUNT(*) FROM Employee;")
                .ToString();

            lblTotalActiveCases.Text =
                ExecuteScalarInt(
                    connection,
                    @"SELECT COUNT(*)
                      FROM Criminal_case cc
                      INNER JOIN Case_status cs
                          ON cs.case_status_id =
                             cc.case_status_id
                      WHERE cs.case_status_name
                            IN ('Возбуждено', 'Расследуется');")
                .ToString();

            lblAttentionDepartments.Text =
                ExecuteScalarInt(
                    connection,
                    @"SELECT COUNT(*)
                      FROM Department d
                      WHERE
                          (
                              SELECT COUNT(*)
                              FROM Employee e
                              INNER JOIN Employment_status es
                                  ON es.employment_status_id =
                                     e.employment_status_id
                              WHERE e.department_id =
                                    d.department_id
                          ) = 0
                          OR
                          (
                              SELECT COUNT(*)
                              FROM Employee e
                              INNER JOIN Employment_status es
                                  ON es.employment_status_id =
                                     e.employment_status_id
                              WHERE e.department_id =
                                    d.department_id
                                AND es.employment_status_name =
                                    'На службе'
                          ) * 100.0
                          /
                          NULLIF(
                              (
                                  SELECT COUNT(*)
                                  FROM Employee e
                                  WHERE e.department_id =
                                        d.department_id
                              ),
                              0
                          ) < 60;")
                .ToString();
        }

        private int ExecuteScalarInt(
            NpgsqlConnection connection,
            string query)
        {
            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                object value =
                    command.ExecuteScalar();

                if (value == null ||
                    value == DBNull.Value)
                    return 0;

                return Convert.ToInt32(value);
            }
        }

        private void LoadDepartmentFilter(
            NpgsqlConnection connection)
        {
            string selected =
                cmbDepartmentFilter.SelectedItem == null
                    ? "Все подразделения"
                    : cmbDepartmentFilter.SelectedItem.ToString();

            isLoadingFilter = true;

            try
            {
                cmbDepartmentFilter.Items.Clear();
                cmbDepartmentFilter.Items.Add(
                    "Все подразделения");

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        @"SELECT department_name
                          FROM Department
                          ORDER BY department_name;",
                        connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDepartmentFilter.Items.Add(
                                reader["department_name"].ToString());
                        }
                    }
                }

                int index =
                    cmbDepartmentFilter.Items.IndexOf(selected);

                cmbDepartmentFilter.SelectedIndex =
                    index >= 0 ? index : 0;
            }
            finally
            {
                isLoadingFilter = false;
            }
        }

        private int GetTotalRecords(
            NpgsqlConnection connection)
        {
            string filter =
                BuildWhereClause(
                    out List<NpgsqlParameter> parameters);

            string query =
                @"SELECT COUNT(*)
                  FROM Department d
                  " + filter + ";";

            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                foreach (NpgsqlParameter parameter
                         in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private void LoadDepartmentPage(
            NpgsqlConnection connection)
        {
            string filter =
                BuildWhereClause(
                    out List<NpgsqlParameter> parameters);

            int offset =
                (currentPage - 1) * PageSize;

            string query =
                @"
SELECT
    d.department_id AS ""Id"",
    d.department_name AS ""Department"",

    COALESCE(
        (
            SELECT CONCAT_WS(
                ' ',
                e_head.last_name,
                e_head.name_,
                e_head.middle_name
            )
            FROM Employee e_head
            INNER JOIN Post p_head
                ON p_head.post_id =
                   e_head.post_id
            WHERE e_head.department_id =
                  d.department_id
              AND p_head.post_name =
                  'Начальник отдела'
            ORDER BY e_head.employee_id
            LIMIT 1
        ),
        'Не назначен'
    ) AS ""Head"",

    (
        SELECT COUNT(*)
        FROM Employee e
        WHERE e.department_id =
              d.department_id
    ) AS ""Employees"",

    (
        SELECT COUNT(DISTINCT cc.criminal_case_id)
        FROM Criminal_case cc
        INNER JOIN Case_status cs
            ON cs.case_status_id =
               cc.case_status_id
        INNER JOIN Employee e_case
            ON e_case.employee_id =
               cc.employee_id
        WHERE e_case.department_id =
              d.department_id
          AND cs.case_status_name
              IN ('Возбуждено', 'Расследуется')
    ) AS ""ActiveCases"",

    CASE
        WHEN
            (
                SELECT COUNT(*)
                FROM Employee e
                WHERE e.department_id =
                      d.department_id
            ) = 0
        THEN 'Требует внимания'

        WHEN
            (
                SELECT COUNT(*)
                FROM Employee e
                INNER JOIN Employment_status es
                    ON es.employment_status_id =
                       e.employment_status_id
                WHERE e.department_id =
                      d.department_id
                  AND es.employment_status_name =
                      'На службе'
            ) * 100.0
            /
            NULLIF(
                (
                    SELECT COUNT(*)
                    FROM Employee e
                    WHERE e.department_id =
                          d.department_id
                ),
                0
            ) >= 80
        THEN 'В норме'

        WHEN
            (
                SELECT COUNT(*)
                FROM Employee e
                INNER JOIN Employment_status es
                    ON es.employment_status_id =
                       e.employment_status_id
                WHERE e.department_id =
                      d.department_id
                  AND es.employment_status_name =
                      'На службе'
            ) * 100.0
            /
            NULLIF(
                (
                    SELECT COUNT(*)
                    FROM Employee e
                    WHERE e.department_id =
                          d.department_id
                ),
                0
            ) >= 60
        THEN 'Есть проблемы'

        ELSE 'Требует внимания'
    END AS ""Status""

FROM Department d
" + filter + @"

ORDER BY d.department_name
LIMIT @limit
OFFSET @offset;";

            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                foreach (NpgsqlParameter parameter
                         in parameters)
                {
                    command.Parameters.Add(parameter);
                }

                command.Parameters.AddWithValue(
                    "@limit",
                    PageSize);

                command.Parameters.AddWithValue(
                    "@offset",
                    offset);

                using (NpgsqlDataAdapter adapter =
                    new NpgsqlDataAdapter(command))
                {
                    departmentsTable =
                        new DataTable();

                    adapter.Fill(
                        departmentsTable);
                }
            }

            dgvDepartments.DataSource =
                departmentsTable;
        }

        private string BuildWhereClause(
            out List<NpgsqlParameter> parameters)
        {
            parameters =
                new List<NpgsqlParameter>();

            List<string> conditions =
                new List<string>();

            string search =
                txtSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(search))
            {
                conditions.Add(
                    "LOWER(d.department_name) " +
                    "LIKE LOWER(@search)");

                parameters.Add(
                    new NpgsqlParameter(
                        "@search",
                        "%" + search + "%"));
            }

            if (cmbDepartmentFilter.SelectedIndex > 0 &&
                cmbDepartmentFilter.SelectedItem != null)
            {
                conditions.Add(
                    "d.department_name = @department");

                parameters.Add(
                    new NpgsqlParameter(
                        "@department",
                        cmbDepartmentFilter.SelectedItem.ToString()));
            }

            if (conditions.Count == 0)
                return string.Empty;

            return "WHERE " +
                   string.Join(
                       " AND ",
                       conditions);
        }

        private void DgvDepartments_SelectionChanged(
            object sender,
            EventArgs e)
        {
            LoadSelectedDepartment();
        }

        private void LoadSelectedDepartment()
        {
            if (dgvDepartments.CurrentRow == null)
                return;

            DataRowView row =
                dgvDepartments.CurrentRow
                    .DataBoundItem as DataRowView;

            if (row == null)
                return;

            selectedDepartmentId =
                Convert.ToInt32(
                    row["Id"]);

            lblInfoDepartment.Text =
                Convert.ToString(
                    row["Department"]);

            lblInfoHead.Text =
                Convert.ToString(
                    row["Head"]);

            lblInfoEmployees.Text =
                Convert.ToString(
                    row["Employees"]);

            lblInfoActiveCases.Text =
                Convert.ToString(
                    row["ActiveCases"]);

            LoadAdditionalDepartmentInfo();
        }

        private void LoadAdditionalDepartmentInfo()
        {
            if (selectedDepartmentId <= 0)
                return;

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    int inspections =
                        ExecuteDepartmentCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM Inspection i
                              INNER JOIN Protocol p
                                  ON p.protocol_id =
                                     i.protocol_id
                              INNER JOIN Employee e
                                  ON e.employee_id =
                                     p.employee_id
                              WHERE e.department_id =
                                    @department_id;");

                    int dogs =
                        ExecuteDepartmentCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM Service_dog sd
                              INNER JOIN Employee e
                                  ON e.employee_id =
                                     sd.employee_id
                              WHERE e.department_id =
                                    @department_id;");

                    int activeEmployees =
                        ExecuteDepartmentCount(
                            connection,
                            @"SELECT COUNT(*)
                              FROM Employee e
                              INNER JOIN Employment_status es
                                  ON es.employment_status_id =
                                     e.employment_status_id
                              WHERE e.department_id =
                                    @department_id
                                AND es.employment_status_name =
                                    'На службе';");

                    lblInfoInspections.Text =
                        inspections.ToString();

                    lblInfoDogs.Text =
                        dogs.ToString();

                    lblInfoActiveEmployees.Text =
                        activeEmployees.ToString();

                    string status =
                        GetStatusByReadiness(
                            Convert.ToInt32(
                                lblInfoEmployees.Text),
                            activeEmployees);

                    lblInfoStatus.Text =
                        status;

                    lblInfoStatus.ForeColor =
                        status == "В норме"
                            ? green
                            : status == "Есть проблемы"
                                ? yellow
                                : red;

                    int readinessPercent =
                        Convert.ToInt32(
                            lblInfoEmployees.Text) == 0
                                ? 0
                                : (int)Math.Round(
                                    activeEmployees * 100.0 /
                                    Convert.ToInt32(
                                        lblInfoEmployees.Text));

                    lblInfoReadiness.Text =
                        readinessPercent + "%";

                    lblInfoReadiness.ForeColor =
                        status == "В норме"
                            ? green
                            : status == "Есть проблемы"
                                ? yellow
                                : red;
                }
            }
            catch
            {
                lblInfoInspections.Text = "—";
                lblInfoDogs.Text = "—";
                lblInfoActiveEmployees.Text = "—";
                lblInfoStatus.Text = "—";
                lblInfoReadiness.Text = "—";
                lblInfoStatus.ForeColor = light;
                lblInfoReadiness.ForeColor = light;
            }
        }

        private int ExecuteDepartmentCount(
            NpgsqlConnection connection,
            string query)
        {
            using (NpgsqlCommand command =
                new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@department_id",
                    selectedDepartmentId);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private string GetStatusByReadiness(
            int total,
            int active)
        {
            if (total <= 0)
                return "Требует внимания";

            double percent =
                active * 100.0 / total;

            if (percent >= 80)
                return "В норме";

            if (percent >= 60)
                return "Есть проблемы";

            return "Требует внимания";
        }

        private void ClearDepartmentInfo()
        {
            selectedDepartmentId = 0;

            lblInfoDepartment.Text =
                "Подразделение не выбрано";

            lblInfoHead.Text = "—";
            lblInfoEmployees.Text = "—";
            lblInfoActiveEmployees.Text = "—";
            lblInfoActiveCases.Text = "—";
            lblInfoInspections.Text = "—";
            lblInfoDogs.Text = "—";
            lblInfoStatus.Text = "—";
            lblInfoReadiness.Text = "—";

            lblInfoStatus.ForeColor = light;
            lblInfoReadiness.ForeColor = light;
        }

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            currentPage = 1;
            LoadDepartments();
        }

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Clear();
            cmbDepartmentFilter.SelectedIndex = 0;
            currentPage = 1;
            LoadDepartments();
        }

        private void TxtSearch_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                BtnSearch_Click(
                    null,
                    EventArgs.Empty);
            }
        }

        private void CmbDepartmentFilter_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (!IsHandleCreated ||
                isLoadingFilter)
                return;

            currentPage = 1;
            LoadDepartments();
        }

        private void BtnFirst_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
                return;

            currentPage = 1;
            LoadDepartments();
        }

        private void BtnPrevious_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage <= 1)
                return;

            currentPage--;
            LoadDepartments();
        }

        private void BtnNext_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;

            currentPage++;
            LoadDepartments();
        }

        private void BtnLast_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
                return;

            currentPage = totalPages;
            LoadDepartments();
        }

        private void UpdatePagination()
        {
            lblPage.Text =
                "Страница " +
                currentPage +
                " из " +
                totalPages;

            lblTotal.Text =
                "Всего подразделений: " +
                totalRecords;

            btnFirst.Enabled =
                currentPage > 1;

            btnPrevious.Enabled =
                currentPage > 1;

            btnNext.Enabled =
                currentPage < totalPages;

            btnLast.Enabled =
                currentPage < totalPages;
        }

        private void DgvDepartments_CellPainting(
            object sender,
            DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex != 4)
                return;

            e.PaintBackground(
                e.CellBounds,
                true);

            string status =
                Convert.ToString(
                    dgvDepartments.Rows[
                        e.RowIndex]
                    .Cells[
                        e.ColumnIndex]
                    .Value);

            Color color =
                status == "В норме"
                    ? green
                    : status == "Есть проблемы"
                        ? yellow
                        : red;

            int dotSize = 9;

            using (Brush brush =
                new SolidBrush(color))
            {
                e.Graphics.FillEllipse(
                    brush,
                    e.CellBounds.Left + 12,
                    e.CellBounds.Top +
                    (e.CellBounds.Height -
                     dotSize) / 2,
                    dotSize,
                    dotSize);
            }

            using (Brush brush =
                new SolidBrush(color))
            {
                e.Graphics.DrawString(
                    status,
                    e.CellStyle.Font,
                    brush,
                    e.CellBounds.Left + 29,
                    e.CellBounds.Top + 7);
            }

            e.Handled = true;
        }
    }
}
