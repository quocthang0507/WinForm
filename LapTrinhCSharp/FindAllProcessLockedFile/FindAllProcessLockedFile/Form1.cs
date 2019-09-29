using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindAllProcessLockedFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list_process = Win32Processes.GetProcessesLockingFile(textBox1.Text);
            
            StringBuilder str = new StringBuilder();
            foreach (var item in list_process)
            {
                str.Append(item.ProcessName + Environment.NewLine);
                item.Kill();
            }

            txt_result.Text = str.ToString();


        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            using(var dlg = new OpenFileDialog())
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dlg.FileName;
                }
            }
        }
    }
}
