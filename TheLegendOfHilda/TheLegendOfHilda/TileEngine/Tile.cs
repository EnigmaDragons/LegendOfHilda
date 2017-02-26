
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
            if(blocking)
                base.Locations.ForEach(x => ReallyStupidPositionTracker.Instance.IBlock(new AxisAlignedBoundingBox(x.Position.X, x.Position.Y, TileSize.Int, TileSize.Int)));
        }

        protected override string TextureName => "Images/Tiles/" + _textureName;
        public override int Layer => 1;
    }
}