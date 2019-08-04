using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using OMR;
using OMR.Forms;
using OMR.XML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OMRReader_test1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			filenamet.Text = OMR.RegistryEditor.ReadReg(this.Name, filenamet.Name).ToString();

			if (Convert.ToBoolean(OMR.RegistryEditor.ReadReg(this.Name, loadLast_cb.Name)))
			{
				panel1.BackgroundImage = System.Drawing.Image.FromFile("Lastimg.jpg");
				loadLast_cb.Checked = Convert.ToBoolean(OMR.RegistryEditor.ReadReg(this.Name, loadLast_cb.Name));
			}
		}

		private bool isSame(UnmanagedImage img1, UnmanagedImage img2)
		{
			int count = 0, tcount = img2.Width * img2.Height;
			for (int y = 0; y < img1.Height; y++)
				for (int x = 0; x < img1.Width; x++)
				{
					Color c1 = img1.GetPixel(x, y), c2 = img2.GetPixel(x, y);
					if ((c1.R + c1.G + c1.B) / 3 > (c2.R + c2.G + c2.B) / 3 - 10 &&
						(c1.R + c1.G + c1.B) / 3 < (c2.R + c2.G + c2.B) / 3 + 10)
						count++;
				}
			return (count * 100) / tcount >= 50;
		}
		TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
		private void showTimeStamp(string str)
		{
			textBox1.AppendText(str + ": " + (new TimeSpan(DateTime.Now.Ticks) - ts).TotalSeconds + "\r\n");
			ts = new TimeSpan(DateTime.Now.Ticks);
		}
		private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
		{
			System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

			for (int i = 0, n = points.Count; i < n; i++)
			{
				array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
			}

			return array;
		}
		private List<System.Drawing.Point> afPointListToSystem(List<IntPoint> points)
		{
			List<System.Drawing.Point> list_ = new List<System.Drawing.Point>();

			for (int i = 0, n = points.Count; i < n; i++)
			{
				list_.Add(new System.Drawing.Point(points[i].X, points[i].Y));
			}

			return list_;
		}


		private void filenamet_TextChanged(object sender, EventArgs e)
		{
			OMR.RegistryEditor.WriteRegStr(this.Name, filenamet.Name, filenamet.Text);
		}


		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			OMR.RegistryEditor.WriteRegStr(this.Name, loadLast_cb.Name, loadLast_cb.Checked);
			loadLast_cb.Checked = loadLast_cb.Checked ? !(loadLast_cb.Checked && panel1.BackgroundImage == null) : false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OMRSheetSpecsWriter.WriteSheetsToFile("sheets.xml");
		}

		private void button3_Click(object sender, EventArgs e)
		{
		}

		private void button5_Click(object sender, EventArgs e)
		{
			ts = new TimeSpan(DateTime.Now.Ticks);
			textBox1.Text = "";
			showTimeStamp("Process Started");
			if (!loadLast_cb.Checked)
				panel1.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
			showTimeStamp("Image Read");
			panel1.BackgroundImage = (System.Drawing.Image)ImageUtilities.ResizeImage((Bitmap)panel1.BackgroundImage, 2100, 2100 * panel1.BackgroundImage.Height / panel1.BackgroundImage.Width);
			panel1.Invalidate();
			Application.DoEvents();
			showTimeStamp("Resized");
			Application.DoEvents();
			Bitmap unf = new Bitmap(panel1.BackgroundImage);
			OpticalReader reader = new OpticalReader();
			panel1.BackgroundImage = (System.Drawing.Image)reader.ExtractOMRSheet(unf, "sheets.xml", ref panel1, ref textBox1, OMREnums.OMRSheet.A555);
			//panel1.BackgroundImage = (System.Drawing.Image)ExtractOMRSheet(unf, fill_tb.Value, con_tb.Value, "A540.omr");
			showTimeStamp("OMR Extraction Finished");
			panel1.Invalidate();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			ts = new TimeSpan(DateTime.Now.Ticks);
			textBox1.Text = "";
			showTimeStamp("Process Started");
			if (!loadLast_cb.Checked)
				panel1.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
			showTimeStamp("Image Read");
			panel1.BackgroundImage = (System.Drawing.Image)ImageUtilities.ResizeImage((Bitmap)panel1.BackgroundImage, 2100, 2100 * panel1.BackgroundImage.Height / panel1.BackgroundImage.Width);
			panel1.Invalidate();
			Application.DoEvents();
			showTimeStamp("Resized");
			Application.DoEvents();
			Bitmap unf = new Bitmap(panel1.BackgroundImage);
			OpticalReader reader = new OpticalReader();
			panel1.BackgroundImage = (System.Drawing.Image)reader.ExtractOMRSheet(unf, "sheets.xml", ref panel1, ref textBox1, OMREnums.OMRSheet.A550);
			showTimeStamp("OMR Extraction Finished");
			panel1.Invalidate();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//ContrastCorrection cc = new ContrastCorrection();
			//panel1.BackgroundImage = cc.Apply((Bitmap)panel1.BackgroundImage);
			panel1.Invalidate(); Application.DoEvents();
			showTimeStamp("Slicing Started");
			Rectangle[] Blocks = new Rectangle[]
			{
				OMRSheetReader.GetSheetPropertyLocation("sheets", OMREnums.OMRSheet.A550, OMREnums.OMRProperty.tensBlock1),
				OMRSheetReader.GetSheetPropertyLocation("sheets", OMREnums.OMRSheet.A550, OMREnums.OMRProperty.tensBlock2),
				OMRSheetReader.GetSheetPropertyLocation("sheets", OMREnums.OMRSheet.A550, OMREnums.OMRProperty.tensBlock3),
				OMRSheetReader.GetSheetPropertyLocation("sheets", OMREnums.OMRSheet.A550, OMREnums.OMRProperty.tensBlock4)
			};

			List<Bitmap[]> bmps = new List<Bitmap[]>();
			for (int i = 0; i < 4; i++)
			{
				bmps.Add(SliceOMarkBlock(panel1.BackgroundImage, Blocks[i], 10));
			}
			showTimeStamp("Slicing ended");

			string ans = "";
			foreach (Bitmap[] blk in bmps)
			{
				foreach (Bitmap line in blk)
				{
					ans += rateSlice(line, 5) + ",";
				}
				ans += "\r\n";
			}

			panel1.Invalidate();
			Application.DoEvents();
			MessageBox.Show(ans);

		}
		private int rateSlice(Bitmap slice, int OMCount)
		{
			Rectangle[] cropRects = new Rectangle[OMCount];
			Bitmap[] marks = new Bitmap[OMCount];
			for (int i = 0; i < OMCount; i++)
			{
				cropRects[i] = new Rectangle(i * slice.Width / OMCount, 0, slice.Width / OMCount, slice.Height);
			}

			int crsr = 0;
			foreach (Rectangle cropRect in cropRects)
			{
				Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

				using (Graphics g = Graphics.FromImage(target))
				{
					g.DrawImage(slice, new Rectangle(0, 0, target.Width, target.Height),
									 cropRect,
									 GraphicsUnit.Pixel);
				}
				marks[crsr] = target;
				crsr++;
			}
			long maxPD = (slice.Width / OMCount) * slice.Height * 255;
			List<long> inks = new List<long>();
			List<long> fullInks = new List<long>();

			foreach (Bitmap mark in marks)
			{
				inks.Add(InkDarkness(mark));
				fullInks.Add(inks[inks.Count - 1]);
			}
			int indofMx = -1, indofMn = -1;
			long maxD = 0, minD = 0; ;
			for (int i = 0; i < OMCount; i++)
			{
				if (inks[i] > maxD)
				{
					maxD = inks[i];
					indofMx = i;
				}
			}
			minD = maxD;
			for (int i = 0; i < OMCount; i++)
			{
				if (inks[i] < minD)
				{
					minD = inks[i];
					indofMn = i;
				}
			}
			for (int i = 0; i < OMCount; i++)
			{
				inks[i] -= minD - 1;
			}
			bool parallelExist = false, spe = false, tpe = false, fpe = false;
			for (int i = 0; i < OMCount; i++)
			{
				if (i != indofMx)
				{
					if ((double)fullInks[indofMx] / fullInks[i] <= 2)
					{
						if (tpe) fpe = true;
						if (spe) tpe = true;
						if (parallelExist) spe = true;
						parallelExist = true;
					}
				}
			}
			int negScore = parallelExist ? -1 : 0;
			negScore = spe ? -2 : negScore;
			negScore = tpe ? -3 : negScore;
			negScore = fpe ? -4 : negScore;

			if (!parallelExist)
				return indofMx + 1;
			bool atleastOneUnfilled = false;
			for (int i = 0; i < OMCount; i++)
			{
				if (i != indofMx)
				{
					if ((double)fullInks[indofMx] / fullInks[i] >= 3)
						atleastOneUnfilled = true;
				}
			}
			if (atleastOneUnfilled)
				return negScore;


			return 0;
		}
		private long InkDarkness(Bitmap OMark)
		{
			int darkestC = 255, lightestC = 0;

			UnmanagedImage mark = UnmanagedImage.FromManagedImage(OMark);
			for (int y = 0; y < OMark.Height; y++)
				for (int x = 0; x < OMark.Width; x++)
				{
					Color c = mark.GetPixel(x, y);
					if (((c.R + c.G + c.B) / 3) > lightestC)
					{
						lightestC = ((c.R + c.G + c.B) / 3);
					}
					if (((c.R + c.G + c.B) / 3) < darkestC)
					{
						darkestC = ((c.R + c.G + c.B) / 3);
					}
				}
			int dc = 0;
			for (int y = 0; y < OMark.Height; y++)
				for (int x = 0; x < OMark.Width; x++)
				{
					Color c = mark.GetPixel(x, y);

					if (((c.R + c.G + c.B) / 3) < (lightestC + darkestC) / 2)
					{ dc += 255; }
				}
			return dc;
		}
		private Bitmap[] SliceOMarkBlock(System.Drawing.Image fullSheet, Rectangle slicer, int slices)
		{
			List<Rectangle> cropRects = new List<Rectangle>();
			Bitmap[] bmps = new Bitmap[slices];
			for (int i = 0; i < slices; i++)
			{
				cropRects.Add(new Rectangle(slicer.X, slicer.Y + (slicer.Height / slices) * i, slicer.Width, slicer.Height / slices));
			}
			Bitmap src = (Bitmap)fullSheet;
			int crsr = 0;
			foreach (Rectangle cropRect in cropRects)
			{
				Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

				using (Graphics g = Graphics.FromImage(target))
				{
					g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
									 cropRect,
									 GraphicsUnit.Pixel);
				}
				bmps[crsr] = target;
				crsr++;
			}
			return bmps;
			throw new Exception("Couldn't slice");
		}

		private void button8_Click(object sender, EventArgs e)
		{
			OpticalReader rr = new OpticalReader();
			MessageBox.Show("Found registration number: " + rr.getRegNumOfSheet(panel1.BackgroundImage, OMREnums.OMRSheet.A550, "sheets.xml", false).ToString());
		}

		private void button9_Click(object sender, EventArgs e)
		{
			answerKeyDesigner rrf = new answerKeyDesigner();
			rrf.StartPosition = FormStartPosition.CenterParent;
			rrf.ShowDialog(this);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			OpticalReader reader = new OpticalReader();
			panel1.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
			panel2.BackgroundImage = ImageUtilities.drawHistogram(ImageUtilities.histogram(panel1.BackgroundImage));

			panel3.BackgroundImage = ImageUtilities.drawSmoothHistogramWithMaximas(panel1.BackgroundImage);
			panel1.BackgroundImage = reader.prepareForObjectDetection(new Bitmap(panel1.BackgroundImage));
		}

		private void button10_Click(object sender, EventArgs e)
		{
			panel1.BackgroundImage = System.Drawing.Image.FromFile(filenamet.Text);
			panel2.BackgroundImage = ImageUtilities.drawHistogram(ImageUtilities.histogram(panel1.BackgroundImage));
			panel3.BackgroundImage = ImageUtilities.drawSmoothHistogramWithMaximas(panel1.BackgroundImage);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Bitmap bitmap = new Bitmap(panel1.BackgroundImage);
			BitmapData bitmapData = bitmap.LockBits(
				new Rectangle(0, 0, bitmap.Width, bitmap.Height),
				ImageLockMode.ReadWrite, bitmap.PixelFormat);

			// step 2 - locating objects
			BlobCounter blobCounter = new BlobCounter();
			int minBlobWidHei = (int)(0.001 * bitmap.Width);
			blobCounter.FilterBlobs = true;
			blobCounter.MinHeight = minBlobWidHei;  // both these variables have to be given when calling the
			blobCounter.MinWidth = minBlobWidHei;   // method, this can also be queried from the XML reader using OMREnums

			blobCounter.BackgroundThreshold = Color.FromArgb(10, 10, 10);
			blobCounter.ProcessImage(bitmapData);
			Blob[] blobInfo = blobCounter.GetObjectsInformation();
			bitmap.UnlockBits(bitmapData);
			Blob[] blobObs = blobCounter.GetObjects(bitmap, false);
			Rectangle[] blobRects = blobCounter.GetObjectsRectangles();

			Graphics g = Graphics.FromImage(bitmap);
			Pen yellowPen = new Pen(Color.Yellow, 2);   // create pen in case image extraction failes and we need to preview the
														//blobs that were detected

			Pen redPen = new Pen(Color.Red, 2);   // create pen in case image extraction failes and we need to preview the
												  //blobs that were not detected


			foreach (Rectangle rec in blobRects)
			{
				g.DrawRectangle(yellowPen, rec);
			}

			panel1.BackgroundImage = bitmap;
		}

		private void button5_Click_1(object sender, EventArgs e)
		{

			AForge.Math.Geometry.SimpleShapeChecker sc = new SimpleShapeChecker();
			AForge.Imaging.Filters.Edges edg = new Edges();
			UnmanagedImage source = UnmanagedImage.FromManagedImage((Bitmap)panel1.BackgroundImage);
			UnmanagedImage destination = UnmanagedImage.FromManagedImage(new Bitmap(panel1.BackgroundImage.Width, panel1.BackgroundImage.Height));
			panel1.BackgroundImage = edg.Apply((Bitmap)panel1.BackgroundImage);


		}
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
