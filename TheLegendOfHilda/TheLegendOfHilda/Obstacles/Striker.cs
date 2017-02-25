using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.PlayerControl;

namespace TheLegendOfHilda.Obstacles
{
    public class Striker : IVisualAutomaton
    {
        private const float MoveSpeed = 0.1F;

        private Rectangle _position;
        private Vector2 _location;

        private readonly Player _playerRef;
        private bool _isChasing = false;

        private readonly List<Vector2> _patrolPath;
        private bool _isPatroling;
        private Vector2 _targetNode;
        private int _index;

        public Striker(Player player, Rectangle startingPosition, List<Vector2> path)
        {
            _playerRef = player;
            _position = startingPosition;
            _patrolPath = path;
            _index = 0;
            _isPatroling = path.Count > 1;
            _location = new Vector2(_position.Center.X, _position.Center.Y);
            if (_isPatroling)
                _targetNode = _patrolPath[_index];
        }

        public void Update(TimeSpan delta)
        {
            if (Math.Abs(_playerRef.Location.X - _location.X) < 1000 && Math.Abs(_playerRef.Location.Y - _location.Y) < 1000)
            {
                _isPatroling = false;
                _isChasing = true;
            }
            if (_isPatroling) 
                Patrol(delta);
            if (_isChasing)
                Chase(delta);
                
        }

        public void Draw(Vector2 offset)
        {
            World.Draw("Images/Temp/StrikerPlaceholder", new Rectangle((int)(_position.X + offset.X), (int)(_position.Y + offset.Y), _position.Width, _position.Height));
        }

        public void Patrol(TimeSpan delta)
        {
            if (Math.Abs(_location.X - _targetNode.X) < 1 && Math.Abs(_location.Y - _targetNode.Y) < 1)
                _index = _index == _patrolPath.Count - 1 ? 0 : _index + 1;
            _targetNode = _patrolPath[_index];

            var distance = (float)MoveSpeed*(float)delta.TotalMilliseconds;
            var direction = _targetNode - _location;
            direction.Normalize(); 
            _location = _location + distance * direction;
            _position = new Rectangle((int)(_location.X - 16), (int)(_location.Y - 16), _position.Width, _position.Height); 
        }

        public void Chase(TimeSpan delta)
        {
            var distance = (float)MoveSpeed * (float)delta.TotalMilliseconds;
            var direction = _playerRef.Location - _location;
            direction.Normalize();
            _location = _location + distance * direction;
            _position = new Rectangle((int)(_location.X - 16), (int)(_location.Y - 16), _position.Width, _position.Height);
        }
    }
}
