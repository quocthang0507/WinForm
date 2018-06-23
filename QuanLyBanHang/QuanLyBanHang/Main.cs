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
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
			Form frm_login = new DangNhap();
			frm_login.ShowDialog();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form frm = new DoiMatKhau();
			frm.ShowDialog();
		}

		void XemDanhMuc(int intDanhMuc)
		{
			Form frm = new DanhMuc();
			frm.Text = intDanhMuc.ToString();
			frm.ShowDialog();
		}

		private void thànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(1);
		}

		private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(2);
		}

		private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(3);
		}

		private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(4);
		}

		private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(5);
		}

		private void chiTiếtHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			XemDanhMuc(6);
		}

		private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
