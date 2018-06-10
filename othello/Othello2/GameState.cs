using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Othello2
{
	public class GameState
	{
		public enum player { NONE, BLACK, WHITE, GAME_OVER };
		private player[,] board;
		private player current_player;
		private List<Point> validMoves = new List<Point>();

		public List<Point> ValidMoves
		{
			get { return validMoves; }
		}

		public player[,] Board
		{
			get { return board; }
			set { board = value; }
		}

		public player Current_player
		{
			get { return current_player; }
			set { current_player = value; }
		}

		public GameState()
		{
			current_player = player.NONE;
			board = new player[8, 8];
			for (int i = 0; i < board.GetLength(0); ++i)
			{
				for (int j = 0; j < board.GetLength(1); ++j)
				{
					board[i, j] = player.NONE;
				}
			}
		}

		public void NewGame()
		{
			for (int i = 0; i < 8; ++i)
			{
				for (int j = 0; j < 8; ++j)
				{
					Board[i, j] = GameState.player.NONE;
					if (2 < i && i < 5 && 2 < j && j < 5)
					{
						if (i == j)
						{
							Board[i, j] = GameState.player.WHITE;
						}
						else
						{
							Board[i, j] = GameState.player.BLACK;
						}
					}
				}
			}
			Current_player = GameState.player.BLACK;
			getValidMoves();
		}

		public bool PlayPiece(Point move)
		{
			bool rval = false;
			if (Current_player == GameState.player.WHITE || Current_player == GameState.player.BLACK)
			{
				if (ValidMoves.Contains(move))
				{
					Size direction = new Size();
					Board[move.X, move.Y] = Current_player;
					for (direction.Width = -1; direction.Width < 2; ++direction.Width)
					{
						for (direction.Height = -1; direction.Height < 2; ++direction.Height)
						{
							if (direction != new Size(0, 0) && checkDirection(move, direction))
							{
								PlayDirection(move, direction);
							}
						}
					}
					rval = true;
					swapTurn();
				}
			}
			return rval;
		}

		private void swapTurn()
		{
			Current_player = (GameState.player)getOpponent();
			ValidMoves.Clear();
			getValidMoves();
			if (ValidMoves.Count == 0)
			{
				Current_player = getOpponent();
				ValidMoves.Clear();
				getValidMoves();
				if (ValidMoves.Count == 0)
				{
					Current_player = GameState.player.GAME_OVER;
				}
			}
		}

		private void getValidMoves()
		{
			ValidMoves.Clear();
			Point start = new Point();
			Size direction = new Size();
			bool nextMove;
			for (start.X = 0; start.X < Board.GetLength(0); ++start.X)
			{
				for (start.Y = 0; start.Y < Board.GetLength(1); ++start.Y)
				{
					nextMove = (Board[start.X, start.Y] != GameState.player.NONE);
					for (direction.Width = -1; !nextMove && direction.Width < 2; ++direction.Width)
					{
						for (direction.Height = -1; !nextMove && direction.Height < 2; ++direction.Height)
						{
							if (direction != new Size(0, 0) && checkDirection(start, direction))
							{
								ValidMoves.Add(start);
								nextMove = true;
							}
						}
					}
				}
			}
		}

		private void PlayDirection(Point start, Size dir)
		{
			GameState.player Opponent = getOpponent();

			for (start = start + dir; Board[start.X, start.Y] == Opponent; start = start + dir)
			{
				Board[start.X, start.Y] = Current_player;
			}
		}

		private bool checkDirection(Point start, Size dir)
		{
			bool foundOpponent = false;
			GameState.player Opponent = getOpponent();

			start = start + dir;
			while (boundsCheck(start) && Board[start.X, start.Y] == Opponent)
			{
				start = start + dir;
				foundOpponent = true;
			}

			return (foundOpponent && boundsCheck(start) && Board[start.X, start.Y] == Current_player);
		}

		private GameState.player getOpponent()
		{
			return ((Current_player == GameState.player.WHITE) ? (GameState.player.BLACK) : (GameState.player.WHITE));
		}

		private bool boundsCheck(Point p)
		{
			return (-1 < p.X && p.X < 8 && -1 < p.Y && p.Y < 8);
		}

		public GameState Clone()
		{
			GameState rval = new GameState();
			for (int i = 0; i < Board.GetLength(0); ++i)
			{
				for (int j = 0; j < Board.GetLength(1); ++j)
				{
					rval.Board[i, j] = Board[i, j];
				}
			}
			rval.Current_player = Current_player;
			for (int i = 0; i < ValidMoves.Count; ++i)
			{
				rval.ValidMoves.Add(ValidMoves[i]);
			}
			return rval;
		}
	}
}
