/*
 * Copyright (c) YinYang 2011
 * http://yinyangit.wordpress.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y2_MineLand
{
    public class Cell
    {
        public bool IsMine = false;
        public bool IsOpened = false;
        public bool IsFlag = false;
        public bool IsMarked = false;
        public int MinesAround = 0;
    }


    public class MinesBoard
    {
        Cell[,] _cells;

        public int _CellsCount;
        public int _Rows;
        public int _Cols;
        public int _MinesCount;
        public int _FlagsCount;
        public int _OpenedCellsCount;

        public bool _IsFinish;
        public bool _IsLost;

        public MinesBoard()
            : this(9, 9, 10)
        {

        }
        public MinesBoard(int rows, int cols, int minesCount)
        {
            New(rows, cols, minesCount);
        }
        public void New()
        {
            New(_Rows, _Cols, _MinesCount);
        }
        public void New(int rows, int cols, int minesCount)
        {
            this._Rows = rows;
            this._Cols = cols;
            this._MinesCount = minesCount;
            this._CellsCount = _Rows * _Cols;

            _OpenedCellsCount = 0;
            _IsFinish = false;
            _IsLost = false;
            _FlagsCount = 0;

            InitBoard();
        }
        public Cell this[int row, int col]
        {
            get { return _cells[row, col]; }
        }

        private void InitBoard()
        {
            _cells = new Cell[_Rows, _Cols];

            for (int i = 0; i < _Rows; i++)
                for (int j = 0; j < _Cols; j++)
                    _cells[i, j] = new Cell();

            Random rnd = new Random();
            int count = 0;

            while (count < _MinesCount)
            {
                int index = rnd.Next(_CellsCount);
                int r = index / _Cols;
                int c = index % _Cols;

                if (!_cells[r, c].IsMine)
                {
                    _cells[r, c].IsMine = true;
                    count++;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true nếu trúng mìn</returns>
        public bool OpenCell(int row, int col)
        {
            if (_cells[row, col].IsOpened || _cells[row, col].IsFlag)
                return false;
            _cells[row, col].IsOpened = true;
            _cells[row, col].IsMarked = false;

            if (_cells[row, col].IsMine)
            {
                return true;
            }
            _OpenedCellsCount++;

            // Đếm số mìn xung quanh và kiểm tra các trường hợp
            int count = CountAroundMines(row, col);

            if (count > 0)
            {
                _cells[row, col].MinesAround = count;
            }
            else
            {
                int r1 = row == 0 ? 0 : -1;
                int c1 = col == 0 ? 0 : -1;
                int r2 = row == _Rows - 1 ? 1 : 2;
                int c2 = col == _Cols - 1 ? 1 : 2;

                for (; r1 < r2; r1++)
                    for (int j = c1; j < c2; j++)
                    {
                        OpenCell(row + r1, col + j);
                    }
            }
            return false;
        }
        private int CountAroundMines(int row, int col)
        {
            int count = 0;
            int r1 = row == 0 ? 0 : -1;
            int c1 = col == 0 ? 0 : -1;
            int r2 = row == _Rows - 1 ? 1 : 2;
            int c2 = col == _Cols - 1 ? 1 : 2;

            for (; r1 < r2; r1++)
                for (int j = c1; j < c2; j++)
                {
                    if (_cells[row + r1, col + j].IsMine)
                        count++;
                }
            return count;
        }
/// <summary>
/// Mở các ô xung quanh nếu số ô đã cắm cờ = số ô có mìn
/// </summary>
/// <param name="row"></param>
/// <param name="col"></param>
/// <returns>true nếu trúng mìn</returns>
public bool OpenAroundCell(int row, int col)
{

    int count = 0;
    int r1 = row == 0 ? 0 : -1;
    int c1 = col == 0 ? 0 : -1;
    int r2 = row == _Rows - 1 ? 1 : 2;
    int c2 = col == _Cols - 1 ? 1 : 2;

    for (int i=r1; i < r2; i++)
        for (int j = c1; j < c2; j++)
        {
            if (_cells[row + i, col + j].IsFlag)
                count++;
        }

    if (count == _cells[row, col].MinesAround)
    {
        for (int i = r1; i < r2; i++)
            for (int j = c1; j < c2; j++)
            {
                int r=row+i;
                int c=col+j;
                if (!_cells[r, c].IsFlag && !_cells[r, c].IsOpened)
                    if (OpenCell(r, c))
                        return true;
            }
    }
    return false;
}


    }
}
