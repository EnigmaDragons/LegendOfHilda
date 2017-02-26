using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Collision;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Physics;

namespace TheLegendOfHilda.TileEngine
{
    public abstract class TileLayerBase : ITileLayer
    {
        protected readonly Rotation Rotation;
        protected abstract string TextureName { get; }

        public abstract int Layer { get; }
        public TileLocation Location { get; }
        public List<TileLocation> Locations { get; }

        public TileLayerBase(Rotation rotation, TileLocation loc)
            : this(rotation, new List<TileLocation> { loc }) { }

        public TileLayerBase(Rotation rotation, List<TileLocation> locs, bool blocking = false)
        {
            Rotation = rotation;
            Location = locs.First();
            Locations = locs;
            if (blocking)
                Locations.ForEach(x => ReallyStupidPositionTracker.Instance.IBlock(new AxisAlignedBoundingBox(x.Position.X, x.Position.Y, TileSize.Int, TileSize.Int)));
        }

        public virtual void Update(TimeSpan delta)
        {
        }

        public virtual void Draw(Vector2 offset)
        {
            World.DrawRotated(TextureName, Location.Position + offset, Rotation.Value);
        }
    }
}
