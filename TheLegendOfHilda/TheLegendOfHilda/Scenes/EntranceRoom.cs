using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class EntranceRoom : IScene
    {
        private Room _room;
        private Player _player;

        public void Init()
        {
            _room = new Room();
            _room.Add(new TileWalker(0, 28, 0, 20).Get(x => new Tile("tile1", x, Rotation.Up)));
            _room.Add(new TileWalker(3, 12, 1, 1).Get(x => new Tile("wall", x, Rotation.Up)));
            _room.Add(new TileWalker(1, 1, 2, 12).Get(x => new Tile("wall", x, Rotation.Left)));
            _room.Add(new TileWalker(15, 1, 3, 12).Get(x => new Tile("wall", x, Rotation.Right)));
            _room.Add(new TileWalker(2, 12, 15, 1).Get(x => new Tile("wall", x, Rotation.Down)));
            _room.Add(new TileWalker(1, 1, 1, 1).Get(x => new Tile("wallcorner", x, Rotation.Up)));
            _room.Add(new TileWalker(1, 1, 15, 1).Get(x => new Tile("wallcorner", x, Rotation.Left)));
            _room.Add(new TileWalker(15, 1, 1, 1).Get(x => new Tile("wallcorner", x, Rotation.Right)));
            _room.Add(new TileWalker(15, 1, 15, 1).Get(x => new Tile("wallcorner", x, Rotation.Down)));
            _room.Add(new TileWalker(3, 2, 13, 2).Get(x => new Obj("pot", x)));
            _room.Add(new Door(DoorState.Blocked, new TileLocation(8, 1)));
            _player = new Player(new Vector2(100, 100));
        }

        public void Update(TimeSpan delta)
        {
            _player.Update(delta);
        }

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            _room.Draw(new Vector2());
            _player.Draw();
        }
    }
}
