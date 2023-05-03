using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Physics_engine.Classes;

namespace Physics_engine.Classes
{
    public class Circles
    {
        private Texture2D texture;
        //private Texture2D collisionTexture;
        private Rectangle destinationRectangle;
        private Rectangle collision;
        bool done = false;
        public bool Done { get { return done; } }
        public Rectangle CircleCollision
        {
            get { return collision; }
        }
        private double ySpeed;
        private double yAcceleration;

        public Circles(int x, int y)
        {
            destinationRectangle = new Rectangle(x - 50, y - 50, 100, 100);
            ySpeed = 0;
            yAcceleration = 20;
            collision = destinationRectangle;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("circle");
            //collisionTexture = content.Load<Texture2D>("collision");
        }

        public void Update(Ground ground, GameTime gameTime)
        {
            if (!this.CircleCollision.Intersects(ground.GroundCollision))
            {
                destinationRectangle = new Rectangle(destinationRectangle.X, (int)Math.Floor(destinationRectangle.Y + ySpeed * gameTime.ElapsedGameTime.TotalSeconds), 100, 100);
                collision = destinationRectangle;
                ySpeed += yAcceleration;

            }
            else
            {
                int inside = collision.Y + 100 - ground.GroundCollision.Y;
                if (inside >= 0)
                {
                    destinationRectangle.Y -= inside - 2;
                    collision = destinationRectangle;
                    done = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
            //spriteBatch.Draw(collisionTexture, collision, Color.Green);
        }
    }
}
