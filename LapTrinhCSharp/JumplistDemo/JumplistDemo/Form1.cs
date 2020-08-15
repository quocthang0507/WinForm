using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Windows7Jumplist;

namespace JumplistDemo
{
    public partial class Form1 : Form
    {
        private MyJumplist list;
        public Form1()
        {
            InitializeComponent();          
            list = new MyJumplist(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WindowsMessageHelper.ClearHistoryArg)
            {
            
                ClearHistory();
                UpdateRecentAction(RecentActions.ClearHistory);
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {              
                txtFilePath.Text = dlg.FileName;             
                lbRecentFiles.Items.Add(txtFilePath.Text);
                list.AddToRecent(txtFilePath.Text);               
                UpdateRecentAction(RecentActions.OpenFile);
            }
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            OpenNotepad();
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            OpenCalculator();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            ClearHistory();
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            OpenPaint();
        }

        private void ClearHistory()
        {         
            lbRecentFiles.Items.Clear();
            txtFilePath.Text = "";          
            UpdateRecentAction(RecentActions.ClearHistory);
        }

        private void OpenNotepad()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Process.Start(Path.Combine(path, "notepad.exe"));

            UpdateRecentAction(RecentActions.OpenNotepad);
        }

        private void OpenCalculator()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Process.Start(Path.Combine(path, "calc.exe"));

            UpdateRecentAction(RecentActions.OpenCalculator);
        }

        private void OpenPaint()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Process.Start(Path.Combine(path, "mspaint.exe"));

            UpdateRecentAction(RecentActions.OpenPaint);
        }

        private void UpdateRecentAction(RecentActions recentAction)
        {
            switch (recentAction)
            {
                case RecentActions.ClearHistory:
                    lblRecentAction.Text = "Clear History";
                    break;

                case RecentActions.OpenCalculator:
                    lblRecentAction.Text = "Open Calculator";
                    break;

                case RecentActions.OpenFile:
                    lblRecentAction.Text = "Open file";
                    break;

                case RecentActions.OpenNotepad:
                    lblRecentAction.Text = "Open Notepad";
                    break;

                case RecentActions.OpenPaint:
                    lblRecentAction.Text = "Open Paint";
                    break;
            }
        }
    }
}
