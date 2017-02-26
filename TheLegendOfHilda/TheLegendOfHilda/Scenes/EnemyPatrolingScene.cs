using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using TheLegendOfHilda.Obstacles;
using TheLegendOfHilda.PlayerControl;

namespace TheLegendOfHilda.Scenes
{
    public class EnemyPatrolingScene : @string
    {
        private List<IVisual> _visuals = new List<IVisual>();
        private List<IAutomaton> _automaton = new List<IAutomaton>();

        public void Init()
        {
            var player = new Player(new Rectangle(333, 333, 64, 64));
            //var striker1 = new Striker(player, new Rectangle(600 - 16, 600 - 16, 32, 32), new List<Vector2> { new Vector2(600), new Vector2(400) });
            var striker2 = new Striker(player, new Rectangle(100 - 16, 100 - 16, 32, 32), new List<Vector2> { new Vector2(100), new Vector2(100, 600) });
            //var striker3 = new Striker(player, new Rectangle(100 - 16, 600 - 16, 32, 32), new List<Vector2> { new Vector2(100, 600), new Vector2(130, 520), new Vector2(180, 510) });
            //striker4 = new Striker(player, new Rectangle(600 - 16, 100 - 16, 32, 32), new List<Vector2>());
            _visuals.AddRange(new List<IVisual> { striker2, player });
            _automaton.AddRange(new List<IAutomaton> { striker2 });
        }

        public void Update(TimeSpan delta)
        {
            _automaton.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            World.Draw("Images/Temp/BackgroundPlaceholder", Vector2.Zero);
            _visuals.ForEach(x => x.Draw(Vector2.Zero));
        }
    }
}
