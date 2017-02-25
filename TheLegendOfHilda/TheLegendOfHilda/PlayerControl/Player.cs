using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.PlayerControl
{
    public class Player : IVisual
    {
        public Rectangle Position { get; }
        public Vector2 Location => new Vector2(Position.Center.X, Position.Center.Y);

        public Player(Rectangle startingPosition)
        {
            Position = startingPosition;
        }

        public void Draw(Vector2 offset)
        {
            World.Draw("Images/Temp/PlayerPlaceholder", new Rectangle((int)(Position.X + offset.X), (int)(Position.Y + offset.Y), Position.Width, Position.Height));
        }
    }
}
