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

        private static Game _game;
        private static ContentManager _content;
        private static SpriteBatch _spriteBatch;
        private static INavigation _navigation;
        private static SceneContents _sceneContents;
        private static Texture2D _rectTexture;

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch)
        {
            _game = game;
            _content = game.Content;
            _navigation = navigation;
            _spriteBatch = spriteBatch;
            SetupRectangleTexture(game.GraphicsDevice);
            _sceneContents = new SceneContents(_content);
            DefaultFont.Load(_content);
        }

        private static void SetupRectangleTexture(GraphicsDevice device)
        {
            _rectTexture = new Texture2D(device, 1, 1);
            var data = new Color[1];
            data[0] = Color.White;
            _rectTexture.SetData(data);
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

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), pixelPosition);
        }

        public static void Draw(string imageName, Rectangle rectPostion)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), rectPostion, Color.White);
        }

        public static void Draw(string imageName, Vector2 position, Rectangle sourceRectangle)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), position, sourceRectangle, Color.White);
        }

        public static void DrawFlipped(string imageName, Vector2 position, Rectangle sourceRectangle)
        {
            var destinationRect = new Rectangle((int)position.X, (int)position.Y, sourceRectangle.Width, sourceRectangle.Height);
            _spriteBatch.Draw(Load<Texture2D>(imageName), destinationRect, sourceRectangle, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(DefaultFont.Font, text, position, color);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(_rectTexture, rectangle, color);
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
