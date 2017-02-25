using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class Door : ITileLayer
    {
        private DoorState _state;

        public int Layer => 1;
        public TileLocation Location { get; }

        public Door(DoorState state, TileLocation location)
        {
            Location = location;
            _state = state;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Vector2 offset)
        {
            World.Draw("Images/Tiles/door-" + _state.ToString().ToLower(), Location.Position + offset);
        }
    }

    public enum DoorState
    {
        Open,
        Locked,
        Blocked,
        Unlocked,
    }
}
