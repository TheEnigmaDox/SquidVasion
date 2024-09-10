using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SquidVasion
{
    internal class PlayerShip : MotionGraphic
    {
        Vector2 _maxVelocity = new Vector2(3, 3);

        public PlayerShip(Texture2D art, Vector2 velocity, Texture2D debugPixel) : base(art, velocity, debugPixel, 1)
        {
            Position = new Vector2(100, 240);
            _velocity = velocity;
        }

        public void Update(KeyboardState keyboardState)
        {
            //Position.Y = MathHelper.Clamp(Position.Y, 0 + _art.Height, Game1.screenSize.Y - _art.Height);
            //Position.X = MathHelper.Clamp(Position.X, 0 + _art.Width, Game1.screenSize.X / 3);

            Position = Vector2.Clamp(Position, _art.Bounds.Size.ToVector2(), (Game1.screenSize - new Point(Game1.screenSize.X / 3, _art.Height)).ToVector2());

            Rect = new Rectangle(Position.ToPoint() - _art.Bounds.Center, Rect.Size);

            ShipMovement(keyboardState);
        }

        private void ShipMovement(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.W))
                _velocity.Y -= 0.2f;
            if (keyboardState.IsKeyDown(Keys.S))
                _velocity.Y += 0.2f;
            if (keyboardState.IsKeyDown(Keys.A))
                _velocity.X -= 0.2f;
            if (keyboardState.IsKeyDown(Keys.D))
                _velocity.X += 0.2f;

            if (keyboardState.GetPressedKeys().Length == 0)
                _velocity *= 0.98f;
            ReduceVelocity();

            Position += _velocity;

            //Debug.WriteLine(_velocity.Length());
        }

        private void ReduceVelocity()
        {
            if (_velocity.Length() < 0.2f)
                _velocity = Vector2.Zero;

            _velocity = Vector2.Clamp(_velocity, -_maxVelocity, _maxVelocity);
        }
    }
}
