using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Graph
{
    public class DirectedGraph<T>
    {
        Dictionary<T, HashSet<T>> _edges = new Dictionary<T, HashSet<T>>();
        List<T> _vertices = new List<T>();

        public void AddVertex(T vertex)
        {
            if (_vertices.Contains(vertex))
                throw new Exception("this element was in graph");
            else
                _vertices.Add(vertex);
        }

        public void AddEdge(T fromVertex, T toVertex)
        {
            if (!_vertices.Contains(fromVertex))
                throw new Exception(string.Format("element {0} doesn't exist in graph", fromVertex));

            if(!_vertices.Contains(toVertex))
                throw new Exception(string.Format("element {0} doesn't exist in graph", toVertex));

            var descendants = (_edges.ContainsKey(fromVertex)) ? _edges[fromVertex] : (new HashSet<T>());
            _edges[fromVertex] = descendants;

            descendants.Add(toVertex);
        }

        public int IndexOf(T node)
        {
            return _vertices.IndexOf(node);
        }

        public T[] GetVertices()
        {
            return _vertices.ToArray();
        }

        public bool[,] GetEdges()
        {
            var edges = new bool[_vertices.Count, _vertices.Count];
            for (int i = 0; i < _vertices.Count; i++)
            {
                for (int j = 0; j < _vertices.Count; j++)
                {
                    if (HasEdge(_vertices[i], _vertices[j]))
                        edges[i, j] = true;
                    else
                        edges[i, j] = false;
                }
            }

            return edges;
        }

        public bool HasEdge(T fromVertex, T toVertex)
        {
            return (_edges.ContainsKey(fromVertex) && _edges[fromVertex].Contains(toVertex));
        }

        public T[] GetAllDescendants(T node)
        {
            return _edges[node].ToArray();
        }

        public bool IsReachable(T fromVertex, T toVertex)
        {
            bool[] visited = Enumerable.Repeat(false, _vertices.Count).ToArray();

            var vertices = GetVertices();
            bool[,] edges = GetEdges();

            var fromIdx = IndexOf(fromVertex);
            var toIdx = IndexOf(toVertex);

            var traversingNodes = new Queue<int>();
            traversingNodes.Enqueue(fromIdx);

            while (traversingNodes.Count > 0)
            {
                var curNode = traversingNodes.Dequeue();
                visited[curNode] = true;

                for (int i = 0; i < vertices.Length; i++)
                {
                    if (!visited[i] && edges[curNode, i])
                    {
                        if (i == toIdx)
                            return true;
                        else
                            traversingNodes.Enqueue(i);
                    }
                }
            }

            return false;
        }
    }
}
