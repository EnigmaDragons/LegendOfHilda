using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    struct Regenerates : IComponent<Keys>
    {
        public Keys Key => Keys.Regenerates;
        public long Amount { get; set; }
    }
}
