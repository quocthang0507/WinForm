using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
	public partial class DangNhap : Form
	{
		public static string userName = "thang_050798", passWord = "12345679";

		public DangNhap()
		{
			InitializeComponent();
		}

		private void btn_DangNhap_Click(object sender, EventArgs e)
		{
			if (this.tbx_TenDangNhap.Text == userName && this.tbx_MatKhau.Text == passWord)
			{
				MessageBox.Show("Bạn đã đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			else
			{
				MessageBox.Show("Bạn nhập sai tên đăng nhập/ mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.tbx_TenDangNhap.Focus();
			}
		}

		private void btn_Thoat_Click(object sender, EventArgs e)
		{
			DialogResult traLoi;
			traLoi = MessageBox.Show("Bạn thật sự muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (traLoi == DialogResult.OK)
			{
				Application.Exit();
			}
		}
	}
}
