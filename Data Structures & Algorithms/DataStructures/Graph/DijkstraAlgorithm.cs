using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Graph
{
    class Node
    {
        public Node()
        {
            IsVisited = false;
            Distance = -1;
            PrevNode = -1;
        }

        public bool IsVisited { get; set; }
        public int Distance { get; set; }
        public int PrevNode { get; set; }
    }

    public class DijkstraAlgorithm<T>
    {
        T[] _vertices;
        int[,] _edges;

        public DijkstraAlgorithm(T[] vertices, int[,] edges)
        {
            _vertices = vertices;
            _edges = edges;
        }

        public T[] FindPath(int fromIdx, int toIdx)
        {
            var nodes = new Node[_vertices.Length];
            for (int i = 0; i < _vertices.Length; i++)
                nodes[i] = new Node();

            var curNode = fromIdx;
            nodes[curNode].Distance = 0;

            while(curNode != -1)
            {
                nodes[curNode].IsVisited = true;

                for (int i = 0; i < _vertices.Length; i++)
                {
                    if(!nodes[i].IsVisited && _edges[curNode, i] != -1)
                    {
                        if(i == toIdx)
                        {
                            // I found you
                            var path = new List<T>();
                            nodes[toIdx].PrevNode = curNode;
                            var iterNode = toIdx;
                            while(nodes[iterNode].PrevNode != -1)
                            {
                                path.Add(_vertices[iterNode]);
                                iterNode = nodes[iterNode].PrevNode;
                            }

                            if (iterNode != fromIdx)
                                throw new Exception("your algorithm is broken");

                            path.Add(_vertices[fromIdx]);
                            path.Reverse();

                            return path.ToArray();
                        }
                        else if(nodes[i].Distance == -1 || nodes[curNode].Distance + _edges[curNode, i] < nodes[i].Distance)
                        {
                            nodes[i].Distance = nodes[curNode].Distance + _edges[curNode, i];
                            nodes[i].PrevNode = curNode;
                        }
                    }
                }

                curNode = -1;
                var minDistance = -1;
                for (int i = 0; i < _vertices.Length; i++)
                {
                    if (!nodes[i].IsVisited && nodes[i].Distance > 0 && (curNode == -1 || nodes[i].Distance < minDistance))
                    {
                        curNode = i;
                        minDistance = nodes[i].Distance;
                    }
                }
            }

            return null;
        }
    }
}
