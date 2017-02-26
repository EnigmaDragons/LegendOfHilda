using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using System;

namespace MonoDragons.Core.Animation
{
    public class StillFrame : Animation
    {
        string texture;
        Rectangle frame;
        bool isInverted = false;

        public StillFrame(string texture, Rectangle frame)
        {
            this.texture = texture;
            this.frame = frame;
        }

        public void Update(TimeSpan deltaTime)
        {
        }

        public void SetInverted(bool isInverted)
        {
            this.isInverted = isInverted;
        }

        public void Draw(Vector2 position)
        {
            if (isInverted)
                World.DrawFlipped(texture, position, frame);
            else
                World.Draw(texture, position, frame);
        }

        public void Reset()
        {
        }
    }
}
