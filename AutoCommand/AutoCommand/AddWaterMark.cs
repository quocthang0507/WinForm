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
		/// <param name="watermarkText">The text watermark</param>
		/// <param name="outputStream">The output stream</param>
		/// <param name="f">The font name</param>
		/// <param name="size">The font size</param>
		/// <param name="s">The font style</param>
		public void AddWatermark(FileStream fs, string watermarkText, Stream outputStream, string f, int size, FontStyle s)
		{
			Image img = Image.FromStream(fs);
			Font font = new Font(f, size, s, GraphicsUnit.Pixel);
			Color color = Color.Orange;
			Point pt = new Point(10, 30);
			SolidBrush sbrush = new SolidBrush(color);
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
