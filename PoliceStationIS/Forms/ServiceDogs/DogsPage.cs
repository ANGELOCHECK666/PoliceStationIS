using Npgsql;
using PoliceStationIS.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Dogs
{
    public partial class DogsPage : UserControl
    {
        private const int PageSize = 9;

        private int currentPage = 1;
        private int totalPages = 1;
        private int totalRecords = 0;

        private int selectedDogId = 0;

        public DogsPage()
        {
            InitializeComponent();

            ConfigureGrid();
            LoadStampNumbers();

            btnSearch.Click += BtnSearch_Click;
            btnReset.Click += BtnReset_Click;

            btnAddDog.Click += BtnAddDog_Click;
            btnEditDog.Click += BtnEditDog_Click;
            btnAssignDog.Click += BtnAssignDog_Click;

            btnFirstPage.Click += BtnFirstPage_Click;
            btnPreviousPage.Click += BtnPreviousPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
            btnLastPage.Click += BtnLastPage_Click;

            dgvDogs.CellClick += DgvDogs_CellClick;

            ClearDogInformation();
            LoadDogs();
        }

        private void ConfigureGrid()
        {
            dgvDogs.EnableHeadersVisualStyles = false;
            dgvDogs.AutoGenerateColumns = false;

            dgvDogs.BackgroundColor =
                Color.FromArgb(12, 28, 55);

            dgvDogs.BorderStyle =
                BorderStyle.None;

            dgvDogs.GridColor =
                Color.FromArgb(45, 65, 100);

            dgvDogs.RowHeadersVisible = false;

            dgvDogs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDogs.MultiSelect = false;
            dgvDogs.ReadOnly = true;

            dgvDogs.AllowUserToAddRows = false;
            dgvDogs.AllowUserToDeleteRows = false;
            dgvDogs.AllowUserToResizeRows = false;
            dgvDogs.AllowUserToResizeColumns = false;

            dgvDogs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDogs.ColumnHeadersHeight = 42;
            dgvDogs.RowTemplate.Height = 34;

            dgvDogs.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(25, 45, 80);

            dgvDogs.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(212, 160, 23);

            dgvDogs.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvDogs.DefaultCellStyle.BackColor =
                Color.FromArgb(18, 38, 74);

            dgvDogs.DefaultCellStyle.ForeColor =
                Color.White;

            dgvDogs.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(28, 48, 84);

            dgvDogs.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvDogs.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            dgvDogs.Columns.Clear();

            DataGridViewTextBoxColumn stampColumn =
                new DataGridViewTextBoxColumn();

            stampColumn.Name = "StampNumber";
            stampColumn.HeaderText = "№ клейма";
            stampColumn.FillWeight = 13;

            dgvDogs.Columns.Add(stampColumn);

            DataGridViewTextBoxColumn nameColumn =
                new DataGridViewTextBoxColumn();

            nameColumn.Name = "DogName";
            nameColumn.HeaderText = "Кличка";
            nameColumn.FillWeight = 14;

            dgvDogs.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn birthColumn =
                new DataGridViewTextBoxColumn();

            birthColumn.Name = "BirthDate";
            birthColumn.HeaderText = "Дата рождения";
            birthColumn.FillWeight = 16;

            dgvDogs.Columns.Add(birthColumn);

            DataGridViewTextBoxColumn sexColumn =
                new DataGridViewTextBoxColumn();

            sexColumn.Name = "Sex";
            sexColumn.HeaderText = "Пол";
            sexColumn.FillWeight = 9;

            dgvDogs.Columns.Add(sexColumn);

            DataGridViewTextBoxColumn breedColumn =
                new DataGridViewTextBoxColumn();

            breedColumn.Name = "Breed";
            breedColumn.HeaderText = "Порода";
            breedColumn.FillWeight = 17;

            dgvDogs.Columns.Add(breedColumn);

            DataGridViewTextBoxColumn statusColumn =
                new DataGridViewTextBoxColumn();

            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Статус";
            statusColumn.FillWeight = 14;

            dgvDogs.Columns.Add(statusColumn);

            DataGridViewTextBoxColumn employeeColumn =
                new DataGridViewTextBoxColumn();

            employeeColumn.Name = "Employee";
            employeeColumn.HeaderText = "Закреплён за";
            employeeColumn.FillWeight = 17;

            dgvDogs.Columns.Add(employeeColumn);
        }

        private void LoadDogs()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    //--------------------------------------------------
                    // ОБЩЕЕ КОЛИЧЕСТВО ЗАПИСЕЙ С УЧЁТОМ ФИЛЬТРОВ
                    //--------------------------------------------------

                    string countQuery = @"
                        SELECT COUNT(*)
                        FROM Service_dog sd
                        INNER JOIN Employee e
                            ON sd.employee_id = e.employee_id
                        INNER JOIN Post p
                            ON e.post_id = p.post_id
                    ";

                    using (NpgsqlCommand countCommand =
                        new NpgsqlCommand(
                            countQuery,
                            connection))
                    {
                        string whereClause =
                            BuildDogFilter(countCommand);

                        countCommand.CommandText +=
                            whereClause;

                        totalRecords =
                            Convert.ToInt32(
                                countCommand.ExecuteScalar());
                    }

                    //--------------------------------------------------
                    // КОЛИЧЕСТВО СТРАНИЦ
                    //--------------------------------------------------

                    totalPages =
                        Math.Max(
                            1,
                            (int)Math.Ceiling(
                                (double)totalRecords /
                                PageSize));

                    if (currentPage > totalPages)
                    {
                        currentPage = totalPages;
                    }

                    //--------------------------------------------------
                    // ПОЛУЧЕНИЕ СОБАК
                    //--------------------------------------------------

                    string query = @"
                        SELECT
                            sd.service_dog_id AS ""Id"",
                            sd.stamp_number AS ""№ клейма"",
                            sd.dog_name AS ""Кличка"",
                            sd.date_of_birth AS ""Дата рождения"",
                            s.sex_name AS ""Пол"",
                            b.breed_name AS ""Порода"",
                            ds.dog_status_name AS ""Статус"",
                            sp.specialization_name AS ""Специализация"",
                            CONCAT_WS(
                                ' ',
                                e.last_name,
                                e.name_,
                                e.middle_name
                            ) AS ""Закреплён за"",
                            sd.health AS ""Здоровье""
                        FROM Service_dog sd
                        INNER JOIN Sex s
                            ON sd.sex_id = s.sex_id
                        INNER JOIN Breed b
                            ON sd.breed_id = b.breed_id
                        INNER JOIN Dog_status ds
                            ON sd.dog_status_id =
                               ds.dog_status_id
                        INNER JOIN Specialization sp
                            ON sd.specialization_id =
                               sp.specialization_id
                        INNER JOIN Employee e
                            ON sd.employee_id =
                               e.employee_id
                        INNER JOIN Post p
                            ON e.post_id =
                               p.post_id
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        //--------------------------------------------------
                        // ФИЛЬТРЫ
                        //--------------------------------------------------

                        string whereClause =
                            BuildDogFilter(command);

                        command.CommandText +=
                            whereClause;

                        //--------------------------------------------------
                        // СОРТИРОВКА
                        //--------------------------------------------------

                        command.CommandText += @"
                            ORDER BY
                                sd.dog_name
                        ";

                        //--------------------------------------------------
                        // ПАГИНАЦИЯ
                        //--------------------------------------------------

                        int offset =
                            (currentPage - 1) *
                            PageSize;

                        command.CommandText += @"
                            LIMIT @limit
                            OFFSET @offset;
                        ";

                        command.Parameters.AddWithValue(
                            "@limit",
                            PageSize);

                        command.Parameters.AddWithValue(
                            "@offset",
                            offset);

                        //--------------------------------------------------
                        // ЗАГРУЗКА ТАБЛИЦЫ
                        //--------------------------------------------------

                        using (NpgsqlDataAdapter adapter =
                            new NpgsqlDataAdapter(command))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvDogs.Rows.Clear();

                            foreach (DataRow row in table.Rows)
                            {
                                int rowIndex =
                                    dgvDogs.Rows.Add(
                                        row["№ клейма"]
                                            .ToString()
                                            .Trim(),

                                        row["Кличка"],

                                        Convert.ToDateTime(
                                            row["Дата рождения"])
                                            .ToString("dd.MM.yyyy"),

                                        row["Пол"]
                                            .ToString()
                                            .Trim(),

                                        row["Порода"],

                                        row["Статус"],

                                        row["Закреплён за"]);

                                dgvDogs.Rows[rowIndex].Tag =
                                    Convert.ToInt32(
                                        row["Id"]);
                            }
                        }
                    }
                }

                UpdatePagination();

                //--------------------------------------------------
                // ВЫБИРАЕМ ПЕРВУЮ СОБАКУ НА СТРАНИЦЕ
                //--------------------------------------------------

                if (dgvDogs.Rows.Count > 0)
                {
                    dgvDogs.Rows[0].Selected = true;

                    dgvDogs.CurrentCell =
                        dgvDogs.Rows[0].Cells[0];

                    object value =
                        dgvDogs.Rows[0].Tag;

                    if (value != null &&
                        int.TryParse(
                            value.ToString(),
                            out int dogId))
                    {
                        selectedDogId = dogId;
                        LoadDogInformation(selectedDogId);
                    }
                }
                else
                {
                    ClearDogInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить служебных собак.\n\n" +
                    ex.Message,
                    "Ошибка загрузки служебных собак",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStampNumbers()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT DISTINCT
                            TRIM(stamp_number) AS stamp_number
                        FROM Service_dog
                        ORDER BY stamp_number;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbSearchStamp.Items.Clear();
                        cmbSearchStamp.Items.Add("Все");

                        while (reader.Read())
                        {
                            cmbSearchStamp.Items.Add(
                                reader["stamp_number"].ToString());
                        }

                        cmbSearchStamp.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить номера клейм.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string BuildDogFilter(
            NpgsqlCommand command)
        {
            List<string> conditions =
                new List<string>();

            //--------------------------------------------------
            // КЛИЧКА
            //--------------------------------------------------

            if (!string.IsNullOrWhiteSpace(
                txtSearchName.Text))
            {
                conditions.Add(
                    "sd.dog_name ILIKE @dog_name");

                command.Parameters.AddWithValue(
                    "@dog_name",
                    "%" +
                    txtSearchName.Text.Trim() +
                    "%");
            }

            //--------------------------------------------------
            // НОМЕР КЛЕЙМА
            //--------------------------------------------------

            if (cmbSearchStamp.SelectedIndex > 0 &&
                cmbSearchStamp.SelectedItem != null)
            {
                conditions.Add(
                    "TRIM(sd.stamp_number) = @stamp");

                command.Parameters.AddWithValue(
                    "@stamp",
                    cmbSearchStamp.SelectedItem.ToString().Trim());
            }

            if (conditions.Count == 0)
            {
                return string.Empty;
            }

            return
                "WHERE " +
                string.Join(
                    " AND ",
                    conditions) +
                "\n";
        }

        private void UpdatePagination()
        {
            if (totalRecords == 0)
            {
                lblPageInfo.Text =
                    "Нет записей";
            }
            else
            {
                int firstRecord =
                    ((currentPage - 1) * PageSize) + 1;

                int lastRecord =
                    Math.Min(
                        currentPage * PageSize,
                        totalRecords);

                lblPageInfo.Text =
                    $"{firstRecord}-{lastRecord} из {totalRecords}";
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

        private void BtnFirstPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage == 1)
            {
                return;
            }

            currentPage = 1;
            LoadDogs();
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
            LoadDogs();
        }

        private void BtnNextPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage >= totalPages)
            {
                return;
            }

            currentPage++;
            LoadDogs();
        }

        private void BtnLastPage_Click(
            object sender,
            EventArgs e)
        {
            if (currentPage == totalPages)
            {
                return;
            }

            currentPage = totalPages;
            LoadDogs();
        }

        private void DgvDogs_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            object value =
                dgvDogs.Rows[e.RowIndex].Tag;

            if (value == null)
            {
                return;
            }

            if (!int.TryParse(
                value.ToString(),
                out int dogId))
            {
                return;
            }

            selectedDogId = dogId;

            LoadDogInformation(selectedDogId);
        }

        private void LoadDogInformation(
            int dogId)
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            sd.stamp_number,
                            sd.dog_name,
                            sd.date_of_birth,
                            s.sex_name,
                            b.breed_name,
                            ds.dog_status_name,
                            sp.specialization_name,
                            CONCAT_WS(
                                ' ',
                                e.last_name,
                                e.name_,
                                e.middle_name
                            ) AS employee_name,
                            sd.health
                        FROM Service_dog sd
                        INNER JOIN Sex s
                            ON sd.sex_id = s.sex_id
                        INNER JOIN Breed b
                            ON sd.breed_id = b.breed_id
                        INNER JOIN Dog_status ds
                            ON sd.dog_status_id =
                               ds.dog_status_id
                        INNER JOIN Specialization sp
                            ON sd.specialization_id =
                               sp.specialization_id
                        INNER JOIN Employee e
                            ON sd.employee_id =
                               e.employee_id
                        WHERE sd.service_dog_id = @id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            dogId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ClearDogInformation();
                                return;
                            }

                            lblStampValue.Text =
                                reader["stamp_number"]
                                    .ToString()
                                    .Trim();

                            lblNameValue.Text =
                                reader["dog_name"]
                                    .ToString();

                            lblBreedValue.Text =
                                reader["breed_name"]
                                    .ToString();

                            lblSexValue.Text =
                                reader["sex_name"]
                                    .ToString()
                                    .Trim();

                            lblStatusValue.Text =
                                reader["dog_status_name"]
                                    .ToString();

                            lblSpecializationValue.Text =
                                reader["specialization_name"]
                                    .ToString();

                            lblEmployeeValue.Text =
                                reader["employee_name"]
                                    .ToString();

                            lblBirthValue.Text =
                                Convert.ToDateTime(
                                    reader["date_of_birth"])
                                    .ToString("dd.MM.yyyy");

                            lblHealthValue.Text =
                                reader["health"]
                                    .ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить информацию о собаке.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearDogInformation()
        {
            selectedDogId = 0;

            lblStampValue.Text = "—";
            lblNameValue.Text = "—";
            lblBreedValue.Text = "—";
            lblSexValue.Text = "—";
            lblStatusValue.Text = "—";
            lblSpecializationValue.Text = "—";
            lblEmployeeValue.Text = "—";
            lblBirthValue.Text = "—";
            lblHealthValue.Text = "—";

        }

        private void BtnSearch_Click(
            object sender,
            EventArgs e)
        {
            currentPage = 1;
            LoadDogs();
        }

        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {
            cmbSearchStamp.SelectedIndex = 0;
            txtSearchName.Clear();

            currentPage = 1;

            LoadDogs();
        }

        private void BtnAddDog_Click(
            object sender,
            EventArgs e)
        {
            using (ServiceDogEditForm form =
                new ServiceDogEditForm())
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    currentPage = 1;
                    LoadStampNumbers();
                    LoadDogs();
                }
            }
        }

        private void BtnEditDog_Click(
            object sender,
            EventArgs e)
        {
            if (selectedDogId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите служебную собаку.",
                    "Редактирование",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (ServiceDogEditForm form =
                new ServiceDogEditForm(selectedDogId))
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadStampNumbers();
                    LoadDogs();
                }
            }
        }

        private void BtnAssignDog_Click(
            object sender,
            EventArgs e)
        {
            if (selectedDogId <= 0)
            {
                MessageBox.Show(
                    "Сначала выберите служебную собаку.",
                    "Закрепление за сотрудником",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (AssignDogForm form =
                new AssignDogForm(selectedDogId))
            {
                if (form.ShowDialog(
                    this.FindForm()) ==
                    DialogResult.OK)
                {
                    LoadStampNumbers();
                    LoadDogs();
                }
            }
        }
    }
}
