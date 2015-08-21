using Botter.CodeSnippets.DSA.DataStructure;
using Botter.CodeSnippets.DSA.DataStructure.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Tests
{
    [TestClass]
    public class TestList
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

        [TestMethod]
        public void TestStack()
        {
            var st = new Stack<int>();
            for (int i = 0; i < 10; i++)
            {
                st.Push(i);
            }

            Assert.AreEqual(st.Top(), 9);

            Assert.AreEqual(st.Pop(), 9);
            Assert.AreEqual(st.Top(), 8);

            while (!st.IsEmpty())
                st.Pop();

            try
            {
                var t = st.Top(); // should raise Exception here
                Assert.IsTrue(false);
            }
            catch (Exception)
            {
                // should be here
            }            
        }

        [TestMethod]
        public void TestQueue()
        {
            var st = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                st.EnQueue(i);
            }

            Assert.AreEqual(st.Top(), 0);

            Assert.AreEqual(st.DeQueue(), 0);
            Assert.AreEqual(st.Top(), 1);

            while (!st.IsEmpty())
                st.DeQueue();

            try
            {
                var t = st.Top(); // should raise Exception here
                Assert.IsTrue(false);
            }
            catch (Exception)
            {
                // should be here
            }
        }
    }
}
