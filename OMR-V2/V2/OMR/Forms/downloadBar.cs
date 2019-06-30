using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OMR.helpers;

namespace OMR.Forms
{
    public partial class gsDownloader : Form
    {
        public gsDownloader()
        {
            InitializeComponent();
        }
        System.Net.WebClient wc = new System.Net.WebClient();
        string x32DLL = "GSdll32.dll";
        string x64DLL = "GSdll64.dll";
        string x32Setup = "redist\\ghostScript\\GPL Ghost Script 9.18 x32.exe";
        string x64Setup = "redist\\ghostScript\\GPL Ghost Script 9.18 x64.exe";
        string x32Link = @"http://downloads.ghostscript.com/public/gs918w32.exe";
        string x64Link = @"http://downloads.ghostscript.com/public/gs918w64.exe";
        string dll = "", setup = "", link = "";

        Timer t; TimeSpan ts = new TimeSpan();
        bool forceClose = false, allowClose = false;
        private void downloadBar_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            bool exit = true;
            if (!SystemUtils.tryGSCopy())
            {
                if (SystemUtils.InternalCheckIsWow64())
                {
                    dll = x64DLL;
                    setup = x64Setup;
                    link = x64Link;
                }
                else
                {
                    dll = x32DLL;
                    setup = x32Setup;
                    link = x32Link;
                }
                if (MessageBox.Show(this, "GPL Ghostscript is required by this utility to run. Kindly download and install it to your PC and then copy " + dll + " to the application directory.\r\nAlternatively, you could let the application do this automatically for you. Do you want to let it do the required tasks for you?", "GPL Ghostscript not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    exit = false;

                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    try
                    {
                        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(setup));
                    }
                    catch { }
                    if (File.Exists(setup))
                        downloadComplete();
                    else
                    {
                        ts = new TimeSpan(DateTime.Now.Ticks);
                        wc.DownloadFileAsync(new Uri(link), setup);
                    }
                }
            }
            else { DialogResult = DialogResult.OK; }
            if (exit)
            {
                forceClose = true;
                allowClose = true;
                t = new Timer(); t.Interval = 100; t.Tick += T_Tick; t.Start();
            }
        }
        

        private void T_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            allowClose = true;
            Close();
        }

        private void downloadComplete()
        {
            MessageBox.Show("When the wizard installs GhostScript, don't change the installation path.");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = new System.Diagnostics.ProcessStartInfo(setup);
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch { }
            if (SystemUtils.tryGSCopy())
            {
                MessageBox.Show("Ghost script was installed successfully.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                allowClose = true;
                MessageBox.Show("Ghost script installation failed. Kindly retry or install it manually.");
                DialogResult = DialogResult.No;
                Close();
            }
        }
        private void Wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            double elapsedms = (ts2 - ts).TotalMilliseconds;
            double remaining = elapsedms * (100D - (double)e.ProgressPercentage) / (double)e.ProgressPercentage;
            allowClose = true;
            label2.Text = string.Format("Downloaded {0} MB of {1} MB ({2}%)",
                Math.Round((double)e.BytesReceived / 1024 / 1024, 2),
                Math.Round((double)e.TotalBytesToReceive / 1024 / 1024, 2),
                e.ProgressPercentage);
            label3.Text = "ETA: " + new TimeSpan(0, 0, 0, (int)(remaining / 1000), 0).ToString();
            progressBar1.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                label2.Text = "Download Complete.";
                downloadComplete();
            }
            { label2.Text = "Connection error..."; DialogResult = DialogResult.Abort; };
        }

        private void downloadBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (allowClose)
            {
                if (!forceClose)
                {
                    if (MessageBox.Show(this, "Do you want to cancel the installation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        DialogResult = DialogResult.Abort;
                    else
                        e.Cancel = true;
                }
            }
            else e.Cancel = true;

            if (e.Cancel == false)
            {
                try { wc.CancelAsync();wc.Dispose();  File.Delete(setup); } catch { }
            }
        }
    }
}
