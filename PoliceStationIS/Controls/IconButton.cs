using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Controls
{
    public class IconButton : Button
    {
        private Image buttonIcon;

        public Image ButtonIcon
        {
            get => buttonIcon;

            set
            {
                buttonIcon = value;
                Invalidate();
            }
        }

        public int IconSize { get; set; } = 22;

        public int IconLeft { get; set; } = 10;

        public IconButton()
        {
            FlatStyle = FlatStyle.Flat;

            FlatAppearance.BorderSize = 1;

            FlatAppearance.BorderColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            BackColor =
                Color.FromArgb(
                    42,
                    73,
                    133);

            ForeColor =
                Color.White;

            Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            TextAlign =
                ContentAlignment.MiddleCenter;

            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (buttonIcon == null)
                return;

            Rectangle iconRect =
                new Rectangle(
                    IconLeft,
                    (Height - IconSize) / 2,
                    IconSize,
                    IconSize);

            e.Graphics.DrawImage(
                buttonIcon,
                iconRect);
        }
    }
}