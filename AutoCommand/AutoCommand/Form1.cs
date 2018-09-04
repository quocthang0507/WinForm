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
		string path1 = "log.txt", path2 = "backup.txt";
		bool canReplace = true;
		bool tiengViet = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tiengViet = false;
			tabPage2.Text = "Multi-Watermark Tool";
			groupBox6.Text = "Preview";
			label6.Text = "Text:";
			label7.Text = "Path:";
			label8.Text = "Font:";
			label9.Text = "Size:";
			label10.Text = "Font style:";
			btn_Start2.Text = "Start";
			label12.Text = "Position:";
			label15.Text = "Color:";
			btn_ChoosenColor.Text = "Choose...";
			btn_Review.Text = "Preview";
			tabPage1.Text = "Multi-Rename Tool";
			groupBox1.Text = "Rename mask: File name";
			chk_Diacritical.Text = "Remove diacritical marks";
			groupBox2.Text = "Extension";
			groupBox3.Text = "Find and Replace";
			label1.Text = "Find:";
			label2.Text = "Replace with:";
			groupBox4.Text = "Change case";
			label3.Text = "Start at:";
			label4.Text = "Step by:";
			label5.Text = "Digits:";
			Col_Location.HeaderText = "Location";
			Col_Date.HeaderText = "Date modification";
			Size.HeaderText = "Size";
			Col_NewName.HeaderText = "New name";
			Col_OldName.HeaderText = "Old name";
			btn_Start1.Text = "Start";
			btn_Browse1.Text = "Browse...";
			label11.Text = "View log";
			label16.Text = "Backup";
			ShowTooltip();
		}

		private void tiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tiengViet = true;
			tabPage2.Text = "Chèn ảnh mờ";
			groupBox6.Text = "Xem trước";
			label6.Text = "Chữ:";
			label7.Text = "Đdẫn:";
			label8.Text = "Phông:";
			label9.Text = "Cỡ:";
			label10.Text = "Kiểu:";
			btn_Start2.Text = "B.đầu";
			label12.Text = "Vị trí:";
			label15.Text = "Màu:";
			btn_ChoosenColor.Text = "Chọn...";
			btn_Review.Text = "Xem trước";
			tabPage1.Text = "Đổi tên";
			groupBox1.Text = "Mặt nạ: Tên";
			chk_Diacritical.Text = "Loại bỏ thanh điệu";
			groupBox2.Text = "Phần mở rộng";
			groupBox3.Text = "T.kiếm và T.thế";
			label1.Text = "Tìm:";
			label2.Text = "Thay bằng:";
			groupBox4.Text = "Đổi chữ hoa";
			label3.Text = "B.đầu tại:";
			label4.Text = "K.cách:";
			label5.Text = "T.phân:";
			Col_Location.HeaderText = "Vị trí";
			Col_Date.HeaderText = "Ngày chỉnh sửa";
			Col_NewName.HeaderText = "Tên mới";
			Size.HeaderText = "Cỡ";
			Col_OldName.HeaderText = "Tên cũ";
			btn_Start1.Text = "B.đầu";
			btn_Browse1.Text = "Duyệt...";
			label11.Text = "Xem n.ký";
			label16.Text = "Sao lưu";
			ShowTooltip();
		}

		private void aboutAuthorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("CHƯƠNG TRÌNH HỖ TRỢ ĐỔI TÊN ĐA TẬP TIN VÀ THÊM ẢNH MỜ (WATERMARK) VÀO ẢNH\r\nTác giả: LA QUỐC THẮNG\r\nChi tiết liên hệ: quocthang0507@gmail.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.RowHeadersVisible = false;
			ShowTooltip();
			GetFont();
		}

		void ShowTooltip()
		{
			ToolTip toolTip1 = new ToolTip();
			toolTip1.AutoPopDelay = 10000;
			toolTip1.InitialDelay = 1000;
			toolTip1.ReshowDelay = 500;
			toolTip1.ShowAlways = true;
			if (!tiengViet)
			{
				toolTip1.SetToolTip(btn_Browse1, "Browse for file(s)");
				toolTip1.SetToolTip(btn_Start1, "Start rename all files");
				toolTip1.SetToolTip(btn_Browse2, "Browse for image folder");
				toolTip1.SetToolTip(btn_Start2, "Start add watermark to all pictures in folder");
				toolTip1.SetToolTip(label11, "View the log");
				toolTip1.SetToolTip(label16, "Backup these file names and open file backup");
				toolTip1.SetToolTip(btn_Review, "Review the effectiveness of adding watermark to first image");
				toolTip1.SetToolTip(chk_Diacritical, "Remove diacritical marks if exists, such as ắ -> a, ươ -> uo, đ -> d,...");
			}
			else
			{
				toolTip1.SetToolTip(btn_Browse1, "Duyệt  đến (các) tập tin");
				toolTip1.SetToolTip(btn_Start1, "Thực thi việc đổi tên");
				toolTip1.SetToolTip(btn_Browse2, "Duyệt đến thư mục có chứa hình ảnh");
				toolTip1.SetToolTip(btn_Start2, "Thực thi việc chèn watermark vào các ảnh trong thư mục");
				toolTip1.SetToolTip(label11, "Xem nhật ký đổi tên");
				toolTip1.SetToolTip(label16, "Sao lưu tên tập tin và mở tập sao lưu");
				toolTip1.SetToolTip(btn_Review, "Xem trước sự ảnh hưởng của việc chèn watermark vào ảnh đầu tiên");
				toolTip1.SetToolTip(chk_Diacritical, "Loại bỏ các thanh điệu, ví dụ ắ -> a, ươ -> uo, đ -> d,...");
			}
		}

		#region Tab1
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

		private void btn_Browse1_Click(object sender, EventArgs e)
		{
			if (!tiengViet)
				openFileDialog1.Title = "Browse for one or more files";
			else openFileDialog1.Title = "Duyệt đến một hoặc nhiều tập tin";
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.Multiselect = true;
			if (!tiengViet)
				openFileDialog1.Filter = "All files (*.*)|*.*";
			else openFileDialog1.Filter = "Tất cả (*.*)|*.*";
			ShowSelectedfiles();
		}

		void Reset()
		{
			dataGridView1.Rows.Clear();
			tbx_fileName.Text = "[N]";
			tbx_Extension.Text = "[E]";
			tbx_Find.Text = "";
			tbx_Replace.Text = "";
			cbx_Case.SelectedIndex = 0;
			nud_Start.Value = 1;
			nud_Step.Value = 1;
			cbx_Digits.SelectedIndex = 0;
			chk_Diacritical.Checked = false;
		}

		void ShowSelectedfiles()
		{
			DialogResult r = openFileDialog1.ShowDialog();
			if (r == DialogResult.OK)
			{
				Reset();
				object[] row = new object[5];
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
					if (!tiengViet)
						row[3] = modification.ToString("yyyy/M/dd");
					else row[3] = modification.ToString("dd/M/yyyy");
					row[4] = item.Replace(name, "");
					dataGridView1.Rows.Add(row);
					progressBar1.Value += step;
				}
				path1 = dataGridView1.Rows[0].Cells[4].Value.ToString() + "log.txt";
				path2 = dataGridView1.Rows[0].Cells[4].Value.ToString() + "backup.txt";
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

		private void label11_Click(object sender, EventArgs e)
		{
			if (!File.Exists(path1))
				File.CreateText(path1);
			Process.Start(path1);
		}

		private void label16_Click(object sender, EventArgs e)
		{
			string[] names = openFileDialog1.FileNames;
			if (names[0] == "openFileDialog1")
				if (!tiengViet)
					MessageBox.Show("You have to firstly browse for file(s) ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else MessageBox.Show("Bạn phải duyệt tập tin trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				StreamWriter sw = new StreamWriter(path2, true);
				if (!tiengViet)
					sw.WriteLine(DateTime.Now.ToString("yyyy/M/dd"));
				else sw.WriteLine(DateTime.Now.ToString("dd/M/yyyy"));
				foreach (var item in names)
					sw.WriteLine(item);
				sw.WriteLine();
				sw.Close();
				Process.Start(path2);
			}
		}

		private void tbx_fileName_DoubleClick(object sender, EventArgs e)
		{
			tbx_fileName.SelectAll();
		}

		private void tbx_Extension_DoubleClick(object sender, EventArgs e)
		{
			tbx_Extension.SelectAll();
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
						case "[n]":
							n += name;
							break;
						case "[C]":
						case "[c]":
							n += count.ToString("D" + digit);
							break;
						case "[T]":
						case "[t]":
							n += modification.ToString("hhmmss");
							break;
						case "[N#-#]":
						case "[n#-#]":
							n += string.Concat(id + 1, "-", total - 1);
							break;
						case "[D]":
						case "[d]":
							if (!tiengViet)
								n += modification.ToString("yyyyMdd");
							else n += modification.ToString("ddMyyyy");
							break;
						default:
							n += item;
							break;
					}
					if (chk_Diacritical.Checked)
						n = Retitle(n);
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
						case "[c]":
							e += count.ToString("D" + digit);
							break;
						case "[E]":
						case "[e]":
							e += ext;
							break;
						case "[E#-#]":
						case "[e#-#]":
							e += string.Concat(id + 1, "-", total - 1);
							break;
						default:
							e += item;
							break;
					}
				}
			return e;
		}

		string[] SplitByDot(string text)
		{
			string[] r = new string[2];
			int i = text.LastIndexOf('.');
			r[0] = text.Remove(i);
			r[1] = text.Substring(i + 1);
			return r;
		}

		void MaskProcessing()
		{
			int count = Convert.ToInt32(nud_Start.Value), id = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value != null)
				{
					string[] t = SplitByDot(row.Cells[0].Value.ToString());
					string r = string.Concat(NameProcessing(t[0], id, count, dataGridView1.RowCount, int.Parse(cbx_Digits.SelectedItem.ToString())), '.', ExtProcessing(t[1], id, count, dataGridView1.RowCount, int.Parse(cbx_Digits.SelectedItem.ToString())));
					r = ChangeCase(r, cbx_Case.SelectedIndex);
					if (tbx_Find.Text != "" && canReplace)
					{
						t = SplitByDot(r);
						t[0] = t[0].Replace(tbx_Find.Text, tbx_Replace.Text);
						t[1] = t[1].Replace(tbx_Find.Text, tbx_Replace.Text);
						row.Cells[1].Value = string.Concat(t[0], ".", t[1]);
					}
					else row.Cells[1].Value = r;
					count += Convert.ToInt32(nud_Step.Value);
					id++;
				}
			}
		}

		private void tbx_fileName_TextChanged(object sender, EventArgs e)
		{
			MaskProcessing();
		}

		private void tbx_Extension_TextChanged(object sender, EventArgs e)
		{
			MaskProcessing();
		}

		void ReloadMask()
		{
			MaskProcessing();
		}

		string ChangeCase(string text, int id)
		{
			if (id == 0)
				return text;
			else if (id == 1)
				return text.ToLower();
			else if (id == 2)
				return text.ToUpper();
			else if (id == 3)
				return char.ToUpper(text.First()) + text.Substring(1).ToLower();
			else
			{
				TextInfo t = new CultureInfo("en-US", false).TextInfo;
				return t.ToTitleCase(text);
			}
		}

		string Retitle(string t)
		{
			var from = "àáảãạăằắẳẵặâầấẩẫậđèéẻẽẹêềếểễệìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵ·/_,:;";
			var to = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy------";
			var r = t;
			for (int i = 0, l = from.Length; i < l; i++)
				r = r.Replace(from[i].ToString(), to[i].ToString()).Replace(from[i].ToString().ToUpper(), to[i].ToString().ToUpper());
			return r;
		}

		private void cbx_Case_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cbx_Case.SelectedIndex == 0)
				ReloadMask();
			else
				foreach (DataGridViewRow row in dataGridView1.Rows)
					if (row.Cells[0].Value != null)
						row.Cells[1].Value = ChangeCase(row.Cells[1].Value.ToString(), cbx_Case.SelectedIndex);
		}

		private void tbx_Find_TextChanged(object sender, EventArgs e)
		{
			canReplace = false;
			ReloadMask();
			if (tbx_Find.Text != "")
			{
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						string[] t = SplitByDot(row.Cells[1].Value.ToString());
						t[0] = t[0].Replace(tbx_Find.Text, tbx_Replace.Text);
						t[1] = t[1].Replace(tbx_Find.Text, tbx_Replace.Text);
						row.Cells[1].Value = string.Concat(t[0], ".", t[1]);
					}
				}
			}
			canReplace = true;
		}

		private void tbx_Replace_TextChanged(object sender, EventArgs e)
		{
			if (tbx_Find.Text != "")
			{
				canReplace = false;
				ReloadMask();
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (row.Cells[0].Value != null)
					{
						string[] t = SplitByDot(row.Cells[1].Value.ToString());
						t[0] = t[0].Replace(tbx_Find.Text, tbx_Replace.Text);
						t[1] = t[1].Replace(tbx_Find.Text, tbx_Replace.Text);
						row.Cells[1].Value = string.Concat(t[0], ".", t[1]);
					}
				}
				canReplace = true;
			}
		}

		private void btn_Start1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.FileNames[0] == "openFileDialog1")
				if (!tiengViet)
					MessageBox.Show("Please firstly browse file(s). Then change the file name and file extenion. Finally press this button", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else MessageBox.Show("Đầu tiên duyệt đến các tập tin. Sau đó thay đổi tên và phần mở rộng. Cuối cùng mới nhấn nút này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				int count = dataGridView1.Rows.Count - 1;
				int step = 1 / count;
				progressBar1.Value = 0;
				StreamWriter sw = new StreamWriter(path1, true);
				sw.WriteLine(DateTime.Now.ToString());
				foreach (DataGridViewRow row in dataGridView1.Rows)
					if (row.Cells[0].Value != null)
					{
						string oldPath = string.Concat(row.Cells[4].Value, row.Cells[0].Value);
						string newPath = string.Concat(row.Cells[4].Value, row.Cells[1].Value);
						File.Move(oldPath, newPath);
						sw.WriteLine(string.Concat("\"", oldPath, "\" -> \"", newPath, "\""));
						row.Cells[0].Value = row.Cells[1].Value;
						progressBar1.Value += step;
					}
				progressBar1.Value = 100;
				sw.WriteLine();
				sw.Close();
			}
		}

		private void label11_MouseHover(object sender, EventArgs e)
		{
			label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point, ((byte)(163)));
		}

		private void label11_MouseLeave(object sender, EventArgs e)
		{
			label11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(163)));
		}

		private void label16_MouseHover(object sender, EventArgs e)
		{
			label16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point, ((byte)(163)));
		}

		private void label16_MouseLeave(object sender, EventArgs e)
		{
			label16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(163)));
		}

		private void nud_Start_ValueChanged(object sender, EventArgs e)
		{
			if (tbx_fileName.Text.Contains("[C]") || tbx_fileName.Text.Contains("[c]"))
				tbx_fileName_TextChanged(sender, e);
			if (tbx_Extension.Text.Contains("[C]") || tbx_fileName.Text.Contains("[c]"))
				tbx_Extension_TextChanged(sender, e);
		}

		private void nud_Step_ValueChanged(object sender, EventArgs e)
		{
			nud_Start_ValueChanged(sender, e);
		}

		private void cbx_Digits_SelectedIndexChanged(object sender, EventArgs e)
		{
			nud_Start_ValueChanged(sender, e);
		}

		private void tbx_fileName_KeyPress(object sender, KeyPressEventArgs e)
		{
			btn_Start1.PerformClick();
		}

		private void tbx_Extension_KeyPress(object sender, KeyPressEventArgs e)
		{
			btn_Start1.PerformClick();
		}

		private void chk_Diacritical_CheckedChanged(object sender, EventArgs e)
		{
			ReloadMask();
		}

		#endregion

		#region Tab2

		int GetFontStyle()
		{
			if (cbx_FontStyle.SelectedIndex == 0)
				return 0;
			else if (cbx_FontStyle.SelectedIndex == 1)
				return 1;
			else if (cbx_FontStyle.SelectedIndex == 2)
				return 2;
			else if (cbx_FontStyle.SelectedIndex == 4)
				return 4;
			else return 8;
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
				string[] imgExtension = { "*.jpg", "*.jpeg", ".gif", "*.bmp", "*.png" };
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
						AddWaterMark.AddWatermark(fs, int.Parse(tbx_PX.Text), int.Parse(tbx_PY.Text), tbx_Text.Text, outputStream, listFont.SelectedItem.ToString(), Convert.ToInt32(cbx_Size.Text), (FontStyle)GetFontStyle(), btn_ChoosenColor.BackColor);
						fs.Close();
						img = Image.FromStream(outputStream);
						using (Bitmap savingImage = new Bitmap(img.Width, img.Height, img.PixelFormat))
						{
							using (Graphics g = Graphics.FromImage(savingImage))
								g.DrawImage(img, new Point(0, 0));
							string[] t = file.Name.Split('.');
							savingImage.Save(string.Concat(path, @"\", t[0], "_new.", t[1]), ImageFormat.Jpeg);
						}
						img.Dispose();
					}
				}
				if (!tiengViet)
					MessageBox.Show("Processing Completed", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else MessageBox.Show("Xử lý xong", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				if (!tiengViet)
					MessageBox.Show("There was an error during processing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else MessageBox.Show("Có một lỗi trong quá trình xử lý", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			listFont.SelectedIndex = 0;
		}

		private void btn_Browse2_Click(object sender, EventArgs e)
		{
			if (!tiengViet)
				folderBrowserDialog1.Description = "Browse for image folder";
			else folderBrowserDialog1.Description = "Duyệt đến thư mục có chứa hình ảnh";
			folderBrowserDialog1.ShowNewFolderButton = false;
			ReviewPicture();
		}

		string GetTheFirstPic()
		{
			string[] files = Directory.GetFiles(tbx_Path2.Text);
			foreach (var item in files)
				if (item.ToLower().EndsWith(".jpg") || item.ToLower().EndsWith(".jpeg") ||
					item.ToLower().EndsWith(".gif") || item.ToLower().EndsWith(".bmp") ||
					item.ToLower().EndsWith(".png"))
					return item;
			return "";
		}

		void ReviewPicture()
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				tbx_Path2.Text = folderBrowserDialog1.SelectedPath;
				string r = GetTheFirstPic();
				if (r == "")
					if (!tiengViet)
						MessageBox.Show("Can't find any pictures on this folder", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					else MessageBox.Show("Không tìm thấy hình ảnh trong thư mục này", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					pbx_Before.Image = Image.FromFile(r);
			}
			else tbx_Path2.Text = "";
		}

		private void btn_ChoosenColor_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			btn_ChoosenColor.BackColor = colorDialog1.Color;
		}

		private void btn_Review_Click(object sender, EventArgs e)
		{
			string fullPath = GetTheFirstPic();
			FileInfo file = new FileInfo(fullPath);
			FileStream fs = file.OpenRead();
			Stream outputStream = new MemoryStream();
			AddWaterMark.AddWatermark(fs, int.Parse(tbx_PX.Text), int.Parse(tbx_PY.Text), tbx_Text.Text, outputStream, listFont.SelectedItem.ToString(), Convert.ToInt32(cbx_Size.Text), (FontStyle)GetFontStyle(), btn_ChoosenColor.BackColor);
			pbx_After.Image = Image.FromStream(outputStream);
			fs.Close();
		}
	}
	#endregion
}
