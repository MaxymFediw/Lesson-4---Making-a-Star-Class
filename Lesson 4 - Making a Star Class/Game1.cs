using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Lesson_4___Making_a_Star_Class //Maxym F
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        SpriteFont _titleFont;

        KeyboardState _keyboardState;

        Rectangle window;
        Rectangle shipRect;

        Texture2D shipTexture;
        Texture2D starTexture;
        Texture2D windowTexture;

        Star star1;

      

        List<Star> stars;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            shipRect = new Rectangle(250, 250, 150, 40);

            


            base.Initialize();

            star1 = new Star(starTexture, new Rectangle(100, 100, 2, 2), new Vector2(-2, 0));

            stars = new List<Star>();
            for (int i = 0; i < 150; i++)
            {
                int x, y;
                x = generator.Next(window.Width);
                y = generator.Next(window.Height);
                Rectangle star = new Rectangle(x, y, 3, 3);
                stars.Add(new Star(starTexture, star, new Vector2(-2, 0)));
            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            shipTexture = Content.Load<Texture2D>("Images/enterprise");

            starTexture = Content.Load<Texture2D>("Images/circle");

            windowTexture = Content.Load<Texture2D>("Images/shipWindow");

            _titleFont = Content.Load<SpriteFont>("Fonts/BTTF");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.W)) 
            {
                shipRect.Y -= 2;
            }

            if (_keyboardState.IsKeyDown(Keys.S)) 
            {
                shipRect.Y += 2;
            }

            star1.Update(window);

            foreach (Star star in stars)
                star.Update(window);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();


            star1.Draw(_spriteBatch);

            foreach (var star in stars)
                star.Draw(_spriteBatch);

            _spriteBatch.Draw(shipTexture, shipRect, Color.White);

            _spriteBatch.Draw(windowTexture, window, Color.White);

            _spriteBatch.DrawString(_titleFont, "Press K To Go Into Warp Drive!", new Vector2(12, 67), Color.White);


            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
