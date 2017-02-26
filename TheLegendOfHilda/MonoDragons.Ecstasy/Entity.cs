using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public abstract class Entity
    {
        string _id;
        public Entity(string id)
        {
            _id = id;
        }
        public bool Equals(Entity other)
        {
            return _id == (other as Entity)._id;
        }
    }
}
