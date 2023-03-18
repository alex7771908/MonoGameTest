using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using MonoGameSpaceWar.Classes;

namespace MonoGameTest
{
    public class Game1 : Game
    {
        // инструменты
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // fields
        private Player player;
        private Space space;
        //private Asteroid asteroid;
        private List<Asteroid> asteroids;
        private List<Explosion> explosions;
        private int screenHeight = 600;
        private int screenWidth = 800;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Config
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player(Content);
            space = new Space();
            //asteroid = new Asteroid();
            asteroids = new List<Asteroid>();
            explosions = new List<Explosion>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            space.LoadContent(Content);
         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            space.Update();
            UpdateAsteroids();
            CheckCollision();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            space.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateAsteroids()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                Asteroid asteroid = asteroids[i];

                asteroid.Update();

                // teleport
                if (asteroid.Position.Y > screenHeight)
                {
                    Random random = new Random();
                    int y = random.Next(-screenHeight, 0 - asteroid.Height);
                    int x = random.Next(0, screenWidth - asteroid.Width);

                    asteroid.Position = new Vector2(x, y);
                }


                if (!asteroid.IsAlive)
                {
                    
                    asteroids.Remove(asteroid);
                    i--;
                }
            }

            // загрузка доп астеройдов в игру
            if (asteroids.Count < 10)
            {
                LoadAsteroids();
            }
        }

        private void LoadAsteroids()
        {
            int rectangleHeight = screenHeight;
            int rectangleWidth = screenWidth;
            Random rnd = new Random();
            Asteroid asteroid = new Asteroid();
            asteroid.LoadContent(Content);

            int x = rnd.Next(rectangleWidth - asteroid.Width);
            int y = rnd.Next(rectangleHeight - asteroid.Height);
            Vector2 position = new Vector2(x, -y);
            asteroid.Position = position;

            asteroids.Add(asteroid);
        }

        private void CheckCollision()
        {
            foreach (var asteroid in asteroids)
            {
                if (player.Collision.Intersects(asteroid.Collision))
                {
                    asteroid.IsAlive = false;
                }

                foreach (var bullet in player.BulletList)
                {
                    if (asteroid.Collision.Intersects(bullet.Collision))
                    {
                        bullet.IsAlive = false;
                        asteroid.IsAlive = false;
                    }
                }
            }
        }
    }
}