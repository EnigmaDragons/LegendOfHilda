using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Items
{
    public class SmallChest : TileLayerBase
    {
        public override int Layer => 2;

        private ChestState _state = ChestState.Closed;

        public SmallChest(TileLocation loc)
            : base(Rotation.Up, loc) { }

        protected override string TextureName => "Images/Objects/chest-" + _state.ToString().ToLower();
    }

    public enum ChestState
    {
        Closed,
        Open,
    }
}
