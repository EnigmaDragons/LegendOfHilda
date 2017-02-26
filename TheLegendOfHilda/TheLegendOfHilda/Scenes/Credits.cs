using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Scenes
{
    class Credits : IScene
    {
        private float _Height = 333;
        private double _Millis;

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            World.Draw("Images/Backgrounds/credits 1", new Vector2(0, _Height));
            World.Draw("Images/Backgrounds/pressenter1", new Rectangle(180, 180, 200, 100));
        }
        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("Title"));
        }

        public void Update(TimeSpan delta)
        {
            _Millis += delta.TotalMilliseconds;
            if (_Millis > 20)
            {
                _Millis -= 20;
                _Height = _Height-0.5f; 
            }
        }
    }
}
