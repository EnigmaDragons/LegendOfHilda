
namespace TheLegendOfHilda.TileEngine
{
    public class Tile : TileLayerBase
    {
        private readonly string _textureName;

        public Tile(string textureName, TileLocation location, Rotation rotation)
            : base(rotation, location)
        {
            _textureName = textureName;
        }

        protected override string TextureName => "Images/Tiles/" + _textureName;
        public override int Layer => 1;
    }
}