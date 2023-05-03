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
    public class Bullet
    {
        private Rectangle destinationRectangle;
        private Texture2D texture;
        private int width = 15;
        private int height = 75;
        private int speed = 200;
        private bool isAlive = true;
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        private Vector2 vectorDirection = new Vector2(1, 0);
        public Vector2 Position
        { 
            get 
            { 
                return new Vector2(destinationRectangle.X, destinationRectangle.Y); 
            }
            set
            {
                destinationRectangle.X = (int)value.X;
                destinationRectangle.Y = (int)value.Y;
            }
        }
        public Rectangle Collision
        {
            get { return destinationRectangle; }
        }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public Bullet(Vector2 vectorDirection)
        {
            texture = null;
            this.vectorDirection = vectorDirection;
            destinationRectangle = new Rectangle(0, 0, width, height);
        }

        public Bullet(Texture2D texture, Vector2 vectorDirection)
        {
            this.texture = texture;
            destinationRectangle = new Rectangle(0, 0, width, height);
            this.vectorDirection = vectorDirection;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("bullet");     
        } 

        public void Update(GameTime gameTime)
        {
            //destinationRectangle.Y -= 6;
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 vectorVelocity = vectorDirection * speed;

            Position = Position + vectorVelocity * delta;

            if(Position.Y < 0 - height || Position.X < -width || Position.Y > 600 || Position.X > 800 )
            {
                isAlive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.Black);
        }
    }
}
