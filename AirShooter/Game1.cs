using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using AirShooter.Classes;
using System;

namespace AirShooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Sky sky1;
        private Sky sky2;
        private Sky sky3;
        private Sky[] skies;
        private List<Mine> mines;
        private int screenWidth = 800;
        private int screenHeight = 450;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            sky1 = new Sky(1);
            sky2 = new Sky(2);
            sky3 = new Sky(4);
            skies = new Sky[3] { sky1, sky2, sky3};
            mines = new List<Mine>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            sky1.LoadContent(Content, "mainbackground");
            sky2.LoadContent(Content, "bgLayer1");
            sky3.LoadContent(Content, "bgLayer2");
            int rectangleHeight = screenHeight;
            int rectangleWidth = screenWidth;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Mine mine = new Mine();
                mine.LoadContent(Content);

                int x = random.Next(screenWidth, screenWidth * 2);
                int y = random.Next(rectangleHeight - mine.Height);
                Vector2 position = new Vector2(x, y);
                mine.Position = position;

                mines.Add(mine);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update();
            foreach (Sky sky in skies)
            {
                sky.Update();
            }
            foreach(Mine mine in mines)
            {
                mine.Update();
                if(mine.Position.X <= 0 - mine.Width)
                {
                    Random random = new Random();
                    int x = random.Next(screenWidth, screenWidth*2);
                    int y = random.Next(screenHeight - mine.Height);
                    Vector2 position = new Vector2(x, y);
                    mine.Position = position;
                }

                if (mine.Collision.Intersects(player.Collision))
                {
                    //FIX
                    Exit();
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Sky sky in skies)
            {
                sky.Draw(_spriteBatch);
            }
            foreach (Mine mine in mines)
            {
                mine.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}