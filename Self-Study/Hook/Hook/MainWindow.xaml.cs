using System;
using System.Linq;
using System.Windows;

namespace Hook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private HookLib.UsingHookKey usingHook;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			usingHook = new HookLib.UsingHookKey();
		}

		/// <summary>
		/// Show the message on the textbox
		/// Used for calling the non-static object in the static method
		/// </summary>
		/// <param name="message"></param>
		public static void Show(string message)
		{
			Application.Current.Dispatcher.Invoke(new Action(() =>
			{
				MainWindow my = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
				my.showResult.Text += message + "\n";
				my.showResult.SelectionStart = my.showResult.Text.Length;
				my.showResult.ScrollToEnd();
			}));
		}
	}
}
