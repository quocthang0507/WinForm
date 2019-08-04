using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SuDungCongCu_Graphic
{
	public partial class VeHCN : Form
	{
		public volatile Graphics graphic;
		public VeHCN()
		{
			InitializeComponent();
			graphic = panel1.CreateGraphics();
		}

		private void btPlay_Click(object sender, EventArgs e)
		{
			//int i = 10;
			//Rectangle rect2 = new Rectangle(10, 10, 20, 20);
			//graphic.DrawRectangle(Pens.Red, rect2);
			//int j = 5;
			//Rectangle rect3 = new Rectangle(20, 10, 20, 20);
			//graphic.DrawRectangle(Pens.Magenta, rect3);
			//while (i < 150)
			//{
			//	i = i + 5;
			//	Thread.Sleep(50);
			//	graphic.Clear(Color.White);
			//	Rectangle rect1 = new Rectangle(10, i, 20, 20);
			//	Rectangle rect4 = new Rectangle(i, 10, 20, 20);
			//	graphic.DrawRectangle(Pens.Magenta, rect4);
			//	graphic.DrawRectangle(Pens.Red, rect1);
			//}
			for (int i = 1; i <= 150; i++)
			{
				Thread.Sleep(10);
				graphic.Clear(Color.White);
				Rectangle rect1 = new Rectangle(i, i, 20, 20);
				graphic.DrawRectangle(Pens.Magenta, rect1);
			}
		}
	}
}
