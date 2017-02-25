using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public class Room : IVisualAutomaton
    {
        private readonly List<Tile> _tiles = new List<Tile>();
        private readonly List<Obj> _objs = new List<Obj>();

        public void Add(Tile tile)
        {
            _tiles.Add(tile);
        }

        public void Add(IEnumerable<Tile> tiles)
        {
            _tiles.AddRange(tiles);
        }

        public void Add(Obj obj)
        {
            _objs.Add(obj);
        }

        public void Add(IEnumerable<Obj> objs)
        {
            _objs.AddRange(objs);
        }

        public bool Exist(TileLocation loc)
        {
            return _tiles.Any(x => x.Location.Equals(loc));
        }

        public Tile Get(TileLocation loc)
        {
            return _tiles.First(x => x.Location.Equals(loc));
        }

        public void Update(TimeSpan delta)
        {
            _tiles.ForEach(x => x.Update(delta));
            _objs.ForEach(x => x.Update(delta));
        }

        public void Draw(Vector2 offset)
        {
            _tiles.ForEach(x => x.Draw(offset));
            _objs.ForEach(x => x.Draw(offset));
        }
    }
}