using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using PoliceStationIS.Forms.Authorization.RegistrationPages;
using PoliceStationIS.Models;
using PoliceStationIS.Services;

namespace PoliceStationIS.Forms.Authorization
{
    public partial class RegisterForm : Form
    {
        private int currentStep = 0;
        private RegistrationData registrationData;

        private PersonalDataPage personalPage;
        private PassportDataPage passportPage;
        private ContactDataPage contactPage;
        private AccountDataPage accountPage;
        private ConfirmationPage confirmationPage;
        private void LoadPersonalDataPage()
        {
            panelContent.Controls.Clear();

            PersonalDataPage page =
                new PersonalDataPage();

            page.Dock =
                DockStyle.Fill;

            panelContent.Controls.Add(page);
        }
        private void MakeCircle(Control control)
        {
            GraphicsPath path =
                new GraphicsPath();

            path.AddEllipse(
                0,
                0,
                control.Width,
                control.Height);

            control.Region =
                new Region(path);
        }

        private void ConfigureStepCircle(
            Label label)
        {
            label.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);

            label.ForeColor =
                Color.White;

            label.Paint +=
                StepCircle_Paint;
        }

        private void StepCircle_Paint(
            object sender,
            PaintEventArgs e)
        {
            Label lbl =
                sender as Label;

            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            using (Pen pen =
                   new Pen(
                       Color.FromArgb(
                           214,
                           170,
                           74),
                       2))
            {
                e.Graphics.DrawEllipse(
                    pen,
                    1,
                    1,
                    lbl.Width - 3,
                    lbl.Height - 3);
            }
        }


        public RegisterForm()
        {
            InitializeComponent();

            MakeCircle(lblStep1);
            MakeCircle(lblStep2);
            MakeCircle(lblStep3);
            MakeCircle(lblStep4);
            MakeCircle(lblStep5);
            ConfigureStepCircle(lblStep1);
            ConfigureStepCircle(lblStep2);
            ConfigureStepCircle(lblStep3);
            ConfigureStepCircle(lblStep4);
            ConfigureStepCircle(lblStep5);
            personalPage = new PersonalDataPage();
            passportPage = new PassportDataPage();
            contactPage = new ContactDataPage();
            accountPage = new AccountDataPage();
            confirmationPage = new ConfirmationPage();
            registrationData = new RegistrationData();
            confirmationPage.RegisterClicked +=
    ConfirmationPage_RegisterClicked;

            ShowStep(0);
        }
        private void ShowStep(int step)
        {
            panelContent.Controls.Clear();

            switch (step)
            {
                case 0:
                    panelContent.Controls.Add(personalPage);
                    break;

                case 1:
                    panelContent.Controls.Add(passportPage);
                    break;

                case 2:
                    panelContent.Controls.Add(contactPage);
                    break;

                case 3:
                    panelContent.Controls.Add(accountPage);
                    break;

                case 4:
                    panelContent.Controls.Add(confirmationPage);
                    break;
            }

            currentStep = step;

            UpdateStepButtons();
        }
        private void UpdateStepButtons()
        {
            lblStep1.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);

            lblStep2.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);

            lblStep3.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);

            lblStep4.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);

            lblStep5.BackColor =
                Color.FromArgb(
                    8,
                    24,
                    48);


            lblStep1.ForeColor =
                Color.White;

            lblStep2.ForeColor =
                Color.White;

            lblStep3.ForeColor =
                Color.White;

            lblStep4.ForeColor =
                Color.White;

            lblStep5.ForeColor =
                Color.White;


            switch (currentStep)
            {
                case 0:

                    lblStep1.BackColor =
                        Color.FromArgb(
                            214,
                            170,
                            74);

                    lblStep1.ForeColor =
                        Color.FromArgb(
                            8,
                            24,
                            48);

                    break;

                case 1:

                    lblStep2.BackColor =
                        Color.FromArgb(
                            214,
                            170,
                            74);

                    lblStep2.ForeColor =
                        Color.FromArgb(
                            8,
                            24,
                            48);

                    break;

                case 2:

                    lblStep3.BackColor =
                        Color.FromArgb(
                            214,
                            170,
                            74);

                    lblStep3.ForeColor =
                        Color.FromArgb(
                            8,
                            24,
                            48);

                    break;

                case 3:

                    lblStep4.BackColor =
                        Color.FromArgb(
                            214,
                            170,
                            74);

                    lblStep4.ForeColor =
                        Color.FromArgb(
                            8,
                            24,
                            48);

                    break;

                case 4:

                    lblStep5.BackColor =
                        Color.FromArgb(
                            214,
                            170,
                            74);

                    lblStep5.ForeColor =
                        Color.FromArgb(
                            8,
                            24,
                            48);

                    break;

            }

            // ======================================
            // Настройка кнопок
            // ======================================

            if (currentStep == 4)
            {
                // Текст кнопки

                btnNext.Text =
                    "Зарегистрироваться";

                // Зелёный цвет

                btnNext.BackColor =
                    Color.FromArgb(
                        67,
                        160,
                        71);

                // Кнопка Назад немного левее

                btnBack.Location =
                    new Point(
                        670,
                        590);

                // Кнопка Регистрация немного левее

                btnNext.Location =
                    new Point(
                        830,
                        590);

                // Увеличиваем ТОЛЬКО на последнем шаге

                btnNext.Size =
                    new Size(
                        210,
                        40);
            }
            else
            {
                // Обычная кнопка Далее

                btnNext.Text =
                    "Далее";

                btnNext.BackColor =
                    Color.FromArgb(
                        214,
                        170,
                        74);

                // Возвращаем стандартное положение

                btnBack.Location =
                    new Point(
                        740,
                        590);

                btnNext.Location =
                    new Point(
                        900,
                        590);

                // Возвращаем стандартный размер

                btnNext.Size =
                    new Size(
                        140,
                        40);
            }

            lblStep1.Invalidate();
            lblStep2.Invalidate();
            lblStep3.Invalidate();
            lblStep4.Invalidate();
            lblStep5.Invalidate();
        }

        private void CollectRegistrationData()
        {
            // Личные данные

            registrationData.LastName =
                personalPage.LastName;

            registrationData.FirstName =
                personalPage.FirstName;

            registrationData.MiddleName =
                personalPage.MiddleName;

            registrationData.BirthDate =
                personalPage.BirthDate;

            registrationData.Gender =
                personalPage.Gender;

            registrationData.Position =
                personalPage.Position;

            registrationData.Department =
                personalPage.Department;

            registrationData.Rank =
                personalPage.Rank;


            // Паспорт

            registrationData.PassportSeries =
                passportPage.PassportSeries;

            registrationData.PassportNumber =
                passportPage.PassportNumber;

            registrationData.DepartmentCode =
                passportPage.DepartmentCode;

            registrationData.IssuedBy =
                passportPage.IssuedBy;

            registrationData.IssueDate =
                passportPage.IssueDate;

            registrationData.RegistrationAddress =
                passportPage.RegistrationAddress;


            // Контакты

            registrationData.Phone =
                contactPage.Phone;

            registrationData.ResidentialAddress =
                contactPage.ResidentialAddress;


            // Аккаунт

            registrationData.Login =
                accountPage.Login;

            registrationData.Email =
                accountPage.Email;

            registrationData.Password =
                accountPage.Password;
        }
        private void btnNext_Click(
    object sender,
    EventArgs e)
        {
            if (currentStep == 3)
            {
                CollectRegistrationData();

                confirmationPage.LoadData(
                    registrationData);
            }

            if (currentStep == 4)
            {
                ConfirmationPage_RegisterClicked(
                    this,
                    EventArgs.Empty);

                return;
            }

            ShowStep(currentStep + 1);
        }

        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            if (currentStep > 0)
            {
                ShowStep(currentStep - 1);
            }
        }
    private void ConfirmationPage_RegisterClicked(
    object sender,
    EventArgs e)
        {
            try
            {
                RegistrationService.Register(
                    registrationData);

                MessageBox.Show(
                    "Регистрация успешно завершена.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка регистрации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}