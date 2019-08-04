using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

// Really need to think more about this whole MVC thing, think I'm doing it wrong
namespace Othello2
{
	public static class Controller
	{
		public static void doUpdate()
		{
			Startup.mainForm.UpdateViews();
		}

		public static void TryMove(Point move)
		{
			if (Model.State.PlayPiece(move))
			{
				Model.MoveList.AppendLine(standardForm(move));
				doUpdate();
			}
			while (Model.State.Current_player == Model.AIplayer)
			{
				Point AImove = new Point();
				System.Threading.Thread.Sleep(1000);
				if (Model.State.PlayPiece(AImove = AI.getMove(Model.State)))
				{
					Model.MoveList.AppendLine(standardForm(AImove));
					doUpdate();
				}
			}
		}

		public static void New()
		{
			Model.State.NewGame();
			Model.MoveList.Clear();
			doUpdate();
		}

		public static void ExportMoves(string fileName)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
			sw.Write(Model.MoveList);
			sw.Close();
		}

		public static void ImportMoves(string fileName)
		{
			System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
			New();
			foreach (string line in sr.ReadToEnd().Split(new char[] { '\n' }))
			{
				if (line != "")
				{
					Point temp = pointForm(line);
					Model.State.PlayPiece(temp);
				}
			}
			sr.Close();
		}

		private static Point pointForm(string s)
		{
			Point rval = new Point();
			rval.X = ((int)s[0]) - (int)'A';
			rval.Y = (int)s[1] - (int)'0';
			return rval;
		}

		private static string standardForm(Point p)
		{
			StringBuilder rval = new StringBuilder();
			rval.Append(((char)(p.X + (int)'A')).ToString());
			rval.Append(p.Y.ToString());
			return rval.ToString();
		}

	}
}
