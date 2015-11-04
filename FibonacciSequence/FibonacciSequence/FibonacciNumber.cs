using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence
{
    public class FibonacciNumber : IEnumerable<long>
    {
        private int count;

        public FibonacciNumber(int count)
        {
            this.count = count;
        }

        public IEnumerator<long> GetEnumerator()
        {
            long a = 1;
            long b = 0;
            long c = 0;
            for (int i = 0; i<count; i++)
            {
                yield return c;
                c = a + b;
                a = b;
                b = c;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
