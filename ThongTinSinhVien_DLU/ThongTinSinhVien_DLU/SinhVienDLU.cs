using EncryptAndDecryptFile;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
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
            AddSchoolYearList();
            AutoSelectSchoolYear();
            AutoSelectTerm();
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


        void AddSchoolYearList()
        {
            int yearStart = int.Parse(string.Concat("20", mssv[0], mssv[1]));

            for (int i = 0; i < 4; i++)
            {
                cbx_NamHoc.Items.Insert(i, string.Concat(yearStart, '-', ++yearStart));
            }
        }

        void AutoSelectSchoolYear()
        {
            string yearNow = GetSchoolYear();
            foreach (var item in cbx_NamHoc.Items)
            {
                if (item.ToString() == yearNow)
                {
                    cbx_NamHoc.SelectedItem = item;
                    return;
                }
            }
        }

        void AutoSelectTerm()
        {
            DateTime dt = DateTime.Now;
            int month = dt.Month;
            if (month >= 8 && month <= 12)
                cbx_HocKy.SelectedIndex = 0;
            else if (month >= 1 && month <= 6)
                cbx_HocKy.SelectedIndex = 1;
            else cbx_HocKy.SelectedIndex = 2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tác giả: La Quốc Thắng \r\nMọi góp ý vui lòng gửi về Email : quocthang0507@gmail.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void AutoSelectWeek()
        {

        }

        private void btn_XuatTKB_Click(object sender, EventArgs e)
        {
            var html = client.DownloadString(ChangeLinkSchedule());
            webBrowser1.DocumentText = html;
        }

        string ChangeLinkSchedule()
        {
            //if (rbn_SinhVien.Checked == true)
            return string.Concat("http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=", mssv, "&YearId=", cbx_NamHoc.Text, "&TermId=HK0", cbx_HocKy.SelectedIndex + 1, "&WeekId=", nud_Tuan.Value);
        }
    }
}
