using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata.Ecma335;

namespace SquidVasion
{
    class MotionGraphic : StaticGraphic
    {
        protected Vector2 _velocity;
        Texture2D _debugPixel;

        public MotionGraphic(Texture2D art, Vector2 velocity, Texture2D debugPixel, int scale = 1) : base(art, scale)
        {
            _velocity = velocity;
            _debugPixel = debugPixel;
        }

        public void DrawMotionGraphic(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_art, Position, new Rectangle(0, 0, _art.Width, _art.Height),
                Color.White,
                0f,
                new Vector2(_art.Width * _scale / 2, _art.Height * _scale / 2),
                _scale,
                SpriteEffects.None,
                0f);

            //spriteBatch.Draw(_debugPixel, Rect, Color.White);
        }
    }
}
