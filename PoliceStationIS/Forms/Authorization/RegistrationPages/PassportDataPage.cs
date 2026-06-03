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

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class PassportDataPage : UserControl
    {
        private MonthCalendar calendar;
        public PassportDataPage()
        {
            InitializeComponent();

            calendar = new MonthCalendar();

            calendar.Visible = false;

            calendar.MaxSelectionCount = 1;

            calendar.DateSelected +=
                Calendar_DateSelected;

            this.Controls.Add(calendar);

            btnCalendar.Click +=
                BtnCalendar_Click;

            LoadDepartmentCodes();
            LoadIssuedBy();
        }
        private void LoadDepartmentCodes()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"SELECT Code
              FROM Passport_issuance
              ORDER BY Code";

                using (var command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDepartmentCode.Items.Add(
                                reader["Code"].ToString());
                        }
                    }
                }
            }
        }
        private void LoadIssuedBy()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"SELECT Passport_issuance_name
              FROM Passport_issuance
              ORDER BY Passport_issuance_name";

                using (var command =
                       new NpgsqlCommand(
                           query,
                           connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbIssuedBy.Items.Add(
                                reader["Passport_issuance_name"]
                                    .ToString());
                        }
                    }
                }
            }
        }
        private void BtnCalendar_Click(
    object sender,
    EventArgs e)
        {
            calendar.Location =
    new Point(
        btnCalendar.Left - 20,
        btnCalendar.Top - 160);
            calendar.BringToFront();

            calendar.Visible =
                !calendar.Visible;
        }

        private void Calendar_DateSelected(
            object sender,
            DateRangeEventArgs e)
        {
            txtIssueDate.Text =
                e.Start.ToString(
                    "dd.MM.yyyy");

            calendar.Visible = false;
        }
    }
}
