using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Healing
{
    interface IHealer //ComponentManager
    {
        IEnumerable<ComponentReference<Position>> Positions { get; }

        void Heal(IEntity entity, HealAmount amount);
    }
}
