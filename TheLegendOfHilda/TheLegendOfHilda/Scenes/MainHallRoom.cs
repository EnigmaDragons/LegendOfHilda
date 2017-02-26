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
    public class MainHallRoom : IScene
    {
        private Room _room;
        private Player _player;
        private List<IVisualAutomaton> _enemies = new List<IVisualAutomaton>();

        public void Init()
        {
            _room = new Room();
            _room.Add(new TileWalker(0, 16, 0, 20).Get(x => new Tile("tile1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 12, 0, 1).Get(x => new Tile("wall", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 1, 16).Get(x => new Tile("wall", x, Rotation.Left)));
            _room.Add(new TileWalker(14, 1, 2, 16).Get(x => new Tile("wall", x, Rotation.Right)));
            _room.Add(new TileWalker(1, 12, 18, 1).Get(x => new Tile("wall", x, Rotation.Down)));

            _room.Add(new TileWalker(0, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 1, 18, 1).Get(x => new Tile("wallcorner", x, Rotation.Left)));
            _room.Add(new TileWalker(14, 1, 0, 1).Get(x => new Tile("wallcorner", x, Rotation.Right)));
            _room.Add(new TileWalker(14, 1, 18, 1).Get(x => new Tile("wallcorner", x, Rotation.Down)));

            _room.Add(new TileWalker(3, 10, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 2, 14).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 3, 14).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(2, 10, 16, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 16, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Right)));
            _room.Add(new TileWalker(12, 1, 16, 1).Get(x => new Tile("walledgecorner", x, Rotation.Down)));

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

            _room.Add(new Door(DoorState.Locked, new TileLocation(7, 0), Rotation.Up, "TimTestScene"));
            _room.Add(new Door(DoorState.Open, new TileLocation(7, 18), Rotation.Down, "EntranceRoom"));
            _room.Add(new Door(DoorState.Open, new TileLocation(0, 8), Rotation.Left, "OgreChestRoom"));
            _room.Add(new Door(DoorState.Open, new TileLocation(14, 8), Rotation.Right, "TimTestScene"));
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
