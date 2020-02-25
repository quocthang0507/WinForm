using AltoHttp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AltoHttp_Downoload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://laptrinhvb.net");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DownloadFile(txt_link.Text, Application.StartupPath + "\\" + Path.GetFileName(txt_link.Text));
        }
        public HttpDownloader mDownloader = null;
        public void DownloadFile(string urlAddress, string location)
        {
            mDownloader = new HttpDownloader(urlAddress, location);
            mDownloader.DownloadProgressChanged += new AltoHttp.ProgressChangedEventHandler(downloadProgress);
            mDownloader.DownloadCompleted += new EventHandler(downloadComplete);
            mDownloader.StartAsync();

        }

        private void downloadComplete(object sender, EventArgs e)
        {
            lbl_status.Text = "Finish!";
            lbl_percent.Text = "100%";
        }

        private void downloadProgress(object sender, AltoHttp.DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.Progress;
            lbl_percent.Text = e.Progress + "%";
            lbl_speed.Text = string.Format("{0} MB/s", (e.Speed / 1024d / 1024d).ToString("0.00"));
            lbl_size.Text = string.Format("{0} MB",               
               (mDownloader.ContentSize / 1024d / 1024d).ToString("0.00"));

            lbl_bytesReceived.Text = string.Format("{0} / {1} ",
               (mDownloader.BytesReceived ).ToString("0.00"),
               (mDownloader.ContentSize).ToString("0.00"));
            lbl_status.Text = "Downloading...";
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            mDownloader.Pause();
            lbl_status.Text = "Paused";
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            mDownloader.ResumeAsync();
            lbl_status.Text = "Resume...";
        }
    }
}
