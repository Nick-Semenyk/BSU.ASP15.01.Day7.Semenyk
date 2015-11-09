using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibrary
{
    public class CustomQueue<T>:IEnumerable<T>
    {
        private T[] queueElements;
        private int capacity;
        private int firstElementIndex;
        private int lastElementIndex;

        public int Count { get; private set; }

        public CustomQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive number");
            }
            queueElements = new T[capacity];
            Count = 0;
            this.capacity = capacity;
            firstElementIndex = 0;
            lastElementIndex = 0;
        }

        public void Enqueue(T item)
        {
            if (Count == capacity)
                throw new InvalidOperationException("Queue is full");
            if (lastElementIndex == capacity)
                lastElementIndex = 0;
            queueElements[lastElementIndex] = item;
            lastElementIndex++;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            if (firstElementIndex == capacity)
            {
                firstElementIndex = 0;
            }
            T result = queueElements[firstElementIndex];
            queueElements[firstElementIndex] = default(T);
            firstElementIndex++;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            return queueElements[firstElementIndex];
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(queueElements, firstElementIndex, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void RecreateArray()
        {
            T[] newArray = new T[capacity];
            for (int i = firstElementIndex; i<lastElementIndex; i++)
            {
                newArray[i - firstElementIndex] = queueElements[i];
            }
            //queueElements.CopyTo(newArray, firstElementIndex - 1);
            lastElementIndex = lastElementIndex - firstElementIndex;
            firstElementIndex = 0;
            queueElements = newArray;
        }

        private class QueueEnumerator:IEnumerator<T>
        {
            private int currentIndex;
            private int remainingCount;
            private int firstIndex;
            private int firstCount;
            private T[] queue;

            public T Current {
                get
                {
                    if (remainingCount > 0)
                    {
                        if (currentIndex == queue.Count())
                            currentIndex = 0;
                        return queue[currentIndex];
                    }
                    throw new InvalidOperationException();
                }
            }

            public QueueEnumerator(T[] array, int firstIndex, int count)
            {
                this.firstIndex = firstIndex;
                firstCount = count;
                currentIndex = firstIndex - 1;
                queue = array;
                remainingCount = count + 1;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                currentIndex++;
                remainingCount--;
                return remainingCount != 0;
            }

            public void Reset()
            {
                currentIndex = firstIndex - 1;
                remainingCount = firstCount + 1;
            }
        }
    }
}
