using System;
using System.Globalization;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Squads
{
    public partial class SquadEditForm : Form
    {
        private readonly int squadId;
        private readonly bool editMode;

        private class ComboItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private class CompositionItem
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public string PersonalNotes { get; set; }
        }

        public SquadEditForm()
        {
            InitializeComponent();

            squadId = 0;
            editMode = false;

            ConfigureForm();
            ConfigureControls();
            ConfigureEvents();
            LoadReferenceData();
        }

        public SquadEditForm(int id)
        {
            InitializeComponent();

            squadId = id;
            editMode = true;

            ConfigureForm();
            ConfigureControls();
            ConfigureEvents();
            LoadReferenceData();
            LoadSquadData();
        }

        private void ConfigureForm()
        {
            Text = editMode
                ? "Редактирование наряда"
                : "Создание наряда";

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(900, 900);
        }

        private void ConfigureControls()
        {
            ConfigureComboBox(cmbSquadType);
            ConfigureComboBox(cmbStatus);
            ConfigureComboBox(cmbEmployee);
            ConfigureComboBox(cmbDutyType);
            ConfigureComboBox(cmbMovementType);
            ConfigureComboBox(cmbCrimeRate);

            txtNumberOfPeople.KeyPress += TxtNumberOfPeople_KeyPress;
            txtLength.KeyPress += TxtLength_KeyPress;

            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.CustomFormat = "dd.MM.yyyy HH:mm";
            dtStart.ShowUpDown = true;

            dtEnd.Format = DateTimePickerFormat.Custom;
            dtEnd.CustomFormat = "dd.MM.yyyy HH:mm";
            dtEnd.ShowUpDown = true;

            dtEstimatedTime.Format = DateTimePickerFormat.Custom;
            dtEstimatedTime.CustomFormat = "HH:mm";
            dtEstimatedTime.ShowUpDown = true;

            dgvComposition.AllowUserToAddRows = false;
            dgvComposition.AllowUserToDeleteRows = false;
            dgvComposition.ReadOnly = true;
            dgvComposition.MultiSelect = false;
            dgvComposition.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvComposition.AutoGenerateColumns = false;
            dgvComposition.RowHeadersVisible = false;

            dgvComposition.Columns.Clear();

            DataGridViewTextBoxColumn employeeColumn =
                new DataGridViewTextBoxColumn();

            employeeColumn.Name = "EmployeeName";
            employeeColumn.HeaderText = "Сотрудник";
            employeeColumn.DataPropertyName = "EmployeeName";
            employeeColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn notesColumn =
                new DataGridViewTextBoxColumn();

            notesColumn.Name = "PersonalNotes";
            notesColumn.HeaderText = "Примечание";
            notesColumn.DataPropertyName = "PersonalNotes";
            notesColumn.Width = 230;

            dgvComposition.Columns.Add(employeeColumn);
            dgvComposition.Columns.Add(notesColumn);
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void ConfigureEvents()
        {
            btnAddEmployee.Click += BtnAddEmployee_Click;
            btnRemoveEmployee.Click += BtnRemoveEmployee_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void LoadReferenceData()
        {
            try
            {
                LoadSquadTypes();
                LoadSquadStatuses();
                LoadEmployees();
                LoadDutyTypes();
                LoadMovementTypes();
                LoadCrimeRates();

                if (!editMode)
                    SetDefaultDateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить справочники наряда.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadSquadTypes()
        {
            cmbSquadType.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT squad_type_id, squad_type_name
                    FROM squad_type
                    ORDER BY squad_type_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbSquadType.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["squad_type_id"]),
                                Name = reader[
                                    "squad_type_name"].ToString()
                            });
                    }
                }
            }

            if (cmbSquadType.Items.Count > 0)
                cmbSquadType.SelectedIndex = 0;
        }

        private void LoadSquadStatuses()
        {
            cmbStatus.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT squad_status_id, squad_status_name
                    FROM squad_status
                    ORDER BY squad_status_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbStatus.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["squad_status_id"]),
                                Name = reader[
                                    "squad_status_name"].ToString()
                            });
                    }
                }
            }

            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            cmbEmployee.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT employee_id, last_name, name_, middle_name
                    FROM employee
                    ORDER BY last_name, name_, middle_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fullName =
                            reader["last_name"].ToString() +
                            " " +
                            reader["name_"].ToString();

                        if (reader["middle_name"] != DBNull.Value &&
                            !string.IsNullOrWhiteSpace(
                                reader["middle_name"].ToString()))
                        {
                            fullName +=
                                " " +
                                reader["middle_name"].ToString();
                        }

                        cmbEmployee.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["employee_id"]),
                                Name = fullName
                            });
                    }
                }
            }

            if (cmbEmployee.Items.Count > 0)
                cmbEmployee.SelectedIndex = 0;
        }

        private void LoadDutyTypes()
        {
            cmbDutyType.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT type_of_duty_id, type_of_duty_name
                    FROM type_of_duty
                    ORDER BY type_of_duty_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbDutyType.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["type_of_duty_id"]),
                                Name = reader[
                                    "type_of_duty_name"].ToString()
                            });
                    }
                }
            }

            if (cmbDutyType.Items.Count > 0)
                cmbDutyType.SelectedIndex = 0;
        }

        private void LoadMovementTypes()
        {
            cmbMovementType.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        type_of_movement_id,
                        type_of_movement_name
                    FROM type_of_movement
                    ORDER BY type_of_movement_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbMovementType.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["type_of_movement_id"]),
                                Name = reader[
                                    "type_of_movement_name"].ToString()
                            });
                    }
                }
            }

            if (cmbMovementType.Items.Count > 0)
                cmbMovementType.SelectedIndex = 0;
        }

        private void LoadCrimeRates()
        {
            cmbCrimeRate.Items.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT crime_rate_id, crime_rate_name
                    FROM crime_rate
                    ORDER BY crime_rate_name;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader =
                    command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCrimeRate.Items.Add(
                            new ComboItem
                            {
                                Id = Convert.ToInt32(
                                    reader["crime_rate_id"]),
                                Name = reader[
                                    "crime_rate_name"].ToString()
                            });
                    }
                }
            }

            if (cmbCrimeRate.Items.Count > 0)
                cmbCrimeRate.SelectedIndex = 0;
        }

        private void SetDefaultDateTime()
        {
            DateTime start = DateTime.Now;
            dtStart.Value = start;
            dtEnd.Value = start.AddHours(8);
            dtEstimatedTime.Value =
                DateTime.Today.AddHours(1);
        }

        private void LoadSquadData()
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
                            squad_type_id,
                            squad_status_id,
                            number_of_people
                        FROM squad
                        WHERE squad_id = @squad_id;
                        ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@squad_id", squadId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Наряд не найден.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                Close();
                                return;
                            }

                            SelectComboById(
                                cmbSquadType,
                                Convert.ToInt32(
                                    reader["squad_type_id"]));

                            SelectComboById(
                                cmbStatus,
                                Convert.ToInt32(
                                    reader["squad_status_id"]));

                            txtNumberOfPeople.Text =
                                reader["number_of_people"].ToString();
                        }
                    }
                }

                LoadComposition();
                LoadScheduleAndRoute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные наряда.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadComposition()
        {
            dgvComposition.Rows.Clear();

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query =
                    @"
                    SELECT
                        es.employee_id,
                        e.last_name || ' ' ||
                        e.name_ ||
                        CASE
                            WHEN e.middle_name IS NULL
                                 OR e.middle_name = ''
                            THEN ''
                            ELSE ' ' || e.middle_name
                        END AS employee_name,
                        es.personal_notes
                    FROM employee_squad es
                    INNER JOIN employee e
                        ON es.employee_id = e.employee_id
                    WHERE es.squad_id = @squad_id
                    ORDER BY e.last_name, e.name_;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id", squadId);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvComposition.Rows.Add(
                                reader["employee_name"].ToString(),
                                reader["personal_notes"].ToString());

                            dgvComposition.Rows[
                                dgvComposition.Rows.Count - 1
                            ].Tag =
                                new CompositionItem
                                {
                                    EmployeeId =
                                        Convert.ToInt32(
                                            reader["employee_id"]),
                                    EmployeeName =
                                        reader["employee_name"].ToString(),
                                    PersonalNotes =
                                        reader["personal_notes"].ToString()
                                };
                        }
                    }
                }
            }
        }

        private void LoadScheduleAndRoute()
        {
            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string scheduleQuery =
                    @"
                    SELECT
                        schedule_id,
                        type_of_duty_id,
                        planned_start_date_and_time,
                        planned_end_date_and_time
                    FROM schedule
                    WHERE squad_id = @squad_id
                    ORDER BY planned_start_date_and_time DESC
                    LIMIT 1;
                    ";

                int scheduleId = 0;

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        scheduleQuery,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@squad_id", squadId);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            scheduleId =
                                Convert.ToInt32(
                                    reader["schedule_id"]);

                            SelectComboById(
                                cmbDutyType,
                                Convert.ToInt32(
                                    reader["type_of_duty_id"]));

                            dtStart.Value =
                                Convert.ToDateTime(
                                    reader[
                                        "planned_start_date_and_time"]);

                            dtEnd.Value =
                                Convert.ToDateTime(
                                    reader[
                                        "planned_end_date_and_time"]);
                        }
                    }
                }

                if (scheduleId <= 0)
                    return;

                string routeQuery =
                    @"
                    SELECT
                        type_of_movement_id,
                        crime_rate_id,
                        description,
                        length_of_the_route_km,
                        estimated_time,
                        route
                    FROM patrol_and_post_service
                    WHERE schedule_id = @schedule_id
                    LIMIT 1;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        routeQuery,
                        connection))
                {
                    command.Parameters.AddWithValue(
                        "@schedule_id", scheduleId);

                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return;

                        SelectComboById(
                            cmbMovementType,
                            Convert.ToInt32(
                                reader["type_of_movement_id"]));

                        SelectComboById(
                            cmbCrimeRate,
                            Convert.ToInt32(
                                reader["crime_rate_id"]));

                        txtDescription.Text =
                            reader["description"].ToString();

                        txtLength.Text =
                            reader[
                                "length_of_the_route_km"].ToString();

                        TimeSpan estimated =
                            (TimeSpan)reader["estimated_time"];

                        dtEstimatedTime.Value =
                            DateTime.Today.Add(estimated);

                        txtRoute.Text =
                            reader["route"].ToString();
                    }
                }
            }
        }

        private void BtnAddEmployee_Click(
            object sender,
            EventArgs e)
        {
            ComboItem employee =
                cmbEmployee.SelectedItem as ComboItem;

            if (employee == null)
            {
                MessageBox.Show(
                    "Выберите сотрудника.",
                    "Состав наряда",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row
                in dgvComposition.Rows)
            {
                CompositionItem item =
                    row.Tag as CompositionItem;

                if (item != null &&
                    item.EmployeeId == employee.Id)
                {
                    MessageBox.Show(
                        "Этот сотрудник уже добавлен в состав.",
                        "Состав наряда",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            string notes =
                txtPersonalNotes.Text.Trim();

            if (string.IsNullOrWhiteSpace(notes))
            {
                MessageBox.Show(
                    "Укажите персональное примечание сотрудника.",
                    "Состав наряда",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPersonalNotes.Focus();
                return;
            }

            CompositionItem composition =
                new CompositionItem
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    PersonalNotes = notes
                };

            dgvComposition.Rows.Add(
                composition.EmployeeName,
                composition.PersonalNotes);

            dgvComposition.Rows[
                dgvComposition.Rows.Count - 1
            ].Tag = composition;

            txtPersonalNotes.Clear();
        }

        private void BtnRemoveEmployee_Click(
            object sender,
            EventArgs e)
        {
            if (dgvComposition.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Выберите сотрудника в составе.",
                    "Состав наряда",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dgvComposition.Rows.Remove(
                dgvComposition.SelectedRows[0]);
        }

        private void BtnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (NpgsqlTransaction transaction =
                        connection.BeginTransaction())
                    {
                        int currentSquadId;

                        if (editMode)
                        {
                            UpdateSquad(
                                connection,
                                transaction);

                            currentSquadId = squadId;
                        }
                        else
                        {
                            currentSquadId =
                                InsertSquad(
                                    connection,
                                    transaction);
                        }

                        SaveComposition(
                            connection,
                            transaction,
                            currentSquadId);

                        int scheduleId =
                            SaveSchedule(
                                connection,
                                transaction,
                                currentSquadId);

                        SaveRoute(
                            connection,
                            transaction,
                            scheduleId);

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    editMode
                        ? "Данные наряда успешно обновлены."
                        : "Наряд успешно создан.",
                    "Сохранение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить наряд.\n\n" +
                    ex.Message,
                    "Ошибка сохранения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int InsertSquad(
            NpgsqlConnection connection,
            NpgsqlTransaction transaction)
        {
            string query =
                @"
                INSERT INTO squad
                (
                    squad_type_id,
                    squad_status_id,
                    number_of_people
                )
                VALUES
                (
                    @squad_type_id,
                    @squad_status_id,
                    @number_of_people
                )
                RETURNING squad_id;
                ";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    query,
                    connection,
                    transaction))
            {
                AddSquadParameters(command);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private void UpdateSquad(
            NpgsqlConnection connection,
            NpgsqlTransaction transaction)
        {
            string query =
                @"
                UPDATE squad
                SET
                    squad_type_id = @squad_type_id,
                    squad_status_id = @squad_status_id,
                    number_of_people = @number_of_people
                WHERE squad_id = @squad_id;
                ";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    query,
                    connection,
                    transaction))
            {
                AddSquadParameters(command);

                command.Parameters.AddWithValue(
                    "@squad_id", squadId);

                command.ExecuteNonQuery();
            }
        }

        private void AddSquadParameters(
            NpgsqlCommand command)
        {
            ComboItem squadType =
                cmbSquadType.SelectedItem as ComboItem;

            ComboItem status =
                cmbStatus.SelectedItem as ComboItem;

            command.Parameters.AddWithValue(
                "@squad_type_id", squadType.Id);

            command.Parameters.AddWithValue(
                "@squad_status_id", status.Id);

            command.Parameters.AddWithValue(
                "@number_of_people",
                Convert.ToInt32(
                    txtNumberOfPeople.Text.Trim()));
        }

        private void SaveComposition(
            NpgsqlConnection connection,
            NpgsqlTransaction transaction,
            int currentSquadId)
        {
            string deleteQuery =
                @"
                DELETE FROM employee_squad
                WHERE squad_id = @squad_id;
                ";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    deleteQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@squad_id", currentSquadId);

                command.ExecuteNonQuery();
            }

            string insertQuery =
                @"
                INSERT INTO employee_squad
                (
                    employee_id,
                    squad_id,
                    personal_notes
                )
                VALUES
                (
                    @employee_id,
                    @squad_id,
                    @personal_notes
                );
                ";

            foreach (DataGridViewRow row
                in dgvComposition.Rows)
            {
                CompositionItem item =
                    row.Tag as CompositionItem;

                if (item == null)
                    continue;

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        insertQuery,
                        connection,
                        transaction))
                {
                    command.Parameters.AddWithValue(
                        "@employee_id", item.EmployeeId);

                    command.Parameters.AddWithValue(
                        "@squad_id", currentSquadId);

                    command.Parameters.AddWithValue(
                        "@personal_notes",
                        item.PersonalNotes);

                    command.ExecuteNonQuery();
                }
            }
        }

        private int SaveSchedule(
            NpgsqlConnection connection,
            NpgsqlTransaction transaction,
            int currentSquadId)
        {
            ComboItem duty =
                cmbDutyType.SelectedItem as ComboItem;

            string findQuery =
                @"
                SELECT schedule_id
                FROM schedule
                WHERE squad_id = @squad_id
                ORDER BY planned_start_date_and_time DESC
                LIMIT 1;
                ";

            int scheduleId = 0;

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    findQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@squad_id", currentSquadId);

                object result =
                    command.ExecuteScalar();

                if (result != null &&
                    result != DBNull.Value)
                {
                    scheduleId =
                        Convert.ToInt32(result);
                }
            }

            if (scheduleId > 0)
            {
                string updateQuery =
                    @"
                    UPDATE schedule
                    SET
                        type_of_duty_id = @type_of_duty_id,
                        planned_start_date_and_time =
                            @planned_start,
                        planned_end_date_and_time =
                            @planned_end
                    WHERE schedule_id = @schedule_id;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        updateQuery,
                        connection,
                        transaction))
                {
                    command.Parameters.AddWithValue(
                        "@type_of_duty_id", duty.Id);

                    command.Parameters.AddWithValue(
                        "@planned_start", dtStart.Value);

                    command.Parameters.AddWithValue(
                        "@planned_end", dtEnd.Value);

                    command.Parameters.AddWithValue(
                        "@schedule_id", scheduleId);

                    command.ExecuteNonQuery();
                }

                return scheduleId;
            }

            string insertQuery =
                @"
                INSERT INTO schedule
                (
                    squad_id,
                    type_of_duty_id,
                    planned_start_date_and_time,
                    planned_end_date_and_time
                )
                VALUES
                (
                    @squad_id,
                    @type_of_duty_id,
                    @planned_start,
                    @planned_end
                )
                RETURNING schedule_id;
                ";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    insertQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@squad_id", currentSquadId);

                command.Parameters.AddWithValue(
                    "@type_of_duty_id", duty.Id);

                command.Parameters.AddWithValue(
                    "@planned_start", dtStart.Value);

                command.Parameters.AddWithValue(
                    "@planned_end", dtEnd.Value);

                return Convert.ToInt32(
                    command.ExecuteScalar());
            }
        }

        private void SaveRoute(
            NpgsqlConnection connection,
            NpgsqlTransaction transaction,
            int scheduleId)
        {
            ComboItem movement =
                cmbMovementType.SelectedItem as ComboItem;

            ComboItem crimeRate =
                cmbCrimeRate.SelectedItem as ComboItem;

            TimeSpan estimatedTime =
                dtEstimatedTime.Value.TimeOfDay;

            string findQuery =
                @"
                SELECT patrol_and_post_service_id
                FROM patrol_and_post_service
                WHERE schedule_id = @schedule_id
                LIMIT 1;
                ";

            int routeId = 0;

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    findQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@schedule_id", scheduleId);

                object result =
                    command.ExecuteScalar();

                if (result != null &&
                    result != DBNull.Value)
                {
                    routeId =
                        Convert.ToInt32(result);
                }
            }

            if (routeId > 0)
            {
                string updateQuery =
                    @"
                    UPDATE patrol_and_post_service
                    SET
                        type_of_movement_id =
                            @type_of_movement_id,
                        crime_rate_id =
                            @crime_rate_id,
                        description = @description,
                        length_of_the_route_km = @length,
                        estimated_time = @estimated_time,
                        route = @route
                    WHERE patrol_and_post_service_id =
                          @route_id;
                    ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        updateQuery,
                        connection,
                        transaction))
                {
                    AddRouteParameters(
                        command,
                        movement,
                        crimeRate,
                        estimatedTime);

                    command.Parameters.AddWithValue(
                        "@route_id", routeId);

                    command.ExecuteNonQuery();
                }

                return;
            }

            string insertQuery =
                @"
                INSERT INTO patrol_and_post_service
                (
                    schedule_id,
                    type_of_movement_id,
                    crime_rate_id,
                    description,
                    length_of_the_route_km,
                    estimated_time,
                    route
                )
                VALUES
                (
                    @schedule_id,
                    @type_of_movement_id,
                    @crime_rate_id,
                    @description,
                    @length,
                    @estimated_time,
                    @route
                );
                ";

            using (NpgsqlCommand command =
                new NpgsqlCommand(
                    insertQuery,
                    connection,
                    transaction))
            {
                command.Parameters.AddWithValue(
                    "@schedule_id", scheduleId);

                AddRouteParameters(
                    command,
                    movement,
                    crimeRate,
                    estimatedTime);

                command.ExecuteNonQuery();
            }
        }

        private void AddRouteParameters(
            NpgsqlCommand command,
            ComboItem movement,
            ComboItem crimeRate,
            TimeSpan estimatedTime)
        {
            decimal length;

            if (!decimal.TryParse(
                txtLength.Text.Trim().Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out length))
            {
                length = 0;
            }

            command.Parameters.AddWithValue(
                "@type_of_movement_id", movement.Id);

            command.Parameters.AddWithValue(
                "@crime_rate_id", crimeRate.Id);

            command.Parameters.AddWithValue(
                "@description",
                txtDescription.Text.Trim());

            command.Parameters.AddWithValue(
                "@length", length);

            command.Parameters.AddWithValue(
                "@estimated_time", estimatedTime);

            command.Parameters.AddWithValue(
                "@route",
                txtRoute.Text.Trim());
        }

        private bool ValidateForm()
        {
            if (cmbSquadType.SelectedItem == null)
            {
                ShowValidation(
                    "Выберите тип наряда.",
                    cmbSquadType);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                ShowValidation(
                    "Выберите статус наряда.",
                    cmbStatus);
                return false;
            }

            int numberOfPeople;

            if (!int.TryParse(
                txtNumberOfPeople.Text.Trim(),
                out numberOfPeople) ||
                numberOfPeople <= 0 ||
                numberOfPeople > 32767)
            {
                ShowValidation(
                    "Количество сотрудников должно быть от 1 до 32767.",
                    txtNumberOfPeople);
                return false;
            }

            if (dgvComposition.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Добавьте хотя бы одного сотрудника в состав наряда.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (dgvComposition.Rows.Count > numberOfPeople)
            {
                MessageBox.Show(
                    "Количество сотрудников в составе не может быть больше указанного количества.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (cmbDutyType.SelectedItem == null)
            {
                ShowValidation(
                    "Выберите тип дежурства.",
                    cmbDutyType);
                return false;
            }

            if (dtEnd.Value <= dtStart.Value)
            {
                MessageBox.Show(
                    "Время окончания графика должно быть позже времени начала.",
                    "Проверка графика",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMovementType.SelectedItem == null)
            {
                ShowValidation(
                    "Выберите тип передвижения.",
                    cmbMovementType);
                return false;
            }

            if (cmbCrimeRate.SelectedItem == null)
            {
                ShowValidation(
                    "Выберите уровень криминогенности.",
                    cmbCrimeRate);
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtDescription.Text))
            {
                ShowValidation(
                    "Заполните описание маршрута.",
                    txtDescription);
                return false;
            }

            decimal length;

            if (!decimal.TryParse(
                txtLength.Text.Trim().Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out length) ||
                length <= 0 ||
                length > 999.99m)
            {
                ShowValidation(
                    "Протяженность маршрута должна быть больше 0 и не превышать 999,99 км.",
                    txtLength);
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtRoute.Text))
            {
                ShowValidation(
                    "Заполните маршрут.",
                    txtRoute);
                return false;
            }

            return true;
        }

        private void ShowValidation(
            string message,
            Control control)
        {
            MessageBox.Show(
                message,
                "Проверка данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            control.Focus();
        }

        private void SelectComboById(
            ComboBox comboBox,
            int id)
        {
            for (int i = 0;
                 i < comboBox.Items.Count;
                 i++)
            {
                ComboItem item =
                    comboBox.Items[i] as ComboItem;

                if (item != null &&
                    item.Id == id)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }
        }

        private void TxtNumberOfPeople_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtLength_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) ||
                char.IsDigit(e.KeyChar))
                return;

            if ((e.KeyChar == ',' ||
                 e.KeyChar == '.') &&
                !txtLength.Text.Contains(",") &&
                !txtLength.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void BtnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}