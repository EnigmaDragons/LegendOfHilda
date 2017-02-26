using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Healing
{
    class HealingSystem : ISystem<Keys>
    {
        public Keys RequiredComponents { get; }
            = Keys.Regenerates | Keys.Health;

        //TODO: Systems should be stateless... we need to save this somewhere else...
        ElapsedGameTime _timeSinceLastHeal = ElapsedGameTime.Zero;

        public void Update(IEngine engine, HealingSettings settings)
        {
            _timeSinceLastHeal += engine.Elapsed;

            var elapsedIntervals = _timeSinceLastHeal / settings.Interval;

            if (elapsedIntervals <= 0)
                return;
            else
                _timeSinceLastHeal = ElapsedGameTime.Zero;

            foreach (var entity in engine.Entities(RequiredComponents))
            {
                var regen = entity.Component<Regenerates>();
                var health = entity.Component<Health>();

                var newHealth = health.Amount + (regen.Amount * elapsedIntervals);
                health.Amount = Math.Min(health.Max, newHealth);
            }
        }
    }
}
