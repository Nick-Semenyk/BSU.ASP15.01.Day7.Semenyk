using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearch;

namespace BinarySearchTests
{
    [TestFixture]
    public class BinarySearchTest
    {
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 0, Result = 0)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 2, Result = 2)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 10, Result = 6)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 100, Result = -1)]
        public int IntegerDelegateTests(int[] collection, int item)
        {
            return collection.BinarySearch(item, (i1, i2) => i1 - i2);
        }

        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 0, Result = 0)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 2, Result = 2)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 10, Result = 6)]
        [TestCase(new int[] { 0, 0, 2, 3, 6, 8, 10, 10, 11, 20 }, 100, Result = -1)]
        public int IntegerComparerTests(int[] collection, int item)
        {
            return collection.BinarySearch(item, Comparer<int>.Default);
        }
        

        [TestCase(null, null, null, ExpectedException = typeof(NullReferenceException))]
        [TestCase(new object[] {1,2}, null, null, ExpectedException = typeof(ArgumentNullException))]
        [TestCase(null, int.MaxValue, null, ExpectedException = typeof(NullReferenceException))]
        public int NullTests(object[] collection, object item, IComparer<object> comparer  )
        {
            return collection.BinarySearch(item, comparer);
        }
    }
}
