using System.Diagnostics;
using System.Windows.Forms;

namespace CARO
{
	public partial class fmLuatChoi : Form
	{
		public fmLuatChoi()
		{
			InitializeComponent();
		}

		private void LinkFB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("www.facebook.com/PhongHkphone");
		}
	}
}
