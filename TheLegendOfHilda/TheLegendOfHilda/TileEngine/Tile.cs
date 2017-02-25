using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public class Tile : ITileLayer
    {
        public int Layer => 1;

        public TileLocation Location { get; }

        private readonly string _textureName;
        
        public Tile(string textureName, TileLocation location)
        {
            Location = location;
            _textureName = "Images/Tiles/" + textureName;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Vector2 offset)
        {
            World.Draw(_textureName, Location.Position + offset);
        }
    }
}