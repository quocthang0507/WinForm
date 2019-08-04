using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OMRReader_test1
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
            //Application.Run(new OMR.Forms.omrSheetDesigner());
            //Application.Run(new OMR.Forms.answerKeyDesigner());
            Application.Run(new Form1());
            //Application.Run(new OMR.Forms.gsDownloader());
        }
    }
}
