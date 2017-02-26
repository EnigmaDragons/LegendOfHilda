using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Components
{
    [Flags]
    public enum Keys : long
    {
        None = 0,
        Position = 2 ^ 0,
        Opacity = 2 ^ 1,
        Renderable = 2 ^ 2,
        Collideable = 2 ^ 3,
        Health = 2 ^ 4,
        Regenerates = 2 ^ 5,
    }
}
