using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienLuongCuaNhanVien
{
	public partial class Form1 : Form
	{
		public decimal mtongLuong, mtongPC;
		int mintongSoNhanVien;
		public Form1()
		{
			InitializeComponent();
		}

		private void txtgio_TextChanged(object sender, EventArgs e)
		{
			if (txtten.Text != "" && txtcoban.Text != "" && txtgio.Text != "")
			{
				btntinh.Enabled = true;
				btnxoa.Enabled = true;
				btnthoat.Enabled = true;
			}
		}

		private void btntinh_Click(object sender, EventArgs e)
		{
			decimal luongCB, gio, phuCap, luong;
			luongCB = decimal.Parse(txtcoban.Text);
			gio = Convert.ToDecimal(txtgio.Text);
			if (chkpc.Checked == true)
			{
				phuCap = 50000;
			}
			else
			{
				phuCap = 0;
			}
			luong = gio * luongCB + phuCap;
			txttongluong.Text = luong.ToString();
			mtongLuong += luong;
			mtongPC += phuCap;
			mintongSoNhanVien++;
		}

		private void btnxoa_Click(object sender, EventArgs e)
		{
			txtcoban.Text = null;
			txtgio.Text = "";
			txtten.Text = null;
			txttongluong.Text = "";
			btntinh.Enabled = false;
			btnxoa.Enabled = false;
		}

		private void btntongket_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Tổng số nhân viên: " + mintongSoNhanVien + "\nTổng phụ cấp: " + mtongPC + "\nTổng lương: " + mtongLuong, "Tổng kết", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnthoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult hopThoai = MessageBox.Show("Bạn thật sự muốn thoát khỏi ứng dụng không?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (hopThoai == DialogResult.Cancel)
				e.Cancel = true;
		}
	}
}