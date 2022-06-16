using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _023_Point
{
    internal class Point:IComparable<Point>
    {
        int x, y;

        public int getX() { return x; }
        public int getY() { return y; }
        public void setX(int x) { this.x = x; }
        public void setY(int y) { this.y = y; }

        public int CompareTo(Point point)
        {
            if (this.x > point.x)
                return 1;
            else if (this.x < point.x)
                return -1;
            else
            {
                if (this.y > point.y)
                    return 1;
                else if (this.y < point.y)
                    return -1;
                else
                    return 0;
            }
        }
        

        public Point(int x, int y) { this.x = x; this.y = y; }

    }
}
