﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Inputs;

namespace MonoDragons.Core.Engine
{
    public class MainGame : Game, INavigation
    {
        private readonly string _startingViewName;
        private readonly SceneFactory _sceneFactory;
        private readonly IController _controller;
        private Vector2 _baseResolution;
        private float _scale;
        //private GraphicsDeviceManager _graphicsManager;

        private SpriteBatch _sprites;
        private IScene _currentScene;

        public MainGame(string startingViewName, ScreenSize screenSize, float scale , SceneFactory sceneFactory, IController controller)
        {
            _scale = scale;
            screenSize.Apply(new GraphicsDeviceManager(this));
            Content.RootDirectory = "Content";
            _startingViewName = startingViewName;
            _sceneFactory = sceneFactory;
            _controller = controller;
        }

        protected override void Initialize()
        {
            _baseResolution = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            IsMouseVisible = true;
            _sprites = new SpriteBatch(GraphicsDevice);
            Hack.TheGame = this;
            Input.SetController(_controller);
            World.Init(this, this, _sprites, _scale);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            NavigateTo(_startingViewName);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            _controller.Update(gameTime.ElapsedGameTime);
            _currentScene?.Update(gameTime.ElapsedGameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _sprites.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _currentScene?.Draw();
            _sprites.End();
            base.Draw(gameTime);
        }

        public void NavigateTo(string sceneName)
        {
            var scene = _sceneFactory.Create(sceneName);
            scene.Init();
            _currentScene = scene;
        }
    }
}
