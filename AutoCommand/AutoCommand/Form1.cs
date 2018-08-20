using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoCommand
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.RowHeadersVisible = false;
			ShowTooltip();
			//GetFont();
		}

		void ShowTooltip()
		{
			ToolTip toolTip1 = new ToolTip();
			toolTip1.AutoPopDelay = 5000;
			toolTip1.InitialDelay = 1000;
			toolTip1.ReshowDelay = 500;
			toolTip1.ShowAlways = true;
			toolTip1.SetToolTip(btn_Browse1, "Browse for file(s)");
			toolTip1.SetToolTip(btn_Start1, "Start rename all files");
			toolTip1.SetToolTip(btn_Browse2, "Browse for image folder");
			toolTip1.SetToolTip(btn_Start2, "Start add watermark to all pictures in folder");
			toolTip1.SetToolTip(label11, "View the history");
		}

		private void btn_Browse1_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Browse for one or more files";
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.Multiselect = true;
			openFileDialog1.Filter = "All files (*.*)|*.*";
			ShowSelectedfiles();
		}

		string ConvertFileLength(double len)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (len >= 1024 && order < sizes.Length - 1)
			{
				order++;
				len = len / 1024;
			}
			return string.Format("{0:0.##} {1}", len, sizes[order]);
		}

		void ShowSelectedfiles()
		{
			DialogResult r = openFileDialog1.ShowDialog();
			dataGridView1.Rows.Clear();
			object[] row = new object[5];
			if (r == DialogResult.OK)
			{
				int count = openFileDialog1.FileNames.Length;
				int step = 1 / count;
				progressBar1.Value = 0;
				foreach (var item in openFileDialog1.FileNames)
				{
					DateTime modification = File.GetLastWriteTime(item);
					string name = Path.GetFileName(item);
					row[0] = name;
					row[1] = name;
					row[2] = ConvertFileLength(new FileInfo(item).Length);
					row[3] = modification.ToString("yyyy/M/dd");
					row[4] = item.Replace(name, "");
					dataGridView1.Rows.Add(row);
					progressBar1.Value += step;
				}
				progressBar1.Value = 100;
			}
		}

		private void btn_Name_Click(object sender, EventArgs e)
		{
			tbx_fileName.Text += "[N]";
		}

		private void btn_Counter_Click(object sender, EventArgs e)
		{
			tbx_fileName.Text += "[C]";
		}

		private void btn_Time_Click(object sender, EventArgs e)
		{
			tbx_fileName.Text += "[T]";
		}

		private void btn_Range_Click(object sender, EventArgs e)
		{
			tbx_fileName.Text += "[N#-#]";
		}

		private void btn_Date_Click(object sender, EventArgs e)
		{
			tbx_fileName.Text += "[D]";
		}

		private void btn_eExtension_Click(object sender, EventArgs e)
		{
			tbx_Extension.Text += "[E]";
		}

		private void btn_eRange_Click(object sender, EventArgs e)
		{
			tbx_Extension.Text += "[E#-#]";
		}

		private void btn_eCounter_Click(object sender, EventArgs e)
		{
			tbx_Extension.Text += "[C]";
		}

		List<string> DecomposeMask(TextBox t)
		{
			List<string> mask = new List<string>();
			string pattern = "\\[.*?\\]|.";
			Regex rgx = new Regex(pattern);
			foreach (Match m in rgx.Matches(t.Text, 0))
				mask.Add(m.Value);
			return mask;
		}

		//The name without extension, and it is original name
		string NameProcessing(string name, int id, int count, int total, int digit)
		{
			List<string> mask = DecomposeMask(tbx_fileName);
			string n = "";
			if (mask.Count == 0)
				return n;
			else
				foreach (var item in mask)
				{
					string path = string.Concat(dataGridView1.Rows[id].Cells[4].Value, dataGridView1.Rows[id].Cells[0].Value);
					DateTime modification = File.GetLastWriteTime(path);
					switch (item)
					{
						case "[N]":
							n += name;
							break;
						case "[C]":
							n += count.ToString("D" + digit);
							break;
						case "[T]":
							n += modification.ToString("hhmmss");
							break;
						case "[N#-#]":
							n += string.Concat(name, id + 1, "-", total - 1);
							break;
						case "[D]":
							n += modification.ToString("yyyyMdd");
							break;
						default:
							n += item;
							break;
					}
				}
			return n;
		}

		string ExtProcessing(string ext, int id, int count, int total, int digit)
		{
			List<string> mask = DecomposeMask(tbx_Extension);
			string e = "";
			if (mask.Count == 0)
				return e;
			else
				foreach (var item in mask)
				{
					switch (item)
					{
						case "[C]":
							e += count.ToString("D" + digit);
							break;
						case "[E]":
							e += ext;
							break;
						case "[E#-#]":
							e += string.Concat(ext, id + 1, "-", total - 1);
							break;
						default:
							e += item;
							break;
					}
				}
			return e;
		}

		private void tbx_fileName_TextChanged(object sender, EventArgs e)
		{
			int count = Convert.ToInt32(nud_Start.Value), id = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					string[] t = row.Cells[0].Value.ToString().Split('.');
					row.Cells[1].Value = string.Concat(NameProcessing(t[0], id, count, dataGridView1.RowCount, int.Parse(cbx_Digits.SelectedItem.ToString())), '.', t[1]);
					count += Convert.ToInt32(nud_Step.Value);
					id++;
				}
			}
		}

		private void tbx_Extension_TextChanged(object sender, EventArgs e)
		{
			int count = Convert.ToInt32(nud_Start.Value), id = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					string[] t = row.Cells[0].Value.ToString().Split('.');
					row.Cells[1].Value = string.Concat(t[0], '.', ExtProcessing(t[1], id, count, dataGridView1.RowCount, int.Parse(cbx_Digits.SelectedItem.ToString())));
					count += Convert.ToInt32(nud_Step.Value);
					id++;
				}
			}
		}

		List<string> backup;

		void BackupName()
		{
			backup = new List<string>();
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					backup.Add(row.Cells[1].Value.ToString());
				}
			}
		}

		void RestoreName()
		{
			int i = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					row.Cells[1].Value = backup[i];
					i++;
				}
			}
		}

		private void cbx_Case_SelectedValueChanged(object sender, EventArgs e)
		{
			BackupName();
			int i = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					if (cbx_Case.SelectedIndex == 0)
						row.Cells[1].Value = backup[i];
					else if (cbx_Case.SelectedIndex == 1)
						row.Cells[1].Value = backup[i].ToLower();
					else if (cbx_Case.SelectedIndex == 2)
						row.Cells[1].Value = backup[i].ToUpper();
					else if (cbx_Case.SelectedIndex == 3)
						row.Cells[1].Value = char.ToUpper(backup[i].First()) + backup[i].Substring(1).ToLower();
					else
					{
						TextInfo t = new CultureInfo("en-US", false).TextInfo;
						row.Cells[1].Value = t.ToTitleCase(backup[i]);
					}
				}
				i++;
			}
		}

		private void tbx_Extension_Click(object sender, EventArgs e)
		{
			tbx_Extension.SelectAll();
		}

		private void tbx_fileName_Click(object sender, EventArgs e)
		{
			tbx_fileName.SelectAll();
		}

		private void tbx_Find_TextChanged(object sender, EventArgs e)
		{
			if (tbx_Find.Text != "")
			{
				BackupName();
				int i = 0;
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						row.Cells[1].Value = backup[i].Replace(tbx_Find.Text, tbx_Replace.Text);
						i++;
					}
				}
			}
			else RestoreName();
		}

		private void tbx_Replace_TextChanged(object sender, EventArgs e)
		{
			if (tbx_Replace.Text != null)
			{
				int i = 0;
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						row.Cells[1].Value = backup[i].Replace(tbx_Find.Text, tbx_Replace.Text);
						i++;
					}
				}
			}
		}

		private void btn_Start1_Click(object sender, EventArgs e)
		{
			int count = dataGridView1.Rows.Count - 1;
			int step = 1 / count;
			progressBar1.Value = 0;
			StreamWriter sw = new StreamWriter("log.txt", true);
			sw.WriteLine(DateTime.Now.ToString());
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					string oldPath = string.Concat(row.Cells[4].Value, row.Cells[0].Value);
					string newPath = string.Concat(row.Cells[4].Value, row.Cells[1].Value);
					File.Move(oldPath, newPath);
					sw.WriteLine(string.Concat("\"", oldPath, "\" -> \"", newPath, "\""));
					row.Cells[0].Value = row.Cells[1].Value;
					progressBar1.Value += step;
				}
			}
			progressBar1.Value = 100;
			sw.Close();
		}

		private void label11_MouseHover(object sender, EventArgs e)
		{
			label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point, ((byte)(163)));
		}

		private void label11_MouseLeave(object sender, EventArgs e)
		{
			label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(163)));
		}

		private void listFont_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.Graphics.DrawString(listFont.Items[e.Index].ToString(), new Font(listFont.Items[e.Index].ToString(), 20), Brushes.Black, e.Bounds);
		}

		private void btn_Start2_Click(object sender, EventArgs e)
		{
			Image img = null;
			string path = tbx_Path2.Text;
			string fullPath = string.Empty;
			try
			{
				string[] imgExtension = { "*.jpg", "*.jpeg", ".gif", "*.bmp" };
				List<FileInfo> files = new List<FileInfo>();
				DirectoryInfo dir = new DirectoryInfo(path);
				foreach (string ext in imgExtension)
				{
					FileInfo[] folder = dir.GetFiles(ext, SearchOption.AllDirectories);
					foreach (FileInfo file in folder)
					{
						FileStream fs = file.OpenRead();
						fullPath = path + @"\" + file.Name;
						Stream outputStream = new MemoryStream();
						//AddWaterMark.AddWatermark(fs, text, outputStream);
						fs.Close();
						file.Delete();
						img = Image.FromStream(outputStream);

						using (Bitmap savingImage = new Bitmap(img.Width, img.Height, img.PixelFormat))
						{
							using (Graphics g = Graphics.FromImage(savingImage))
								g.DrawImage(img, new Point(0, 0));
							savingImage.Save(fullPath, ImageFormat.Jpeg);
						}
						img.Dispose();
					}
				}
				MessageBox.Show("Processing Completed");
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error during processing..");
			}
			finally
			{
				if (img != null)
					img.Dispose();
			}
		}

		void GetFont()
		{
			listFont.ItemHeight = 30;
			using (InstalledFontCollection col = new InstalledFontCollection())
			{
				foreach (FontFamily fa in col.Families)
					listFont.Items.Add(fa.Name);
				listFont.DrawMode = DrawMode.OwnerDrawFixed;
			}
		}

		private void btn_Browse2_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.Description = "Browse for image folder";
			folderBrowserDialog1.ShowNewFolderButton = false;
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
				tbx_Path2.Text = folderBrowserDialog1.SelectedPath;
			else tbx_Path2.Text = null;
		}

		private void label11_Click(object sender, EventArgs e)
		{
			Process.Start("log.txt");
		}
	}
}
