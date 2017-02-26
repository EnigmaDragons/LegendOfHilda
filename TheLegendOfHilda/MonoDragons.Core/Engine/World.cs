using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.UI;
using System;
using MonoDragons.Core.Physics;

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
        private static Texture2D _rectTexture;
        
        public static float Scale { get; private set; }

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch, float scale)
        {
            Scale = scale;
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
        public static void StopMusic(string songName)
        {
            MediaPlayer.Stop();
        }

        private static T Load<T>(string resourceName) where T : IDisposable
        {
            return _sceneContents.Load<T>(resourceName);
        }

        public static void NavigateToScene(string sceneName)
        {
            //TODO: Shared resources between scenes might be a problem for ContentManager
            //var oldSceneContents = _sceneContents;
            //_sceneContents = new SceneContents(_content);
            _navigation.NavigateTo(sceneName);
            //oldSceneContents.Dispose();
            ReallyStupidPositionTracker.Instance.Reset();
        }

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), ScaleVector(pixelPosition.X, pixelPosition.Y), null, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public static void Draw(string imageName, Rectangle rectPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), null,
                new Rectangle(ScalePoint(rectPosition.X, rectPosition.Y), ScalePoint(rectPosition.Width, rectPosition.Height)),
                null, null, 0, new Vector2(Scale, Scale));
        }

        public static void DrawRotated(string imageName, Vector2 pixelPosition, float rotation)
        {
            var texture = Load<Texture2D>(imageName);
            DrawRotated(imageName, new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, texture.Width, texture.Height), rotation);
        }

        public static void DrawRotated(string imageName, Rectangle rectPosition, float rotation)
        {
            var origin = new Vector2(16, 16);
            _spriteBatch.Draw(Load<Texture2D>(imageName), 
                null, 
                new Rectangle(ScalePoint(rectPosition.X + origin.X, rectPosition.Y + origin.Y), ScalePoint(rectPosition.Width, rectPosition.Height)), 
                null, 
                origin, 
                rotation, 
                /*Insert scale*/ new Vector2(Scale, Scale));
        }

        public static void DrawCentered(string imageName)
        {
            var texture = Load<Texture2D>(imageName);
            DrawCentered(imageName, new Vector2(texture.Width, texture.Height));
        }

        public static void DrawCentered(string imageName, Vector2 WidthHeight)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), null, new Rectangle(ScalePoint(1344 / 2 / Scale - WidthHeight.X / 2, 960 / 2 / Scale - WidthHeight.Y / 2), ScalePoint(WidthHeight.X, WidthHeight.Y)), null, null, 0, new Vector2(Scale, Scale));
        }

        public static void Draw(string imageName, Vector2 position, Rectangle sourceRectangle)
        {
            var destinationRect = new Rectangle(ScalePoint(position.X, position.Y), ScalePoint(sourceRectangle.Width, sourceRectangle.Height));
            _spriteBatch.Draw(Load<Texture2D>(imageName), destinationRect, sourceRectangle, Color.White);
        }

        public static void DrawFlipped(string imageName, Vector2 position, Rectangle sourceRectangle)
        {
            var destinationRect = new Rectangle(ScalePoint(position.X, position.Y), ScalePoint(sourceRectangle.Width, sourceRectangle.Height));
            _spriteBatch.Draw(Load<Texture2D>(imageName), destinationRect, sourceRectangle, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(DefaultFont.Font, text, ScaleVector(position.X, position.Y), color, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(_rectTexture, rectangle, color);
        }

        public static void DrawRotatedOnOrigin(string texture, Vector2 position, Vector2 origin, float rotation)
        {
            _spriteBatch.Draw(Load<Texture2D>(texture), position * Scale, null, Color.White, rotation, origin, Scale, SpriteEffects.None, 0.0f);
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

        private static Vector2 ScaleVector(float x, float y)
        {
            return new Vector2(x * Scale, y * Scale);
        }

        private static Point ScalePoint(float x, float y)
        {
            return new Point((int)Math.Round(x * Scale), (int)Math.Round(y * Scale));
        }
    }
}
