using System;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Protocols
{
    public partial class ProtocolEditForm : Form
    {
        private readonly int protocolId;
        private readonly bool editMode;

        public ProtocolEditForm()
        {
            InitializeComponent();

            protocolId = 0;
            editMode = false;

            ConfigureForm();
            ConfigureEvents();
            LoadReferenceData();
        }

        public ProtocolEditForm(int id)
        {
            InitializeComponent();

            protocolId = id;
            editMode = true;

            ConfigureForm();
            ConfigureEvents();
            LoadReferenceData();
            LoadProtocolData();
        }

        private void ConfigureForm()
        {
            Text = editMode
                ? "Редактирование протокола"
                : "Создание протокола";

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
        }

        private void ConfigureEvents()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadReferenceData()
        {
            try
            {
                LoadProtocolTypes();
                LoadProtocolStatuses();
                LoadEmployees();
                LoadArticles();
                LoadEvidence();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники протокола.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadProtocolTypes()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_type_id,
                        protocol_type_name
                    FROM protocol_type
                    ORDER BY protocol_type_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbProtocolType.Items.Clear();

                    while (reader.Read())
                    {
                        cmbProtocolType.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["protocol_type_id"]),
                                Name = reader[
                                    "protocol_type_name"]
                                    .ToString()
                            });
                    }
                }
            }

            if (cmbProtocolType.Items.Count > 0)
                cmbProtocolType.SelectedIndex = 0;
        }

        private void LoadProtocolStatuses()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        protocol_status_id,
                        protocol_status_name
                    FROM protocol_status
                    ORDER BY protocol_status_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbStatus.Items.Clear();

                    while (reader.Read())
                    {
                        cmbStatus.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["protocol_status_id"]),
                                Name = reader[
                                    "protocol_status_name"]
                                    .ToString()
                            });
                    }
                }
            }

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        employee_id,
                        last_name || ' ' ||
                        name_ || ' ' ||
                        COALESCE(middle_name, '') AS employee_name
                    FROM employee
                    ORDER BY
                        last_name,
                        name_,
                        middle_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbEmployee.Items.Clear();

                    while (reader.Read())
                    {
                        cmbEmployee.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["employee_id"]),
                                Name = reader[
                                    "employee_name"]
                                    .ToString()
                                    .Trim()
                            });
                    }
                }
            }

            if (cmbEmployee.Items.Count > 0)
                cmbEmployee.SelectedIndex = 0;
        }

        private void LoadArticles()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        article_of_the_cao_rf_id,
                        article_of_the_cao_rf_code,
                        article_of_the_cao_rf_name
                    FROM article_of_the_cao_rf
                    ORDER BY article_of_the_cao_rf_code;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbArticle.Items.Clear();

                    cmbArticle.Items.Add(
                        new ComboBoxItem
                        {
                            Id = 0,
                            Name = "Не выбрано"
                        });

                    while (reader.Read())
                    {
                        cmbArticle.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader[
                                        "article_of_the_cao_rf_id"]),
                                Name = reader[
                                    "article_of_the_cao_rf_code"]
                                    .ToString() +
                                    " — " +
                                    reader[
                                        "article_of_the_cao_rf_name"]
                                        .ToString()
                            });
                    }
                }
            }

            if (cmbArticle.Items.Count > 0)
                cmbArticle.SelectedIndex = 0;
        }

        private void LoadEvidence()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        evidence_id,
                        evidence_number,
                        evidence_name
                    FROM evidence
                    ORDER BY evidence_number, evidence_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    cmbEvidence.Items.Clear();

                    cmbEvidence.Items.Add(
                        new ComboBoxItem
                        {
                            Id = 0,
                            Name = "Не выбрано"
                        });

                    while (reader.Read())
                    {
                        string number =
                            reader["evidence_number"]
                            .ToString()
                            .Trim();

                        string name =
                            reader["evidence_name"]
                            .ToString();

                        cmbEvidence.Items.Add(
                            new ComboBoxItem
                            {
                                Id = Convert.ToInt32(
                                    reader["evidence_id"]),
                                Name = number +
                                       " — " +
                                       name
                            });
                    }
                }
            }

            if (cmbEvidence.Items.Count > 0)
                cmbEvidence.SelectedIndex = 0;
        }

        private void LoadProtocolData()
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
                            protocol_number,
                            employee_id,
                            protocol_type_id,
                            article_of_the_cao_rf_id,
                            protocol_status_id,
                            evidence_id,
                            description_protocol,
                            place_of_commission,
                            date_of_preparation_protocol
                        FROM protocol
                        WHERE protocol_id = @id;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            protocolId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Протокол не найден.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                DialogResult =
                                    DialogResult.Cancel;

                                Close();
                                return;
                            }

                            txtProtocolNumber.Text =
                                reader["protocol_number"]
                                .ToString()
                                .Trim();

                            txtPlace.Text =
                                reader["place_of_commission"]
                                .ToString();

                            txtDescription.Text =
                                reader["description_protocol"]
                                .ToString();

                            dtPreparationDate.Value =
                                Convert.ToDateTime(
                                    reader[
                                        "date_of_preparation_protocol"]);

                            SelectComboItem(
                                cmbEmployee,
                                Convert.ToInt32(
                                    reader["employee_id"]));

                            SelectComboItem(
                                cmbProtocolType,
                                Convert.ToInt32(
                                    reader["protocol_type_id"]));

                            SelectComboItem(
                                cmbStatus,
                                Convert.ToInt32(
                                    reader["protocol_status_id"]));

                            if (reader[
                                    "article_of_the_cao_rf_id"] ==
                                DBNull.Value)
                            {
                                SelectComboItem(
                                    cmbArticle,
                                    0);
                            }
                            else
                            {
                                SelectComboItem(
                                    cmbArticle,
                                    Convert.ToInt32(
                                        reader[
                                            "article_of_the_cao_rf_id"]));
                            }

                            if (reader["evidence_id"] ==
                                DBNull.Value)
                            {
                                SelectComboItem(
                                    cmbEvidence,
                                    0);
                            }
                            else
                            {
                                SelectComboItem(
                                    cmbEvidence,
                                    Convert.ToInt32(
                                        reader["evidence_id"]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные протокола.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void SelectComboItem(
            ComboBox comboBox,
            int id)
        {
            for (int i = 0;
                 i < comboBox.Items.Count;
                 i++)
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

            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        private bool ValidateProtocol()
        {
            string protocolNumber =
                txtProtocolNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(protocolNumber))
            {
                MessageBox.Show(
                    "Введите номер протокола.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtProtocolNumber.Focus();
                return false;
            }

            if (protocolNumber.Length > 5)
            {
                MessageBox.Show(
                    "Номер протокола должен содержать не более 5 символов.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtProtocolNumber.Focus();
                return false;
            }

            if (cmbProtocolType.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите тип протокола.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbProtocolType.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите статус протокола.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return false;
            }

            if (cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника, составившего протокол.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEmployee.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtPlace.Text))
            {
                MessageBox.Show(
                    "Введите место составления протокола.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPlace.Focus();
                return false;
            }

            if (txtPlace.Text.Trim().Length > 255)
            {
                MessageBox.Show(
                    "Место составления не должно превышать 255 символов.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPlace.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtDescription.Text))
            {
                MessageBox.Show(
                    "Введите описание протокола.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateProtocol())
                return;

            try
            {
                if (editMode)
                    UpdateProtocol();
                else
                    AddProtocol();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Протокол с таким номером уже существует.",
                        "Ошибка сохранения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка сохранения протокола",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка сохранения протокола",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddProtocol()
        {
            ComboBoxItem employeeItem =
                cmbEmployee.SelectedItem as ComboBoxItem;

            ComboBoxItem typeItem =
                cmbProtocolType.SelectedItem as ComboBoxItem;

            ComboBoxItem statusItem =
                cmbStatus.SelectedItem as ComboBoxItem;

            ComboBoxItem articleItem =
                cmbArticle.SelectedItem as ComboBoxItem;

            ComboBoxItem evidenceItem =
                cmbEvidence.SelectedItem as ComboBoxItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    INSERT INTO protocol
                    (
                        employee_id,
                        protocol_type_id,
                        article_of_the_cao_rf_id,
                        protocol_status_id,
                        evidence_id,
                        protocol_number,
                        description_protocol,
                        place_of_commission,
                        date_of_preparation_protocol
                    )
                    VALUES
                    (
                        @employee_id,
                        @protocol_type_id,
                        @article_id,
                        @protocol_status_id,
                        @evidence_id,
                        @protocol_number,
                        @description,
                        @place,
                        @preparation_date
                    );
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@employee_id",
                        employeeItem.Id);

                    command.Parameters.AddWithValue(
                        "@protocol_type_id",
                        typeItem.Id);

                    command.Parameters.AddWithValue(
                        "@article_id",
                        articleItem != null &&
                        articleItem.Id > 0
                            ? (object)articleItem.Id
                            : DBNull.Value);

                    command.Parameters.AddWithValue(
                        "@protocol_status_id",
                        statusItem.Id);

                    command.Parameters.AddWithValue(
                        "@evidence_id",
                        evidenceItem != null &&
                        evidenceItem.Id > 0
                            ? (object)evidenceItem.Id
                            : DBNull.Value);

                    command.Parameters.AddWithValue(
                        "@protocol_number",
                        txtProtocolNumber.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@description",
                        txtDescription.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@place",
                        txtPlace.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@preparation_date",
                        dtPreparationDate.Value.Date);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateProtocol()
        {
            ComboBoxItem employeeItem =
                cmbEmployee.SelectedItem as ComboBoxItem;

            ComboBoxItem typeItem =
                cmbProtocolType.SelectedItem as ComboBoxItem;

            ComboBoxItem statusItem =
                cmbStatus.SelectedItem as ComboBoxItem;

            ComboBoxItem articleItem =
                cmbArticle.SelectedItem as ComboBoxItem;

            ComboBoxItem evidenceItem =
                cmbEvidence.SelectedItem as ComboBoxItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    UPDATE protocol
                    SET
                        employee_id =
                            @employee_id,
                        protocol_type_id =
                            @protocol_type_id,
                        article_of_the_cao_rf_id =
                            @article_id,
                        protocol_status_id =
                            @protocol_status_id,
                        evidence_id =
                            @evidence_id,
                        protocol_number =
                            @protocol_number,
                        description_protocol =
                            @description,
                        place_of_commission =
                            @place,
                        date_of_preparation_protocol =
                            @preparation_date
                    WHERE
                        protocol_id = @id;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@employee_id",
                        employeeItem.Id);

                    command.Parameters.AddWithValue(
                        "@protocol_type_id",
                        typeItem.Id);

                    command.Parameters.AddWithValue(
                        "@article_id",
                        articleItem != null &&
                        articleItem.Id > 0
                            ? (object)articleItem.Id
                            : DBNull.Value);

                    command.Parameters.AddWithValue(
                        "@protocol_status_id",
                        statusItem.Id);

                    command.Parameters.AddWithValue(
                        "@evidence_id",
                        evidenceItem != null &&
                        evidenceItem.Id > 0
                            ? (object)evidenceItem.Id
                            : DBNull.Value);

                    command.Parameters.AddWithValue(
                        "@protocol_number",
                        txtProtocolNumber.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@description",
                        txtDescription.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@place",
                        txtPlace.Text.Trim());

                    command.Parameters.AddWithValue(
                        "@preparation_date",
                        dtPreparationDate.Value.Date);

                    command.Parameters.AddWithValue(
                        "@id",
                        protocolId);

                    command.ExecuteNonQuery();
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

        private class ComboBoxItem
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