using System;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.Physics
{
    public static class Physics
    {
        public static Vector2 MoveTowards(Vector2 source, Vector2 destination, float distance)
        {
            var direction = destination - source;
            direction.Normalize();
            return source + distance * direction;
        }

        public static Vector2 Direction(Vector2 source, Vector2 destination)
        {
            var direction = destination - source;
            direction.Normalize();
            return direction;
        }
    }
}
