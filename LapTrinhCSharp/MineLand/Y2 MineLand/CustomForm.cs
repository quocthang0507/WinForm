using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Y2_MineLand
{
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
        }
        public CustomForm(int rows,int cols, int mines):this()
        {
            numericUpDown1.Value = rows;
            numericUpDown2.Value = cols;
            numericUpDown3.Value = mines;

        }
        public int Rows
        {
            get { return (int)numericUpDown1.Value; }
        }
        public int Cols
        {
            get { return (int)numericUpDown2.Value; }
        }
        public int Mines
        {
            get { return (int)numericUpDown3.Value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value >= numericUpDown1.Value * numericUpDown2.Value)
            {
                MessageBox.Show("Invalid input number of Mines!");
            }
            else
                this.DialogResult = DialogResult.OK;
        }


    }
}
