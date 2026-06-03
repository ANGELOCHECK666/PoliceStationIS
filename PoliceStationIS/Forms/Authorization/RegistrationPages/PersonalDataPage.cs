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
    public partial class PersonalDataPage : UserControl
    {
        private MonthCalendar calendar;
        public PersonalDataPage()
        {
            InitializeComponent();

            calendar = new MonthCalendar();

            calendar.Visible = false;

            calendar.MaxSelectionCount = 1;

            calendar.DateSelected += Calendar_DateSelected;

            this.Controls.Add(calendar);

            btnCalendar.Click += BtnCalendar_Click;

            LoadGenders();
            LoadDepartments();
            LoadPositions();
            LoadRanks();
        }
        private void LoadGenders()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT sex_id, sex_name FROM sex";

                using (var command =
                       new NpgsqlCommand(query, connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbGender.Items.Add(
                                reader["sex_name"].ToString());
                        }
                    }
                }
            }
        }
        private void LoadDepartments()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT department_name FROM department ORDER BY department_name";

                using (var command =
                       new NpgsqlCommand(query, connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDepartment.Items.Add(
                                reader["department_name"].ToString());
                        }
                    }
                }
            }
        }
        private void LoadPositions()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT post_name FROM post ORDER BY post_name";

                using (var command =
                       new NpgsqlCommand(query, connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbPosition.Items.Add(
                                reader["post_name"].ToString());
                        }
                    }
                }
            }
        }
        private void LoadRanks()
        {
            using (var connection =
                   DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    "SELECT rank_name FROM rank_ ORDER BY rank_id";

                using (var command =
                       new NpgsqlCommand(query, connection))
                {
                    using (var reader =
                           command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbRank.Items.Add(
                                reader["rank_name"].ToString());
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
                    btnCalendar.Left,
                    btnCalendar.Bottom + 5);

            calendar.Visible =
                !calendar.Visible;
        }

        private void Calendar_DateSelected(
            object sender,
            DateRangeEventArgs e)
        {
            txtBirthDate.Text =
                e.Start.ToString(
                    "dd.MM.yyyy");

            calendar.Visible = false;
        }
    }
}