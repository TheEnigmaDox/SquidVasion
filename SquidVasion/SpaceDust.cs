using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SquidVasion
{
    internal class SpaceDust : MotionGraphic
    {
        public SpaceDust(Texture2D art, Vector2 velocity, int scale, Texture2D debugPixel) : base(art, velocity, debugPixel, 2)
        {
            Position = new Vector2(Game1.rng.Next(0, Game1.screenSize.X), Game1.rng.Next(0, Game1.screenSize.Y));
            _velocity = velocity;
            _scale = scale;
        }

        public void UpdateSpaceDust()
        {
            if(Position.X < -5)
            {
                Position = new Vector2(Game1.screenSize.X + 5, Game1.rng.Next(0, Game1.screenSize.Y));
                _velocity.X = Game1.rng.Next(1, 5);
            }

            Position += -_velocity;

            //Debug.WriteLine(Position);
        }
    }
}
