using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		System.Windows.Forms.Timer uiDecoupleTimer = new System.Windows.Forms.Timer();
		AutoResetEvent selectionChanged = new AutoResetEvent(false);
		AutoResetEvent itemsChanged = new AutoResetEvent(false);
		public Form1()
		{
			InitializeComponent();
			explorerBrowser.NavigationLog.NavigationLogChanged += new EventHandler<NavigationLogEventArgs>(NavigationLog_NavigationLogChanged);
			uiDecoupleTimer.Tick += new EventHandler(uiDecoupleTimer_Tick);

			explorerBrowser.ItemsChanged += new EventHandler(explorerBrowser_ItemsChanged);
			explorerBrowser.SelectionChanged += new EventHandler(explorerBrowser_SelectionChanged);

			uiDecoupleTimer.Interval = 100;
			uiDecoupleTimer.Start();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			explorerBrowser.Navigate((ShellObject)KnownFolders.Computer);
		}

		private void btn_back_Click(object sender, EventArgs e)
		{
			explorerBrowser.NavigateLogLocation(NavigationLogDirection.Backward);
		}

		void explorerBrowser_SelectionChanged(object sender, EventArgs e)
		{
			selectionChanged.Set();
		}

		void explorerBrowser_ItemsChanged(object sender, EventArgs e)
		{
			itemsChanged.Set();
			var a = explorerBrowser.NavigationLog.CurrentLocation.Properties;
		}

		private void btn_forward_Click(object sender, EventArgs e)
		{
			explorerBrowser.NavigateLogLocation(NavigationLogDirection.Forward);
		}
		public void NavigationLog_NavigationLogChanged(object sender, NavigationLogEventArgs args)
		{

			BeginInvoke(new MethodInvoker(delegate ()
			{
				if (args.CanNavigateBackwardChanged)
				{
					this.btn_back.Enabled = explorerBrowser.NavigationLog.CanNavigateBackward;
				}
				if (args.CanNavigateForwardChanged)
				{
					this.btn_forward.Enabled = explorerBrowser.NavigationLog.CanNavigateForward;
				}

				if (args.LocationsChanged)
				{

					foreach (ShellObject shobj in this.explorerBrowser.NavigationLog.Locations)
					{
						if (shobj.ParsingName.Contains(@"\"))
						{
							txt_location.Text = shobj.ParsingName;
						}
						else
						{
							txt_location.Text = shobj.Name;

						}
					}
				}

				if (this.explorerBrowser.NavigationLog.CurrentLocationIndex == -1)
					txt_location.Text = "";
				else
				{
					if (explorerBrowser.NavigationLog.CurrentLocation.ParsingName.Contains(@"\"))
					{
						txt_location.Text = explorerBrowser.NavigationLog.CurrentLocation.ParsingName;
					}
					else
					{
						txt_location.Text = explorerBrowser.NavigationLog.CurrentLocation.Name;

					}

				}

			}));
		}

		public void uiDecoupleTimer_Tick(object sender, EventArgs e)
		{
			if (selectionChanged.WaitOne(1))
			{
				StringBuilder itemsText = new StringBuilder();

				foreach (ShellObject item in explorerBrowser.SelectedItems)
				{
					if (item != null)
						itemsText.AppendLine(item.GetDisplayName(DisplayNameType.Default));
				}

				lbl_fileName_select.Text = itemsText.ToString();
				//this.itemsTabControl.TabPages[1].Text = "Selected Items (Count=" + explorerBrowser.SelectedItems.Count.ToString() + ")";
			}

			//if (itemsChanged.WaitOne(1))
			//{
			//    // update items text box
			//    StringBuilder itemsText = new StringBuilder();

			//    foreach (ShellObject item in explorerBrowser.Items)
			//    {
			//        if (item != null)
			//            itemsText.AppendLine("\tItem = " + item.GetDisplayName(DisplayNameType.Default));
			//    }

			//    this.lbl_fileName_select.Text = itemsText.ToString();
			//    //this.itemsTabControl.TabPages[0].Text = "Items (Count=" + explorerBrowser.Items.Count.ToString() + ")";
			//}
		}


		private void navigateButton_Click(object sender, EventArgs e)
		{
			//try
			//{
			//    // navigate to specific folder
			//    explorerBrowser.Navigate(ShellFileSystemFolder.FromFolderPath(pathEdit.Text));
			//}
			//catch (COMException)
			//{
			//    MessageBox.Show("Navigation not possible.");
			//}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://laptrinhvb.net");
		}
	}
}
