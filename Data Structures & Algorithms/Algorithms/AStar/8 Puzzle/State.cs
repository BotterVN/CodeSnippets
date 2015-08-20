using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Algorithms.AStar
{
    public class State
    {
        public static int[] _dx = { -1, 0, 1, 0 };
        public static int[] _dy = { 0, -1, 0, 1 };
        public int[,] Cells { get; set; }

        public State(int[,] cells)
        {
            Cells = cells;
        }

        /// <summary>
        /// clone a new state from the current state
        /// </summary>
        /// <returns></returns>
        private State Clone()
        {
            var result = new State(new int[3,3]);
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    result.Cells[row, col] = Cells[row, col];
                }
            }

            return result;
        }

        public List<State> GenerateNextMoves()
        {
            var result = new List<State>();
            
            // look for zero position
            var zr = 0;
            var zc = 0;
            for (int row = 0; row < 3; row++)
			{
			    for (int col = 0; col < 3; col++)
                    if (Cells[row, col] == 0) 
                    {
                        zr = row;
                        zc = col;
                        break;
                    }
			}

            // generate new states
            for (int i = 0; i < 4; i++)
            {
                var nc = _dx[i] + zc;
                var nr = _dy[i] + zr;

                // if a valid state is generated
                if (nc >= 0 && nc < 3 && nr >= 0 && nr < 3)
                {
                    var state = this.Clone();
                    state.Cells[zr, zc] = Cells[nr, nc];
                    state.Cells[nr, nc] = 0;
                    result.Add(state);
                }
            }

            return result;
        }

        /// <summary>
        /// calculate distance from one state to another state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetDistance(State state)
        {
            var result = 9;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (this.Cells[row, col] == state.Cells[row, col]) 
                        result--;
                }
            }
            return result;
        }

        /// <summary>
        /// display the state
        /// </summary>
        /// <returns></returns>
        public String ToDisplayString()
        {
            var result = "";

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    result += Cells[row, col] + " ";
                }
                result += Environment.NewLine;
            }

            return result;
        }
    }
}
