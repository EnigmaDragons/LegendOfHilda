using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Animation;
using MonoDragons.Core.Collision;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Physics;
using TheLegendOfHilda.PlayerStuff;
using TheLegendOfHilda.TileEngine;

namespace TheLegendOfHilda.Enemies
{
    public class SpearEnemy : Character, IVisualAutomaton
    {
        //charge details
        private const float ChargeMaxSpeed = 0.5f;
        private const float AccelerationPerMillis = 0.0001f;
        private const float ChargeDistance = 100;
        private const int ChargeDelayMillis = 1000;
        //walk speed
        private const float PatrolSpeed = 0.1F;
        //player sense 
        private const float SenseDistance = 100;

        private Vector2 _location;

        private Player _player;
        private bool _isTargetLocated = false;

        private readonly List<TileLocation> _patrolPath;
        private bool _isPatroling;
        private Vector2 _targetNode;
        private int _index = 0;

        public SpearEnemy(Player player, TileLocation postion, List<TileLocation> path) : base(CreateAnimations())
        {
            _player = player;
            _patrolPath = path;
            _isPatroling = path.Count > 1;
            _location = new Vector2(_location.X + TileSize.Int / 2, _location.Y + TileSize.Int / 2);
            if (_isPatroling)
                _targetNode = _patrolPath[_index].Position;
        }

        public void Update(TimeSpan delta)
        {
            if (Math.Abs(_player.EnemyTrackingPosition.X - _location.X) < SenseDistance && Math.Abs(_player.EnemyTrackingPosition.Y - _location.Y) < SenseDistance)
            {
                _isPatroling = false;
                _isTargetLocated = true;
            }
            if (_isPatroling)
                Patrol(delta);
            if (_isTargetLocated)
                Charge(delta);

            base.Update(delta);
        }

        public void Draw(Vector2 offset)
        {
            base.position = new Vector2(_location.X - TileSize.Int / 2, _location.Y - TileSize.Int / 2);
            base.Draw();
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

        public void Patrol(TimeSpan delta)
        {
            if (Math.Abs(_location.X - _targetNode.X) < 1 && Math.Abs(_location.Y - _targetNode.Y) < 1)
                _index = _index == _patrolPath.Count - 1 ? 0 : _index + 1;
            _targetNode = _patrolPath[_index].Position;

            var distance = (float)PatrolSpeed * (float)delta.TotalMilliseconds;
            base.OnDirection(new Direction(Physics.Direction(_location, _targetNode)));
            TryToUpdatePosition(Physics.MoveTowards(_location, _targetNode, distance));
        }

        private float _currentSpeed = 0f;
        private float _currentDistanceCharged;
        private Vector2 _targetLoc;
        private TimeSpan _currentChargeWait;

        public void Charge(TimeSpan delta)
        {
            if (Math.Abs(_currentDistanceCharged - ChargeDistance) < 0.01)
            {
                _currentSpeed = 0f;
                _currentDistanceCharged = 0;
                _currentChargeWait = new TimeSpan();
            }
            if (_currentChargeWait.TotalMilliseconds < ChargeDelayMillis)
            {
                _currentChargeWait += delta;
                if (_currentChargeWait.TotalMilliseconds >= ChargeDelayMillis)
                    _targetLoc = Physics.Direction(_location, _player.EnemyTrackingPosition);
            }
            if (_currentChargeWait.TotalMilliseconds >= ChargeDelayMillis)
            {
                _currentSpeed = Math.Min(_currentSpeed + AccelerationPerMillis * delta.Milliseconds, ChargeMaxSpeed);
                var distance = (float)Math.Min(_currentSpeed * delta.TotalMilliseconds, ChargeDistance - _currentDistanceCharged);
                _currentDistanceCharged += distance;
                base.OnDirection(new Direction(Physics.Direction(_location, _player.EnemyTrackingPosition)));
                TryToUpdatePosition(_location + distance*_targetLoc);
            }
        }

        private void TryToUpdatePosition(Vector2 proposal)
        {
            if (ReallyStupidPositionTracker.Instance.CanIGoHere(new AxisAlignedBoundingBox(proposal, new Vector2(boundingBox.Width, boundingBox.Height))))
                _location = proposal;

        }
    }
}
