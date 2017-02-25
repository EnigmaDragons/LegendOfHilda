using Microsoft.Xna.Framework;
using System;

namespace MonoDragons.Core.Animation
{
    public interface Animation
    {
        void Update(TimeSpan deltaTime);
        void Draw(Vector2 position);
        void Reset();
    }
}
