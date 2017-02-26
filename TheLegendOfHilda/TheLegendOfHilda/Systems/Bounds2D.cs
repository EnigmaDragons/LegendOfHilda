using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Systems
{
    struct Bounds2D
    {
        public static Bounds2D Zero { get; } = new Bounds2D(0, 0);
        public double Length => Math.Sqrt(Width * Width + Height * Height);
        public int Area => Width * Height;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Bounds2D(int width, int height)
        {
            Width = width;
            Height = height;
        }


        public Bounds2D Normalize(int scale)
        {
            return new Bounds2D(Width / scale, Height / scale);
        }

        public static Bounds2D operator -(Bounds2D left, Bounds2D right)
        {
            return new Bounds2D(left.Width - right.Width, left.Height - right.Height);
        }
    }
}
