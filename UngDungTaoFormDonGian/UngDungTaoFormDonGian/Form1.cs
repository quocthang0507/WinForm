using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungTaoFormDonGian
{
	public partial class Form1 : Form
	{
		AccessData ac = new AccessData();
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_HienThi_Click(object sender, EventArgs e)
		{
			string sql = "Select * from SinhVien";
			dgv_HienThi.DataSource = ac.CreateTable(sql);
		}

		private void btn_Them_Click(object sender, EventArgs e)
		{
			string sql = "Insert into SinhVien values (N'" + tbx_MSSV.Text + "', N'" + tbx_HoTen.Text + "')";
			try
			{
				ac.ExcuteNonQuery(sql);
			}
			catch (Exception)
			{
				MessageBox.Show("Đã có sinh viên này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			string sql1 = "Select * from SinhVien";
			dgv_HienThi.DataSource = ac.CreateTable(sql1);
		}

		private void btn_Sua_Click(object sender, EventArgs e)
		{
			string sql = "Update SinhVien Set TenSV = N'" + tbx_HoTen.Text + "' Where MaSV = N'" + tbx_MSSV.Text + "'";
			ac.ExcuteNonQuery(sql);
			string sql1 = "Select * from SinhVien";
			dgv_HienThi.DataSource = ac.CreateTable(sql1);
		}

		private void CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			tbx_MSSV.Text = dgv_HienThi.Rows[index].Cells[0].Value.ToString();
			tbx_HoTen.Text = dgv_HienThi.Rows[index].Cells[1].Value.ToString();
		}

		private void btn_Xoa_Click(object sender, EventArgs e)
		{
			string sql = "Delete from SinhVien Where MaSV = '" + tbx_MSSV.Text + "'";
			ac.ExcuteNonQuery(sql);
			string sql1 = "Select * from SinhVien";
			dgv_HienThi.DataSource = ac.CreateTable(sql1);
		}
	}
}
