using System.Windows.Forms;
using System.Drawing;

namespace PoliceStationIS.Forms.Employees
{
    partial class EmployeesPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private Panel pnlHeader;
        private Panel pnlSearch;
        private Panel pnlActions;
        private Panel pnlEmployees;

        private Label lblTitle;
        private Label lblSubtitle;

        private Label lblSearch;
        private Label lblSearchField;

        private Label lblDepartment;
        private Label lblPost;
        private Label lblRank;
        private Label lblStatus;

        private TextBox txtSearch;

        private ComboBox cmbDepartment;
        private ComboBox cmbPost;
        private ComboBox cmbRank;
        private ComboBox cmbStatus;

        private Button btnSearch;
        private Button btnReset;

        private Button btnAddEmployee;
        private Button btnEditEmployee;
        private Button btnChangeStatus;
        private Button btnVacation;
        private Button btnSickLeave;
        private Button btnChangePost;
        private PictureBox picAddEmployee;
        private PictureBox picEditEmployee;
        private PictureBox picChangeStatus;
        private PictureBox picVacation;
        private PictureBox picSickLeave;
        private PictureBox picChangePost;
        private PictureBox picHeaderImage;

        private PictureBox picHeaderEmblem;

        private PictureBox picSearchUser;
        private PictureBox picSearchDepartment;
        private PictureBox picSearchPost;
        private PictureBox picSearchRank;
        private PictureBox picSearchStatus;

        private PictureBox picEmployeesTitle;

        private Label lblEmployees;

        private DataGridView dgvEmployees;

        private Button btnPrevPage;
        private Button btnNextPage;

        private Label lblPage1;
        private Label lblPage2;
        private Label lblPage3;

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.pnlSearch = new Panel();
            this.pnlActions = new Panel();
            this.pnlEmployees = new Panel();

            this.lblTitle = new Label();
            this.lblSubtitle = new Label();

            this.lblSearch = new Label();
            this.lblSearchField = new Label();

            this.lblDepartment = new Label();
            this.lblPost = new Label();
            this.lblRank = new Label();
            this.lblStatus = new Label();

            this.txtSearch = new TextBox();

            this.cmbDepartment = new ComboBox();
            this.cmbPost = new ComboBox();
            this.cmbRank = new ComboBox();
            this.cmbStatus = new ComboBox();

            this.btnSearch = new Button();
            this.btnReset = new Button();

            this.btnAddEmployee = new Button();
            this.btnEditEmployee = new Button();
            this.btnChangeStatus = new Button();
            this.btnVacation = new Button();
            this.btnSickLeave = new Button();
            this.btnChangePost = new Button();

            this.picAddEmployee = new PictureBox();
            this.picEditEmployee = new PictureBox();
            this.picChangeStatus = new PictureBox();
            this.picVacation = new PictureBox();
            this.picSickLeave = new PictureBox();
            this.picChangePost = new PictureBox();
            this.picHeaderImage = new PictureBox();

            this.picHeaderEmblem =
    new PictureBox();

            this.picEmployeesTitle =
    new PictureBox();

            this.picSearchUser = new PictureBox();
            this.picSearchDepartment = new PictureBox();
            this.picSearchPost = new PictureBox();
            this.picSearchRank = new PictureBox();
            this.picSearchStatus = new PictureBox();

            this.lblEmployees = new Label();

            this.dgvEmployees = new DataGridView();

            this.btnPrevPage = new Button();
            this.btnNextPage = new Button();

            this.lblPage1 = new Label();
            this.lblPage2 = new Label();
            this.lblPage3 = new Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvEmployees)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // USER CONTROL
            // =====================================

            this.AutoScaleMode =
                AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    5,
                    24,
                    58);

            this.Name =
                "EmployeesPage";

            this.Size =
                new System.Drawing.Size(
                    1320,
                    820);


            // =====================================
            // HEADER PANEL
            // =====================================

            this.pnlHeader.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlHeader.Location =
                new System.Drawing.Point(
                    20,
                    20);

            this.pnlHeader.Size =
                new System.Drawing.Size(
                    1260,
                    100);


            // =====================================
            // TITLE
            // =====================================

            this.lblTitle.AutoSize =
                true;

            this.lblTitle.ForeColor =
                System.Drawing.Color.White;

            this.lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitle.Location =
                new System.Drawing.Point(
                    25,
                    18);

            this.lblTitle.Text =
                "Сотрудники";

            Panel pnlTitleLine = new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(212, 160, 23);

            pnlTitleLine.Size =
                new Size(24, 3);

            pnlTitleLine.Location =
                new Point(30, 52);

            this.pnlHeader.Controls.Add(
                pnlTitleLine);


            // =====================================
            // SUBTITLE
            // =====================================

            this.lblSubtitle.AutoSize =
                true;

            this.lblSubtitle.ForeColor =
                System.Drawing.Color.Gainsboro;

            this.lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblSubtitle.Location =
                new System.Drawing.Point(
                    28,
                    58);

            this.lblSubtitle.Text =
                "Управление личным составом подразделения";

            this.pnlHeader.Controls.Add(
                this.lblTitle);

            this.pnlHeader.Controls.Add(
                this.lblSubtitle);
            this.pnlHeader.Controls.Add(
    this.picHeaderImage);

            this.pnlHeader.Controls.Add(
    this.picHeaderEmblem);

            this.picHeaderEmblem.BringToFront();

            // HEADER IMAGE

            this.picHeaderImage.Image =
                Properties.Resources.staff_icon;

            this.picHeaderImage.SizeMode =
    PictureBoxSizeMode.StretchImage;

            this.picHeaderImage.BackColor =
                Color.Transparent;

            this.picHeaderImage.Size =
                new Size(560, 140);

            this.picHeaderImage.Location =
                new Point(
                    600,
                    0);

            this.picHeaderEmblem.Image =
    Properties.Resources.section_emblem_gold;

            this.picHeaderEmblem.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picHeaderEmblem.BackColor =
                Color.Transparent;

            this.picHeaderEmblem.Size =
    new Size(95, 95);

            this.picHeaderEmblem.Location =
                new Point(
                    1145,
                    2);

            this.picHeaderEmblem.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            this.pnlHeader.Controls.Add(
                this.picHeaderEmblem);

            this.picHeaderEmblem.BringToFront();



            this.picEmployeesTitle.Image =
    Properties.Resources.citizens_gold_icon;

            this.picEmployeesTitle.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picEmployeesTitle.BackColor =
                Color.Transparent;

            this.picEmployeesTitle.Size =
    new Size(28, 28);

            this.picEmployeesTitle.Location =
                new Point(18, 88);


            // =====================================
            // SEARCH PANEL
            // =====================================

            this.pnlSearch.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlSearch.Location =
                new System.Drawing.Point(
                    20,
                    230);

            this.pnlSearch.Size =
                new System.Drawing.Size(
                    1260,
                    120);

            pnlSearch.BorderStyle =
    BorderStyle.FixedSingle;


            // =====================================
            // SEARCH LABEL
            // =====================================

            this.lblSearch.AutoSize =
                true;

            this.lblSearch.ForeColor =
                System.Drawing.Color.White;

            this.lblSearch.Font =
                new Font(
    "Segoe UI",
    12F,
    FontStyle.Bold);

            this.lblSearch.Location =
                new System.Drawing.Point(
                    25,
                    12);

            this.lblSearch.Text =
                "Поиск сотрудника";

            Panel pnlSearchLine =
    new Panel();

            pnlSearchLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlSearchLine.Size =
                new Size(
                    3,
                    22);

            pnlSearchLine.Location =
                new Point(
                    18,
                    12);

            this.pnlEmployees.Controls.Add(
                pnlSearchLine);

            // =====================================
            // SEARCH ICONS
            // =====================================

            this.picSearchUser.Image =
                Properties.Resources.employee_search_gold_icon;

            this.picSearchUser.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSearchUser.BackColor =
                Color.Transparent;

            this.picSearchUser.Size =
    new Size(22, 22);

            this.picSearchUser.Location =
                new Point(25, 38);


            this.picSearchDepartment.Image =
                Properties.Resources.department_gold_icon;

            this.picSearchDepartment.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSearchDepartment.BackColor =
                Color.Transparent;

            this.picSearchDepartment.Size =
    new Size(22, 22);

            this.picSearchDepartment.Location =
                new Point(260, 38);


            this.picSearchPost.Image =
                Properties.Resources.position_gold_icon;

            this.picSearchPost.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSearchPost.BackColor =
                Color.Transparent;

            this.picSearchPost.Size =
    new Size(22, 22);

            this.picSearchPost.Location =
                new Point(455, 38);


            this.picSearchRank.Image =
                Properties.Resources.rank_gold_icon;

            this.picSearchRank.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSearchRank.BackColor =
                Color.Transparent;

            this.picSearchRank.Size =
    new Size(22, 22);

            this.picSearchRank.Location =
                new Point(650, 38);


            this.picSearchStatus.Image =
                Properties.Resources.status_gold_icon;

            this.picSearchStatus.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSearchStatus.BackColor =
                Color.Transparent;

            this.picSearchStatus.Size =
    new Size(22, 22);

            this.picSearchStatus.Location =
                new Point(845, 38);


            // =====================================
            // DEPARTMENT LABEL
            // =====================================

            this.lblDepartment.AutoSize = true;

            this.lblDepartment.ForeColor =
                System.Drawing.Color.White;

            this.lblDepartment.Location =
                new System.Drawing.Point(
                    283,
                    45);

            this.lblDepartment.Text =
                "Отдел";


            // =====================================
            // POST LABEL
            // =====================================

            this.lblPost.AutoSize = true;

            this.lblPost.ForeColor =
                System.Drawing.Color.White;

            this.lblPost.Location =
                new System.Drawing.Point(
                    478,
                    45);

            this.lblPost.Text =
                "Должность";


            // =====================================
            // RANK LABEL
            // =====================================

            this.lblRank.AutoSize = true;

            this.lblRank.ForeColor =
                System.Drawing.Color.White;

            this.lblRank.Location =
                new System.Drawing.Point(
                    673,
                    45);

            this.lblRank.Text =
                "Звание";


            // =====================================
            // STATUS LABEL
            // =====================================

            this.lblStatus.AutoSize = true;

            this.lblStatus.ForeColor =
                System.Drawing.Color.White;

            this.lblStatus.Location =
                new System.Drawing.Point(
                    868,
                    45);

            this.lblStatus.Text =
                "Статус";

            // =====================================
            // SEARCH FIELD LABEL
            // =====================================

            this.lblSearchField.AutoSize = true;

            this.lblSearchField.ForeColor =
                System.Drawing.Color.White;

            this.lblSearchField.Location =
                new System.Drawing.Point(
                    47,
                    45);

            this.lblSearchField.Text =
                "ФИО сотрудника";

            // =====================================
            // SEARCH TEXTBOX
            // =====================================

            this.txtSearch.Location =
    new System.Drawing.Point(
        25,
        65);

            this.txtSearch.Size =
                new System.Drawing.Size(
                    220,
                    27);

            this.txtSearch.BackColor =
    Color.White;

            this.txtSearch.ForeColor =
                Color.Black;

            this.txtSearch.ForeColor =
                Color.White;

            this.txtSearch.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // DEPARTMENT
            // =====================================

            this.cmbDepartment.Location =
                new System.Drawing.Point(
                    260,
                    65);

            this.cmbDepartment.Size =
                new System.Drawing.Size(
                    180,
                    28);

            this.cmbDepartment.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbDepartment.BackColor =
    Color.FromArgb(
        35,
        57,
        105);

            this.cmbDepartment.ForeColor =
                Color.White;

            // =====================================
            // POST
            // =====================================

            this.cmbPost.Location =
                new System.Drawing.Point(
                    455,
                    65);

            this.cmbPost.Size =
                new System.Drawing.Size(
                    180,
                    28);

            this.cmbPost.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbPost.BackColor =
    Color.FromArgb(
        35,
        57,
        105);

            this.cmbPost.ForeColor =
                Color.White;


            // =====================================
            // RANK
            // =====================================

            this.cmbRank.Location =
                new System.Drawing.Point(
                    650,
                    65);

            this.cmbRank.Size =
                new System.Drawing.Size(
                    180,
                    28);

            this.cmbRank.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbRank.BackColor =
    Color.FromArgb(
        35,
        57,
        105);

            this.cmbRank.ForeColor =
                Color.White;


            // =====================================
            // STATUS
            // =====================================

            this.cmbStatus.Location =
                new System.Drawing.Point(
                    845,
                    65);

            this.cmbStatus.Size =
                new System.Drawing.Size(
                    180,
                    28);

            this.cmbStatus.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cmbStatus.BackColor =
    Color.FromArgb(
        35,
        57,
        105);

            this.cmbStatus.ForeColor =
                Color.White;


            // =====================================
            // SEARCH BUTTON
            // =====================================

            this.btnSearch.FlatStyle =
                FlatStyle.Flat;

            this.btnSearch.FlatAppearance.BorderSize =
                0;

            this.btnSearch.BackColor =
    Color.FromArgb(
        196,
        145,
        35);

            this.btnSearch.FlatAppearance.BorderSize =
                1;

            this.btnSearch.FlatAppearance.BorderColor =
                Color.FromArgb(
                    230,
                    190,
                    80);

            this.btnSearch.Font =
    new Font(
        "Segoe UI",
        9F,
        FontStyle.Bold);

            this.btnSearch.ForeColor =
                System.Drawing.Color.White;

            this.btnSearch.Location =
                new System.Drawing.Point(
                    1040,
                    60);

            this.btnSearch.Size =
                new System.Drawing.Size(
                    90,
                    32);

            this.btnSearch.Text =
                "Найти";


            // =====================================
            // RESET BUTTON
            // =====================================

            this.btnReset.FlatStyle =
                FlatStyle.Flat;

            this.btnReset.FlatAppearance.BorderSize = 1;

            this.btnReset.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnReset.BackColor =
                System.Drawing.Color.FromArgb(
                    45,
                    63,
                    105);

            this.btnReset.ForeColor =
                System.Drawing.Color.White;

            this.btnReset.Location =
                new System.Drawing.Point(
                    1140,
                    60);

            this.btnReset.Size =
                new System.Drawing.Size(
                    90,
                    32);

            this.btnReset.Text =
                "Сброс";


            // =====================================
            // SEARCH CONTROLS
            // =====================================

            this.pnlEmployees.Controls.Add(
    this.picSearchUser);

            this.pnlEmployees.Controls.Add(
                this.picSearchDepartment);

            this.pnlEmployees.Controls.Add(
                this.picSearchPost);

            this.pnlEmployees.Controls.Add(
                this.picSearchRank);

            this.pnlEmployees.Controls.Add(
                this.picSearchStatus);

            this.pnlEmployees.Controls.Add(
    this.lblSearch);

            this.pnlEmployees.Controls.Add(
                this.lblSearchField);

            this.pnlEmployees.Controls.Add(
                this.lblDepartment);

            this.pnlEmployees.Controls.Add(
                this.lblPost);

            this.pnlEmployees.Controls.Add(
                this.lblRank);

            this.pnlEmployees.Controls.Add(
                this.lblStatus);

            this.pnlEmployees.Controls.Add(
                this.txtSearch);

            this.pnlEmployees.Controls.Add(
                this.cmbDepartment);

            this.pnlEmployees.Controls.Add(
                this.cmbPost);

            this.pnlEmployees.Controls.Add(
                this.cmbRank);

            this.pnlEmployees.Controls.Add(
                this.cmbStatus);

            this.pnlEmployees.Controls.Add(
                this.btnSearch);

            this.pnlEmployees.Controls.Add(
                this.btnReset);

            // =====================================
            // ACTIONS PANEL
            // =====================================

            this.pnlActions.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlActions.Location =
                new System.Drawing.Point(
                    20,
                    140);

            this.pnlActions.Size =
                new System.Drawing.Size(
                    1260,
                    70);


            // =====================================
            // ADD EMPLOYEE
            // =====================================

            this.btnAddEmployee.FlatStyle =
                FlatStyle.Flat;

            this.btnAddEmployee.FlatAppearance.BorderSize =
    1;

            this.btnAddEmployee.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnAddEmployee.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnAddEmployee.ForeColor =
                System.Drawing.Color.White;

            this.btnAddEmployee.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnAddEmployee.Location =
                new System.Drawing.Point(
                    20,
                    17);

            this.btnAddEmployee.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnAddEmployee.Text =
                "Добавить сотрудника";
            this.btnAddEmployee.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;


            // =====================================
            // EDIT
            // =====================================

            this.btnEditEmployee.FlatStyle =
                FlatStyle.Flat;

            this.btnEditEmployee.FlatAppearance.BorderSize =
    1;

            this.btnEditEmployee.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnEditEmployee.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnEditEmployee.ForeColor =
                System.Drawing.Color.White;

            this.btnEditEmployee.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnEditEmployee.Location =
                new System.Drawing.Point(
                    225,
                    17);

            this.btnEditEmployee.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnEditEmployee.Text =
                "Редактировать";
            this.btnEditEmployee.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;




            // =====================================
            // STATUS
            // =====================================

            this.btnChangeStatus.FlatStyle =
                FlatStyle.Flat;

            this.btnChangeStatus.FlatAppearance.BorderSize =
    1;

            this.btnChangeStatus.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnChangeStatus.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnChangeStatus.ForeColor =
                System.Drawing.Color.White;

            this.btnChangeStatus.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnChangeStatus.Location =
                new System.Drawing.Point(
                    430,
                    17);

            this.btnChangeStatus.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnChangeStatus.Text =
                "Изменить статус";
            this.btnChangeStatus.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;


            // =====================================
            // VACATION
            // =====================================

            this.btnVacation.FlatStyle =
                FlatStyle.Flat;

            this.btnVacation.FlatAppearance.BorderSize =
    1;

            this.btnVacation.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnVacation.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnVacation.ForeColor =
                System.Drawing.Color.White;

            this.btnVacation.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnVacation.Location =
                new System.Drawing.Point(
                    635,
                    17);

            this.btnVacation.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnVacation.Text =
                "Отпуск";
            this.btnVacation.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;


            // =====================================
            // SICK LEAVE
            // =====================================

            this.btnSickLeave.FlatStyle =
                FlatStyle.Flat;

            this.btnSickLeave.FlatAppearance.BorderSize =
    1;

            this.btnSickLeave.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnSickLeave.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnSickLeave.ForeColor =
                System.Drawing.Color.White;

            this.btnSickLeave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnSickLeave.Location =
                new System.Drawing.Point(
                    840,
                    17);

            this.btnSickLeave.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnSickLeave.Text =
                "Больничный";
            this.btnSickLeave.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;


            // =====================================
            // CHANGE POST
            // =====================================

            this.btnChangePost.FlatStyle =
                FlatStyle.Flat;

            this.btnChangePost.FlatAppearance.BorderSize =
    1;

            this.btnChangePost.FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.btnChangePost.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnChangePost.ForeColor =
                System.Drawing.Color.White;

            this.btnChangePost.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9F,
                    System.Drawing.FontStyle.Bold);

            this.btnChangePost.Location =
                new System.Drawing.Point(
                    1045,
                    17);

            this.btnChangePost.Size =
                new System.Drawing.Size(
                    190,
                    35);

            this.btnChangePost.Text =
                "Изменить должность";
            this.btnChangePost.TextAlign =
    System.Drawing.ContentAlignment.MiddleCenter;


            // ADD EMPLOYEE ICON

            this.picAddEmployee.Image =
                Properties.Resources.employee_add_gold_icon;

            this.picAddEmployee.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picAddEmployee.BackColor =
    Color.Transparent;

            this.picAddEmployee.Parent =
                this.btnAddEmployee;

            this.picAddEmployee.Size =
                new Size(20, 20);

            this.picAddEmployee.Location =
                new Point(
                    10,
                    7);

            // EDIT ICON

            this.picEditEmployee.Image =
                Properties.Resources.edit_gold_icon;

            this.picEditEmployee.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picEditEmployee.BackColor =
                Color.Transparent;

            this.picEditEmployee.Parent =
                this.btnEditEmployee;

            this.picEditEmployee.Size =
                new Size(20, 20);

            this.picEditEmployee.Location =
                new Point(
                    10,
                    7);

            // STATUS ICON

            this.picChangeStatus.Image =
                Properties.Resources.status_change_gold_icon;

            this.picChangeStatus.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picChangeStatus.BackColor =
                Color.Transparent;

            this.picChangeStatus.Parent =
                this.btnChangeStatus;

            this.picChangeStatus.Size =
                new Size(24, 24);

            this.picChangeStatus.Location =
                new Point(
                    10,
                    7);

            // VACATION ICON

            this.picVacation.Image =
                Properties.Resources.vacation_gold_icon;

            this.picVacation.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picVacation.BackColor =
                Color.Transparent;

            this.picVacation.Parent =
                this.btnVacation;

            this.picVacation.Size =
                new Size(20, 20);

            this.picVacation.Location =
                new Point(
                    10,
                    7);

            // SICK ICON

            this.picSickLeave.Image =
                Properties.Resources.sick_leave_gold_icon;

            this.picSickLeave.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picSickLeave.BackColor =
                Color.Transparent;

            this.picSickLeave.Parent =
                this.btnSickLeave;

            this.picSickLeave.Size =
                new Size(20, 20);

            this.picSickLeave.Location =
                new Point(
                    10,
                    7);

            // POST ICON

            this.picChangePost.Image =
                Properties.Resources.change_position_gold_icon;

            this.picChangePost.SizeMode =
                PictureBoxSizeMode.Zoom;

            this.picChangePost.BackColor =
                Color.Transparent;

            this.picChangePost.Parent =
                this.btnChangePost;

            this.picChangePost.Size =
                new Size(20, 20);

            this.picChangePost.Location =
                new Point(
                    10,
                    7);

            // =====================================
            // ACTIONS CONTROLS
            // =====================================

            this.pnlActions.Controls.Add(
    this.picAddEmployee);
            this.picAddEmployee.Parent =
     this.btnAddEmployee;

            this.pnlActions.Controls.Add(
                this.picEditEmployee);
            this.picEditEmployee.Parent =
    this.btnEditEmployee;

            this.pnlActions.Controls.Add(
                this.picChangeStatus);
            this.picChangeStatus.Parent =
    this.btnChangeStatus;

            this.pnlActions.Controls.Add(
                this.picVacation);
            this.picVacation.Parent =
    this.btnVacation;

            this.pnlActions.Controls.Add(
                this.picSickLeave);
            this.picSickLeave.Parent =
    this.btnSickLeave;

            this.pnlActions.Controls.Add(
                this.picChangePost);
            this.picChangePost.Parent =
    this.btnChangePost;


            this.pnlEmployees.Controls.Add(
    this.picEmployeesTitle);

            this.pnlActions.Controls.Add(
                this.btnAddEmployee);

            this.pnlActions.Controls.Add(
                this.btnEditEmployee);

            this.pnlActions.Controls.Add(
                this.btnChangeStatus);

            this.pnlActions.Controls.Add(
                this.btnVacation);

            this.pnlActions.Controls.Add(
                this.btnSickLeave);

            this.pnlActions.Controls.Add(
                this.btnChangePost);

            // =====================================
            // EMPLOYEES PANEL
            // =====================================

            this.pnlEmployees.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    58,
                    117);

            this.pnlEmployees.Location =
                new System.Drawing.Point(
                    20,
                    225);

            this.pnlEmployees.Size =
                new System.Drawing.Size(
                    1260,
                    535);

            this.pnlEmployees.BorderStyle =
    BorderStyle.FixedSingle;


            // =====================================
            // EMPLOYEES TITLE
            // =====================================

            this.lblEmployees.AutoSize =
                true;

            this.lblEmployees.ForeColor =
                System.Drawing.Color.White;

            this.lblEmployees.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblEmployees.Location =
                new System.Drawing.Point(
                    55,
                    90);

            this.lblEmployees.Text =
                "Список сотрудников";

            Panel pnlEmployeesLine =
    new Panel();

            pnlEmployeesLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlEmployeesLine.Size =
                new Size(
                    3,
                    22);

            pnlEmployeesLine.Location =
                new Point(
                    18,
                    88);

            this.pnlEmployees.Controls.Add(
                pnlEmployeesLine);


            // =====================================
            // DATAGRIDVIEW
            // =====================================

            this.dgvEmployees.Location =
                new System.Drawing.Point(
                    25,
                    125);
            this.dgvEmployees.BorderStyle =
    BorderStyle.FixedSingle;

            this.dgvEmployees.Size =
                new System.Drawing.Size(
                    1210,
                    400);

            this.dgvEmployees.ColumnCount = 8;

            this.dgvEmployees.EnableHeadersVisualStyles =
    false;

            this.dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            this.dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            this.dgvEmployees.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);
            this.dgvEmployees.AutoGenerateColumns = false;

            this.dgvEmployees.Columns[0].Name =
                "ФИО";

            this.dgvEmployees.Columns[1].Name =
                "Дата рождения";

            this.dgvEmployees.Columns[2].Name =
                "Должность";

            this.dgvEmployees.Columns[3].Name =
                "Отдел";

            this.dgvEmployees.Columns[4].Name =
                "Звание";

            this.dgvEmployees.Columns[5].Name =
                "Статус";

            this.dgvEmployees.Columns[6].Name =
                "Телефон";

            this.dgvEmployees.Columns[7].Name =
                "Дата приема";


            // =====================================
            // PAGINATION
            // =====================================

            this.btnPrevPage.FlatStyle =
                FlatStyle.Flat;

            this.btnPrevPage.FlatAppearance.BorderSize =
                0;

            this.btnPrevPage.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnPrevPage.ForeColor =
                System.Drawing.Color.White;

            this.btnPrevPage.Location =
                new System.Drawing.Point(
                   1060, 475);

            this.btnPrevPage.Size =
                new System.Drawing.Size(
                    35,
                    30);

            this.btnPrevPage.Text =
                "<";


            this.lblPage1.AutoSize =
                true;

            this.lblPage1.ForeColor =
                System.Drawing.Color.White;

            this.lblPage1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Bold);

            this.lblPage1.Location =
                new System.Drawing.Point(
                    1115, 480);

            this.lblPage1.Text =
                "1";


            this.lblPage2.AutoSize =
                true;

            this.lblPage2.ForeColor =
                System.Drawing.Color.Gainsboro;

            this.lblPage2.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPage2.Location =
                new System.Drawing.Point(
                    1140, 480);

            this.lblPage2.Text =
                "2";


            this.lblPage3.AutoSize =
                true;

            this.lblPage3.ForeColor =
                System.Drawing.Color.Gainsboro;

            this.lblPage3.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F);

            this.lblPage3.Location =
                new System.Drawing.Point(
                    1165, 480);

            this.lblPage3.Text =
                "3";


            this.btnNextPage.FlatStyle =
                FlatStyle.Flat;

            this.btnNextPage.FlatAppearance.BorderSize =
                0;

            this.btnNextPage.BackColor =
                System.Drawing.Color.FromArgb(
                    42,
                    73,
                    133);

            this.btnNextPage.ForeColor =
                System.Drawing.Color.White;

            this.btnNextPage.Location =
                new System.Drawing.Point(
                    1190, 475);

            this.btnNextPage.Size =
                new System.Drawing.Size(
                    35,
                    30);

            this.btnNextPage.Text =
                ">";


            // =====================================
            // EMPLOYEES CONTROLS
            // =====================================

            this.pnlEmployees.Controls.Add(
                this.lblEmployees);

            this.pnlEmployees.Controls.Add(
                this.dgvEmployees);

            //this.pnlEmployees.Controls.Add(
            //    this.btnPrevPage);

            //this.pnlEmployees.Controls.Add(
            //    this.lblPage1);

            //this.pnlEmployees.Controls.Add(
            //    this.lblPage2);

            //this.pnlEmployees.Controls.Add(
            //    this.lblPage3);

            //this.pnlEmployees.Controls.Add(
            //    this.btnNextPage);


            // =====================================
            // ADD PANELS TO PAGE
            // =====================================

            this.Controls.Add(
                this.pnlHeader);

            //this.Controls.Add(
            //    this.pnlSearch);

            this.Controls.Add(
                this.pnlActions);

            this.Controls.Add(
                this.pnlEmployees);


            // =====================================
            // END
            // =====================================

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvEmployees)).EndInit();

            this.ResumeLayout(false);

        }

        #endregion
    }
}