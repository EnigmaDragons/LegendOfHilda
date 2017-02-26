using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace TheLegendOfHilda.PlayerStuff
{
    public enum SwordState
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Sword
    {
        private string texture = @"Images\Objects\Sword";

        private Dictionary<SwordState, Vector2> offsets = GetOffsets();

        public static Dictionary<SwordState, Vector2> GetOffsets()
        {
            return new Dictionary<SwordState, Vector2>
            {
                {SwordState.Up, new Vector2(10, 6) },
                {SwordState.Down, new Vector2(19, 29) },
                {SwordState.Left, new Vector2(8, 19) },
                {SwordState.Right, new Vector2(24, 19) },
            };
        }

        public void Draw(Vector2 playerPosition, SwordState state)
        {
            World.DrawRotatedOnOrigin(texture, playerPosition + offsets[state], new Vector2(0, 3), GetRotation(state));
        }

        private float GetRotation(SwordState state)
        {
            if (state == SwordState.Up)
                return (float)(Math.PI * 1.5);
            if (state == SwordState.Down)
                return (float)(Math.PI * 0.5);
            if (state == SwordState.Left)
                return (float)(Math.PI);
            return 0;
        }
    }
}
