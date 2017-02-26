using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;
using TheLegendOfHilda.PlayerStuff;

namespace TheLegendOfHilda.Scenes
{
    public class BrendanTestScene : IScene
    {
        Player player;

        public void Init()
        {
            player = new Player();
        }

        public void Update(TimeSpan delta)
        {
            player.Update(delta);
        }

        public void Draw()
        {
            player.Draw();
        }
    }
}
