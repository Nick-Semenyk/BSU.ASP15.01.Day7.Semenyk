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

        public CustomQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive number");
            }
            queueElements = new T[capacity];
            this.capacity = capacity;
            firstElementIndex = 0;
            lastElementIndex = 0;
        }

        public void Enqueue(T item)
        {
            if (lastElementIndex == capacity)
            {
                if (firstElementIndex == 0)
                {
                    throw new InvalidOperationException("Queue is full");
                }
                else
                {
                    RecreateArray();
                }
            }
            queueElements[lastElementIndex] = item;
            lastElementIndex++;
        }

        public T Dequeue()
        {
            if (firstElementIndex == lastElementIndex)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T result = queueElements[firstElementIndex];
            queueElements[firstElementIndex] = default(T);
            firstElementIndex++;
            return result;
        }

        public T Peek()
        {
            if (firstElementIndex == lastElementIndex)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return queueElements[firstElementIndex];
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(queueElements);
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
            private T[] queue;

            public T Current {
                get
                {
                    if (currentIndex < queue.Count())
                        return queue[currentIndex];
                    throw new InvalidOperationException();
                }
            }

            public QueueEnumerator(T[] array)
            {
                currentIndex = -1;
                queue = array;
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
                return currentIndex < queue.Count();
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
