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

        public T[] FindSpanningTree()
        {
            var spanningTree = new T[_vertices.Length];
            var spanningTreeIdx = new int[_vertices.Length];
            var isVisited = Enumerable.Repeat(false, _vertices.Length).ToArray();

            var curVertexIdx = 0;
            spanningTreeIdx[curVertexIdx++] = 0;
            isVisited[0] = true;

            while(curVertexIdx < _vertices.Length)
            {
                var minimumNodeIdx = -1;
                var minDist = Int32.MaxValue;

                for (int i = 0; i < curVertexIdx; i++)
                {
                    for (int j = 0; j < _vertices.Length; j++)
                    {
                        if (!isVisited[j] && _edges[i, j] != -1 && _edges[i, j] < minDist)
                        {
                            minimumNodeIdx = j;
                            minDist = _edges[i, j];
                        }
                    }
                }

                spanningTreeIdx[curVertexIdx++] = minimumNodeIdx;
                isVisited[minimumNodeIdx] = true;
            }

            return spanningTreeIdx.Select(idx => _vertices[idx]).ToArray();
        }
    }
}
