using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace TheLegendOfHilda.Scenes
{
    public class BrendanTestScene : IScene
    {
        Animation playerAnimation;
        Animation backAnimation;
        Animation sideAnimation;

        public void Init()
        {
            playerAnimation = new BackAndForthAnimation(@"Images\Link", MakeFrames(0, 0, 32, 32, 7), 0.06);
            backAnimation = new BackAndForthAnimation(@"Images\Link", MakeFrames(32, 0, 32, 32, 7), 0.06);
            sideAnimation = new BackAndForthAnimation(@"Images\Link", MakeFrames(64, 0, 32, 32, 7), 0.06);
        }

        private List<Rectangle> MakeFrames(int top, int left, int width, int height, int numFrames)
        {
            var frames = new List<Rectangle>();
            for(int i = 0; i < numFrames; ++i)
            {
                frames.Add(new Rectangle(left + width * i, top, width, height));
            }
            return frames;
        }

        public void Update(TimeSpan delta)
        {
            playerAnimation.Update(delta);
            backAnimation.Update(delta);
            sideAnimation.Update(delta);
        }

        public void Draw()
        {
            playerAnimation.Draw(new Vector2(100, 100));
            backAnimation.Draw(new Vector2(200, 100));
            sideAnimation.Draw(new Vector2(300, 100));
        }
    }
}
