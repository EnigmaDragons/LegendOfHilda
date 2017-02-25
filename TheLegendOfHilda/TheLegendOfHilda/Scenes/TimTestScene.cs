using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Scenes
{
    class TimTestScene : IScene
    {
        public void Draw()
        {
            World.DrawBrackgroundColor(Color.Black);
            World.DrawText("Hello World", new Vector2(0, 0), Color.Yellow);
            World.DrawText("Hello World", new Vector2(100, 0), Color.Yellow);
        }

        public void Init()
        {
        }

        public void Update(TimeSpan delta)
        {
        }
    }
}
