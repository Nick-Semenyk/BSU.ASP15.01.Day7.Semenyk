using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearchCollection<T>:IEnumerable<T>,ICollection<T>
    {
        private struct HashCodeMatch
        {
            public T Item { get; }
            public int HashCode { get; }

            public HashCodeMatch(T item)
            {
                Item = item;
                HashCode = item.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                if (!(obj is T))
                {
                    return false;
                }
                T item = (T) obj;
                return item.Equals(Item);
            }

            public bool Equals(HashCodeMatch match)
            {
                return match.Equals(Item);
            }
        }

        private List<HashCodeMatch> items;

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public BinarySearchCollection()
        {
            items = new List<HashCodeMatch>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < items.Count; i++)
                yield return items[i].Item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            HashCodeMatch match = new HashCodeMatch(item);
            int insertIndex;
            BinarySearch(item, out insertIndex);
            items.Insert(insertIndex, new HashCodeMatch(item));
        }

        public void Clear()
        {
            items = new List<HashCodeMatch>();
        }

        public bool Contains(T item)
        {
            int index = BinarySearch(item);
            return index != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0 || arrayIndex >= array.Count())
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((array.Count() - arrayIndex) < this.Count)
            {
                throw new ArgumentException();
            }
            for (int i = arrayIndex; i < arrayIndex + this.Count; i++)
            {
                array[i] = items[i - arrayIndex].Item;
            }
        }

        public bool Remove(T item)
        {
            int index = BinarySearch(item);
            if (index > 0)
                items.RemoveAt(index);
            return index != -1;
        }

        private int BinarySearch(T item)
        {
            int result = -1;
            int minIndex = 0;
            int maxIndex = items.Count;
            //int halfCount;// = (minIndex + maxIndex)/ 2;
            int hashCode = item.GetHashCode();
            while (true)
            {
                int halfCount = (minIndex + maxIndex) / 2;
                if (items[halfCount].HashCode < hashCode)
                {
                    minIndex = halfCount;
                }
                if (items[halfCount].HashCode > hashCode)
                {
                    maxIndex = halfCount;
                }
                if (items[halfCount].HashCode == hashCode)
                {
                    //need to call Equals for each item with same hash code
                    HashCodeMatch searchMatch = items[halfCount];
                    int halfCountOriginal = halfCount;
                    while(searchMatch.HashCode == hashCode)
                    {
                        if (searchMatch.Equals(item))
                        {
                            result = halfCount;
                            return result;
                        }
                        halfCount--;
                        searchMatch = items[halfCount];
                    }
                    halfCount = halfCountOriginal + 1;
                    searchMatch = items[halfCount];
                    while (searchMatch.HashCode == hashCode)
                    {
                        if (searchMatch.Equals(item))
                        {
                            result = halfCount;
                            return result;
                        }
                        halfCount++;
                        searchMatch = items[halfCount];
                    }
                    return result;
                }
                if (minIndex == maxIndex)
                {
                    return result;
                }
            }
            return result;
        }

        private void BinarySearch(T item, out int insertIndex)
        {
            int result = -1;
            insertIndex = 0;
            int minIndex = 0;
            int maxIndex = items.Count;
            int oldhalfCount = int.MaxValue;
            //int halfCount;// = (minIndex + maxIndex)/ 2;
            int hashCode = item.GetHashCode();
            if (items.Count == 0)
            {
                insertIndex = 0;
                return;
            }
            while (true)
            {
                int halfCount = (minIndex + maxIndex) / 2;
                if (halfCount == oldhalfCount)
                {
                    if (items[halfCount].HashCode < hashCode)
                    {
                        insertIndex = maxIndex;
                    }
                    if (items[halfCount].HashCode > hashCode)
                    {
                        insertIndex = minIndex;
                    }
                    return;
                }
                oldhalfCount = halfCount;
                if (items[halfCount].HashCode < hashCode)
                {
                    minIndex = halfCount;
                }
                if (items[halfCount].HashCode > hashCode)
                {
                    maxIndex = halfCount;
                }
                if (items[halfCount].HashCode == hashCode)
                {
                    insertIndex = halfCount;
                    return;
                }
                if (minIndex == maxIndex)
                {
                    insertIndex = maxIndex;
                    return;
                }
            }
        }
    }
}
