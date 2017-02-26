using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    struct Health : IComponent<Keys>
    {
        public Keys Key => Keys.Health;
        public long Amount { get; set; }
        public long Max { get; set; }
    }
}
