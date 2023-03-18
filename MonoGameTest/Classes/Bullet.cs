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
        private bool isAlive = true;
        public int Width { get { return width; } }
        public int Height { get { return height; } }
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
        public Bullet()
        {
            texture = null;
            destinationRectangle = new Rectangle(0, 0, width, height);
        }
        public Bullet(Vector2 position)
        {
            texture = null;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("bullet");     
        } 

        public void Update()
        {
            destinationRectangle.Y -= 6;
            if(Position.Y < 0 - height)
            {
                isAlive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }
    }
}
