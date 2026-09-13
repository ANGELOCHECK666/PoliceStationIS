using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Cases
{
    public partial class TransferToCourtForm : Form
    {
        private readonly int caseId;

        public TransferToCourtForm(int id)
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
            Text = "Передача дела в суд";
            lblTitle.Text = "Передача дела в суд";
            lblTargetStatus.Text = "Передано в суд";
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

                    string query =
                        @"UPDATE criminal_case
                          SET
                              case_status_id = (
                                  SELECT case_status_id
                                  FROM case_status
                                  WHERE case_status_name =
                                        'Передано в суд'
                              ),
                              last_update_date = CURRENT_DATE
                          WHERE criminal_case_id = @id;";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@id",
                            caseId);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Дело успешно передано в суд.",
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
                "Передано в суд")
            {
                MessageBox.Show(
                    "Для этого дела уже установлен статус «Передано в суд».",
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