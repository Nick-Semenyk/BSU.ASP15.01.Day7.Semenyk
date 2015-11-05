using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using QueueLibrary;

namespace CustomQueueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> q = new CustomQueue<int>(20);
            for (int i = 0; i<20; i++)
            {
                q.Enqueue(i);
            }
            for (int i = 0; i<10; i++)
                Console.WriteLine(q.Dequeue());
            for (int i = 100; i < 110; i++)
            {
                q.Enqueue(i);
            }

            Console.WriteLine("Enqueued");
            foreach (int a in q)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine(q.Peek());
        }
    }
}
