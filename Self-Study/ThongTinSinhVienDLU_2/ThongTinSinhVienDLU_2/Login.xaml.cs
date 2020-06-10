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
		private string mssv, password;
		private string pass = "M@tKh@u";
		private bool isSuccess = false;
		private string data = "data.dat";
		private string temp = "temp.txt";
		public static string yourName;

		protected string Pass { get => pass; set => pass = value; }
		protected string Data { get => data; set => data = value; }
		protected string Temp { get => temp; set => temp = value; }

		public Login()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if (File.Exists(Data))
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
			CryptoStuff.DecryptFile(Pass, Data, Temp);
			string data = File.ReadAllText(Temp);
			File.Delete(Temp);
			string[] temp = data.Split(' ');
			mssv = temp[0];
			tbx_UserName.Text = mssv;
			password = temp[1];
			tbx_Password.Password = password;
		}

		private void Ghi_DuLieu()
		{
			string data_de = string.Concat(tbx_UserName.Text, " ", tbx_Password.Password);
			File.WriteAllText(Temp, data_de, Encoding.UTF8);
			CryptoStuff.EncryptFile(Pass, Temp, Data);
			File.Delete(Temp);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (chk_Luu.IsChecked == false)
				File.Delete(Data);
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

		private void GuestMode_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			isSuccess = true;
			this.Close();
			GuestForm form = new GuestForm();
			form.ShowDialog();
		}

		private void logo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			System.Diagnostics.Process.Start(@"http://dlu.edu.vn");
		}

		private void btn_LogIn_Click(object sender, RoutedEventArgs e)
		{
			bool error = false;
			using (var client = new CookieAwareWebClient())
			{
				if (tbx_UserName.Text == "" || tbx_Password.Password == "")
					label3.Content = "Bạn chưa nhập đủ thông tin";
				else
				{
					var values = new NameValueCollection { { "txtTaiKhoan", tbx_UserName.Text }, { "txtMatKhau", tbx_Password.Password } };
					client.Encoding = Encoding.UTF8;
					try
					{
						client.UploadValues(new Uri(@"http://online.dlu.edu.vn/Login"), "POST", values);
					}
					catch (Exception)
					{
						MessageBox.Show("Hừm, có vẻ internet của máy tính không hoạt động hiệu quả, vui lòng kiểm tra lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
						error = true;
					}
					if (!error)
					{
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
							Ghi_DuLieu();
							isSuccess = true;
							this.Close();
						}
					}
				}
			}
		}
	}
}
