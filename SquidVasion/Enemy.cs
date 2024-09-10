using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace SquidVasion
{
    internal class Enemy : AnimatedGraphic
    {
        public bool Collided { get; private set; }
        public Enemy(Texture2D art, Vector2 velocity, Vector2 frameSize, int numOfFrames, float fps) :
            base(art, velocity, frameSize, numOfFrames, fps)
        {
            Position = new Vector2(Game1.screenSize.X + _art.Width, Game1.rng.Next(0, Game1.screenSize.Y));

            Collided = false;
        }

        public void Update(Rectangle playerRect)
        {
            UpdateRect();

            Position -= _velocity;

            if (Position.X < 0 - _art.Width)
            {
                Position = new Vector2(Game1.screenSize.X + _art.Width, Game1.rng.Next(0, Game1.screenSize.Y));
                _velocity = new Vector2(Game1.rng.Next(1, 5), 0);
            }

            if (Rect.Intersects(playerRect))
            {
                Collided = true;
            }

            Debug.WriteLine(Collided);
        }

        void UpdateRect()
        {
            Rect = new Rectangle((int)Position.X, (int)Position.Y, _art.Width / 2, _art.Height);
        }
    }
}
