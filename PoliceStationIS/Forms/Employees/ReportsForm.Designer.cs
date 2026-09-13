using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PoliceStationIS.Forms.HR
{
    partial class ReportsForm
    {
        private IContainer components = null;

        #region Components

        private Panel pnlHeader;

        private PictureBox picHeaderIcon;

        private Label lblTitle;

        private Button btnClose;

        private Panel pnlMain;

        // Левая панель

        private Panel pnlLeft;

        private Label lblParameters;
        private Label lblParametersDescription;

        private Panel pnlType;
        private Panel lineType;
        private PictureBox picTypeIcon;

        private Label lblReportType;

        private ComboBox cmbReportType;

        private Panel pnlPeriod;
        private Panel linePeriod;
        private PictureBox picPeriodIcon;

        private Label lblPeriod;

        private Label lblDateFrom;

        private DateTimePicker dtpDateFrom;

        private Label lblDateTo;

        private DateTimePicker dtpDateTo;

        private Panel pnlOptions;
        private Panel lineOptions;
        private PictureBox picOptionsIcon;

        private Label lblOptions;

        private Panel pnlDynamicOptions;

        private Button btnCancel;

        private Button btnGenerate;

        // Правая панель

        private Panel pnlRight;

        private PictureBox picReportIcon;

        private Label lblAfterGenerate;

        private Panel lineAfterGenerate;

        private Panel pnlSaveCard;

        private Panel pnlPrintCard;

        private PictureBox picSave;

        private PictureBox picPrint;

        private Label lblSaveTitle;

        private Label lblSaveText;

        private Label lblPrintTitle;

        private Label lblPrintText;

        #endregion

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
            this.pnlHeader = new Panel();

            this.picHeaderIcon = new PictureBox();

            this.lblTitle = new Label();

            this.btnClose = new Button();

            this.pnlMain = new Panel();

            this.pnlLeft = new Panel();

            this.lblParameters = new Label();

            this.pnlType = new Panel();
            this.lineType = new Panel();
            this.picTypeIcon = new PictureBox();

            this.lblReportType = new Label();

            this.cmbReportType = new ComboBox();

            this.pnlPeriod = new Panel();
            this.linePeriod = new Panel();
            this.picPeriodIcon = new PictureBox();

            this.lblPeriod = new Label();

            this.lblDateFrom = new Label();

            this.dtpDateFrom = new DateTimePicker();

            this.lblDateTo = new Label();

            this.dtpDateTo = new DateTimePicker();

            this.pnlOptions = new Panel();
            this.lineOptions = new Panel();
            this.picOptionsIcon = new PictureBox();

            this.lblOptions = new Label();

            this.pnlDynamicOptions = new Panel();

            this.btnCancel = new Button();

            this.btnGenerate = new Button();

            this.pnlRight = new Panel();

            this.picReportIcon = new PictureBox();

            this.lblAfterGenerate = new Label();

            this.lineAfterGenerate = new Panel();

            this.pnlSaveCard = new Panel();

            this.pnlPrintCard = new Panel();

            this.picSave = new PictureBox();

            this.picPrint = new PictureBox();

            this.lblSaveTitle = new Label();

            this.lblSaveText = new Label();

            this.lblPrintTitle = new Label();

            this.lblPrintText = new Label();

            ((ISupportInitialize)(this.picHeaderIcon)).BeginInit();

            ((ISupportInitialize)(this.picReportIcon)).BeginInit();

            ((ISupportInitialize)(this.picSave)).BeginInit();

            ((ISupportInitialize)(this.picPrint)).BeginInit();

            this.SuspendLayout();

            //
            // pnlHeader
            //

            this.pnlHeader.BackColor =
                Color.FromArgb(8, 24, 48);

            this.pnlHeader.Dock =
                DockStyle.Top;

            this.pnlHeader.Size =
                new Size(1280, 78);

            this.pnlHeader.Name =
                "pnlHeader";

            //
            // picHeaderIcon
            //

            this.picHeaderIcon.Image =
                Properties.Resources.reports_gold_icon;

            this.picHeaderIcon.Location =
                new Point(22, 16);

            this.picHeaderIcon.Size =
                new Size(38, 38);

            this.picHeaderIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            //
            // lblTitle
            //

            this.lblTitle.AutoSize =
                true;

            this.lblTitle.Font =
                new Font(
                    "Segoe UI",
                    13F,
                    FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.White;

            this.lblTitle.Location =
                new Point(66, 22);

            this.lblTitle.Text =
                "Формирование отчетов";

            //
            // btnClose
            //

            this.btnClose.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.btnClose.BackColor =
                Color.Transparent;

            this.btnClose.FlatAppearance.BorderSize =
                0;

            this.btnClose.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(35, 55, 90);

            this.btnClose.FlatStyle =
                FlatStyle.Flat;

            this.btnClose.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.btnClose.ForeColor =
                Color.White;

            this.btnClose.Location =
                new Point(1246, 18);

            this.btnClose.Size =
                new Size(28, 28);

            this.btnClose.Text =
                "✕";

            //
            // Добавляем элементы
            //

            this.pnlHeader.Controls.Add(this.picHeaderIcon);

            this.pnlHeader.Controls.Add(this.lblTitle);

            this.pnlHeader.Controls.Add(this.btnClose);

            //
            // pnlMain
            //

            this.pnlMain.BackColor =
                Color.FromArgb(12, 34, 64);

            this.pnlMain.Dock =
                DockStyle.Fill;

            this.pnlMain.Padding =
                new Padding(24);

            this.pnlMain.Name =
                "pnlMain";

            //
            // pnlLeft
            //

            this.pnlLeft.BackColor =
                Color.FromArgb(18, 42, 74);

            this.pnlLeft.Location =
                new Point(18, 18);

            this.pnlLeft.Name =
                "pnlLeft";

            this.pnlLeft.Size =
                new Size(380, 700);

            this.pnlLeft.TabIndex = 0;

            //
            // lblParameters
            //

            this.lblParameters.AutoSize =
                true;

            this.lblParameters.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblParameters.ForeColor =
                Color.White;

            this.lblParameters.Location =
                new Point(20, 18);

            this.lblParameters.Name =
                "lblParameters";

            this.lblParameters.Size =
                new Size(187, 21);

            this.lblParameters.TabIndex = 0;

            this.lblParameters.Text =
                "Параметры отчета";

            //
            // pnlRight
            //

            this.pnlRight.BackColor =
                Color.FromArgb(18, 42, 74);

            this.pnlRight.Location =
                new Point(420, 24);

            this.pnlRight.Name =
                "pnlRight";

            this.pnlRight.Size =
                new Size(860, 700);

            this.pnlRight.TabIndex = 1;


            //
            // picReportIcon
            //

            this.picReportIcon.Image =
                Properties.Resources.reports_gold_icon;

            this.picReportIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picReportIcon.Location =
                new Point(394, 35);

            this.picReportIcon.Size =
                new Size(72, 72);

            //
            // lblAfterGenerate
            //

            this.lblAfterGenerate.AutoSize = true;

            this.lblAfterGenerate.Font =
                new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold);

            this.lblAfterGenerate.ForeColor =
                Color.White;

            this.lblAfterGenerate.Text =
                "После формирования отчета";

            this.lblAfterGenerate.Location =
                new Point(245, 118);

            //
            // lineAfterGenerate
            //

            this.lineAfterGenerate.BackColor =
                Color.FromArgb(212, 160, 23);

            this.lineAfterGenerate.Location =
                new Point(120, 155);

            this.lineAfterGenerate.Size =
                new Size(620, 1);

            //
            // pnlSaveCard
            //

            this.pnlSaveCard.BackColor =
                Color.FromArgb(22, 45, 78);

            this.pnlSaveCard.Location =
                new Point(120, 250);

            this.pnlSaveCard.Size =
                new Size(250, 250);

            this.pnlSaveCard.BorderStyle =
    BorderStyle.None;

            this.pnlSaveCard.Cursor =
                Cursors.Hand;

            this.picSave.Image =
    Properties.Resources.download_icon_gold;

            this.picSave.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSave.Size =
                new Size(74, 74);

            this.picSave.Location =
                new Point(83, 28);

            this.lblSaveTitle.AutoSize =
    true;

            this.lblSaveTitle.Font =
                new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold);

            this.lblSaveTitle.ForeColor =
                Color.White;

            this.lblSaveTitle.Text =
                "СОХРАНИТЬ";

            this.lblSaveTitle.Location =
                new Point(45, 112);

            this.lblSaveText.Size =
    new Size(190, 55);

            this.lblSaveText.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblSaveText.ForeColor =
                Color.White;

            this.lblSaveText.TextAlign =
                ContentAlignment.MiddleCenter;

            this.lblSaveText.Text =
                "Сохранить отчет\nна компьютер";

            this.lblSaveText.Location =
                new Point(25, 150);

            //
            // Добавляем элементы
            //

            this.pnlLeft.Controls.Add(
    this.lblParameters);

            this.pnlMain.Controls.Add(
                this.pnlLeft);

            this.pnlMain.Controls.Add(
                this.pnlRight);

            this.pnlRight.Controls.Add(this.picReportIcon);

            this.pnlRight.Controls.Add(this.lblAfterGenerate);

            this.pnlRight.Controls.Add(this.lineAfterGenerate);

            this.pnlRight.Controls.Add(this.pnlSaveCard);

            this.pnlRight.Controls.Add(this.pnlPrintCard);

            this.pnlSaveCard.Controls.Add(this.picSave);

            this.pnlSaveCard.Controls.Add(this.lblSaveTitle);

            this.pnlSaveCard.Controls.Add(this.lblSaveText);

            //
            // pnlPrintCard
            //

            this.pnlPrintCard.BackColor =
                Color.FromArgb(22, 45, 78);

            this.pnlPrintCard.Location =
                new Point(520, 250);

            this.pnlPrintCard.Size =
                new Size(250, 250);

            this.pnlPrintCard.BorderStyle =
    BorderStyle.None;

            this.pnlPrintCard.Cursor =
                Cursors.Hand;

            this.picPrint.Image =
    Properties.Resources.printer_icon;

            this.picPrint.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picPrint.Size =
                new Size(110, 115);

            this.picPrint.Location =
                new Point(75, 5);

            this.lblPrintTitle.AutoSize =
    true;

            this.lblPrintTitle.Font =
                new Font(
                    "Segoe UI",
                    14F,
                    FontStyle.Bold);

            this.lblPrintTitle.ForeColor =
                Color.White;

            this.lblPrintTitle.Text =
                "ПЕЧАТЬ";

            this.lblPrintTitle.Location =
                new Point(80, 112);

            this.lblPrintText.Size =
    new Size(190, 55);

            this.lblPrintText.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.lblPrintText.ForeColor =
                Color.White;

            this.lblPrintText.TextAlign =
                ContentAlignment.MiddleCenter;

            this.lblPrintText.Text =
                "Отправить отчет\nна печать";

            this.lblPrintText.Location =
                new Point(35, 150);

            this.pnlPrintCard.Controls.Add(this.picPrint);

            this.pnlPrintCard.Controls.Add(this.lblPrintTitle);

            this.pnlPrintCard.Controls.Add(this.lblPrintText);

            //
            // pnlType
            //

            this.pnlType.BackColor =
                Color.FromArgb(24, 49, 84);

            this.pnlType.Location =
                new Point(20, 58);

            this.pnlType.Name =
                "pnlType";

            this.pnlType.Size =
                new Size(340, 110);

            this.pnlType.TabIndex = 2;

            //
            // picTypeIcon
            //

            this.picTypeIcon.Image =
                Properties.Resources.protocols_gold_icon;

            this.picTypeIcon.Location =
                new Point(15, 9);

            this.picTypeIcon.Size =
                new Size(28, 28);

            this.picTypeIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            //
            // lineType
            //

            this.lineType.BackColor =
                Color.FromArgb(140, 212, 160, 23);

            this.lineType.Location =
                new Point(18, 42);

            this.lineType.Name =
                "lineType";

            this.lineType.Size =
                new Size(300, 1);

            this.lineType.TabIndex = 0;

            //
            // lblReportType
            //

            this.lblReportType.AutoSize =
                true;

            this.lblReportType.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblReportType.ForeColor =
                Color.White;

            this.lblReportType.Location =
                new Point(40, 14);

            this.lblReportType.Name =
                "lblReportType";

            this.lblReportType.Size =
                new Size(96, 17);

            this.lblReportType.TabIndex = 0;

            this.lblReportType.Text =
                "1. Тип отчета";

            //
            // cmbReportType
            //

            this.cmbReportType.BackColor =
                Color.FromArgb(34, 60, 98);

            this.cmbReportType.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbReportType.FlatStyle =
                FlatStyle.Flat;

            this.cmbReportType.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
        FontStyle.Regular);

            this.cmbReportType.ForeColor =
                Color.White;

            this.cmbReportType.FormattingEnabled =
                true;

            this.cmbReportType.Location =
                new Point(25, 58);

            this.cmbReportType.Name =
                "cmbReportType";

            this.cmbReportType.Size =
                new Size(290, 34);

            this.cmbReportType.TabIndex = 1;

            //
            // Добавляем элементы в pnlType
            //

            this.pnlType.Controls.Add(
    this.picTypeIcon);

            this.pnlType.Controls.Add(
                this.lblReportType);

            this.pnlType.Controls.Add(
                this.lineType);

            this.pnlType.Controls.Add(
                this.cmbReportType);

            //
            // Добавляем pnlType в левую панель
            //

            this.pnlLeft.Controls.Add(
                this.pnlType);

            //
            // pnlPeriod
            //

            this.pnlPeriod.BackColor =
                Color.FromArgb(24, 49, 84);

            this.pnlPeriod.Location =
                new Point(20, 184);

            this.pnlPeriod.Name =
                "pnlPeriod";

            this.pnlPeriod.Size =
                new Size(340, 120);

            this.pnlPeriod.TabIndex = 3;

            this.picPeriodIcon.Image =
    Properties.Resources.calendar_gold_icon;

            this.picPeriodIcon.Location =
                new Point(15, 11);

            this.picPeriodIcon.Size =
                new Size(24, 24);

            this.picPeriodIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            //
            // linePeriod
            //

            this.linePeriod.BackColor =
                Color.FromArgb(140, 212, 160, 23);

            this.linePeriod.Location =
                new Point(18, 42);

            this.linePeriod.Name =
                "linePeriod";

            this.linePeriod.Size =
                new Size(300, 1);

            this.linePeriod.TabIndex = 0;

            //
            // lblPeriod
            //

            this.lblPeriod.AutoSize =
                true;

            this.lblPeriod.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblPeriod.ForeColor =
                Color.White;

            this.lblPeriod.Location =
                new Point(40, 14);

            this.lblPeriod.Name =
                "lblPeriod";

            this.lblPeriod.Size =
                new Size(71, 17);

            this.lblPeriod.TabIndex = 0;

            this.lblPeriod.Text =
                "2. Период";

            //
            // lblDateFrom
            //

            this.lblDateFrom.AutoSize =
                true;

            this.lblDateFrom.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblDateFrom.ForeColor =
                Color.FromArgb(210, 218, 230);

            this.lblDateFrom.Location =
                new Point(18, 50);

            this.lblDateFrom.Name =
                "lblDateFrom";

            this.lblDateFrom.Size =
                new Size(53, 15);

            this.lblDateFrom.TabIndex = 1;

            this.lblDateFrom.Text =
                "Дата с:";

            //
            // dtpDateFrom
            //

            this.dtpDateFrom.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.dtpDateFrom.Format =
                DateTimePickerFormat.Short;

            this.dtpDateFrom.Location =
                new Point(78, 45);

            this.dtpDateFrom.Name =
                "dtpDateFrom";

            this.dtpDateFrom.Size =
                new Size(120, 28);

            this.dtpDateFrom.TabIndex = 2;

            //
            // lblDateTo
            //

            this.lblDateTo.AutoSize =
                true;

            this.lblDateTo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.lblDateTo.ForeColor =
                Color.FromArgb(210, 218, 230);

            this.lblDateTo.Location =
                new Point(18, 84);

            this.lblDateTo.Name =
                "lblDateTo";

            this.lblDateTo.Size =
                new Size(57, 15);

            this.lblDateTo.TabIndex = 3;

            this.lblDateTo.Text =
                "Дата по:";

            //
            // dtpDateTo
            //

            this.dtpDateTo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.dtpDateTo.Format =
                DateTimePickerFormat.Short;

            this.dtpDateTo.Location =
                new Point(78, 79);

            this.dtpDateTo.Name =
                "dtpDateTo";

            this.dtpDateTo.Size =
                new Size(120, 28);

            this.dtpDateTo.TabIndex = 4;

            //
            // Добавляем элементы в pnlPeriod
            //

            this.pnlPeriod.Controls.Add(
    this.picPeriodIcon);
            this.pnlPeriod.Controls.Add(
                this.lblPeriod);
            this.pnlPeriod.Controls.Add(
    this.linePeriod);

            this.pnlPeriod.Controls.Add(
                this.lblDateFrom);

            this.pnlPeriod.Controls.Add(
                this.dtpDateFrom);

            this.pnlPeriod.Controls.Add(
                this.lblDateTo);

            this.pnlPeriod.Controls.Add(
                this.dtpDateTo);

            //
            // Добавляем pnlPeriod
            //

            this.pnlLeft.Controls.Add(
                this.pnlPeriod);
            
            this.picOptionsIcon.Image =
    Properties.Resources.edit_gold_icon;

            this.picOptionsIcon.Location =
                new Point(15, 11);

            this.picOptionsIcon.Size =
                new Size(24, 24);

            this.picOptionsIcon.SizeMode =
                PictureBoxSizeMode.Zoom;

            //
            // pnlOptions
            //

            this.pnlOptions.BackColor =
                Color.FromArgb(24, 49, 84);

            this.pnlOptions.Location =
                new Point(20, 318);

            this.pnlOptions.Name =
                "pnlOptions";

            this.pnlOptions.Size =
                new Size(340, 270);

            this.pnlOptions.TabIndex = 4;

            //
            // lineOptions
            //

            this.lineOptions.BackColor =
                Color.FromArgb(140, 212, 160, 23);

            this.lineOptions.Location =
                new Point(18, 42);

            this.lineOptions.Name =
                "lineOptions";

            this.lineOptions.Size =
                new Size(300, 1);

            this.lineOptions.TabIndex = 0;

            //
            // lblOptions
            //

            this.lblOptions.AutoSize =
                true;

            this.lblOptions.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            this.lblOptions.ForeColor =
                Color.White;

            this.lblOptions.Location =
                new Point(40, 14);

            this.lblOptions.Name =
                "lblOptions";

            this.lblOptions.Size =
                new Size(171, 17);

            this.lblOptions.TabIndex = 0;

            this.lblOptions.Text =
                "3. Дополнительные параметры";

            //
            // pnlDynamicOptions
            //

            this.pnlDynamicOptions.BackColor =
                Color.Transparent;

            this.pnlDynamicOptions.Location =
                new Point(15, 42);

            this.pnlDynamicOptions.Name =
                "pnlDynamicOptions";

            this.pnlDynamicOptions.Size =
                new Size(305, 205);

            this.pnlDynamicOptions.TabIndex = 1;

            //
            // Добавляем элементы
            //

            this.pnlOptions.Controls.Add(
    this.picOptionsIcon);

            this.pnlOptions.Controls.Add(
                this.lblOptions);

            this.pnlOptions.Controls.Add(
                this.lineOptions);

            this.pnlOptions.Controls.Add(
                this.pnlDynamicOptions);

            //
            // btnCancel
            //

            this.btnCancel.BackColor =
                Color.FromArgb(70, 84, 112);

            this.btnCancel.FlatAppearance.BorderSize =
                0;

            this.btnCancel.FlatStyle =
                FlatStyle.Flat;

            this.btnCancel.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnCancel.ForeColor =
                Color.White;

            this.btnCancel.Location =
                new Point(20, 620);

            this.btnCancel.Name =
                "btnCancel";

            this.btnCancel.Size =
                new Size(130, 42);

            this.btnCancel.TabIndex = 5;

            this.btnCancel.Text =
                "Отмена";

            this.btnCancel.UseVisualStyleBackColor =
                false;

            //
            // btnGenerate
            //

            this.btnGenerate.BackColor =
                Color.FromArgb(212, 160, 23);

            this.btnGenerate.FlatAppearance.BorderSize =
                0;

            this.btnGenerate.FlatStyle =
                FlatStyle.Flat;

            this.btnGenerate.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            this.btnGenerate.ForeColor =
                Color.White;

            this.btnGenerate.Location =
                new Point(180, 620);

            this.btnGenerate.Name =
                "btnGenerate";

            this.btnGenerate.Size =
                new Size(180, 42);

            this.btnGenerate.TabIndex = 6;

            this.btnGenerate.Text =
                "Сформировать";

            this.btnGenerate.UseVisualStyleBackColor =
                false;

            //
            // Добавляем элементы в левую панель
            //

            this.pnlLeft.Controls.Add(
                this.pnlOptions);

            this.pnlLeft.Controls.Add(
                this.btnCancel);

            this.pnlLeft.Controls.Add(
                this.btnGenerate);

            //
            // Добавляем панели на форму
            //

            this.Controls.Add(
                this.pnlMain);

            this.Controls.Add(
                this.pnlHeader);

            //
            // ReportsForm
            //

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.ClientSize =
                new Size(1280, 820);

            this.DoubleBuffered =
                true;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "ReportsForm";

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Формирование отчетов";

            this.pnlHeader.ResumeLayout(false);

            this.pnlHeader.PerformLayout();

            this.pnlLeft.ResumeLayout(false);

            this.pnlLeft.PerformLayout();

            this.pnlType.ResumeLayout(false);

            this.pnlType.PerformLayout();

            this.pnlPeriod.ResumeLayout(false);

            this.pnlPeriod.PerformLayout();

            this.pnlOptions.ResumeLayout(false);

            this.pnlOptions.PerformLayout();

            this.pnlRight.ResumeLayout(false);

            this.pnlRight.PerformLayout();

            this.pnlMain.ResumeLayout(false);

            ((ISupportInitialize)(this.picHeaderIcon)).EndInit();

            ((ISupportInitialize)(this.picReportIcon)).EndInit();

            ((ISupportInitialize)(this.picSave)).EndInit();

            ((ISupportInitialize)(this.picPrint)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}