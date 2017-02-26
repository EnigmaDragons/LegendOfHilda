using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using TheLegendOfHilda.Enemies;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class EntranceRoom : IScene
    {
        private Room _room;
        private Player _player;
        private List<IVisualAutomaton> _enemies = new List<IVisualAutomaton>();

        public void Init()
        {
            World.PlayMusic("Music/dungeon1");

            _room = new Room();
            _room.Add(new TileWalker(0, 16, 0, 16).Get(x => new Tile("tile1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 12, 0, 1).Get(x => new Tile("wall", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 1, 12).Get(x => new Tile("wall", x, Rotation.Left)));
            _room.Add(new TileWalker(14, 1, 2, 12).Get(x => new Tile("wall", x, Rotation.Right)));
            _room.Add(new TileWalker(1, 12, 14, 1).Get(x => new Tile("wall", x, Rotation.Down)));

            _room.Add(new TileWalker(0, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 14, 1).Get(x => new Tile("wallcorner", x, Rotation.Left)));
            _room.Add(new TileWalker(14, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Right)));
            _room.Add(new TileWalker(14, 1, 14, 1).Get(x => new Tile("wallcorner", x, Rotation.Down)));

            _room.Add(new TileWalker(3, 10, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 2, 10).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 3, 10).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(2, 10, 12, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 12, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Right)));
            _room.Add(new TileWalker(12, 1, 12, 1).Get(x => new Tile("walledgecorner", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 2, 12, 2).Get(x => new Tile("itemplatform", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 2, 12, 2).Get(x => new Obj("pot", x)));
            _room.Add(new Tile("dungeonentrance", new TileLocation(6, 12), Rotation.Up));
            _room.Add(new Door(DoorState.Blocked, new TileLocation(7, 0), Rotation.Up, "MainHallRoom"));

            _player = new Player(new Vector2(TileSize.Int * 7, TileSize.Int * 12));
            _enemies.Add(new SpearEnemy(_player, new TileLocation(8, 5), new List<TileLocation> { new TileLocation(8, 5), new TileLocation(8, 10) }));
        }

        public void Update(TimeSpan delta)
        {
            _player.Update(delta);
            _enemies.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            _room.Draw(new Vector2());
            _player.Draw();
            _enemies.ForEach(x => x.Draw(Vector2.Zero));
        }
    }
}
