using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Squads
{
    partial class SquadEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Panel pnlContent;

        private Label lblMainSection;
        private Panel lineMain;
        private Label lblSquadType;
        private Label lblStatus;
        private Label lblNumberOfPeople;
        private ComboBox cmbSquadType;
        private ComboBox cmbStatus;
        private TextBox txtNumberOfPeople;

        private Label lblCompositionSection;
        private Panel lineComposition;
        private Label lblEmployee;
        private ComboBox cmbEmployee;
        private Label lblPersonalNotes;
        private TextBox txtPersonalNotes;
        private Button btnAddEmployee;
        private Button btnRemoveEmployee;
        private DataGridView dgvComposition;

        private Label lblScheduleSection;
        private Panel lineSchedule;
        private Label lblDutyType;
        private ComboBox cmbDutyType;
        private Label lblStart;
        private Label lblEnd;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;

        private Label lblRouteSection;
        private Panel lineRoute;
        private Label lblMovementType;
        private ComboBox cmbMovementType;
        private Label lblCrimeRate;
        private ComboBox cmbCrimeRate;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblLength;
        private TextBox txtLength;
        private Label lblEstimatedTime;
        private DateTimePicker dtEstimatedTime;
        private Label lblRoute;
        private TextBox txtRoute;

        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblHeader = new Label();
            this.pnlContent = new Panel();

            this.lblMainSection = new Label();
            this.lineMain = new Panel();
            this.lblSquadType = new Label();
            this.lblStatus = new Label();
            this.lblNumberOfPeople = new Label();
            this.cmbSquadType = new ComboBox();
            this.cmbStatus = new ComboBox();
            this.txtNumberOfPeople = new TextBox();

            this.lblCompositionSection = new Label();
            this.lineComposition = new Panel();
            this.lblEmployee = new Label();
            this.cmbEmployee = new ComboBox();
            this.lblPersonalNotes = new Label();
            this.txtPersonalNotes = new TextBox();
            this.btnAddEmployee = new Button();
            this.btnRemoveEmployee = new Button();
            this.dgvComposition = new DataGridView();

            this.lblScheduleSection = new Label();
            this.lineSchedule = new Panel();
            this.lblDutyType = new Label();
            this.cmbDutyType = new ComboBox();
            this.lblStart = new Label();
            this.lblEnd = new Label();
            this.dtStart = new DateTimePicker();
            this.dtEnd = new DateTimePicker();

            this.lblRouteSection = new Label();
            this.lineRoute = new Panel();
            this.lblMovementType = new Label();
            this.cmbMovementType = new ComboBox();
            this.lblCrimeRate = new Label();
            this.cmbCrimeRate = new ComboBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblLength = new Label();
            this.txtLength = new TextBox();
            this.lblEstimatedTime = new Label();
            this.dtEstimatedTime = new DateTimePicker();
            this.lblRoute = new Label();
            this.txtRoute = new TextBox();

            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // ============================================================
            // FORM
            // ============================================================

            this.AutoScaleDimensions =
                new SizeF(7F, 15F);

            this.AutoScaleMode =
                AutoScaleMode.None;

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            // Компактный размер формы.
            this.ClientSize =
                new Size(900, 900);

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            // ============================================================
            // HEADER
            // ============================================================

            this.lblHeader.AutoSize = true;

            this.lblHeader.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            this.lblHeader.ForeColor =
                Color.White;

            this.lblHeader.Location =
                new Point(25, 18);

            this.lblHeader.Text =
                "Данные наряда";

            // ============================================================
            // CONTENT PANEL
            // ============================================================

            this.pnlContent.Location =
                new Point(15, 58);

            // Панель почти во всю ширину формы.
            // Высоты хватает на ВСЕ поля маршрута.
            this.pnlContent.Size =
                new Size(870, 770);

            this.pnlContent.BackColor =
                Color.FromArgb(15, 38, 78);

            this.pnlContent.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlContent.AutoScroll = false;

            // ============================================================
            // MAIN
            // ============================================================

            ConfigureSectionHeader(
                this.lblMainSection,
                "Основные данные",
                25,
                12);

            ConfigureLine(
                this.lineMain,
                25,
                38,
                820);

            ConfigureLabel(
                this.lblSquadType,
                "Тип наряда",
                25,
                55);

            ConfigureCombo(
                this.cmbSquadType,
                25,
                76,
                370);

            ConfigureLabel(
                this.lblStatus,
                "Статус",
                435,
                55);

            ConfigureCombo(
                this.cmbStatus,
                435,
                76,
                370);

            ConfigureLabel(
                this.lblNumberOfPeople,
                "Количество сотрудников",
                25,
                120);

            ConfigureTextBox(
                this.txtNumberOfPeople,
                25,
                141,
                180);

            // ============================================================
            // COMPOSITION
            // ============================================================

            ConfigureSectionHeader(
                this.lblCompositionSection,
                "Состав сотрудников",
                25,
                174);

            ConfigureLine(
                this.lineComposition,
                25,
                200,
                820);

            ConfigureLabel(
                this.lblEmployee,
                "Сотрудник",
                25,
                217);

            ConfigureCombo(
                this.cmbEmployee,
                25,
                238,
                470);

            ConfigureActionButton(
                this.btnAddEmployee,
                "Добавить",
                520,
                238,
                150,
                35);

            ConfigureActionButton(
                this.btnRemoveEmployee,
                "Удалить",
                685,
                238,
                150,
                35);

            ConfigureLabel(
                this.lblPersonalNotes,
                "Персональное примечание",
                25,
                278);

            ConfigureTextBox(
                this.txtPersonalNotes,
                25,
                299,
                470);

            this.dgvComposition.Location =
                new Point(25, 338);

            this.dgvComposition.Size =
                new Size(810, 82);

            this.dgvComposition.BackgroundColor =
                Color.FromArgb(30, 58, 117);

            this.dgvComposition.BorderStyle =
                BorderStyle.None;

            this.dgvComposition.GridColor =
                Color.FromArgb(70, 90, 135);

            this.dgvComposition.EnableHeadersVisualStyles =
                false;

            this.dgvComposition.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(20, 45, 90),
                    ForeColor = Color.White,
                    Font =
                        new Font(
                            "Segoe UI",
                            9F,
                            FontStyle.Bold)
                };

            this.dgvComposition.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor =
                        Color.FromArgb(30, 58, 117),
                    ForeColor = Color.White,
                    SelectionBackColor =
                        Color.FromArgb(55, 85, 145),
                    SelectionForeColor = Color.White
                };

            this.dgvComposition.RowTemplate.Height =
                25;

            // ============================================================
            // SCHEDULE
            // ============================================================

            ConfigureSectionHeader(
                this.lblScheduleSection,
                "График",
                25,
                438);

            ConfigureLine(
                this.lineSchedule,
                25,
                464,
                820);

            ConfigureLabel(
                this.lblDutyType,
                "Тип дежурства",
                25,
                481);

            ConfigureCombo(
                this.cmbDutyType,
                25,
                502,
                300);

            ConfigureLabel(
                this.lblStart,
                "Плановое начало",
                350,
                481);

            ConfigureDateTimePicker(
                this.dtStart,
                350,
                502,
                225);

            ConfigureLabel(
                this.lblEnd,
                "Плановое окончание",
                600,
                481);

            ConfigureDateTimePicker(
                this.dtEnd,
                600,
                502,
                235);

            // ============================================================
            // ROUTE
            // ============================================================

            ConfigureSectionHeader(
                this.lblRouteSection,
                "Маршрут",
                25,
                550);

            ConfigureLine(
                this.lineRoute,
                25,
                576,
                820);

            ConfigureLabel(
                this.lblMovementType,
                "Тип передвижения",
                25,
                593);

            ConfigureCombo(
                this.cmbMovementType,
                25,
                614,
                300);

            ConfigureLabel(
                this.lblCrimeRate,
                "Уровень криминогенности",
                350,
                593);

            ConfigureCombo(
                this.cmbCrimeRate,
                350,
                614,
                300);

            ConfigureLabel(
                this.lblDescription,
                "Описание",
                25,
                651);

            ConfigureTextBox(
                this.txtDescription,
                25,
                672,
                810);

            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 40;
            this.txtDescription.ScrollBars =
                ScrollBars.Vertical;

            // Нижняя строка маршрута.
            ConfigureLabel(
                this.lblLength,
                "Протяженность, км",
                25,
                722);

            ConfigureTextBox(
                this.txtLength,
                25,
                743,
                180);

            ConfigureLabel(
                this.lblEstimatedTime,
                "Расчетное время",
                225,
                722);

            ConfigureDateTimePicker(
                this.dtEstimatedTime,
                225,
                743,
                180);

            ConfigureLabel(
                this.lblRoute,
                "Маршрут",
                425,
                722);

            ConfigureTextBox(
                this.txtRoute,
                425,
                743,
                410);

            this.txtRoute.Multiline = true;
            this.txtRoute.Height = 40;
            this.txtRoute.ScrollBars =
                ScrollBars.Vertical;

            // ============================================================
            // CONTENT CONTROLS
            // ============================================================

            this.pnlContent.Controls.Add(
                this.lblMainSection);
            this.pnlContent.Controls.Add(
                this.lineMain);
            this.pnlContent.Controls.Add(
                this.lblSquadType);
            this.pnlContent.Controls.Add(
                this.cmbSquadType);
            this.pnlContent.Controls.Add(
                this.lblStatus);
            this.pnlContent.Controls.Add(
                this.cmbStatus);
            this.pnlContent.Controls.Add(
                this.lblNumberOfPeople);
            this.pnlContent.Controls.Add(
                this.txtNumberOfPeople);

            this.pnlContent.Controls.Add(
                this.lblCompositionSection);
            this.pnlContent.Controls.Add(
                this.lineComposition);
            this.pnlContent.Controls.Add(
                this.lblEmployee);
            this.pnlContent.Controls.Add(
                this.cmbEmployee);
            this.pnlContent.Controls.Add(
                this.lblPersonalNotes);
            this.pnlContent.Controls.Add(
                this.txtPersonalNotes);
            this.pnlContent.Controls.Add(
                this.btnAddEmployee);
            this.pnlContent.Controls.Add(
                this.btnRemoveEmployee);
            this.pnlContent.Controls.Add(
                this.dgvComposition);

            this.pnlContent.Controls.Add(
                this.lblScheduleSection);
            this.pnlContent.Controls.Add(
                this.lineSchedule);
            this.pnlContent.Controls.Add(
                this.lblDutyType);
            this.pnlContent.Controls.Add(
                this.cmbDutyType);
            this.pnlContent.Controls.Add(
                this.lblStart);
            this.pnlContent.Controls.Add(
                this.dtStart);
            this.pnlContent.Controls.Add(
                this.lblEnd);
            this.pnlContent.Controls.Add(
                this.dtEnd);

            this.pnlContent.Controls.Add(
                this.lblRouteSection);
            this.pnlContent.Controls.Add(
                this.lineRoute);
            this.pnlContent.Controls.Add(
                this.lblMovementType);
            this.pnlContent.Controls.Add(
                this.cmbMovementType);
            this.pnlContent.Controls.Add(
                this.lblCrimeRate);
            this.pnlContent.Controls.Add(
                this.cmbCrimeRate);
            this.pnlContent.Controls.Add(
                this.lblDescription);
            this.pnlContent.Controls.Add(
                this.txtDescription);
            this.pnlContent.Controls.Add(
                this.lblLength);
            this.pnlContent.Controls.Add(
                this.txtLength);
            this.pnlContent.Controls.Add(
                this.lblEstimatedTime);
            this.pnlContent.Controls.Add(
                this.dtEstimatedTime);
            this.pnlContent.Controls.Add(
                this.lblRoute);
            this.pnlContent.Controls.Add(
                this.txtRoute);

            // ============================================================
            // BUTTONS
            // ============================================================

            ConfigureSaveButton(
                this.btnSave,
                "Сохранить",
                590,
                840,
                135,
                40);

            ConfigureCancelButton(
                this.btnCancel,
                "Отмена",
                740,
                840,
                120,
                40);

            // ============================================================
            // FORM CONTROLS
            // ============================================================

            this.Controls.Add(
                this.lblHeader);

            this.Controls.Add(
                this.pnlContent);

            this.Controls.Add(
                this.btnSave);

            this.Controls.Add(
                this.btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigureSectionHeader(
            Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Text = text;

            label.ForeColor =
                Color.FromArgb(212, 175, 55);

            label.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            label.Location =
                new Point(x, y);
        }

        private void ConfigureLine(
            Panel line,
            int x,
            int y,
            int width)
        {
            line.Location =
                new Point(x, y);

            line.Size =
                new Size(width, 2);

            line.BackColor =
                Color.FromArgb(212, 175, 55);
        }

        private void ConfigureLabel(
            Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Text = text;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.Location =
                new Point(x, y);
        }

        private void ConfigureCombo(
            ComboBox combo,
            int x,
            int y,
            int width)
        {
            combo.Location =
                new Point(x, y);

            combo.Size =
                new Size(width, 30);

            combo.BackColor =
                Color.FromArgb(30, 58, 117);

            combo.ForeColor =
                Color.White;

            combo.FlatStyle =
                FlatStyle.Flat;
        }

        private void ConfigureTextBox(
            TextBox textBox,
            int x,
            int y,
            int width)
        {
            textBox.Location =
                new Point(x, y);

            textBox.Size =
                new Size(width, 30);

            textBox.BackColor =
                Color.FromArgb(30, 58, 117);

            textBox.ForeColor =
                Color.White;

            textBox.BorderStyle =
                BorderStyle.FixedSingle;

            textBox.Font =
                new Font(
                    "Segoe UI",
                    9F);
        }

        private void ConfigureDateTimePicker(
            DateTimePicker picker,
            int x,
            int y,
            int width)
        {
            picker.Location =
                new Point(x, y);

            picker.Size =
                new Size(width, 30);

            picker.Font =
                new Font(
                    "Segoe UI",
                    9F);
        }

        private void ConfigureActionButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            button.Text = text;

            button.Location =
                new Point(x, y);

            button.Size =
                new Size(width, height);

            button.BackColor =
                Color.FromArgb(30, 58, 117);

            button.ForeColor =
                Color.White;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 175, 55);

            button.FlatAppearance.BorderSize =
                1;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
        }

        private void ConfigureSaveButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            button.Text = text;

            button.Location =
                new Point(x, y);

            button.Size =
                new Size(width, height);

            button.BackColor =
                Color.FromArgb(30, 58, 117);

            button.ForeColor =
                Color.White;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(212, 175, 55);

            button.FlatAppearance.BorderSize =
                1;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
        }

        private void ConfigureCancelButton(
            Button button,
            string text,
            int x,
            int y,
            int width,
            int height)
        {
            button.Text = text;

            button.Location =
                new Point(x, y);

            button.Size =
                new Size(width, height);

            button.BackColor =
                Color.FromArgb(25, 45, 80);

            button.ForeColor =
                Color.Gainsboro;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(100, 115, 140);

            button.FlatAppearance.BorderSize =
                1;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);
        }
    }
}