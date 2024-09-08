using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SquidVasion
{
    internal class StaticGraphic
    {
        protected int _scale = 1;

        protected Vector2 _position;

        protected Texture2D _art;

        public StaticGraphic(Texture2D art, int scale = 1) 
        {
            _art = art; 
            _position = new Vector2(Game1.screenSize.X / 2, Game1.screenSize.Y / 2);
            _scale = scale;
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_art, 
                _position,
                new Rectangle(0, 0, _art.Width, _art.Height),
                Color.White,
                0f,
                new Vector2(_art.Width / 2, _art.Height / 2),
                1f,
                SpriteEffects.None,
                0f);
        }
    }
}
