using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }          
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SendToBack();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var hour = DateTime.Now.Hour; 
            var minute = DateTime.Now.Minute;
            var second = DateTime.Now.Second;
            if(second % 2 == 0)
            {
                lbl_splash.Visible = true;
            }
            else
            {
                lbl_splash.Visible = false;
            }
            txt_hour.Value = hour;
            txt_minute.Value = minute;
            txt_second.Value = second;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Process.Start("https://laptrinhvb.net");
        }
    }
}
