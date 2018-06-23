using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
	public partial class DanhMuc : Form
	{
		public DanhMuc()
		{
			InitializeComponent();
		}

		string strConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = QuanLyBanHang;Integrated Security = True";

		SqlConnection conn = null;

		SqlDataAdapter daTable = null;

		DataTable dtTable = null;

		private void DanhMucKhachHang_Load(object sender, EventArgs e)
		{
			try
			{
				conn = new SqlConnection(strConnectionString);
				int intDM = Convert.ToInt32(this.Text);
				switch (intDM)
				{
					case 1:
						lbl_DM.Text = "Danh Mục Thành Phố";
						daTable = new SqlDataAdapter("Select ThanhPho, TenThanhPho From ThanhPho", conn);
						break;
					case 2:
						lbl_DM.Text = "Danh Mục Khách Hàng";
						daTable = new SqlDataAdapter("Select MaKH, TenCTy From KhachHang", conn);
						break;
					case 3:
						lbl_DM.Text = "Danh Mục Nhân Viên";
						daTable = new SqlDataAdapter("Select MaNV, HoLot, Ten From NhanVien", conn);
						break;
					case 4:
						lbl_DM.Text = "Danh Mục Sản Phẩm";
						daTable = new SqlDataAdapter("Select MaSP, TenSP, DonViTinh, DonGia From SanPham", conn);
						break;
					case 5:
						lbl_DM.Text = "Danh Mục Hoá Đơn";
						daTable = new SqlDataAdapter("Select MaHD, MaKH, MaNV From HoaDon", conn);
						break;
					case 6:
						lbl_DM.Text = "Danh Mục Chi Tiết Hoá Đơn";
						daTable = new SqlDataAdapter("Select * From ChiTietHoaDon", conn);
						break;
					default:
						break;
				}
				dtTable = new DataTable();
				dtTable.Clear();
				daTable.Fill(dtTable);
				dgv_DanhMuc.DataSource = dtTable;
				dgv_DanhMuc.AutoResizeColumns();
			}
			catch (SqlException)
			{
				MessageBox.Show("Lỗi trong khi lấy nội dung từ table!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_TroVe_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
