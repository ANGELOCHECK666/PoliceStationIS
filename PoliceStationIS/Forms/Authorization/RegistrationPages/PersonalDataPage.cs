using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class PersonalDataPage : UserControl
    {
        public string LastName =>
            txtSurname.Text.Trim();

        public string FirstName =>
            txtName.Text.Trim();

        public string MiddleName =>
            txtPatronymic.Text.Trim();

        public string BirthDate =>
            txtBirthDate.Text.Trim();

        public string Gender =>
            cmbGender.Text.Trim();

        public string Position =>
            cmbPosition.Text.Trim();

        public string Department =>
            cmbDepartment.Text.Trim();

        public string Rank =>
            cmbRank.Text.Trim();

        private MonthCalendar calendar;

        public PersonalDataPage()
        {
            InitializeComponent();

            calendar = new MonthCalendar();
            calendar.Visible = false;
            calendar.MaxSelectionCount = 1;
            calendar.DateSelected += Calendar_DateSelected;

            Controls.Add(calendar);

            btnCalendar.Click += BtnCalendar_Click;

            txtSurname.Leave += TxtSurname_Leave;
            txtName.Leave += TxtName_Leave;
            txtPatronymic.Leave += TxtPatronymic_Leave;
            txtBirthDate.Leave += TxtBirthDate_Leave;

            cmbGender.Leave += CmbRequiredCombo_Leave;
            cmbDepartment.Leave += CmbRequiredCombo_Leave;
            cmbPosition.Leave += CmbRequiredCombo_Leave;
            cmbRank.Leave += CmbRequiredCombo_Leave;

            LoadGenders();
            LoadDepartments();
            LoadPositions();
            LoadRanks();
        }

        private void TxtSurname_Leave(object sender, EventArgs e)
        {
            ValidateNameField(txtSurname, "фамилию");
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            ValidateNameField(txtName, "имя");
        }

        private void TxtPatronymic_Leave(object sender, EventArgs e)
        {
            txtPatronymic.Text = txtPatronymic.Text.Trim();

            // Отчество в RegistrationService допускается пустым,
            // поэтому здесь не делаем его обязательным.
            if (ValidationHelper.IsFilled(txtPatronymic.Text) &&
                !ValidationHelper.IsValidName(txtPatronymic.Text))
            {
                MessageBox.Show(
                    "Введите корректное отчество.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPatronymic.Focus();
            }
        }

        private void ValidateNameField(
            TextBox textBox,
            string fieldName)
        {
            textBox.Text = textBox.Text.Trim();

            if (!ValidationHelper.IsFilled(textBox.Text))
            {
                MessageBox.Show(
                    $"Введите {fieldName}.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox.Focus();
                return;
            }

            if (!ValidationHelper.IsValidName(textBox.Text))
            {
                MessageBox.Show(
                    $"Введите корректные {fieldName}.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox.Focus();
            }
        }

        private void TxtBirthDate_Leave(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(
                    txtBirthDate.Text.Trim(),
                    "dd.MM.yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime birthDate))
            {
                MessageBox.Show(
                    "Введите корректную дату рождения.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBirthDate.Focus();
                return;
            }

            if (birthDate.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "Дата рождения не может быть будущей.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtBirthDate.Focus();
            }
        }

        private void CmbRequiredCombo_Leave(
            object sender,
            EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox == null ||
                ValidationHelper.IsFilled(comboBox.Text))
            {
                return;
            }

            MessageBox.Show(
                "Выберите значение из списка.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            comboBox.Focus();
        }

        private void LoadGenders()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    "SELECT sex_id, sex_name FROM sex";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbGender.Items.Add(
                            reader["sex_name"].ToString());
                    }
                }
            }
        }

        private void LoadDepartments()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    "SELECT department_name " +
                    "FROM department " +
                    "ORDER BY department_name";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbDepartment.Items.Add(
                            reader["department_name"].ToString());
                    }
                }
            }
        }

        private void LoadPositions()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    "SELECT post_name FROM post ORDER BY post_name";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbPosition.Items.Add(
                            reader["post_name"].ToString());
                    }
                }
            }
        }

        private void LoadRanks()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    "SELECT rank_name FROM rank_ ORDER BY rank_id";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbRank.Items.Add(
                            reader["rank_name"].ToString());
                    }
                }
            }
        }

        private void BtnCalendar_Click(object sender, EventArgs e)
        {
            calendar.Location = new Point(
                btnCalendar.Left - 20,
                btnCalendar.Top - 160);

            calendar.BringToFront();
            calendar.Visible = !calendar.Visible;
        }

        private void Calendar_DateSelected(
            object sender,
            DateRangeEventArgs e)
        {
            txtBirthDate.Text =
                e.Start.ToString("dd.MM.yyyy");

            calendar.Visible = false;
        }
    }
}
