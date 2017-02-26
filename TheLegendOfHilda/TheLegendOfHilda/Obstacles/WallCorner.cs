using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class WallCorner : TileLayerBase
    {
        public WallCorner(Rotation rotation, TileLocation loc) 
            : base(rotation, loc.Through(loc.Plus(2, 2)), true) { }

        protected override string TextureName => "Images/Tiles/wallcorner";
        public override int Layer => 1;
    }
}
