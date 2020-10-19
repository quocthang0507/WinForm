using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanizerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            var number = Convert.ToInt32(txt_input.Text);
            txt_output_en.Text = number.ToWords().Transform(To.SentenceCase);
            txt_output_vi.Text = number.ToWords(new System.Globalization.CultureInfo("vi")).Transform(To.SentenceCase);
            try
            {
                txt_Roman.Text = number.ToRoman();
            }
            catch (Exception)
            {                
            }
        }
    }
}
