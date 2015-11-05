using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbg
{
    public struct Point2D : IComparable
    {
        public int X;
        public int Y;

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Point2D otherPoint2D = (Point2D)obj;
            if (X > otherPoint2D.X)
                return 1;
            if (X < otherPoint2D.X)
                return -1;
            if (Y > otherPoint2D.Y)
                return 1;
            if (Y < otherPoint2D.Y)
                return -1;
            return 0;
        }
    }

    public class Point2DClass : IComparable
    {
        public int X;
        public int Y;

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Point2DClass otherPoint2D = (Point2DClass)obj;
            if (X > otherPoint2D.X)
                return 1;
            if (X < otherPoint2D.X)
                return -1;
            if (Y > otherPoint2D.Y)
                return 1;
            if (Y < otherPoint2D.Y)
                return -1;
            return 0;
        }
    }

}
