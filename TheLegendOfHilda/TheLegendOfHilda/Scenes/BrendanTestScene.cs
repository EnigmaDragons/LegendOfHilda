using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace TheLegendOfHilda.Scenes
{
    public class BrendanTestScene : IScene
    {
        BackAndForthAnimation playerAnimation;
        BackAndForthAnimation backAnimation;

        public void Init()
        {
            playerAnimation = new BackAndForthAnimation(@"Images\Link", MakeFrames(), 0.08);
            backAnimation = new BackAndForthAnimation(@"Images\Link", MakeBackFrames(), 0.08);
        }

        private List<Rectangle> MakeBackFrames()
        {
            var frames = new List<Rectangle>();
            for (int i = 0; i < 7; ++i)
            {
                frames.Add(new Rectangle(32 * i, 32, 32, 32));
            }
            return frames;
        }

        private List<Rectangle> MakeFrames()
        {
            var frames = new List<Rectangle>();
            for(int i = 0; i < 7; ++i)
            {
                frames.Add(new Rectangle(32 * i, 0, 32, 32));
            }
            return frames;
        }

        public void Update(TimeSpan delta)
        {
            playerAnimation.Update(delta);
            backAnimation.Update(delta);
        }

        public void Draw()
        {
            playerAnimation.Render(new Vector2(100, 100));
            backAnimation.Render(new Vector2(300, 100));
        }
    }
}
