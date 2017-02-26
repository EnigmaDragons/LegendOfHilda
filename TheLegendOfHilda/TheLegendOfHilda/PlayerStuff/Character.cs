using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Collision;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace TheLegendOfHilda.PlayerStuff
{
    public abstract class Character
    {
        private static bool drawDebug = true;

        private Color debugColor = new Color(256, 0, 0, 10);
        private Dictionary<AnimationState, Animation> animations;
        private AnimationState currentAnimationState = AnimationState.StandingForward;

        protected float speed = 2.0f; // pixels/sec
        protected Vector2 position;
        protected AxisAlignedBoundingBox boundingBox;
        protected Vector2 boundingBoxOffset;

        protected Character(Dictionary<AnimationState, Animation> animations)
        {
            position = new Vector2(0, 0);
            boundingBox = new AxisAlignedBoundingBox(position, new Vector2(16, 16));
            boundingBoxOffset = new Vector2(8, 9);
            this.animations = animations;
        }

        public void Update(TimeSpan deltaTime)
        {
            boundingBox.Position = position + boundingBoxOffset;
            animations[currentAnimationState].Update(deltaTime);
        }

        public void Draw()
        {
            animations[currentAnimationState].Draw(position);
            if (drawDebug)
            {
                // Bit of a hack to account for the render scale
                var rect = new Rectangle();
                rect.X = (int)((position.X + boundingBoxOffset.X) * World.Scale);
                rect.Y = (int)((position.Y + boundingBoxOffset.Y) * World.Scale);
                rect.Width = (int)(boundingBox.Width * World.Scale);
                rect.Height = (int)(boundingBox.Height * World.Scale);
                World.DrawRectangle(rect, debugColor);
                // Call this if there's no scaling
                //World.DrawRectangle(boundingBox.ToRect(), debugColor);
            }
        }

        public void OnDirection(Direction direction)
        {
            Vector2 movement = new Vector2();
            movement.X += (int)direction.HDir;
            movement.Y += (int)direction.VDir;
            if (movement.Length() < 0.000001f)
            {
                movement = Vector2.Zero;
                SwitchToStanding();
            }
            else
            {
                movement.Normalize();
                if (movement.X < 0)
                    SetAnimationState(AnimationState.WalkingLeft);
                else if (movement.X > 0)
                    SetAnimationState(AnimationState.WalkingRight);
                else if (movement.Y < 0)
                    SetAnimationState(AnimationState.WalkingBackward);
                else if (movement.Y > 0)
                    SetAnimationState(AnimationState.WalkingForward);
            }

            position += movement * speed;
        }

        private void SetAnimationState(AnimationState state)
        {
            if (currentAnimationState != state)
            {
                currentAnimationState = state;
                animations[currentAnimationState].Reset();
            }
        }

        private void SwitchToStanding()
        {
            if (currentAnimationState == AnimationState.WalkingBackward)
                currentAnimationState = AnimationState.StandingBackward;
            if (currentAnimationState == AnimationState.WalkingForward)
                currentAnimationState = AnimationState.StandingForward;
            if (currentAnimationState == AnimationState.WalkingLeft)
                currentAnimationState = AnimationState.StandingLeft;
            if (currentAnimationState == AnimationState.WalkingRight)
                currentAnimationState = AnimationState.StandingRight;
        }
    }
}
