using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace DeCaptcha
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private string reconhecerCaptcha(Image img)
		{
			Bitmap imagem = new Bitmap(img);
			imagem = imagem.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			Erosion erosion = new Erosion();
			Dilatation dilatation = new Dilatation();
			Invert inverter = new Invert();
			ColorFiltering cor = new ColorFiltering();
			cor.Blue = new AForge.IntRange(200, 255);
			cor.Red = new AForge.IntRange(200, 255);
			cor.Green = new AForge.IntRange(200, 255);
			Opening open = new Opening();
			BlobsFiltering bc = new BlobsFiltering();
			Closing close = new Closing();
			GaussianSharpen gs = new GaussianSharpen();
			ContrastCorrection cc = new ContrastCorrection();
			bc.MinHeight = 10;
			FiltersSequence seq = new FiltersSequence(gs, inverter, open, inverter, bc, inverter, open, cc, cor, bc, inverter);
			pic_decaptcha.Image = seq.Apply(imagem);
			string reconhecido = OCR((Bitmap)pic_decaptcha.Image);
			return reconhecido;
		}

		private string OCR(Bitmap b)
		{
			string res = "";
			using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
			{
				//engine.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ");
				engine.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
				engine.SetVariable("tessedit_unrej_any_wd", true);

				using (var page = engine.Process(b, PageSegMode.SingleLine))
					res = page.GetText();
			}
			return res;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				pic_orgin.LoadAsync(openFileDialog.FileName);
			}
		}

		private void btn_decaptcha_Click(object sender, EventArgs e)
		{
			resultLabel.Text = reconhecerCaptcha(pic_orgin.Image);
		}
	}
}
