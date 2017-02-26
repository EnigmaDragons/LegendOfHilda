using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Items
{
    public class SmallChest : ITileLayer
    {
        public int Layer => 2;
        public TileLocation Location { get; }

        private ChestState _state = ChestState.Closed;
        private string _spriteBaseName = "Images/Objects/chest-";

        public SmallChest(TileLocation loc)
        {
            Location = loc;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Vector2 offset)
        {
            World.Draw(_spriteBaseName + _state.ToString().ToLower(), Location.Position + offset);
        }
    }

    public enum ChestState
    {
        Closed,
        Open,
    }
}
