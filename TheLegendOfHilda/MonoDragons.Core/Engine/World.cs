using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.UI;
using System;

namespace MonoDragons.Core.Engine
{
    public static class World
    {
        private static readonly Events _events = new Events();

        private static GraphicsDevice _graphicsDevice;
        private static Game _game;
        private static ContentManager _content;
        private static SpriteBatch _spriteBatch;
        private static INavigation _navigation;
        private static SceneContents _sceneContents;
        //private static Vector2 _baseResolution;
        private static float _scale;
        //private static GraphicsDeviceManager _graphicsManager;

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch, float scale)
        {
            //_graphicsDevice = graphics;
            //_graphicsManager = manager;
            //_baseResolution = baseResolution;
            _scale = scale;
            _game = game;
            //_game.Window.AllowUserResizing = true;
            //_game.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            _content = game.Content;
            _navigation = navigation;
            _spriteBatch = spriteBatch;
            _sceneContents = new SceneContents(_content);
            DefaultFont.Load(_content);
        }

        private static void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            //var x = _graphicsDevice.Viewport.Width / _baseResolution.X;
            //var y = _graphicsDevice.Viewport.Height / _baseResolution.Y;
            //_scale = x > y ? y : x ;
            //_graphicsManager.PreferredBackBufferWidth = (int)Math.Round((float)_baseResolution.X * _scale);
            //_graphicsManager.PreferredBackBufferHeight = (int)Math.Round((float)_baseResolution.Y * _scale);
        }

        public static void PlaySound(string soundName)
        {
            Load<SoundEffect>(soundName).Play();
        }

        public static void PlayMusic(string songName)
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Load<Song>(songName));
        }

        private static T Load<T>(string resourceName) where T : IDisposable
        {
            return _sceneContents.Load<T>(resourceName);
        }

        public static void NavigateToScene(string sceneName)
        {
            var oldSceneContents = _sceneContents;
            _sceneContents = new SceneContents(_content);
            _navigation.NavigateTo(sceneName);
            oldSceneContents.Dispose();
        }

        public static void DrawBrackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), pixelPosition, null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }

        public static void Draw(string imageName, Rectangle rectPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), null, rectPosition, null, null, 0, new Vector2(_scale, _scale));
        }

        public static void DrawRotated(string imageName, Vector2 pixelPosition, float rotation)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), pixelPosition, null, Color.White, rotation, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }

        public static void DrawRotated(string imageName, Rectangle rectPosition, float rotation)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), null, rectPosition, null, null, rotation, new Vector2(_scale, _scale));
        }

        public static void Draw(string imageName, Vector2 position, Rectangle sourceRectangle)
        {
            // SCALING HACK
            var destinationRect = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
            _spriteBatch.Draw(Load<Texture2D>(imageName), destinationRect, sourceRectangle, Color.White);
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(DefaultFont.Font, text, position, color, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }

        public static void Publish<T>(T payload)
        {
            _events.Publish(payload);
        }

        public static void Subscribe<T>(EventSubscription<T> subscription)
        {
            _events.Subscribe(subscription);
            _sceneContents.Add(Guid.NewGuid().ToString(), subscription);
        }

        public static void Unsubscribe(object owner)
        {
            _events.Unsubscribe(owner);
        }
    }
}
