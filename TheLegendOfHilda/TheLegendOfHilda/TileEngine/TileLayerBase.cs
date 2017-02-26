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
        //private List<TileLocation> Blocking { get; set; } = new List<TileLocation> { };

        public TileLayerBase(Rotation rotation, TileLocation loc)
            : this(rotation, new List<TileLocation> { loc }) { }

        public TileLayerBase(Rotation rotation, List<TileLocation> locs, bool blocking = false)
        {
            Rotation = rotation;
            Location = locs.First();
            Locations = locs;
            //if (blocking)
                //Locations.ForEach(x => Blocking.Add(x));
            if (blocking)
                Locations.ForEach(x => ReallyStupidPositionTracker.Instance.IBlock(new AxisAlignedBoundingBox(x.Position.X, x.Position.Y, TileSize.Int, TileSize.Int)));
        }

        public virtual void Update(TimeSpan delta)
        {
        }

        public virtual void Draw(Vector2 offset)
        {
            World.DrawRotated(TextureName, Location.Position + offset, Rotation.Value);

            /*foreach(var loc in Blocking)
            {
                var rect = new Rectangle();
                rect.X = (int)((loc.Column * TileSize.Int) * World.Scale);
                rect.Y = (int)((loc.Row * TileSize.Int) * World.Scale);
                rect.Width = (int)(32 * World.Scale);
                rect.Height = (int)(32 * World.Scale);
                World.DrawRectangle(rect, Color.FromNonPremultiplied(255,255,255,50));
            }*/
        }
    }
}
