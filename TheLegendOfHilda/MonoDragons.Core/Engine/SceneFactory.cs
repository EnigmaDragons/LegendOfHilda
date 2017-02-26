using System;
using System.Collections.Generic;

namespace MonoDragons.Core.Engine
{
    public class SceneFactory
    {
        private readonly Dictionary<string, Func<@string>> _sceneInstructions;

        public SceneFactory(Dictionary<string, Func<@string>> sceneInstructions)
        {
            _sceneInstructions = sceneInstructions;
        }

        public @string Create(string sceneName)
        {
            return _sceneInstructions[sceneName]();
        }
    }
}
