using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SquidVasion
{
    internal class Rocket : MotionGraphic
    {
        int _speed = 10;

        public Rocket(Texture2D art, Vector2 velocity, Vector2 position) : base(art, velocity)
        {
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            Position -= _velocity * _speed /*(float)gameTime.TotalGameTime.TotalSeconds*/;
        }
    }
}
