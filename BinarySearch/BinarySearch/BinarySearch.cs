using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class BinarySearch
    {
        public static int Search<T>(this ICollection<T> collection, T searchItem, IComparer<T> comparer)
        {
            return Search(collection, searchItem, comparer.Compare);
        }

        public static int Search<T>(this ICollection<T> collection, T searchItem, Func<T,T,int> comparer )
        {
            if (collection == null)
                throw new NullReferenceException();
            if (searchItem == null || comparer == null)
                throw new ArgumentNullException();
            int minIndex = 0;
            int maxIndex = collection.Count;
            int oldhalfCount = int.MaxValue;
            int result = -1;
            if (collection.Count == 0)
                return result;
            while (true)
            {
                int halfCount = (minIndex + maxIndex) / 2;
                if (halfCount == oldhalfCount)
                {
                    return result;
                }
                oldhalfCount = halfCount;
                switch (Math.Sign(comparer(collection.ElementAt(halfCount), searchItem)))
                {
                    case -1:
                        minIndex = halfCount;
                        break;
                    case 1:
                        maxIndex = halfCount;
                        break;
                    case 0:
                        T equalItem = collection.ElementAt(halfCount);
                        while (comparer(equalItem, searchItem) == 0)
                        {
                            halfCount--;
                            equalItem = collection.ElementAt(halfCount);
                        }
                        return halfCount + 1;
                }
                if (minIndex == maxIndex)
                {
                    return result;
                }
            }
        }
    }
}
