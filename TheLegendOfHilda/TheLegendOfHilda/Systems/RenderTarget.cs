using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Systems.Rendering;

namespace TheLegendOfHilda.Systems
{
    public interface IRenderable
    {

    }

    struct RenderTarget
    {
        public Bounds2D GetBounds() { return Bounds2D.Zero; }

        public void Draw(IRenderable render)
        {

        }
    }
}
