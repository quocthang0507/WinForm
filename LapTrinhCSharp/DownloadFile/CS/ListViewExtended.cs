using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace SampleProject
{
	
	public class ListViewExtended : ListView
	{
		
		private ImageList StatusImageList = new ImageList();
		
		public ListViewExtended()
		{
            
			//// Set OwnerDraw to True, so we can draw the progressbar.
			this.OwnerDraw = true;
			
			//// The control flickers if it's continuously
			//// updated and not double-buffered.
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.DrawColumnHeader += Me_DrawColumnHeader;
            this.DrawItem += Me_DrawItem;
            this.DrawSubItem += Me_DrawSubItem;
           


            //// Configure the columns and such.
            this.View = View.Details;
            this.BackColor = Color.White;
            this.ShowItemToolTips = true;
            this.FullRowSelect = true;
            this.HideSelection = true;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
            this.Columns.Add("Filename", 225, HorizontalAlignment.Left);
			this.Columns.Add("Size", 80, HorizontalAlignment.Right);
			this.Columns.Add("Status", 125, HorizontalAlignment.Left);
			this.Columns.Add("Completed", 100, HorizontalAlignment.Right);
			this.Columns.Add("Progress", 125, HorizontalAlignment.Center);
			this.Columns.Add("Speed", 75, HorizontalAlignment.Right);
			this.Columns.Add("Time", 80, HorizontalAlignment.Left);
			this.Columns.Add("Time Left", 80, HorizontalAlignment.Left);

            //// Configure Imagelist and assign it to the Listview.
            StatusImageList.ColorDepth = ColorDepth.Depth32Bit;
            StatusImageList.ImageSize = new Size(16, 16);
            StatusImageList.Images.Add("Initializing", global::My.Resources.Resources.StatusInitializing);
            StatusImageList.Images.Add("Downloading", global::My.Resources.Resources.StatusDownload);
            StatusImageList.Images.Add("Paused", global::My.Resources.Resources.StatusPaused);
            StatusImageList.Images.Add("Finished", global::My.Resources.Resources.StatusFinished);
            StatusImageList.Images.Add("Error", global::My.Resources.Resources.StatusError);
            this.SmallImageList = StatusImageList;

        }
		
		//// Draw default ColumnHeader.
		private void Me_DrawColumnHeader(object sender, 
			DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}
		
		//// Draw default main item.
		private void Me_DrawItem(object sender, 
			DrawListViewItemEventArgs e)
		{
			e.DrawDefault = false;
		}
		
		//// Here we draw the progressbar in the 4th SubItem.
		private void Me_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			
			if (((int) (e.ItemState) & (int) ListViewItemStates.Selected) != 0)
			{
				//// Item is highlighted.
				e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
			}
			
			//// Draw the progressbar.
			if (e.ColumnIndex == 4)
			{
				//// Center the text in the progressbar.
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				//// Background color of the progressbar is white.
				e.Graphics.FillRectangle(Brushes.White, e.Bounds);
				//// Percentage of the progressbar to fill.
				int FillPercent = System.Convert.ToInt32(((double.Parse(e.SubItem.Text)) / 100) * (e.Bounds.Width - 2));
				//// This creates a nice gradient. From top (White) to bottom (Red).
				Brush brGradient = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.Red, Color.White, 270, true);
				//// Draw the actual progressbar.
				e.Graphics.FillRectangle(brGradient, e.Bounds.X + 1, e.Bounds.Y + 2, FillPercent, e.Bounds.Height - 3);
				//// Draw the percentage number and percent sign.
				//// NOTE: make sure that e.SubItem.Text only contains a number or an error will occur.
				e.Graphics.DrawString(e.SubItem.Text + " %", this.Font, Brushes.Black, (float) (e.Bounds.X + ((double) e.Bounds.Width / 2)), e.Bounds.Y + 3, sf);
				//// Draw a light gray rectangle/border around the progressbar.
				e.Graphics.DrawRectangle(Pens.LightGray, e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 2);
			}
			else
			{
				e.DrawDefault = true;
			}
		}
		
		public void StartDownload(string URL, string LocalFilePath)
		{
			DownloadFileAsyncExtended wClient = new DownloadFileAsyncExtended();
			
			//// Add some initial data to the Listview.
			ListViewItem lvw = this.Items.Add(Path.GetFileName(LocalFilePath));
			lvw.SubItems.Add("0 Bytes"); //// Total Size.
			lvw.SubItems.Add("Initializing..."); //// Status.
			lvw.SubItems.Add("0 Bytes"); //// Completed.
			lvw.SubItems.Add("0"); //// Progress Percentage. NOTE: Only add a number here, no letters/signs!
			lvw.SubItems.Add("0 kB/s"); //// Download Speed.
			lvw.SubItems.Add("00:00:00"); //// Download Time.
			lvw.SubItems.Add("00:00:00"); //// Remaining Time.
			lvw.ImageKey = "Initializing"; //// Initializing image.
			//// Store the DownloadFileAsyncExtended class instance in the Tag,
			//// so we can use it later to cancel/resume the download if necessary.
			lvw.Tag = wClient;
			
			//// Add Event handlers, so we can update the progress to the user.
			wClient.DownloadProgressChanged += DownloadProgressChanged;
			wClient.DownloadCompleted += DownloadCompleted;
			
			//// IMPORTANT !!
			//// If you don't add this line, then all events are raised on a separate
			//// thread and you will get cross-thread errors when accessing the Listview
			//// or other controls directly in the raised events.
			wClient.SynchronizingObject = this;
			
			//// Update frequency. You can select NoDelay, HalfSecond or Second.
			//// HalfSecond and Second will prevent the DownloadProgressChanged event
			//// from firing continuously and hogging CPU when updating the controls.
			//// If you download small files that could be downloaded within a second,
			//// then set it to NoDelay or the progress might not be visible.
			wClient.ProgressUpdateFrequency = DownloadFileAsyncExtended.UpdateFrequency.Second;
			
			//// The method to actually download a file. The userToken parameter can
			//// for example be a control you wish to update in the DownloadProgressChanged
			//// and DownloadCompleted events. A ListViewItem in this example.
			wClient.DowloadFileAsync(URL, LocalFilePath, lvw);
			
			//// Set wClient to Nothing, because we don't need it anymore. Free storage
			wClient = null;
		}
		
		//// This event allows you to show the download progress to the user.
		
		//// e.BytesReceived = Bytes received so far.
		//// e.DownloadSpeedBytesPerSec = Download speed in bytes per second.
		//// e.DownloadTimeSeconds = Download time in seconds so far.
		//// e.ProgressPercentage = Percentage of the file downloaded.
		//// e.RemainingTimeSeconds = Remaining download time in seconds.
		//// e.TotalBytesToReceive = Total size of the file that is being downloaded.
		//// e.userToken = Usually the control(s) you wish to update.
		private void DownloadProgressChanged(object sender, FileDownloadProgressChangedEventArgs e)
		{
			//// Get the ListViewItem we passed as userToken parameter, so we can update it.
			ListViewItem lvw = (ListViewItem) e.userToken;
			
			//// Update the ListView items.
			lvw.SubItems[1].Text = ConvertBytes(e.TotalBytesToReceive);
			lvw.SubItems[2].Text = "Downloading";
			lvw.SubItems[3].Text = ConvertBytes(e.BytesReceived);
			lvw.SubItems[4].Text = System.Convert.ToString(e.ProgressPercentage);
			lvw.SubItems[5].Text = (e.DownloadSpeedBytesPerSec / 1024).ToString() + " kB/s";
			lvw.SubItems[6].Text = ConvertSeconds(e.DownloadTimeSeconds);
			lvw.SubItems[7].Text = ConvertSeconds(e.RemainingTimeSeconds);
			lvw.ImageKey = "Downloading";
		}
		
		//// This event lets you know when the download is complete. The download finished
		//// successfully, the user cancelled the download or there was an error.
		private void DownloadCompleted(object sender, FileDownloadCompletedEventArgs e)
		{
			//// Get the ListViewItem we passed as userToken parameter, so we can update it
			ListViewItem lvw = (ListViewItem) e.userToken;
			
			if (e.ErrorMessage != null) //// Was there an error.
			{
				lvw.SubItems[2].Text = e.ErrorMessage.Message.ToString();
				lvw.ImageKey = "Error";
				//// Set Tag to Nothing in order to remove the wClient class instance.
				//// This way we know we can't resume the download.
				lvw.Tag = null;
				
			}
			else if (e.Cancelled) //// The user cancelled the download.
			{
				lvw.SubItems[2].Text = "Paused";
				lvw.ImageKey = "Paused";
				
			}
			else //// Download was successful.
			{
				lvw.SubItems[2].Text = "Finished";
				lvw.ImageKey = "Finished";
				//// Set Tag to Nothing in order to remove the wClient class instance.
				//// This way we know we can't resume the download.
				lvw.Tag = null;
			}
			
			//// Reset Speed and Time values.
			lvw.SubItems[5].Text = "0 kB/s";
			lvw.SubItems[6].Text = ConvertSeconds(0);
			lvw.SubItems[7].Text = ConvertSeconds(0);
		}
		
		//// Convert seconds to hour:minute:seconds (00:00:00) format.
		private string ConvertSeconds(long Seconds)
		{
			if (Seconds <= 0)
			{
				Seconds = 0;
			}
			return string.Format("{0}:{1}:{2}", (Seconds / 3600).ToString("00"), ((Seconds % 3600) / 60).ToString("00"), (Seconds % 60).ToString("00"));
		}
		
		//// Convert Bytes to KiloBytes.
		private string ConvertBytes(long Bytes)
		{
			if (Bytes < 1024)
			{
				return "1 KB";
			}
			else
			{
				return string.Format("{0:#,#} KB", (double) Bytes / 1024);
			}
		}
	}
	
}
