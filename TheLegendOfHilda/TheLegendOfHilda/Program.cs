using MonoDragons.Core.Engine;
using System;
using MonoDragons.Core.Inputs;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TheLegendOfHilda.Scenes;

namespace TheLegendOfHilda
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var game = new MainGame("Title", new ScreenSize(800, 800), 2, CreateSceneFactory(), CreateKeyboardContoller()))
                game.Run();
        }

        private static IController CreateKeyboardContoller()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Escape, Control.Quit },
                { Keys.Enter, Control.Start }
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "TimTestScene", () => new TimTestScene() },
                { "NateTestScene", () => new NateTestScene() },
                { "EnemyPatrolling", () => new EnemyPatrolingScene() },
                { "BrendanTestScene", () => new BrendanTestScene() },
                { "Room1", () => new Room1() },
                { "Title", () => new TitleScene() },
            });
        }
    }
#endif
}
