using MonoDragons.Ecstasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLegendOfHilda.Components;

namespace TheLegendOfHilda.Systems.Rendering
{
    class Font
    {
    }

    class Text : IRenderable
    {
        public string Content { get; internal set; }

        internal void SetCharacterSize(object textCharacterSize)
        {
            throw new NotImplementedException();
        }

        internal void SetFont(Font font)
        {
            throw new NotImplementedException();
        }

        internal void SetPoition(Point2D point2D)
        {
            throw new NotImplementedException();
        }

        internal void SetColor(string textColor)
        {
            throw new NotImplementedException();
        }
    }

    class RenderSystem : ISystem<Keys>
    {
        public Keys RequiredComponents { get; }
            = Keys.Position | Keys.Opacity | Keys.Renderable;

        ElapsedGameTime _lastUpdate = ElapsedGameTime.Zero;
        FrameCount _frameCount = FrameCount.Zero;
        RenderSettings _settings;
        RenderTarget _target;
        Text _text;

        public RenderSystem(RenderTarget target, Font font, RenderSettings settings)
        {
            _target = target;

            _text = new Text();
            _text.SetFont(font);
            _text.SetPoition(new Point2D(2, 2));
            _text.SetCharacterSize(settings.TextCharacterSize);
            _text.SetColor(settings.TextColor);
        }

        public void Update(IEngine engine)
        {
            foreach (var entity in engine.Entities(RequiredComponents))
            {
                var position = entity.Component<Position>();
                var renderable = entity.Component<Renderable>();
                var opacity = entity.Component<Opacity>();

                var fillColor = renderable.FillColor;
                fillColor.A = (byte)(opacity.Alpha * 255);

                renderable.FillColor = fillColor;
                renderable.Location = new Point2D(position.X, position.Y);

                var render = renderable.Render();
                _target.Draw(render);
            }

            _frameCount.Tick();
            _lastUpdate += engine.Elapsed;

            if (_lastUpdate >= _settings.FpsFrequency)
            {
                var fps = (long)(_frameCount / _lastUpdate);
                var content = engine.Debug(fps);
                _text.Content = content;

                _lastUpdate = ElapsedGameTime.Zero;
                _frameCount.Reset();
            }
            _target.Draw(_text);
        }
    }
}
