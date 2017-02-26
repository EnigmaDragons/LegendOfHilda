using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace TheLegendOfHilda.Scenes
{
    public class TitleScene : IScene
    {
        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("Room1"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            //var screenWidth = 1344 / 3;
            //var screenHeight = 960 / 3;
            //var useWidth = 
            World.DrawBackgroundColor(Color.Black);
            World.DrawCentered("Images/Backgrounds/bg 1", new Vector2(256, 144) * new Vector2(1.6f));
            World.DrawCentered("Images/Backgrounds/title1");
            World.Draw("Images/Backgrounds/pressenter1", new Rectangle(120, 180, 200, 100));
            //World.Draw("Images/Backgrounds/bg 1", new Rectangle((int)(1344 * 0.25), (int)(960 * 0.25), 256, 144));
            //World.Draw("Images/Backgrounds/title1", Vector2.Zero);
        }
    }
}
