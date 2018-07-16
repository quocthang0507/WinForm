using EncryptAndDecryptFile;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ThongTinSinhVien_DLU
{
    public partial class Form_DangNhap : Form
    {
        string mssv, password;
        string pass = "12345679";
        bool isSuccess = false;
        public static string yourName;

        public Form_DangNhap()
        {
            InitializeComponent();
            tbx_UserName.Focus();
            if (File.Exists("data.dat"))
            {
                Doc_DuLieu();
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


        private void btn_LogIn_Click(object sender, EventArgs e)
        {
            using (var client = new CookieAwareWebClient())
            {
                if (tbx_UserName.Text == "" || tbx_Password.Text == "")
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Lỗi");
                else
                {
                    if (!File.Exists("data.dat") || mssv != tbx_UserName.Text || password != tbx_Password.Text)
                    {
                        File.Delete("data.dat");
                        Ghi_DuLieu();
                    }
                    var values = new NameValueCollection { { "txtTaiKhoan", tbx_UserName.Text }, { "txtMatKhau", tbx_Password.Text } };
                    client.Encoding = Encoding.UTF8;
                    try
                    {
                        client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi kết nối với máy chủ! Vui lòng kiểm tra kết nối mạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                    var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/Index");
                    if (html.Contains("<title>Đăng nhập</title>"))
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        yourName = Regex.Match(html, "<span>(?<Content>([^<]*))</span>").Value;
                        yourName = yourName.Replace("<span>", "");
                        yourName = yourName.Replace("</span>", "");
                        MessageBox.Show(string.Concat("Xin chào ", yourName), "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSuccess = true;
                        this.Close();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dlu.edu.vn");
        }

        private void Form_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSuccess)
                Application.Exit();
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
