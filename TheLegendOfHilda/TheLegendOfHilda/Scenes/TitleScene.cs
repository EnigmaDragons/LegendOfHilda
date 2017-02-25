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
            World.DrawBrackgroundColor(Color.Black);

            World.Draw("Images/Backgrounds/bg 1", new Rectangle(0, 0, 512, 288));
            World.Draw("Images/Backgrounds/title1", Vector2.Zero);
        }
    }
}
