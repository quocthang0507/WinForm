using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OMR
{
	public class OpticalReader
	{
		TimeSpan ts = new TimeSpan();
		/// <summary>
		/// Extracts Images from smallSize CameraImage, No feed Back given during process
		/// </summary>
		/// <param name="SmallCameraImage"></param>
		/// <param name="OMRSpecsSheetAddress"></param>
		/// <returns>Formated, Right sized OMR Sheet</returns>
		public Bitmap ExtractOMRSheet(Bitmap SmallCameraImage, string OMRSpecsSheetAddress, XML.OMREnums.OMRSheet sheet)
		{
			Panel p = new Panel();
			TextBox t = new TextBox();
			t.Text = "";
			return ExtractOMRSheet(SmallCameraImage, OMRSpecsSheetAddress, ref p, ref t, false, sheet);
		}
		/// <summary>
		/// Extracts image and gives "In-Process" feebback on referenced panel and text box
		/// </summary>
		/// <param name="SmallCameraImage">any small image, as smaller as 3MP is recomended and enough clear. Bigger images take alot of time to be processed</param>
		/// <param name="OMRSpecsSheetAddress">XML sheet specification file</param>
		/// <param name="panel1"></param>
		/// <param name="textBox1"></param>
		/// <returns></returns>

		public Bitmap ExtractOMRSheet(Bitmap SmallCameraImage, string OMRSpecsSheetAddress, ref Panel panel1, ref TextBox textBox1, XML.OMREnums.OMRSheet sheet)
		{
			return ExtractOMRSheet(SmallCameraImage, OMRSpecsSheetAddress, ref panel1, ref textBox1, true, sheet);
		}
		private Bitmap ExtractOMRSheet(Bitmap basicImage, string OMRSpecsSheetAddress, ref Panel panel1, ref TextBox textBox1, bool giveFB, XML.OMREnums.OMRSheet sheet)
		{
			ts = new TimeSpan(DateTime.Now.Ticks);
			System.Drawing.Image flattened = (System.Drawing.Image)prepareForObjectDetection(basicImage);
			if (giveFB)
			{
				showTimeStamp("Flatting Started", ref textBox1);
				panel1.BackgroundImage = flattened;
				showTimeStamp("Flattened", ref textBox1);
				panel1.Invalidate();
				Application.DoEvents();
				showTimeStamp("OMR Extraction Started", ref textBox1);
			}
			return ExtractPaperFromPrepapred(new Bitmap(flattened), basicImage, OMRSpecsSheetAddress, ref textBox1, ref panel1, giveFB, sheet);
		}
		/// <summary>
		/// Detects, wrapps and crops out OMR sheet from flattened camera/scanner image.
		/// Flattened image is got by using method,  private Bitmap flatten(Bitmap bmp, int fillint, int contint);         
		/// </summary>
		/// <param name="bitmap">Bitmap image to process</param>
		/// <param name="basicImage">Backup image in case extraction fails</param>
		/// <param name="minBlobWidHei">Pre-configured variable, to be queried from XML reader</param>
		/// <param name="OMRSheets">Sheets XML File Address</param>
		/// <param name="tb">Textbox to give in'process details on</param>
		/// <param name="panel1">Panel to draw in-process changes on.</param>
		/// <param name="giveFB">True when In- Process Feedback is required.</param>
		/// <param name="sheet">Type of sheet from OMREnums</param>
		/// <returns>Cropped OMR sheet (if detected) from camera/scanner image.</returns>
		private Bitmap ExtractPaperFromPrepapred(Bitmap bitmap, Bitmap basicImage, string OMRSheets, ref TextBox tb, ref Panel panel1, bool giveFB, XML.OMREnums.OMRSheet sheet)
		{

			//first, use auto image prepration to convert to binary
			bitmap = prepareForObjectDetection(bitmap);

			return bitmap;
			if (giveFB)
			{
				panel1.BackgroundImage = bitmap;
				panel1.Invalidate();
			}
			// lock image, Bitmap itself takes much time to be processed
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

			Blob[] blobs = blobCounter.GetObjectsInformation();
			bitmap.UnlockBits(bitmapData);

			Graphics g = Graphics.FromImage(bitmap);
			Pen yellowPen = new Pen(Color.Yellow, 2);   // create pen in case image extraction failes and we need to preview the
														//blobs that were detected

			Pen redPen = new Pen(Color.Red, 2);   // create pen in case image extraction failes and we need to preview the
												  //blobs that were not detected


			Rectangle[] rects = blobCounter.GetObjectsRectangles();
			Blob[] blobs2 = blobCounter.GetObjects(bitmap, false);

			//Detection of paper lies within the presence of crossmark printed on the corneres of printed sheet.
			// First, detect left edge.
			System.Drawing.Image compImg = System.Drawing.Image.FromFile("lc.jpg");
			// lc.jpg = Mirrored image sample as located on the corner of printed sheet
			UnmanagedImage compUMImg = UnmanagedImage.FromManagedImage((Bitmap)compImg);
			// this helps filtering out much smaller and much larger blobs depending upon the size of image.
			// can be queried from XML Reader
			double minbr = XML.OMRSheetReader.getProcessVariableD(OMRSheets, sheet, XML.OMREnums.OMRImageProcessVariables.MinBlobRatio);
			double maxbr = XML.OMRSheetReader.getProcessVariableD(OMRSheets, sheet, XML.OMREnums.OMRImageProcessVariables.MaxBlobRatio);

			minbr = 0;
			maxbr = 100;
			List<IntPoint> quad = new List<IntPoint>(); // Store sheet corner locations (if anyone is detected )

			if (giveFB) showTimeStamp("Left edge detection started.", ref tb);
			try
			{
				foreach (Blob blob in blobs2)
				{
					if (
						((double)blob.Area) / ((double)bitmap.Width * bitmap.Height) > minbr &&
						((double)blob.Area) / ((double)bitmap.Width * bitmap.Height) < maxbr &&
							blob.Rectangle.X < (bitmap.Width) / 2) // filters oout very small or very larg blobs
					{
						if ((double)blob.Rectangle.Width / blob.Rectangle.Height < 1.4 &&
							(double)blob.Rectangle.Width / blob.Rectangle.Height > .6) // filters out blobs having insanely wrong aspect ratio
						{
							compUMImg = UnmanagedImage.FromManagedImage(ImageUtilities.ResizeImage(compImg, blob.Rectangle.Width, blob.Rectangle.Height));
							if (isSame(blob.Image, compUMImg))
							{
								g.DrawRectangle(yellowPen, blob.Rectangle);
								quad.Add(new IntPoint((int)blob.CenterOfGravity.X, (int)blob.CenterOfGravity.Y));
							}
							else
								g.DrawRectangle(redPen, blob.Rectangle);
						}
					}
				}
			}
			catch (ArgumentException) { MessageBox.Show("No Blobs"); }
			if (giveFB) showTimeStamp("Left edge detection finished.", ref tb);
			try
			{ // Sort out the list in right sequence, UpperLeft,LowerLeft,LowerRight,upperRight
				if (quad[0].Y > quad[1].Y)
				{
					IntPoint tp = quad[0];
					quad[0] = quad[1];
					quad[1] = tp;
				}
			}
			catch
			{
			}
			compImg = System.Drawing.Image.FromFile("rc.jpg");
			compUMImg = UnmanagedImage.FromManagedImage((Bitmap)compImg);
			if (giveFB) showTimeStamp("Right edge detection started.", ref tb); // jusst like left edge detection
			try
			{
				foreach (Blob blob in blobs2)
				{
					if (
						((double)blob.Area) / ((double)bitmap.Width * bitmap.Height) > minbr &&
						((double)blob.Area) / ((double)bitmap.Width * bitmap.Height) < maxbr &&
						blob.Rectangle.X > (bitmap.Width * 3) / 4)
					{
						if ((double)blob.Rectangle.Width / blob.Rectangle.Height < 1.4 &&
						(double)blob.Rectangle.Width / blob.Rectangle.Height > .6)
						{
							compUMImg = UnmanagedImage.FromManagedImage(ImageUtilities.ResizeImage(compImg, blob.Rectangle.Width, blob.Rectangle.Height));
							if (isSame(blob.Image, compUMImg))
							{
								g.DrawRectangle(yellowPen, blob.Rectangle);
								quad.Add(new IntPoint((int)blob.CenterOfGravity.X, (int)blob.CenterOfGravity.Y));
							}
							else
								g.DrawRectangle(redPen, blob.Rectangle);
						}
					}
				}
			}
			catch (ArgumentException) { MessageBox.Show("No Blobs"); }
			if (giveFB) showTimeStamp("Right edge detection finished.", ref tb);
			try
			{
				if (quad[2].Y < quad[3].Y)
				{
					IntPoint tp = quad[2];
					quad[2] = quad[3];
					quad[3] = tp;
				}
			}
			catch
			{

			}

			yellowPen.Dispose();
			g.Dispose();
			//Again, filter out if wrong blobs pretended to our blobs.
			if (quad.Count == 4)
			{
				if (((double)quad[1].Y - (double)quad[0].Y) / ((double)quad[2].Y - (double)quad[3].Y) < .75 ||
					((double)quad[1].Y - (double)quad[0].Y) / ((double)quad[2].Y - (double)quad[3].Y) > 1.25)
					quad.Clear(); // clear if, both edges have insanely wrong lengths
				else if (quad[0].X > bitmap.Width / 2 || quad[1].X > bitmap.Width / 2 || quad[2].X < bitmap.Width / 2 || quad[3].X < bitmap.Width / 2)
					quad.Clear(); // clear if, sides appear to be "wrong sided"
			}
			if (quad.Count != 4)// sheet not detected, reccurrsive call.
			{

				MessageBox.Show("Extraction Failed.");
				return bitmap;
			}
			else // sheet found
			{
				IntPoint tp2 = quad[3];
				quad[3] = quad[1];
				quad[1] = tp2;
				//sort the edges for wrap operation
				QuadrilateralTransformation wrap = new QuadrilateralTransformation(quad);
				wrap.UseInterpolation = false; //perspective wrap only, no binary.
				Rectangle sr = XML.OMRSheetReader.GetSheetPropertyLocation(OMRSheets, sheet, XML.OMREnums.OMRProperty.SheetSize);
				wrap.AutomaticSizeCalculaton = false;
				wrap.NewWidth = sr.Width;
				wrap.NewHeight = sr.Height;
				wrap.Apply(basicImage).Save("LastImg.jpg", ImageFormat.Jpeg); // creat file backup for future use.
				return wrap.Apply(basicImage); // wrap
			}
		}

		public Bitmap prepareForObjectDetection(Bitmap bmp)
		{
			// step 1 - turn background to black

			ColorFiltering colorFilter = new ColorFiltering();

			int upper = ImageUtilities.getWhiteLevel(bmp);
			colorFilter.Red = new IntRange(0, upper);
			colorFilter.Green = new IntRange(0, upper);
			colorFilter.Blue = new IntRange(0, upper);
			colorFilter.FillOutsideRange = true;
			colorFilter.FillColor = new RGB(Color.White);
			AForge.Imaging.Filters.ExtractChannel extract_channel = new ExtractChannel(0);
			AForge.Imaging.Filters.Threshold threshholdFilter = new Threshold(10);
			AForge.Imaging.Filters.Invert invert = new Invert();


			colorFilter.ApplyInPlace(bmp);

			colorFilter.Red = new IntRange(0, upper);
			colorFilter.Green = new IntRange(0, upper);
			colorFilter.Blue = new IntRange(0, upper);
			colorFilter.FillColor = new RGB(Color.Black);
			colorFilter.FillOutsideRange = true;

			bmp = extract_channel.Apply(bmp);

			invert.ApplyInPlace(bmp);

			threshholdFilter.ApplyInPlace(bmp);

			//invert.ApplyInPlace(bmp);
			bmp = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format24bppRgb);
			//invert.ApplyInPlace(bmp);

			return bmp;
		}
		private bool isSame(UnmanagedImage img1, UnmanagedImage img2)
		{
			int count = 0, tcount = img2.Width * img2.Height;
			for (int y = 0; y < img1.Height; y++)
				for (int x = 0; x < img1.Width; x++)
				{
					Color c1 = img1.GetPixel(x, y), c2 = img2.GetPixel(x, y);
					if (((c1.R + c1.G + c1.B) / 3 > 127) == ((c2.R + c2.G + c2.B) / 3 > 127))
						count++;
					//if ((c1.R + c1.G + c1.B) / 3 > (c2.R + c2.G + c2.B) / 3 - 10 &&
					//    (c1.R + c1.G + c1.B) / 3 < (c2.R + c2.G + c2.B) / 3 + 10)
					//    count++;
				}
			return (count * 100) / tcount >= 54;
		}
		private void showTimeStamp(string str, ref TextBox textBox1)
		{
			textBox1.AppendText(str + ": " + (new TimeSpan(DateTime.Now.Ticks) - ts).TotalSeconds + "\r\n");
			ts = new TimeSpan(DateTime.Now.Ticks);
		}

		public int getRegNumOfSheet(System.Drawing.Image image, XML.OMREnums.OMRSheet sheet, string OMRSheetFile, bool readInvalidRegNum)
		{
			Rectangle[] Blocks = new Rectangle[]
			{
				XML.OMRSheetReader.GetSheetPropertyLocation(OMRSheetFile, sheet, XML.OMREnums.OMRProperty.RegNumBlock),
			};

			List<Bitmap[]> bmps = new List<Bitmap[]>();
			bmps.Add(SliceOMarkBlock(image, Blocks[0], 3));

			int regNum = 0, multiplier = 100;
			foreach (Bitmap[] blk in bmps)
			{
				foreach (Bitmap line in blk)
				{
					int num = rateSlice(line, 10) - 1;
					if (num < 1 && !readInvalidRegNum)
						throw new Exception("Invalid Reg. No.");
					else
					{
						if (num < 0) num = 0;
						regNum += num * multiplier;
						multiplier /= 10;
					}
				}
			}

			return regNum;
		}
		/// <summary>
		/// Reads all the selected options on paper in one call
		/// </summary>
		/// <param name="image">Exctracted Sheet.</param>
		/// <param name="sheet">Type of printed sheet</param>
		/// <param name="OMRSheetFile">XML sheet address</param>
		/// <returns></returns>
		public List<List<int>> getScoreOfSheet(System.Drawing.Image image, XML.OMREnums.OMRSheet sheet, string OMRSheetFile)
		{
			List<List<int>> scores = new List<List<int>>();
			//number of blocks depend upon type of sheet selected
			Rectangle[] Blocks = new Rectangle[
				XML.OMRSheetReader.GetSheetPropertyInt(OMRSheetFile, sheet, XML.OMREnums.OMRProperty.NumOfBlocks)
				];
			// Read block location from XML file for selected sheet
			for (int i = 1; i <= Blocks.Length; i++)
			{
				Blocks[i - 1] = XML.OMRSheetReader.GetSheetPropertyLocation(OMRSheetFile, sheet, (XML.OMREnums.OMRProperty)i);
			}

			// slice the blocks into lines inside them and record as bitmap
			List<Bitmap[]> bmps = new List<Bitmap[]>();
			for (int i = 0; i < 4; i++)
			{
				bmps.Add(SliceOMarkBlock(image, Blocks[i], 10));
				scores.Add(new List<int>());
			}

			int bn = 0;
			// read selected option of sliced line
			foreach (Bitmap[] blk in bmps)
			{
				foreach (Bitmap line in blk)
				{
					scores[bn].Add(rateSlice(line, 5));
				}
				bn++;
			}

			return scores;
		}
		/// <summary>
		/// returns ant int representation of selected option
		/// </summary>
		/// <param name="slice">Sliced sinlge line in choices block</param>
		/// <param name="OMCount"></param>
		/// <returns></returns>
		private int rateSlice(Bitmap slice, int OMCount)
		{
			Rectangle[] cropRects = new Rectangle[OMCount];
			Bitmap[] marks = new Bitmap[OMCount];
			//sub-devide line into option (horizontal only)
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
			List<long> fullInks = new List<long>();

			//get marking level
			foreach (Bitmap mark in marks)
			{
				fullInks.Add(InkDarkness(mark));
			}
			int indofMx = -1, indofMn = -1;
			long maxD = 0;

			//get maximum ink level
			for (int i = 0; i < OMCount; i++)
			{
				if (fullInks[i] > maxD)
				{
					maxD = fullInks[i];
					indofMx = i;
				}
			}
			bool parallelExist = false, spe = false, tpe = false, fpe = false;
			for (int i = 0; i < OMCount; i++)
			{
				if (i != indofMx)
				{
					if ((double)fullInks[indofMx] / fullInks[i] <= 2) //both ink levels are nearly the same
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
			//check if multiple options were selected
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


	}
}
