using MonoDragons.Core.Engine;
using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Inputs;

namespace TheLegendOfHilda.Scenes
{
    public class GameOver : IScene
    {
        private bool _shouldShowEnter;
        private double _millis;

        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("Title"));
            World.StopMusic("Music/dungeon1");
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
            World.DrawCentered("Images/Backgrounds/gameover1");

            if (_shouldShowEnter)
                World.Draw("Images/Backgrounds/pressenter1", new Rectangle(120, 180, 200, 100));
        }
    }
}
