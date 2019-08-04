using System;
using System.Windows.Forms;

namespace WindowsMedia_with_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] fileNames, filePaths;
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNames = openFileDialog1.SafeFileNames;
                filePaths = openFileDialog1.FileNames;
                foreach (String filename in fileNames)
                {
                    list_FileNhac.Items.Add(filename);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list_FileNhac.Items.Add("Tên file nhạc");
        }

        private void list_FileNhac_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = filePaths[list_FileNhac.SelectedIndex];
        }
    }
}
