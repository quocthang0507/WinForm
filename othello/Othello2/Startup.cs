using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Othello2
{
	static class Startup
	{
		public static frmOthello mainForm;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mainForm = new frmOthello();
			Application.Run(mainForm);
		}
	}
}
