using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Graph
{
    class BFS<T>
    {
        DirectedGraph<T> _graph;

        public BFS(DirectedGraph<T> graph)
        {
            _graph = graph;
        }

        public List<T> GetPath(T fromNode, T toNode)
        {
            var fromIdx = _graph.IndexOf(fromNode);
            var toIdx = _graph.IndexOf(toNode);

            var vertices = _graph.GetVertices();
            var edges = _graph.GetEdges();

            var visited = Enumerable.Repeat(false, vertices.Length).ToArray();
            var prevNodes = Enumerable.Repeat(-1, vertices.Length).ToArray();

            var traverseNodes = new Queue<int>();
            traverseNodes.Enqueue(fromIdx);

            while(traverseNodes.Count > 0)
            {
                var curNode = traverseNodes.Dequeue();
                visited[curNode] = true;

                for (int i = 0; i < vertices.Length; i++)
                {
                    if(!visited[i] && edges[curNode, i])
                    {
                        prevNodes[i] = curNode;

                        if (i == toIdx)
                        {
                            // I found you
                            var path = new List<T>();
                            var j = toIdx;
                            while(prevNodes[j] != -1)
                            {
                                path.Add(vertices[j]);
                                j = prevNodes[j];
                            }

                            if (j != fromIdx)
                                throw new Exception("your algorithm is broken");
                            path.Add(vertices[j]);

                            path.Reverse();
                            return path;
                        }
                        else
                        {
                            traverseNodes.Enqueue(i);
                        }
                    }
                }
            }

            return null;
        }
    }
}
