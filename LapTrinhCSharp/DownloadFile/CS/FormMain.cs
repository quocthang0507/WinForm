using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;


using System.IO;
using SampleProject;
using System.Drawing.Drawing2D;

namespace SampleProject
{
	
	public partial class FormMain
	{
		public FormMain()
		{
			InitializeComponent();
           
            //Added to support default instance behavour in C#
            if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FormMain defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static FormMain Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FormMain();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		
		public void FormMain_Load(System.Object sender, System.EventArgs e)
		{
			//// The DefaultConnectionLimit is 2, which means you can normally only do two
			//// simultaneous downloads. This code allows you to change the limit.
			System.Net.ServicePointManager.DefaultConnectionLimit = 5;
           
		}
		
		public void FormMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			for (int i = 0; i <= ListViewEx.Items.Count - 1; i++)
			{
				//// Check if the Tag isn't Nothing, because else the download has already
				//// finished or an error occurred, so it can't be cancelled.
				if (ListViewEx.Items[i].Tag != null)
				{
					//// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
					wClient = (DownloadFileAsyncExtended) (ListViewEx.Items[i].Tag);
					//// Cancel the download if it's still busy.
					wClient.CancelAsync();
				}
			}
		}
		
		public void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		
		public void AboutToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			MessageBox.Show("Sample Project for DownloadFileAsyncExtended", "Sample Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		
		public void btnAddNewDownload_Click(System.Object sender, System.EventArgs e)
		{

          
			string strURL = "";
			string strFileName = "";
			string strSavePath = "";
			
			using (FormNewDownload frm = new FormNewDownload())
			{
				//// Show Add New Download dialog and get result.
				if (frm.ShowDialog() == DialogResult.OK)
				{
					strURL = frm.TextBoxURL.Text.Trim();
					strFileName = frm.TextBoxFilename.Text.Trim();
					strSavePath = frm.TextBoxBrowse.Text.Trim();
					//// Start the download.
					ListViewEx.StartDownload(strURL, Path.Combine(strSavePath, strFileName));
				}
			}
			
		}
		
		public void ListViewEx_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point objDrawingPoint = new Point();
			ListViewItem objListViewItem = default(ListViewItem);
			
			objDrawingPoint = ListViewEx.PointToClient(Cursor.Position);
			
			//// Check to see if an item has been selected.
			if (!ReferenceEquals(objDrawingPoint, null))
			{
				objListViewItem = ListViewEx.GetItemAt(objDrawingPoint.X, objDrawingPoint.Y);
				
				//// If an item has been selected, then enable toolstrip buttons.
				if (!ReferenceEquals(objListViewItem, null))
				{
					btnResume.Enabled = true;
					btnPause.Enabled = true;
					btnRemove.Enabled = true;
				}
				else //// Else disable them.
				{
					btnResume.Enabled = false;
					btnPause.Enabled = false;
					btnRemove.Enabled = false;
				}
			}
		}
		
		public void btnResume_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			for (int i = 0; i <= ListViewEx.SelectedItems.Count - 1; i++)
			{
				if (ListViewEx.SelectedItems[i].Tag != null)
				{
					wClient = (DownloadFileAsyncExtended) (ListViewEx.SelectedItems[i].Tag);
					//// Make sure you check if the download is not
					//// already busy or an exception will be thrown.
					if (wClient.IsBusy == false)
					{
						wClient.ResumeAsync();
					}
				}
			}
		}
		
		public void btnResumeAll_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			for (int i = 0; i <= ListViewEx.Items.Count - 1; i++)
			{
				if (ListViewEx.Items[i].Tag != null)
				{
					wClient = (DownloadFileAsyncExtended) (ListViewEx.Items[i].Tag);
					//// Make sure you check if the download is not
					//// already busy or an exception will be thrown.
					if (wClient.IsBusy == false)
					{
						wClient.ResumeAsync();
					}
				}
			}
		}
		
		public void btnPause_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			for (int i = 0; i <= ListViewEx.SelectedItems.Count - 1; i++)
			{
				if (ListViewEx.SelectedItems[i].Tag != null)
				{
					wClient = (DownloadFileAsyncExtended) (ListViewEx.SelectedItems[i].Tag);
					//// Pause the download.
					wClient.CancelAsync();
				}
			}
		}
		
		public void btnPauseAll_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			for (int i = 0; i <= ListViewEx.Items.Count - 1; i++)
			{
				if (ListViewEx.Items[i].Tag != null)
				{
					wClient = (DownloadFileAsyncExtended) (ListViewEx.Items[i].Tag);
					//// Pause the download.
					wClient.CancelAsync();
				}
			}
		}
		
		public void btnRemove_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			//// Always loop backwards when removing items from the list,
			//// because the index gets updated when an item is removed.
			//// This can result in certain items not getting removed.
			for (int i = ListViewEx.SelectedItems.Count - 1; i >= 0; i--)
			{
				if (ListViewEx.SelectedItems[i].Tag != null)
				{
					//// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
					wClient = (DownloadFileAsyncExtended) (ListViewEx.SelectedItems[i].Tag);
					//// Pause (cancel) the download and remove it from the list.
					wClient.CancelAsync();
					ListViewEx.SelectedItems[i].Tag = null;
					ListViewEx.SelectedItems[i].Remove();
				}
				else
				{
					//// There's nothing to cancel, because the
					//// download has finished or caused an error.
					//// Just remove the item from the list.
					ListViewEx.SelectedItems[i].Remove();
				}
			}
		}
		
		public void btnRemoveAll_Click(System.Object sender, System.EventArgs e)
		{
			DownloadFileAsyncExtended wClient = default(DownloadFileAsyncExtended);
			
			//// Always loop backwards when removing items from the list,
			//// because the index gets updated when an item is removed.
			//// This can result in certain items not getting removed.
			for (int i = ListViewEx.Items.Count - 1; i >= 0; i--)
			{
				if (ListViewEx.Items[i].Tag != null)
				{
					//// Get the DownloadFileAsyncExtended class instance from the ListViewItem Tag.
					wClient = (DownloadFileAsyncExtended) (ListViewEx.Items[i].Tag);
					//// Pause (cancel) the download and remove it from the list.
					wClient.CancelAsync();
					ListViewEx.Items[i].Tag = null;
					ListViewEx.Items[i].Remove();
				}
				else
				{
					//// There's nothing to cancel, because the
					//// download has finished or caused an error.
					//// Just remove the item from the list.
					ListViewEx.Items[i].Remove();
				}
			}
		}

      
    }
	
}
