using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Npgsql;
using NpgsqlTypes;

using PoliceStationIS.Database;

namespace PoliceStationIS.Forms.Evidence
{
    public partial class EvidenceEditForm : Form
    {
        // =========================================================
        // РЕЖИМ ФОРМЫ
        // =========================================================

        private readonly int? evidenceId;

        // =========================================================
        // ФОТОГРАФИЯ
        // =========================================================

        private byte[] evidenceImageBytes;

        private bool imageChanged = false;

        // =========================================================
        // КОНСТРУКТОР — ДОБАВЛЕНИЕ
        // =========================================================

        public EvidenceEditForm()
        {
            InitializeComponent();

            evidenceId = null;

            lblTitle.Text =
                "ДОБАВЛЕНИЕ ДОКАЗАТЕЛЬСТВА";

            lblSubtitle.Text =
                "Добавление нового вещественного доказательства";

            dtDateOfSeizure.MinDate =
    DateTimePicker.MinimumDateTime;

            dtDateOfSeizure.MaxDate =
                DateTime.Today;

            dtDateOfSeizure.Value =
                DateTime.Today;

            LoadStatuses();
        }

        // =========================================================
        // КОНСТРУКТОР — РЕДАКТИРОВАНИЕ
        // =========================================================

        public EvidenceEditForm(int evidenceId)
        {
            InitializeComponent();

            this.evidenceId =
                evidenceId;

            lblTitle.Text =
                "РЕДАКТИРОВАНИЕ ДОКАЗАТЕЛЬСТВА";

            lblSubtitle.Text =
                "Изменение данных вещественного доказательства";

            LoadStatuses();

            LoadEvidence();
        }

        // =========================================================
        // ЗАГРУЗКА СТАТУСОВ
        // =========================================================

        private void LoadStatuses()
        {
            try
            {
                cmbEvidenceStatus.Items.Clear();

                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            evidence_status_id,
                            evidence_status_name
                        FROM Evidence_status
                        ORDER BY evidence_status_id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbEvidenceStatus.Items.Add(
                                    new EvidenceStatusItem
                                    {
                                        Id =
                                            Convert.ToInt32(
                                                reader[
                                                    "evidence_status_id"]),

                                        Name =
                                            reader[
                                                "evidence_status_name"]
                                            .ToString()
                                    });
                            }
                        }
                    }
                }

                cmbEvidenceStatus.DisplayMember =
                    "Name";

                cmbEvidenceStatus.ValueMember =
                    "Id";

                if (cmbEvidenceStatus.Items.Count > 0 &&
                    evidenceId == null)
                {
                    cmbEvidenceStatus.SelectedIndex =
                        0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить статусы доказательств.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ЗАГРУЗКА СУЩЕСТВУЮЩЕГО ДОКАЗАТЕЛЬСТВА
        // =========================================================

        private void LoadEvidence()
        {
            if (evidenceId == null)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            evidence_number,
                            evidence_name,
                            evidence_status_id,
                            date_of_seizure,
                            storage_location,
                            description_evidence,
                            evidence_image
                        FROM Evidence
                        WHERE evidence_id = @evidence_id;
                    ";

                    using (NpgsqlCommand command =
                        new NpgsqlCommand(
                            query,
                            connection))
                    {
                        command.Parameters.Add(
                            "@evidence_id",
                            NpgsqlDbType.Integer);

                        command.Parameters[
                            "@evidence_id"].Value =
                            evidenceId.Value;

                        using (NpgsqlDataReader reader =
                            command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Доказательство не найдено.",
                                    "Ошибка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                DialogResult =
                                    DialogResult.Cancel;

                                Close();

                                return;
                            }

                            // -----------------------------------------
                            // ОСНОВНЫЕ ДАННЫЕ
                            // -----------------------------------------

                            txtEvidenceNumber.Text =
                                reader[
                                    "evidence_number"]
                                .ToString()
                                .Trim();

                            txtEvidenceName.Text =
                                reader[
                                    "evidence_name"]
                                .ToString()
                                .Trim();

                            txtStorageLocation.Text =
                                reader[
                                    "storage_location"]
                                .ToString()
                                .Trim();

                            txtDescription.Text =
                                reader[
                                    "description_evidence"]
                                .ToString();

                            if (reader[
                                "date_of_seizure"] !=
                                DBNull.Value)
                            {
                                dtDateOfSeizure.Value =
                                    Convert.ToDateTime(
                                        reader[
                                            "date_of_seizure"]);
                            }

                            // -----------------------------------------
                            // СТАТУС
                            // -----------------------------------------

                            int statusId =
                                Convert.ToInt32(
                                    reader[
                                        "evidence_status_id"]);

                            for (int i = 0;
                                 i < cmbEvidenceStatus.Items.Count;
                                 i++)
                            {
                                EvidenceStatusItem item =
                                    cmbEvidenceStatus.Items[i]
                                    as EvidenceStatusItem;

                                if (item != null &&
                                    item.Id == statusId)
                                {
                                    cmbEvidenceStatus
                                        .SelectedIndex = i;

                                    break;
                                }
                            }

                            // -----------------------------------------
                            // ФОТОГРАФИЯ
                            // -----------------------------------------

                            if (reader[
                                "evidence_image"] !=
                                DBNull.Value)
                            {
                                evidenceImageBytes =
                                    (byte[])reader[
                                        "evidence_image"];

                                ShowImage(
                                    evidenceImageBytes);
                            }
                            else
                            {
                                evidenceImageBytes =
                                    null;

                                picEvidence.Image =
                                    null;
                            }

                            imageChanged =
                                false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить данные доказательства.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ВЫБОР ФОТОГРАФИИ
        // =========================================================

        private void btnChoosePhoto_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog dialog =
                new OpenFileDialog())
            {
                dialog.Title =
                    "Выберите фотографию доказательства";

                dialog.Filter =
                    "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|" +
                    "*.jpg;*.jpeg;*.png;*.bmp";

                dialog.Multiselect =
                    false;

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                {
                    return;
                }

                try
                {
                    byte[] bytes =
                        File.ReadAllBytes(
                            dialog.FileName);

                    using (MemoryStream stream =
                        new MemoryStream(bytes))
                    {
                        using (Image tempImage =
                            Image.FromStream(stream))
                        {
                            if (picEvidence.Image != null)
                            {
                                picEvidence.Image.Dispose();

                                picEvidence.Image =
                                    null;
                            }

                            picEvidence.Image =
                                new Bitmap(
                                    tempImage);
                        }
                    }

                    evidenceImageBytes =
                        bytes;

                    imageChanged =
                        true;

                    lblPhotoHint.Text =
                        Path.GetFileName(
                            dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось загрузить изображение.\n\n" +
                        ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================
        // УДАЛЕНИЕ ФОТОГРАФИИ
        // =========================================================

        private void btnRemovePhoto_Click(
            object sender,
            EventArgs e)
        {
            if (picEvidence.Image != null)
            {
                picEvidence.Image.Dispose();

                picEvidence.Image =
                    null;
            }

            evidenceImageBytes =
                null;

            imageChanged =
                true;

            lblPhotoHint.Text =
                "Фотография не выбрана";
        }

        // =========================================================
        // ПОКАЗ ФОТОГРАФИИ
        // =========================================================

        private void ShowImage(
            byte[] imageBytes)
        {
            if (imageBytes == null ||
                imageBytes.Length == 0)
            {
                picEvidence.Image =
                    null;

                lblPhotoHint.Text =
                    "Фотография не выбрана";

                return;
            }

            try
            {
                using (MemoryStream stream =
                    new MemoryStream(
                        imageBytes))
                {
                    using (Image tempImage =
                        Image.FromStream(stream))
                    {
                        if (picEvidence.Image != null)
                        {
                            picEvidence.Image.Dispose();

                            picEvidence.Image =
                                null;
                        }

                        picEvidence.Image =
                            new Bitmap(
                                tempImage);
                    }
                }

                lblPhotoHint.Text =
                    "Фотография загружена из БД";
            }
            catch
            {
                picEvidence.Image =
                    null;

                lblPhotoHint.Text =
                    "Не удалось открыть фотографию";
            }
        }

        // =========================================================
        // СОХРАНЕНИЕ
        // =========================================================

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            try
            {
                if (evidenceId == null)
                {
                    InsertEvidence();
                }
                else
                {
                    UpdateEvidence();
                }

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show(
                        "Доказательство с таким номером уже существует.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtEvidenceNumber.Focus();

                    return;
                }

                MessageBox.Show(
                    "Ошибка PostgreSQL:\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось сохранить доказательство.\n\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ДОБАВЛЕНИЕ
        // =========================================================

        private void InsertEvidence()
        {
            EvidenceStatusItem status =
                cmbEvidenceStatus.SelectedItem
                as EvidenceStatusItem;

            if (status == null)
            {
                throw new Exception(
                    "Не выбран статус доказательства.");
            }

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query = @"
                    INSERT INTO Evidence
                    (
                        evidence_status_id,
                        evidence_number,
                        evidence_name,
                        description_evidence,
                        date_of_seizure,
                        storage_location,
                        evidence_image
                    )
                    VALUES
                    (
                        @status_id,
                        @evidence_number,
                        @evidence_name,
                        @description,
                        @date_of_seizure,
                        @storage_location,
                        @evidence_image
                    );
                ";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.Add(
                        "@status_id",
                        NpgsqlDbType.Integer)
                        .Value =
                        status.Id;

                    command.Parameters.Add(
                        "@evidence_number",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtEvidenceNumber.Text.Trim();

                    command.Parameters.Add(
                        "@evidence_name",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtEvidenceName.Text.Trim();

                    command.Parameters.Add(
                        "@description",
                        NpgsqlDbType.Text)
                        .Value =
                        txtDescription.Text.Trim();

                    command.Parameters.Add(
                        "@date_of_seizure",
                        NpgsqlDbType.Date)
                        .Value =
                        dtDateOfSeizure.Value.Date;

                    command.Parameters.Add(
                        "@storage_location",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtStorageLocation.Text.Trim();

                    NpgsqlParameter imageParameter =
                        command.Parameters.Add(
                            "@evidence_image",
                            NpgsqlDbType.Bytea);

                    imageParameter.Value =
                        evidenceImageBytes != null
                            ? (object)evidenceImageBytes
                            : DBNull.Value;

                    command.ExecuteNonQuery();
                }
            }
        }

        // =========================================================
        // РЕДАКТИРОВАНИЕ
        // =========================================================

        private void UpdateEvidence()
        {
            EvidenceStatusItem status =
                cmbEvidenceStatus.SelectedItem
                as EvidenceStatusItem;

            if (status == null)
            {
                throw new Exception(
                    "Не выбран статус доказательства.");
            }

            using (NpgsqlConnection connection =
                DatabaseConnection.GetConnection())
            {
                connection.Open();

                string query;

                if (imageChanged)
                {
                    query = @"
                        UPDATE Evidence
                        SET
                            evidence_status_id =
                                @status_id,

                            evidence_number =
                                @evidence_number,

                            evidence_name =
                                @evidence_name,

                            description_evidence =
                                @description,

                            date_of_seizure =
                                @date_of_seizure,

                            storage_location =
                                @storage_location,

                            evidence_image =
                                @evidence_image

                        WHERE evidence_id =
                            @evidence_id;
                    ";
                }
                else
                {
                    query = @"
                        UPDATE Evidence
                        SET
                            evidence_status_id =
                                @status_id,

                            evidence_number =
                                @evidence_number,

                            evidence_name =
                                @evidence_name,

                            description_evidence =
                                @description,

                            date_of_seizure =
                                @date_of_seizure,

                            storage_location =
                                @storage_location

                        WHERE evidence_id =
                            @evidence_id;
                    ";
                }

                using (NpgsqlCommand command =
                    new NpgsqlCommand(
                        query,
                        connection))
                {
                    command.Parameters.Add(
                        "@status_id",
                        NpgsqlDbType.Integer)
                        .Value =
                        status.Id;

                    command.Parameters.Add(
                        "@evidence_number",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtEvidenceNumber.Text.Trim();

                    command.Parameters.Add(
                        "@evidence_name",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtEvidenceName.Text.Trim();

                    command.Parameters.Add(
                        "@description",
                        NpgsqlDbType.Text)
                        .Value =
                        txtDescription.Text.Trim();

                    command.Parameters.Add(
                        "@date_of_seizure",
                        NpgsqlDbType.Date)
                        .Value =
                        dtDateOfSeizure.Value.Date;

                    command.Parameters.Add(
                        "@storage_location",
                        NpgsqlDbType.Varchar)
                        .Value =
                        txtStorageLocation.Text.Trim();

                    if (imageChanged)
                    {
                        NpgsqlParameter imageParameter =
                            command.Parameters.Add(
                                "@evidence_image",
                                NpgsqlDbType.Bytea);

                        imageParameter.Value =
                            evidenceImageBytes != null
                                ? (object)evidenceImageBytes
                                : DBNull.Value;
                    }

                    command.Parameters.Add(
                        "@evidence_id",
                        NpgsqlDbType.Integer)
                        .Value =
                        evidenceId.Value;

                    int rowsAffected =
                        command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception(
                            "Доказательство не найдено или уже было удалено.");
                    }
                }
            }
        }

        // =========================================================
        // ПРОВЕРКА ПОЛЕЙ
        // =========================================================

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(
                txtEvidenceNumber.Text))
            {
                MessageBox.Show(
                    "Введите номер доказательства.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEvidenceNumber.Focus();

                return false;
            }

            if (txtEvidenceNumber.Text.Trim().Length >
                4)
            {
                MessageBox.Show(
                    "Номер доказательства не может содержать более 4 символов.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEvidenceNumber.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtEvidenceName.Text))
            {
                MessageBox.Show(
                    "Введите название доказательства.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEvidenceName.Focus();

                return false;
            }

            if (cmbEvidenceStatus.SelectedItem ==
                null)
            {
                MessageBox.Show(
                    "Выберите статус доказательства.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEvidenceStatus.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtStorageLocation.Text))
            {
                MessageBox.Show(
                    "Введите место хранения.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStorageLocation.Focus();

                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtDescription.Text))
            {
                MessageBox.Show(
                    "Введите описание доказательства.",
                    "Проверка данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescription.Focus();

                return false;
            }

            return true;
        }

        // =========================================================
        // ОТМЕНА
        // =========================================================

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }

        // =========================================================
        // ОСВОБОЖДЕНИЕ ФОТОГРАФИИ
        // =========================================================

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            if (picEvidence != null &&
                picEvidence.Image != null)
            {
                picEvidence.Image.Dispose();

                picEvidence.Image =
                    null;
            }

            base.OnFormClosed(e);
        }
    }

    // =============================================================
    // ЭЛЕМЕНТ COMBOBOX ДЛЯ СТАТУСА
    // =============================================================

    public class EvidenceStatusItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}