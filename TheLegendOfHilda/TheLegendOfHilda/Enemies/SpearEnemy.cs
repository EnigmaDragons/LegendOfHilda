using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.PlayerStuff;

namespace TheLegendOfHilda.Enemies
{
    public class SpearEnemy : Character, IVisualAutomaton
    {
        private Dictionary<AnimationState, Animation> _animations;

        public SpearEnemy()
            : base(CreateAnimations())
        {
        }

        public void Update(TimeSpan delta)
        {
            base.Update(delta);
        }

        public void Draw(Vector2 offset)
        {
        }

        private static Dictionary<AnimationState, Animation> CreateAnimations()
        {
            var animations = new Dictionary<AnimationState, Animation>();
            animations[AnimationState.WalkingForward] = new StillFrame("Images/Enemies/striker-u", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.WalkingBackward] = new StillFrame("Images/Enemies/striker-d", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.WalkingLeft] = new StillFrame("Images/Enemies/striker-l", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.WalkingRight] = new StillFrame("Images/Enemies/striker-r", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.StandingForward] = new StillFrame("Images/Enemies/striker-u", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.StandingBackward] = new StillFrame("Images/Enemies/striker-d", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.StandingLeft] = new StillFrame("Images/Enemies/striker-l", new Rectangle(0, 0, 32, 32));
            animations[AnimationState.StandingRight] = new StillFrame("Images/Enemies/striker-r", new Rectangle(0, 0, 32, 32));
            return animations;
        }
    }
}
