using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using Windows7Jumplist;

namespace JumplistDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool firstInstance = false;

            Mutex mtx = new Mutex(true, "Jumplist.demo", out firstInstance);

            if (firstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                // Send argument to running window
                HandleCmdLineArgs();
            }
        }

        public static void HandleCmdLineArgs()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                switch (Environment.GetCommandLineArgs()[1])
                {
                    case "-1":
                        WindowsMessageHelper.SendMessage("Jumplist.demo", WindowsMessageHelper.ClearHistoryArg);
                        break;
                }
            }
        }
    }
}
