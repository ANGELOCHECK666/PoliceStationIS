using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Citizens
{
    public partial class CitizenEditForm : Form
    {
        private readonly int citizenId;
        private readonly bool editMode;

        public CitizenEditForm()
        {
            InitializeComponent();
            citizenId = 0;
            editMode = false;
            ConfigureForm();
            LoadReferenceData();
            dtpBirthDate.Value = new DateTime(1990, 1, 1);
            dtpPassportIssueDate.Value = DateTime.Today;
            Text = "Добавление гражданина";
            lblTitle.Text = "Добавление гражданина";
            lblSubtitle.Text = "Заполнение персональных, паспортных и контактных данных";
        }

        public CitizenEditForm(int id)
        {
            InitializeComponent();
            citizenId = id;
            editMode = true;
            ConfigureForm();
            LoadReferenceData();
            LoadCitizenData();
            Text = "Редактирование гражданина";
            lblTitle.Text = "Редактирование гражданина";
            lblSubtitle.Text = "Изменение персональных, паспортных и контактных данных";
        }

        private void ConfigureForm()
        {
            ConfigureComboBox(cmbGender);
            ConfigureComboBox(cmbBirthPlace);
            ConfigureComboBox(cmbCitizenship);
            ConfigureComboBox(cmbMaritalStatus);
            ConfigureComboBox(cmbCitizenRole);
            ConfigureComboBox(cmbPassportIssuance);

            txtLastName.MaxLength = 43;
            txtFirstName.MaxLength = 1478;
            txtMiddleName.MaxLength = 1482;
            txtPassportSeries.MaxLength = 4;
            txtPassportNumber.MaxLength = 6;
            txtPhone.MaxLength = 18;
            txtEmail.MaxLength = 255;
            txtRegistrationAddress.MaxLength = 255;
            txtResidentialAddress.MaxLength = 255;

            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpPassportIssueDate.Format = DateTimePickerFormat.Short;

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

        private void LoadReferenceData()
        {
            try
            {
                LoadComboBox(cmbGender,
                    "SELECT sex_id, sex_name FROM sex ORDER BY sex_name;",
                    "Выберите пол");

                LoadComboBox(cmbBirthPlace,
                    "SELECT birth_place_id, birth_place_name FROM birth_place ORDER BY birth_place_name;",
                    "Выберите место рождения");

                LoadComboBox(cmbCitizenship,
                    "SELECT citizenship_id, citizenship_name FROM citizenship ORDER BY citizenship_name;",
                    "Выберите гражданство");

                LoadComboBox(cmbMaritalStatus,
                    "SELECT marital_status_id, marital_status_name FROM marital_status ORDER BY marital_status_name;",
                    "Выберите семейное положение");

                LoadComboBox(cmbPassportIssuance,
                    "SELECT passport_issuance_id, passport_issuance_name FROM passport_issuance ORDER BY passport_issuance_name;",
                    "Выберите кем выдан паспорт");

                LoadComboBox(cmbCitizenRole,
                    "SELECT citizen_role_id, citizen_role_name FROM citizen_role ORDER BY citizen_role_name;",
                    "Выберите роль гражданина");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники гражданина.\n\n" + ex.Message,
                    "Ошибка загрузки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadComboBox(ComboBox comboBox, string query, string firstItem)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(new CitizenComboBoxItem { Id = 0, Name = firstItem });

            using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(new CitizenComboBoxItem
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Name = reader.GetValue(1).ToString()
                        });
                    }
                }
            }

            comboBox.SelectedIndex = 0;
        }

        private void LoadCitizenData()
        {
            try
            {
                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    const string query = @"
SELECT
    citizen_id,
    sex_id,
    birth_place_id,
    citizenship_id,
    marital_status_id,
    passport_issuance_id,
    citizen_role_id,
    passport_series,
    passport_number,
    last_name,
    name_,
    middle_name,
    phone_number,
    email,
    date_of_issue,
    date_of_birth,
    registration_address,
    residential_address,
    distinguishing_features
FROM citizen
WHERE citizen_id = @citizen_id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@citizen_id", citizenId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Гражданин не найден.",
                                    "Редактирование",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }

                            SelectComboItem(cmbGender, Convert.ToInt32(reader["sex_id"]));
                            SelectComboItem(cmbBirthPlace, Convert.ToInt32(reader["birth_place_id"]));
                            SelectComboItem(cmbCitizenship, Convert.ToInt32(reader["citizenship_id"]));
                            SelectComboItem(cmbMaritalStatus, Convert.ToInt32(reader["marital_status_id"]));
                            SelectComboItem(cmbPassportIssuance, Convert.ToInt32(reader["passport_issuance_id"]));
                            SelectComboItem(cmbCitizenRole, Convert.ToInt32(reader["citizen_role_id"]));

                            txtLastName.Text = reader["last_name"].ToString();
                            txtFirstName.Text = reader["name_"].ToString();
                            txtMiddleName.Text = reader["middle_name"] == DBNull.Value ? "" : reader["middle_name"].ToString();

                            dtpBirthDate.Value = Convert.ToDateTime(reader["date_of_birth"]);

                            txtPassportSeries.Text = reader["passport_series"].ToString().Trim();
                            txtPassportNumber.Text = reader["passport_number"].ToString().Trim();
                            dtpPassportIssueDate.Value = Convert.ToDateTime(reader["date_of_issue"]);

                            txtPhone.Text = reader["phone_number"].ToString().Trim();
                            txtEmail.Text = reader["email"] == DBNull.Value ? "" : reader["email"].ToString();

                            txtRegistrationAddress.Text = reader["registration_address"].ToString();
                            txtResidentialAddress.Text = reader["residential_address"] == DBNull.Value ? "" : reader["residential_address"].ToString();
                            txtDistinguishingFeatures.Text = reader["distinguishing_features"] == DBNull.Value ? "" : reader["distinguishing_features"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные гражданина.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SelectComboItem(ComboBox comboBox, int id)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                CitizenComboBoxItem item = comboBox.Items[i] as CitizenComboBoxItem;

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
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string passportSeries = txtPassportSeries.Text.Trim();
            string passportNumber = txtPassportNumber.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string registrationAddress = txtRegistrationAddress.Text.Trim();
            string residentialAddress = txtResidentialAddress.Text.Trim();
            string features = txtDistinguishingFeatures.Text.Trim();

            CitizenComboBoxItem gender = cmbGender.SelectedItem as CitizenComboBoxItem;
            CitizenComboBoxItem birthPlace = cmbBirthPlace.SelectedItem as CitizenComboBoxItem;
            CitizenComboBoxItem citizenship = cmbCitizenship.SelectedItem as CitizenComboBoxItem;
            CitizenComboBoxItem marital = cmbMaritalStatus.SelectedItem as CitizenComboBoxItem;
            CitizenComboBoxItem issuance = cmbPassportIssuance.SelectedItem as CitizenComboBoxItem;
            CitizenComboBoxItem role = cmbCitizenRole.SelectedItem as CitizenComboBoxItem;

            if (!ValidateRequired(lastName, "Введите фамилию.", txtLastName) ||
                !ValidateRequired(firstName, "Введите имя.", txtFirstName) ||
                !ValidateCombo(gender, "Выберите пол.", cmbGender) ||
                !ValidateCombo(birthPlace, "Выберите место рождения.", cmbBirthPlace) ||
                !ValidateCombo(citizenship, "Выберите гражданство.", cmbCitizenship) ||
                !ValidateCombo(marital, "Выберите семейное положение.", cmbMaritalStatus) ||
                !ValidateCombo(issuance, "Выберите орган, выдавший паспорт.", cmbPassportIssuance) ||
                !ValidateCombo(role, "Выберите роль гражданина.", cmbCitizenRole))
            {
                return;
            }

            if (passportSeries.Length != 4)
            {
                ShowValidation("Серия паспорта должна содержать 4 символа.", txtPassportSeries);
                return;
            }

            if (passportNumber.Length != 6)
            {
                ShowValidation("Номер паспорта должен содержать 6 символов.", txtPassportNumber);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowValidation("Введите номер телефона.", txtPhone);
                return;
            }

            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                ShowValidation("Введите корректный адрес электронной почты.", txtEmail);
                return;
            }

            if (string.IsNullOrWhiteSpace(registrationAddress))
            {
                ShowValidation("Введите адрес регистрации.", txtRegistrationAddress);
                return;
            }

            if (dtpBirthDate.Value.Date > DateTime.Today)
            {
                ShowValidation("Дата рождения не может быть в будущем.", dtpBirthDate);
                return;
            }

            if (dtpPassportIssueDate.Value.Date > DateTime.Today)
            {
                ShowValidation("Дата выдачи паспорта не может быть в будущем.", dtpPassportIssueDate);
                return;
            }

            if (dtpPassportIssueDate.Value.Date < dtpBirthDate.Value.Date)
            {
                ShowValidation("Дата выдачи паспорта не может быть раньше даты рождения.", dtpPassportIssueDate);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    if (editMode)
                    {
                        UpdateCitizen(
                            connection,
                            gender.Id,
                            birthPlace.Id,
                            citizenship.Id,
                            marital.Id,
                            issuance.Id,
                            role.Id,
                            passportSeries,
                            passportNumber,
                            lastName,
                            firstName,
                            middleName,
                            phone,
                            email,
                            registrationAddress,
                            residentialAddress,
                            features);
                    }
                    else
                    {
                        AddCitizen(
                            connection,
                            gender.Id,
                            birthPlace.Id,
                            citizenship.Id,
                            marital.Id,
                            issuance.Id,
                            role.Id,
                            passportSeries,
                            passportNumber,
                            lastName,
                            firstName,
                            middleName,
                            phone,
                            email,
                            registrationAddress,
                            residentialAddress,
                            features);
                    }
                }

                MessageBox.Show(
                    editMode ? "Данные гражданина успешно изменены." : "Гражданин успешно добавлен.",
                    editMode ? "Редактирование" : "Добавление",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                string message;

                if (ex.SqlState == "23505")
                    message = "Паспорт или номер телефона с такими данными уже существует.";
                else
                    message = ex.MessageText;

                MessageBox.Show(
                    message,
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить гражданина.\n\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddCitizen(
            NpgsqlConnection connection,
            int sexId,
            int birthPlaceId,
            int citizenshipId,
            int maritalId,
            int issuanceId,
            int roleId,
            string series,
            string number,
            string lastName,
            string firstName,
            string middleName,
            string phone,
            string email,
            string registration,
            string residence,
            string features)
        {
            const string query = @"
INSERT INTO citizen
(
    sex_id,
    birth_place_id,
    citizenship_id,
    marital_status_id,
    passport_issuance_id,
    citizen_role_id,
    passport_series,
    passport_number,
    last_name,
    name_,
    middle_name,
    phone_number,
    email,
    date_of_issue,
    date_of_birth,
    registration_address,
    residential_address,
    distinguishing_features
)
VALUES
(
    @sex_id,
    @birth_place_id,
    @citizenship_id,
    @marital_id,
    @issuance_id,
    @role_id,
    @series,
    @number,
    @last_name,
    @name_,
    @middle_name,
    @phone,
    @email,
    @issue_date,
    @birth_date,
    @registration,
    @residence,
    @features
);";

            ExecuteSaveQuery(
                connection,
                query,
                sexId,
                birthPlaceId,
                citizenshipId,
                maritalId,
                issuanceId,
                roleId,
                series,
                number,
                lastName,
                firstName,
                middleName,
                phone,
                email,
                registration,
                residence,
                features,
                false);
        }

        private void UpdateCitizen(
            NpgsqlConnection connection,
            int sexId,
            int birthPlaceId,
            int citizenshipId,
            int maritalId,
            int issuanceId,
            int roleId,
            string series,
            string number,
            string lastName,
            string firstName,
            string middleName,
            string phone,
            string email,
            string registration,
            string residence,
            string features)
        {
            const string query = @"
UPDATE citizen SET
    sex_id = @sex_id,
    birth_place_id = @birth_place_id,
    citizenship_id = @citizenship_id,
    marital_status_id = @marital_id,
    passport_issuance_id = @issuance_id,
    citizen_role_id = @role_id,
    passport_series = @series,
    passport_number = @number,
    last_name = @last_name,
    name_ = @name_,
    middle_name = @middle_name,
    phone_number = @phone,
    email = @email,
    date_of_issue = @issue_date,
    date_of_birth = @birth_date,
    registration_address = @registration,
    residential_address = @residence,
    distinguishing_features = @features
WHERE citizen_id = @citizen_id;";

            ExecuteSaveQuery(
                connection,
                query,
                sexId,
                birthPlaceId,
                citizenshipId,
                maritalId,
                issuanceId,
                roleId,
                series,
                number,
                lastName,
                firstName,
                middleName,
                phone,
                email,
                registration,
                residence,
                features,
                true);
        }

        private void ExecuteSaveQuery(
            NpgsqlConnection connection,
            string query,
            int sexId,
            int birthPlaceId,
            int citizenshipId,
            int maritalId,
            int issuanceId,
            int roleId,
            string series,
            string number,
            string lastName,
            string firstName,
            string middleName,
            string phone,
            string email,
            string registration,
            string residence,
            string features,
            bool update)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@sex_id", sexId);
                command.Parameters.AddWithValue("@birth_place_id", birthPlaceId);
                command.Parameters.AddWithValue("@citizenship_id", citizenshipId);
                command.Parameters.AddWithValue("@marital_id", maritalId);
                command.Parameters.AddWithValue("@issuance_id", issuanceId);
                command.Parameters.AddWithValue("@role_id", roleId);
                command.Parameters.AddWithValue("@series", series);
                command.Parameters.AddWithValue("@number", number);
                command.Parameters.AddWithValue("@last_name", lastName);
                command.Parameters.AddWithValue("@name_", firstName);
                command.Parameters.AddWithValue("@middle_name", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                command.Parameters.AddWithValue("@issue_date", dtpPassportIssueDate.Value.Date);
                command.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value.Date);
                command.Parameters.AddWithValue("@registration", registration);
                command.Parameters.AddWithValue("@residence", string.IsNullOrWhiteSpace(residence) ? (object)DBNull.Value : residence);
                command.Parameters.AddWithValue("@features", string.IsNullOrWhiteSpace(features) ? (object)DBNull.Value : features);

                if (update)
                    command.Parameters.AddWithValue("@citizen_id", citizenId);

                int affected = command.ExecuteNonQuery();

                if (update && affected == 0)
                    throw new Exception("Гражданин не найден или уже был удалён.");
            }
        }

        private bool ValidateRequired(string value, string message, Control control)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return true;

            ShowValidation(message, control);
            return false;
        }

        private bool ValidateCombo(CitizenComboBoxItem item, string message, Control control)
        {
            if (item != null && item.Id != 0)
                return true;

            ShowValidation(message, control);
            return false;
        }

        private void ShowValidation(string message, Control control)
        {
            MessageBox.Show(
                message,
                "Проверка данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private sealed class CitizenComboBoxItem
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