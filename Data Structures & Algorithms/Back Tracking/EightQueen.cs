namespace Botter.CodeSnippets.DSA.BackTracking
{
    class Program
    {
        static int MaxWidth = 8;
        static int[,] _map;
        static Stack<int> _stack;
        static int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
        static int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

        static void Main(string[] args)
        {
            _stack = new Stack<int>();
            _map = new int[,] 
            {{0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0}};

            Try(0);

            while (_stack.Count > 0)
                Console.Write("{0} ",_stack.Pop());

            Console.Read();
        }

        public static void Try(int row)
        {
            if (row == MaxWidth) return;

            var pos = 0;
            if (row == _stack.Count - 1)
            {
                pos = _stack.Pop();
                RemoveAQueen(row, pos);
                pos += 1;
            }

            var canPlace = false;
            for (var i = pos; i < MaxWidth; i++)
            {
                if (_map[i, row] == 0)
                {
                    canPlace = true;
                    PlaceAQueen(row, i);
                    _stack.Push(i);
                    Try(row + 1);
                    break;
                }
            }

            if (!canPlace)
            {
                Try(row - 1);
            }
        }

        public static void Update(int row, int col, int w)
        {
            _map[col, row] += w;
            for (int i = 0; i < 8; i++)
            {
                var nx = col + dx[i];
                var ny = row + dy[i];

                while (nx > -1 && nx < 8 && ny > -1 && ny < 8)
                {
                    _map[nx, ny] += w;
                    nx += dx[i];
                    ny += dy[i];
                }
            }
        }

        public static void PlaceAQueen(int row, int col)
        {
            Update(row, col, 1);
        }

        public static void RemoveAQueen(int row, int col)
        {
            Update(row, col, -1);
        }
    }
}