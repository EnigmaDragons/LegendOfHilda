﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Collision;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Physics;

namespace TheLegendOfHilda.PlayerStuff
{
    public abstract class Character 
    {
        private static bool drawDebug = false;

        private readonly Color debugColor = new Color(256, 0, 0, 10);
        private Dictionary<AnimationState, Animation> animations;
        protected AnimationState currentAnimationState = AnimationState.StandingForward;

        protected readonly float speed = 2.0f; // pixels/sec
        protected Vector2 position;
        protected AxisAlignedBoundingBox boundingBox;
        protected Vector2 boundingBoxOffset;

        protected Vector2 proposedPosition;

        protected bool isAttacking;
        private float currentAttackTime; // seconds
        private readonly float attackTime = 0.2f; // seconds

        protected Character(Dictionary<AnimationState, Animation> animations)
        {
            position = new Vector2(0, 0);
            boundingBox = new AxisAlignedBoundingBox(position, new Vector2(16, 16));
            boundingBoxOffset = new Vector2(8, 9);
            this.animations = animations;
        }

        public void Update(TimeSpan deltaTime)
        {
            if(isAttacking)
            {
                currentAttackTime -= (float)deltaTime.TotalSeconds;
                if(currentAttackTime < 0.0f)
                {
                    isAttacking = false;
                    if (currentAnimationState == AnimationState.AttackingBackward)
                        currentAnimationState = AnimationState.StandingBackward;
                    if (currentAnimationState == AnimationState.AttackingForward)
                        currentAnimationState = AnimationState.StandingForward;
                    if (currentAnimationState == AnimationState.AttackingLeft)
                        currentAnimationState = AnimationState.StandingLeft;
                    if (currentAnimationState == AnimationState.AttackingRight)
                        currentAnimationState = AnimationState.StandingRight;
                }
            }

            
            var potentialMove = new AxisAlignedBoundingBox(boundingBox.Top, boundingBox.Left, boundingBox.Width, boundingBox.Height);
            potentialMove.Position = proposedPosition + boundingBoxOffset;

            if (ReallyStupidPositionTracker.Instance.CanIGoHere(potentialMove))
            {
                position = proposedPosition;
                boundingBox.Position = position + boundingBoxOffset;
            }
            else
            {
                proposedPosition = position;
            }

            animations[currentAnimationState].Update(deltaTime);
        }

        public void Draw()
        {
            animations[currentAnimationState].Draw(position);
            if (drawDebug)
            {
                var rect = new Rectangle();
                rect.X = (int)(position.X + boundingBoxOffset.X);
                rect.Y = (int)(position.Y + boundingBoxOffset.Y);
                rect.Width = (int)boundingBox.Width;
                rect.Height = (int)boundingBox.Height;
                World.DrawRectangle(rect, debugColor);
            }
        }

        protected void OnDirection(Direction direction)
        {
            if(!isAttacking)
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

                proposedPosition += movement * speed;
            }
        }

        protected void OnAttack()
        {
            if(!isAttacking)
            {
                if (currentAnimationState == AnimationState.StandingBackward ||
                    currentAnimationState == AnimationState.WalkingBackward)
                    currentAnimationState = AnimationState.AttackingBackward;
                if (currentAnimationState == AnimationState.StandingForward ||
                    currentAnimationState == AnimationState.WalkingForward)
                    currentAnimationState = AnimationState.AttackingForward;
                if (currentAnimationState == AnimationState.StandingRight ||
                    currentAnimationState == AnimationState.WalkingRight)
                    currentAnimationState = AnimationState.AttackingRight;
                if (currentAnimationState == AnimationState.StandingLeft ||
                    currentAnimationState == AnimationState.WalkingLeft)
                    currentAnimationState = AnimationState.AttackingLeft;
                isAttacking = true;
                World.PlaySound("SFX/Sword1");
                currentAttackTime = attackTime;
            }
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
