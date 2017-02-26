using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public interface ISystem
    {
        void Update(IEngine engine);
    }

    public interface ISystem<T>
        where T : struct
    {
        T RequiredComponents { get; }
    }
}
