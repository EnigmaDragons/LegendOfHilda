
using MonoDragons.Core.Collision;
using MonoDragons.Core.Physics;

namespace TheLegendOfHilda.TileEngine
{
    public class Tile : TileLayerBase
    {
        private readonly string _textureName;

        public Tile(string textureName, TileLocation location, Rotation rotation, bool blocking = false)
            : base(rotation, location)
        {
            _textureName = textureName;
        }

        protected override string TextureName => "Images/Tiles/" + _textureName;
        public override int Layer => 1;
    }
}