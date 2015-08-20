using Botter.CodeSnippets.DSA.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Tests
{
    [TestClass]
    public class TestGraph
    {
        DirectedGraph<char> _graph;

        [TestInitialize]
        public void InitGraph()
        {
            _graph = new DirectedGraph<char>();
            _graph.AddVertex('A');
            _graph.AddVertex('B');
            _graph.AddVertex('D');
            _graph.AddVertex('E');
            _graph.AddEdge('A', 'B');
            _graph.AddEdge('A', 'D');
            _graph.AddEdge('D', 'B');
            _graph.AddEdge('D', 'E');
            _graph.AddEdge('E', 'B');
        }

        [TestMethod]
        public void TestCreateGraph()
        {
            Assert.IsTrue(_graph.HasEdge('D', 'B'));
            Assert.IsTrue(_graph.HasEdge('E', 'B'));
            Assert.IsFalse(_graph.HasEdge('A', 'E'));

            Assert.IsTrue(_graph.IsReachable('A', 'D'));
            Assert.IsTrue(_graph.IsReachable('A', 'E'));
            Assert.IsFalse(_graph.IsReachable('B', 'E'));
        }

        [TestMethod]
        public void TestGraphAlgorithms()
        {
            var bfs = new BFS<char>(_graph);
            var path1 = bfs.GetPath('A', 'E');
            CollectionAssert.AreEqual(path1, new char[] { 'A', 'D', 'E' });

            var dfs = new DFS<char>(_graph);
            var path2 = dfs.GetPath('A', 'E');
            CollectionAssert.AreEqual(path2, new char[] { 'A', 'D', 'E' });
        }
    }
}
