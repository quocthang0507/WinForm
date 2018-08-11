using System.Collections.Generic;
using System.Windows;
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
		string pass = "12345679";
		List<string> listWeek;
		int week;

		public MainWindow()
		{
			Login form = new Login();
			form.ShowDialog();
			InitializeComponent();
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
			if (this.WindowState == System.Windows.WindowState.Normal)
			{
				this.WindowState = System.Windows.WindowState.Maximized;
			}
			else
			{
				this.WindowState = System.Windows.WindowState.Normal;
			}
		}

		private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = System.Windows.WindowState.Minimized;
		}
	}
}
