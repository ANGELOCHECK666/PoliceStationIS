using Npgsql;
using PoliceStationIS.Database;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PoliceStationIS.Forms.Equipment
{
    public partial class CreateIssueRequestForm : Form
    {
        private class ComboItem
        {
            public int Id { get; }
            public string Text { get; }

            public ComboItem(int id, string text)
            {
                Id = id;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        public CreateIssueRequestForm()
        {
            InitializeComponent();

            ConfigureControls();
            ConfigureEvents();

            LoadEmployees();
            LoadCategories();
        }

        private void ConfigureControls()
        {
            ConfigureComboBox(cmbEmployee);
            ConfigureComboBox(cmbCategory);
            ConfigureComboBox(cmbEquipment);

            txtComment.Multiline = true;
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.MaxLength = 1000;

            dtpRequestDate.Format = DateTimePickerFormat.Short;
            dtpRequestDate.Value = DateTime.Today;
            dtpRequestDate.Enabled = false;

            btnCreate.Enabled = false;
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.BackColor = Color.FromArgb(30, 58, 117);
            comboBox.ForeColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = new Font("Segoe UI", 9F);
        }

        private void ConfigureEvents()
        {
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            cmbEmployee.SelectedIndexChanged += SelectionChanged;
            cmbEquipment.SelectedIndexChanged += SelectionChanged;

            btnCreate.Click += BtnCreate_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadEmployees()
        {
            try
            {
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
                        ORDER BY last_name, name_;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbEmployee.Items.Clear();

                        while (reader.Read())
                        {
                            cmbEmployee.Items.Add(
                                new ComboItem(
                                    Convert.ToInt32(
                                        reader["employee_id"]),
                                    reader["full_name"].ToString()));
                        }
                    }
                }

                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить список сотрудников.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            equipment_category_id,
                            equipment_category_name
                        FROM equipment_category
                        ORDER BY equipment_category_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        cmbCategory.Items.Clear();

                        while (reader.Read())
                        {
                            cmbCategory.Items.Add(
                                new ComboItem(
                                    Convert.ToInt32(
                                        reader["equipment_category_id"]),
                                    reader["equipment_category_name"].ToString()));
                        }
                    }
                }

                cmbCategory.SelectedIndex = -1;
                cmbEquipment.Items.Clear();
                cmbEquipment.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить категории имущества.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadEquipment()
        {
            cmbEquipment.Items.Clear();
            cmbEquipment.Enabled = false;

            ComboItem category =
                cmbCategory.SelectedItem as ComboItem;

            if (category == null)
            {
                UpdateCreateButtonState();
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        SELECT
                            e.equipment_id,
                            e.equipment_name
                        FROM equipment e
                        INNER JOIN equipment_status s
                            ON s.equipment_status_id =
                               e.equipment_status_id
                        WHERE e.employee_id IS NULL
                          AND e.equipment_category_id = @category_id
                          AND s.equipment_status_name = 'Исправно'
                        ORDER BY e.equipment_name;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@category_id",
                            category.Id);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEquipment.Items.Add(
                                    new ComboItem(
                                        Convert.ToInt32(
                                            reader["equipment_id"]),
                                        reader["equipment_name"].ToString()));
                            }
                        }
                    }
                }

                cmbEquipment.Enabled =
                    cmbEquipment.Items.Count > 0;

                cmbEquipment.SelectedIndex = -1;

                if (cmbEquipment.Items.Count == 0)
                {
                    lblEquipmentHint.Text =
                        "Нет доступного имущества этой категории.";
                }
                else
                {
                    lblEquipmentHint.Text =
                        "Выберите имущество, которое требуется выдать.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить доступное имущество.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            UpdateCreateButtonState();
        }

        private void CmbCategory_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            LoadEquipment();
        }

        private void SelectionChanged(
            object sender,
            EventArgs e)
        {
            UpdateCreateButtonState();
        }

        private void UpdateCreateButtonState()
        {
            btnCreate.Enabled =
                cmbEmployee.SelectedItem != null &&
                cmbCategory.SelectedItem != null &&
                cmbEquipment.SelectedItem != null;
        }

        private void BtnCreate_Click(
            object sender,
            EventArgs e)
        {
            ComboItem employee =
                cmbEmployee.SelectedItem as ComboItem;

            ComboItem equipment =
                cmbEquipment.SelectedItem as ComboItem;

            if (employee == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (equipment == null)
            {
                MessageBox.Show(
                    "Выберите имущество для выдачи.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string comment = txtComment.Text.Trim();

            DialogResult result = MessageBox.Show(
                "Создать заявку на выдачу?\n\n" +
                "Сотрудник: " + employee.Text + "\n" +
                "Имущество: " + equipment.Text,
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
                        INSERT INTO equipment_issue_request
                        (
                            employee_id,
                            equipment_id,
                            request_date,
                            request_status,
                            comment
                        )
                        SELECT
                            @employee_id,
                            e.equipment_id,
                            CURRENT_DATE,
                            1,
                            @comment
                        FROM equipment e
                        INNER JOIN equipment_status s
                            ON s.equipment_status_id =
                               e.equipment_status_id
                        WHERE e.equipment_id = @equipment_id
                          AND e.employee_id IS NULL
                          AND s.equipment_status_name = 'Исправно'
                          AND NOT EXISTS
                          (
                              SELECT 1
                              FROM equipment_issue_request r
                              WHERE r.equipment_id = e.equipment_id
                                AND r.request_status = 1
                          );";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@employee_id",
                            employee.Id);

                        command.Parameters.AddWithValue(
                            "@equipment_id",
                            equipment.Id);

                        command.Parameters.AddWithValue(
                            "@comment",
                            string.IsNullOrWhiteSpace(comment)
                                ? (object)DBNull.Value
                                : comment);

                        int affectedRows =
                            command.ExecuteNonQuery();

                        if (affectedRows == 0)
                        {
                            MessageBox.Show(
                                "Заявку создать не удалось.\n\n" +
                                "Возможно, это имущество уже выдано " +
                                "или на него уже существует заявка, " +
                                "находящаяся в обработке.",
                                "Заявка не создана",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Заявка успешно создана.\n\n" +
                    "Статус заявки: В обработке.",
                    "Заявка создана",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось создать заявку.\n\n" +
                    ex.Message,
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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