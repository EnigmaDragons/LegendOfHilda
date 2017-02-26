using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Enemies;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class SmallChestRoom : IScene
    {
        private Room _room;
        private Player _player;
        private List<IVisualAutomaton> _enemies = new List<IVisualAutomaton>();

        public void Init()
        {
            World.PlayMusic("Music/dungeon1");

            _room = new Room();
            _room.Add(new TileWalker(0, 14, 0, 16).Get(x => new Tile("tile1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 10, 0, 1).Get(x => new Tile("wall", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 1, 12).Get(x => new Tile("wall", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 2, 12).Get(x => new Tile("wall", x, Rotation.Right)));
            _room.Add(new TileWalker(1, 10, 14, 1).Get(x => new Tile("wall", x, Rotation.Down)));

            _room.Add(new TileWalker(0, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 14, 1).Get(x => new Tile("wallcorner", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Right)));
            _room.Add(new TileWalker(12, 1, 14, 1).Get(x => new Tile("wallcorner", x, Rotation.Down)));

            _room.Add(new TileWalker(3, 8, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 2, 10).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(10, 1, 3, 10).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(2, 8, 12, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 12, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));
            _room.Add(new TileWalker(10, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Right)));
            _room.Add(new TileWalker(10, 1, 12, 1).Get(x => new Tile("walledgecorner", x, Rotation.Down)));

            _room.Add(new TileWalker(11, 1, 12, 2).Get(x => new Tile("itemplatform", x, Rotation.Up)));
            _room.Add(new TileWalker(11, 1, 12, 2).Get(x => new Obj("pot", x)));
            _room.Add(new Obj("chest-closed", new TileLocation(11, 2)));
            _room.Add(new Door(DoorState.Open, new TileLocation(0, 7), Rotation.Left, "MainHallRoom"));

            _player = new Player(new Vector2(TileSize.Int * 2, TileSize.Int * 7));
            _enemies.Add(new SpearEnemy(_player, new TileLocation(7, 7), new List<TileLocation> { new TileLocation(4, 7), new TileLocation(7, 7) }));
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
