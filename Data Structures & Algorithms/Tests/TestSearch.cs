using Botter.CodeSnippets.DSA.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotterDSA.Tests
{
    [TestClass]
    public class TestSearch
    {
        int[] _arr;
        int _searchValue = 3;
        int _searchIndex = 2;

        [TestInitialize]
        public void Init()
        {
            _arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        }

        [TestMethod]
        public void TestBinarySearch()
        {
            var search = new BinarySearch();
            Assert.AreEqual(search.Search(_arr, _searchValue), _searchIndex);
        }

        [TestMethod]
        public void TestLinearSearch()
        {
            var search = new LinearSearch();
            Assert.AreEqual(search.Search(_arr, _searchValue), _searchIndex);
        }

        [TestMethod]
        public void TestBruteForceSearch()
        {
            var search = new BruteForce();
            Assert.AreEqual(search.Search("this is a string", "is"), 2);
        }
    }
}
