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
            using (var game = new MainGame("Victory", new ScreenSize(1344, 960), 3, CreateSceneFactory(), CreateKeyboardContoller()))
                game.Run();
        }

        private static IController CreateKeyboardContoller()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Escape, Control.Quit },
                { Keys.Enter, Control.Start },
                { Keys.J, Control.B },
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "MainHallRoom", () => new MainHallRoom() },
                { "EntranceRoom", () => new EntranceRoom() },
                { "TimTestScene", () => new TimTestScene() },
                { "NateTestScene", () => new NateTestScene() },
                { "BrendanTestScene", () => new BrendanTestScene() },
                { "Title", () => new TitleScene() },
                { "GiovanniTestScene", () => new GiovanniTestScene() },
                { "Room1", () => new Room1() },
                { "GameOver", () => new GameOver() },
                { "Victory", () => new VictoryScene() },
            });
        }
    }
#endif
}
