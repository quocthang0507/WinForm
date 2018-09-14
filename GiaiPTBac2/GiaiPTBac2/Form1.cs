using System;
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

		private void button1_Click(object sender, EventArgs e)
		{
			double a = 0, b = 0, c = 0;
			double delta;
			double x1, x2;
			if (double.TryParse(txtA.Text, out a) || double.TryParse(txtB.Text, out b) || double.TryParse(txtC.Text, out c))
			{
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
			else lblKetqua.Text = "Bạn nhập chưa đầy đủ thông tin/ \r\nhoặc chưa đúng";
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			txtA.Text = txtB.Text = txtC.Text = "";
			lblKetqua.Text = lblX1.Text = lblX2.Text = "";
		}
	}
}