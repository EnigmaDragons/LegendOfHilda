using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    struct Collideable : IComponent<Keys>
    {
        public Keys Key => Keys.Collideable;
        public int Radius { get; set; }
    }
}
