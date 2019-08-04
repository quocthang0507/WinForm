using System;
using System.Windows.Forms;

namespace howto_fit_font
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			autoResizeLabel1.Text = textBox1.Text;
		}
	}
}
