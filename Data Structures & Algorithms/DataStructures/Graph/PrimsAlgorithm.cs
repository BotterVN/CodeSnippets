using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Graph
{
    public class PrimsAlgorithm<T>
    {
        T[] _vertices;
        int[,] _edges;

        public PrimsAlgorithm(T[] vertices, int[,] edges)
        {
            _vertices = vertices;
            _edges = edges;
        }

        public int[,] FindSpanningTree()
        {
            var spanningTree = new int[_vertices.Length, _vertices.Length];
            for (int i = 0; i < _vertices.Length; i++)
            {
                for (int j = 0; j < _vertices.Length; j++)
                {
                    spanningTree[i, j] = -1;
                }
            }

            var isVisited = Enumerable.Repeat(false, _vertices.Length).ToArray();

            var traversedNodes = new List<int>();
            traversedNodes.Add(0);

            while (traversedNodes.Count < _vertices.Length)
            {
                var fromNode = -1;
                var toNode = -1;
                var minDist = Int32.MaxValue;

                foreach (var i in traversedNodes)
                {
                    for (int j = 0; j < _vertices.Length; j++)
                    {
                        if (!traversedNodes.Contains(j) && _edges[i, j] != -1 && _edges[i, j] < minDist)
                        {
                            fromNode = i;
                            toNode = j;
                            minDist = _edges[i, j];
                        }
                    }
                }

                spanningTree[fromNode, toNode] = minDist;
                spanningTree[toNode, fromNode] = minDist;

                traversedNodes.Add(toNode);
            }

            return spanningTree;
        }
    }
}
