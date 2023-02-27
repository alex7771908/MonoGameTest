using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSpaceWar.Classes
{
    public enum TypePlayer { Beginner, Intermediate, Advanced, Pro, God}
    
    public class Player
    {
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        private TypePlayer playerType;
        private Rectangle collision;
        public Rectangle Collision
        {
            get { return collision; }
        }

        public Player()
        {
            position = new Vector2(350 , 175);
            texture = null;
            speed = 3;
            playerType = TypePlayer.Beginner;
            
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            #region Control
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            else if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;

            }
            #endregion

            #region Boundaries
            if (position.X < 0)
            {
                position.X = 0;
            }else if(position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }

            if(position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }
            #endregion

            //collision
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
