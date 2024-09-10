using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace SquidVasion
{
    internal class AnimatedGraphic : MotionGraphic
    {
        int _currentFrame = 1;
        int _numOfFrames;
        float _framesPerSecond;
        float _maxFramesPerSecond;
        Vector2 _frameSize;

        Rectangle _sourceRect;
        public AnimatedGraphic(Texture2D art, Vector2 velocity, Vector2 frameSize, int numOfFrames, float fps) :
            base(art, velocity) 
        {
            _maxFramesPerSecond = fps;

            _framesPerSecond = _maxFramesPerSecond;

            _numOfFrames = numOfFrames;

            _frameSize = frameSize;

            _sourceRect = new Rectangle(0, 0, _art.Width / 2, _art.Height);
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            if (_currentFrame <= _numOfFrames && _framesPerSecond < 0)
            {
                _currentFrame++;

                _sourceRect.X += (int)_frameSize.X;

                _framesPerSecond = _maxFramesPerSecond;

                if (_currentFrame > _numOfFrames)
                {
                    _currentFrame = 1;
                    _sourceRect.X = 0;
                }
            }
            else
            {
                _framesPerSecond -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //Debug.WriteLine("Frames Per Second : " + _framesPerSecond);
            //Debug.WriteLine("Current Frame : " + _currentFrame);
        }

        public void DrawAnimation(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_art, Position, _sourceRect, Color.White);

            //spriteBatch.Draw(_debugPixel, Rect, Color.Red);
        }
    }
}
