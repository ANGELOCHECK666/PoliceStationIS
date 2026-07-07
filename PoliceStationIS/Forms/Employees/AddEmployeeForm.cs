using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Employees
{
    public partial class AddEmployeeForm : Form
    {
        private int? employeeId = null;

        private NpgsqlConnection connection;
        public AddEmployeeForm()
        {
            InitializeComponent();

            connection =
                DatabaseConnection.GetConnection();

            this.Load += AddEmployeeForm_Load;

            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
            txtPhone.Leave += TxtPhone_Leave;
            // =====================================
            // ФИО
            // =====================================

            txtLastName.KeyPress +=
                InputHelper.OnlyLetters;

            txtFirstName.KeyPress +=
                InputHelper.OnlyLetters;

            txtMiddleName.KeyPress +=
                InputHelper.OnlyLetters;

            // =====================================
            // ПАСПОРТ
            // =====================================

            txtPassportSeries.KeyPress +=
                InputHelper.OnlyDigits;

            txtPassportNumber.KeyPress +=
                InputHelper.OnlyDigits;

            // =====================================
            // ВОЕННЫЙ БИЛЕТ
            // =====================================

            txtMilitaryNumber.KeyPress +=
                InputHelper.OnlyDigits;

            // =====================================
            // ЖЕТОН
            // =====================================

            txtTokenNumber.KeyPress +=
                InputHelper.OnlyDigits;

            // =====================================
            // РОСТ И ВЕС
            // =====================================

            txtHeight.KeyPress +=
                InputHelper.OnlyDigits;

            txtWeight.KeyPress +=
                InputHelper.DecimalNumber;

            // =====================================
            // ЛОГИН
            // =====================================

            txtLogin.KeyPress +=
                InputHelper.LettersAndDigits;
            // =====================================
            // МАКСИМАЛЬНАЯ ДЛИНА
            // =====================================

            txtPassportSeries.MaxLength = 4;

            txtPassportNumber.MaxLength = 6;

            txtMilitarySeries.MaxLength = 2;

            txtMilitaryNumber.MaxLength = 7;

            txtTokenSeries.MaxLength = 2;

            txtTokenNumber.MaxLength = 6;

            txtLogin.MaxLength = 50;
        }

        public AddEmployeeForm(
    int employeeId)
    : this()
        {
            this.employeeId =
                employeeId;

            this.Text =
                "Редактирование сотрудника";

            btnSave.Text =
                "Сохранить изменения";
        }

        private void AddEmployeeForm_Load(
    object sender,
    EventArgs e)
        {
            try
            {
                LoadSex();
                LoadMaritalStatuses();
                LoadPassportIssuance();
                LoadMilitaryCategories();

                LoadDepartments();
                LoadPosts();
                LoadRanks();
                LoadEmploymentStatuses();

                LoadUserRoles();
                if (employeeId.HasValue)
                {
                    LoadEmployeeData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadSex()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       "SELECT Sex_id, Sex_name FROM Sex ORDER BY Sex_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbSex.DataSource = table;
            cmbSex.DisplayMember = "Sex_name";
            cmbSex.ValueMember = "Sex_id";
        }

        private void LoadMaritalStatuses()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Marital_status_id,
                        Marital_status_name
                 FROM Marital_status
                 ORDER BY Marital_status_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbMaritalStatus.DataSource = table;
            cmbMaritalStatus.DisplayMember =
                "Marital_status_name";

            cmbMaritalStatus.ValueMember =
                "Marital_status_id";
        }

        private void LoadPassportIssuance()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Passport_issuance_id,
                        Passport_issuance_name
                 FROM Passport_issuance
                 ORDER BY Passport_issuance_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbPassportIssuedBy.DataSource =
                table;

            cmbPassportIssuedBy.DisplayMember =
                "Passport_issuance_name";

            cmbPassportIssuedBy.ValueMember =
                "Passport_issuance_id";
        }

        private void LoadMilitaryCategories()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Military_category_id,
                        Military_category_name
                 FROM Military_category
                 ORDER BY Military_category_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbMilitaryCategory.DataSource =
                table;

            cmbMilitaryCategory.DisplayMember =
                "Military_category_name";

            cmbMilitaryCategory.ValueMember =
                "Military_category_id";
        }

        private void LoadDepartments()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Department_id,
                        Department_name
                 FROM Department
                 ORDER BY Department_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbDepartment.DataSource =
                table;

            cmbDepartment.DisplayMember =
                "Department_name";

            cmbDepartment.ValueMember =
                "Department_id";
        }

        private void LoadPosts()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Post_id,
                        Post_name
                 FROM Post
                 ORDER BY Post_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbPost.DataSource =
                table;

            cmbPost.DisplayMember =
                "Post_name";

            cmbPost.ValueMember =
                "Post_id";
        }

        private void LoadRanks()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Rank_id,
                        Rank_name
                 FROM Rank_
                 ORDER BY Rank_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbRank.DataSource =
                table;

            cmbRank.DisplayMember =
                "Rank_name";

            cmbRank.ValueMember =
                "Rank_id";
        }

        private void LoadEmploymentStatuses()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT Employment_status_id,
                        Employment_status_name
                 FROM Employment_status
                 ORDER BY Employment_status_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbEmploymentStatus.DataSource =
                table;

            cmbEmploymentStatus.DisplayMember =
                "Employment_status_name";

            cmbEmploymentStatus.ValueMember =
                "Employment_status_id";
        }

        private void LoadUserRoles()
        {
            DataTable table =
                new DataTable();

            using (NpgsqlDataAdapter adapter =
                   new NpgsqlDataAdapter(
                       @"SELECT User_role_id,
                        User_role_name
                 FROM User_role
                 ORDER BY User_role_name",
                       connection))
            {
                adapter.Fill(table);
            }

            cmbUserRole.DataSource =
                table;

            cmbUserRole.DisplayMember =
                "User_role_name";

            cmbUserRole.ValueMember =
                "User_role_id";
        }

        private void BtnCancel_Click(
    object sender,
    EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(
    object sender,
    EventArgs e)
        {

            if (!ValidationHelper.IsFilled(
        txtLastName.Text))
            {
                MessageBox.Show(
                    "Введите фамилию.");
                return;
            }

            if (!ValidationHelper.IsFilled(
                    txtFirstName.Text))
            {
                MessageBox.Show(
                    "Введите имя.");
                return;
            }

            if (!ValidationHelper.IsValidName(
                    txtLastName.Text))
            {
                MessageBox.Show(
                    "Фамилия содержит недопустимые символы.");
                return;
            }

            if (!ValidationHelper.IsValidName(
                    txtFirstName.Text))
            {
                MessageBox.Show(
                    "Имя содержит недопустимые символы.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(
                    txtMiddleName.Text) &&
                !ValidationHelper.IsValidName(
                    txtMiddleName.Text))
            {
                MessageBox.Show(
                    "Отчество содержит недопустимые символы.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(
        txtMiddleName.Text) &&
    !ValidationHelper.IsValidName(
        txtMiddleName.Text))
            {
                MessageBox.Show(
                    "Отчество содержит недопустимые символы.");
                return;
            }
            if (!ValidationHelper.IsValidPhone(
        txtPhone.Text))
            {
                MessageBox.Show(
                    "Введите корректный номер телефона.");
                return;
            }

            if (!ValidationHelper.IsValidEmail(
                    txtEmail.Text))
            {
                MessageBox.Show(
                    "Введите корректный Email.");
                return;
            }
            if (!ValidationHelper.IsValidPassportSeries(
        txtPassportSeries.Text))
            {
                MessageBox.Show(
                    "Серия паспорта должна содержать 4 цифры.");
                return;
            }

            if (!ValidationHelper.IsValidPassportNumber(
                    txtPassportNumber.Text))
            {
                MessageBox.Show(
                    "Номер паспорта должен содержать 6 цифр.");
                return;
            }
            if (!ValidationHelper.IsValidMilitarySeries(
        txtMilitarySeries.Text))
            {
                MessageBox.Show(
                    "Серия военного билета должна содержать 2 символа.");
                return;
            }

            if (!ValidationHelper.IsValidMilitaryNumber(
                    txtMilitaryNumber.Text))
            {
                MessageBox.Show(
                    "Номер военного билета должен содержать 7 цифр.");
                return;
            }
            if (!ValidationHelper.IsValidTokenSeries(
        txtTokenSeries.Text))
            {
                MessageBox.Show(
                    "Серия жетона должна содержать 2 символа.");
                return;
            }

            if (!ValidationHelper.IsValidTokenNumber(
                    txtTokenNumber.Text))
            {
                MessageBox.Show(
                    "Номер жетона должен содержать 6 цифр.");
                return;
            }
            if (!ValidationHelper.IsValidLogin(
        txtLogin.Text))
            {
                MessageBox.Show(
                    "Логин должен содержать от 5 до 50 символов.\nДопустимы буквы, цифры и знак _");
                return;
            }

            if (!ValidationHelper.IsValidPassword(
                    txtPassword.Text))
            {
                MessageBox.Show(
                    "Пароль должен содержать минимум 8 символов, одну букву и одну цифру.");
                return;
            }

            if (txtPassword.Text !=
                txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Пароли не совпадают.");
                return;
            }
            if (!ValidationHelper.IsValidHeight(
        txtHeight.Text))
            {
                MessageBox.Show(
                    "Рост должен быть числом.");
                return;
            }

            if (!ValidationHelper.IsValidWeight(
                    txtWeight.Text))
            {
                MessageBox.Show(
                    "Вес должен быть числом.");
                return;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLogin.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show(
                        "Заполните обязательные поля.");

                    return;
                }

                if (txtPassword.Text !=
                    txtConfirmPassword.Text)
                {
                    MessageBox.Show(
                        "Пароли не совпадают.");

                    return;
                }

                connection.Open();

                NpgsqlTransaction transaction =
                    connection.BeginTransaction();

                if (employeeId.HasValue)
                {
                    UpdateEmployee(transaction);

                    transaction.Commit();

                    MessageBox.Show(
                        "Изменения успешно сохранены.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();

                    return;
                }

                string employeeQuery =
@"
INSERT INTO Employee
(
    Sex_id,
    Marital_status_id,
    Passport_issuance_id,
    Military_category_id,
    Department_id,
    Post_id,
    Rank_id,
    Employment_status_id,

    Passport_series,
    Passport_number,

    Last_name,
    Name_,
    Middle_name,

    Phone_number,

    Date_of_issue,
    Date_of_birth,

    Registration_address,
    Residential_address,

    Military_card_series,
    Military_card_number,

    Weight_kg,
    Height_cm,

    Criminal_record,

    License_series,
    License_number,
    Validity_period,

    Token_series,
    Token_number,

    Service_start_date
)
VALUES
(
    @SexId,
    @MaritalStatusId,
    @PassportIssuanceId,
    @MilitaryCategoryId,
    @DepartmentId,
    @PostId,
    @RankId,
    @EmploymentStatusId,

    @PassportSeries,
    @PassportNumber,

    @LastName,
    @FirstName,
    @MiddleName,

    @Phone,

    @IssueDate,
    @BirthDate,

    @RegistrationAddress,
    @ResidentialAddress,

    @MilitarySeries,
    @MilitaryNumber,

    @Weight,
    @Height,

    @CriminalRecord,

    @LicenseSeries,
    @LicenseNumber,
    @LicenseValidity,

    @TokenSeries,
    @TokenNumber,

    @ServiceStartDate
)
RETURNING Employee_id;
";

                NpgsqlCommand employeeCommand =
    new NpgsqlCommand(
        employeeQuery,
        connection,
        transaction);

                employeeCommand.Parameters.AddWithValue(
    "@SexId",
    Convert.ToInt32(cmbSex.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@MaritalStatusId",
                    Convert.ToInt32(cmbMaritalStatus.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@PassportIssuanceId",
                    Convert.ToInt32(cmbPassportIssuedBy.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@MilitaryCategoryId",
                    Convert.ToInt32(cmbMilitaryCategory.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@DepartmentId",
                    Convert.ToInt32(cmbDepartment.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@PostId",
                    Convert.ToInt32(cmbPost.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@RankId",
                    Convert.ToInt32(cmbRank.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
                    "@EmploymentStatusId",
                    Convert.ToInt32(cmbEmploymentStatus.SelectedValue));

                employeeCommand.Parameters.AddWithValue(
    "@PassportSeries",
    txtPassportSeries.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@PassportNumber",
                    txtPassportNumber.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@LastName",
                    txtLastName.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@FirstName",
                    txtFirstName.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@MiddleName",
                    txtMiddleName.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@Phone",
                    txtPhone.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@IssueDate",
                    dtpIssueDate.Value.Date);

                employeeCommand.Parameters.AddWithValue(
                    "@BirthDate",
                    dtpBirthDate.Value.Date);

                employeeCommand.Parameters.AddWithValue(
                    "@RegistrationAddress",
                    txtRegistrationAddress.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@ResidentialAddress",
                    txtResidentialAddress.Text);

                employeeCommand.Parameters.AddWithValue(
    "@MilitarySeries",
    txtMilitarySeries.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@MilitaryNumber",
                    txtMilitaryNumber.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@Weight",
                    decimal.Parse(txtWeight.Text));

                employeeCommand.Parameters.AddWithValue(
                    "@Height",
                    int.Parse(txtHeight.Text));

                employeeCommand.Parameters.AddWithValue(
                    "@CriminalRecord",
                    chkCriminalRecord.Checked);

                employeeCommand.Parameters.AddWithValue(
                    "@LicenseSeries",
                    txtLicenseSeries.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@LicenseNumber",
                    txtLicenseNumber.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@LicenseValidity",
                    dtpLicenseValidity.Value.Date);

                employeeCommand.Parameters.AddWithValue(
                    "@TokenSeries",
                    txtTokenSeries.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@TokenNumber",
                    txtTokenNumber.Text);

                employeeCommand.Parameters.AddWithValue(
                    "@ServiceStartDate",
                    dtpServiceStartDate.Value.Date);

                int newEmployeeId =
    Convert.ToInt32(
        employeeCommand.ExecuteScalar());

                string userQuery =
@"
INSERT INTO App_user
(
    Employee_id,
    User_role_id,
    Login_,
    Password_hash,
    Email
)
VALUES
(
    @EmployeeId,
    @UserRoleId,
    @Login,
    @PasswordHash,
    @Email
);
";

                NpgsqlCommand userCommand =
    new NpgsqlCommand(
        userQuery,
        connection,
        transaction);

                userCommand.Parameters.AddWithValue(
    "@EmployeeId",
    newEmployeeId);

                userCommand.Parameters.AddWithValue(
                    "@UserRoleId",
                    Convert.ToInt32(
                        cmbUserRole.SelectedValue));

                userCommand.Parameters.AddWithValue(
                    "@Login",
                    txtLogin.Text);

                userCommand.Parameters.AddWithValue(
                    "@PasswordHash",
                    HashPassword(
                        txtPassword.Text));

                userCommand.Parameters.AddWithValue(
                    "@Email",
                    txtEmail.Text);

                userCommand.ExecuteNonQuery();

                string historyQuery =
                @"
INSERT INTO Personnel_history
(
    employee_id,
    event_type,
    event_description
)
VALUES
(
    @EmployeeId,
    @EventType,
    @Description
);
";

                NpgsqlCommand historyCommand =
                    new NpgsqlCommand(
                        historyQuery,
                        connection,
                        transaction);

                historyCommand.Parameters.AddWithValue(
    "@EmployeeId",
    newEmployeeId);

                historyCommand.Parameters.AddWithValue(
                    "@EventType",
                    "Прием на работу");

                historyCommand.Parameters.AddWithValue(
                    "@Description",
                    "Назначен на должность " +
                    cmbPost.Text);

                historyCommand.ExecuteNonQuery();

                transaction.Commit();


                MessageBox.Show(
                    "Сотрудник успешно добавлен.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State ==
                    ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha =
                   System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes =
                    Encoding.UTF8.GetBytes(password);

                byte[] hash =
                    sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        private void BtnClose_Click(
    object sender,
    EventArgs e)
        {
            this.Close();
        }

        private void TxtPhone_Leave(
    object sender,
    EventArgs e)
        {
            txtPhone.Text =
                ValidationHelper.FormatPhone(
                    txtPhone.Text);
        }

        private void LoadEmployeeData()
        {
            try
            {
                string query =
        @"
SELECT
    e.*,

    u.Login_,
    u.Email,
    u.User_role_id

FROM Employee e

LEFT JOIN App_user u
    ON e.Employee_id = u.Employee_id

WHERE e.Employee_id = @EmployeeId;
";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@EmployeeId",
                        employeeId.Value);

                    connection.Open();

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return;

                        txtLastName.Text =
                            reader["Last_name"].ToString();

                        txtFirstName.Text =
                            reader["Name_"].ToString();

                        txtMiddleName.Text =
                            reader["Middle_name"].ToString();

                        txtPhone.Text =
                            reader["Phone_number"].ToString();

                        txtPassportSeries.Text =
                            reader["Passport_series"].ToString();

                        txtPassportNumber.Text =
                            reader["Passport_number"].ToString();

                        txtRegistrationAddress.Text =
                            reader["Registration_address"].ToString();

                        txtResidentialAddress.Text =
                            reader["Residential_address"].ToString();

                        txtMilitarySeries.Text =
                            reader["Military_card_series"].ToString();

                        txtMilitaryNumber.Text =
                            reader["Military_card_number"].ToString();

                        txtTokenSeries.Text =
                            reader["Token_series"].ToString();

                        txtTokenNumber.Text =
                            reader["Token_number"].ToString();

                        txtLicenseSeries.Text =
                            reader["License_series"].ToString();

                        txtLicenseNumber.Text =
                            reader["License_number"].ToString();

                        txtHeight.Text =
                            reader["Height_cm"].ToString();

                        txtWeight.Text =
                            reader["Weight_kg"].ToString();

                        txtLogin.Text =
                            reader["Login_"].ToString();

                        txtEmail.Text =
                            reader["Email"].ToString();

                        chkCriminalRecord.Checked =
    reader["Criminal_record"] != DBNull.Value
    &&
    Convert.ToBoolean(
        reader["Criminal_record"]);

                        if (reader["Date_of_birth"] != DBNull.Value)
                        {
                            dtpBirthDate.Value =
                                Convert.ToDateTime(
                                    reader["Date_of_birth"]);
                        }

                        if (reader["Date_of_issue"] != DBNull.Value)
                        {
                            dtpIssueDate.Value =
                                Convert.ToDateTime(
                                    reader["Date_of_issue"]);
                        }

                        if (reader["Validity_period"] != DBNull.Value)
                        {
                            dtpLicenseValidity.Value =
                                Convert.ToDateTime(
                                    reader["Validity_period"]);
                        }

                        if (reader["Service_start_date"] != DBNull.Value)
                        {
                            dtpServiceStartDate.Value =
                                Convert.ToDateTime(
                                    reader["Service_start_date"]);
                        }

                        cmbSex.SelectedValue =
                            reader["Sex_id"];

                        cmbMaritalStatus.SelectedValue =
                            reader["Marital_status_id"];

                        cmbPassportIssuedBy.SelectedValue =
                            reader["Passport_issuance_id"];

                        cmbMilitaryCategory.SelectedValue =
                            reader["Military_category_id"];

                        cmbDepartment.SelectedValue =
                            reader["Department_id"];

                        cmbPost.SelectedValue =
                            reader["Post_id"];

                        cmbRank.SelectedValue =
                            reader["Rank_id"];

                        cmbEmploymentStatus.SelectedValue =
                            reader["Employment_status_id"];

                        if (reader["User_role_id"] != DBNull.Value)
                        {
                            cmbUserRole.SelectedValue =
                                reader["User_role_id"];
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки сотрудника",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State ==
                    ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void UpdateEmployee(
    NpgsqlTransaction transaction)
        {
            string employeeQuery =
        @"
UPDATE Employee
SET
    Sex_id = @SexId,
    Marital_status_id = @MaritalStatusId,
    Passport_issuance_id = @PassportIssuanceId,
    Military_category_id = @MilitaryCategoryId,

    Department_id = @DepartmentId,
    Post_id = @PostId,
    Rank_id = @RankId,
    Employment_status_id = @EmploymentStatusId,

    Passport_series = @PassportSeries,
    Passport_number = @PassportNumber,

    Last_name = @LastName,
    Name_ = @FirstName,
    Middle_name = @MiddleName,

    Phone_number = @Phone,

    Date_of_issue = @IssueDate,
    Date_of_birth = @BirthDate,

    Registration_address = @RegistrationAddress,
    Residential_address = @ResidentialAddress,

    Military_card_series = @MilitarySeries,
    Military_card_number = @MilitaryNumber,

    Weight_kg = @Weight,
    Height_cm = @Height,

    Criminal_record = @CriminalRecord,

    License_series = @LicenseSeries,
    License_number = @LicenseNumber,
    Validity_period = @LicenseValidity,

    Token_series = @TokenSeries,
    Token_number = @TokenNumber,

    Service_start_date = @ServiceStartDate

WHERE Employee_id = @EmployeeId;
";

            NpgsqlCommand command =
                new NpgsqlCommand(
                    employeeQuery,
                    connection,
                    transaction);

            command.Parameters.AddWithValue(
    "@SexId",
    Convert.ToInt32(cmbSex.SelectedValue));

            command.Parameters.AddWithValue(
                "@MaritalStatusId",
                Convert.ToInt32(cmbMaritalStatus.SelectedValue));

            command.Parameters.AddWithValue(
                "@PassportIssuanceId",
                Convert.ToInt32(cmbPassportIssuedBy.SelectedValue));

            command.Parameters.AddWithValue(
                "@MilitaryCategoryId",
                Convert.ToInt32(cmbMilitaryCategory.SelectedValue));

            command.Parameters.AddWithValue(
                "@DepartmentId",
                Convert.ToInt32(cmbDepartment.SelectedValue));

            command.Parameters.AddWithValue(
                "@PostId",
                Convert.ToInt32(cmbPost.SelectedValue));

            command.Parameters.AddWithValue(
                "@RankId",
                Convert.ToInt32(cmbRank.SelectedValue));

            command.Parameters.AddWithValue(
                "@EmploymentStatusId",
                Convert.ToInt32(cmbEmploymentStatus.SelectedValue));

            command.Parameters.AddWithValue(
                "@PassportSeries",
                txtPassportSeries.Text);

            command.Parameters.AddWithValue(
                "@PassportNumber",
                txtPassportNumber.Text);

            command.Parameters.AddWithValue(
                "@LastName",
                txtLastName.Text);

            command.Parameters.AddWithValue(
                "@FirstName",
                txtFirstName.Text);

            command.Parameters.AddWithValue(
                "@MiddleName",
                txtMiddleName.Text);

            command.Parameters.AddWithValue(
                "@Phone",
                txtPhone.Text);

            command.Parameters.AddWithValue(
                "@IssueDate",
                dtpIssueDate.Value.Date);

            command.Parameters.AddWithValue(
                "@BirthDate",
                dtpBirthDate.Value.Date);

            command.Parameters.AddWithValue(
                "@RegistrationAddress",
                txtRegistrationAddress.Text);

            command.Parameters.AddWithValue(
                "@ResidentialAddress",
                txtResidentialAddress.Text);

            command.Parameters.AddWithValue(
                "@MilitarySeries",
                txtMilitarySeries.Text);

            command.Parameters.AddWithValue(
                "@MilitaryNumber",
                txtMilitaryNumber.Text);

            command.Parameters.AddWithValue(
                "@Weight",
                decimal.Parse(txtWeight.Text));

            command.Parameters.AddWithValue(
                "@Height",
                int.Parse(txtHeight.Text));

            command.Parameters.AddWithValue(
                "@CriminalRecord",
                chkCriminalRecord.Checked);

            command.Parameters.AddWithValue(
                "@LicenseSeries",
                txtLicenseSeries.Text);

            command.Parameters.AddWithValue(
                "@LicenseNumber",
                txtLicenseNumber.Text);

            command.Parameters.AddWithValue(
                "@LicenseValidity",
                dtpLicenseValidity.Value.Date);

            command.Parameters.AddWithValue(
                "@TokenSeries",
                txtTokenSeries.Text);

            command.Parameters.AddWithValue(
                "@TokenNumber",
                txtTokenNumber.Text);

            command.Parameters.AddWithValue(
                "@ServiceStartDate",
                dtpServiceStartDate.Value.Date);

            command.Parameters.AddWithValue(
                "@EmployeeId",
                employeeId.Value);

            command.ExecuteNonQuery();

            string userQuery =
@"
UPDATE App_user
SET
    User_role_id = @UserRoleId,
    Login_ = @Login,
    Email = @Email
WHERE Employee_id = @EmployeeId;
";

            NpgsqlCommand userCommand =
                new NpgsqlCommand(
                    userQuery,
                    connection,
                    transaction);

            userCommand.Parameters.AddWithValue(
                "@EmployeeId",
                employeeId.Value);

            userCommand.Parameters.AddWithValue(
                "@UserRoleId",
                Convert.ToInt32(
                    cmbUserRole.SelectedValue));

            userCommand.Parameters.AddWithValue(
                "@Login",
                txtLogin.Text);

            userCommand.Parameters.AddWithValue(
                "@Email",
                txtEmail.Text);

            userCommand.ExecuteNonQuery();

            string historyQuery =
@"
INSERT INTO Personnel_history
(
    employee_id,
    event_type,
    event_description
)
VALUES
(
    @EmployeeId,
    @EventType,
    @Description
);
";

            NpgsqlCommand historyCommand =
                new NpgsqlCommand(
                    historyQuery,
                    connection,
                    transaction);

            historyCommand.Parameters.AddWithValue(
                "@EmployeeId",
                employeeId.Value);

            historyCommand.Parameters.AddWithValue(
                "@EventType",
                "Редактирование данных");

            historyCommand.Parameters.AddWithValue(
                "@Description",
                "Изменены данные сотрудника");

            historyCommand.ExecuteNonQuery();
        }
        }
}

