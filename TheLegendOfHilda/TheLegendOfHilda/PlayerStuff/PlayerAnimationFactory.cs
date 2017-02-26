using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using System.Collections.Generic;

namespace TheLegendOfHilda.PlayerStuff
{
    public class PlayerAnimationFactory
    {
        public static Dictionary<AnimationState, Animation> GetPlayerAnimations()
        {
            var animations = new Dictionary<AnimationState, Animation>();
            animations[AnimationState.WalkingForward] = new BackAndForthAnimation(@"Images\Link", AnimationHelper.MakeFrames(0, 0, 32, 32, 7), 0.06);
            animations[AnimationState.WalkingBackward] = new BackAndForthAnimation(@"Images\Link", AnimationHelper.MakeFrames(32, 0, 32, 32, 7), 0.06);
            animations[AnimationState.WalkingRight] = new BackAndForthAnimation(@"Images\Link", AnimationHelper.MakeFrames(64, 0, 32, 32, 7), 0.06);
            animations[AnimationState.WalkingLeft] = new BackAndForthAnimation(@"Images\Link", AnimationHelper.MakeFrames(64, 0, 32, 32, 7), 0.06);
            ((BackAndForthAnimation)animations[AnimationState.WalkingLeft]).SetInverted(true);

            animations[AnimationState.StandingForward] = new StillFrame(@"Images\Link", new Rectangle(96, 0, 32, 32));
            animations[AnimationState.StandingBackward] = new StillFrame(@"Images\Link", new Rectangle(96, 32, 32, 32));
            animations[AnimationState.StandingRight] = new StillFrame(@"Images\Link", new Rectangle(96, 64, 32, 32));
            animations[AnimationState.StandingLeft] = new StillFrame(@"Images\Link", new Rectangle(96, 64, 32, 32));
            ((StillFrame)animations[AnimationState.StandingLeft]).SetInverted(true);

            animations[AnimationState.AttackingBackward] = new StillFrame(@"Images\Link", new Rectangle(32, 96, 32, 32));
            animations[AnimationState.AttackingForward] = new StillFrame(@"Images\Link", new Rectangle(0, 96, 32, 32));
            animations[AnimationState.AttackingRight] = new StillFrame(@"Images\Link", new Rectangle(64, 96, 32, 32));
            animations[AnimationState.AttackingLeft] = new StillFrame(@"Images\Link", new Rectangle(64, 96, 32, 32));
            ((StillFrame)animations[AnimationState.AttackingLeft]).SetInverted(true);

            return animations;
        }
    }
}
