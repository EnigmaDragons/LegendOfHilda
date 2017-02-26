using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Scenes
{
    class NateTestScene : IScene
    {
        Engine _engine;
        public void Init()
        {
            // setup before action (ASSETS)
            _engine = new Engine();
        }

        public void Update(TimeSpan delta)
        {
            _engine.Tick(delta);
        }

        public void Draw()
        {
            // render the stuff...
            World.DrawBackgroundColor(Color.Black);
            World.DrawText("Hello World", new Vector2(0, 0), Color.White);
        }
    }
}
