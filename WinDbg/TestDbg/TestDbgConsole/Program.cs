using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDbg;

namespace TestDbgConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p = new Point2D();
            p.X = 100;
            p.Y = 100;
            Point2D o = new Point2D();
            o.X = 100;
            o.Y = 100;
            int result = p.CompareTo(o);
            Console.WriteLine(result);
            //
            Point2DClass q = new Point2DClass();
            q.X = 100;
            q.Y = 100;
            Point2DClass w = new Point2DClass();
            w.X = 100;
            w.Y = 100;
            result = q.CompareTo(w);
            Console.WriteLine(result);
        }
    }
}
