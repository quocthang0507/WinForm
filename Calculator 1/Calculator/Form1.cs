using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
	public partial class Calculator : Form
	{
		double num1, num2;
		string temp;
		double kq = 0;
		char pt;
		int count = 0;
		public Calculator()
		{
			InitializeComponent();
		}

		private void So0_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "0";
			temp += "0";
		}

		private void So1_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "1";
			temp += "1";
		}

		private void So2_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "2";
			temp += "2";
		}

		private void So3_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "3";
			temp += "3";
		}

		private void So4_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "4";
			temp += "4";
		}

		private void So5_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "5";
			temp += "5";
		}

		private void So6_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "6";
			temp += "6";
		}

		private void So7_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "7";
			temp += "7";
		}

		private void So8_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "8";
			temp += "8";
		}

		private void So9_Click(object sender, EventArgs e)
		{
			txtHienThiPT.Text += "9";
			temp += "9";
		}

		private void Add_Click(object sender, EventArgs e)
		{
			count++;
			if (count == 1)
			{
				num1 = double.Parse(txtHienThiPT.Text);
			}
			else
			{
				DauBang_Click(sender, e);
				if (pt == '+')
				{
					num1 = kq;
					txtHienThiKQ.Text = "";
				}
				else if (pt != '+')
				{
					num1 = kq;
					txtHienThiPT.Text = "";
					txtHienThiPT.Text = num1.ToString();
				}
			}
			temp = "";
			pt = '+';
			txtHienThiPT.Text += " + ";
		}

		private void Sub_Click(object sender, EventArgs e)
		{
			count++;
			if (count == 1)
			{
				num1 = double.Parse(txtHienThiPT.Text);
			}
			else
			{
				DauBang_Click(sender, e);
				if (pt == '-')
				{
					num1 = kq;
					txtHienThiKQ.Text = "";
				}
				else if (pt != '-')
				{
					num1 = kq;
					txtHienThiPT.Text = "";
					txtHienThiPT.Text = num1.ToString();
				}
			}
			temp = "";
			pt = '-';
			txtHienThiPT.Text += " - ";
		}

		private void Mul_Click(object sender, EventArgs e)
		{
			count++;
			if (count == 1)
			{
				num1 = double.Parse(txtHienThiPT.Text);
				txtHienThiKQ.Text = "";
			}
			else
			{
				DauBang_Click(sender, e);
				if (pt == 'x')
				{
					num1 = kq;
					txtHienThiKQ.Text = "";
				}
				else if (pt != 'x')
				{
					num1 = kq;
					txtHienThiPT.Text = "";
					txtHienThiPT.Text = num1.ToString();
				}
			}
			temp = "";
			pt = 'x';
			txtHienThiPT.Text += " x ";
		}

		private void Div_Click(object sender, EventArgs e)
		{
			count++;
			if (count == 1)
			{
				num1 = double.Parse(txtHienThiPT.Text);
				txtHienThiKQ.Text = "";
			}
			else
			{
				DauBang_Click(sender, e);
				if (pt == '/')
				{
					num1 = kq;
					txtHienThiKQ.Text = "";
				}
				else if (pt != '/')
				{
					num1 = kq;
					txtHienThiPT.Text = "";
					txtHienThiPT.Text = num1.ToString();
				}
			}
			temp = "";
			pt = '/';
			txtHienThiPT.Text += " / ";
		}
		private void TinhToan(double so1, double so2, char pt)
		{
			switch (pt)
			{
				case '+':
					kq = so1 + so2;
					txtHienThiKQ.Text = kq.ToString();
					break;
				case '-':
					kq = so1 - so2;
					txtHienThiKQ.Text = kq.ToString();
					break;
				case 'x':
					kq = so1 * so2;
					txtHienThiKQ.Text = kq.ToString();
					break;
				case '/':
					if (so2 == 0)
						MessageBox.Show("Không thể thực hiện phép chia cho 0!\r\nVui lòng chọn số khác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
					{
						kq = so1 / so2;
						txtHienThiKQ.Text = kq.ToString();
					}
					break;
			}
		}

		private void DauBang_Click(object sender, EventArgs e)
		{
			num2 = double.Parse(temp);
			TinhToan(num1, num2, pt);
		}

		private void Del_Click(object sender, EventArgs e)
		{
			txtHienThiKQ.Text = "";
			txtHienThiPT.Text = "";
			temp = "";
			num1 = num2 = kq = count = 0;
		}

		private void AddSub_Click(object sender, EventArgs e)
		{
			num1 = double.Parse(temp) * -1;
			txtHienThiPT.Text = num1.ToString();
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}