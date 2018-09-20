using System;
using System.Windows.Forms;

namespace Calendar
{
	public partial class Form_Am_Duong : Form
	{
		public Form_Am_Duong()
		{
			InitializeComponent();
		}

		private void btnChuyen_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			tbNgay.Text = tbThang.Text = tbNam.Text = "";
			rtbKetQua.Text = "";
		}

		private void btnNhap_Click(object sender, EventArgs e)
		{
			int ngay, thang, nam;
			if (tbNgay.Text == "" || tbThang.Text == "" || tbNam.Text == "")
			{
				rtbKetQua.Text = "Bạn chưa nhập đủ thông tin!";
			}
			else
			{
				ngay = int.Parse(tbNgay.Text);
				thang = int.Parse(tbThang.Text);
				nam = int.Parse(tbNam.Text);
				if (cbxNhuan.Checked == true)
					rtbKetQua.Text = Calculate.convertLunar2Solar(ngay, thang, nam, 1);
				else rtbKetQua.Text = Calculate.convertLunar2Solar(ngay, thang, nam, 0);
			}
		}

		private void btnTuDong_Click(object sender, EventArgs e)
		{
			Calculate.ThoiGian();
			string[] tg = Calculate.convertSolar2Lunar(Calculate.ngay, Calculate.thang, Calculate.nam).Split('/');
			tbNgay.Text = tg[0].TrimEnd();
			tbThang.Text = tg[1].Trim();
			tbNam.Text = tg[2].Split(',')[0].Trim();
			if (int.Parse(tg[2].Split(',')[1].Trim()) == 0)
				cbxNhuan.Checked = false;
			else cbxNhuan.Checked = true;
		}
	}
}
