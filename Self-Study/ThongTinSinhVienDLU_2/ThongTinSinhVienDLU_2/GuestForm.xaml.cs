using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ThongTinSinhVienDLU_2
{
	/// <summary>
	/// Interaction logic for GuestForm.xaml
	/// </summary>
	public partial class GuestForm : Window
	{
		CookieAwareWebClient client = new CookieAwareWebClient();
		List<string> listWeek;

		public GuestForm()
		{
			InitializeComponent();
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			AddSchoolYear(cbx_NamHoc_Lop);
			AutoSelectSchoolYear(cbx_NamHoc_Lop);
			AutoSelectTerm(cbx_HocKy_Lop);
			SetValueRangeNUD(nud_Tuan_Lop);
			AutoSelectWeek(nud_Tuan_Lop);
		}

		private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == WindowState.Normal)
			{
				this.WindowState = WindowState.Maximized;
			}
			else
			{
				this.WindowState = WindowState.Normal;
			}
		}

		private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Environment.Exit(1);
		}

		void AddSchoolYear(ComboBox x)
		{
			int year = DateTime.Now.Year;
			for (int i = 5; i >= 0; i--)
			{
				x.Items.Add(string.Concat(year - i, "-", year - i + 1));
			}
		}

		string GetCurrentSchoolYear()
		{
			DateTime dt = DateTime.Now;
			int month = dt.Month;
			int year = dt.Year;
			if (month <= 12 && month >= 8)
				return string.Concat(year, '-', year + 1);
			else return string.Concat(year - 1, '-', year);
		}

		void AutoSelectSchoolYear(ComboBox x)
		{
			x.Text = GetCurrentSchoolYear();
		}

		void AutoSelectTerm(ComboBox x)
		{
			int month = DateTime.Now.Month;
			if (month >= 8 && month <= 12)
				x.Text = "1";
			else if (month >= 1 && month <= 6)
				x.Text = "2";
			else x.Text = "3";
		}

		void GetWeekofTerm(ComboBox namHoc, ComboBox hocKy)
		{
			string link = string.Concat(@"http://qlgd.dlu.edu.vn/Public/GetWeek/", namHoc.SelectedValue, "$HK0", hocKy.SelectedValue);
			client.Encoding = Encoding.UTF8;
			string data;
			try
			{
				data = client.DownloadString(link);
			}
			catch (Exception)
			{
				MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
			string pattern = "\"Week\"(.*?),\"DisPlayWeek\"(.*?),";
			Regex rgx = new Regex(pattern);
			listWeek = new List<string>();
			foreach (Match m in rgx.Matches(data, 0))
			{
				string temp = m.Value.Replace("\"Week\":", "");
				temp = temp.Replace(",\"DisPlayWeek\":", " ");
				temp = temp.Replace(",", "");
				listWeek.Add(temp);
			}
		}

		void SetValueRangeNUD(Xceed.Wpf.Toolkit.IntegerUpDown x)
		{
			string[] t = listWeek[0].Split(' ');
			int min = int.Parse(t[1]);
			t = listWeek[listWeek.Count - 1].Split(' ');
			int max = int.Parse(t[1]);
			x.Minimum = min;
			x.Maximum = max;
		}

		int GetCurrentNumWeek()
		{
			client.Encoding = Encoding.UTF8;
			string html;
			try
			{
				html = client.DownloadString(@"http://vi.weeknumber52.com/getdate.php?lang=vi");
			}
			catch (Exception)
			{
				MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
			html = Regex.Match(html, "<li class=\"date1\">*>([^<]*)</li>").Value;
			html = html.Replace("<li class=\"date1\">Tuần ", "");
			html = html.Replace("</li>", "");
			return int.Parse(html);
		}

		void AutoSelectWeek(Xceed.Wpf.Toolkit.IntegerUpDown x)
		{
			int w = GetCurrentNumWeek();
			foreach (var item in listWeek)
			{
				string[] t = item.Split(' ');
				if (w == int.Parse(t[0]))
				{
					x.Value = int.Parse(t[1]);
					return;
				}
			}
		}

		string DisplayWeek2RealWeek(Xceed.Wpf.Toolkit.IntegerUpDown x)
		{
			string w = x.Value.ToString();
			foreach (var item in listWeek)
			{
				string[] t = item.Split(' ');
				if (t[1] == w)
					return t[0];
			}
			return "0";
		}

		string GetClassSchedule()
		{
			return string.Concat("http://qlgd.dlu.edu.vn/public/DrawingClassStudentSchedules_Mau2?YearStudy=", cbx_NamHoc_Lop.Text, "&TermID=HK0", cbx_HocKy_Lop.Text, "&Week=", DisplayWeek2RealWeek(nud_Tuan_Lop), "&ClassStudentID=", tbx_Lop.Text);
		}

		string GetLecturerSchedule()
		{
			return string.Concat("http://qlgd.dlu.edu.vn/public/DrawingProfessorSchedule?YearStudy=", cbx_NamHoc_GV.Text, "&TermID=HK0", cbx_HocKy_GV.Text, "&Week=", DisplayWeek2RealWeek(nud_Tuan_GV), "&ProfessorID=", tbx_GV.Text);
		}

		void AddRoomToBox()
		{
			string rooms = "A11.104	A11.105	A11.106	A11.107	A11.201	A11.202	A11.204	A11.205	A11.301	A11.302	A11.303	A11.304	A11.305	A11.306	A11.401	A11.402	A11.403	A11.404	A11.NK	A19.1	A19.2	A19.3	A19.4	A19.5	A19.6	A19.7	A19.TN	A19.TN1	A20.101	A20.103	A20.104	A20.105	A20.201	A21.3	A21.4	A21.5	A24.1	A24.LAU	A27.1	A27.10	A27.10B	A27.11	A27.12	A27.2	A27.3	A27.5	A27.6	A27.6B	A27.7	A27.8	A27.9	A27.CH3	A3.1	A3.2	A3.3.1	A3.3.2	A3.L1	A3.L2	A3.L3	A3.L4	A3.L5	A30.1	A30.10	A30.11	A30.12	A30.3	A30.4	A30.5	A30.7	A30.8	A30.9	A31.101	A31.102	A31.103	A31.104	A31.105	A31.201	A31.203	A31.204	A31.205	A31.206	A31.301	A31.302	A31.303	A4.CDHC	A4.CDPT	A4.DC	A4.HCO	A4.HLY	A4.PTIC	A4.VCO	A5.1	A5.2	A5.CMO	A5.NL	A6.1	A6.2	A7.1	A7.2	A7.3	A7.4	A7.5	A7.6	A7.7	A7.8	A8.3	A8.4	A8.5.1	A8.5.2	A8.6.1	A8.6.2	A8.7.1	A8.7.2	A8.8.1	A8.8.2	A8.B	ChuaCoPhong	HoiThao_TV	HTTN	LAU A8.B	NT_100	NHAT T	NHATT	NHA-TT	SAN_QP_LT	SAN1	SAN10	SAN11	SAN2	SAN3	SAN4	SAN5	SAN6	SAN7	SAN8	SAN9	SANA25	SANBD	SANBD2	SANBD3	SANQP1	SANQP10	SANQP11	SANQP12	SANQP13	SANQP14	SANQP15	SANQP2	SANQP3	SANQP4	SANQP5	SANQP6	SANQP7	SANQP8	SANQP9	SANQPAN_TT_1	SANQPAN_TT_2	TAM	TAM1	TAM2	TN-NH1	TNVL	TTCT	TTCTXH	TTDL1	TTDL2	TTDN	TTKS	TTSP1	TTSP2	TTSP3	TTSP4	TTSP5	TTSP6	TTSP7	TTUDKTHN	TT-VL	TV_DT	TV1	TV3	TV4	TH_1000	TH-DL	TH-DL1	TH-DL2	TH-NL1	THNL10	THNL11	THNL12	TH-NL2	TH-NL3	TH-NL4	TH-NL5	TH-NL6	TH-NL7	TH-NL8	TH-NL9	TH-NT1	TH-NT2	TH-NT20	TH-VBT	TH-VX1	VBTLD	Vien_BTLÐ	Vien_NCKÐ	Vien_NCHN 1	Vien_NCHN2	Vien_NCHN3	VPK_CNTT	VPK_CTXH	VPK_DL	VPK_KTHN	VPK_LH	VPK_LS	VPK_MT	VPK_NL	VPK_NN	VPK_NV	VPK_QT	VPK_QTH	VPK_SH	VPK_SP	VPK_VL	VSHTN	VTLD";
			string[] room = rooms.Split('\t');
			foreach (var item in room)
				cbx_Phong.Items.Add(item);
		}

		string GetRoomSchedule()
		{
			return string.Concat("http://qlgd.dlu.edu.vn/public/DrawingRoomSchedules?YearStudy=", cbx_NamHoc_Phong.Text, "&TermID=HK0", cbx_HocKy_Phong.Text, "&Week=", DisplayWeek2RealWeek(nud_Tuan_Phong), "&RoomID=", cbx_Phong.SelectedValue.ToString());
		}

		List<KeyValuePair<string, string>> department = new List<KeyValuePair<string, string>>();

		void AddDepartmentToList()
		{
			string titles = "Khoa Công nghệ thông tin	Khoa Công tác xã hội	Khoa Giáo dục thể chất	Khoa Hóa học	Khoa Kinh tế - Quản trị kinh doanh	Khoa Kỹ Thuật Hạt Nhân	Khoa Lịch sử	Khoa Luật học	Khoa Lý luận Chính trị	Khoa Môi trường & Tài nguyên	Khoa Ngoại ngữ	Khoa Ngữ văn & Văn hóa học	Khoa Nông lâm	Khoa Quản trị Du lịch	Khoa Quốc tế học	Khoa Sinh học	Khoa Sư phạm	Khoa Toán - Tin học	Khoa Vật lý	Phòng QLĐT Sau Đại học";
			string[] title = titles.Split('\t');
			string codes = "CT$1	CP$1	TD$2	HH$1	QT$1	HNH$1	LS$1	LH$1	ML$2	MT$1	NN$2	NV$1	NH$1	DL$1	DP$1	SH$1	SP$1	TN$1	VL$1	SDH$1";
			string[] code = codes.Split('\t');
			int i = 0;
			foreach (var item in title)
			{
				department.Add(new KeyValuePair<string, string>(code[i], item));
				cbx_Khoa.Items.Add(title[i]);
				i++;
			}
		}

		string GetDepartmentCode()
		{
			foreach (var item in department)
				if (item.Value == cbx_Khoa.SelectedValue.ToString())
					return item.Key;
			return null;
		}

		string GetDepartmentSchedule()
		{
			string y;
			string[] t = cbx_NamHoc_Khoa.Text.Split('-');
			if (cbx_HocKy_Khoa.Text == "1")
				y = t[0];
			else y = t[1];
			return string.Concat("http://qlgd.dlu.edu.vn/public/DrawingDepartmentSchedules_DangLuoi?YearStudy=", cbx_NamHoc_Khoa.Text, "&TermID=HK0", cbx_HocKy_Khoa.Text, "&Week=", DisplayWeek2RealWeek(nud_Tuan_Khoa), "$", y, "&DepartmentID=", GetDepartmentCode());
		}

		void DisplaySchedule(string link, System.Windows.Forms.WebBrowser w)
		{
			string html;
			try
			{
				html = client.DownloadString(link);
			}
			catch (Exception)
			{
				MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				throw;
			}
			w.DocumentText = html;
		}

		private void cbx_NamHoc_Lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetWeekofTerm(cbx_NamHoc_Lop, cbx_HocKy_Lop);
			if (listWeek.Count != 0)
				SetValueRangeNUD(nud_Tuan_Lop);
			if (nud_Tuan_Lop.Value < nud_Tuan_Lop.Minimum || nud_Tuan_Lop.Value > nud_Tuan_Lop.Maximum)
				nud_Tuan_Lop.Value = nud_Tuan_Lop.Minimum;
		}

		private void cbx_HocKy_Lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cbx_NamHoc_Lop_SelectionChanged(sender, e);
		}

		private void nud_Tuan_Lop_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			DisplaySchedule(GetClassSchedule(), webBrowser1);
		}

		private void btn_Xuat_TKB_Lop_Click(object sender, RoutedEventArgs e)
		{
			DisplaySchedule(GetClassSchedule(), webBrowser1);
		}

		private void nud_Tuan_Lop_GotFocus(object sender, RoutedEventArgs e)
		{
			nud_Tuan_Lop.ToolTip = string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_Lop.Minimum, " đến ", nud_Tuan_Lop.Maximum);
		}

		private void cbx_NamHoc_GV_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetWeekofTerm(cbx_NamHoc_GV, cbx_HocKy_GV);
			if (listWeek.Count != 0)
				SetValueRangeNUD(nud_Tuan_GV);
			if (nud_Tuan_GV.Value < nud_Tuan_GV.Minimum || nud_Tuan_GV.Value > nud_Tuan_GV.Maximum)
				nud_Tuan_GV.Value = nud_Tuan_GV.Minimum;
		}

		private void cbx_HocKy_GV_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cbx_NamHoc_GV_SelectionChanged(sender, e);
		}

		private void nud_Tuan_GV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			DisplaySchedule(GetLecturerSchedule(), webBrowser2);
		}

		private void btn_Xuat_TKB_GV_Click(object sender, RoutedEventArgs e)
		{
			DisplaySchedule(GetLecturerSchedule(), webBrowser2);
		}

		private void nud_Tuan_GV_GotFocus(object sender, RoutedEventArgs e)
		{
			nud_Tuan_GV.ToolTip = string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_GV.Minimum, " đến ", nud_Tuan_GV.Maximum);
		}

		private void cbx_NamHoc_Phong_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetWeekofTerm(cbx_NamHoc_Phong, cbx_HocKy_Phong);
			if (listWeek.Count != 0)
				SetValueRangeNUD(nud_Tuan_Phong);
			if (nud_Tuan_Phong.Value < nud_Tuan_Phong.Minimum || nud_Tuan_Phong.Value > nud_Tuan_Phong.Maximum)
				nud_Tuan_Phong.Value = nud_Tuan_Phong.Minimum;
		}

		private void cbx_HocKy_Phong_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cbx_NamHoc_Phong_SelectionChanged(sender, e);
		}

		private void nud_Tuan_Phong_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			DisplaySchedule(GetRoomSchedule(), webBrowser3);
		}

		private void nud_Tuan_Phong_GotFocus(object sender, RoutedEventArgs e)
		{
			nud_Tuan_Phong.ToolTip = string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_Phong.Minimum, " đến ", nud_Tuan_Phong.Maximum);
		}

		private void btn_Xuat_TKB_Phong_Click(object sender, RoutedEventArgs e)
		{
			DisplaySchedule(GetRoomSchedule(), webBrowser3);
		}

		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (tabControl.SelectedIndex == 1)
			{
				if (cbx_NamHoc_GV.Items.Count == 0)
				{
					AddSchoolYear(cbx_NamHoc_GV);
					AutoSelectSchoolYear(cbx_NamHoc_GV);
					AutoSelectTerm(cbx_HocKy_GV);
					SetValueRangeNUD(nud_Tuan_GV);
					AutoSelectWeek(nud_Tuan_GV);
				}
			}
			else if (tabControl.SelectedIndex == 2)
			{
				if (cbx_Phong.Items.Count == 0)
				{
					AddRoomToBox();
					cbx_Phong.SelectedIndex = 0;
					AddSchoolYear(cbx_NamHoc_Phong);
					AutoSelectSchoolYear(cbx_NamHoc_Phong);
					AutoSelectTerm(cbx_HocKy_Phong);
					SetValueRangeNUD(nud_Tuan_Phong);
					AutoSelectWeek(nud_Tuan_Phong);
				}
			}
			else if (tabControl.SelectedIndex == 3)
			{
				if (cbx_Khoa.Items.Count == 0)
				{
					AddDepartmentToList();
					cbx_Khoa.SelectedIndex = 0;
					AddSchoolYear(cbx_NamHoc_Khoa);
					AutoSelectSchoolYear(cbx_NamHoc_Khoa);
					AutoSelectTerm(cbx_HocKy_Khoa);
					SetValueRangeNUD(nud_Tuan_Khoa);
					AutoSelectWeek(nud_Tuan_Khoa);
				}
			}
		}

		private void cbx_NamHoc_Khoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GetWeekofTerm(cbx_NamHoc_Khoa, cbx_HocKy_Khoa);
			if (listWeek.Count != 0)
				SetValueRangeNUD(nud_Tuan_Khoa);
			if (nud_Tuan_Khoa.Value < nud_Tuan_Khoa.Minimum || nud_Tuan_Khoa.Value > nud_Tuan_Khoa.Maximum)
				nud_Tuan_Khoa.Value = nud_Tuan_Khoa.Minimum;
		}

		private void cbx_HocKy_Khoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			cbx_NamHoc_Khoa_SelectionChanged(sender, e);
		}

		private void nud_Tuan_Khoa_GotFocus(object sender, RoutedEventArgs e)
		{
			nud_Tuan_Khoa.ToolTip = string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_Khoa.Minimum, " đến ", nud_Tuan_Khoa.Maximum);
		}

		private void nud_Tuan_Khoa_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			DisplaySchedule(GetDepartmentSchedule(), webBrowser4);
		}

		private void btn_Xuat_TKB_Khoa_Click(object sender, RoutedEventArgs e)
		{
			DisplaySchedule(GetDepartmentSchedule(), webBrowser4);
		}
	}
}
