using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow
        (IntPtr hwand, int dwTime, AnimateWindowFlags flags);

        enum AnimateWindowFlags : uint
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            AnimateWindow(frm.Handle, 1000, AnimateWindowFlags.AW_ACTIVATE | AnimateWindowFlags.AW_BLEND);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimateWindow(pictureBox1.Handle, 1000, AnimateWindowFlags.AW_SLIDE | AnimateWindowFlags.AW_CENTER | AnimateWindowFlags.AW_HIDE);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnimateWindow(pictureBox1.Handle, 1000, AnimateWindowFlags.AW_SLIDE | AnimateWindowFlags.AW_CENTER | AnimateWindowFlags.AW_ACTIVATE);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            AnimateWindow(frm.Handle, 1000, AnimateWindowFlags.AW_SLIDE | AnimateWindowFlags.AW_CENTER | AnimateWindowFlags.AW_ACTIVATE);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE);

        }
    }
}
