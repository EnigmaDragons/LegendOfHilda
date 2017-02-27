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
        
        private static float _scale { get; set; }

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch, float scale)
        {
            _scale = scale;
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
            ReallyStupidPositionTracker.Instance.Reset();
            //TODO: Shared resources between scenes might be a problem for ContentManager
            //var oldSceneContents = _sceneContents;
            //_sceneContents = new SceneContents(_content);
            _navigation.NavigateTo(sceneName);
            //oldSceneContents.Dispose();
        }

        public static void DrawBackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), ScaleVector(pixelPosition.X, pixelPosition.Y), null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }

        public static void Draw(string imageName, Rectangle rectPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), null,
                new Rectangle(ScalePoint(rectPosition.X, rectPosition.Y), ScalePoint(rectPosition.Width, rectPosition.Height)),
                null, null, 0, new Vector2(_scale, _scale));
        }

        public static void DrawRotated(string imageName, Vector2 pixelPosition, float rotation)
        {
            var texture = Load<Texture2D>(imageName);
            DrawRotated(imageName, new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, texture.Width, texture.Height), rotation);
        }

        public static void DrawRotated(string imageName, Rectangle rectPosition, float rotation)
        {
            var x = 0;
            var y = 0;
            if (rotation == Rotation.Right.Value)
            {
                x = rectPosition.Height / 2;
                y = x;
            }
            else if (rotation == Rotation.Down.Value)
            {
                x = rectPosition.Width / 2;
                y = rectPosition.Height / 2;
            }
            else if (rotation == Rotation.Left.Value)
            {
                y = rectPosition.Width / 2;
                x = y;
            }

            var origin = new Vector2(x, y);

            _spriteBatch.Draw(Load<Texture2D>(imageName), 
                null, 
                new Rectangle(ScalePoint(rectPosition.X + origin.X, rectPosition.Y + origin.Y), ScalePoint(rectPosition.Width, rectPosition.Height)), 
                null, 
                origin, 
                rotation, 
                new Vector2(_scale, _scale));
        }

        public static void DrawCentered(string imageName)
        {
            DrawCenteredWithOffset(imageName, Vector2.Zero);
        }

        public static void DrawCentered(string imageName, Vector2 WidthHeight)
        {
            DrawCenteredWithOffset(imageName, WidthHeight, Vector2.Zero);
            /*_spriteBatch.Draw(Load<Texture2D>(imageName), null,
                new Rectangle(ScalePoint(_game.GraphicsDevice.Viewport.Width / 2 / _scale - WidthHeight.X / 2,
                _game.GraphicsDevice.Viewport.Height / 2 / _scale - WidthHeight.Y / 2), ScalePoint(WidthHeight.X, WidthHeight.Y)),
                null, null, 0, new Vector2(_scale, _scale));*/
        }

        public static void DrawCenteredWithOffset(string imageName, Vector2 offSet)
        {
            var texture = Load<Texture2D>(imageName);
            DrawCenteredWithOffset(imageName, new Vector2(texture.Width, texture.Height), offSet);
        }

        public static void DrawCenteredWithOffset(string imageName, Vector2 WidthHeight, Vector2 offSet)
        {

            _spriteBatch.Draw(Load<Texture2D>(imageName), null,
                new Rectangle(ScalePoint(_game.GraphicsDevice.Viewport.Width / 2 / _scale - WidthHeight.X / 2 + offSet.X,
                _game.GraphicsDevice.Viewport.Height / 2 / _scale - WidthHeight.Y / 2 + offSet.Y), ScalePoint(WidthHeight.X, WidthHeight.Y)),
                null, null, 0, new Vector2(_scale, _scale));
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
            _spriteBatch.DrawString(DefaultFont.Font, text, ScaleVector(position.X, position.Y), color, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(_rectTexture, new Rectangle(ScalePoint(rectangle.X, rectangle.Y), ScalePoint(rectangle.Width, rectangle.Height)), color);
        }

        public static void DrawRotatedOnOrigin(string texture, Vector2 position, Vector2 origin, float rotation)
        {
            _spriteBatch.Draw(Load<Texture2D>(texture), position * _scale, null, Color.White, rotation, origin, _scale, SpriteEffects.None, 0.0f);
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
            return new Vector2(x * _scale, y * _scale);
        }

        private static Point ScalePoint(float x, float y)
        {
            return new Point((int)Math.Round(x * _scale), (int)Math.Round(y * _scale));
        }

        private struct Rotation
        {
            public static Rotation Up = new Rotation(0);
            public static Rotation Right = new Rotation((float)(Math.PI / 2));
            public static Rotation Down = new Rotation((float)Math.PI);
            public static Rotation Left = new Rotation((float)(Math.PI * 1.5));

            public float Value { get; }

            public Rotation(float value)
            {
                Value = value;
            }

            public override bool Equals(object obj)
            {
                return Math.Abs(Value - ((Rotation)obj).Value) < 0.01;
            }
        }
    }
}
