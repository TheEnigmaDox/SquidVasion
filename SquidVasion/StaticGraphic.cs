using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SquidVasion
{
    internal class StaticGraphic
    {
        protected Vector2 _position;

        protected Texture2D _art;

        public StaticGraphic(Texture2D art, Vector2 position) 
        {
            _art = art; 
            _position = position;
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_art, 
                _position,
                new Rectangle((int)_position.X, (int)_position.Y, _art.Width, _art.Height),
                Color.White,
                0f,
                new Vector2(_art.Width / 2, _art.Height / 2),
                1f,
                SpriteEffects.None,
                0f);
        }
    }
}
