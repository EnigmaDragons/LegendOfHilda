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
            _room.Add(Enumerable.Range(0, 12).SelectMany(x => Enumerable.Range(0, 12).Select(y => new Tile("tile1", new TileLocation(x, y)))));
            _room.Add(new Tile("dungeonentrance", new TileLocation(5, 11)));
            _room.Add(Enumerable.Range(3, 5).SelectMany(x => Enumerable.Range(3, 5).Select(y => new Obj("pot", new TileLocation(x, y)))));
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
