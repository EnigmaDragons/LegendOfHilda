using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public interface IEntity : IEquatable<IEntity>
    {
        T Component<T>();
    }
}
