using System;
using System.Collections.Generic;
using System.Drawing;

namespace Othello2
{
	public static class AI
	{
		private static Dictionary<int, Point> actions = new Dictionary<int, Point>();
		private const int negInfinity = -2147483647;
		private const int posInfinity = 2147483647;
		private static int maxDepth = 3;
		private enum scoreType { AI_PIECE, AI_EDGE, AI_CORNER, PLAYER_PIECE, PLAYER_EDGE, PLAYER_CORNER };
		private static int[] scoring = new int[6] { 1, 1, 1, -1, -50, -50 };

		public static Point getMove(GameState gs)
		{
			actions.Clear();
			int v = max_search(gs, negInfinity, posInfinity, 0);
			System.Diagnostics.Debug.WriteLine(v + " = " + actions[v].ToString());
			return actions[v];
		}

		private static int max_search(GameState gs, int alpha, int beta, int depth)
		{
			int rval;
			rval = 0;
			if (terminal(gs, depth))
			{
				rval = score(gs);
			}
			else
			{
				rval = negInfinity;
				for (int i = 0; i < gs.ValidMoves.Count; ++i)
				{
					int tempScore;
					GameState tempGS = gs.Clone();
					tempGS.PlayPiece(gs.ValidMoves[i]);

					if (tempGS.Current_player == Model.AIplayer)
					{
						tempScore = max_search(tempGS, alpha, beta, depth);
					}
					else
					{
						tempScore = min_search(tempGS, alpha, beta, depth + 1);
					}

					if (tempScore > rval)
					{
						rval = tempScore;
					}

					if (gs.Equals(Model.State))
					{
						actions[rval] = gs.ValidMoves[i];
					}

					if (rval >= beta)
					{
						break;
					}

					alpha = Math.Max(alpha, rval);
				}
			}
			return rval;
		}

		private static int min_search(GameState gs, int alpha, int beta, int depth)
		{
			int rval;
			rval = 0;
			if (terminal(gs, depth))
			{
				rval = score(gs);
			}
			else
			{
				rval = posInfinity;
				for (int i = 0; i < gs.ValidMoves.Count; ++i)
				{
					int tempScore;
					GameState tempGS = gs.Clone();

					tempGS.PlayPiece(gs.ValidMoves[i]);

					if (tempGS.Current_player == Model.AIplayer)
					{
						tempScore = max_search(tempGS, alpha, beta, depth);
					}
					else
					{
						tempScore = min_search(tempGS, alpha, beta, depth);
					}

					if (tempScore < rval)
					{
						rval = tempScore;
					}

					if (rval <= alpha)
					{
						break;
					}

					beta = Math.Min(beta, rval);
				}
			}
			return rval;
		}

		private static bool terminal(GameState gs, int depth)
		{
			return ((depth > maxDepth) || (gs.Current_player == GameState.player.GAME_OVER));
		}

		private static int score(GameState gs)
		{
			int rval;
			rval = 0;
			for (int i = 0; i < gs.Board.GetLength(0); ++i)
			{
				for (int j = 0; j < gs.Board.GetLength(1); ++j)
				{
					if (gs.Board[i, j] == Model.AIplayer)
					{
						rval += scoring[(int)scoreType.AI_PIECE];
						if (isCorner(i, j))
						{
							rval += scoring[(int)scoreType.AI_CORNER];
						}
						else if (isEdge(i, j))
						{
							rval += scoring[(int)scoreType.AI_EDGE];
						}
					}
					else if (gs.Board[i, j] != GameState.player.NONE)
					{
						rval += scoring[(int)scoreType.PLAYER_PIECE];
						if (isCorner(i, j))
						{
							rval += scoring[(int)scoreType.PLAYER_CORNER];
						}
						else if (isEdge(i, j))
						{
							rval += scoring[(int)scoreType.PLAYER_EDGE];
						}
					}
				}
			}
			return rval;
		}

		private static bool isCorner(int x, int y)
		{
			return (((x == 0) || (x == 7)) && ((y == 0) || (y == 7)));
		}

		private static bool isEdge(int x, int y)
		{
			return ((x == 0) || (x == 7) || (y == 0) || (y == 7));
		}
	}
}
