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
    }
}
