using Botter.CodeSnippets.DSA.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Tests
{
    [TestClass]
    public class TestSort
    {
        int[] _arr;
        int[] _expectedArr;

        [TestInitialize]
        public void Init()
        {
            _arr = new int[] { 1, 3, 5, 9, 8, 7, 6, 4, 2 };
            _expectedArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            var sort = new BubleSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestHeapSort()
        {
            var sort = new HeapSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestInsertSort()
        {
            var sort = new InsertSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestInterchangeSort()
        {
            var sort = new InterchangeSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestQuickSort()
        {
            var sort = new QuickSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestSelectionSort()
        {
            var sort = new SelectionSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }

        [TestMethod]
        public void TestShakeSort()
        {
            var sort = new ShakerSort();
            sort.Sort(_arr);
            CollectionAssert.AreEqual(_arr, _expectedArr);
        }
    }
}
