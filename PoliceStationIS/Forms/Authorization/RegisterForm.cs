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

namespace PoliceStationIS.Forms.Authorization
{
    public partial class RegisterForm : Form
    {
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
        }
    }
}