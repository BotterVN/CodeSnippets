using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Graph
{
    public class Edge
    {
        public char Source { get; set; }
        public char Sink { get; set; }
        public int Capacity { get; set; }
        public Edge REdge { get; set; }
    }

    public class FordFulkerson
    {
        Dictionary<char,List<Edge>> _adjacencyList = new Dictionary<char,List<Edge>>();
        Dictionary<Edge, int> _flows = new Dictionary<Edge, int>();

        public void AddEdge(char source, char sink, int capacity)
        {
            var edge = new Edge() { Source = source, Sink = sink, Capacity = capacity };
            var redge = new Edge() { Source = sink, Sink = source, Capacity = 0 };
            edge.REdge = redge;
            redge.REdge = edge;

            if (!_adjacencyList.ContainsKey(source))
                _adjacencyList[source] = new List<Edge>();

            if (!_adjacencyList.ContainsKey(sink))
                _adjacencyList[sink] = new List<Edge>();

            _adjacencyList[source].Add(edge);
            _adjacencyList[sink].Add(redge);
            _flows[edge] = 0;
            _flows[redge] = 0;
        }

        public List<Edge> GetPath(char source, char sink, List<Edge> path)
        {
            if (source == sink)
                return path;

            foreach (var edge in _adjacencyList[source])
            {
                if (_flows[edge] < edge.Capacity && !path.Contains(edge))
                {
                    var passingPath = path.ToList();
                    passingPath.Add(edge);
                    var result = GetPath(edge.Sink, sink, passingPath);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        public List<Edge> GetPath(char source, char sink)
        {
            return GetPath(source, sink, new List<Edge>());
        }

        public int CalculateMaxTraffic(char source, char sink)
        {
            var path = GetPath(source, sink);

            while (path != null)
            {
                var minTrafficFlow = path.Min(edge => edge.Capacity - _flows[edge]);

                // update traffic flow
                foreach (var edge in path)
                {
                    _flows[edge] += minTrafficFlow;
                    _flows[edge.REdge] -= minTrafficFlow;
                }

                path = GetPath(source, sink);
            }

            return _adjacencyList[source].Sum(edge => _flows[edge]);
        }
    }
}
