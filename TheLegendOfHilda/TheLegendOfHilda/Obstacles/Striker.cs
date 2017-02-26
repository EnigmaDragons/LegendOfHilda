using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Physics;
using TheLegendOfHilda.PlayerControl;

namespace TheLegendOfHilda.Obstacles
{
    public class Striker : IVisualAutomaton
    {
        //charge details
        private const float ChargeMaxSpeed = 0.5f;
        private const float AccelerationPerMillis = 0.0001f;
        private const float ChargeDistance = 100;
        private const int ChargeDelayMillis = 1000;
        //walk speed
        private const float PatrolSpeed = 0.1F;
        //player sense 
        private const float SenseDistance = 1000;

        private int _width;
        private int _height;
        private Vector2 _location;

        private readonly Player _playerRef;
        private bool _isTargetLocated = false;

        private readonly List<Vector2> _patrolPath;
        private bool _isPatroling;
        private Vector2 _targetNode;
        private int _index;

        public Striker(Player player, Rectangle startingPosition, List<Vector2> path)
        {
            _playerRef = player;
            _width = startingPosition.Width;
            _height = startingPosition.Height;
            _patrolPath = path;
            _index = 0;
            _isPatroling = path.Count > 1;
            _location = new Vector2(startingPosition.Center.X, startingPosition.Center.Y);
            if (_isPatroling)
                _targetNode = _patrolPath[_index];
        }

        public void Update(TimeSpan delta)
        {
            if (Math.Abs(_playerRef.Location.X - _location.X) < SenseDistance && Math.Abs(_playerRef.Location.Y - _location.Y) < SenseDistance)
            {
                _isPatroling = false;
                _isTargetLocated = true;
            }
            if (_isPatroling) 
                Patrol(delta);
            if (_isTargetLocated)
                Charge(delta);
        }

        public void Draw(Vector2 offset)
        {
            World.Draw("Images/Temp/StrikerPlaceholder", new Rectangle((int)(_location.X - 16 + offset.X) , (int)(_location.Y - 16 + offset.Y), _width, _height));
        }

        public void Patrol(TimeSpan delta)
        {
            if (Math.Abs(_location.X - _targetNode.X) < 1 && Math.Abs(_location.Y - _targetNode.Y) < 1)
                _index = _index == _patrolPath.Count - 1 ? 0 : _index + 1;
            _targetNode = _patrolPath[_index];

            var distance = (float)PatrolSpeed*(float)delta.TotalMilliseconds;
            _location = Physics.MoveTowards(_location, _playerRef.Location, distance);
        }

        public void Chase(TimeSpan delta)
        {
            var distance = (float)PatrolSpeed * (float)delta.TotalMilliseconds;
            _location = Physics.MoveTowards(_location, _playerRef.Location, distance);
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
                    _targetLoc = Physics.Direction(_location, _playerRef.Location);
            }
            if (_currentChargeWait.TotalMilliseconds >= ChargeDelayMillis)
            {
                _currentSpeed = Math.Min(_currentSpeed + AccelerationPerMillis * delta.Milliseconds, ChargeMaxSpeed);
                var distance = (float)Math.Min(_currentSpeed * delta.TotalMilliseconds, ChargeDistance - _currentDistanceCharged);
                _currentDistanceCharged += distance;
                _location = _location + distance * _targetLoc;
            }
        }
    }
}
