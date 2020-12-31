/*
 * Copyright (c) YinYang 2011
 * http://yinyangit.wordpress.com
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Y2_MineLand
{
    public partial class MinesBoardUI : UserControl
    {
        public event EventHandler CellClick;
        public event EventHandler MinesExplode;

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        #region Properties

        const int CELL_SIZE = 20;
        Color[] _foreColors = {
    Color.Blue,Color.Green,Color.Red,Color.Purple,Color.Peru,
    Color.PaleGreen,Color.Orchid,Color.Olive};

        Image _imgCell;
        Image _imgBomb;
        Image _imgFlag;
        Image _imgExplode;

        MinesBoard _board;

        public bool IsLost { get { return _board._IsLost; } }

        public int Rows
        {
            get { return _board._Rows; }
        }
        public int Cols
        {
            get { return _board._Cols; }
        }
        public int MinesCount
        {
            get { return _board._MinesCount; }
        }
        public int FlagsCount { get { return _board._FlagsCount; } }

        public int RemainCellsCount { get { return Rows * Cols - _board._OpenedCellsCount; } }

        private Color _maskColor;

        public Color MaskColor
        {
            get { return _maskColor; }
            set
            {
                _maskColor = value;
                _imgCell = new Bitmap(Properties.Resources.cell, CELL_SIZE, CELL_SIZE);

                using (Graphics g = Graphics.FromImage(_imgCell))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, _maskColor)),
                        0, 0, _imgCell.Width, _imgCell.Height);
                }
                Invalidate();
            }
        }

        #endregion

        public MinesBoardUI()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            _imgBomb = new Bitmap(Properties.Resources.clanbomber, CELL_SIZE, CELL_SIZE);
            _imgFlag = new Bitmap(Properties.Resources.flag, CELL_SIZE, CELL_SIZE);
            _imgExplode = Properties.Resources.explode;

            _board = new MinesBoard();

            // this.MaskColor = Color.Gray;
        }

        public void NewGame()
        {
            _board.New();

            this.Width = CELL_SIZE * _board._Cols + 3;
            this.Height = CELL_SIZE * _board._Rows + 3;
            Invalidate();
        }

        public void NewGame(int rows, int cols, int mines)
        {
            _board.New(rows, cols, mines);

            this.Width = CELL_SIZE * _board._Cols + 3;
            this.Height = CELL_SIZE * _board._Rows + 3;
            Invalidate();
        }


        void DoExplode(int left,int top)
        {
            _board._IsLost = true;

            pictureBox1.Left = left - pictureBox1.Width / 2;
            pictureBox1.Top = top- pictureBox1.Height / 2;
            pictureBox1.Visible = true;
            timer1.Enabled = true;
            
            OnMinesExplode();

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            if (!_board._IsLost && !_board._IsFinish)
            {
                int c = e.X / CELL_SIZE;
                int r = e.Y / CELL_SIZE;


                if (_board[r, c].IsOpened)
                {
                    if (GetKeyState((int)Keys.LButton) < 0 && GetKeyState((int)Keys.RButton) < 0)
                    {
                        if (_board.OpenAroundCell(r, c))
                            DoExplode(e.X,e.Y);
                        Invalidate();
                    }
                    return;
                }

                

                if (!_board[r, c].IsFlag && e.Button == MouseButtons.Left)
                {                    
                    if (_board.OpenCell(r, c))                                            
                        DoExplode(e.X,e.Y);
                    else
                    {
                        // Win
                        if (RemainCellsCount == MinesCount)
                        {
                            _board._IsFinish = true;

                            // Cắm cờ tất cả ô còn lại
                            for (int i = 0; i < Rows; i++)
                            {
                                for (int j = 0; j < Cols; j++)
                                {
                                    if (!_board[i, j].IsOpened)
                                        _board[i, j].IsFlag = true;
                                }
                            }
                        }
                    }

                    Invalidate();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (_board[r, c].IsMarked)
                    {
                        _board[r, c].IsMarked = false;
                    }
                    else
                    {
                        _board[r, c].IsFlag = !_board[r, c].IsFlag;
                        _board[r, c].IsMarked = !_board[r, c].IsFlag;

                        if (_board[r, c].IsFlag)
                            _board._FlagsCount++;
                        else
                            _board._FlagsCount--;
                    }
                    Invalidate();

                }
                // Dùng cho event
                OnCellClick();
            }
            base.OnMouseDown(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, 0, 0, this.Width, this.Height);

            for (int i = 0; i < _board._Rows; i++)
            {
                int y = CELL_SIZE * i;

                for (int j = 0; j < _board._Cols; j++)
                {
                    int x = CELL_SIZE * j;

                    if (_board[i, j].IsOpened)
                    {
                        if (_board[i, j].IsMine)
                        {
                            e.Graphics.FillRectangle(Brushes.Red, x, y, CELL_SIZE, CELL_SIZE);
                            e.Graphics.DrawImage(_imgBomb, x, y);
                        }
                        else if (_board[i, j].MinesAround > 0)
                        {
                            string s = _board[i, j].MinesAround.ToString();
                            SizeF size = e.Graphics.MeasureString(s, this.Font);

                            e.Graphics.DrawString(s,
                                this.Font, new SolidBrush(_foreColors[_board[i, j].MinesAround - 1]),
                                    x + (CELL_SIZE - size.Width) / 2, y + (CELL_SIZE - size.Height) / 2);
                        }
                    }
                    else
                        e.Graphics.DrawImage(_imgCell, x, y);

                    if (_board._IsLost)
                    {
                        if (_board[i, j].IsMine)
                            e.Graphics.DrawImage(_imgBomb, x, y);
                    }

                    if (_board[i, j].IsFlag)
                    {
                        e.Graphics.DrawImage(_imgFlag, x, y);
                    }
                    else if (_board[i, j].IsMarked)
                    {
                        string s = "?";
                        SizeF size = e.Graphics.MeasureString(s, this.Font);

                        e.Graphics.DrawString(s,
                            this.Font, Brushes.Black,
                                x + (CELL_SIZE - size.Width) / 2, y + (CELL_SIZE - size.Height) / 2);

                    }
                    // vertical
                    if (i == 0)
                        e.Graphics.DrawLine(Pens.Gray, x, 0, x, this.Height);
                }

                // hoz
                e.Graphics.DrawLine(Pens.Gray, 0, y, this.Width, y);
            }

            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            timer1.Enabled = false;
        }

        #region CustomEvent

        private void OnCellClick()
        {
            if (CellClick != null)
                CellClick(this, null);
        }
        protected void OnMinesExplode()
        {
            if (MinesExplode != null)
                MinesExplode(this, null);
        }

        #endregion
    }
}

