using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FibonacciSequence;

namespace FibonacciConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciNumber f = new FibonacciNumber(25);
            foreach (long number in f)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}
