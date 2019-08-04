using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OMR_Tools
{
    public partial class omrToolsForm : Form
    {
        public omrToolsForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OMR.Forms.omrSheetDesigner sdf = new OMR.Forms.omrSheetDesigner();
            Hide();
            sdf.StartPosition = FormStartPosition.CenterScreen;
            sdf.ShowDialog(this);
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OMR.Forms.answerKeyDesigner akdf = new OMR.Forms.answerKeyDesigner();
            akdf.StartPosition = FormStartPosition.CenterScreen;
            Hide();
            akdf.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo("omrConsole_classic.exe");
            Hide();
            p.WaitForExit();
            Show();
        }
    }
}
