using Microsoft.Xna.Framework;
using MonoDragons.Core.Collision;
using MonoDragons.Core.Inputs;

namespace TheLegendOfHilda.PlayerStuff
{
    public class Player : Character
    {
        public Player(Vector2 initialPosition)
            : base(PlayerAnimationFactory.GetPlayerAnimations())
        {
            position = initialPosition;
            boundingBox = new AxisAlignedBoundingBox(position, new Vector2(16, 18));
            boundingBoxOffset = new Vector2(8, 9);
            Input.OnDirection(OnDirection);
        }
    }
}
