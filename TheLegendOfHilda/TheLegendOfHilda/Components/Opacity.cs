using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    class Opacity : IComponent<Keys>
    {
        public Keys Key => Keys.Opacity;
        public float Alpha { get; set; }
    }
}
