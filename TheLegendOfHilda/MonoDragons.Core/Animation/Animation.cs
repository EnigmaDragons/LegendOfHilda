using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Animation
{
    public class Animation
    {
        string texture;
        List<Rectangle> frames;
        int currentFrame = 0;
        double secondsPerFrame;
        double currentSeconds = 0;

        public Animation(string texture, List<Rectangle> frames, double secondsPerFrame)
        {
            this.texture = texture;
            this.frames = frames;
            this.secondsPerFrame = secondsPerFrame;
        }

        public void Update(TimeSpan deltaTime)
        {
            currentSeconds += deltaTime.TotalSeconds;
            while(currentSeconds > secondsPerFrame)
            {
                currentSeconds -= secondsPerFrame;
                currentFrame++;
                currentFrame %= frames.Count;
            }
        }

        public void Render(Vector2 location)
        {
            World.Draw(texture, location, frames[currentFrame]);
        }

        public void Reset()
        {
            currentFrame = 0;
        }
    }
}
