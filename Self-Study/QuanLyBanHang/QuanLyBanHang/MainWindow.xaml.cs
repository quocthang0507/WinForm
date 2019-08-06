using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace QuanLyBanHang
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
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

		private void Menu_Thoat_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(1);
		}

		private void Menu_LoadBangGia_Click(object sender, RoutedEventArgs e)
		{
			string path = Excel.OpenFile();
			string dataPath = Directory.GetCurrentDirectory().ToString() + "\\data.dat";
			if (path != null)
			{
				dgBangGia.ItemsSource = Excel.ReadExcel(path);
				if (!File.Exists(dataPath))
				{
					File.Create(dataPath);
				}
				StreamWriter streamWriter = new StreamWriter(dataPath);
				streamWriter.Write(dataPath);
				streamWriter.Close();
			}
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			string path = Directory.GetCurrentDirectory().ToString() + "\\data.dat";
			if (File.Exists(path))
			{
				StreamReader streamReader = new StreamReader(path);
				string data = streamReader.ReadLine();
				if (File.Exists(data))
				{
					dgBangGia.ItemsSource = Excel.ReadExcel(data);
				}
				streamReader.Close();
			}
		}
	}
}
