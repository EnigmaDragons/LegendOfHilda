using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Spawning
{
    class SpawningSystem : ISystem<Keys>
    {
        public Keys RequiredComponents { get; }
            //= Keys.Position | Keys.Opacity | Keys.Renderable;

        RenderTarget _target;

        public SpawningSystem(RenderTarget target, SpawningSettings settings)
        {
            _target = target;
        }

        public void Update(IEngine engine)
        {
            var size = _target.GetBounds();

            //ComponentReference<Collideable> collideable;
            //engine.Entities.Each<Collideable>()
            //var entity = 
        }
    }

    /*
class SpawnSystem : public System<SpawnSystem> {
public:
  explicit SpawnSystem(RenderTarget &target, int count) 
    : size(target.getSize()), count(count) {}

  void update(EntityManager &es, EventManager &events, TimeDelta dt) override {
    int c = 0;
    ComponentHandle<Collideable> collideable;
    es.each<Collideable>([&](Entity entity, Collideable&) { ++c; });

    for (int i = 0; i < count - c; i++) {
      var entity = es.create();

      // Mark as collideable (explosion particles will not be collideable).
      collideable = entity.assign<Collideable>(r(10, 5));

      // "Physical" attributes.
      entity.assign<Body>(
        Vector2f(r(size.x), r(size.y)),
        Vector2f(r(100, -50), r(100, -50)));

      // Shape to apply to entity.
      Renderable shape(new CircleShape(collideable.radius));
      shape.setFillColor(Color(r(128, 127), r(128, 127), r(128, 127), 0));
      shape.setOrigin(collideable.radius, collideable.radius);
      entity.assign<Renderable>(shape);
    }
  }
};
     */
}
