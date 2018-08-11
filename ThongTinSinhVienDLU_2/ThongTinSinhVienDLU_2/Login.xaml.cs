using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ThongTinSinhVienDLU_2
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		string mssv, password;
		string pass = "matkhau";
		bool isSuccess = false;
		public static string yourName;

		public Login()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (File.Exists("data.dat"))
			{
				chk_Luu.IsChecked = true;
				Doc_DuLieu();
				btn_LogIn.Focus();
			}
			else
			{
				chk_Luu.IsChecked = false;
				tbx_UserName.Focus();
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
			tbx_UserName.Text = mssv;
			password = temp[1];
			tbx_Password.Password = password;
		}

		private void Ghi_DuLieu()
		{
			string data_de = string.Concat(tbx_UserName.Text, " ", tbx_Password.Password);
			File.WriteAllText("temp.txt", data_de, Encoding.UTF8);
			CryptoStuff.EncryptFile(pass, "temp.txt", "data.dat");
			File.Delete("temp.txt");
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!isSuccess)
				Environment.Exit(1);
		}

		private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				btn_LogIn_Click(this, null);
		}

		private void tbx_UserName_KeyDown(object sender, KeyEventArgs e)
		{
			Window_KeyDown(sender, e);
		}

		private void tbx_Password_KeyDown(object sender, KeyEventArgs e)
		{
			Window_KeyDown(sender, e);
		}

		private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void chk_Luu_Checked(object sender, RoutedEventArgs e)
		{
			MainWindow.rememberLogin = true;
		}

		private void chk_Luu_Unchecked(object sender, RoutedEventArgs e)
		{
			MainWindow.rememberLogin = false;
		}

		private void btn_LogIn_Click(object sender, RoutedEventArgs e)
		{
			using (var client = new CookieAwareWebClient())
			{
				if (tbx_UserName.Text == "" || tbx_Password.Password == "")
					label3.Content = "Bạn chưa nhập đủ thông tin";
				else
				{
					if (!File.Exists("data.dat") || mssv != tbx_UserName.Text || password != tbx_Password.Password)
					{
						File.Delete("data.dat");
						Ghi_DuLieu();
					}
					var values = new NameValueCollection { { "txtTaiKhoan", tbx_UserName.Text }, { "txtMatKhau", tbx_Password.Password } };
					client.Encoding = Encoding.UTF8;
					try
					{
						client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
					}
					catch (Exception)
					{
						label3.Content = "Lỗi kết nối với máy chủ!";
						throw;
					}
					var html = client.DownloadString(@"http://online.dlu.edu.vn/Home/Index");
					if (html.Contains("<title>Đăng nhập</title>"))
						label3.Content = "Bạn nhập sai tên đăng nhập hoặc mật khẩu";
					else
					{
						yourName = Regex.Match(html, "<span>(?<Content>([^<]*))</span>").Value;
						yourName = yourName.Replace("<span>", "");
						yourName = yourName.Replace("</span>", "");
						yourName = yourName.Replace("#224;", "à");
						label3.Content = "";
						isSuccess = true;
						this.Close();
					}
				}
			}
		}
	}
}
