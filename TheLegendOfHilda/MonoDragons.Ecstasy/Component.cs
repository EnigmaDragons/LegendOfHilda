using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public class ComponentManager
    {
        //list of entities by their component Keys
        //list of components by the system's Key

        // Ideally every system Key is unique, but it's not guaranteed
        IDictionary<IEntity, IEntity> _entities = new Dictionary<IEntity, IEntity>();
        IList<IComponent> _inner = new List<IComponent>();

        public void Add(IEntity entity, IComponent component)
        {
            _entities[entity] = entity;
        }
    }
}
