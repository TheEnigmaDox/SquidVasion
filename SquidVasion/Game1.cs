using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SquidVasion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Debug variables for showing fps
        //int frameCount = 0;
        //double elapsedTime = 0;
        //int fps = 0;
        //SpriteFont debugFont;

        public static Point screenSize = new Point(800, 480);

        public static Random rng = new Random();

        StaticGraphic background;

        Crosshair crosshair;

        PlayerShip playerShip;

        List<SpaceDust> spaceDust; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = screenSize.X;
            _graphics.PreferredBackBufferHeight = screenSize.Y;
            _graphics.ApplyChanges();

            spaceDust = new List<SpaceDust>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //debugFont = Content.Load<SpriteFont>("DebugFont");

            background = new StaticGraphic(Content.Load<Texture2D>("Textures/starfield"));

            crosshair = new Crosshair(Content.Load<Texture2D>("Textures/crosshair2"), this);

            playerShip = new PlayerShip(Content.Load<Texture2D>("Textures/rtype ship9"), Vector2.Zero);

            for(int i = 0; i < 20; i++)
            {
                spaceDust.Add(new SpaceDust(Content.Load<Texture2D>("Textures/pixel"), new Vector2(rng.Next((int)1, 5), 0), Game1.rng.Next(1, 5)));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            crosshair.Update(Mouse.GetState());

            playerShip.Update(Keyboard.GetState());

            for (int i = 0; i < spaceDust.Count; i++)
            {
                SpaceDust eachDust = spaceDust[i];
                eachDust.UpdateSpaceDust();
            }

            //Debug for fps
            //elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;

            //frameCount++;

            //if (elapsedTime >= 1.0)
            //{
            //    fps = frameCount;
            //    frameCount = 0;
            //    elapsedTime -= 1.0;
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            background.Draw(_spriteBatch);

            crosshair.CrossHair(_spriteBatch);

            playerShip.DrawMotionGraphic(_spriteBatch);

            for (int i = 0; i < spaceDust.Count; i++)
            {
                SpaceDust eachDust = spaceDust[i];
                eachDust.DrawMotionGraphic(_spriteBatch);
            }

            //_spriteBatch.DrawString(debugFont, $"FPS: {fps}", new Vector2(10, 10), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
