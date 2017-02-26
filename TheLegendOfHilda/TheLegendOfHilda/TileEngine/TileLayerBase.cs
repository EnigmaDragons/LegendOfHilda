using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

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

        public TileLayerBase(Rotation rotation, List<TileLocation> locs)
        {
            Rotation = rotation;
            Location = locs.First();
            Locations = locs;
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
