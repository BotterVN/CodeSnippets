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
        [TestMethod]
        public void TestCreateGraph()
        {
            var graph = new DirectedGraph<char>();
            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('D');
            graph.AddVertex('E');
            graph.AddEdge('A', 'B');
            graph.AddEdge('A', 'D');
            graph.AddEdge('D', 'B');
            graph.AddEdge('D', 'E');
            graph.AddEdge('E', 'B');

            Assert.IsTrue(graph.HasEdge('D', 'B'));
            Assert.IsTrue(graph.HasEdge('E', 'B'));
            Assert.IsFalse(graph.HasEdge('A', 'E'));

            Assert.IsTrue(graph.IsReachable('A', 'D'));
            Assert.IsTrue(graph.IsReachable('A', 'E'));
            Assert.IsFalse(graph.IsReachable('B', 'E'));
        }
    }
}
