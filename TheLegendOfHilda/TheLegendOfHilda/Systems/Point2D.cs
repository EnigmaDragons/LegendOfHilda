using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Systems
{
    class Point2D
    {
        public static Point2D Zero { get; } = new Point2D(0, 0);
        public double Length => Math.Sqrt(X * X + Y * Y);

        public int X { get; private set; }
        public int Y { get; private set; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point2D Normalize(int scale)
        {
            return new Point2D(X / scale, Y / scale);
        }

        public static Point2D operator -(Point2D left, Point2D right)
        {
            return new Point2D(left.X - right.X, left.Y - right.Y);
        }
    }
}
