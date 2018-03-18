using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace BangCuuChuong
{
	public partial class BangCuuChuong : Form
	{
		public BangCuuChuong()
		{
			InitializeComponent();
			tbxHeso.Text = tbxKetqua.Text = "";
		}

		private void tbxHeso_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnXuat_Click(object sender, EventArgs e)
		{
			bool phepToan = rbtNhan.Checked;
			int check;
			int.TryParse(tbxHeso.Text, out check);
			if (check == 0)
			{
				if (tbxHeso.Text == "all")
				{
					if (phepToan)
					{
						tbxKetqua.Text = "";
						for (int i = 1; i <= 10; i++, tbxKetqua.Text += "\r\n")
							for (int j = 2; j <= 9; j++)
							{
								int result = i * j;
								string t = result.ToString();
								if (i < 10)
								{
									if (result < 10)
									{
										t += " ";
										tbxKetqua.Text += j + " x " + i + "   = " + t + "\r\t";
									}
									else
										tbxKetqua.Text += j + " x " + i + "   = " + i * j + "\r\t";
								}
								else
									tbxKetqua.Text += j + " x " + i + " = " + i * j + "\r\t";
							}
					}
					else
					{
						tbxKetqua.Text = "";
						int soBiChia = 2, t = 1;
						for (int i = 1; i <= 10; i++, tbxKetqua.Text += "\r\n", soBiChia = i * t)
							for (int j = 2; j <= 9; j++)
							{
								t = j;
								soBiChia = i * t;
								string t1 = soBiChia.ToString();
								int result = soBiChia / j;
								string t2 = result.ToString();
								if (soBiChia < 10)
									t1 += "  ";
								if (result < 10)
									t2 += " ";
								tbxKetqua.Text += t1 + " : " + j + " = " + t2 + "\r\t";
							}
					}
				}
				if (tbxHeso.Text != "all")
				{
					tbxKetqua.Text = "";
					tbxKetqua.Text = "Bạn nhập không chính xác. \r\nĐề nghị nhập lại!";
				}
			}
			else
			{
				int heSo = int.Parse(tbxHeso.Text);
				if (phepToan)
				{
					tbxKetqua.Text = "";
					for (int i = 1; i <= 10; i++)
					{
						if (i == 10)
							tbxKetqua.Text += heSo + " x " + i + " = " + heSo * i + "\r\n";
						else
							tbxKetqua.Text += heSo + " x " + i + "   = " + heSo * i + "\r\n";
					}
				}
				else
				{
					tbxKetqua.Text = "";
					int soBiChia = 0;
					for (int i = 1; i <= 10; i++)
					{
						soBiChia += heSo;
						if (soBiChia < 10)
							tbxKetqua.Text += soBiChia + "   : " + heSo + " = " + soBiChia / heSo + "\r\n";
						else
							tbxKetqua.Text += soBiChia + " : " + heSo + " = " + soBiChia / heSo + "\r\n";
					}
				}
			}
		}
	}
}