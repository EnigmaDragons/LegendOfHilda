using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonoDragons.Core.Animation
{
    public static class AnimationHelper
    {
        public static List<Rectangle> MakeFrames(int top, int left, int width, int height, int numFrames)
        {
            var frames = new List<Rectangle>();
            for (int i = 0; i < numFrames; ++i)
            {
                frames.Add(new Rectangle(left + width * i, top, width, height));
            }
            return frames;
        }
    }
}
