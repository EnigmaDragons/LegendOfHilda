using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public class Room : IVisualAutomaton
    {
        private readonly List<ITileLayer> _tiles = new List<ITileLayer>();

        public void Add(ITileLayer tile)
        {
            _tiles.Add(tile);
        }

        public void Add(IEnumerable<ITileLayer> tiles)
        {
            _tiles.AddRange(tiles);
        }

        public bool Exist(TileLocation loc)
        {
            return _tiles.Any(x => x.Location.Equals(loc));
        }

        public ITileLayer Get(TileLocation loc)
        {
            return _tiles.First(x => x.Location.Equals(loc));
        }

        public void Update(TimeSpan delta)
        {
            _tiles.OrderBy(x => x.Layer).ForEach(x => x.Update(delta));
        }

        public void Draw(Vector2 offset)
        {
            _tiles.OrderBy(x => x.Layer).ForEach(x => x.Draw(offset));
        }
    }
}