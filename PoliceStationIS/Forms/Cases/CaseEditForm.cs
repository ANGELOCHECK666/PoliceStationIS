using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Cases
{
    public partial class CaseEditForm : Form
    {
        private readonly int caseId;
        private readonly bool isEditMode;
        private byte[] existingCaseFile;

        public CaseEditForm()
        {
            caseId = 0;
            isEditMode = false;
            InitializeComponent();
            ConfigureForm();
            LoadLookups();
            SetDefaultValues();
        }

        public CaseEditForm(int id)
        {
            caseId = id;
            isEditMode = true;
            InitializeComponent();
            ConfigureForm();
            LoadLookups();
            LoadCase();
        }

        private void ConfigureForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(900, 790);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(5, 24, 58);
            Text = isEditMode ? "Редактирование дела" : "Создание дела";
            lblTitle.Text = Text;
        }

        private void LoadLookups()
        {
            LoadArticles();
            LoadStatuses();
            LoadEmployees();
            LoadProtocols();
        }

        private void LoadArticles()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT article_of_the_ccrf_id,
                                            article_of_the_ccrf_code,
                                            article_of_the_ccrf_name
                                     FROM article_of_the_ccrf
                                     ORDER BY article_of_the_ccrf_code;";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbArticle.Items.Clear();
                        while (reader.Read())
                        {
                            cmbArticle.Items.Add(new ComboBoxItem(
                                Convert.ToInt32(reader["article_of_the_ccrf_id"]),
                                reader["article_of_the_ccrf_code"] + " — " +
                                reader["article_of_the_ccrf_name"]));
                        }
                    }
                    if (cmbArticle.Items.Count > 0) cmbArticle.SelectedIndex = 0;
                }
                catch (Exception ex) { ShowLoadError("статей", ex); }
            }
        }

        private void LoadStatuses()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT case_status_id, case_status_name
                                     FROM case_status ORDER BY case_status_name;";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbStatus.Items.Clear();
                        while (reader.Read())
                            cmbStatus.Items.Add(new ComboBoxItem(
                                Convert.ToInt32(reader["case_status_id"]),
                                reader["case_status_name"].ToString()));
                    }
                    SelectStatusByName("В обработке");
                    if (cmbStatus.SelectedIndex < 0 && cmbStatus.Items.Count > 0)
                        cmbStatus.SelectedIndex = 0;
                }
                catch (Exception ex) { ShowLoadError("статусов", ex); }
            }
        }

        private void LoadEmployees()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT employee_id, last_name, name_, middle_name
                                     FROM employee
                                     ORDER BY last_name, name_, middle_name;";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbEmployee.Items.Clear();
                        while (reader.Read())
                        {
                            string fullName = reader["last_name"] + " " +
                                              reader["name_"] + " " +
                                              reader["middle_name"];
                            cmbEmployee.Items.Add(new ComboBoxItem(
                                Convert.ToInt32(reader["employee_id"]),
                                fullName.Trim()));
                        }
                    }
                    if (cmbEmployee.Items.Count > 0) cmbEmployee.SelectedIndex = 0;
                }
                catch (Exception ex) { ShowLoadError("сотрудников", ex); }
            }
        }

        private void LoadProtocols()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT protocol_id, protocol_number
                                     FROM protocol ORDER BY protocol_number;";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbProtocol.Items.Clear();
                        while (reader.Read())
                            cmbProtocol.Items.Add(new ComboBoxItem(
                                Convert.ToInt32(reader["protocol_id"]),
                                reader["protocol_number"].ToString().Trim()));
                    }
                    if (cmbProtocol.Items.Count > 0) cmbProtocol.SelectedIndex = 0;
                }
                catch (Exception ex) { ShowLoadError("протоколов", ex); }
            }
        }

        private void SetDefaultValues()
        {
            txtCaseNumber.Clear();
            txtCrimeScene.Clear();
            txtDescription.Clear();
            dtCrimeDate.Value = DateTime.Now;
            dtCrimeDate.Checked = false;
            existingCaseFile = null;
            lblFileName.Text = "Файл не выбран";
        }

        private void LoadCase()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT case_number, employee_id, protocol_id,
                                            article_of_the_ccrf_id, case_status_id,
                                            description_case, date_and_time_of_crime,
                                            crime_scene, criminal_case_file
                                     FROM criminal_case
                                     WHERE criminal_case_id = @id;";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", caseId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Дело не найдено.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            txtCaseNumber.Text = reader["case_number"].ToString().Trim();
                            txtCrimeScene.Text = reader["crime_scene"].ToString();
                            txtDescription.Text = reader["description_case"].ToString();
                            SelectComboById(cmbEmployee, Convert.ToInt32(reader["employee_id"]));
                            SelectComboById(cmbProtocol, Convert.ToInt32(reader["protocol_id"]));
                            SelectComboById(cmbArticle, Convert.ToInt32(reader["article_of_the_ccrf_id"]));
                            SelectComboById(cmbStatus, Convert.ToInt32(reader["case_status_id"]));

                            if (reader["date_and_time_of_crime"] == DBNull.Value)
                            {
                                dtCrimeDate.Checked = false;
                                dtCrimeDate.Value = DateTime.Now;
                            }
                            else
                            {
                                dtCrimeDate.Checked = true;
                                dtCrimeDate.Value = Convert.ToDateTime(reader["date_and_time_of_crime"]);
                            }

                            if (reader["criminal_case_file"] == DBNull.Value)
                            {
                                existingCaseFile = null;
                                lblFileName.Text = "Файл не прикреплен";
                            }
                            else
                            {
                                existingCaseFile = (byte[])reader["criminal_case_file"];
                                lblFileName.Text = "Файл прикреплен";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки дела",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void SelectComboById(ComboBox comboBox, int id)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items[i] as ComboBoxItem;
                if (item != null && item.Id == id)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
            comboBox.SelectedIndex = -1;
        }

        private void SelectStatusByName(string name)
        {
            for (int i = 0; i < cmbStatus.Items.Count; i++)
            {
                var item = cmbStatus.Items[i] as ComboBoxItem;
                if (item != null && string.Equals(item.Name, name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    cmbStatus.SelectedIndex = i;
                    return;
                }
            }
        }

        private ComboBoxItem Selected(ComboBox comboBox)
        {
            return comboBox.SelectedItem as ComboBoxItem;
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Выберите файл уголовного дела";
                dialog.Filter = "Все файлы|*.*";
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    existingCaseFile = File.ReadAllBytes(dialog.FileName);
                    lblFileName.Text = Path.GetFileName(dialog.FileName);
                }
            }
        }

        private void BtnRemoveFile_Click(object sender, EventArgs e)
        {
            existingCaseFile = null;
            lblFileName.Text = "Файл не прикреплен";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var article = Selected(cmbArticle);
            var status = Selected(cmbStatus);
            var employee = Selected(cmbEmployee);
            var protocol = Selected(cmbProtocol);

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = isEditMode
                        ? @"UPDATE criminal_case SET
                               case_number = @case_number,
                               employee_id = @employee_id,
                               protocol_id = @protocol_id,
                               article_of_the_ccrf_id = @article_id,
                               case_status_id = @status_id,
                               description_case = @description,
                               date_and_time_of_crime = @crime_date,
                               crime_scene = @crime_scene,
                               criminal_case_file = @case_file,
                               last_update_date = CURRENT_DATE
                           WHERE criminal_case_id = @id;"
                        : @"INSERT INTO criminal_case
                           (employee_id, protocol_id, article_of_the_ccrf_id,
                            case_status_id, case_number, description_case,
                            date_and_time_of_crime, crime_scene, criminal_case_file,
                            case_creation_date, last_update_date)
                           VALUES
                           (@employee_id, @protocol_id, @article_id,
                            @status_id, @case_number, @description,
                            @crime_date, @crime_scene, @case_file,
                            CURRENT_DATE, CURRENT_DATE);";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@case_number", txtCaseNumber.Text.Trim());
                        command.Parameters.AddWithValue("@employee_id", employee.Id);
                        command.Parameters.AddWithValue("@protocol_id", protocol.Id);
                        command.Parameters.AddWithValue("@article_id", article.Id);
                        command.Parameters.AddWithValue("@status_id", status.Id);
                        command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        command.Parameters.AddWithValue("@crime_date",
                            dtCrimeDate.Checked ? (object)dtCrimeDate.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@crime_scene", txtCrimeScene.Text.Trim());
                        command.Parameters.AddWithValue("@case_file",
                            existingCaseFile == null ? (object)DBNull.Value : existingCaseFile);
                        if (isEditMode) command.Parameters.AddWithValue("@id", caseId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isEditMode ? "Дело успешно изменено." : "Дело успешно создано.",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(ex.MessageText, "Ошибка сохранения дела",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения дела",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCaseNumber.Text))
                return ValidationError("Введите номер дела.", txtCaseNumber);
            if (txtCaseNumber.Text.Trim().Length > 20)
                return ValidationError("Номер дела не должен превышать 20 символов.", txtCaseNumber);
            if (Selected(cmbArticle) == null)
                return ValidationError("Выберите статью УК РФ.", cmbArticle);
            if (Selected(cmbStatus) == null)
                return ValidationError("Выберите статус дела.", cmbStatus);
            if (Selected(cmbEmployee) == null)
                return ValidationError("Выберите следователя.", cmbEmployee);
            if (Selected(cmbProtocol) == null)
                return ValidationError("Выберите протокол.", cmbProtocol);
            if (string.IsNullOrWhiteSpace(txtCrimeScene.Text))
                return ValidationError("Введите место совершения преступления.", txtCrimeScene);
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
                return ValidationError("Введите описание дела.", txtDescription);
            return true;
        }

        private bool ValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Проверка данных",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            return false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowLoadError(string what, Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка загрузки " + what,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private class ComboBoxItem
        {
            public int Id { get; private set; }
            public string Name { get; private set; }
            public ComboBoxItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() { return Name; }
        }
    }
}