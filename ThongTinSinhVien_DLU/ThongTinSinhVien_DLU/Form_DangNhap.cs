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
        }

        private void Form_DangNhap_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.dat"))
            {
                chk_Luu.Checked = true;
                Doc_DuLieu();
                btn_LogIn.Focus();
            }
            else
                chk_Luu.Checked = false; tbx_UserName.Focus();
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
                        label3.Text = "Lỗi kết nối với máy chủ!";
                        throw;
                    }
                    var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/Index");
                    if (html.Contains("<title>Đăng nhập</title>"))
                        label3.Text = "Bạn nhập sai tên đăng nhập hoặc mật khẩu";
                    else
                    {
                        yourName = Regex.Match(html, "<span>(?<Content>([^<]*))</span>").Value;
                        yourName = yourName.Replace("<span>", "");
                        yourName = yourName.Replace("</span>", "");
                        yourName = yourName.Replace("#224;", "à");
                        label3.Text = "";
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

        private void Form_DangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btn_LogIn.PerformClick();
        }

        private void tbx_UserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form_DangNhap_KeyPress(sender, e);
        }

        private void tbx_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form_DangNhap_KeyPress(sender, e);
        }

        private void chk_Luu_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Luu.Checked == true)
                Form_SinhVienDLU.rememberLogin = true;
            else Form_SinhVienDLU.rememberLogin = false;
        }
    }
}
