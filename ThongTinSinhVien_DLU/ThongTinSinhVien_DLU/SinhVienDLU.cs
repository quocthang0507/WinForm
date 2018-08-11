using EncryptAndDecryptFile;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ThongTinSinhVien_DLU
{
	public partial class Form_SinhVienDLU : Form
	{
		public static bool rememberLogin = false;
		string mssv, password;
		string pass = "12345679";
		List<string> listWeek;  //Study week list (Display week)
		int week;   //Real week

		CookieAwareWebClient client = new CookieAwareWebClient();

		public Form_SinhVienDLU()
		{
			Form login = new Form_DangNhap();
			login.ShowDialog();
			InitializeComponent();
		}

		private void SinhVienDLU_Load(object sender, EventArgs e)
		{
			Doc_DuLieu();
			SendLoginCookie();
			label4.Visible = label5.Visible = false;
			tbx_GiangVien.Visible = tbx_Lop.Visible = false;
			lbl_YourName.Text = Form_DangNhap.yourName;
			week = GetCurrentNumWeek();
			rbn_SinhVien.Checked = true;
			AddSchoolYearsList(cbx_NamHoc_TKB);
			AutoSelectSchoolYear(cbx_NamHoc_TKB);
			AutoSelectTerm(cbx_HocKy_TKB);
			GetWeekofTerm();
			AutoSelectWeek();
			btn_XuatTKB_Click(sender, e);
			SetValueRangeNUD();
		}

		/// <summary>
		/// Read login information from a existed file which is successful
		/// </summary>
		void Doc_DuLieu()
		{
			string path = "data.dat";
			CryptoStuff.DecryptFile(pass, path, "temp.txt");
			string data = File.ReadAllText("temp.txt");
			File.Delete("temp.txt");
			string[] temp = data.Split(' ');
			mssv = temp[0];
			password = temp[1];
			if (!rememberLogin)
				File.Delete(path);
		}

		/// <summary>
		/// Send login information as cookie to server
		/// </summary>
		void SendLoginCookie()
		{
			var values = new NameValueCollection { { "txtTaiKhoan", mssv }, { "txtMatKhau", password } };
			client.Encoding = Encoding.UTF8;
			client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
		}

		/// <summary>
		/// Get the current number of week of year
		/// </summary>
		/// <returns></returns>
		int GetCurrentNumWeek()
		{
			client.Encoding = Encoding.UTF8;
			var html = client.DownloadString(@"http://vi.weeknumber52.com/getdate.php?lang=vi");
			html = Regex.Match(html, "<li class=\"date1\">*>([^<]*)</li>").Value;
			html = html.Replace("<li class=\"date1\">Tuần ", "");
			html = html.Replace("</li>", "");
			return int.Parse(html);
		}

		/// <summary>
		/// Get current school year
		/// </summary>
		/// <returns></returns>
		string GetCurrentSchoolYear()
		{
			DateTime dt = DateTime.Now;
			string schoolYear;
			int month = dt.Month;
			int year = dt.Year;
			if (month <= 12 && month >= 8)
				schoolYear = string.Concat(year, '-', year + 1);
			else schoolYear = string.Concat(year - 1, '-', year);
			return schoolYear;
		}

		/// <summary>
		/// Get student's study programs
		/// </summary>
		/// <returns></returns>
		string GetStudyPrograms()
		{
			var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/StudyPrograms");
			html = Regex.Match(html, "<option value=\"(.*?)\">").Value;
			html = Regex.Match(html, "\"(.*?)\"").Value;
			html = html.Replace("\"", "");
			return html;
		}

		/// <summary>
		/// Add school years list to indicated combo-box
		/// </summary>
		/// <param name="x"></param>
		void AddSchoolYearsList(ComboBox x)
		{
			int yearStart = int.Parse(string.Concat("20", mssv[0], mssv[1]));
			for (int i = 0; i <= 4; i++)
				x.Items.Insert(i, string.Concat(yearStart, '-', ++yearStart));
		}

		/// <summary>
		/// Auto select current school year in combo-box
		/// </summary>
		/// <param name="x"></param>
		void AutoSelectSchoolYear(ComboBox x)
		{
			x.SelectedText = GetCurrentSchoolYear();
		}

		/// <summary>
		/// Auto select current term in combo-box
		/// </summary>
		/// <param name="x"></param>
		void AutoSelectTerm(ComboBox x)
		{
			int month = DateTime.Now.Month;
			if (month >= 8 && month <= 12)
				x.SelectedIndex = 0;
			else if (month >= 1 && month <= 6)
				x.SelectedIndex = 1;
			else x.SelectedIndex = 2;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("CHƯƠNG TRÌNH QUẢN LÝ TRANG CÁ NHÂN SINH VIÊN DLU \r\n\nTác giả: La Quốc Thắng \r\nMọi góp ý vui lòng gửi về Email : quocthang0507@gmail.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Get study week list of indicated term
		/// </summary>
		void GetWeekofTerm()
		{
			string link = string.Concat("http://qlgd.dlu.edu.vn/Public/GetWeek/", cbx_NamHoc_TKB.Text, "$HK0", cbx_HocKy_TKB.Text);
			var data = client.DownloadString(link);
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

		/// <summary>
		/// Set range of values of NumbericUpDown
		/// </summary>
		void SetValueRangeNUD()
		{
			string[] t = listWeek[0].Split(' ');
			int min = int.Parse(t[1]);
			t = listWeek[listWeek.Count - 1].Split(' ');
			int max = int.Parse(t[1]);
			nud_Tuan_TKB.Minimum = min;
			nud_Tuan_TKB.Maximum = max;
		}

		/// <summary>
		/// Auto select current study week of indicated term
		/// </summary>
		void AutoSelectWeek()
		{
			int w = GetCurrentNumWeek();
			foreach (var item in listWeek)
			{
				string[] t = item.Split(' ');
				if (w == int.Parse(t[0]))
				{
					nud_Tuan_TKB.Value = int.Parse(t[1]);
					return;
				}
			}
		}

		/// <summary>
		/// Convert display week (study week) to real week
		/// </summary>
		/// <returns></returns>
		string DisplayWeek2RealWeek()
		{
			string w = nud_Tuan_TKB.Value.ToString();
			foreach (var item in listWeek)
			{
				string[] t = item.Split(' ');
				if (t[1] == w)
					return t[0];
			}
			return "0";
		}

		/// <summary>
		/// Get schedule link of student, class or lecturer
		/// </summary>
		/// <returns></returns>
		string GetScheduleLink()
		{
			if (rbn_SinhVien.Checked == true)
				return string.Concat("http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=", mssv, "&YearId=", cbx_NamHoc_TKB.Text, "&TermId=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&WeekId=", DisplayWeek2RealWeek());
			else if (rbn_Lop.Checked == true)
				return string.Concat("http://online.dlu.edu.vn/Home/DrawingClassStudentSchedules_Mau2?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", DisplayWeek2RealWeek(), "&ClassStudentID=", tbx_Lop.Text);
			else return string.Concat("http://online.dlu.edu.vn/Home/DrawingProfessorSchedule?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", DisplayWeek2RealWeek(), "&ProfessorID=", tbx_GiangVien.Text);
		}

		private void btn_XuatTKB_Click(object sender, EventArgs e)
		{
			var html = client.DownloadString(GetScheduleLink());
			webBrowser1.DocumentText = html;
		}

		private void rbn_Lop_CheckedChanged(object sender, EventArgs e)
		{
			if (rbn_Lop.Checked == true)
			{
				label4.Visible = true;
				tbx_Lop.Visible = true;
				btn_Xuat_TKB.Location = new System.Drawing.Point(769, 4);
			}
			else
			{
				label4.Visible = false;
				tbx_Lop.Visible = false;
				btn_Xuat_TKB.Location = new System.Drawing.Point(598, 4);
			}
		}

		private void rbn_GiangVien_CheckedChanged(object sender, EventArgs e)
		{
			if (rbn_GiangVien.Checked == true)
			{
				label5.Visible = true;
				tbx_GiangVien.Visible = true;
				btn_Xuat_TKB.Location = new System.Drawing.Point(769, 4);
			}
			else
			{
				label5.Visible = false;
				tbx_GiangVien.Visible = false;
				btn_Xuat_TKB.Location = new System.Drawing.Point(598, 4);
			}
		}

		/// <summary>
		/// Get student's exam schedule link
		/// </summary>
		/// <returns></returns>
		string ExamSchedule()
		{
			return string.Concat("http://online.dlu.edu.vn/Home/ShowExam?YearStudy=", cbx_NamHoc_LichThi.Text, "&TermID=HK0", cbx_HocKy_LichThi.SelectedIndex + 1);
		}

		private void btn_Xuat_LichThi_Click(object sender, EventArgs e)
		{
			var html = client.DownloadString(ExamSchedule());
			webBrowser2.DocumentText = html;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0)
			{
				btn_XuatTKB_Click(sender, e);
			}
			else if (tabControl1.SelectedIndex == 1)
			{
				if (cbx_NamHoc_LichThi.Items.Count == 0)
				{
					AddSchoolYearsList(cbx_NamHoc_LichThi);
					AutoSelectTerm(cbx_HocKy_LichThi);
					AutoSelectSchoolYear(cbx_NamHoc_LichThi);
					btn_Xuat_LichThi_Click(sender, e);
				}
			}
			else if (tabControl1.SelectedIndex == 2)
			{
				if (cbx_NamHoc_Diem.Items.Count == 0)
				{
					AddSchoolYearsList(cbx_NamHoc_Diem);
					AutoSelectTerm(cbx_HocKy_Diem);
					AutoSelectSchoolYear(cbx_NamHoc_Diem);
					cbx_HocKy_Diem.Items.Add("Tất cả");
					cbx_NamHoc_Diem.Items.Add("Tất cả");
					btn_Xuat_Diem_Click(sender, e);
				}
			}
			else if (tabControl1.SelectedIndex == 3)
			{
				if (cbx_NamHoc_RL.Items.Count == 0)
				{
					AddSchoolYearsList(cbx_NamHoc_RL);
					AutoSelectTerm(cbx_HocKy_RL);
					AutoSelectSchoolYear(cbx_NamHoc_RL);
					btn_Xuat_RL_Click(sender, e);
				}
			}
			else if (tabControl1.SelectedIndex == 4)
				btn_Xuat_HP_Click(sender, e);
		}

		/// <summary>
		/// Get student's marks link
		/// </summary>
		/// <returns></returns>
		string Marks()
		{
			if (cbx_NamHoc_Diem.Text == "Tất cả")
				return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=0&TermID=0&HeDiem=10");
			else if (cbx_HocKy_Diem.Text == "Tất cả")
				return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=", cbx_NamHoc_Diem.Text, "&TermID=0&HeDiem=10");
			else return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=", cbx_NamHoc_Diem.Text, "&TermID=HK0", cbx_HocKy_Diem.Text, "&HeDiem=10");
		}

		private void btn_Xuat_Diem_Click(object sender, EventArgs e)
		{
			var html = client.DownloadString(Marks());
			html = html.Replace("/Content/images/Dau.png", "http://online.dlu.edu.vn/Content/images/Dau.png");
			html = html.Replace("/Content/images/Rot.png", "http://online.dlu.edu.vn/Content/images/Rot.png");
			html = html.Replace("/Content/images/detail.png", "http://online.dlu.edu.vn/Content/images/detail.png");
			webBrowser3.DocumentText = html;
		}

		private void cbx_NamHoc_Diem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbx_NamHoc_Diem.SelectedIndex == 4)
			{
				label9.Visible = false;
				cbx_HocKy_Diem.Visible = false;
			}
			else { label9.Visible = true; cbx_HocKy_Diem.Visible = true; }
		}

		/// <summary>
		/// Get student behaviors link
		/// </summary>
		/// <returns></returns>
		string Behaviors()
		{
			return string.Concat("http://online.dlu.edu.vn/Home/BehaviorByStudent?yearStudy=", cbx_NamHoc_RL.Text, "&termID=HK0", cbx_HocKy_RL.Text);
		}

		private void btn_Xuat_RL_Click(object sender, EventArgs e)
		{
			var html = client.DownloadString(Behaviors());
			var clearedScript = Regex.Match(html, "<script[^>]*>(?:[^<]+|<(?!\n/script>))+").Value;
			html = html.Replace(clearedScript, "");
			html = html.Replace(".error {\r\n        border-color: red;\r\n    }", ".error {\r\n        border-color: red;\r\n    }   table {\r\n    width:100%;\r\n    }");
			webBrowser4.DocumentText = html;
		}

		/// <summary>
		/// Get school fees link
		/// </summary>
		/// <returns></returns>
		string SchoolFees()
		{
			return string.Concat("http://online.dlu.edu.vn/Home/ShowFees?YearStudy=", GetCurrentSchoolYear(), "&TermID=HK00");
		}

		private void cbx_NamHoc_TKB_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetWeekofTerm();
			if (listWeek.Count != 0)
				SetValueRangeNUD();
		}

		private void cbx_HocKy_TKB_SelectedIndexChanged(object sender, EventArgs e)
		{
			GetWeekofTerm();
			if (listWeek.Count != 0)
				SetValueRangeNUD();
		}

		private void SinhVienDLU_FormClosing(object sender, FormClosingEventArgs e)
		{
			//if (!rememberLogin)
			//	File.Delete("data.dat");
		}

		/// <summary>
		/// Display tool tip of NumbericUpDown when entered
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nud_Tuan_TKB_Enter(object sender, EventArgs e)
		{
			ToolTip tt = new ToolTip();
			tt.InitialDelay = 0;
			tt.IsBalloon = true;
			tt.Show(string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_TKB.Minimum, " đến ", nud_Tuan_TKB.Maximum), nud_Tuan_TKB, 5000);
		}

		private void btn_Xuat_HP_Click(object sender, EventArgs e)
		{
			var html = client.DownloadString(SchoolFees());
			webBrowser5.DocumentText = html;
		}
	}
}
