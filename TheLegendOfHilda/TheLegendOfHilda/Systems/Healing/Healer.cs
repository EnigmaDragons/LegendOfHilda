using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoDragons.Ecstasy;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Healing
{
    class Healer : ComponentManager, IHealer
    {
        public IEnumerable<ComponentReference<Position>> Positions { get; }

        IDictionary<IEntity, IEntity> _entities = new Dictionary<IEntity, IEntity>();
        IList<IComponent> _inner = new List<IComponent>();
        
        public void Register(IEntity entity, IComponent component)
        {
            _entities[entity] = entity;
        }

        public void Heal(IEntity entity, HealAmount amount)
        {
            
        }
    }
}
