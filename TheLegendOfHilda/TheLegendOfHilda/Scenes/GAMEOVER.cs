using MonoDragons.Core.Engine;
using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Scenes
{
    public class GameOver : IScene
    {
        private bool _ShouldShowEnter;
        private double _Millis;

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            World.DrawCentered("Images/Backgrounds/gameover1");
            if (_ShouldShowEnter)
                World.Draw("Images/Backgrounds/pressenter1", new Rectangle(120, 180, 200, 100));
        }

        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("Title"));
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
