using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SquidVasion
{
    internal class PlayerShip : MotionGraphic
    {
        Vector2 _maxVelocity = new Vector2(3, 3);
        Vector2 _maxNegVelocity = new Vector2(-3, -3);

        public PlayerShip(Texture2D art, Vector2 velocity) : base(art, velocity)
        {
            _position = new Vector2(100, 240);
            _velocity = velocity;
        }

        public void Update(KeyboardState keyboardState)
        {
            _position.Y = MathHelper.Clamp(_position.Y, 0 + _art.Height, Game1.screenSize.Y - _art.Height);
            _position.X = MathHelper.Clamp(_position.X, 0 + _art.Width, Game1.screenSize.X / 3);

            ShipMovement(keyboardState);
        }

        private void ShipMovement(KeyboardState keyboardState)
        {
            if (_velocity.Y > _maxNegVelocity.Y && keyboardState.IsKeyDown(Keys.W))
            {
                _velocity.Y -= 0.5f;
            }
            else if (_velocity.Y != 0 && keyboardState.IsKeyUp(Keys.W))
            {
                ReduceVelocity();
            }

            if (_velocity.Y < _maxVelocity.Y && keyboardState.IsKeyDown(Keys.S))
            {
                _velocity.Y += 0.5f;
            }
            else if (_velocity.Y != 0 && keyboardState.IsKeyUp(Keys.S))
            {
                ReduceVelocity();
            }

            if (_velocity.X > _maxNegVelocity.Y && keyboardState.IsKeyDown(Keys.A))
            {
                _velocity.X -= 0.2f;
            }
            else if (_velocity.X != 0 && keyboardState.IsKeyUp(Keys.A))
            {
                ReduceVelocity();
            }

            if (_velocity.X < _maxVelocity.Y && keyboardState.IsKeyDown(Keys.D))
            {
                _velocity.X += 0.2f;
            }
            else if (_velocity.X != 0 && keyboardState.IsKeyUp(Keys.D))
            {
                ReduceVelocity();
            }

            _position += _velocity;

            //Debug.WriteLine(_velocity);
        }

        private void ReduceVelocity()
        {
            if (_velocity.Y < -0.5f)
            {
                _velocity.Y += 0.02f;

                if (_velocity.Y > -0.5f)
                {
                    _velocity.Y = 0;
                }
            }
            else if (_velocity.Y > 0.5f)
            {
                _velocity.Y -= 0.02f;

                if (_velocity.Y < 0.5f)
                {
                    _velocity.Y = 0;
                }
            }

            if (_velocity.X < -0.5f)
            {
                _velocity.X += 0.02f;

                if (_velocity.X > -0.5)
                {
                    _velocity.X = 0;
                }
            }
            else if (_velocity.X > 0.5f)
            {
                _velocity.X -= 0.02f;

                if (_velocity.X < 0.5f)
                {
                    _velocity.X = 0;
                }
            }
        }
    }
}
