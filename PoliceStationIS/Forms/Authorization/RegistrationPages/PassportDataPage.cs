using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class PassportDataPage : UserControl
    {
        public string PassportSeries =>
            txtPassportSeries.Text.Trim();

        public string PassportNumber =>
            txtPassportNumber.Text.Trim();

        public string DepartmentCode =>
            cmbDepartmentCode.Text.Trim();

        public string IssuedBy =>
            cmbIssuedBy.Text.Trim();

        public string IssueDate =>
            txtIssueDate.Text.Trim();

        public string RegistrationAddress =>
            txtRegistrationAddress.Text.Trim();

        private MonthCalendar calendar;

        public PassportDataPage()
        {
            InitializeComponent();

            calendar = new MonthCalendar();
            calendar.Visible = false;
            calendar.MaxSelectionCount = 1;
            calendar.DateSelected += Calendar_DateSelected;

            Controls.Add(calendar);

            btnCalendar.Click += BtnCalendar_Click;

            txtPassportSeries.Leave += TxtPassportSeries_Leave;
            txtPassportNumber.Leave += TxtPassportNumber_Leave;
            cmbDepartmentCode.Leave += CmbDepartmentCode_Leave;
            cmbIssuedBy.Leave += CmbIssuedBy_Leave;
            txtIssueDate.Leave += TxtIssueDate_Leave;
            txtRegistrationAddress.Leave += TxtRegistrationAddress_Leave;

            LoadDepartmentCodes();
            LoadIssuedBy();
        }

        private void LoadDepartmentCodes()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    @"SELECT Code
                          FROM Passport_issuance
                          ORDER BY Code";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbDepartmentCode.Items.Add(
                            reader["Code"].ToString());
                    }
                }
            }
        }

        private void LoadIssuedBy()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                const string query =
                    @"SELECT Passport_issuance_name
                          FROM Passport_issuance
                          ORDER BY Passport_issuance_name";

                using (var command = new NpgsqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbIssuedBy.Items.Add(
                            reader["Passport_issuance_name"].ToString());
                    }
                }
            }
        }

        private void TxtPassportSeries_Leave(object sender, EventArgs e)
        {
            txtPassportSeries.Text = txtPassportSeries.Text.Trim();

            if (!ValidationHelper.IsValidPassportSeries(
                    txtPassportSeries.Text))
            {
                MessageBox.Show(
                    "Серия паспорта должна содержать 4 цифры.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassportSeries.Focus();
            }
        }

        private void TxtPassportNumber_Leave(object sender, EventArgs e)
        {
            txtPassportNumber.Text = txtPassportNumber.Text.Trim();

            if (!ValidationHelper.IsValidPassportNumber(
                    txtPassportNumber.Text))
            {
                MessageBox.Show(
                    "Номер паспорта должен содержать 6 цифр.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassportNumber.Focus();
            }
        }

        private void CmbDepartmentCode_Leave(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsFilled(cmbDepartmentCode.Text))
            {
                MessageBox.Show(
                    "Выберите код подразделения.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbDepartmentCode.Focus();
            }
        }

        private void CmbIssuedBy_Leave(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsFilled(cmbIssuedBy.Text))
            {
                MessageBox.Show(
                    "Выберите, кем выдан паспорт.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbIssuedBy.Focus();
            }
        }

        private void TxtIssueDate_Leave(object sender, EventArgs e)
        {
            if (!DateTime.TryParseExact(
                    txtIssueDate.Text.Trim(),
                    "dd.MM.yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime issueDate))
            {
                MessageBox.Show(
                    "Введите корректную дату выдачи паспорта.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtIssueDate.Focus();
                return;
            }

            if (issueDate.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "Дата выдачи паспорта не может быть будущей.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtIssueDate.Focus();
            }
        }

        private void TxtRegistrationAddress_Leave(
            object sender,
            EventArgs e)
        {
            txtRegistrationAddress.Text =
                txtRegistrationAddress.Text.Trim();

            if (!ValidationHelper.IsFilled(
                    txtRegistrationAddress.Text))
            {
                MessageBox.Show(
                    "Введите адрес регистрации.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtRegistrationAddress.Focus();
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
            txtIssueDate.Text =
                e.Start.ToString("dd.MM.yyyy");

            calendar.Visible = false;
        }
    }
}
