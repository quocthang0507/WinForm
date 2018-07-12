using System;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class SinhVienOnline : Form
    {
        public class CookieAwareWebClient : WebClient
        {
            private int? _timeout = null;
            public int? Timeout { get { return _timeout; } set { _timeout = value; } }
            public CookieContainer CookieContainer { get; private set; }
            public CookieCollection ResponseCookies { get; set; }
            public CookieAwareWebClient() { CookieContainer = new CookieContainer(); this.ResponseCookies = new CookieCollection(); }
            public CookieAwareWebClient(CookieContainer cookies) { this.CookieContainer = cookies; }
            public void SetTimeout(int timeout) { _timeout = timeout; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = (HttpWebRequest)base.GetWebRequest(address);
                request.CookieContainer = CookieContainer;
                if (_timeout.HasValue) { request.Timeout = _timeout.Value; }
                return request;
            }
        }

        public SinhVienOnline()
        {
            InitializeComponent();
            if (!File.Exists("data.txt"))
                File.CreateText("data.txt");
            else Doc_DuLieu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new CookieAwareWebClient())
            {
                if (tbx_UserName.Text == "" || tbx_Password.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Lỗi");
                }
                else
                {
                    Ghi_DuLieu();
                    var values = new NameValueCollection { { "txtTaiKhoan", tbx_UserName.Text }, { "txtMatKhau", tbx_Password.Text } };
                    client.Encoding = Encoding.UTF8;
                    client.UploadValues(new Uri("http://online.dlu.edu.vn/Login"), "POST", values);
                    var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=1610207&YearId=2017-2018&TermId=HK02&WeekId=3");
                    webBrowser1.DocumentText = html;
                }
            }
        }

        private void Doc_DuLieu()
        {
            string path = "data.txt";
            StreamReader sr = new StreamReader(path);
            string data = sr.ReadLine();
            if (data != "")
            {
                tbx_UserName.Text = data;
                tbx_Password.Text = sr.ReadLine();
                sr.Close();
            }
            else Ghi_DuLieu();
        }

        private void Ghi_DuLieu()
        {
            string path = "data.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(tbx_UserName.Text);
            sw.Write(tbx_Password.Text);
            sw.Close();
        }
    }
}
