using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class Wall : TileLayerBase
    {
        public Wall(Rotation rotation, TileLocation loc) 
            : base(rotation, loc.Through(loc.Plus(2, 1)), true) { }

        protected override string TextureName => "Images/Tiles/wall";
        public override int Layer => 1;
    }
}
