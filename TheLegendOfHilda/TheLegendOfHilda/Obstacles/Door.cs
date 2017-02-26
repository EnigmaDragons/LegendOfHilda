using System;
using System.Linq;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Obstacles
{
    public class Door : TileLayerBase
    {
        private DoorState _state;
        private readonly Player _player;

        public string ConnectedRoom { get; set; }
        public override int Layer => 1;

        public Door(DoorState state, TileLocation location, Rotation rotation, string connectedRoom, Player player)
            : base(rotation, location.Through(location.Plus(1, 1)))
        {
            ConnectedRoom = connectedRoom;
            _player = player;
            _state = state;
        }

        public override void Update(TimeSpan delta)
        {
            var playerLoc = new TileLocation(_player.EnemyTrackingPosition);
            if (Locations.Any(x => x.Equals(playerLoc)))
                World.NavigateToScene(ConnectedRoom);
        }

        protected override string TextureName => "Images/Tiles/door-" + _state.ToString().ToLower();
    }

    public enum DoorState
    {
        Open,
        Locked,
        Blocked,
        Unlocked,
    }
}
