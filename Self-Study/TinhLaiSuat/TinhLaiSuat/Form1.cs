using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhLaiSuat
{
	public partial class TinhLaiSuat : Form
	{
		public TinhLaiSuat()
		{
			InitializeComponent();
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void btTinh_Click(object sender, EventArgs e)
		{
			decimal tienBanDau = Convert.ToDecimal(txtTienBanDau.Text); //Hoặc dùng Decimal.Parse(txtTienBanDau.Text)
			double laiSuat = double.Parse(txtLaiSuat.Text); //Tương tự Convert.ToDouble(txtLaiSuat.Text)
			int nam = Convert.ToInt32(nudNam.Value);
			decimal ketQua=tienBanDau;
			string dauRa = "Năm\t Khoản tiền thu được gồm lãi suất \r\n";
			for (int nams = 1; nams <= nam; nams++)
			{
				ketQua += tienBanDau*(decimal)laiSuat/100;
				dauRa += (nams + "\t" + string.Format("{0:C}", ketQua) + "\r\n");
			}
			rtbKetQua.Text = dauRa;
		}

		private void btXoa_Click(object sender, EventArgs e)
		{
			txtLaiSuat.Text = "";
			txtTienBanDau.Text = "";
			rtbKetQua.Text = "";
			nudNam.Value = 0;
			
		}
	}
}
