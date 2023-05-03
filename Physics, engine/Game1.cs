using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Physics_engine.Classes;
using System.Collections.Generic;

namespace Physics__engine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private static Ground ground = new Ground();
        private int screenWidth = 1920;
        private int screenHeight = 1080;
        private MouseState prevMouseState = Mouse.GetState();
        private MouseState mouseState = Mouse.GetState();
        private Slider slider;

        private List<Circles> circles;

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
            circles = new List<Circles>();
            slider = new Slider(new Vector2(300, 300), 500);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            slider.LoadContent(Content);
            ground.LoadContent(Content);
            
        }

        protected override void Update(GameTime gameTime)
        {
            

            // TODO: Add your update logic here
            ground.Update();
            circlesUpdate(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Circles c in circles)
            {
                c.Draw(_spriteBatch);
            }
            slider.Draw(_spriteBatch);
            ground.Draw(_spriteBatch);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void circlesUpdate(GameTime gameTime)
        {
            #region Spawn
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
            {
                circles.Add(new Circles(mouseState.X, mouseState.Y));
                circles[circles.Count - 1].LoadContent(Content);
            }
            prevMouseState = mouseState;
            #endregion

            foreach (Circles c in circles)
            {
                if (!c.Done)
                {
                    c.Update(ground, gameTime);
                }
                
            }
        }

    }
}