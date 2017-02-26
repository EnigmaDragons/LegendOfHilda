using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public class ComponentReference<TComponent>
        where TComponent : IComponent
    {
        public IEntity Entity { get; }
        public TComponent Component { get; }
    }
}
