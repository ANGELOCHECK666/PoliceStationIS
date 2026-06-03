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

namespace PoliceStationIS.Forms.Authorization
{
    public partial class RegisterForm : Form
    {
        private int currentStep = 0;

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

        public RegisterForm()
        {
            InitializeComponent();

            MakeCircle(lblStep1);
            MakeCircle(lblStep2);
            MakeCircle(lblStep3);
            MakeCircle(lblStep4);
            MakeCircle(lblStep5);
            personalPage = new PersonalDataPage();
            passportPage = new PassportDataPage();
            contactPage = new ContactDataPage();
            accountPage = new AccountDataPage();
            confirmationPage = new ConfirmationPage();

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
            btnPersonalData.BackColor =
                Color.FromArgb(26, 53, 96);

            btnPassportData.BackColor =
                Color.FromArgb(26, 53, 96);

            btnContacts.BackColor =
                Color.FromArgb(26, 53, 96);

            btnAccount.BackColor =
                Color.FromArgb(26, 53, 96);

            btnConfirmation.BackColor =
                Color.FromArgb(26, 53, 96);

            switch (currentStep)
            {
                case 0:
                    btnPersonalData.BackColor =
                        Color.FromArgb(70, 115, 200);
                    break;

                case 1:
                    btnPassportData.BackColor =
                        Color.FromArgb(70, 115, 200);
                    break;

                case 2:
                    btnContacts.BackColor =
                        Color.FromArgb(70, 115, 200);
                    break;

                case 3:
                    btnAccount.BackColor =
                        Color.FromArgb(70, 115, 200);
                    break;

                case 4:
                    btnConfirmation.BackColor =
                        Color.FromArgb(70, 115, 200);
                    break;
            }
        }
        private void btnNext_Click(
    object sender,
    EventArgs e)
        {
            if (currentStep < 4)
            {
                ShowStep(currentStep + 1);
            }
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
    }
}