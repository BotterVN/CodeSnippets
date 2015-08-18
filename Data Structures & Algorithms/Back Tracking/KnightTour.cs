using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class Program
    {
        static int N = 5;
        static int cells = 1;
        static int[,] map;        
        static int[] dx = { -2, -1, 1, 2,  2,  1, -1, -2 };
        static int[] dy = {  1,  2, 2, 1, -1, -2, -2, -1 };        

        static void Main(string[] args)
        {        
            int xStart = 0;
            int yStart = 0;

            map = new int[N, N];
            InitMap(xStart, yStart);
            
            Move(xStart, yStart);            
        }        
        static void Move(int row, int col)
        {
            for (int i = 0; i < 8; i++)
            {                
                var nx = row + dx[i];
                var ny = col + dy[i];
                
                if (nx > -1 && nx < N && ny > -1 && ny < N)
                {                    
                    if (map[nx, ny] == 0)
                    {
                        map[nx, ny] = ++cells;                        
                        if (cells == N * N)
                        {                            
                            PrintMatrix();
                            Console.ReadLine();                            
                        }
                        
                        Move(nx, ny);
                        
                        cells--;
                        map[nx, ny] = 0;
                    }
                }
            }
        }
        static void InitMap(int xStart, int yStart)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 0;
                }
            }

            map[xStart, yStart] = 1;
        }
        static void PrintMatrix()
        {
            for (int i = 0; i < N; i++)
            {                
                for (int j = 0; j < N; j++)
                {
                    if (map[i, j] < 10) Console.Write(" {0} ", map[i, j]);
                    else Console.Write("{0} ", map[i, j]);                    
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
