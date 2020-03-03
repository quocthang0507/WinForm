using System.Drawing;

namespace CARO
{
	public class Board
	{
		public int NumRow { get; set; }
		public int NumCol { get; set; }

		private Image ImageO = new Bitmap(Properties.Resources.o);
		private Image ImageX = new Bitmap(Properties.Resources.x);

		public Board()
		{
			NumCol = 0;
			NumRow = 0;
		}

		public Board(int numRow, int numCol)
		{
			NumRow = numRow;
			NumCol = numCol;
		}

		public void DrawBoard(Graphics graphic)
		{
			// Draw columns
			for (int i = 0; i <= NumCol; i++)
			{
				graphic.DrawLine(Controller.DefaultPen, i * Cell.Width, 0, i * Cell.Width, NumRow * Cell.Height);
			}
			// Draw rows
			for (int i = 0; i <= NumRow; i++)
			{
				graphic.DrawLine(Controller.DefaultPen, 0, i * Cell.Height, NumCol * Cell.Width, i * Cell.Height);
			}
		}

		public void DrawChess(Graphics graphic, int x, int y, int possess)
		{
			// Black chessman (or O chessman)
			if (possess == 1)
			{
				graphic.DrawImage(ImageO, x, y);
			}
			else // White chessman (or X chessman)
			{
				graphic.DrawImage(ImageX, x + 2, y + 2);
			}
		}
	}
}
