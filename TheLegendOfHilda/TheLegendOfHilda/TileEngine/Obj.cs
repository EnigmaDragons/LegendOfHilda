
namespace TheLegendOfHilda.TileEngine
{
    public class Obj : TileLayerBase
    {
        private readonly string _textureName;

        public Obj(string textureName, TileLocation location)
            : base (Rotation.Up, location)
        {
            _textureName = textureName;
        }

        protected override string TextureName => "Images/Objects/" + _textureName;
        public override int Layer => 2;
    }
}
