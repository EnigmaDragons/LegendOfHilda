using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class MainHallRoom : IScene
    {
        private Player _player;
        private Room _room;
        private List<IVisualAutomaton> _enemies = new List<IVisualAutomaton>();

        public void Init()
        {
            _player = new Player(new Vector2(TileSize.Int * 7, TileSize.Int * 16));

            _room = new Room();
            _room.Add(new TileWalker(0, 16, 0, 20).Get(x => new Tile("tile1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 5, 0, 1).Get(x => new Wall(Rotation.Up, x)));
            _room.Add(new TileWalker(9, 5, 0, 1).Get(x => new Wall(Rotation.Up, x)));
            _room.Add(new TileWalker(0, 1, 2, 6).Get(x => new Wall(Rotation.Left, x)));
            _room.Add(new TileWalker(0, 1, 10, 8).Get(x => new Wall(Rotation.Left, x)));
            _room.Add(new TileWalker(14, 1, 2, 6).Get(x => new Wall(Rotation.Right, x)));
            _room.Add(new TileWalker(14, 1, 10, 8).Get(x => new Wall(Rotation.Right, x)));
            _room.Add(new TileWalker(2, 5, 18, 1).Get(x => new Wall(Rotation.Down, x)));
            _room.Add(new TileWalker(9, 5, 18, 1).Get(x => new Wall(Rotation.Down, x)));

            _room.Add(new TileWalker(0, 1, 0, 1).Get(x => new WallCorner(Rotation.Up, x)));
            _room.Add(new TileWalker(0, 1, 18, 1).Get(x => new WallCorner(Rotation.Left, x)));
            _room.Add(new TileWalker(14, 1, 0, 1).Get(x => new WallCorner(Rotation.Right, x)));
            _room.Add(new TileWalker(14, 1, 18, 1).Get(x => new WallCorner(Rotation.Down, x)));

            _room.Add(new TileWalker(3, 10, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 3, 14).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(13, 1, 3, 14).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(3, 10, 17, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 17, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));
            _room.Add(new TileWalker(13, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Right)));
            _room.Add(new TileWalker(13, 1, 17, 1).Get(x => new Tile("walledgecorner", x, Rotation.Down)));            
            _room.Add(new Door(DoorState.Locked, new TileLocation(7, 0), Rotation.Up, "TimTestScene", _player));
            _room.Add(new Door(DoorState.Open, new TileLocation(7, 18), Rotation.Down, "EntranceRoom", _player));
            _room.Add(new Door(DoorState.Open, new TileLocation(0, 8), Rotation.Left, "GameOver", _player));
            _room.Add(new Door(DoorState.Open, new TileLocation(14, 8), Rotation.Right, "SmallChestRoom", _player));

            _room.Add(new Tile("itemplatform", new TileLocation(2, 16), Rotation.Up));
            _room.Add(new Tile("itemplatform", new TileLocation(2, 17), Rotation.Up));
            _room.Add(new Tile("itemplatform", new TileLocation(3, 17), Rotation.Up));
            _room.Add(new Tile("itemplatform", new TileLocation(13, 16), Rotation.Up));
            _room.Add(new Tile("itemplatform", new TileLocation(13, 17), Rotation.Up));
            _room.Add(new Tile("itemplatform", new TileLocation(12, 17), Rotation.Up));
            _room.Add(new Obj("Pot", new TileLocation(2, 16)));
            _room.Add(new Obj("Pot", new TileLocation(2, 17)));
            _room.Add(new Obj("Pot", new TileLocation(3, 17)));
            _room.Add(new Obj("Pot", new TileLocation(13, 16)));
            _room.Add(new Obj("Pot", new TileLocation(13, 17)));
            _room.Add(new Obj("Pot", new TileLocation(12, 17)));
        }

        public void Update(TimeSpan delta)
        {
            _room.Update(delta);
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
