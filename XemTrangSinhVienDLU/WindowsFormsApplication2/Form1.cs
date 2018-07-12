using System;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using EncryptAndDecryptFile;

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

        string pass = "12345679";
        string mssv, password;


        public SinhVienOnline()
        {
            InitializeComponent();
            if (File.Exists("data.dat"))
            {
                Doc_DuLieu();
            }
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
                    if (!File.Exists("data.dat") || mssv != tbx_UserName.Text || password != tbx_Password.Text)
                    {
                        File.Delete("data.dat");
                        Ghi_DuLieu();
                    }
                    var values = new NameValueCollection { { "txtTaiKhoan", tbx_UserName.Text }, { "txtMatKhau", tbx_Password.Text } };
                    client.Encoding = Encoding.UTF8;
                    client.UploadValues(new Uri("http://online.dlu.edu.vn/Login"), "POST", values);
                    var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/DrawingStudentSchedule?StudentId=1610207&YearId=2017-2018&TermId=HK02&WeekId=3");
                    if (html.Contains("<title>Đăng nhập</title>"))
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else webBrowser1.DocumentText = html;
                }
            }
        }

        private void Doc_DuLieu()
        {
            string path = "data.dat";
            CryptoStuff.DecryptFile(pass, path, "temp.txt");
            string data = File.ReadAllText("temp.txt");
            File.Delete("temp.txt");
            string[] temp = data.Split(' ');
            mssv = temp[0];
            tbx_UserName.Text = temp[0];
            password = temp[1];
            tbx_Password.Text = temp[1];
        }

        private void Ghi_DuLieu()
        {
            string data_de = string.Concat(tbx_UserName.Text, " ", tbx_Password.Text);
            File.WriteAllText("temp.txt", data_de, Encoding.UTF8);
            CryptoStuff.EncryptFile(pass, "temp.txt", "data.dat");
            File.Delete("temp.txt");
        }
    }
}
