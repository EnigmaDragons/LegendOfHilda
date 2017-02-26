using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;
using System.Collections;

namespace TheLegendOfHilda.Systems.Colliding
{
    class CollisionGrid
    {
        readonly List<IList<CollisionCandidate>> _inner = new List<IList<CollisionCandidate>>();
        readonly int _partitions;
        readonly int _capacity;
        readonly int _unit;

        public CollisionGrid(int partitions, Bounds2D _size)
        {
            _partitions = partitions;
            _capacity = _size.Area;
            _unit = _size.Width;
        }

        public void Reset()
        {
            _inner.Clear();
            _inner.Capacity = _capacity;
        }

        public void Partition(IEntity entity, Point2D location, int radius)
        {
            var candidate = new CollisionCandidate(entity, location, radius);

            var left = (candidate.Position.X - candidate.Radius) / _capacity;
            var top = (candidate.Position.Y - candidate.Radius) / _capacity;
            var right = (candidate.Position.X + candidate.Radius) / _capacity;
            var bottom = (candidate.Position.Y + candidate.Radius) / _capacity;

            var cells = new int[]
            {
                left + top * _unit,
                right + top * _unit,
                left + bottom * _unit,
                right + bottom * _unit,
            };

            _inner[cells[0]].Add(candidate);
            if (cells[0] != cells[1]) _inner[cells[1]].Add(candidate);
            if (cells[1] != cells[2]) _inner[cells[2]].Add(candidate);
            if (cells[2] != cells[3]) _inner[cells[3]].Add(candidate);
        }

        public IEnumerable<Tuple<IEntity, IEntity>> GetCollisions()
        {
            foreach (var candidates in _inner)
            {
                foreach (var first in candidates)
                {
                    foreach (var second in candidates)
                    {
                        if (first.Entity == second.Entity) continue;

                        if (first.CollidesWith(second))
                            yield return new Tuple<IEntity, IEntity>(first.Entity, second.Entity);
                    }
                }
            }
        }
        
        struct CollisionCandidate
        {
            public IEntity Entity { get; }
            public Point2D Position { get; }
            public int Radius { get; }

            public CollisionCandidate(IEntity entity, Point2D position, int radius)
            {
                Entity = entity;
                Position = position;
                Radius = radius;
            }

            public bool CollidesWith(CollisionCandidate other)
            {
                var length = (Position - other.Position).Length;
                return length < Radius + other.Radius;
            }
        }
    }
}
