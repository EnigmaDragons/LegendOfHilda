using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheLegendOfHilda.TileEngine
{
    public class TileLocation
    {
        public int Column { get; }
        public int Row { get; }

        public TileLocation(Vector2 pixelLoc) : this((int)pixelLoc.X / TileSize.Int, (int)pixelLoc.Y / TileSize.Int) {}

        public TileLocation(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public List<TileLocation> Through(TileLocation end)
        {
            var locs = new List<TileLocation>();
            var xCondition = Column <= end.Column;
            var yCondition = Row <= end.Row;
            for(var x = Column; xCondition ? x < end.Column + 1 : x > end.Column - 1 ; x = xCondition ? x+1 : x-1)
                for (var y = Row; yCondition ? y < end.Row + 1 : y > end.Row - 1; y = yCondition ? y + 1 : y -1)
                    locs.Add(new TileLocation(x, y));
            return locs;
        }

        public Vector2 Position => new Vector2(Column * TileSize.Int, Row * TileSize.Int);

        protected bool Equals(TileLocation other)
        {
            return Column == other.Column && Row == other.Row;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TileLocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Column*397) ^ Row;
            }
        }

        public TileLocation Plus(int x, int y)
        {
            return new TileLocation(Column + x, Row + y);
        }

        public TileLocation Plus(int x, int y, Rotation rotation)
        {
            //var a = Column + (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Down) ? x : y) * (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Left) ? 1 : -1);
            //var b = Row + (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Down) ? y : x) * (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Right) ? 1 : -1);
            return new TileLocation(Column + (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Down) ? y : x), Row + (rotation.Equals(Rotation.Up) || rotation.Equals(Rotation.Down) ? x : y));
            //return new TileLocation(a, Row + y);
        }

        public override string ToString()
        {
            return $"{Column}, {Row}";
        }
    }
}
