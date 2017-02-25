using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoDragons.Core.Animation
{
    public class Animation
    {
        Texture2D texture;
        List<Rectangle> frames;
        int frameNum;
        double secondsPerFrame;
        double currentSeconds = 0;

        public Animation(Texture2D texture, List<Rectangle> frames, double secondsPerFrame)
        {
            this.texture = texture;
            this.frames = frames;
            this.secondsPerFrame = secondsPerFrame;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Render(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, location, frames[frameNum], Color.White);
        }

        public void Reset()
        {
            frameNum = 0;
        }
    }
}
