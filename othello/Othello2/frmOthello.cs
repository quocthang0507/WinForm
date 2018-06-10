using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Othello2
{
	public partial class frmOthello : Form
	{
		#region View

		private int squareSize;
		private PictureBox[,] board;
		private Label[] rowLabels;
		private Label[] colLabels;
		private Image freeSquare;
		private Image whiteSquare;
		private Image blackSquare;
		private TextBox moveList;
		private TextBox gameStatus;
		private int move_list_min_width = 50;
		private int padding_for_labels = 20;

		public void UpdateViews()
		{
			UpdateBoardView();
			UpdateMoveListView();
			UpdateGameStatusView();
			this.Refresh();
		}

		private void UpdateGameStatusView()
		{
			StringBuilder status = new StringBuilder();
			int blackScore = 0;
			int whiteScore = 0;

			switch (Model.State.Current_player)
			{
				case GameState.player.NONE:
					status.AppendLine("None");
					break;
				case GameState.player.WHITE:
					status.AppendLine("White's Turn");
					break;
				case GameState.player.BLACK:
					status.AppendLine("Black's Turn");
					break;
				case GameState.player.GAME_OVER:
					status.AppendLine("Game Over");
					break;
			}

			for (int i = 0; i < Model.State.Board.GetLength(0); ++i)
			{
				for (int j = 0; j < Model.State.Board.GetLength(1); ++j)
				{
					switch (Model.State.Board[i, j])
					{
						case GameState.player.WHITE:
							++whiteScore;
							break;
						case GameState.player.BLACK:
							++blackScore;
							break;
					}
				}
			}

			status.AppendLine("White: " + whiteScore.ToString());
			status.AppendLine("Black: " + blackScore.ToString());

			gameStatus.Text = status.ToString();
		}

		private void UpdateBoardView()
		{
			GameState.player[,] model_board = Model.State.Board;
			for (int i = 0; i < model_board.GetLength(0); ++i)
			{
				for (int j = 0; j < model_board.GetLength(1); ++j)
				{
					switch (model_board[i, j])
					{
						case GameState.player.NONE:
							board[i, j].Image = freeSquare;
							break;
						case GameState.player.WHITE:
							board[i, j].Image = whiteSquare;
							break;
						case GameState.player.BLACK:
							board[i, j].Image = blackSquare;
							break;
					}
				}
			}
		}

		private void UpdateMoveListView()
		{
			moveList.Text = Model.MoveList.ToString();
		}

		private void CreateViews()
		{
			CreateBoardView();
			CreateMoveListView();
			CreateGameStatusView();
		}

		private void CreateBoardView()
		{
			squareSize = (System.Math.Min(pnlView.Width - move_list_min_width, pnlView.Height) - (2 * padding_for_labels)) / 8;
			board = new PictureBox[8, 8];
			rowLabels = new Label[8];
			colLabels = new Label[8];
			freeSquare = Image.FromFile("square.bmp");
			whiteSquare = Image.FromFile("white.bmp");
			blackSquare = Image.FromFile("black.bmp");
			for (int i = 0; i < 8; ++i)
			{
				rowLabels[i] = new Label();
				rowLabels[i].Text = i.ToString();
				rowLabels[i].Location = new Point(0, padding_for_labels + i * squareSize);
				rowLabels[i].Size = new Size(padding_for_labels, squareSize);
				rowLabels[i].Name = "lblRow" + i.ToString();
				rowLabels[i].TabStop = false;
				rowLabels[i].TextAlign = ContentAlignment.MiddleCenter;
				pnlView.Controls.Add(rowLabels[i]);
				for (int j = 0; j < 8; ++j)
				{
					colLabels[i] = new Label();
					colLabels[i].Text = Convert.ToChar(j + 65).ToString();
					colLabels[i].Location = new Point(padding_for_labels + j * squareSize, 0);
					colLabels[i].Size = new Size(squareSize, padding_for_labels);
					colLabels[i].Name = "lblCol" + j.ToString();
					colLabels[i].TabStop = false;
					colLabels[i].TextAlign = ContentAlignment.MiddleCenter;
					pnlView.Controls.Add(colLabels[j]);

					board[i, j] = new PictureBox();
					board[i, j].Image = freeSquare;
					board[i, j].Location = new Point(padding_for_labels + i * squareSize, padding_for_labels + j * squareSize);
					board[i, j].Size = new Size(squareSize, squareSize);
					board[i, j].Name = "pBoxBoard" + i.ToString() + j.ToString();
					board[i, j].TabIndex = 0;
					board[i, j].TabStop = false;
					board[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
					board[i, j].Click += board_click;
					board[i, j].Tag = new Point(i, j);
					pnlView.Controls.Add(board[i, j]);
				}
			}
		}

		private void CreateMoveListView()
		{
			moveList = new TextBox();
			moveList.Text = "";
			moveList.TextAlign = HorizontalAlignment.Left;
			moveList.ReadOnly = true;
			moveList.Location = new Point(8 * squareSize + (padding_for_labels * 2), padding_for_labels);
			moveList.Multiline = true;
			moveList.Name = "txtMoveList";
			moveList.ScrollBars = ScrollBars.Vertical;
			moveList.Size = new Size(System.Math.Max(move_list_min_width, pnlView.Width - (padding_for_labels * 3) - 8 * squareSize), (pnlView.Height - (padding_for_labels * 3)) / 2);
			moveList.TabStop = false;
			moveList.Visible = true;
			moveList.WordWrap = false;
			pnlView.Controls.Add(moveList);
		}

		private void CreateGameStatusView()
		{
			gameStatus = new TextBox();
			gameStatus.TextAlign = HorizontalAlignment.Left;
			gameStatus.ReadOnly = true;
			gameStatus.Location = new Point(8 * squareSize + (padding_for_labels * 2), (padding_for_labels * 2) + moveList.Height);
			gameStatus.Multiline = true;
			gameStatus.Name = "txtGameStatus";
			gameStatus.Size = new Size(System.Math.Max(move_list_min_width, pnlView.Width - (padding_for_labels * 3) - 8 * squareSize), (pnlView.Height - (padding_for_labels * 3)) / 2);
			gameStatus.TabStop = false;
			gameStatus.Visible = true;
			gameStatus.WordWrap = false;
			gameStatus.Text = "None" + Environment.NewLine + "White: 0" + Environment.NewLine + "Black: 0";
			pnlView.Controls.Add(gameStatus);
		}

		private void board_click(object sender, System.EventArgs e)
		{
			Point squareClicked = ((Point)((PictureBox)sender).Tag);
			Controller.TryMove(squareClicked);
		}

		#endregion View

		#region FormStuff

		private void handleChecks(object sender)
		{
			beginnerToolStripMenuItem.Checked = false;
			intermediateToolStripMenuItem.Checked = false;
			expertToolStripMenuItem.Checked = false;
			masterToolStripMenuItem.Checked = false;
			customToolStripMenuItem.Checked = false;
			localToolStripMenuItem.Checked = false;
			networkToolStripMenuItem.Checked = false;
			playerToolStripMenuItem.Checked = false;
			((ToolStripMenuItem)sender).Checked = true;
			if (sender.Equals(localToolStripMenuItem) || sender.Equals(networkToolStripMenuItem))
			{
				playerToolStripMenuItem.Checked = true;
				Model.AIplayer = GameState.player.NONE;
			}
			else
			{
				Model.AIplayer = GameState.player.WHITE;
			}
		}

		public frmOthello()
		{
			InitializeComponent();
		}

		private void frmOthello_Load(object sender, EventArgs e)
		{
			MinimumSize = Size;
			CreateViews();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void expertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void masterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void customToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void localToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void networkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			handleChecks(sender);
		}

		private void exportMoveListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string FileName = getSaveFileName();
			if (FileName != null)
			{
				Controller.ExportMoves(saveFile.FileName);
			}
		}

		private void importGameFromMoveListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult doOpen = openFile.ShowDialog();
			if (doOpen == DialogResult.OK)
			{
				Controller.ImportMoves(openFile.FileName);
			}
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Controller.New();
		}

		private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Future implementation, for now just import
			importGameFromMoveListToolStripMenuItem_Click(sender, e);
		}

		private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Future implementation, for now just export
			exportMoveListToolStripMenuItem_Click(sender, e);
		}

		private string getSaveFileName()
		{
			string rval = null;
			if (pnlView.Controls.Find("txtMoveList", true)[0].Text != "")
			{
				DialogResult doSave = saveFile.ShowDialog();
				if (doSave == DialogResult.OK)
				{
					rval = saveFile.FileName;
				}
			}
			return rval;
		}

		#endregion Form Stuff

	}
}
