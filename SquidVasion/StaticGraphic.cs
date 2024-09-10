using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SquidVasion
{
    internal class StaticGraphic
    {
        protected int _scale = 1;

        public Vector2 Position { get; set; }

        public Rectangle Rect { get; protected set; }

        public Texture2D _art;

        public StaticGraphic(Texture2D art, int scale = 1) 
        {
            _art = art; 
            Position = new Vector2(Game1.screenSize.X / 2, Game1.screenSize.Y / 2);
            _scale = scale;

            Rect = new Rectangle((int)Position.X - _art.Width / 2, (int)Position.Y - _art.Height / 2, _art.Width, _art.Height);
        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_art, 
                Position,
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
