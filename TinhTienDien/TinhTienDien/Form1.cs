using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienDien
{
	public partial class ChuongTrinh : Form
	{
		public int chiMuc;
		public ChuongTrinh()
		{
			InitializeComponent();
			ttbChiSoCu.Text = "";
			ttbChiSoMoi.Text = "";
			ttbDNTT.Text += 0;
			ttbKetQua.Text = "";
			cbbGioSD.SelectedItem = "";
			cbbMucDich.SelectedItem = "";
			cbbNoiSuDung.SelectedItem = "";
		}

		private void ltbMucDich_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cbbMucDich_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbbNoiSuDung.Items.Clear();
			cbbGioSD.Items.Clear();
			cbbGioSD.Text = "";
			if (cbbMucDich.SelectedItem == "1. Điện sinh hoạt")
			{
				cbbNoiSuDung.Items.Add("1. Sinh hoạt bậc thang");
				cbbNoiSuDung.Items.Add("2. Sinh hoạt gia đình tại huyện đảo");
				cbbNoiSuDung.Items.Add("3. Sinh hoạt gia đình tại huyện đảo Lý Sơn");
				cbbNoiSuDung.Items.Add("4. Sinh hoạt tại huyện đảo Phú Quý - Bình Thuận");
			}
			else if (cbbMucDich.SelectedItem == "2. Điện kinh doanh")
				cbbNoiSuDung.Items.Add("1. Kinh doanh, dịch vụ, du lịch,...");
			else if (cbbMucDich.SelectedItem == "3. Điện sản xuất")
			{
				cbbNoiSuDung.Items.Add("1. Đặc thù bơm tưới tiêu - Phú Quốc");
				cbbNoiSuDung.Items.Add("2. Bán buôn khu công nghiệp cấp điện áp 110KV");
				cbbNoiSuDung.Items.Add("3. Các ngành sản xuất bình thường");
				cbbNoiSuDung.Items.Add("4. Doanh nghiệp thuộc KCN A, Tuy Hạ");
				cbbNoiSuDung.Items.Add("5. Sản xuất tại huyện đảo Phú Quốc");
				cbbNoiSuDung.Items.Add("6. Sản xuất tại huyện đảo Lý Sơn");
			}
			else if (cbbMucDich.SelectedItem == "4. Điện cho các cơ quan hành chính")
			{
				cbbNoiSuDung.Items.Add("1. Hành chính sự nghiệp tại huyện đảo Phú Quốc");
				cbbNoiSuDung.Items.Add("2. Chiếu sáng công cộng tại huyện đảo Phú Quốc");
				cbbNoiSuDung.Items.Add("3. Cơ quan, trường học, bệnh viện tại Vũng Ngán & Bình Hưng - Khánh Hoà");
				cbbNoiSuDung.Items.Add("4. Cơ quan hành chính tại Vũng Ngán & Bình Hưng - Khánh Hoà");
				cbbNoiSuDung.Items.Add("5. Bệnh viện, trường học, nhà trẻ");
				cbbNoiSuDung.Items.Add("6. Hành chính sự nghiệp");
				cbbNoiSuDung.Items.Add("7. Hành chính sự nghiệp tại huyện đảo Phú Quốc");
				cbbNoiSuDung.Items.Add("8. Hành chính sự nghiệp tại huyện đảo Lý Sơn");
			}
			else if (cbbMucDich.SelectedItem == "5. Bán buôn điện")
			{
				cbbNoiSuDung.Items.Add("1. Bán buôn điện sinh hoạt cho tổ hợp TM - DV - SH");
				cbbNoiSuDung.Items.Add("2. Bán buôn khu tập thể - Thành thị - MBA của EVN");
				cbbNoiSuDung.Items.Add("3. Bán buôn khu tập thể - Huyện lỵ - MBA của KH");
				cbbNoiSuDung.Items.Add("4. Bán buôn khu tập thể - Huyện lỵ - MBA của EVN");
				cbbNoiSuDung.Items.Add("5. Bán buôn khu tập thể - Thành thị - MBA của KH");
				cbbNoiSuDung.Items.Add("6. Bán buôn sinh hoạt điện nông thôn");
			}
			else
			{
				cbbNoiSuDung.Items.Add("1. Bán theo giá ngoại tệ cho Lào của CTy Điện Lực 1");
				cbbNoiSuDung.Items.Add("2. Bán theo giá ngoại tệ cho Campuchia của Cty Điện Lực 2");
				cbbNoiSuDung.Items.Add("3. Bán theo giá ngoại tệ cho Lào của CTy Điện Lực 3");
			}
		}

		private void cbbNoiSuDung_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Điện sinh hoạt
			cbbGioSD.Items.Clear();
			cbbGioSD.Text = "";
			if (cbbNoiSuDung.SelectedItem == "1. Sinh hoạt bậc thang")
				chiMuc = 1;
			else if (cbbNoiSuDung.SelectedItem == "2. Sinh hoạt gia đình tại huyện đảo")
				chiMuc = 2;
			else if (cbbNoiSuDung.SelectedItem == "3. Sinh hoạt gia đình tại huyện đảo Lý Sơn")
				chiMuc = 3;
			else if (cbbNoiSuDung.SelectedItem == "4. Sinh hoạt tại huyện đảo Phú Quý - Bình Thuận")
				chiMuc = 4;
			//Điện kinh doanh
			else if (cbbNoiSuDung.SelectedItem == "1. Kinh doanh, dịch vụ, du lịch,...")
			{
				chiMuc = 5;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV - Giờ bình thường");
				cbbGioSD.Items.Add("2. Điện áp dưới 6kV - Giờ cao điểm");
				cbbGioSD.Items.Add("3. Điện áp dưới 6kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("4. Điện áp từ 6kV đến 22kV - Giờ bình thường");
				cbbGioSD.Items.Add("5. Điện áp từ 6kV đến 22kV - Giờ cao điểm");
				cbbGioSD.Items.Add("6. Điện áp từ 6kV đến 22kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("7. Điện áp trên 22kV - Giờ bình thường");
				cbbGioSD.Items.Add("8. Điện áp trên 22kV - Giờ cao điểm");
				cbbGioSD.Items.Add("9. Điện áp trên 22kV - Giờ thấp điểm");
			}
			//Điện sản xuất
			else if (cbbNoiSuDung.SelectedItem == "1. Đặc thù bơm tưới tiêu - Phú Quốc")
			{
				chiMuc = 6;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV - Không theo thời gian");
				cbbGioSD.Items.Add("2. Điện áp dưới 6kV -  Giờ bình thường");
				cbbGioSD.Items.Add("3. Điện áp dưới 6kV -  Giờ cao điểm");
				cbbGioSD.Items.Add("4. Điện áp dưới 6kV -  Giờ thấp điểm");
				cbbGioSD.Items.Add("5. Điện áp trên 6kV -  Không theo thời gian");
				cbbGioSD.Items.Add("6. Điện áp trên 6kV - Giờ bình thường");
				cbbGioSD.Items.Add("7. Điện áp trên 6kV - Giờ cao điểm");
				cbbGioSD.Items.Add("8. Điện áp trên 6kV - Giờ thấp điểm");
			}
			else if (cbbNoiSuDung.SelectedItem == "2. Bán buôn khu công nghiệp cấp điện áp 110KV")
			{
				chiMuc = 7;
				cbbGioSD.Items.Add("1. Giờ bình thường");
				cbbGioSD.Items.Add("2. Giờ cao điểm");
				cbbGioSD.Items.Add("3. Giờ thấp điểm");
			}
			else if (cbbNoiSuDung.SelectedItem == "3. Các ngành sản xuất bình thường")
			{
				chiMuc = 8;
				cbbGioSD.Items.Add("1. Ngành SX bình thường - Điện áp dưới 6kV - Giờ bình thường");
				cbbGioSD.Items.Add("2. Ngành SX bình thường - Điện áp dưới 6kV - Giờ cao điểm");
				cbbGioSD.Items.Add("3. Ngành SX bình thường - Điện áp dưới 6kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("4. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ bình thường");
				cbbGioSD.Items.Add("5. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ cao điểm");
				cbbGioSD.Items.Add("6. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("7. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ bình thường");
				cbbGioSD.Items.Add("8. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ cao điểm");
				cbbGioSD.Items.Add("9. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("10. Ngành SX bình thường - Điện áp trên 110kV - Giờ bình thường");
				cbbGioSD.Items.Add("12. Ngành SX bình thường - Điện áp trên 110kV - Giờ cao điểm");
				cbbGioSD.Items.Add("12. Ngành SX bình thường - Điện áp trên 110kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("13. Tại KCN - Điện áp dưới 6kV - Giờ bình thường");
				cbbGioSD.Items.Add("14. Tại KCN - Điện áp dưới 6kV - Giờ cao điểm");
				cbbGioSD.Items.Add("15. Tại KCN - Điện áp dưới 6kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("16. Tại KCN - Điện áp từ 22 đến 110kV - Giờ bình thường");
				cbbGioSD.Items.Add("17. Tại KCN - Điện áp từ 22 đến 110kV - Giờ cao điểm");
				cbbGioSD.Items.Add("18. Tại KCN - Điện áp từ 22 đến 110kV - Giờ thấp điểm");
			}
			else if (cbbNoiSuDung.SelectedItem == "4. Doanh nghiệp thuộc KCN A, Tuy Hạ")
			{
				chiMuc = 9;
				cbbGioSD.Items.Add("1. Giờ bình thường");
				cbbGioSD.Items.Add("2. Giờ cao điểm");
				cbbGioSD.Items.Add("3. Giờ thấp điểm");
			}
			else if (cbbNoiSuDung.SelectedItem == "5. Sản xuất tại huyện đảo Phú Quốc")
			{
				chiMuc = 10;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV - Không theo thời gian");
				cbbGioSD.Items.Add("2. Điện áp dưới 6kV - Giờ bình thường");
				cbbGioSD.Items.Add("3. Điện áp dưới 6kV - Giờ cao điểm");
				cbbGioSD.Items.Add("4. Điện áp dưới 6kV - Giờ thấp điểm");
				cbbGioSD.Items.Add("5. Điện áp từ 6 đến 22kV - Không theo thời gian");
				cbbGioSD.Items.Add("6. Điện áp từ 6 đến 22kV - Giờ bình thường");
				cbbGioSD.Items.Add("7. Điện áp từ 6 đến 22kV - Giờ cao điểm");
				cbbGioSD.Items.Add("8. Điện áp từ 6 đến 22kV - Giờ thấp điểm");
			}
			else if (cbbNoiSuDung.SelectedItem == "6. Sản xuất tại huyện đảo Lý Sơn")
				chiMuc = 11;
			//Cơ quan hành chính
			else if (cbbNoiSuDung.SelectedItem == "1. Hành chính sự nghiệp tại huyện đảo Phú Quốc")
			{
				chiMuc = 12;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV");
				cbbGioSD.Items.Add("2. Điện áp trên 6kV");
			}
			else if (cbbNoiSuDung.SelectedItem == "2. Chiếu sáng công cộng tại huyện đảo Phú Quốc")
			{
				chiMuc = 13;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV");
				cbbGioSD.Items.Add("2. Điện áp trên 6kV");
			}
			else if (cbbNoiSuDung.SelectedItem == "3. Cơ quan, trường học, bệnh viện tại Vũng Ngán & Bình Hưng - Khánh Hoà")
				chiMuc = 14;
			else if (cbbNoiSuDung.SelectedItem == "4. Cơ quan hành chính tại Vũng Ngán & Bình Hưng - Khánh Hoà")
				chiMuc = 15;
			else if (cbbNoiSuDung.SelectedItem == "5. Bệnh viện, trường học, nhà trẻ")
			{
				chiMuc = 16;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV");
				cbbGioSD.Items.Add("2. Điện áp trên 6kV");
			}
			else if (cbbNoiSuDung.SelectedItem == "6. Hành chính sự nghiệp")
			{
				chiMuc = 17;
				cbbGioSD.Items.Add("1. Điện áp dưới 6kV");
				cbbGioSD.Items.Add("2. Điện áp trên 6kV");
			}
			else if (cbbNoiSuDung.SelectedItem == "7. Hành chính sự nghiệp tại huyện đảo Phú Quốc")
				chiMuc = 18;
			else if (cbbNoiSuDung.SelectedItem == "8. Hành chính sự nghiệp tại huyện đảo Lý Sơn")
				chiMuc = 19;
			//Bán buôn điện
			else if (cbbNoiSuDung.SelectedItem == "1. Bán buôn điện sinh hoạt cho tổ hợp TM - DV - SH")
				chiMuc = 20;
			else if (cbbNoiSuDung.SelectedItem == "2. Bán buôn khu tập thể - Thành thị - MBA của EVN")
				chiMuc = 21;
			else if (cbbNoiSuDung.SelectedItem == "3. Bán buôn khu tập thể - Huyện lỵ - MBA của KH")
				chiMuc = 22;
			else if (cbbNoiSuDung.SelectedItem == "4. Bán buôn khu tập thể - Huyện lỵ - MBA của EVN")
				chiMuc = 23;
			else if (cbbNoiSuDung.SelectedItem == "5. Bán buôn khu tập thể - Thành thị - MBA của KH")
				chiMuc = 24;
			else if (cbbNoiSuDung.SelectedItem == "6. Bán buôn sinh hoạt điện nông thôn")
				chiMuc = 25;
			//Bán điện cho khách nước ngoài
			else if (cbbNoiSuDung.SelectedItem == "1. Bán theo giá ngoại tệ cho Lào của CTy Điện Lực 1")
				chiMuc = 26;
			else if (cbbNoiSuDung.SelectedItem == "2. Bán theo giá ngoại tệ cho Campuchia của Cty Điện Lực 2")
				chiMuc = 27;
			else if (cbbNoiSuDung.SelectedItem == "3. Bán theo giá ngoại tệ cho Lào của CTy Điện Lực 3")
				chiMuc = 28;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			ttbChiSoCu.Text = "";
			ttbChiSoMoi.Text = "";
			ttbKetQua.Text = "";
			cbbNoiSuDung.Items.Clear();
			cbbGioSD.Items.Clear();
			cbbGioSD.Text = "";
		}

		private void btnKetQua_Click(object sender, EventArgs e)
		{
			ushort chiSoMoi, chiSoCu, tieuThu;
			double tienTruocThue = 0, tienSauThue;
			if (ttbChiSoCu.Text != "" && ttbChiSoMoi.Text != "")
			{
				chiSoMoi = ushort.Parse(ttbChiSoMoi.Text);
				chiSoCu = ushort.Parse(ttbChiSoCu.Text);
			}
			tieuThu = ushort.Parse(ttbDNTT.Text);
			ttbKetQua.Text = "";
			switch (chiMuc)
			{
				//Điện sinh hoạt
				case 1:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1484;
							ttbKetQua.Text += tieuThu + " x " + "1484" + " = " + tieuThu * 1484 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1533;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1533" + " = " + (tieuThu - 50) * 1533 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1786;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1786" + " = " + (tieuThu - 100) * 1786 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 2242;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "2242" + " = " + (tieuThu - 200) * 2242 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2503;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2503" + " = " + (tieuThu - 300) * 2503 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2587;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2587" + " = " + (tieuThu - 400) * 2587 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 2:
					ttbKetQua.Text = "Không có dữ liệu bảng giá tiền điện!";
					break;
				case 3:
					tienTruocThue = tieuThu * 682;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "682" + " = " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 4:
					ttbKetQua.Text = "Không có dữ liệu bảng giá tiền điện!";
					break;
				//Điện kinh doanh
				case 5:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 2320;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2320" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp dưới 6kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 3991;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "3991" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "3. Điện áp dưới 6kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 1412;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1412" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "4. Điện áp từ 6kV đến 22kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 2287;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2287" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "5. Điện áp từ 6kV đến 22kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 3829;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "3829" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "6. Điện áp từ 6kV đến 22kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 1347;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1347" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "7. Điện áp trên 22kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 2125;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2125" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "8. Điện áp trên 22kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 3699;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "3699" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "9. Điện áp trên 22kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 1185;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1185" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				//Điện sản xuất
				case 6:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV - Không theo thời gian")
					{
						tienTruocThue = tieuThu * 785;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "785" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp dưới 6kV -  Giờ bình thường")
					{
						tienTruocThue = tieuThu * 785;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "785" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "3. Điện áp dưới 6kV -  Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 1500;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1500" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "4. Điện áp dưới 6kV -  Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 310;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "310" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "5. Điện áp trên 6kV -  Không theo thời gian")
					{
						tienTruocThue = tieuThu * 750;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "750" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "6. Điện áp trên 6kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 750;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "750" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "7. Điện áp trên 6kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 1425;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1425" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "8. Điện áp trên 6kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 300;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "300" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 7:
					ttbKetQua.Text = "Không có dữ liệu bảng giá tiền điện!";
					break;
				case 8:
					if (cbbGioSD.SelectedItem == "1. Ngành SX bình thường - Điện áp dưới 6kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1518;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1518" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Ngành SX bình thường - Điện áp dưới 6kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2735;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2735" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "3. Ngành SX bình thường - Điện áp dưới 6kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 983;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "983" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "4. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1453;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1453" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "5. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2637;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2637" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "6. Ngành SX bình thường - Điện áp từ 6 đến 22kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 934;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "934" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "7. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1405;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1405" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "8. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2556;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2556" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "9. Ngành SX bình thường - Điện áp từ 22 đến 110kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 902;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "902" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "10. Ngành SX bình thường - Điện áp trên 110kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1388;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1388" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "12. Ngành SX bình thường - Điện áp trên 110kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2459;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2459" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "12. Ngành SX bình thường - Điện áp trên 110kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 869;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "869" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "13. Tại KCN - Điện áp dưới 6kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1425;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1425" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "14. Tại KCN - Điện áp dưới 6kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2586;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2586" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "15. Tại KCN - Điện áp dưới 6kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 916;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "916" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "16. Tại KCN - Điện áp từ 22 đến 110kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1378;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1378" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "17. Tại KCN - Điện áp từ 22 đến 110kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2506;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2506" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "18. Tại KCN - Điện áp từ 22 đến 110kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 885;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "885" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 9:
					if (cbbGioSD.SelectedItem == "1. Giờ bình thường")
					{
						tienTruocThue = tieuThu * 767;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "767" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 1554;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1554" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "3. Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 416;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "416" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 10:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV - Không theo thời gian")
					{
						tienTruocThue = tieuThu * 1180;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1180" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp dưới 6kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1115;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1115" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "3. Điện áp dưới 6kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2215;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2215" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "4. Điện áp dưới 6kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 630;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "630" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "5. Điện áp từ 6 đến 22kV - Không theo thời gian")
					{
						tienTruocThue = tieuThu * 1130;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1130" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "6. Điện áp từ 6 đến 22kV - Giờ bình thường")
					{
						tienTruocThue = tieuThu * 1075;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1075" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "7. Điện áp từ 6 đến 22kV - Giờ cao điểm")
					{
						tienTruocThue = tieuThu * 2140;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "2140" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "8. Điện áp từ 6 đến 22kV - Giờ thấp điểm")
					{
						tienTruocThue = tieuThu * 600;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "600" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 11:
					tienTruocThue = tieuThu * 1200;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1200" + " = " + tienTruocThue + " đồng" + "\r\n";
					break;
				//Điện cho các cơ quan hành chính
				case 12:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV")
					{
						tienTruocThue = tieuThu * 1285;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1285" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp trên 6kV")
					{
						tienTruocThue = tieuThu * 1235;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1235" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 13:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV")
					{
						tienTruocThue = tieuThu * 1255;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1255" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp trên 6kV")
					{
						tienTruocThue = tieuThu * 1205;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1205" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 14:
					tienTruocThue = tieuThu * 1150;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1150" + " = " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 15:
					ttbKetQua.Text = "Không có dữ liệu bảng giá tiền điện!";
					break;
				case 16:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV")
					{
						tienTruocThue = tieuThu * 1557;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1557" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp trên 6kV")
					{
						tienTruocThue = tieuThu * 1460;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1460" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 17:
					if (cbbGioSD.SelectedItem == "1. Điện áp dưới 6kV")
					{
						tienTruocThue = tieuThu * 1671;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1671" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					else if (cbbGioSD.SelectedItem == "2. Điện áp trên 6kV")
					{
						tienTruocThue = tieuThu * 1606;
						ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1606" + " = " + tienTruocThue + " đồng" + "\r\n";
					}
					break;
				case 18:
					tienTruocThue = tieuThu * 1136;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1136" + " = " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 19:
					tienTruocThue = tieuThu * 1230;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "1230" + " = " + tienTruocThue + " đồng" + "\r\n";
					break;
				//Bán buôn điện
				case 20:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1454;
							ttbKetQua.Text += tieuThu + " x " + "1454" + " = " + tieuThu * 1454 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1502;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1502" + " = " + (tieuThu - 50) * 1502 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1750;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1750" + " = " + (tieuThu - 100) * 1750 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 2197;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "2197" + " = " + (tieuThu - 200) * 2197 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2453;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2453" + " = " + (tieuThu - 300) * 2453 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2535;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2535" + " = " + (tieuThu - 400) * 2535 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 21:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1382;
							ttbKetQua.Text += tieuThu + " x " + "1382" + " = " + tieuThu * 1382 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1431;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1431" + " = " + (tieuThu - 50) * 1431 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1624;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1624" + " = " + (tieuThu - 100) * 1624 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 2049;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "2049" + " = " + (tieuThu - 200) * 2049 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2310;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2310" + " = " + (tieuThu - 300) * 2310 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2389;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2389" + " = " + (tieuThu - 400) * 2389 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 22:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1311;
							ttbKetQua.Text += tieuThu + " x " + "1311" + " = " + tieuThu * 1311 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1360;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1360" + " = " + (tieuThu - 50) * 1360 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1503;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1503" + " = " + (tieuThu - 100) * 1503 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 1856;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "1856" + " = " + (tieuThu - 200) * 1856 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2101;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2101" + " = " + (tieuThu - 300) * 2101 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2174;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2174" + " = " + (tieuThu - 400) * 2174 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 23:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1332;
							ttbKetQua.Text += tieuThu + " x " + "1332" + " = " + tieuThu * 1332 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1381;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1381" + " = " + (tieuThu - 50) * 1381 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1539;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1539" + " = " + (tieuThu - 100) * 1539 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 1941;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "1941" + " = " + (tieuThu - 200) * 1941 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2181;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2181" + " = " + (tieuThu - 300) * 2181 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2256;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2256" + " = " + (tieuThu - 400) * 2256 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 24:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1361;
							ttbKetQua.Text += tieuThu + " x " + "1361" + " = " + tieuThu * 1361 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1410;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1410" + " = " + (tieuThu - 50) * 1410 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1575;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1575" + " = " + (tieuThu - 100) * 1575 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 1984;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "1984" + " = " + (tieuThu - 200) * 1984 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 2229;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "2229" + " = " + (tieuThu - 300) * 2229 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2333;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2333" + " = " + (tieuThu - 400) * 2333 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				case 25:
					while (tieuThu > 0)
					{
						if (tieuThu <= 50) //Từ 0 đến 50
						{
							tienTruocThue += tieuThu * 1230;
							ttbKetQua.Text += tieuThu + " x " + "1230" + " = " + tieuThu * 1230 + " đồng" + "\r\n";
							tieuThu = 0;
						}
						else
						{
							if (tieuThu <= 100) //Từ 51 đến 100
							{
								tienTruocThue += (tieuThu - 50) * 1279;
								ttbKetQua.Text += (tieuThu - 50) + " x " + "1279" + " = " + (tieuThu - 50) * 1279 + " đồng" + "\r\n";
								tieuThu = 50;
							}
							else if (tieuThu <= 200) //Từ  101 đến 200
							{
								tienTruocThue += (tieuThu - 100) * 1394;
								ttbKetQua.Text += (tieuThu - 100) + " x " + "1394" + " = " + (tieuThu - 100) * 1394 + " đồng" + "\r\n";
								tieuThu = 100;
							}
							else if (tieuThu <= 300) //Từ 201 đến 300
							{
								tienTruocThue += (tieuThu - 200) * 1720;
								ttbKetQua.Text += (tieuThu - 200) + " x " + "1720" + " = " + (tieuThu - 200) * 1720 + " đồng" + "\r\n";
								tieuThu = 200;
							}
							else if (tieuThu <= 400) //Từ 301 đến 400
							{
								tienTruocThue += (tieuThu - 300) * 1945;
								ttbKetQua.Text += (tieuThu - 300) + " x " + "1945" + " = " + (tieuThu - 300) * 1945 + " đồng" + "\r\n";
								tieuThu = 300;
							}
							else //Lớn hơn 400
							{
								tienTruocThue += (tieuThu - 400) * 2028;
								ttbKetQua.Text += (tieuThu - 400) + " x " + "2028" + " = " + (tieuThu - 400) * 2028 + " đồng" + "\r\n";
								tieuThu = 400;
							}
						}
					}
					ttbKetQua.Text += "\r\n" + "Tổng số tiền chưa tính thuế : " + tienTruocThue + " đồng" + "\r\n";
					break;
				//Bán điện cho khách hàng nước ngoài
				case 26:
					tienTruocThue = tieuThu * 0.06;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "0.06" + " = " + tienTruocThue + " USD" + "\r\n";
					break;
				case 27:
					tienTruocThue = tieuThu * 0.069;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "0.069" + " = " + tienTruocThue + " USD" + "\r\n";
					break;
				case 28:
					tienTruocThue = tieuThu * 0.06;
					ttbKetQua.Text += "Tổng số tiền chưa tính thuế : " + tieuThu + " x " + "0.06" + " = " + tienTruocThue + " USD" + "\r\n";
					break;
			}
			if (ttbKetQua.Text != "Không có dữ liệu bảng giá tiền điện!")
			{
				if (chiMuc < 26)
				{
					ttbKetQua.Text += "Thuế GTGT (10%) : " + tienTruocThue * 10 / 100 + " đồng" + "\r\n";
					tienSauThue = tienTruocThue * 110 / 100;
					ttbKetQua.Text += "\r\n" + "Tổng tiền phải trả : " + tienSauThue + " đồng" + "\r\n";
				}
				else
				{
					ttbKetQua.Text += "Thuế GTGT (10%) : " + tienTruocThue * 10 / 100 + " USD" + "\r\n";
					tienSauThue = tienTruocThue * 110 / 100;
					ttbKetQua.Text += "\r\n" + "Tổng tiền phải trả : " + tienSauThue + " USD" + "\r\n";
				}
			}
		}

		private void ttbChiSoMoi_TextChanged(object sender, EventArgs e)
		{

		}

		private void ttbChiSoMoi_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
				e.Handled = true;
		}

		private void ttbChiSoCu_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
				e.Handled = true;
		}

		private void ttbDNTT_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
				e.Handled = true;
		}

		private void lblChiSoCu_Click(object sender, EventArgs e)
		{

		}

		private void ttbChiSoCu_TextChanged(object sender, EventArgs e)
		{
			int tieuThu = 0;
			ttbDNTT.Text = "";
			if (ttbChiSoMoi.Text != "" && ttbChiSoCu.Text != "")
				tieuThu = int.Parse(ttbChiSoMoi.Text) - int.Parse(ttbChiSoCu.Text);
			ttbDNTT.Text += tieuThu;
		}

		private void lblDNTT_Click(object sender, EventArgs e)
		{

		}

		private void ttbDNTT_TextChanged(object sender, EventArgs e)
		{

		}

		private void lblChiSoMoi_Click(object sender, EventArgs e)
		{

		}

		private void ttbChiSoMoi_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void vềToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Đây là chương trình tính tiền điện. \nCập nhật ngày: 14 Tháng 7 năm 2017 \nTác giả: La Quốc Thắng", "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void giờCaoĐiểmLàGìToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("1. Giờ bình thường: \n  a) Gồm các ngày từ thứ Hai đến thứ Bảy:\n    -Từ 04 giờ 00 đến 9 giờ 30 (05 giờ 30 phút)\n    -Từ 11 giờ 30 đến 17 giờ 00 (05 giờ 30 phút)\n    -Từ 20 giờ 00 đến 22 giờ 00 (02 giờ)\n  b) Ngày Chủ nhật:\n     Từ 04 giờ 00 đến 22 giờ 00 (18 giờ).\n2. Giờ cao điểm:\n  a) Gồm các ngày từ thứ Hai đến thứ Bảy:\n    -Từ 09 giờ 30 đến 11 giờ 30 (02 giờ)\n    -Từ 17 giờ 00 đến 20 giờ 00 (03 giờ)\n  b) Ngày Chủ nhật: không có giờ cao điểm\n3. Giờ thấp điểm:\n    Tất cả các ngày trong tuần: từ 22 giờ 00 đến 04 giờ 00 (06 giờ) sáng ngày hôm sau\n\n Lưu ý: Nếu không có để chữ gì, mặc định là không tính thời gian", "Giờ sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void cbbGioSD_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ttbKetQua_TextChanged(object sender, EventArgs e)
		{

		}
	}
}