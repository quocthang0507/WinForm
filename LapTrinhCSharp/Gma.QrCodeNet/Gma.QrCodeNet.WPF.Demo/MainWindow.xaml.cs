using System.Windows;
using System.Windows.Controls;

namespace Gma.QrCodeNet.WPF.Demo
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

		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (qrCodeGeoControl1 != null)
			{
				qrCodeImgControl1.Text = textBox1.Text;
				qrCodeGeoControl1.Text = textBox1.Text;
			}
			//qrCodeControl1.Text = textBox1.Text;
		}

	}
}
