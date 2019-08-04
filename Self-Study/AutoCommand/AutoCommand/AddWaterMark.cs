using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AutoCommand
{
	class AddWaterMark
	{
		/// <summary>
		/// Add watermark to image
		/// </summary>
		/// <param name="fs">The file stream</param>
		/// <param name="px"></param>
		/// <param name="py"></param>
		/// <param name="watermarkText">The text watermark</param>
		/// <param name="outputStream">The output stream</param>
		/// <param name="nameFont">The font name</param>
		/// <param name="size">The font size</param>
		/// <param name="style">The font style</param>
		public static void AddWatermark(FileStream fs, int px, int py, string watermarkText, Stream outputStream, string nameFont, int size, FontStyle style, Color c)
		{
			Image img = Image.FromStream(fs);
			Font font = new Font(nameFont, size, style, GraphicsUnit.Pixel);
			Point pt = new Point(px, py);
			SolidBrush sbrush = new SolidBrush(c);
			Graphics gr = null;
			try
			{
				gr = Graphics.FromImage(img);
			}
			catch
			{
				Image img1 = img;
				img = new Bitmap(img.Width, img.Height);
				gr = Graphics.FromImage(img);
				gr.DrawImage(img1, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
				img1.Dispose();
			}
			gr.DrawString(watermarkText, font, sbrush, pt);
			gr.Dispose();
			img.Save(outputStream, ImageFormat.Jpeg);
		}
	}
}
