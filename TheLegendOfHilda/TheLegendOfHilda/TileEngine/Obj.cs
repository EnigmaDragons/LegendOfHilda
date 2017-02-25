using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public class Obj
    {
        public TileLocation Location { get; }
        private readonly string _textureName;

        public Obj(string textureName, TileLocation location)
        {
            Location = location;
            _textureName = "Images/Objects/" + textureName;
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
