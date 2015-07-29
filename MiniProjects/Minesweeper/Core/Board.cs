using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Board
    {
        private Cell[,] _cells;

        public int Width { get; set; }
        public int Height { get; set; }

        public Cell[,] Cells
        {
            get { return _cells; }
        }

        public Board(int rows = 8, int cols = 8, int numberOfMines = 20)
        {
            Width = rows;
            Height = cols;

            _cells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _cells[i, j] = new Cell { IsFlagged = false, IsOpened = false, Value = 0 };
                }
            }

            InitMines(numberOfMines);
            UpdateValues();
        }

        private void InitMines(int numberOfMines)
        {
            if (numberOfMines > Width * Height / 2)
                numberOfMines = Width * Height / 2;

            Random rnd = new Random();
            var n = 0;
            while (n < numberOfMines)
            {
                var r = rnd.Next(Height);
                var c = rnd.Next(Width);
                if (_cells[r, c].Value == 0)
                {
                    _cells[r, c].Value = -1;
                    n++;
                }
            }
        }

        private void UpdateValues()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_cells[i, j].Value == 0)
                        _cells[i, j].Value = CountSurround(i, j);
                }
            }
        }

        private int CountSurround(int row, int col)
        {
            var dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
            var dy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };

            var n = 0;

            for (int i = 0; i < 8; i++)
            {
                var sc = col + dx[i];
                var sr = row + dy[i];

                if (sc >= 0 && sc < Width && 
                    sr >= 0 && sr < Height && 
                    _cells[sr, sc].Value == -1)
                    n++;
            }

            return n;
        }

    }
}
