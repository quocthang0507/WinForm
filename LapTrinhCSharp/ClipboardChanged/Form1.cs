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
using WK.Libraries.SharpClipboardNS;

namespace ClipboardChanged
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();        
            chkMonitorClipboard.Checked = sharpClipboard1.MonitorClipboard;
            chkObserveTexts.Checked = sharpClipboard1.ObservableFormats.Texts;
            chkObserveFiles.Checked = sharpClipboard1.ObservableFormats.Files;
            chkObserveImages.Checked = sharpClipboard1.ObservableFormats.Images;
        }


       

        private void sharpClipboard1_MonitorClipboardChanged(object sender, EventArgs e)
        {
            chkMonitorClipboard.Checked = sharpClipboard1.MonitorClipboard;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sharpClipboard1.MonitorClipboard = chkMonitorClipboard.Checked;
        }

        private void chkObserveTexts_CheckedChanged(object sender, EventArgs e)
        {
            sharpClipboard1.ObservableFormats.Texts = chkObserveTexts.Checked;
        }

        private void chkObserveImages_CheckedChanged(object sender, EventArgs e)
        {
            sharpClipboard1.ObservableFormats.Images = chkObserveImages.Checked;
        }

        private void chkObserveFiles_CheckedChanged(object sender, EventArgs e)
        {
            sharpClipboard1.ObservableFormats.Files = chkObserveFiles.Checked;
        }

        private void sharpClipboard1_ClipboardChanged(object sender, SharpClipboard.ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text)
            {
                txtCopiedTexts.Text = sharpClipboard1.ClipboardText;            
            }
            else if (e.ContentType == SharpClipboard.ContentTypes.Image)
            {
                pbCopiedImage.Image = sharpClipboard1.ClipboardImage;
            }
            else if (e.ContentType == SharpClipboard.ContentTypes.Files)
            {             
                List<string> files = new List<string>();             
                foreach (string file in sharpClipboard1.ClipboardFiles)
                {
                    files.Add(Path.GetFileName(file));
                }

                Debug.WriteLine(sharpClipboard1.ClipboardFiles.ToArray());
            
                lstCopiedFiles.Items.Clear();
                lstCopiedFiles.Items.AddRange(files.ToArray());              
            }
            else if (e.ContentType == SharpClipboard.ContentTypes.Other)
            {              
                txtCopiedTexts.Text = sharpClipboard1.ClipboardText?.ToString();
            }

            
            textBox2.Text =
                $"Name: {e.SourceApplication.Name} \n" +
                $"Title: {e.SourceApplication.Title} \n" +
                $"ID: {e.SourceApplication.ID} \n" +
                $"Handle: {e.SourceApplication.Handle} \n" +
                $"Path: {e.SourceApplication.Path}";
        
        }

    }
}
