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
            using (var game = new MainGame("NateTestScene", new ScreenSize(900, 600), CreateSceneFactory(), CreateKeyboardContoller()))
                game.Run();
        }

        private static IController CreateKeyboardContoller()
        {
            return new KeyboardController(new Map<Keys, Control>());
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "NateTestScene", () => new NateTestScene() }
            });
        }
    }
#endif
}
