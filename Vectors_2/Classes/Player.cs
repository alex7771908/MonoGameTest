using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Vectors_2.Classes;
using System.Diagnostics;

namespace Vectors_2.Classes
{
    public class Player
    {
        public Texture2D texture;
        public Vector2 position;
        public float speed;

        public Rectangle collision;

        public Player()
        {
            position = new Vector2(200, 200);
            texture = null;
            speed = 250;
            collision = new Rectangle();
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player"); 
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            float secs = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.W))
            {
                position.Y -= speed * secs;
            }else if (keyState.IsKeyDown(Keys.S))
            {
                position.Y += speed * secs;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                position.X += speed * secs;
            } else if (keyState.IsKeyDown(Keys.A))
            {
                position.X -= speed * secs;
            }
            
            //Debug.Print(Convert.ToString(speed));
            #region Borders
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= 1400 - texture.Width)
            {
                position.X = 1400 - texture.Width;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.Y >= 900 - texture.Height)
            {
                position.Y = 900 - texture.Height;
            }
            #endregion

            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
