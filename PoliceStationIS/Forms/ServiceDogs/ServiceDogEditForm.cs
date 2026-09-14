using Npgsql;
using NpgsqlTypes;
using PoliceStationIS.Database;
using PoliceStationIS.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Dogs
{
    public partial class ServiceDogEditForm : Form
    {
        private readonly int? serviceDogId;

        public ServiceDogEditForm()
        {
            InitializeComponent();

            serviceDogId = null;

            lblTitle.Text =
                "ДОБАВЛЕНИЕ СЛУЖЕБНОЙ СОБАКИ";

            lblSubtitle.Text =
                "Добавление новой служебной собаки";

            dtDateOfBirth.MaxDate =
                DateTime.Today;

            LoadSexes();
            LoadBreeds();
            LoadStatuses();
            LoadSpecializations();
            LoadDogHandlers();
        }

        public ServiceDogEditForm(
            int serviceDogId)
        {
            InitializeComponent();

            this.serviceDogId =
                serviceDogId;

            lblTitle.Text =
                "РЕДАКТИРОВАНИЕ СЛУЖЕБНОЙ СОБАКИ";

            lblSubtitle.Text =
                "Изменение данных служебной собаки";

            dtDateOfBirth.MaxDate =
                DateTime.Today;

            LoadSexes();
            LoadBreeds();
            LoadStatuses();
            LoadSpecializations();
            LoadDogHandlers();
            LoadDog();
        }

        private void LoadSexes()
        {
            cmbSex.Items.Clear();

            LoadCombo(
                cmbSex,
                @"SELECT sex_id, sex_name
                  FROM Sex
                  ORDER BY sex_id;",
                "sex_id",
                "sex_name");
        }

        private void LoadBreeds()
        {
            cmbBreed.Items.Clear();

            LoadCombo(
                cmbBreed,
                @"SELECT breed_id, breed_name
                  FROM Breed
                  ORDER BY breed_name;",
                "breed_id",
                "breed_name");
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            LoadCombo(
                cmbStatus,
                @"SELECT dog_status_id, dog_status_name
                  FROM Dog_status
                  ORDER BY dog_status_name;",
                "dog_status_id",
                "dog_status_name");
        }

        private void LoadSpecializations()
        {
            cmbSpecialization.Items.Clear();

            LoadCombo(
                cmbSpecialization,
                @"SELECT specialization_id, specialization_name
                  FROM Specialization
                  ORDER BY specialization_name;",
                "specialization_id",
                "specialization_name");
        }

        private void LoadDogHandlers()
        {
            cmbEmployee.Items.Clear();

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            e.employee_id,
                            CONCAT_WS(
                                ' ',
                                e.last_name,
                                e.name_,
                                e.middle_name
                            ) AS employee_name
                        FROM Employee e
                        INNER JOIN Post p
                            ON e.post_id = p.post_id
                        WHERE p.post_name IN
                        (
                            'Кинолог',
                            'Инструктор-кинолог'
                        )
                        ORDER BY e.last_name, e.name_;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEmployee.Items.Add(
                                    new ComboItem
                                    {
                                        Id =
                                            Convert.ToInt32(
                                                reader["employee_id"]),

                                        Name =
                                            reader["employee_name"]
                                            .ToString()
                                    });
                            }
                        }
                    }
                }

                cmbEmployee.DisplayMember = "Name";
                cmbEmployee.ValueMember = "Id";

                if (cmbEmployee.Items.Count > 0)
                {
                    cmbEmployee.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить кинологов.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCombo(
            ComboBox comboBox,
            string query,
            string idField,
            string nameField)
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox.Items.Add(
                                    new ComboItem
                                    {
                                        Id =
                                            Convert.ToInt32(
                                                reader[idField]),

                                        Name =
                                            reader[nameField]
                                            .ToString()
                                            .Trim()
                                    });
                            }
                        }
                    }
                }

                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";

                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные справочника.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadDog()
        {
            if (serviceDogId == null)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            sex_id,
                            employee_id,
                            breed_id,
                            dog_status_id,
                            specialization_id,
                            stamp_number,
                            dog_name,
                            date_of_birth,
                            health
                        FROM Service_dog
                        WHERE service_dog_id = @id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@id",
                            NpgsqlDbType.Integer)
                            .Value =
                            serviceDogId.Value;

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Служебная собака не найдена.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                Close();
                                return;
                            }

                            SelectComboItem(
                                cmbSex,
                                Convert.ToInt32(
                                    reader["sex_id"]));

                            SelectComboItem(
                                cmbEmployee,
                                Convert.ToInt32(
                                    reader["employee_id"]));

                            SelectComboItem(
                                cmbBreed,
                                Convert.ToInt32(
                                    reader["breed_id"]));

                            SelectComboItem(
                                cmbStatus,
                                Convert.ToInt32(
                                    reader["dog_status_id"]));

                            SelectComboItem(
                                cmbSpecialization,
                                Convert.ToInt32(
                                    reader["specialization_id"]));

                            txtStampNumber.Text =
                                reader["stamp_number"]
                                .ToString()
                                .Trim();

                            txtDogName.Text =
                                reader["dog_name"]
                                .ToString();

                            DateTime birthDate =
                                Convert.ToDateTime(
                                    reader["date_of_birth"]);

                            if (birthDate >=
                                dtDateOfBirth.MinDate &&
                                birthDate <=
                                dtDateOfBirth.MaxDate)
                            {
                                dtDateOfBirth.Value =
                                    birthDate;
                            }

                            txtHealth.Text =
                                reader["health"]
                                .ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные собаки.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                ComboItem item =
                    comboBox.Items[i]
                    as ComboItem;

                if (item != null &&
                    item.Id == id)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        // Общая проверка заполненности выполняется через ValidationHelper.
        // Специальные правила для полей собаки остаются в этой форме.
        private bool ValidateFields()
        {
            if (!ValidationHelper.IsFilled(
                txtStampNumber.Text))
            {
                MessageBox.Show(
                    "Введите номер клейма.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStampNumber.Focus();
                return false;
            }

            if (txtStampNumber.Text.Trim().Length != 8)
            {
                MessageBox.Show(
                    "Номер клейма должен содержать 8 символов.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStampNumber.Focus();
                return false;
            }

            if (!ValidationHelper.IsFilled(
                txtDogName.Text))
            {
                MessageBox.Show(
                    "Введите кличку собаки.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDogName.Focus();
                return false;
            }

            if (cmbSex.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите пол.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbSex.Focus();
                return false;
            }

            if (cmbEmployee.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника-кинолога.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEmployee.Focus();
                return false;
            }

            if (cmbBreed.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите породу.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbBreed.Focus();
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите статус.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbStatus.Focus();
                return false;
            }

            if (cmbSpecialization.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите специализацию.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbSpecialization.Focus();
                return false;
            }

            if (!ValidationHelper.IsFilled(
                txtHealth.Text))
            {
                MessageBox.Show(
                    "Введите состояние здоровья.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtHealth.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            try
            {
                if (serviceDogId == null)
                {
                    InsertDog();
                }
                else
                {
                    UpdateDog();
                }

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Собака с таким номером клейма уже существует.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStampNumber.Focus();
                    return;
                }

                MessageBox.Show(
                    "Ошибка PostgreSQL:\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить данные собаки.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Добавление новой записи служебной собаки.
        private void InsertDog()
        {
            ComboItem sex =
                cmbSex.SelectedItem as ComboItem;

            ComboItem employee =
                cmbEmployee.SelectedItem as ComboItem;

            ComboItem breed =
                cmbBreed.SelectedItem as ComboItem;

            ComboItem status =
                cmbStatus.SelectedItem as ComboItem;

            ComboItem specialization =
                cmbSpecialization.SelectedItem as ComboItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
                    INSERT INTO Service_dog
                    (
                        sex_id,
                        employee_id,
                        breed_id,
                        dog_status_id,
                        specialization_id,
                        stamp_number,
                        dog_name,
                        date_of_birth,
                        health
                    )
                    VALUES
                    (
                        @sex_id,
                        @employee_id,
                        @breed_id,
                        @status_id,
                        @specialization_id,
                        @stamp_number,
                        @dog_name,
                        @date_of_birth,
                        @health
                    );
                ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    AddParameters(
                        command,
                        sex,
                        employee,
                        breed,
                        status,
                        specialization);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Обновление существующей записи служебной собаки.
        private void UpdateDog()
        {
            ComboItem sex =
                cmbSex.SelectedItem as ComboItem;

            ComboItem employee =
                cmbEmployee.SelectedItem as ComboItem;

            ComboItem breed =
                cmbBreed.SelectedItem as ComboItem;

            ComboItem status =
                cmbStatus.SelectedItem as ComboItem;

            ComboItem specialization =
                cmbSpecialization.SelectedItem as ComboItem;

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
                    UPDATE Service_dog
                    SET
                        sex_id = @sex_id,
                        employee_id = @employee_id,
                        breed_id = @breed_id,
                        dog_status_id = @status_id,
                        specialization_id = @specialization_id,
                        stamp_number = @stamp_number,
                        dog_name = @dog_name,
                        date_of_birth = @date_of_birth,
                        health = @health
                    WHERE service_dog_id = @id;
                ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    AddParameters(
                        command,
                        sex,
                        employee,
                        breed,
                        status,
                        specialization);

                    command.Parameters.Add(
                        "@id",
                        NpgsqlDbType.Integer)
                        .Value =
                        serviceDogId.Value;

                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddParameters(
            NpgsqlCommand command,
            ComboItem sex,
            ComboItem employee,
            ComboItem breed,
            ComboItem status,
            ComboItem specialization)
        {
            command.Parameters.Add(
                "@sex_id",
                NpgsqlDbType.Integer)
                .Value = sex.Id;

            command.Parameters.Add(
                "@employee_id",
                NpgsqlDbType.Integer)
                .Value = employee.Id;

            command.Parameters.Add(
                "@breed_id",
                NpgsqlDbType.Integer)
                .Value = breed.Id;

            command.Parameters.Add(
                "@status_id",
                NpgsqlDbType.Integer)
                .Value = status.Id;

            command.Parameters.Add(
                "@specialization_id",
                NpgsqlDbType.Integer)
                .Value = specialization.Id;

            command.Parameters.Add(
                "@stamp_number",
                NpgsqlDbType.Char)
                .Value =
                txtStampNumber.Text.Trim();

            command.Parameters.Add(
                "@dog_name",
                NpgsqlDbType.Varchar)
                .Value =
                txtDogName.Text.Trim();

            command.Parameters.Add(
                "@date_of_birth",
                NpgsqlDbType.Date)
                .Value =
                dtDateOfBirth.Value.Date;

            command.Parameters.Add(
                "@health",
                NpgsqlDbType.Text)
                .Value =
                txtHealth.Text.Trim();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        private class ComboItem
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
