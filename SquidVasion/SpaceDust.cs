using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SquidVasion
{
    internal class SpaceDust : MotionGraphic
    {
        public SpaceDust(Texture2D art, Vector2 velocity, int scale) : base(art, velocity, scale)
        {
            _position = new Vector2(Game1.screenSize.X, Game1.rng.Next(0, Game1.screenSize.Y));
            _velocity = velocity;
            _scale = scale;
        }

        public void UpdateSpaceDust()
        {
            if(_position.X < -5)
            {
                _position = new Vector2(Game1.screenSize.X + 5, Game1.rng.Next(0, Game1.screenSize.Y));
                _velocity.X = Game1.rng.Next(1, 5);
            }

            _position.X += -_velocity.X;

            Debug.WriteLine(_position);
        }
    }
}
