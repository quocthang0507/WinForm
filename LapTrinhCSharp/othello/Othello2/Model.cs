using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Othello2
{
	public static class Model
	{
		private static GameState state = new GameState();
		private static StringBuilder moveList = new StringBuilder();
		private static GameState.player aiPlayer = GameState.player.NONE;

		public static GameState.player AIplayer
		{
			get { return Model.aiPlayer; }
			set { Model.aiPlayer = value; }
		}

		public static StringBuilder MoveList
		{
			get { return Model.moveList; }
		}

		public static GameState State
		{
			get { return Model.state; }
			set { Model.state = value; }
		}

	}
}
