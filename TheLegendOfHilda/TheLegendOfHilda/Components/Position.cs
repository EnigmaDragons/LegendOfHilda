using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    struct Position : IComponent<Keys>
    {
        public Keys Key => Keys.Position;
        public int X { get; set; }
        public int Y { get; set; }
    }
}
