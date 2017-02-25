using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLegendOfHilda.TileEngine
{
    public class TileWalker
    {
        private readonly int _xStart;
        private readonly int _xEnd;
        private readonly int _yStart;
        private readonly int _yEnd;

        public TileWalker(int xStart, int xEnd, int yStart, int yEnd)
        {
            _xStart = xStart;
            _xEnd = xEnd;
            _yStart = yStart;
            _yEnd = yEnd;
        }

        private IEnumerable<TileLocation> GetTiles()
        {
            return Enumerable.Range(_xStart, _xEnd)
                .SelectMany(x => Enumerable.Range(_yStart, _yEnd)
                    .Select(y => new TileLocation(x, y)));
        }

        public IEnumerable<ITileLayer> Get(Func<TileLocation, ITileLayer> func)
        {
            return GetTiles().Select(func);
        }
    }
}
