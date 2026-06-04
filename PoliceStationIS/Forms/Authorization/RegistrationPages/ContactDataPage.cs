using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Authorization.RegistrationPages
{
    public partial class ContactDataPage : UserControl
    {
        public string Phone =>
    txtPhone.Text;

        public string ResidentialAddress =>
            txtAddress.Text;
        public ContactDataPage()
        {
            InitializeComponent();
        }

    }
}
