using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public interface IComponent { }

    public interface IComponent<T> : IComponent
        where T : struct
    {
        T Key { get; }
    }
}
