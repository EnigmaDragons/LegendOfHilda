using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Collision
{
    public class AxisAlignedBoundingBox
    {
        public float Top { get; set; }
        public float Left { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Vector2 Position
        {
            get { return new Vector2(Top, Left); }
            set
            {
                Top = value.X;
                Left = value.Y;
            }
        }

        public AxisAlignedBoundingBox(float top, float left, float width, float height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public AxisAlignedBoundingBox(Vector2 location, Vector2 size)
        {
            Top = location.X;
            Left = location.Y;
            Width = size.X;
            Height = size.Y;
        }

        public Rectangle ToRect()
        {
            return new Rectangle((int)Top, (int)Left, (int)Width, (int)Height);
        }
    }
}
