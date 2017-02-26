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
    class VictoryScene : IScene
    {
        private bool _ShouldShowEnter;
        private double _Millis;

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            World.DrawCentered("Images/Backgrounds/bg2", new Vector2(256, 144) * new Vector2(1.6f));
            World.DrawCentered("Images/Backgrounds/victory1");
            if (_ShouldShowEnter)
                World.Draw("Images/Backgrounds/pressenter1", new Rectangle(120, 180, 200, 100));
        }

        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("Credits"));
        }

        public void Update(TimeSpan delta)
        {
            _Millis += delta.TotalMilliseconds;
            if (_Millis > 333)
            {
                _Millis -= 333;
                _ShouldShowEnter = !_ShouldShowEnter;
            }
        }
    }
}
