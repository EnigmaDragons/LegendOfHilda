using System;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Inputs
{
    public struct Direction
    {
        public static Direction None = new Direction(HorizontalDirection.None, VerticalDirection.None);

        public HorizontalDirection HDir { get; }
        public VerticalDirection VDir { get; }
        
        public Direction(Vector2 vector2) : this(
            (HorizontalDirection)(vector2.X == 0 ? 0 : vector2.X / Math.Abs(vector2.X)),
            (VerticalDirection)(vector2.Y == 0 ? 0 : vector2.Y / Math.Abs(vector2.Y))) {}

        public Direction(HorizontalDirection hDir, VerticalDirection vDir)
        {
            HDir = hDir;
            VDir = vDir;
        }
    }
}
