using System;
using System.Linq;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class PitCorner : TileLayerBase
    {
        private readonly Player _player;

        public PitCorner(Rotation rotation, TileLocation loc, Player player)
            : base(rotation, loc.Through(loc.Plus(4, 4)))
        {
            _player = player;
        }

        protected override string TextureName => "Images/Tiles/bottomlesscorner";
        public override int Layer => 1;

        public override void Update(TimeSpan delta)
        {
            if (Locations.Any(x => x.Equals(new TileLocation(_player.EnemyTrackingPosition))))
                World.NavigateToScene("GameOver");
        }
    }
}
