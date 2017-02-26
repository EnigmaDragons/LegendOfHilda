using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Linq;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class Room1 : IScene
    {
        private Room _room;

        public void Init()
        {
            _room = new Room();
            _room.Add(new TileWalker(1, 13, 1, 13).Get(x => new Tile("tile1", x, Rotation.Up))); 
            _room.Add(new Tile("dungeonentrance", new TileLocation(5, 12), Rotation.Right));
            _room.Add(new TileWalker(3, 5, 3, 5).Get(x => new Obj("pot", x)));
            _room.Add(new TileWalker(0, 16, 0, 16).Get(x => new Tile("tile1", x, Rotation.Up)));
            _room.Add(new TileWalker(0, 14, 0, 1).Get(x => new Tile("wall", x, Rotation.Up)));
            _room.Add(new Tile("dungeonentrance", new TileLocation(5, 12), Rotation.Up));
            _room.Add(new Tile("wallcorner", new TileLocation(0, 0), Rotation.Up));
            _room.Add(new TileWalker(6, 5, 6, 5).Get(x => new Obj("pot", x)));
            _room.Add(new Door(DoorState.Blocked, new TileLocation(7, 0), Rotation.Up));
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
