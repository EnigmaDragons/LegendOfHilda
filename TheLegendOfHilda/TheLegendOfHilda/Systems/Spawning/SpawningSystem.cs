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
}
