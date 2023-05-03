using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vectors_2.Classes;

namespace Vectors_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public int width = 1400;
        public int height = 900;

        public Player player;
        public Enemy[] enemies;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            enemies = new Enemy[4] { new Enemy(new Vector2(0, 0)), new Enemy(new Vector2(1300, 0)), new Enemy(new Vector2(800, 0)), new Enemy(new Vector2(1300, 800)) };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadContent(Content);
            foreach (Enemy enemy in enemies)
            {
                enemy.LoadContent(Content);
            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(player, gameTime);
            }
            CheckCollisionDeath(player, enemies);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            foreach(Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void CheckCollisionDeath(Player player, Enemy[] enemies)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].collision.Intersects(player.collision))
                {
                    enemies[i].Die();
                }
            }      
        }
    }
}