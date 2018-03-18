using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				//if (cbxNhuan.Checked == true)
				//	rtbKetQua.Text = Calculate.convertLunar2Solar(ngay, thang, nam, 1);
				//else rtbKetQua.Text = Calculate.convertLunar2Solar(ngay, thang, nam, 0);
			}
		}
	}
}
