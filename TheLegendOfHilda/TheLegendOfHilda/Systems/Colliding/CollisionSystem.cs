using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Colliding
{
    /* Determines if two Collideable bodies have collided. If they have, it emits a
    // CollisionEvent. This is used by ExplosionSystem to create explosion
    // particles, but it could be used by a SoundSystem to play an explosion
    // sound, etc..
    //
    // Uses a fairly rudimentary 2D partition system, but performs reasonably well.*/
    class CollisionSystem : ISystem<Keys>
    {
        public Keys RequiredComponents { get; }
            = Keys.Position | Keys.Renderable;

        readonly CollisionGrid _grid;

        public CollisionSystem(RenderTarget target, CollisionSettings settings)
        {
            var targetSize = target.GetBounds();
            var size = targetSize.Normalize(settings.Partitions + 1);

            _grid = new CollisionGrid(settings.Partitions, size);
        }

        public void Update(IEngine engine)
        {
            _grid.Reset();
            Collect(engine);
            EmitCollisions(engine);
        }

        void Collect(IEngine engine)
        {
            foreach (var entity in engine.Entities(RequiredComponents))
            {
                var collideable = entity.Component<Collideable>();
                var position = entity.Component<Position>();
                var location = new Point2D(position.X, position.Y);
                
                _grid.Partition(entity, location, collideable.Radius);
            }
        }

        void EmitCollisions(IEngine engine)
        {
            foreach (var collision in _grid.GetCollisions())
            {
                engine.Emit(new CollisionEvent(collision.Item1, collision.Item2));
            }
        }
    }
}