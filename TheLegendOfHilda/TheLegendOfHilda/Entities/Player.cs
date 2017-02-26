using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Entities
{
    class Player : Entity
    {
        public Player(Func<string> playerIdFactory)
           : base(playerIdFactory()) { }
    }
}
