using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SquidVasion
{
    class Crosshair : StaticGraphic
    {
        float _rotation;

        Color _tint = Color.White;  

        Vector2 _centrePoint;

        Rectangle _screenBounds;

        Game1 _gameOne;

        public Crosshair(Texture2D art, Game1 game1) : base(art) 
        {
            _screenBounds = new Rectangle(0, 0, Game1.screenSize.X, Game1.screenSize.Y);
            _gameOne = game1;
        }

        public void Update(MouseState mouseState)
        {
            _centrePoint = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                _tint = Color.Red;
            }
            else
            {
                _tint = Color.White;
            }

            if (_screenBounds.Contains(_centrePoint))
            {
                _gameOne.IsMouseVisible = false;
            }
            else
            {
                _gameOne.IsMouseVisible = true;
            }

            _rotation += 0.1f;
        }

        public void CrossHair(SpriteBatch spritebatch)
        {
            if (_screenBounds.Contains(_centrePoint))
            {
                spritebatch.Draw(_art,
                        _centrePoint,
                        new Rectangle(0, 0, _art.Width, _art.Height),
                        _tint,
                        _rotation,
                        new Vector2(_art.Width / 2, _art.Height / 2),
                        2f,
                        SpriteEffects.None,
                        0); 
            }
        }
    }
}
