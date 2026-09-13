using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Evidence
{
    partial class EvidenceEditForm
    {
        private System.ComponentModel.IContainer components = null;

        // =========================================================
        // ОСНОВНЫЕ ПАНЕЛИ
        // =========================================================

        private Panel pnlMain;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Panel pnlPhoto;

        // =========================================================
        // ЗАГОЛОВОК
        // =========================================================

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlTitleLine;

        // =========================================================
        // ПОЛЯ ДОКАЗАТЕЛЬСТВА
        // =========================================================

        private Label lblEvidenceNumber;
        private Label lblEvidenceName;
        private Label lblEvidenceStatus;
        private Label lblDateOfSeizure;
        private Label lblStorageLocation;
        private Label lblDescription;

        private TextBox txtEvidenceNumber;
        private TextBox txtEvidenceName;
        private ComboBox cmbEvidenceStatus;
        private DateTimePicker dtDateOfSeizure;
        private TextBox txtStorageLocation;
        private TextBox txtDescription;

        // =========================================================
        // ФОТО
        // =========================================================

        private Label lblPhotoTitle;
        private PictureBox picEvidence;
        private Label lblPhotoHint;

        private Button btnChoosePhoto;
        private Button btnRemovePhoto;

        // =========================================================
        // НИЖНИЕ КНОПКИ
        // =========================================================

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            // =========================================================
            // ФОРМА
            // =========================================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.ClientSize =
                new Size(
                    900,
                    700);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox =
                false;

            this.MinimizeBox =
                false;

            this.Name =
                "EvidenceEditForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Доказательство";

            // =========================================================
            // ГЛАВНАЯ ПАНЕЛЬ
            // =========================================================

            this.pnlMain =
                new Panel();

            this.pnlMain.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.pnlMain.Dock =
                DockStyle.Fill;

            // =========================================================
            // HEADER
            // =========================================================

            this.pnlHeader =
                new Panel();

            this.pnlHeader.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlHeader.Location =
                new Point(
                    20,
                    20);

            this.pnlHeader.Size =
                new Size(
                    860,
                    90);

            this.pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================================================
            // TITLE
            // =========================================================

            this.lblTitle =
                new Label();

            this.lblTitle.AutoSize =
                true;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(
                    25,
                    14);

            this.lblTitle.Text =
                "ДОКАЗАТЕЛЬСТВО";

            // =========================================================
            // TITLE LINE
            // =========================================================

            this.pnlTitleLine =
                new Panel();

            this.pnlTitleLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.pnlTitleLine.Location =
                new Point(
                    28,
                    50);

            this.pnlTitleLine.Size =
                new Size(
                    45,
                    3);

            // =========================================================
            // SUBTITLE
            // =========================================================

            this.lblSubtitle =
                new Label();

            this.lblSubtitle.AutoSize =
                true;

            this.lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.ForeColor =
                Color.Gainsboro;

            this.lblSubtitle.Location =
                new Point(
                    27,
                    58);

            this.lblSubtitle.Text =
                "Добавление и редактирование вещественного доказательства";

            // =========================================================
            // CONTENT
            // =========================================================

            this.pnlContent =
                new Panel();

            this.pnlContent.BackColor =
                Color.FromArgb(
                    18,
                    42,
                    82);

            this.pnlContent.Location =
                new Point(
                    20,
                    125);

            this.pnlContent.Size =
                new Size(
                    535,
                    455);

            this.pnlContent.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================================================
            // NUMBER
            // =========================================================

            this.lblEvidenceNumber =
                new Label();

            this.lblEvidenceNumber.AutoSize =
                true;

            this.lblEvidenceNumber.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblEvidenceNumber.ForeColor =
                Color.White;

            this.lblEvidenceNumber.Location =
                new Point(
                    25,
                    22);

            this.lblEvidenceNumber.Text =
                "Номер доказательства:";

            this.txtEvidenceNumber =
                new TextBox();

            this.txtEvidenceNumber.BackColor =
                Color.White;

            this.txtEvidenceNumber.ForeColor =
                Color.FromArgb(
                    30,
                    30,
                    30);

            this.txtEvidenceNumber.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtEvidenceNumber.Location =
                new Point(
                    25,
                    50);

            this.txtEvidenceNumber.Size =
                new Size(
                    220,
                    30);

            this.txtEvidenceNumber.MaxLength =
                4;

            // =========================================================
            // NAME
            // =========================================================

            this.lblEvidenceName =
                new Label();

            this.lblEvidenceName.AutoSize =
                true;

            this.lblEvidenceName.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblEvidenceName.ForeColor =
                Color.White;

            this.lblEvidenceName.Location =
                new Point(
                    275,
                    22);

            this.lblEvidenceName.Text =
                "Название:";

            this.txtEvidenceName =
                new TextBox();

            this.txtEvidenceName.BackColor =
                Color.White;

            this.txtEvidenceName.ForeColor =
                Color.FromArgb(
                    30,
                    30,
                    30);

            this.txtEvidenceName.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtEvidenceName.Location =
                new Point(
                    275,
                    50);

            this.txtEvidenceName.Size =
                new Size(
                    230,
                    30);

            this.txtEvidenceName.MaxLength =
                25;

            // =========================================================
            // STATUS
            // =========================================================

            this.lblEvidenceStatus =
                new Label();

            this.lblEvidenceStatus.AutoSize =
                true;

            this.lblEvidenceStatus.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblEvidenceStatus.ForeColor =
                Color.White;

            this.lblEvidenceStatus.Location =
                new Point(
                    25,
                    95);

            this.lblEvidenceStatus.Text =
                "Статус:";

            this.cmbEvidenceStatus =
                new ComboBox();

            this.cmbEvidenceStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbEvidenceStatus.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.cmbEvidenceStatus.Location =
                new Point(
                    25,
                    123);

            this.cmbEvidenceStatus.Size =
                new Size(
                    220,
                    30);

            // =========================================================
            // DATE
            // =========================================================

            this.lblDateOfSeizure =
                new Label();

            this.lblDateOfSeizure.AutoSize =
                true;

            this.lblDateOfSeizure.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblDateOfSeizure.ForeColor =
                Color.White;

            this.lblDateOfSeizure.Location =
                new Point(
                    275,
                    95);

            this.lblDateOfSeizure.Text =
                "Дата изъятия:";

            this.dtDateOfSeizure =
                new DateTimePicker();

            this.dtDateOfSeizure.Format =
                DateTimePickerFormat.Short;

            this.dtDateOfSeizure.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.dtDateOfSeizure.Location =
                new Point(
                    275,
                    123);

            this.dtDateOfSeizure.Size =
                new Size(
                    230,
                    30);

            this.dtDateOfSeizure.MaxDate =
                DateTime.Today;

            // =========================================================
            // STORAGE
            // =========================================================

            this.lblStorageLocation =
                new Label();

            this.lblStorageLocation.AutoSize =
                true;

            this.lblStorageLocation.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblStorageLocation.ForeColor =
                Color.White;

            this.lblStorageLocation.Location =
                new Point(
                    25,
                    168);

            this.lblStorageLocation.Text =
                "Место хранения:";

            this.txtStorageLocation =
                new TextBox();

            this.txtStorageLocation.BackColor =
                Color.White;

            this.txtStorageLocation.ForeColor =
                Color.FromArgb(
                    30,
                    30,
                    30);

            this.txtStorageLocation.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtStorageLocation.Location =
                new Point(
                    25,
                    196);

            this.txtStorageLocation.Size =
                new Size(
                    480,
                    30);

            this.txtStorageLocation.MaxLength =
                50;

            // =========================================================
            // DESCRIPTION
            // =========================================================

            this.lblDescription =
                new Label();

            this.lblDescription.AutoSize =
                true;

            this.lblDescription.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.lblDescription.ForeColor =
                Color.White;

            this.lblDescription.Location =
                new Point(
                    25,
                    241);

            this.lblDescription.Text =
                "Описание:";

            this.txtDescription =
                new TextBox();

            this.txtDescription.BackColor =
                Color.White;

            this.txtDescription.ForeColor =
                Color.FromArgb(
                    30,
                    30,
                    30);

            this.txtDescription.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtDescription.Location =
                new Point(
                    25,
                    269);

            this.txtDescription.Size =
                new Size(
                    480,
                    145);

            this.txtDescription.Multiline =
                true;

            this.txtDescription.ScrollBars =
                ScrollBars.Vertical;

            this.txtDescription.MaxLength =
                2000;

            this.txtDescription.TextAlign =
                HorizontalAlignment.Left;

            // =========================================================
            // PHOTO PANEL
            // =========================================================

            this.pnlPhoto =
                new Panel();

            this.pnlPhoto.BackColor =
                Color.FromArgb(
                    18,
                    42,
                    82);

            this.pnlPhoto.Location =
                new Point(
                    570,
                    125);

            this.pnlPhoto.Size =
                new Size(
                    310,
                    455);

            this.pnlPhoto.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================================================
            // PHOTO TITLE
            // =========================================================

            this.lblPhotoTitle =
                new Label();

            this.lblPhotoTitle.AutoSize =
                true;

            this.lblPhotoTitle.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblPhotoTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.lblPhotoTitle.Location =
                new Point(
                    20,
                    18);

            this.lblPhotoTitle.Text =
                "ФОТОГРАФИЯ ДОКАЗАТЕЛЬСТВА";

            // =========================================================
            // PHOTO
            // =========================================================

            this.picEvidence =
                new PictureBox();

            this.picEvidence.BackColor =
                Color.FromArgb(
                    8,
                    27,
                    58);

            this.picEvidence.BorderStyle =
                BorderStyle.FixedSingle;

            this.picEvidence.Location =
                new Point(
                    20,
                    55);

            this.picEvidence.Size =
                new Size(
                    270,
                    245);

            this.picEvidence.SizeMode =
                PictureBoxSizeMode.Zoom;

            // =========================================================
            // PHOTO HINT
            // =========================================================

            this.lblPhotoHint =
                new Label();

            this.lblPhotoHint.AutoSize =
                false;

            this.lblPhotoHint.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblPhotoHint.ForeColor =
                Color.Silver;

            this.lblPhotoHint.TextAlign =
                ContentAlignment.MiddleCenter;

            this.lblPhotoHint.Location =
                new Point(
                    35,
                    310);

            this.lblPhotoHint.Size =
                new Size(
                    240,
                    35);

            this.lblPhotoHint.Text =
                "JPG, JPEG, PNG или BMP";

            // =========================================================
            // CHOOSE PHOTO
            // =========================================================

            this.btnChoosePhoto =
                new Button();

            this.btnChoosePhoto.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnChoosePhoto.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnChoosePhoto.FlatAppearance.BorderSize =
                1;

            this.btnChoosePhoto.FlatStyle =
                FlatStyle.Flat;

            this.btnChoosePhoto.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnChoosePhoto.ForeColor =
                Color.White;

            this.btnChoosePhoto.Location =
                new Point(
                    20,
                    355);

            this.btnChoosePhoto.Size =
                new Size(
                    270,
                    38);

            this.btnChoosePhoto.Text =
                "Выбрать фотографию";

            this.btnChoosePhoto.UseVisualStyleBackColor =
                false;

            // =========================================================
            // REMOVE PHOTO
            // =========================================================

            this.btnRemovePhoto =
                new Button();

            this.btnRemovePhoto.BackColor =
                Color.FromArgb(
                    80,
                    85,
                    95);

            this.btnRemovePhoto.FlatAppearance.BorderColor =
                Color.FromArgb(
                    150,
                    150,
                    150);

            this.btnRemovePhoto.FlatAppearance.BorderSize =
                1;

            this.btnRemovePhoto.FlatStyle =
                FlatStyle.Flat;

            this.btnRemovePhoto.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnRemovePhoto.ForeColor =
                Color.White;

            this.btnRemovePhoto.Location =
                new Point(
                    20,
                    400);

            this.btnRemovePhoto.Size =
                new Size(
                    270,
                    38);

            this.btnRemovePhoto.Text =
                "Удалить фотографию";

            this.btnRemovePhoto.UseVisualStyleBackColor =
                false;

            // =========================================================
            // SAVE
            // =========================================================

            this.btnSave =
                new Button();

            this.btnSave.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnSave.FlatAppearance.BorderColor =
                Color.FromArgb(
                    235,
                    190,
                    60);

            this.btnSave.FlatAppearance.BorderSize =
                1;

            this.btnSave.FlatStyle =
                FlatStyle.Flat;

            this.btnSave.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnSave.ForeColor =
                Color.White;

            this.btnSave.Location =
                new Point(
                    20,
                    610);

            this.btnSave.Size =
                new Size(
                    220,
                    42);

            this.btnSave.Text =
                "Сохранить";

            this.btnSave.UseVisualStyleBackColor =
                false;

            // =========================================================
            // CANCEL
            // =========================================================

            this.btnCancel =
                new Button();

            this.btnCancel.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnCancel.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnCancel.FlatAppearance.BorderSize =
                1;

            this.btnCancel.FlatStyle =
                FlatStyle.Flat;

            this.btnCancel.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnCancel.ForeColor =
                Color.White;

            this.btnCancel.Location =
                new Point(
                    660,
                    610);

            this.btnCancel.Size =
                new Size(
                    220,
                    42);

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            // =========================================================
            // ДОБАВЛЯЕМ ЭЛЕМЕНТЫ В CONTENT
            // =========================================================

            this.pnlContent.Controls.Add(
                this.lblEvidenceNumber);

            this.pnlContent.Controls.Add(
                this.txtEvidenceNumber);

            this.pnlContent.Controls.Add(
                this.lblEvidenceName);

            this.pnlContent.Controls.Add(
                this.txtEvidenceName);

            this.pnlContent.Controls.Add(
                this.lblEvidenceStatus);

            this.pnlContent.Controls.Add(
                this.cmbEvidenceStatus);

            this.pnlContent.Controls.Add(
                this.lblDateOfSeizure);

            this.pnlContent.Controls.Add(
                this.dtDateOfSeizure);

            this.pnlContent.Controls.Add(
                this.lblStorageLocation);

            this.pnlContent.Controls.Add(
                this.txtStorageLocation);

            this.pnlContent.Controls.Add(
                this.lblDescription);

            this.pnlContent.Controls.Add(
                this.txtDescription);

            // =========================================================
            // ДОБАВЛЯЕМ ЭЛЕМЕНТЫ В PHOTO PANEL
            // =========================================================

            this.pnlPhoto.Controls.Add(
                this.lblPhotoTitle);

            this.pnlPhoto.Controls.Add(
                this.picEvidence);

            this.pnlPhoto.Controls.Add(
                this.lblPhotoHint);

            this.pnlPhoto.Controls.Add(
                this.btnChoosePhoto);

            this.pnlPhoto.Controls.Add(
                this.btnRemovePhoto);

            // =========================================================
            // HEADER
            // =========================================================

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.pnlTitleLine);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);

            // =========================================================
            // MAIN PANEL
            // =========================================================

            this.pnlMain.Controls.Add(
                this.pnlHeader);

            this.pnlMain.Controls.Add(
                this.pnlContent);

            this.pnlMain.Controls.Add(
                this.pnlPhoto);

            this.pnlMain.Controls.Add(
                this.btnSave);

            this.pnlMain.Controls.Add(
                this.btnCancel);

            // =========================================================
            // FORM
            // =========================================================

            this.Controls.Add(
                this.pnlMain);

            // =========================================================
            // EVENTS
            // =========================================================

            this.btnChoosePhoto.Click +=
                new EventHandler(
                    this.btnChoosePhoto_Click);

            this.btnRemovePhoto.Click +=
                new EventHandler(
                    this.btnRemovePhoto_Click);

            this.btnSave.Click +=
                new EventHandler(
                    this.btnSave_Click);

            this.btnCancel.Click +=
                new EventHandler(
                    this.btnCancel_Click);

            this.ResumeLayout(false);
        }

        #endregion
    }
}