﻿using EncryptAndDecryptFile;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ThongTinSinhVien_DLU
{
    public partial class SinhVienDLU : Form
    {
        string mssv, password;
        string pass = "12345679";
        int week;

        CookieAwareWebClient client = new CookieAwareWebClient();


        public SinhVienDLU()
        {
            InitializeComponent();
            Form login = new Form_DangNhap();
            login.ShowDialog();
        }

        private void SinhVienDLU_Load(object sender, EventArgs e)
        {
            Doc_DuLieu();
            SendInfoLogin();
            lbl_YourName.Text = Form_DangNhap.yourName;
            week = GetNumWeek();
            rbn_SinhVien.Checked = true;
            AddSchoolYearList(cbx_NamHoc_TKB);
            AutoSelectSchoolYear(cbx_NamHoc_TKB);
            AutoSelectTerm(cbx_HocKy_TKB);
            label4.Visible = label5.Visible = false;
            tbx_GiangVien.Visible = tbx_Lop.Visible = false;
        }

        void SendInfoLogin()
        {
            var values = new NameValueCollection { { "txtTaiKhoan", mssv }, { "txtMatKhau", password } };
            client.Encoding = Encoding.UTF8;
            client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
        }

        void Doc_DuLieu()
        {
            string path = "data.dat";
            CryptoStuff.DecryptFile(pass, path, "temp.txt");
            string data = File.ReadAllText("temp.txt");
            File.Delete("temp.txt");
            string[] temp = data.Split(' ');
            mssv = temp[0];
            password = temp[1];
        }

        int GetNumWeek()
        {
            using (var client = new CookieAwareWebClient())
            {
                client.Encoding = Encoding.UTF8;
                var html = client.DownloadString(@"http://vi.weeknumber52.com/getdate.php?lang=vi");
                html = Regex.Match(html, "<li class=\"date1\">*>([^<]*)</li>").Value;
                html = html.Replace("<li class=\"date1\">Tuần ", "");
                html = html.Replace("</li>", "");
                return int.Parse(html);
            }
        }

        string GetSchoolYear()
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

        string GetStudyPrograms()
        {
            client.Encoding = Encoding.UTF8;
            var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/StudyPrograms");
            html = Regex.Match(html, "<option value=\"(.*?)\">").Value;
            html = Regex.Match(html, "\"(.*?)\"").Value;
            html = html.Replace("\"", "");
            return html;
        }

        void AddSchoolYearList(ComboBox x)
        {
            int yearStart = int.Parse(string.Concat("20", mssv[0], mssv[1]));

            for (int i = 0; i < 4; i++)
            {
                x.Items.Insert(i, string.Concat(yearStart, '-', ++yearStart));
            }
        }

        void AutoSelectSchoolYear(ComboBox x)
        {
            string yearNow = GetSchoolYear();
            foreach (var item in cbx_NamHoc_TKB.Items)
            {
                if (item.ToString() == yearNow)
                {
                    x.SelectedItem = item;
                    return;
                }
            }
        }

        void AutoSelectTerm(ComboBox x)
        {
            DateTime dt = DateTime.Now;
            int month = dt.Month;
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

        void AutoSelectWeek()
        {

        }

        string ChangeLinkSchedule()
        {
            if (rbn_SinhVien.Checked == true)
                return string.Concat("http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=", mssv, "&YearId=", cbx_NamHoc_TKB.Text, "&TermId=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&WeekId=", nud_Tuan_TKB.Value);
            else if (rbn_Lop.Checked == true)
                return string.Concat("http://online.dlu.edu.vn/Home/DrawingClassStudentSchedules_Mau2?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", nud_Tuan_TKB.Value, "&ClassStudentID=", tbx_Lop.Text);
            else return string.Concat("http://online.dlu.edu.vn/Home/DrawingProfessorSchedule?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", nud_Tuan_TKB.Value, "&ProfessorID=", tbx_GiangVien.Text);
        }

        private void btn_XuatTKB_Click(object sender, EventArgs e)
        {
            var html = client.DownloadString(ChangeLinkSchedule());
            webBrowser1.DocumentText = html;
        }

        private void rbn_Lop_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_Lop.Checked == true)
            {
                label4.Visible = true;
                tbx_Lop.Visible = true;
            }
            else
            {
                label4.Visible = false;
                tbx_Lop.Visible = false;
            }
        }

        private void rbn_GiangVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_GiangVien.Checked == true)
            {
                label5.Visible = true;
                tbx_GiangVien.Visible = true;
            }
            else
            {
                label5.Visible = false;
                tbx_GiangVien.Visible = false;
            }
        }

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

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (cbx_NamHoc_LichThi.Items.Count == 0)
                {
                    AddSchoolYearList(cbx_NamHoc_LichThi);
                    AutoSelectTerm(cbx_HocKy_LichThi);
                    AutoSelectSchoolYear(cbx_NamHoc_LichThi);
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (cbx_NamHoc_Diem.Items.Count == 0)
                {
                    AddSchoolYearList(cbx_NamHoc_Diem);
                    AutoSelectTerm(cbx_HocKy_Diem);
                    AutoSelectSchoolYear(cbx_NamHoc_Diem);
                    cbx_HocKy_Diem.Items.Add("Tất cả");
                    cbx_NamHoc_Diem.Items.Add("Tất cả");
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (cbx_NamHoc_RL.Items.Count == 0)
                {
                    AddSchoolYearList(cbx_NamHoc_RL);
                    AutoSelectTerm(cbx_HocKy_RL);
                    AutoSelectSchoolYear(cbx_NamHoc_RL);
                }
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                if (cbx_NamHoc_HP.Items.Count == 0)
                {
                    AddSchoolYearList(cbx_NamHoc_HP);
                    AutoSelectTerm(cbx_HocKy_HP);
                    AutoSelectSchoolYear(cbx_NamHoc_HP);
                }
            }
        }
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

        string Behavior()
        {
            return string.Concat("http://online.dlu.edu.vn/Home/BehaviorByStudent?yearStudy=", cbx_NamHoc_RL.Text, "&termID=HK0", cbx_HocKy_RL.Text);
        }

        private void btn_Xuat_RL_Click(object sender, EventArgs e)
        {
            var html = client.DownloadString(Behavior());
            html = html.Replace(".error {\r\n        border-color: red;\r\n    }", ".error {\r\n        border-color: red;\r\n    }   table {\r\n    width:100%;\r\n    }");
            webBrowser4.DocumentText = html;
        }

        string SchoolFee()
        {
            return string.Concat("http://online.dlu.edu.vn/Home/ShowFees?YearStudy=", cbx_NamHoc_HP.Text, "&TermID=HK0", cbx_HocKy_HP.Text);
        }

        private void btn_Xuat_HP_Click(object sender, EventArgs e)
        {
            var html = client.DownloadString(SchoolFee());
            webBrowser5.DocumentText = html;
        }
    }
}
