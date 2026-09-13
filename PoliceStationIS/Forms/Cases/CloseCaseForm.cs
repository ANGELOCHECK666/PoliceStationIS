using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Cases
{
    public partial class CloseCaseForm : Form
    {
        private readonly int caseId;

        public CloseCaseForm(int id)
        {
            caseId = id;

            InitializeComponent();
            ConfigureForm();
            LoadCase();
        }

        private void ConfigureForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(5, 24, 58);
            Text = "Закрытие дела";
            lblTitle.Text = "Закрытие дела";
            lblTargetStatus.Text = "Закрыто";
        }

        private void LoadCase()
        {
            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query =
                        @"SELECT
                            cc.case_number,
                            cs.case_status_name
                          FROM criminal_case cc
                          INNER JOIN case_status cs
                              ON cs.case_status_id =
                                 cc.case_status_id
                          WHERE cc.criminal_case_id = @id;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            caseId);

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Дело не найдено.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                DialogResult =
                                    DialogResult.Cancel;
                                Close();
                                return;
                            }

                            lblCaseNumberValue.Text =
                                reader["case_number"]
                                    .ToString()
                                    .Trim();

                            lblCurrentStatusValue.Text =
                                reader["case_status_name"]
                                    .ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка загрузки дела",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                DialogResult =
                    DialogResult.Cancel;
                Close();
            }
        }

        private void BtnConfirm_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateAction())
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
                        string closeQuery =
                            @"CALL pr_close_case(@id);";

                        using (NpgsqlCommand command =
                            new NpgsqlCommand(
                                closeQuery,
                                connection,
                                transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@id",
                                caseId);

                            command.ExecuteNonQuery();
                        }

                        string updateQuery =
                            @"UPDATE criminal_case
                              SET last_update_date = CURRENT_DATE
                              WHERE criminal_case_id = @id;";

                        using (NpgsqlCommand command =
                            new NpgsqlCommand(
                                updateQuery,
                                connection,
                                transaction))
                        {
                            command.Parameters.AddWithValue(
                                "@id",
                                caseId);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show(
                    "Дело успешно закрыто.",
                    "Готово",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Ошибка изменения статуса",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка изменения статуса",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateAction()
        {
            if (string.IsNullOrWhiteSpace(
                lblCaseNumberValue.Text))
            {
                MessageBox.Show(
                    "Не удалось определить дело.",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (lblCurrentStatusValue.Text ==
                "Закрыто")
            {
                MessageBox.Show(
                    "Для этого дела уже установлен статус «Закрыто».",
                    "Проверка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            return true;
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