using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaiPTBac2
{
	static class Program
	{
		/// Đây là chương trình có giao diện đầu tiên do Thắng viết toàn bộ
		/// Có tham khảo các bước từ giáo trình của trường Đại học Bách khoa
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
