using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Systems
{
    class CollisionEvent : IEvent
    {
        IEntity First { get; }
        IEntity Second { get; }

        public CollisionEvent(IEntity first, IEntity second)
        {
            First = first;
            Second = second;
        }
    }
}
