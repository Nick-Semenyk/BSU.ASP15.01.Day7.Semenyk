using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearch;
using NUnit.Framework;

namespace BinarySearchCollection.Tests
{
    [TestFixture]
    public class BinarySearchCollectionTests
    {
        [TestCase(new object[] { 1, 2, 3, 4, 5 }, 5, Result = true)]
        [TestCase(new object[] { 1, 2, 3, 4, 5 }, 6, Result = false)]
        [TestCase(new object[] { 1, 2, 3, 4, 5 }, "U", Result = false)]
        [TestCase(new object[] { null, 2, null, 4, 5 }, null, Result = true)]
        public bool ContainmentTests(object[] items, object testValue)
        {
            BinarySearchCollection<object> collection = new BinarySearchCollection<object>();
            foreach(object item in items)
            {
                collection.Add(item);
            }
            return collection.Contains(testValue);
        }
        
        [Test]
        public void ExceptionsTests()
        {
            object[] items = new object[] {1, 2, 3, 4, 5};
            BinarySearchCollection<object> collection = new BinarySearchCollection<object>();
            foreach (object item in items)
            {
                collection.Add(item);
            }
            try
            {
                collection.CopyTo(null, 10);
            }
            catch (ArgumentNullException)
            {
                
            }
            try
            {
                collection.CopyTo(items, -10);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            try
            {
                collection.CopyTo(items, 6);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            try
            {
                collection.CopyTo(items, 4);
            }
            catch (ArgumentException)
            {

            }
        }
    }
}
