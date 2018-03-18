using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaoFormDangNhap
{
	public partial class Form_DangNhap : Form
	{
		static int dem = 1;
		public Form_DangNhap()
		{
			InitializeComponent();
		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			string thongbao="";
			thongbao += this.txtUser.Text;
			thongbao += "\nMật khẩu là: ";
			thongbao += this.txtPass.Text;
			if (this.chkNho.Checked==true)
			{
				thongbao += "\r\nBạn có ghi nhớ!";
			}
			MessageBox.Show(thongbao, "Thông báo");
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			this.txtUser.Text = "";
			this.txtPass.Text = "";
			this.txtUser.Focus();
			this.chkNho.Checked = false;
		}

		private void btnDung_Click(object sender, EventArgs e)
		{
			DialogResult traloi;
			traloi = MessageBox.Show("Bạn có muốn thoát không?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (traloi == DialogResult.OK)
				Application.Exit();
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			if (dem % 2 != 0)
			{
				this.txtPass.PasswordChar = '\0';
			}
			else
				this.txtPass.PasswordChar = '*';
			dem++;
		}
	}
}
