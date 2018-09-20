using System;
using System.Drawing;
using System.Windows.Forms;

namespace howto_fit_font
{
	public class AutoResizeLabel : System.Windows.Forms.Label
	{
		//private String text = "AutoResizeTextView";
		private int size = 12;

		//Create Properties  


		public int font_size
		{
			get { return size; }
			set { size = value; Invalidate(); }
		}

		public AutoResizeLabel()
		{
			this.ForeColor = Color.Green;
			this.Font = new Font(Font.FontFamily, size);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			size = SizeLabelFont();
			if (size == 0)
			{
				size = 1;
			}
			//draw a string of text label  
			//Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
			//e.Graphics.DrawString(this.Text, new Font(Font.FontFamily, size), b, new Point(0, 0));
			this.Font = new Font(Font.FontFamily, size);
			this.AutoSize = false;
		}

		private int SizeLabelFont()
		{
			string txt = this.Text;
			if (txt.Length > 0)
			{
				int best_size = 100;
				int wid = this.DisplayRectangle.Width - 3;
				int hgt = this.DisplayRectangle.Height - 3;
				using (Graphics gr = this.CreateGraphics())
				{
					for (int i = 1; i <= 100; i++)
					{
						using (Font test_font = new Font(this.Font.FontFamily, i))
						{
							SizeF text_size = gr.MeasureString(txt, test_font);
							if ((text_size.Width > wid) || (text_size.Height > hgt))
							{
								best_size = i - 1;
								return best_size;
							}
						}
					}
				}
			}
			return size;
		}
	}
}
