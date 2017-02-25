using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Scenes
{
    class NateTestScene : IScene
    {
        public void Init()
        {
            /// setup before action (ASSETS)
            /// 
        }

        public void Update(TimeSpan delta)
        {
            // do the calcultions

        }

        public void Draw()
        {
            // render the stuff...
            World.DrawBrackgroundColor(Color.Black);
            World.DrawText("Hello World", new Vector2(0, 0), Color.White);
        }
    }
}
