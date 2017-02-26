using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class Wall : TileLayerBase
    {
        public Wall(Rotation rotation, TileLocation loc) 
            : base(rotation, loc.Through(loc.Plus(1, 0, rotation)), true) { }

        protected override string TextureName => "Images/Tiles/wall";
        public override int Layer => 1;
    }
}
