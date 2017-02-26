using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace TheLegendOfHilda.Scenes
{
    public class TitleScene : IScene
    {
        private bool _shouldShowEnter;
        private double _millis;

        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("EntranceRoom"));
        }

        public void Update(TimeSpan delta)
        {
            _millis += delta.TotalMilliseconds;
            if (_millis > 333)
            {
                _millis -= 333;
                _shouldShowEnter = !_shouldShowEnter;
            }
        }

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            World.DrawCentered("Images/Backgrounds/bg 1", new Vector2(256, 144) * new Vector2(1.6f));
            World.DrawCentered("Images/Backgrounds/title1");

            if (_shouldShowEnter)            
                World.Draw("Images/Backgrounds/pressenter1", new Rectangle(120, 180, 200, 100));
        }
    }
}
