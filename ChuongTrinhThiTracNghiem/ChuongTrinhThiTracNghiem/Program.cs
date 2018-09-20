using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhThiTracNghiem
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			bool result;
			var mutex = new Mutex(true, "UniqueAppId", out result);
			if (!result)
			{
				MessageBox.Show("Ứng dụng đang chạy!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			Application.Run(new Form_Question());
			GC.KeepAlive(mutex);
		}
	}
}
