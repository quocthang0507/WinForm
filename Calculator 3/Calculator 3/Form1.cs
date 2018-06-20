using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_3
{
	public partial class Form1 : Form
	{
		PolishNotation PN = new PolishNotation();
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_Tinh_Click(object sender, EventArgs e)
		{
			PN.Reset();
			PN.bieuThuc = tbx_TrungTo.Text;
			try
			{
				PN.KT_BT_Dung();
			}
			catch (Exception ex)
			{
				lbl_Loi.Text = ex.Message;
			}
			//PN.TrungTo_HauTo();
			//tbx_HauTo.Text = PN.Xuat_BieuThuc_HauTo();
			//tbx_KetQua.Text = PN.Tinh_BieuThuc_HauTo().ToString();
		}
	}
}
