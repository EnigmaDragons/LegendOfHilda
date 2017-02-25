using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.PlayerControl;

namespace TheLegendOfHilda.Obstacles
{
    public class Striker : IVisualAutomaton
    {
        private const float MoveSpeed = 0.04F;

        private readonly Player _playerRef;

        private Vector2 _location;

        private bool _isPatroling;
        private List<Vector2> _patrolPath;
        private Vector2 _targetNode;
        private int _index;

        public Striker(Player player, Vector2 startingPosition, List<Vector2> path)
        {
            _playerRef = player;
            _location = startingPosition;
            _patrolPath = path;
            _index = 0;
            _isPatroling = path.Count > 1;
            if (_isPatroling)
                _targetNode = _patrolPath[_index];
        }

        public void Update(TimeSpan delta)
        {
            if (_isPatroling) 
                Patrol(delta);
        }

        public void Draw(Vector2 offset)
        {
            World.Draw("Images/Temp/StrikerPlaceholder", offset + _location);
        }

        public void Patrol(TimeSpan delta)
        {
            if (Math.Abs(_location.X - _targetNode.X) < 1 && Math.Abs(_location.Y - _targetNode.Y) < 1)
                _index = _index == _patrolPath.Count - 1 ? 0 : _index + 1;
            _targetNode = _patrolPath[_index];
            var distance = (float)MoveSpeed*(float)delta.TotalMilliseconds;
            var direction = _targetNode - _location;
            direction.Normalize();
            _location = _location + distance*direction;
        }
    }
}
