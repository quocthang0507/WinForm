using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Search
{
	public partial class Search : Form
	{
		public Search()
		{
			InitializeComponent();
			dgv_list.RowHeadersVisible = false;
		}

		private void Search_Load(object sender, EventArgs e)
		{
			splitContainer1.FixedPanel = FixedPanel.Panel1;
		}

		private void btn_open_Click(object sender, EventArgs e)
		{
			using (var dialog = new FolderBrowserDialog())
			{
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
				{
					tbx_location.Text = dialog.SelectedPath;
				}
			}
		}

		private void btn_load_Click(object sender, EventArgs e)
		{
			getListFolders(tbx_location.Text);
			getListFiles(tbx_location.Text);
		}

		private void getListFolders(string path)
		{
			DirectoryInfo directory = new DirectoryInfo(path);
			DirectoryInfo[] list = directory.GetDirectories();
			object[] row;
			foreach (var item in list)
			{
				row = new object[5];
				row[0] = item.Name;
				row[1] = "Folder";
				row[2] = item.FullName;
				row[3] = item.CreationTime;
				row[4] = convertUnit(getSizeDir(item.FullName));
				dgv_list.Rows.Add(row);
			}
		}

		private void getListFiles(string path)
		{
			DirectoryInfo directory = new DirectoryInfo(path);
			FileInfo[] list = directory.GetFiles();
			object[] row;
			foreach (var item in list)
			{
				row = new object[5];
				row[0] = item.Name;
				row[1] = "File";
				row[2] = item.FullName;
				row[3] = item.CreationTime;
				row[4] = convertUnit(item.Length);
				dgv_list.Rows.Add(row);
			}
		}

		private double getSizeDir(string path)
		{
			double size = 0;
			DirectoryInfo directory = new DirectoryInfo(path);
			DirectoryInfo[] subDirectory = directory.GetDirectories();
			var filter = subDirectory.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
			foreach (var item in filter)
			{
				size += getSizeDir(item.FullName);
			}
			size += directory.EnumerateFiles().Sum(f => f.Length);
			return size;
		}

		private string[] unit = { "B", "KB", "MB", "GB", "TB" };

		private string convertUnit(double size)
		{
			int order = 0;
			while (size >= 1024 && order < unit.Length - 1)
			{
				order++;
				size /= 1024;
			}
			return string.Format("{0:0.##} {1}", size, unit[order]);
		}
	}
}
