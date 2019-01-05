using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ThongTinSinhVienDLU_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool rememberLogin = false;
        string mssv, password;
        private string pass = "M@tKh@u";
        private string data = "data.dat";
        private string temp = "temp.txt";
        int week;
        CookieAwareWebClient client = new CookieAwareWebClient();
        List<string> listWeek;

        protected string Pass { get => pass; set => pass = value; }
        protected string Temp { get => temp; set => temp = value; }
        protected string Data { get => data; set => data = value; }

        public MainWindow()
        {
            Login form = new Login();
            form.ShowDialog();
            InitializeComponent();
        }

        #region Events
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (Doc_DuLieu())
            {
                SendLoginCookie();
                lbl_YourName.Content = Login.yourName;
                week = GetCurrentNumWeek();
                rbn_SinhVien.IsChecked = true;
                AddSchoolYearsList(cbx_NamHoc_TKB);
                AutoSelectSchoolYear(cbx_NamHoc_TKB);
                AutoSelectTerm(cbx_HocKy_TKB);
                GetWeekofTerm();
                AutoSelectWeek();
                SetValueRangeNUD();
            }
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

        private void btn_Xuat_TKB_Click(object sender, RoutedEventArgs e)
        {
            string html;
            try
            {
                html = client.DownloadString(GetScheduleLink());
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            webBrowser1.DocumentText = html;
        }

        private void rbn_Lop_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (rbn_Lop.IsChecked == true)
            {
                label3.Visibility = Visibility.Visible;
                tbx_Lop.Visibility = Visibility.Visible;
            }
            else
            {
                label3.Visibility = Visibility.Hidden;
                tbx_Lop.Visibility = Visibility.Hidden;
            }
        }

        private void rbn_GiangVien_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (rbn_GiangVien.IsChecked == true)
            {
                label4.Visibility = Visibility.Visible;
                tbx_GiangVien.Visibility = Visibility.Visible;
            }
            else
            {
                label4.Visibility = Visibility.Hidden;
                tbx_GiangVien.Visibility = Visibility.Hidden;
            }
        }

        string SchoolFees()
        {
            return string.Concat("http://online.dlu.edu.vn/Home/ShowFees?YearStudy=", GetCurrentSchoolYear(), "&TermID=HK00");
        }

        private void nud_Tuan_TKB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            btn_Xuat_TKB_Click(sender, null);
        }

        private void cbx_HocKy_Diem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Xuat_Diem_Click(sender, null);
        }

        private void btn_Xuat_HP_Click(object sender, EventArgs e)
        {
            string html;
            try
            {
                html = client.DownloadString(SchoolFees());
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            webBrowser5.DocumentText = html;
        }

        private void btn_Xuat_RL_Click(object sender, RoutedEventArgs e)
        {
            string html;
            try
            {
                html = client.DownloadString(Behaviors());
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var clearScript = Regex.Match(html, "<script[^>]*>(?:[^<]+|<(?!\n/script>))+").Value;
            html = html.Replace(clearScript, "");
            html = html.Replace(".error {\r\n        border-color: red;\r\n    }", ".error {\r\n        border-color: red;\r\n    }   table {\r\n    width:100%;\r\n    }");
            webBrowser4.DocumentText = html;
        }

        private void cbx_NamHoc_TKB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetWeekofTerm();
            if (listWeek.Count != 0)
                SetValueRangeNUD();
            if (nud_Tuan_TKB.Value < nud_Tuan_TKB.Minimum || nud_Tuan_TKB.Value > nud_Tuan_TKB.Maximum)
                nud_Tuan_TKB.Value = nud_Tuan_TKB.Minimum;
        }

        private void cbx_HocKy_TKB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbx_NamHoc_TKB_SelectionChanged(sender, e);
        }

        private void nud_Tuan_TKB_GotFocus(object sender, RoutedEventArgs e)
        {
            nud_Tuan_TKB.ToolTip = string.Concat("Chỉ được nhập giá trị trong phạm vi từ ", nud_Tuan_TKB.Minimum, " đến ", nud_Tuan_TKB.Maximum);
        }

        private void cbx_NamHoc_Diem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbx_NamHoc_Diem.SelectedIndex == 4)
            {
                label8.Visibility = Visibility.Hidden;
                cbx_HocKy_Diem.Visibility = Visibility.Hidden;
            }
            else
            {
                label8.Visibility = Visibility.Visible;
                cbx_HocKy_Diem.Visibility = Visibility.Visible;
            }
        }

        private void btn_Xuat_Diem_Click(object sender, RoutedEventArgs e)
        {
            string html;
            try
            {
                html = client.DownloadString(Marks());
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            html = html.Replace("/Content/images/Dau.png", "http://online.dlu.edu.vn/Content/images/Dau.png");
            html = html.Replace("/Content/images/Rot.png", "http://online.dlu.edu.vn/Content/images/Rot.png");
            html = html.Replace("/Content/images/detail.png", "http://online.dlu.edu.vn/Content/images/detail.png");
            webBrowser3.DocumentText = html;
        }

        private void btn_Xuat_LichThi_Click(object sender, RoutedEventArgs e)
        {
            string html;
            try
            {
                html = client.DownloadString(ExamSchedule());
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            webBrowser2.DocumentText = html;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                if (cbx_NamHoc_LichThi.Items.Count == 0)
                {
                    AddSchoolYearsList(cbx_NamHoc_LichThi);
                    AutoSelectTerm(cbx_HocKy_LichThi);
                    AutoSelectSchoolYear(cbx_NamHoc_LichThi);
                    btn_Xuat_LichThi_Click(sender, e);
                }
            }
            else if (tabControl.SelectedIndex == 2)
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
            else if (tabControl.SelectedIndex == 3)
            {
                if (cbx_NamHoc_RL.Items.Count == 0)
                {
                    AddSchoolYearsList(cbx_NamHoc_RL);
                    AutoSelectTerm(cbx_HocKy_RL);
                    AutoSelectSchoolYear(cbx_NamHoc_RL);
                    btn_Xuat_RL_Click(sender, e);
                }
            }
            else if (tabControl.SelectedIndex == 4)
                btn_Xuat_HP_Click(sender, e);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Đọc dữ liệu từ file
        /// </summary>
        bool Doc_DuLieu()
        {
            if (!File.Exists(Data))
                return false;
            CryptoStuff.DecryptFile(Pass, Data, Temp);
            string data = File.ReadAllText(Temp);
            File.Delete(Temp);
            string[] temp = data.Split(' ');
            mssv = temp[0];
            password = temp[1];
            if (!rememberLogin)
                File.Delete(Data);
            return true;
        }

        /// <summary>
        /// Gửi thông tin đăng nhập
        /// </summary>
        void SendLoginCookie()
        {
            var values = new NameValueCollection { { "txtTaiKhoan", mssv }, { "txtMatKhau", password } };
            client.Encoding = Encoding.UTF8;
            try
            {
                client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// Lấy tuần hiện tại
        /// </summary>
        /// <returns>Số tuần</returns>
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
                MessageBox.Show("Hừm, xảy ra lỗi khi lấy thông tin tuần trên internet, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            html = Regex.Match(html, "<li class=\"date1\">*>([^<]*)</li>").Value;
            html = html.Replace("<li class=\"date1\">Tuần ", "");
            html = html.Replace("</li>", "");
            return Convert.ToInt32(html);
        }

        /// <summary>
        /// Lấy năm học hiện tại
        /// </summary>
        /// <returns>Năm học</returns>
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
        /// Lấy chương trình đào tạo
        /// </summary>
        /// <returns>Mã chương trình đào tạo</returns>
        string GetStudyPrograms()
        {
            string html;
            try
            {
                html = client.DownloadString(@"http://online.dlu.edu.vn/Home/StudyPrograms");
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            html = Regex.Match(html, "<option value=\"(.*?)\">").Value;
            html = Regex.Match(html, "\"(.*?)\"").Value;
            html = html.Replace("\"", "");
            return html;
        }

        /// <summary>
        /// Thêm năm học vào combobox
        /// </summary>
        /// <param name="x"></param>
        void AddSchoolYearsList(ComboBox x)
        {
            int yearStart = int.Parse(string.Concat("20", mssv[0], mssv[1]));
            for (int i = 0; i <= 4; i++)
                x.Items.Insert(i, string.Concat(yearStart, '-', ++yearStart));
        }

        /// <summary>
        /// Tự động chọn năm học
        /// </summary>
        /// <param name="x"></param>
        void AutoSelectSchoolYear(ComboBox x)
        {
            x.Text = GetCurrentSchoolYear();
        }

        /// <summary>
        /// Tự động chọn học kỳ
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

        /// <summary>
        /// Lấy tuần học
        /// </summary>
        void GetWeekofTerm()
        {
            string link = string.Concat(@"http://qlgd.dlu.edu.vn/Public/GetWeek/", cbx_NamHoc_TKB.SelectedValue, "$HK0", cbx_HocKy_TKB.SelectedValue);
            string data;
            try
            {
                data = client.DownloadString(link);
            }
            catch (Exception)
            {
                MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
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

        /// <summary>
        /// Thêm giới hạn cho NumericUpDown
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
        /// Tự động chọn tuần học
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
        /// Đổi tuần học sang tuần trong năm
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
        /// Trả về thời khóa biểu
        /// </summary>
        /// <returns>Url</returns>
        string GetScheduleLink()
        {
            if (rbn_SinhVien.IsChecked == true)
                return string.Concat(@"http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=", mssv, "&YearId=", cbx_NamHoc_TKB.Text, "&TermId=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&WeekId=", DisplayWeek2RealWeek());
            else if (rbn_Lop.IsChecked == true)
                return string.Concat(@"http://online.dlu.edu.vn/Home/DrawingClassStudentSchedules_Mau2?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", DisplayWeek2RealWeek(), "&ClassStudentID=", tbx_Lop.Text);
            else return string.Concat(@"http://online.dlu.edu.vn/Home/DrawingProfessorSchedule?YearStudy=", cbx_NamHoc_TKB.Text, "&TermID=HK0", cbx_HocKy_TKB.SelectedIndex + 1, "&Week=", DisplayWeek2RealWeek(), "&ProfessorID=", tbx_GiangVien.Text);
        }

        /// <summary>
        /// Trả về lịch thi
        /// </summary>
        /// <returns>Url</returns>
        string ExamSchedule()
        {
            return string.Concat(@"http://online.dlu.edu.vn/Home/ShowExam?YearStudy=", cbx_NamHoc_LichThi.Text, "&TermID=HK0", cbx_HocKy_LichThi.SelectedIndex + 1);
        }

        /// <summary>
        /// Trả về điểm số
        /// </summary>
        /// <returns>Url</returns>
        string Marks()
        {
            if (cbx_NamHoc_Diem.Text == "Tất cả")
                return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=0&TermID=0&HeDiem=10");
            else if (cbx_HocKy_Diem.Text == "Tất cả")
                return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=", cbx_NamHoc_Diem.Text, "&TermID=0&HeDiem=10");
            else return string.Concat("http://online.dlu.edu.vn/Home/ShowMark?StudyProgram=", GetStudyPrograms(), "&YearStudy=", cbx_NamHoc_Diem.Text, "&TermID=HK0", cbx_HocKy_Diem.Text, "&HeDiem=10");
        }

        /// <summary>
        /// Trả về điểm rèn luyện
        /// </summary>
        /// <returns>Url</returns>
        string Behaviors()
        {
            return string.Concat("http://online.dlu.edu.vn/Home/BehaviorByStudent?yearStudy=", cbx_NamHoc_RL.Text, "&termID=HK0", cbx_HocKy_RL.Text);
        }

        #endregion
    }
}
