using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoliceStationIS.Forms.Squads
{
    partial class PatrolEventJournalForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlInfo;
        private Label lblSquadTitle;
        private Label lblSquadValue;
        private Label lblEventsCountTitle;
        private Label lblEventsCountValue;

        private Panel pnlEvents;
        private Label lblEventsTitle;
        private FlowLayoutPanel flpEvents;

        private Panel pnlBottom;
        private Button btnPrintJournal;
        private Button btnClose;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ============================================================
            // FORM
            // ============================================================

            this.BackColor =
                Color.FromArgb(
                    5,
                    24,
                    58);

            this.ClientSize =
                new Size(
                    900,
                    720);

            this.FormBorderStyle =
                FormBorderStyle.FixedDialog;

            this.MaximizeBox =
                false;

            this.MinimizeBox =
                false;

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.Text =
                "Полный журнал событий";

            // ============================================================
            // HEADER
            // ============================================================

            pnlHeader =
                new Panel();

            pnlHeader.BackColor =
                Color.FromArgb(
                    30,
                    58,
                    117);

            pnlHeader.BorderStyle =
                BorderStyle.FixedSingle;

            pnlHeader.Location =
                new Point(
                    20,
                    20);

            pnlHeader.Size =
                new Size(
                    860,
                    95);


            lblTitle =
                new Label();

            lblTitle.Text =
                "ПОЛНЫЙ ЖУРНАЛ СОБЫТИЙ";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    16F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.AutoSize =
                true;

            lblTitle.Location =
                new Point(
                    20,
                    14);


            Panel pnlTitleLine =
                new Panel();

            pnlTitleLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlTitleLine.Location =
                new Point(
                    23,
                    47);

            pnlTitleLine.Size =
                new Size(
                    32,
                    3);


            lblSubtitle =
                new Label();

            lblSubtitle.Text =
                "Сведения о событиях патрульно-постового обслуживания";

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            lblSubtitle.ForeColor =
                Color.Gainsboro;

            lblSubtitle.AutoSize =
                true;

            lblSubtitle.Location =
                new Point(
                    21,
                    59);


            pnlHeader.Controls.Add(
                pnlTitleLine);

            pnlHeader.Controls.Add(
                lblTitle);

            pnlHeader.Controls.Add(
                lblSubtitle);

            // ============================================================
            // INFO
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
                new Point(
                    20,
                    130);

            pnlInfo.Size =
                new Size(
                    860,
                    70);


            lblSquadTitle =
                new Label();

            lblSquadTitle.Text =
                "Наряд:";

            lblSquadTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblSquadTitle.ForeColor =
                Color.White;

            lblSquadTitle.AutoSize =
                true;

            lblSquadTitle.Location =
                new Point(
                    20,
                    15);


            lblSquadValue =
                new Label();

            lblSquadValue.Text =
                "—";

            lblSquadValue.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblSquadValue.ForeColor =
                Color.Gainsboro;

            lblSquadValue.AutoSize =
                true;

            lblSquadValue.Location =
                new Point(
                    100,
                    14);


            lblEventsCountTitle =
                new Label();

            lblEventsCountTitle.Text =
                "Событий:";

            lblEventsCountTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblEventsCountTitle.ForeColor =
                Color.White;

            lblEventsCountTitle.AutoSize =
                true;

            lblEventsCountTitle.Location =
                new Point(
                    620,
                    15);


            lblEventsCountValue =
                new Label();

            lblEventsCountValue.Text =
                "0";

            lblEventsCountValue.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblEventsCountValue.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblEventsCountValue.AutoSize =
                true;

            lblEventsCountValue.Location =
                new Point(
                    700,
                    14);


            pnlInfo.Controls.Add(
                lblSquadTitle);

            pnlInfo.Controls.Add(
                lblSquadValue);

            pnlInfo.Controls.Add(
                lblEventsCountTitle);

            pnlInfo.Controls.Add(
                lblEventsCountValue);

            // ============================================================
            // EVENTS
            // ============================================================

            pnlEvents =
                new Panel();

            pnlEvents.BackColor =
                Color.FromArgb(
                    18,
                    38,
                    74);

            pnlEvents.BorderStyle =
                BorderStyle.FixedSingle;

            pnlEvents.Location =
                new Point(
                    20,
                    215);

            pnlEvents.Size =
                new Size(
                    860,
                    420);


            lblEventsTitle =
                new Label();

            lblEventsTitle.Text =
                "ЗАПИСИ ЖУРНАЛА";

            lblEventsTitle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblEventsTitle.ForeColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            lblEventsTitle.AutoSize =
                true;

            lblEventsTitle.Location =
                new Point(
                    18,
                    12);


            Panel pnlEventsLine =
                new Panel();

            pnlEventsLine.BackColor =
                Color.FromArgb(
                    212,
                    160,
                    23);

            pnlEventsLine.Location =
                new Point(
                    18,
                    38);

            pnlEventsLine.Size =
                new Size(
                    820,
                    1);


            flpEvents =
                new FlowLayoutPanel();

            flpEvents.Location =
                new Point(
                    15,
                    50);

            flpEvents.Size =
                new Size(
                    825,
                    355);

            flpEvents.AutoScroll =
                true;

            flpEvents.FlowDirection =
                FlowDirection.TopDown;

            flpEvents.WrapContents =
                false;

            flpEvents.BackColor =
                Color.Transparent;


            pnlEvents.Controls.Add(
                lblEventsTitle);

            pnlEvents.Controls.Add(
                pnlEventsLine);

            pnlEvents.Controls.Add(
                flpEvents);

            // ============================================================
            // BOTTOM
            // ============================================================

            pnlBottom =
                new Panel();

            pnlBottom.BackColor =
                Color.Transparent;

            pnlBottom.Location =
                new Point(
                    20,
                    650);

            pnlBottom.Size =
                new Size(
                    860,
                    50);


            btnPrintJournal =
                CreateActionButton(
                    "Печать журнала");

            btnPrintJournal.Location =
                new Point(
                    580,
                    0);

            btnPrintJournal.Size =
                new Size(
                    145,
                    42);


            btnClose =
                CreateActionButton(
                    "Закрыть");

            btnClose.Location =
                new Point(
                    735,
                    0);

            btnClose.Size =
                new Size(
                    125,
                    42);


            pnlBottom.Controls.Add(
                btnPrintJournal);

            pnlBottom.Controls.Add(
                btnClose);

            // ============================================================
            // ADD TO FORM
            // ============================================================

            this.Controls.Add(
                pnlHeader);

            this.Controls.Add(
                pnlInfo);

            this.Controls.Add(
                pnlEvents);

            this.Controls.Add(
                pnlBottom);

            this.ResumeLayout(false);
        }


        // ================================================================
        // BUTTON
        // ================================================================

        private Button CreateActionButton(
            string text)
        {
            Button button =
                new Button();

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
    }
}