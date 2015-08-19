using Botter.CodeSnippets.DSA.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Tests
{
    [TestClass]
    public class TestLinkedList
    {
        [TestMethod]
        public void TestLinkedListOperators()
        {
            var lst = new LinkedList<int>();
            lst.Append(1);
            lst.Append(2);
            lst.Append(4);
            lst.Append(5);
            lst.Insert(2, 3);
            Assert.AreEqual(lst.Get(2).Content, 3);
            Assert.AreEqual(lst.Get(3).Content, 4);

            lst.Remove(0);
            Assert.AreEqual(lst.Get(0).Content, 2);

            Assert.AreEqual(lst.ToString(), "2 3 4 5");
        }
    }
}
