using System;
using System.Windows.Forms;

namespace howto_stopwatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DateTime StartTime;
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrClock.Enabled = !tmrClock.Enabled;
            btnStart.Text = tmrClock.Enabled ? "Stop" : "Start";
            StartTime = DateTime.Now;
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;

            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";

            int tenths = elapsed.Milliseconds;

            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00");

            lblElapsed.Text = text;
            lbl_milisecond.Text = tenths.ToString("000");
        }

    }
}
