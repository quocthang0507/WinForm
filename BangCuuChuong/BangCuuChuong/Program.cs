using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace BangCuuChuong
{
	static class Program
	{
		/// Đây là ứng dụng thứ 2 của mình viết có giao diện
		/// Dùng để xuất Bảng cửu chương phép nhân và phép chia
		/// 
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BangCuuChuong());
		}
	}
}
