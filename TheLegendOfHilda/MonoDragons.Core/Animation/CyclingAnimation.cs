using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Animation
{
    public class CyclingAnimation : Animation
    {
        string texture;
        List<Rectangle> frames;
        int currentFrame = 0;
        double secondsPerFrame;
        double currentSeconds = 0;

        public CyclingAnimation(string texture, List<Rectangle> frames, double secondsPerFrame)
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

        public void Draw(Vector2 position)
        {
            World.Draw(texture, position, frames[currentFrame]);
        }

        public void Reset()
        {
            currentFrame = 0;
        }
    }
}
