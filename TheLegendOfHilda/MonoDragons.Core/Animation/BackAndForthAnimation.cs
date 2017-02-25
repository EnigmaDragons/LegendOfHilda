using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Animation
{
    public class BackAndForthAnimation : Animation
    {
        string texture;
        List<Rectangle> frames;
        int currentFrame = 0;
        double secondsPerFrame;
        double currentSeconds = 0;
        int currentFrameDirection = 1;

        public BackAndForthAnimation(string texture, List<Rectangle> frames, double secondsPerFrame)
        {
            this.texture = texture;
            this.frames = frames;
            this.secondsPerFrame = secondsPerFrame;
        }

        public void Update(TimeSpan deltaTime)
        {
            currentSeconds += deltaTime.TotalSeconds;

            while (currentSeconds > secondsPerFrame)
            {
                currentSeconds -= secondsPerFrame;
                currentFrame += currentFrameDirection;

                if(currentFrame == frames.Count - 1 || currentFrame == 0)
                    currentFrameDirection *= -1;
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
