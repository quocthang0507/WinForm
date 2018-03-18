﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPTBac2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			lblKetqua.Text = lblX1.Text = lblX2.Text = "";
			txtA.Select();
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			double a, b, c;
			double delta;
			double x1, x2;
			a = double.Parse(txtA.Text);
			b = double.Parse(txtB.Text);
			c = double.Parse(txtC.Text);
			if (a != 0)
			{
				delta = b * b - 4 * a * c;
				if (delta > 0)
				{
					x1 = (-b + Math.Sqrt(delta)) / 2 / a;
					x2 = (-b - Math.Sqrt(delta)) / 2 / a;
					lblKetqua.Text = "Phương trình có 2 nghiệm phân biệt : ";
					lblX1.Text = "X1 = " + x1;
					lblX2.Text = "X2 = " + x2;
				}
				else if (delta == 0)
				{
					lblKetqua.Text = "Phương trình có nghiệm kép : ";
					x1 = -b / 2 / a;
					lblX1.Text = "X1 = X2 = " + x1;
					lblX2.Text = "";
				}
				else
				{
					lblKetqua.Text = "Phương trình vô nghiệm";
					lblX1.Text = lblX2.Text = "";
				}
			}
			else if (a == 0)
			{
				x1 = -c / b;
				lblKetqua.Text = "Đây là phương trình bậc nhất có nghiệm đơn : ";
				lblX1.Text = "X = " + x1;
				lblX2.Text = "";
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void txtA_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			txtA.Text = txtB.Text = txtC.Text = "";
			lblKetqua.Text = lblX1.Text = lblX2.Text = "";
		}

		private void lblTieude_Click(object sender, EventArgs e)
		{

		}

		private void txtB_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtC_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}