namespace CARO
{
	public class Cell
	{
		public static readonly int Width = 30;
		public static readonly int Height = 30;

		public int Row { get; set; }
		public int Column { get; set; }
		public int Possess { get; set; }

		public Cell()
		{

		}

		public Cell(int row, int column, int possess)
		{
			Row = row;
			Column = column;
			Possess = possess;
		}
	}
}
