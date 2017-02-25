using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Linq;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class Room1 : IScene
    {
        private Room _room;

        public void Init()
        {
            _room = new Room();
            _room.Add(new TileWalker(1, 15, 1, 15).Get(x => new Tile("tile1", x)));
            _room.Add(new TileWalker(0, 1, 0, 15).Get(x => new Tile("ext1", x)));
            _room.Add(new TileWalker(0, 15, 0, 1).Get(x => new Tile("ext1", x)));
            _room.Add(new TileWalker(15, 1, 0, 15).Get(x => new Tile("ext1", x)));
            _room.Add(new TileWalker(0, 15, 1, 1).Get(x => new Tile("wall-u", x)));
            _room.Add(new Tile("dungeonentrance", new TileLocation(5, 11)));
            _room.Add(new Tile("wallcorner-dl", new TileLocation(0, 11)));
            _room.Add(new Tile("wallcorner-ul", new TileLocation(0, 0)));
            _room.Add(new Tile("wallcorner-dr", new TileLocation(12, 11)));
            _room.Add(new Tile("wallcorner-ur", new TileLocation(12, 0)));
            _room.Add(new TileWalker(3, 5, 3, 5).Get(x => new Obj("pot", x)));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            World.DrawBrackgroundColor(Color.Black);
            _room.Draw(new Vector2());
        }
    }
}
