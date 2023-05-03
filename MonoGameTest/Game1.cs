using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using MonoGameSpaceWar.Classes;
using MonoGameSpaceWar.Classes.Components;


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

        public static GameMode gameMode = GameMode.GameMenu;

        //private Asteroid asteroid;
        private List<Asteroid> asteroids;
        private List<Explosion> explosions;
        private List<Label> labels;
        private MainMenu mainMenu = new MainMenu();
        private GameOver gameOver = new GameOver();
        private HUD hud = new HUD();
        private Weapon weapon = new Weapon();
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
            labels = new List<Label>();

            player.TakeDamage += hud.OnPlayerTakeDamage;

            player.ScoreUpdated += hud.OnScoreChanging;

            space.Speed = 0.5f;

            weapon = new Weapon(new Vector2(350, 100), new Vector2(0, 1));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);
            space.LoadContent(Content);
            mainMenu.LoadContent(Content);
            gameOver.LoadContent(Content);
            hud.LoadContent(Content);
            weapon.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here
            switch (gameMode)
            {
                case GameMode.GamePlay:
                    player.Update(gameTime);
                    space.Speed = 5f;
                    space.Update();
                    UpdateAsteroids();
                    CheckCollision();
                    UpdateExplosions(gameTime);
                    hud.Update();
                    UpdateLabels(gameTime);
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        gameMode = GameMode.GameMenu;
                    space.Speed = 0.5f;
                    weapon.Update(gameTime);
                    break;
                
                case GameMode.GameMenu:
                    space.Update();
                    space.Speed = 5f;
                    mainMenu.Update();
                    break;

                case GameMode.GameOver:
                    gameOver.Update();
                    space.Speed = 0.5f;
                    break;

                case GameMode.GameExit:
                    Exit();
                    break;
            }


            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            switch (gameMode)
            {
                case GameMode.GamePlay:
                    
                    space.Draw(_spriteBatch);
                    player.Draw(_spriteBatch);
                    foreach (Asteroid asteroid in asteroids)
                    {
                        asteroid.Draw(_spriteBatch);
                    }

                    foreach (var explosion in explosions)
                    {
                        explosion.Draw(_spriteBatch);
                    }

                    foreach (var label in labels)
                    {
                        label.Draw(_spriteBatch);
                    }

                    hud.Draw(_spriteBatch);
                    weapon.Draw(_spriteBatch);
                    break;

                case GameMode.GameMenu:
                    space.Draw(_spriteBatch);
                    mainMenu.Draw(_spriteBatch);                 
                    break;

                case GameMode.GameOver:
                    gameOver.Draw(_spriteBatch);
                    break;
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

        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Update(gameTime);
                if (!explosions[i].IsAlive)
                {
                    explosions.RemoveAt(i);
                    i--;
                }
            }
        }

        private void UpdateLabels(GameTime gameTime)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Update(gameTime);
                if (!labels[i].IsAlive)
                {
                    labels.RemoveAt(i);
                    i--;
                }
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
                Vector2 position = new Vector2(asteroid.Position.X - asteroid.Width, asteroid.Position.Y - asteroid.Width);
                if (player.Collision.Intersects(asteroid.Collision))
                {
                    asteroid.IsAlive = false;

                    player.Damage();

                    Explosion explosion = new Explosion(position);
                    explosion.LoadContent(Content);
                    explosions.Add(explosion);

                    Label label = new Label("HIT", position, Color.Red);
                    label.LoadContent(Content);
                    labels.Add(label);
                }

                foreach (var bullet in player.BulletList)
                {
                    if (asteroid.Collision.Intersects(bullet.Collision))
                    {
                        bullet.IsAlive = false;
                        asteroid.IsAlive = false;


                        Explosion explosion = new Explosion(position);
                        explosion.LoadContent(Content);
                        explosions.Add(explosion);

                        Label label = new Label("KILL", position, Color.Red);
                        label.LoadContent(Content);
                        labels.Add(label);
                    }
                }
            }
        
        }

        public void SpaceSpeedChange(float speed)
        {
            space.Speed = speed;
        }
    }
}