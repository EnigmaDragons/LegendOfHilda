﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Scenes
{
    public class OgreChestRoom : IScene
    {
        private Room _room;
        private Player _player;
        private List<IVisualAutomaton> _enemies = new List<IVisualAutomaton>();

        public void Init()
        {
            _player = new Player(new Vector2(TileSize.Int * 12, TileSize.Int * 7));

            _room = new Room();
            _room.Add(new TileWalker(0, 16, 0, 16).Get(x => new Tile("tile1", x, Rotation.Up, false)));
            //_room.Add(new TileWalker(0, 1, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 0, 1).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(17, 11, 0, 20).Get(x => new Tile("ext1", x, Rotation.Up)));
            //_room.Add(new TileWalker(0, 28, 17, 3).Get(x => new Tile("ext1", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 12, 0, 1).Get(x => new Wall(Rotation.Up, x)));
            _room.Add(new TileWalker(0, 1, 2, 12).Get(x => new Wall(Rotation.Left, x)));
            _room.Add(new TileWalker(14, 1, 2, 5).Get(x => new Wall(Rotation.Right, x)));
            _room.Add(new TileWalker(14, 1, 9, 5).Get(x => new Wall(Rotation.Right, x)));
            _room.Add(new TileWalker(2, 12, 14, 1).Get(x => new Wall(Rotation.Down, x)));

            _room.Add(new TileWalker(0, 1, 0, 1).Get(x => new WallCorner(Rotation.Up, x)));
            _room.Add(new TileWalker(0, 1, 14, 1).Get(x => new WallCorner(Rotation.Left, x)));
            _room.Add(new TileWalker(11, 1, 0, 1).Get(x => new PitCorner(Rotation.Right, x, _player)));
            _room.Add(new TileWalker(11, 1, 11, 1).Get(x => new PitCorner(Rotation.Down, x, _player)));

            _room.Add(new TileWalker(3, 8, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 3, 10).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(13, 1, 5, 6).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(3, 8, 13, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 13, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));
            
            _room.Add(new TileWalker(11, 1, 2, 3).Get(x => new Tile("bottomlessedge", x, Rotation.Right)));
            _room.Add(new TileWalker(11, 1, 11, 3).Get(x => new Tile("bottomlessedge", x, Rotation.Right)));
            _room.Add(new TileWalker(11, 3, 4, 1).Get(x => new Tile("bottomlessedge", x, Rotation.Up)));
            _room.Add(new TileWalker(11, 3, 11, 1).Get(x => new Tile("bottomlessedge", x, Rotation.Down)));

            _room.Add(new Obj("chest-closed", new TileLocation(2, 7)));
            _room.Add(new Door(DoorState.Open, new TileLocation(14, 7), Rotation.Right, "MainHallRoom", _player));
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
