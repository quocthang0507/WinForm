// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.IO;
using System.Text.RegularExpressions;
using SampleProject;

namespace SampleProject
{
	
	//// Select the 'URL', 'Filename' and 'Save to' folder.
	//// No real error checking has been added.
	public partial class FormNewDownload
	{
		public FormNewDownload()
		{
			InitializeComponent();
		}
		
		public void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
		
		public void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		
		public void btnBrowse_Click(System.Object sender, System.EventArgs e)
		{
			//// Select a new download folder
			FBDialog.Description = "Select download folder:";
			FBDialog.ShowDialog();
			if (FBDialog.SelectedPath != string.Empty)
			{
				TextBoxBrowse.Text = FBDialog.SelectedPath + ((FBDialog.SelectedPath.EndsWith("\\")) ? "" : "\\");
			}
		}
		
		//// Return filename from the url. Remove illegal characters.
		private string ExtractFileNameFromURL(string URL)
		{
			try
			{
				string FixedURL = Regex.Replace(URL.Substring(URL.LastIndexOf("/") + 1), "[^a-zA-Z0-9!@$%^&*()_+=[\\]{}';,.-]", string.Empty);
				return FixedURL;
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}
		
		public void FormAdd_Load(System.Object sender, System.EventArgs e)
		{
			//// Set initial download folder to the 'Application StartupPath' folder
			TextBoxBrowse.Text = Application.StartupPath + ((Application.StartupPath.EndsWith("\\")) ? "" : "\\");
			
			//// See if there's an URL loaded in the clipboard and show it.
			if (Clipboard.ContainsText() == false)
			{
				return ;
			}
			try
			{
				Uri fileUri = new Uri(Clipboard.GetText());
				if (fileUri.Scheme == Uri.UriSchemeHttp || fileUri.Scheme == Uri.UriSchemeHttps)
				{
					TextBoxURL.Text = Clipboard.GetText();
					TextBoxFilename.Text = ExtractFileNameFromURL(Clipboard.GetText());
				}
			}
			catch
			{
			}
		}
	}
}
