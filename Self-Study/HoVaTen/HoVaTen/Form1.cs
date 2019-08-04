using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace HoVaTen
{
	public partial class Form_HoVaTen : Form
	{
		public Form_HoVaTen()
		{
			InitializeComponent();
		}
		public class Chuoi
		{
			string tenCT = "Chương trình xử lý họ và tên";
			public string In()
			{
				return tenCT;
			}
			public string Ten(string hoTen)
			{
				if (hoTen != "")
				{
					int lio = hoTen.LastIndexOf(" ");
					return hoTen.Substring(lio + 1, hoTen.Length - lio - 1);
				}
				else return "";
			}
			public string HoLot(string hoTen)
			{
				if (hoTen != "")
				{
					int lio = hoTen.LastIndexOf(" ");
					return hoTen.Substring(0, lio);
				}
				else return "";
			}
			public int demTu(string hoTen)
			{
				int count;
				const char Space = ' ';
				string s = hoTen.Trim();
				count = s.Split(Space).Length;
				return count;
			}
			public string Proper(string hoTen)
			{
				TextInfo myTl = new CultureInfo("en-US", false).TextInfo;
				return myTl.ToTitleCase(hoTen.ToLower());
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.txtHoVaTen.Select();
		}

		private void btnIn_Click(object sender, EventArgs e)
		{
			Chuoi s = new Chuoi();
			this.txtKetQua.Text = s.In();
		}

		private void btnHoLot_Click(object sender, EventArgs e)
		{
			Chuoi s = new Chuoi();
			this.txtKetQua.Text = "Họ lót: " + s.HoLot(this.txtHoVaTen.Text);
		}

		private void btnTen_Click(object sender, EventArgs e)
		{
			Chuoi s = new Chuoi();
			this.txtKetQua.Text = "Tên: " + s.Ten(this.txtHoVaTen.Text);
		}

		private void btnDemTu_Click(object sender, EventArgs e)
		{
			Chuoi s = new Chuoi();
			this.txtKetQua.Text = "Tổng số từ: ";
			this.txtKetQua.Text += s.demTu(this.txtHoVaTen.Text);
		}

		private void btnVietHoa_Click(object sender, EventArgs e)
		{
			Chuoi s = new Chuoi();
			this.txtKetQua.Text = "Kết quả là: ";
			this.txtKetQua.Text += s.Proper(this.txtHoVaTen.Text);
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			this.txtKetQua.Text = "";
			this.txtHoVaTen.Text = "";
			this.txtHoVaTen.Focus();
		}

		private void btnDung_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}