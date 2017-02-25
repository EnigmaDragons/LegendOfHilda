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
        private readonly Rotation _rotation;
        
        public Tile(string textureName, TileLocation location, Rotation rotation)
        {
            Location = location;
            _textureName = "Images/Tiles/" + textureName;
            _rotation = rotation;
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Vector2 offset)
        {
            World.DrawRotated(_textureName, Location.Position + offset, _rotation.Value);
        }
    }
}