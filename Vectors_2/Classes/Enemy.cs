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

namespace Vectors_2.Classes
{
    public class Enemy
    {
        public Texture2D texture;
        public Vector2 position;

        public float speed;

        public bool isAlive = true;

        public Rectangle collision;

        public Enemy()
        {
            position = new Vector2(50, 50);
            texture = null;
            collision = new Rectangle();
            speed = 200;
        }

        public Enemy(Vector2 pos)
        {
            this.position = pos;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("enemy");
        }

        public void Update(Player player, GameTime gameTime)
        {
            if (isAlive)
            {
                GoToTarget(player, gameTime);

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

                speed += 0.05f;

                collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
            
            
        }

        public void GoToTarget(Player player, GameTime gameTime)
        {
            Vector2 vDist = player.position - position;
            vDist.Normalize();
            Vector2 vDirection = vDist;
            Vector2 vVelocity = vDirection * speed;
            position += vVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Die()
        {
            isAlive = false;    
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
            
        }
    }
}
