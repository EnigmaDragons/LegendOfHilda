using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public class Engine : IEngine
    {
        public ElapsedGameTime Elapsed { get; private set; }

        public IList<ISystem> Systems { get; } = new List<ISystem>();

        public void Tick(TimeSpan delta)
        {
            Elapsed = new ElapsedGameTime(delta);
            foreach (var system in Systems)
                system.Update(this);
        }


        public string Debug(long fps) => _Entities.Count + " entities (" + fps + " fps)";
        IList<IEntity> _Entities;
        public IEnumerable<IEntity> Entities<T>(T requiredComponentsMask)
            where T : struct
        {
            var key = Convert.ToInt64(requiredComponentsMask);
            yield break;
        }

        public ComponentManager Components { get; } = new ComponentManager();


        public void Emit<T>(T gameEvent) where T : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
