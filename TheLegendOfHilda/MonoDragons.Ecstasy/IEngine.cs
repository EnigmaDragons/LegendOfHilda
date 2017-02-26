using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public interface IEngine
    {
        string Debug(long fps);

        ElapsedGameTime Elapsed { get; }

        IEnumerable<IEntity> Entities<T>(T requiredComponentsMask) where T : struct;
        void Emit<T>(T gameEvent) where T : IEvent;
    }
}
