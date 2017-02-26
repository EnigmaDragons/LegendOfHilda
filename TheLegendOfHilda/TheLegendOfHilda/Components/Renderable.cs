using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Systems;
using TheLegendOfHilda.Systems.Rendering;

namespace TheLegendOfHilda.Components
{
    class RGBA
    {
        public int R { get; set; }
        public int B { get; set; }
        public int G { get; set; }
        public int A { get; set; }
    }

    class Renderable : IComponent<Keys>
    {
        public Keys Key => Keys.Renderable;

        public RGBA FillColor { get; internal set; }
        public Point2D Location { get; internal set; } 

        public IRenderable Render()
        {
            return new Text();
        }
    }
}
