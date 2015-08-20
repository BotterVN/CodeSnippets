using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Algorithms.AStar
{
    public class Solver<T>
    {
        private INode<T> _originNode;
        private INode<T> _target;

        public Solver(INode<T> origin, INode<T> target)
        {
            _originNode = origin;
            _target = target;
        }

        public INode<T> Solve()
        {
            var nodeSet = new List<INode<T>>();
            nodeSet.Add(_originNode);
            var hasNewState = true;

            INode<T> newNode = null;
            do 
            {
                var minDistance = int.MaxValue;
                foreach (var node in nodeSet)
                {
                    if (!node.IsChecked && (node.Distance + node.Heuristic) <= minDistance)
                    {
                        minDistance = node.Distance + node.Heuristic;
                        newNode = node;
                        hasNewState = true;
                    }
                }

                var genNodes = newNode.GenerateNextNodes();
                foreach (var node in genNodes)
                {
                    if (node.IsEqual(_target))
                        return node;
                    else
                    {
                        var canAdd = true;
                        foreach (var n in nodeSet)
                        {
                            if (node.IsEqual(n))
                            {
                                canAdd = false;
                                break;
                            }
                        }

                        if (canAdd) nodeSet.Add(node);
                    }
                }

                newNode.IsChecked = true;
            } while (hasNewState);

            return null;
        }
    }
}
