using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class TimTestScene : IScene
    {
        private Room _room;
        private Player _player;

        public void Init()
        {
            World.PlayMusic("Music/dungeon1");

            _player = new Player(new Vector2(TileSize.Int * 7, TileSize.Int * 12));
            //_player = new Player(new Vector2(0, 0));

            _room = new Room();
            _room.Add(new TileWalker(0, 16, 0, 16).Get(x => new Tile("tile1", x, Rotation.Up, false)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));

            

            //_room.Add(new TileWalker(7, 1, 4, 1).Get(x => new Wall(Rotation.Up, x)));
            _room.Add(new TileWalker(4, 1, 4, 1).Get(x => new WallCorner(Rotation.Up, x)));
            //_room.Add(new TileWalker(4, 1, 7, 1).Get(x => new Wall(Rotation.Left, x)));
            _room.Add(new TileWalker(4, 1, 10, 1).Get(x => new WallCorner(Rotation.Left, x)));
            //_room.Add(new TileWalker(7, 1, 10, 1).Get(x => new Wall(Rotation.Down, x)));
            _room.Add(new TileWalker(10, 1, 10, 1).Get(x => new WallCorner(Rotation.Down, x)));
            //_room.Add(new TileWalker(10, 1, 7, 1).Get(x => new Wall(Rotation.Right, x)));
            _room.Add(new TileWalker(10, 1, 4, 1).Get(x => new WallCorner(Rotation.Right, x)));

            _room.Add(new TileWalker(6, 4, 4, 1).Get(x => new Wall(Rotation.Up, x)));
            _room.Add(new TileWalker(4, 1, 6, 4).Get(x => new Wall(Rotation.Left, x)));
            _room.Add(new TileWalker(6, 4, 10, 1).Get(x => new Wall(Rotation.Down, x)));
            _room.Add(new TileWalker(10, 1, 6, 4).Get(x => new Wall(Rotation.Right, x)));

            //_room.Add(new TileWalker(0, 1, 0, 1).Get(x => new WallCorner(Rotation.Up, x)));
            //_room.Add(new TileWalker(0, 1, 14, 1).Get(x => new WallCorner(Rotation.Left, x)));
            //_room.Add(new TileWalker(14, 1, 0, 1).Get(x => new WallCorner(Rotation.Right, x)));
            //_room.Add(new TileWalker(14, 1, 14, 1).Get(x => new WallCorner(Rotation.Down, x)));
        }

        public void Update(TimeSpan delta)
        {
            _room.Update(delta);
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
