using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienDien
{
	static class Program
	{
		/// Đây là chương trình thứ 3 mà Thắng viết
		/// Nó công phu hơn 2 chương trình trước.
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ChuongTrinh());
		}
	}
}
