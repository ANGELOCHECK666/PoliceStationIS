using System;
using System.Drawing;
using System.Windows.Forms;
using PoliceStationIS.Controls;

namespace PoliceStationIS.Forms.Equipment
{
    partial class EquipmentPage
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlSearch;
        private Panel pnlList;
        private Panel pnlInfo;
        private Panel pnlActions;

        private Label lblTitle;
        private Label lblSubtitle;

        private IconButton btnAddEquipment;
        private IconButton btnEditEquipment;

        private Label lblSearchTitle;
        private Label lblName;
        private Label lblCategory;
        private Label lblStatus;
        private Label lblEmployee;
        private Label lblDateFrom;
        private Label lblDateTo;

        private TextBox txtEquipmentName;
        private ComboBox cmbCategory;
        private ComboBox cmbStatus;
        private ComboBox cmbEmployee;
        private DateTimePicker dtDateFrom;
        private DateTimePicker dtDateTo;

        private Button btnSearch;
        private Button btnReset;

        private Label lblListTitle;
        private FlowLayoutPanel flpEquipment;

        private Button btnFirstPage;
        private Button btnPreviousPage;
        private Label lblPageInfo;
        private Button btnNextPage;
        private Button btnLastPage;

        private Label lblInfoTitle;

        private Label lblInfo1Title;
        private Label lblInfo1Value;

        private Label lblInfo2Title;
        private Label lblInfo2Value;

        private Label lblInfo3Title;
        private Label lblInfo3Value;

        private Label lblInfo4Title;
        private Label lblInfo4Value;

        private Label lblInfo5Title;
        private Label lblInfo5Value;

        private Label lblInfo6Title;
        private Label lblInfo6Value;

        private Label lblInfo7Title;
        private Label lblInfo7Value;

        private Label lblActionsTitle;

        private IconButton btnWarehouse;
        private IconButton btnIssueRequests;
        private IconButton btnMaintenance;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();


            // ============================================================
            // MAIN PAGE
            // ============================================================

            this.BackColor =
                Color.FromArgb(5, 24, 58);

            this.Name =
                "EquipmentPage";

            this.Size =
                new Size(1560, 900);


            // ============================================================
            // HEADER
            // ============================================================

            pnlHeader = new Panel();

            pnlHeader.BackColor =
                Color.FromArgb(30, 58, 117);

            pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            pnlHeader.Location =
                new Point(20, 20);

            pnlHeader.Size =
                new Size(1300, 100);


            // TITLE

            lblTitle = new Label();

            lblTitle.Text =
                "Экипировка";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(25, 15);


            // GOLD LINE

            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTitleLine.Location =
                new Point(30, 50);

            pnlTitleLine.Size =
                new Size(28, 3);


            // SUBTITLE

            lblSubtitle = new Label();

            lblSubtitle.Text =
                "Учёт и управление служебным имуществом";

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblSubtitle.ForeColor =
                Color.Gainsboro;

            lblSubtitle.AutoSize =
                true;

            lblSubtitle.Location =
                new Point(28, 58);


            // ADD BUTTON

            btnAddEquipment =
                CreateHeaderButton("Добавить");

            btnAddEquipment.Location =
                new Point(850, 28);

            btnAddEquipment.Size =
                new Size(210, 42);

            btnAddEquipment.ButtonIcon =
                Properties.Resources.equipment_gold_icon;


            // EDIT BUTTON

            btnEditEquipment =
                CreateHeaderButton(
                    "Редактировать");

            btnEditEquipment.Location =
                new Point(1070, 28);

            btnEditEquipment.Size =
                new Size(210, 42);

            btnEditEquipment.ButtonIcon =
                Properties.Resources.edit_gold_icon;


            pnlHeader.Controls.Add(
                pnlTitleLine);

            pnlHeader.Controls.Add(
                lblTitle);

            pnlHeader.Controls.Add(
                lblSubtitle);

            pnlHeader.Controls.Add(
                btnAddEquipment);

            pnlHeader.Controls.Add(
                btnEditEquipment);


            // ============================================================
            // SEARCH
            // ============================================================

            pnlSearch = new Panel();

            pnlSearch.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlSearch.BorderStyle =
                BorderStyle.FixedSingle;

            pnlSearch.Location =
                new Point(20, 140);

            pnlSearch.Size =
                new Size(855, 155);


            lblSearchTitle = new Label();

            lblSearchTitle.Text =
                "ПОИСК И ФИЛЬТРЫ";

            lblSearchTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblSearchTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblSearchTitle.AutoSize =
                true;

            lblSearchTitle.Location =
                new Point(18, 12);


            Panel pnlSearchLine =
                new Panel();

            pnlSearchLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlSearchLine.Location =
                new Point(18, 38);

            pnlSearchLine.Size =
                new Size(815, 1);


            // NAME

            lblName =
                CreateFieldLabel(
                    "Наименование",
                    20,
                    52);

            txtEquipmentName =
                new TextBox();

            txtEquipmentName.Location =
                new Point(20, 72);

            txtEquipmentName.Size =
                new Size(175, 26);


            // CATEGORY

            lblCategory =
                CreateFieldLabel(
                    "Категория",
                    215,
                    52);

            cmbCategory =
                CreateComboBox(
                    215,
                    72,
                    190);


            // STATUS

            lblStatus =
                CreateFieldLabel(
                    "Статус",
                    425,
                    52);

            cmbStatus =
                CreateComboBox(
                    425,
                    72,
                    190);


            // EMPLOYEE

            lblEmployee =
                CreateFieldLabel(
                    "Выдано сотруднику",
                    635,
                    52);

            cmbEmployee =
                CreateComboBox(
                    635,
                    72,
                    195);


            // DATE FROM

            lblDateFrom =
                CreateFieldLabel(
                    "Дата выдачи с",
                    20,
                    108);

            dtDateFrom =
                CreateDatePicker(
                    20,
                    128,
                    125);


            // DATE TO

            lblDateTo =
                CreateFieldLabel(
                    "Дата выдачи по",
                    160,
                    108);

            dtDateTo =
                CreateDatePicker(
                    160,
                    128,
                    125);


            // SEARCH

            btnSearch =
                CreateSearchButton(
                    "Найти");

            btnSearch.Location =
                new Point(650, 112);


            // RESET

            btnReset =
                CreateResetButton(
                    "Сброс");

            btnReset.Location =
                new Point(745, 112);


            pnlSearch.Controls.Add(
                lblSearchTitle);

            pnlSearch.Controls.Add(
                pnlSearchLine);

            pnlSearch.Controls.Add(
                lblName);

            pnlSearch.Controls.Add(
                txtEquipmentName);

            pnlSearch.Controls.Add(
                lblCategory);

            pnlSearch.Controls.Add(
                cmbCategory);

            pnlSearch.Controls.Add(
                lblStatus);

            pnlSearch.Controls.Add(
                cmbStatus);

            pnlSearch.Controls.Add(
                lblEmployee);

            pnlSearch.Controls.Add(
                cmbEmployee);

            pnlSearch.Controls.Add(
                lblDateFrom);

            pnlSearch.Controls.Add(
                dtDateFrom);

            pnlSearch.Controls.Add(
                lblDateTo);

            pnlSearch.Controls.Add(
                dtDateTo);

            pnlSearch.Controls.Add(
                btnSearch);

            pnlSearch.Controls.Add(
                btnReset);


            // ============================================================
            // LIST
            // ============================================================

            pnlList = new Panel();

            pnlList.BackColor =
                Color.FromArgb(18, 38, 74);

            pnlList.BorderStyle =
                BorderStyle.FixedSingle;

            pnlList.Location =
                new Point(20, 310);

            pnlList.Size =
                new Size(855, 520);


            lblListTitle = new Label();

            lblListTitle.Text =
                "СПИСОК ЭКИПИРОВКИ";

            lblListTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblListTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblListTitle.AutoSize =
                true;

            lblListTitle.Location =
                new Point(18, 12);


            Panel pnlListLine =
                new Panel();

            pnlListLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlListLine.Location =
                new Point(18, 38);

            pnlListLine.Size =
                new Size(815, 1);


            flpEquipment =
                new FlowLayoutPanel();

            flpEquipment.Location =
                new Point(18, 50);

            flpEquipment.Size =
                new Size(815, 390);

            flpEquipment.AutoScroll =
                true;

            flpEquipment.FlowDirection =
                FlowDirection.TopDown;

            flpEquipment.WrapContents =
                false;

            flpEquipment.BackColor =
                Color.Transparent;


            // PAGINATION

            btnFirstPage =
                CreatePaginationButton(
                    "<<");

            btnFirstPage.Location =
                new Point(240, 450);


            btnPreviousPage =
                CreatePaginationButton(
                    "<");

            btnPreviousPage.Location =
                new Point(285, 450);


            lblPageInfo =
                new Label();

            lblPageInfo.Text =
                "0–0 из 0";

            lblPageInfo.ForeColor =
                Color.Gainsboro;

            lblPageInfo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblPageInfo.AutoSize =
                true;

            lblPageInfo.Location =
                new Point(385, 458);


            btnNextPage =
                CreatePaginationButton(
                    ">");

            btnNextPage.Location =
                new Point(625, 450);


            btnLastPage =
                CreatePaginationButton(
                    ">>");

            btnLastPage.Location =
                new Point(670, 450);


            pnlList.Controls.Add(
                lblListTitle);

            pnlList.Controls.Add(
                pnlListLine);

            pnlList.Controls.Add(
                flpEquipment);

            pnlList.Controls.Add(
                btnFirstPage);

            pnlList.Controls.Add(
                btnPreviousPage);

            pnlList.Controls.Add(
                lblPageInfo);

            pnlList.Controls.Add(
                btnNextPage);

            pnlList.Controls.Add(
                btnLastPage);


            // ============================================================
            // INFORMATION
            // ============================================================

            pnlInfo =
                new Panel();

            pnlInfo.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            pnlInfo.BorderStyle =
                BorderStyle.FixedSingle;

            pnlInfo.Location =
                new Point(895, 140);

            pnlInfo.Size =
                new Size(425, 455);


            lblInfoTitle =
                new Label();

            lblInfoTitle.Text =
                "ИНФОРМАЦИЯ ОБ ИМУЩЕСТВЕ";

            lblInfoTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblInfoTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblInfoTitle.AutoSize =
                true;

            lblInfoTitle.Location =
                new Point(18, 12);


            Panel pnlInfoLine =
                new Panel();

            pnlInfoLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlInfoLine.Location =
                new Point(18, 38);

            pnlInfoLine.Size =
                new Size(385, 1);


            lblInfo1Title =
                CreateInfoTitle(
                    20,
                    65);

            lblInfo1Value =
                CreateInfoValue(
                    175,
                    65);


            lblInfo2Title =
                CreateInfoTitle(
                    20,
                    105);

            lblInfo2Value =
                CreateInfoValue(
                    175,
                    105);


            lblInfo3Title =
                CreateInfoTitle(
                    20,
                    145);

            lblInfo3Value =
                CreateInfoValue(
                    175,
                    145);


            lblInfo4Title =
                CreateInfoTitle(
                    20,
                    185);

            lblInfo4Value =
                CreateInfoValue(
                    175,
                    185);


            lblInfo5Title =
                CreateInfoTitle(
                    20,
                    225);

            lblInfo5Value =
                CreateInfoValue(
                    175,
                    225);


            lblInfo6Title =
                CreateInfoTitle(
                    20,
                    265);

            lblInfo6Value =
                CreateInfoValue(
                    175,
                    265);


            lblInfo7Title =
                CreateInfoTitle(
                    20,
                    305);

            lblInfo7Value =
                CreateInfoValue(
                    175,
                    305);


            pnlInfo.Controls.Add(
                lblInfoTitle);

            pnlInfo.Controls.Add(
                pnlInfoLine);

            pnlInfo.Controls.Add(
                lblInfo1Title);

            pnlInfo.Controls.Add(
                lblInfo1Value);

            pnlInfo.Controls.Add(
                lblInfo2Title);

            pnlInfo.Controls.Add(
                lblInfo2Value);

            pnlInfo.Controls.Add(
                lblInfo3Title);

            pnlInfo.Controls.Add(
                lblInfo3Value);

            pnlInfo.Controls.Add(
                lblInfo4Title);

            pnlInfo.Controls.Add(
                lblInfo4Value);

            pnlInfo.Controls.Add(
                lblInfo5Title);

            pnlInfo.Controls.Add(
                lblInfo5Value);

            pnlInfo.Controls.Add(
                lblInfo6Title);

            pnlInfo.Controls.Add(
                lblInfo6Value);

            pnlInfo.Controls.Add(
                lblInfo7Title);

            pnlInfo.Controls.Add(
                lblInfo7Value);


            // ============================================================
            // MTO ACTIONS
            // ============================================================

            pnlActions =
                new Panel();

            pnlActions.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            pnlActions.BorderStyle =
                BorderStyle.FixedSingle;

            pnlActions.Location =
                new Point(895, 610);

            pnlActions.Size =
                new Size(425, 220);


            lblActionsTitle =
                new Label();

            lblActionsTitle.Text =
                "ДЕЙСТВИЯ МТО";

            lblActionsTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblActionsTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblActionsTitle.AutoSize =
                true;

            lblActionsTitle.Location =
                new Point(18, 12);


            Panel pnlActionsLine =
                new Panel();

            pnlActionsLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlActionsLine.Location =
                new Point(18, 38);

            pnlActionsLine.Size =
                new Size(385, 1);


            btnWarehouse =
    CreateActionButton(
        "Управление складом");

            btnWarehouse.Location =
                new Point(15, 55);

            btnWarehouse.ButtonIcon =
                Properties.Resources.mto_card_gold_1;


            btnIssueRequests =
                CreateActionButton(
                    "Заявки на выдачу");

            btnIssueRequests.Location =
                new Point(15, 105);

            btnIssueRequests.ButtonIcon =
                Properties.Resources.mto_card_gold_2;


            btnMaintenance =
                CreateActionButton(
                    "Обслуживание имущества");

            btnMaintenance.Location =
                new Point(15, 155);

            btnMaintenance.ButtonIcon =
                Properties.Resources.mto_card_gold_3;


            pnlActions.Controls.Add(
                lblActionsTitle);

            pnlActions.Controls.Add(
                pnlActionsLine);

            pnlActions.Controls.Add(
                btnWarehouse);

            pnlActions.Controls.Add(
                btnIssueRequests);

            pnlActions.Controls.Add(
                btnMaintenance);


            // ============================================================
            // ADD PANELS
            // ============================================================

            this.Controls.Add(
                pnlHeader);

            this.Controls.Add(
                pnlSearch);

            this.Controls.Add(
                pnlList);

            this.Controls.Add(
                pnlInfo);

            this.Controls.Add(
                pnlActions);


            this.ResumeLayout(false);
        }


        // ============================================================
        // HELPERS
        // ============================================================

        private IconButton CreateHeaderButton(
    string text)
        {
            IconButton button =
                new IconButton();

            button.Text =
                text;

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;

            button.UseVisualStyleBackColor =
                false;

            return button;
        }


        private Label CreateFieldLabel(
            string text,
            int x,
            int y)
        {
            Label label =
                new Label();

            label.Text =
                text;

            label.AutoSize =
                true;

            label.ForeColor =
                Color.Gainsboro;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.Location =
                new Point(
                    x,
                    y);

            return label;
        }


        private ComboBox CreateComboBox(
            int x,
            int y,
            int width)
        {
            ComboBox comboBox =
                new ComboBox();

            comboBox.Location =
                new Point(
                    x,
                    y);

            comboBox.Size =
                new Size(
                    width,
                    26);

            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            return comboBox;
        }


        private DateTimePicker CreateDatePicker(
            int x,
            int y,
            int width)
        {
            DateTimePicker picker =
                new DateTimePicker();

            picker.Location =
                new Point(
                    x,
                    y);

            picker.Size =
                new Size(
                    width,
                    25);

            picker.Format =
                DateTimePickerFormat.Short;

            picker.ShowCheckBox =
                true;

            picker.Checked =
                false;

            return picker;
        }


        private Button CreateSearchButton(
            string text)
        {
            Button button =
                new Button();

            button.Text =
                text;

            button.Size =
                new Size(
                    85,
                    32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    196,
                    145,
                    35);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }


        private Button CreateResetButton(
            string text)
        {
            Button button =
                new Button();

            button.Text =
                text;

            button.Size =
                new Size(
                    85,
                    32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            return button;
        }


        private Button CreatePaginationButton(
            string text)
        {
            Button button =
                new Button();

            button.Text =
                text;

            button.Size =
                new Size(
                    40,
                    32);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            button.ForeColor =
                Color.White;

            return button;
        }


        private IconButton CreateActionButton(
     string text)
        {
            IconButton button =
                new IconButton();

            button.Text =
                text;

            button.Size =
                new Size(
                    390,
                    42);

            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            button.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            button.ForeColor =
                Color.White;

            button.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            button.Cursor =
                Cursors.Hand;

            button.UseVisualStyleBackColor =
                false;

            return button;
        }


        private Label CreateInfoTitle(
            int x,
            int y)
        {
            Label label =
                new Label();

            label.AutoSize =
                true;

            label.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            label.ForeColor =
                Color.White;

            label.Location =
                new Point(
                    x,
                    y);

            return label;
        }


        private Label CreateInfoValue(
            int x,
            int y)
        {
            Label label =
                new Label();

            label.AutoSize =
                false;

            label.Size =
                new Size(
                    220,
                    34);

            label.Font =
                new Font(
                    "Segoe UI",
                    9F);

            label.ForeColor =
                Color.Gainsboro;

            label.Location =
                new Point(
                    x,
                    y);

            return label;
        }
    }
}