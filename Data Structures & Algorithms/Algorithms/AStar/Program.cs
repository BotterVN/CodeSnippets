using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Algorithms.AStar
{
    class Program
    {
        static void Main(string[] args)
        {
            var target = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            var origin = new int[,] { { 1, 3, 6 }, { 4, 2, 0 }, { 7, 5, 8 } };

            var targetState = new State(target);
            var originState = new State(origin);

            INode<State> pOrigin = new PuzzleNode(targetState, originState);
            INode<State> pTarget = new PuzzleNode(targetState, targetState);

            Solver<State> solver = new Solver<State>(pOrigin, pTarget);
            var result = solver.Solve();

            do
            {
                Console.WriteLine(result.Content.ToDisplayString() + Environment.NewLine);
                result = result.Parent;
            } while (result != null);

            Console.Read();
        }
    }
}
