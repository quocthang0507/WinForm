using System;
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
			tbx_HauTo.Text = tbx_KetQua.Text = "";
			PN.bieuThuc = tbx_TrungTo.Text;
			bool error = false;
			try
			{
				error = PN.KT_BT_Dung();
			}
			catch (Exception ex)
			{
				lbl_Loi.Text = ex.Message;
			}
			if (error)
			{
				lbl_Loi.Text = "";
				PN.TrungTo_HauTo();
				tbx_HauTo.Text = PN.Xuat_BieuThuc_HauTo();
				tbx_KetQua.Text = PN.Tinh_BieuThuc_HauTo().ToString();
			}
		}

		private void tbx_TrungTo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == (char)37 ||
				e.KeyChar == (char)43 || e.KeyChar == (char)45 ||
				e.KeyChar == (char)42 || e.KeyChar == (char)47 || e.KeyChar == (char)40 || e.KeyChar == (char)41))
				e.Handled = true;
		}
	}
}
