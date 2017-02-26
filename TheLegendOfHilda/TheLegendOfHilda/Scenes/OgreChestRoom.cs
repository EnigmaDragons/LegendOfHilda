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

            _room.Add(new TileWalker(3, 9, 2, 1).Get(x => new Tile("walledge", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 2, 10).Get(x => new Tile("walledge", x, Rotation.Left)));
            _room.Add(new TileWalker(12, 1, 4, 8).Get(x => new Tile("walledge", x, Rotation.Right)));
            _room.Add(new TileWalker(2, 9, 12, 1).Get(x => new Tile("walledge", x, Rotation.Down)));

            _room.Add(new TileWalker(2, 1, 2, 1).Get(x => new Tile("walledgecorner", x, Rotation.Up)));
            _room.Add(new TileWalker(2, 1, 12, 1).Get(x => new Tile("walledgecorner", x, Rotation.Left)));

            _room.Add(new Obj("chest-closed", new TileLocation(2, 7)));
            _room.Add(new Door(DoorState.Open, new TileLocation(14, 7), Rotation.Right, "MainHallRoom", _player));

            _player = new Player(new Vector2(16 * 12, 8 * 12));
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
