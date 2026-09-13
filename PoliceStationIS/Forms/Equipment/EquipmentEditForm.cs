using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Equipment
{
    public partial class EquipmentEditForm : Form
    {
        private readonly int equipmentId;
        private readonly bool editMode;

        public EquipmentEditForm()
        {
            InitializeComponent();

            equipmentId = 0;
            editMode = false;

            ConfigureForm();
            LoadCategories();
            LoadStatuses();
            LoadEmployees();

            dtpIssueDate.Value = DateTime.Today;
            Text = "Добавление имущества";
            lblTitle.Text = "Добавление имущества";
        }

        public EquipmentEditForm(int id)
        {
            InitializeComponent();

            equipmentId = id;
            editMode = true;

            ConfigureForm();
            LoadCategories();
            LoadStatuses();
            LoadEmployees();
            LoadEquipmentData();

            Text = "Редактирование имущества";
            lblTitle.Text = "Редактирование имущества";
        }

        private void ConfigureForm()
        {
            ConfigureComboBox(cmbCategory);
            ConfigureComboBox(cmbStatus);
            ConfigureComboBox(cmbEmployee);

            dtpIssueDate.Format = DateTimePickerFormat.Short;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.FromArgb(30, 58, 117);
            comboBox.ForeColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 9F);
        }

        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add(
                    new EquipmentComboBoxItem
                    {
                        Id = 0,
                        Name = "Выберите категорию"
                    });

                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT equipment_category_id,
                               equipment_category_name
                        FROM equipment_category
                        ORDER BY equipment_category_name;";

                    using (NpgsqlCommand command =
                           new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(
                                new EquipmentComboBoxItem
                                {
                                    Id = Convert.ToInt32(
                                        reader["equipment_category_id"]),
                                    Name = reader["equipment_category_name"]
                                        .ToString()
                                });
                        }
                    }
                }

                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowError(
                    "Не удалось загрузить категории имущества.",
                    ex);
            }
        }

        private void LoadStatuses()
        {
            try
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add(
                    new EquipmentComboBoxItem
                    {
                        Id = 0,
                        Name = "Выберите статус"
                    });

                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT equipment_status_id,
                               equipment_status_name
                        FROM equipment_status
                        ORDER BY equipment_status_name;";

                    using (NpgsqlCommand command =
                           new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbStatus.Items.Add(
                                new EquipmentComboBoxItem
                                {
                                    Id = Convert.ToInt32(
                                        reader["equipment_status_id"]),
                                    Name = reader["equipment_status_name"]
                                        .ToString()
                                });
                        }
                    }
                }

                cmbStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowError(
                    "Не удалось загрузить статусы имущества.",
                    ex);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                cmbEmployee.Items.Clear();
                cmbEmployee.Items.Add(
                    new EquipmentComboBoxItem
                    {
                        Id = 0,
                        Name = "Выберите сотрудника"
                    });

                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            employee_id,
                            CONCAT(
                                last_name, ' ',
                                name_, ' ',
                                COALESCE(middle_name, '')
                            ) AS full_name
                        FROM employee
                        ORDER BY last_name, name_, middle_name;";

                    using (NpgsqlCommand command =
                           new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbEmployee.Items.Add(
                                new EquipmentComboBoxItem
                                {
                                    Id = Convert.ToInt32(
                                        reader["employee_id"]),
                                    Name = reader["full_name"].ToString()
                                });
                        }
                    }
                }

                cmbEmployee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowError(
                    "Не удалось загрузить список сотрудников.",
                    ex);
            }
        }

        private void LoadEquipmentData()
        {
            try
            {
                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            equipment_name,
                            equipment_category_id,
                            equipment_status_id,
                            employee_id,
                            equipment_date_of_issue
                        FROM equipment
                        WHERE equipment_id = @equipment_id;";

                    using (NpgsqlCommand command =
                           new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@equipment_id",
                            equipmentId);

                        using (NpgsqlDataReader reader =
                               command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Имущество не найдено.",
                                    "Редактирование",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            txtEquipmentName.Text =
                                reader["equipment_name"].ToString();

                            SelectComboItem(
                                cmbCategory,
                                Convert.ToInt32(
                                    reader["equipment_category_id"]));

                            SelectComboItem(
                                cmbStatus,
                                Convert.ToInt32(
                                    reader["equipment_status_id"]));

                            SelectComboItem(
                                cmbEmployee,
                                Convert.ToInt32(
                                    reader["employee_id"]));

                            if (reader["equipment_date_of_issue"] !=
                                DBNull.Value)
                            {
                                dtpIssueDate.Value =
                                    Convert.ToDateTime(
                                        reader["equipment_date_of_issue"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(
                    "Не удалось загрузить данные имущества.",
                    ex);
            }
        }

        private void SelectComboItem(
            ComboBox comboBox,
            int id)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                EquipmentComboBoxItem item =
                    comboBox.Items[i] as EquipmentComboBoxItem;

                if (item != null && item.Id == id)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            comboBox.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string equipmentName =
                txtEquipmentName.Text.Trim();

            EquipmentComboBoxItem category =
                cmbCategory.SelectedItem as EquipmentComboBoxItem;

            EquipmentComboBoxItem status =
                cmbStatus.SelectedItem as EquipmentComboBoxItem;

            EquipmentComboBoxItem employee =
                cmbEmployee.SelectedItem as EquipmentComboBoxItem;

            if (string.IsNullOrWhiteSpace(equipmentName))
            {
                MessageBox.Show(
                    "Введите наименование имущества.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEquipmentName.Focus();
                return;
            }

            if (equipmentName.Length > 50)
            {
                MessageBox.Show(
                    "Наименование имущества не должно превышать 50 символов.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEquipmentName.Focus();
                return;
            }

            if (category == null || category.Id == 0)
            {
                MessageBox.Show(
                    "Выберите категорию имущества.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategory.Focus();
                return;
            }

            if (status == null || status.Id == 0)
            {
                MessageBox.Show(
                    "Выберите статус имущества.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return;
            }

            if (employee == null || employee.Id == 0)
            {
                MessageBox.Show(
                    "Выберите сотрудника, за которым закреплено имущество.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEmployee.Focus();
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                       DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    if (editMode)
                    {
                        UpdateEquipment(
                            connection,
                            equipmentName,
                            category.Id,
                            status.Id,
                            employee.Id);
                    }
                    else
                    {
                        AddEquipment(
                            connection,
                            equipmentName,
                            category.Id,
                            status.Id,
                            employee.Id);
                    }
                }

                MessageBox.Show(
                    editMode
                        ? "Данные имущества успешно изменены."
                        : "Имущество успешно добавлено.",
                    editMode ? "Редактирование" : "Добавление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить имущество.\n\n" +
                    ex.MessageText,
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowError(
                    "Не удалось сохранить имущество.",
                    ex);
            }
        }

        private void AddEquipment(
            NpgsqlConnection connection,
            string equipmentName,
            int categoryId,
            int statusId,
            int employeeId)
        {
            const string query = @"
                INSERT INTO equipment
                (
                    employee_id,
                    equipment_category_id,
                    equipment_status_id,
                    equipment_name,
                    equipment_date_of_issue
                )
                VALUES
                (
                    @employee_id,
                    @category_id,
                    @status_id,
                    @equipment_name,
                    @issue_date
                );";

            using (NpgsqlCommand command =
                   new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@employee_id",
                    employeeId);

                command.Parameters.AddWithValue(
                    "@category_id",
                    categoryId);

                command.Parameters.AddWithValue(
                    "@status_id",
                    statusId);

                command.Parameters.AddWithValue(
                    "@equipment_name",
                    equipmentName);

                command.Parameters.AddWithValue(
                    "@issue_date",
                    dtpIssueDate.Value.Date);

                command.ExecuteNonQuery();
            }
        }

        private void UpdateEquipment(
            NpgsqlConnection connection,
            string equipmentName,
            int categoryId,
            int statusId,
            int employeeId)
        {
            const string query = @"
                UPDATE equipment
                SET
                    employee_id = @employee_id,
                    equipment_category_id = @category_id,
                    equipment_status_id = @status_id,
                    equipment_name = @equipment_name,
                    equipment_date_of_issue = @issue_date
                WHERE equipment_id = @equipment_id;";

            using (NpgsqlCommand command =
                   new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@employee_id",
                    employeeId);

                command.Parameters.AddWithValue(
                    "@category_id",
                    categoryId);

                command.Parameters.AddWithValue(
                    "@status_id",
                    statusId);

                command.Parameters.AddWithValue(
                    "@equipment_name",
                    equipmentName);

                command.Parameters.AddWithValue(
                    "@issue_date",
                    dtpIssueDate.Value.Date);

                command.Parameters.AddWithValue(
                    "@equipment_id",
                    equipmentId);

                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception(
                        "Имущество не найдено или уже было удалено.");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                message + "\n\n" + ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private sealed class EquipmentComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}