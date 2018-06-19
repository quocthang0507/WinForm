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
	public partial class DoiMatKhau : Form
	{
		public DoiMatKhau()
		{
			InitializeComponent();
		}

		private void changePassword()
		{
			if (this.tbx_MatKhauCu.Text == DangNhap.passWord)
			{
				if (this.tbx_MatKhauMoi.Text == this.tbx_NhapLaiMK.Text)
				{
					MessageBox.Show("Thay đổi mật khẩu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
					DangNhap.passWord = tbx_MatKhauMoi.Text;
				}
				else
				{
					this.tbx_NhapLaiMK.Focus();
					MessageBox.Show("Mật khẩu nhập lại không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Nhập sai mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.tbx_MatKhauCu.Focus();
			}
		}

		private void btn_DongY_Click(object sender, EventArgs e)
		{
			if (this.tbx_MatKhauCu.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbx_MatKhauCu.Focus();
			}
			else if (tbx_MatKhauMoi.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbx_MatKhauMoi.Focus();
			}
			else if (tbx_NhapLaiMK.Text == "")
			{
				MessageBox.Show("Bạn chưa nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tbx_NhapLaiMK.Focus();
			}
			else
			{
				changePassword();
			}
		}

		private void btn_Thoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
