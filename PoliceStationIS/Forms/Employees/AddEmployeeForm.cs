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

namespace PoliceStationIS.Forms.Employees
{
    public partial class AddEmployeeForm : Form
    {

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

                int employeeId =
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
                    employeeId);

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
    }
}

