using Npgsql;
using PoliceStationIS.Controls;
using PoliceStationIS.Database;
using PoliceStationIS.Forms.Squads;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Expertises
{
    public partial class ExpertiseEditForm : Form
    {
        private readonly int expertiseId;
        private readonly bool isEditMode;

        private byte[] selectedFileBytes;
        private string selectedFileName;
        private bool existingFile;

        public ExpertiseEditForm()
        {
            InitializeComponent();

            expertiseId = 0;
            isEditMode = false;

            ConfigureForm();
            LoadReferenceData();
        }

        public ExpertiseEditForm(int id)
        {
            InitializeComponent();

            expertiseId = id;
            isEditMode = true;

            ConfigureForm();
            LoadReferenceData();
            LoadExpertiseData();
        }

        private void ConfigureForm()
        {
            Text = isEditMode
                ? "Редактирование экспертизы"
                : "Добавление экспертизы";

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSelectFile.Click += BtnSelectFile_Click;
            btnClearFile.Click += BtnClearFile_Click;

            ConfigureComboBox(cmbEmployee);
            ConfigureComboBox(cmbExpertiseType);
            ConfigureComboBox(cmbStatus);
            ConfigureComboBox(cmbProtocol);

            dtAppointmentDate.Format = DateTimePickerFormat.Short;
            dtResearchStartDate.Format = DateTimePickerFormat.Short;
            dtResearchEndDate.Format = DateTimePickerFormat.Short;

            dtResearchEndDate.ShowCheckBox = true;
            dtResearchEndDate.Checked = false;

            txtConclusion.Multiline = true;
            txtConclusion.ScrollBars = ScrollBars.Vertical;

            lblFileName.Text = "Файл не выбран";
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.FromArgb(30, 58, 117);
            comboBox.ForeColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 9F);
        }

        private void LoadReferenceData()
        {
            try
            {
                LoadEmployees();
                LoadExpertiseTypes();
                LoadStatuses();
                LoadProtocols();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники экспертизы.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        private void LoadEmployees()
        {
            cmbEmployee.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        employee_id,
                        last_name || ' ' ||
                        name_ ||
                        CASE
                            WHEN middle_name IS NULL
                            THEN ''
                            ELSE ' ' || middle_name
                        END AS employee_name
                    FROM employee
                    ORDER BY last_name, name_;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbEmployee.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["employee_id"]),
                                Name = reader["employee_name"].ToString()
                            });
                    }
                }
            }

            cmbEmployee.SelectedIndex = -1;
        }

        private void LoadExpertiseTypes()
        {
            cmbExpertiseType.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        inspection_type_id,
                        inspection_type_name
                    FROM inspection_type
                    ORDER BY inspection_type_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbExpertiseType.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["inspection_type_id"]),
                                Name = reader["inspection_type_name"].ToString()
                            });
                    }
                }
            }

            cmbExpertiseType.SelectedIndex = -1;
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        inspection_status_id,
                        inspection_status_name
                    FROM inspection_status
                    ORDER BY inspection_status_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbStatus.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["inspection_status_id"]),
                                Name = reader["inspection_status_name"].ToString()
                            });
                    }
                }
            }

            cmbStatus.SelectedIndex = -1;
        }

        private void LoadProtocols()
        {
            cmbProtocol.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_id,
                        TRIM(protocol_number) AS protocol_number
                    FROM protocol
                    ORDER BY protocol_number;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbProtocol.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["protocol_id"]),
                                Name = reader["protocol_number"].ToString()
                            });
                    }
                }
            }

            cmbProtocol.SelectedIndex = -1;
        }

        private void LoadExpertiseData()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"
                        SELECT
                            inspection_id,
                            employee_id,
                            inspection_type_id,
                            inspection_status_id,
                            protocol_id,
                            TRIM(inspection_number) AS inspection_number,
                            appointment_date,
                            research_start_date,
                            research_end_date,
                            conclusion,
                            inspection_file
                        FROM inspection
                        WHERE inspection_id = @inspection_id;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@inspection_id",
                            expertiseId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Экспертиза не найдена.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            txtExpertiseNumber.Text =
                                reader["inspection_number"].ToString();

                            SetComboBoxValue(
                                cmbEmployee,
                                Convert.ToInt32(
                                    reader["employee_id"]));

                            SetComboBoxValue(
                                cmbExpertiseType,
                                Convert.ToInt32(
                                    reader["inspection_type_id"]));

                            SetComboBoxValue(
                                cmbStatus,
                                Convert.ToInt32(
                                    reader["inspection_status_id"]));

                            SetComboBoxValue(
                                cmbProtocol,
                                Convert.ToInt32(
                                    reader["protocol_id"]));

                            dtAppointmentDate.Value =
                                Convert.ToDateTime(
                                    reader["appointment_date"]);

                            dtResearchStartDate.Value =
                                Convert.ToDateTime(
                                    reader["research_start_date"]);

                            if (reader["research_end_date"] ==
                                DBNull.Value)
                            {
                                dtResearchEndDate.Checked = false;
                            }
                            else
                            {
                                dtResearchEndDate.Value =
                                    Convert.ToDateTime(
                                        reader["research_end_date"]);

                                dtResearchEndDate.Checked = true;
                            }

                            txtConclusion.Text =
                                reader["conclusion"] ==
                                DBNull.Value
                                ? string.Empty
                                : reader["conclusion"].ToString();

                            if (reader["inspection_file"] ==
                                DBNull.Value)
                            {
                                existingFile = false;
                                selectedFileBytes = null;
                                selectedFileName = null;
                                lblFileName.Text = "Файл не прикреплён";
                            }
                            else
                            {
                                existingFile = true;
                                selectedFileBytes = null;
                                selectedFileName = null;
                                lblFileName.Text =
                                    "Файл уже прикреплён";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные экспертизы.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void SetComboBoxValue(
            ComboBox comboBox,
            int id)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                ComboBoxItem item =
                    comboBox.Items[i] as ComboBoxItem;

                if (item != null &&
                    item.Id == id)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            comboBox.SelectedIndex = -1;
        }

        private void BtnSelectFile_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog dialog =
                new OpenFileDialog())
            {
                dialog.Title = "Выберите файл экспертизы";
                dialog.Filter =
                    "Все файлы (*.*)|*.*|" +
                    "PDF (*.pdf)|*.pdf|" +
                    "Документы Word (*.doc;*.docx)|*.doc;*.docx|" +
                    "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog(this) !=
                    DialogResult.OK)
                {
                    return;
                }

                try
                {
                    selectedFileBytes =
                        File.ReadAllBytes(dialog.FileName);

                    selectedFileName =
                        Path.GetFileName(dialog.FileName);

                    lblFileName.Text =
                        selectedFileName;

                    existingFile = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось загрузить выбранный файл.\n\n" +
                        ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClearFile_Click(
            object sender,
            EventArgs e)
        {
            if (!isEditMode)
            {
                selectedFileBytes = null;
                selectedFileName = null;
                existingFile = false;
                lblFileName.Text = "Файл не выбран";
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Удалить прикреплённый файл из экспертизы?",
                    "Файл экспертизы",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                selectedFileBytes = null;
                selectedFileName = null;
                existingFile = false;
                lblFileName.Text = "Файл будет удалён";
            }
        }

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                if (isEditMode)
                    UpdateExpertise();
                else
                    AddExpertise();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Экспертиза с таким номером уже существует.\n" +
                        "Введите другой номер экспертизы.",
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Ошибка PostgreSQL:\n\n" +
                        ex.Message,
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить экспертизу.\n\n" +
                    ex.Message,
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            string number =
                txtExpertiseNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(number))
            {
                ShowValidation("Введите номер экспертизы.");
                txtExpertiseNumber.Focus();
                return false;
            }

            if (number.Length > 5)
            {
                ShowValidation(
                    "Номер экспертизы должен содержать не более 5 символов.");
                txtExpertiseNumber.Focus();
                return false;
            }

            if (cmbEmployee.SelectedItem == null)
            {
                ShowValidation("Выберите сотрудника.");
                cmbEmployee.Focus();
                return false;
            }

            if (cmbExpertiseType.SelectedItem == null)
            {
                ShowValidation("Выберите тип экспертизы.");
                cmbExpertiseType.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                ShowValidation("Выберите статус экспертизы.");
                cmbStatus.Focus();
                return false;
            }

            if (cmbProtocol.SelectedItem == null)
            {
                ShowValidation("Выберите протокол.");
                cmbProtocol.Focus();
                return false;
            }

            if (dtResearchStartDate.Value.Date <
                dtAppointmentDate.Value.Date)
            {
                ShowValidation(
                    "Дата начала исследования не может быть раньше даты назначения.");
                dtResearchStartDate.Focus();
                return false;
            }

            if (dtResearchEndDate.Checked &&
                dtResearchEndDate.Value.Date <
                dtResearchStartDate.Value.Date)
            {
                ShowValidation(
                    "Дата окончания исследования не может быть раньше даты его начала.");
                dtResearchEndDate.Focus();
                return false;
            }

            return true;
        }

        private void ShowValidation(string message)
        {
            MessageBox.Show(
                message,
                "Проверка данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void AddExpertise()
        {
            ComboBoxItem employee =
                cmbEmployee.SelectedItem as ComboBoxItem;

            ComboBoxItem type =
                cmbExpertiseType.SelectedItem as ComboBoxItem;

            ComboBoxItem status =
                cmbStatus.SelectedItem as ComboBoxItem;

            ComboBoxItem protocol =
                cmbProtocol.SelectedItem as ComboBoxItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    INSERT INTO inspection
                    (
                        employee_id,
                        inspection_type_id,
                        inspection_status_id,
                        protocol_id,
                        inspection_number,
                        appointment_date,
                        research_start_date,
                        research_end_date,
                        conclusion,
                        inspection_file
                    )
                    VALUES
                    (
                        @employee_id,
                        @inspection_type_id,
                        @inspection_status_id,
                        @protocol_id,
                        @inspection_number,
                        @appointment_date,
                        @research_start_date,
                        @research_end_date,
                        @conclusion,
                        @inspection_file
                    );
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    AddParameters(command,
                        employee.Id,
                        type.Id,
                        status.Id,
                        protocol.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateExpertise()
        {
            ComboBoxItem employee =
                cmbEmployee.SelectedItem as ComboBoxItem;

            ComboBoxItem type =
                cmbExpertiseType.SelectedItem as ComboBoxItem;

            ComboBoxItem status =
                cmbStatus.SelectedItem as ComboBoxItem;

            ComboBoxItem protocol =
                cmbProtocol.SelectedItem as ComboBoxItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    UPDATE inspection
                    SET
                        employee_id = @employee_id,
                        inspection_type_id = @inspection_type_id,
                        inspection_status_id = @inspection_status_id,
                        protocol_id = @protocol_id,
                        inspection_number = @inspection_number,
                        appointment_date = @appointment_date,
                        research_start_date = @research_start_date,
                        research_end_date = @research_end_date,
                        conclusion = @conclusion,
                        inspection_file = @inspection_file
                    WHERE inspection_id = @inspection_id;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    AddParameters(command,
                        employee.Id,
                        type.Id,
                        status.Id,
                        protocol.Id);

                    command.Parameters.AddWithValue(
                        "@inspection_id",
                        expertiseId);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddParameters(
            NpgsqlCommand command,
            int employeeId,
            int typeId,
            int statusId,
            int protocolId)
        {
            command.Parameters.AddWithValue(
                "@employee_id",
                employeeId);

            command.Parameters.AddWithValue(
                "@inspection_type_id",
                typeId);

            command.Parameters.AddWithValue(
                "@inspection_status_id",
                statusId);

            command.Parameters.AddWithValue(
                "@protocol_id",
                protocolId);

            command.Parameters.AddWithValue(
                "@inspection_number",
                txtExpertiseNumber.Text.Trim());

            command.Parameters.AddWithValue(
                "@appointment_date",
                dtAppointmentDate.Value.Date);

            command.Parameters.AddWithValue(
                "@research_start_date",
                dtResearchStartDate.Value.Date);

            if (dtResearchEndDate.Checked)
            {
                command.Parameters.AddWithValue(
                    "@research_end_date",
                    dtResearchEndDate.Value.Date);
            }
            else
            {
                command.Parameters.AddWithValue(
                    "@research_end_date",
                    DBNull.Value);
            }

            if (string.IsNullOrWhiteSpace(
                txtConclusion.Text))
            {
                command.Parameters.AddWithValue(
                    "@conclusion",
                    DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue(
                    "@conclusion",
                    txtConclusion.Text.Trim());
            }

            if (selectedFileBytes != null)
            {
                command.Parameters.Add(
                    "@inspection_file",
                    NpgsqlTypes.NpgsqlDbType.Bytea)
                    .Value = selectedFileBytes;
            }
            else if (isEditMode && existingFile)
            {
                command.Parameters.Add(
                    "@inspection_file",
                    NpgsqlTypes.NpgsqlDbType.Bytea)
                    .Value = GetExistingFile();
            }
            else
            {
                command.Parameters.AddWithValue(
                    "@inspection_file",
                    DBNull.Value);
            }
        }

        private byte[] GetExistingFile()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT inspection_file
                    FROM inspection
                    WHERE inspection_id = @inspection_id;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@inspection_id",
                        expertiseId);

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

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}