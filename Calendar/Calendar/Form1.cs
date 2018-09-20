using System;

namespace Calendar
{
	public partial class Form_Duong_Am : System.Windows.Forms.Form
	{
		public Form_Duong_Am()
		{
			InitializeComponent();
		}

		private void btnTuDong_Click(object sender, EventArgs e)
		{
			Calculate.ThoiGian();
			tbNgay.Text = tbThang.Text = tbNam.Text = "";
			tbNgay.Text = Calculate.ngay.ToString();
			tbThang.Text = Calculate.thang.ToString();
			tbNam.Text = Calculate.nam.ToString();
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
				rtbKetQua.Text = Calculate.convertSolar2Lunar(ngay, thang, nam);
				rtbKetQua.Text += Calculate.Can_Chi(ngay, thang, nam);
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			tbNgay.Text = tbThang.Text = tbNam.Text = "";
			rtbKetQua.Text = "";
		}

		private void btnChuyen_Click(object sender, EventArgs e)
		{
			Form_Am_Duong form = new Form_Am_Duong();
			form.ShowDialog();
		}
	}
}