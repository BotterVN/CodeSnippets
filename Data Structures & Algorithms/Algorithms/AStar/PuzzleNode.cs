using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Algorithms.AStar
{
    public class PuzzleNode : INode<State>
    {
        private State _target;

        public State Content { get; set; }
        public INode<State> Parent { get; private set; }
        public int Distance { get; set; }
        public int Heuristic { get; set; }
        public bool IsChecked { get; set; }

        public PuzzleNode(INode<State> parent, State target, State content)
        {
            Parent = parent;
            _target = target;
            Content = content;

            Distance = parent.Distance + 1;
            Heuristic = content.GetDistance(target);
        }

        public PuzzleNode(State target, State content)
        {
            _target = target;
            Content = content;

            Distance = 0;
            Heuristic = content.GetDistance(target);
        }
        
        public List<INode<State>> GenerateNextNodes()
        {
            var lstState = Content.GenerateNextMoves();
            var result = new List<INode<State>>();

            foreach (var state in lstState)
            {
                var node = new PuzzleNode(this, _target, state);
                result.Add(node);
            }

            return result;
        }


        public bool IsEqual(INode<State> node)
        {
            return Content.GetDistance(node.Content) == 0;
        }
    }
}
