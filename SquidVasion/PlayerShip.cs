using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SquidVasion
{
    internal class PlayerShip : MotionGraphic
    {
        public PlayerShip(Texture2D art, Vector2 position) : base(art, position)
        {
            _position = new Vector2(400, 240);
        }

        public void Update()
        {

        }
    }
}
