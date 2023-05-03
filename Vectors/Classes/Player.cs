using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Vectors.Classes
{
    public class Player
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        public Vector2 windSpeed;

        public Player()
        {
            position = new Vector2(20, 20);
            velocity = new Vector2(100, 100);
            windSpeed = new Vector2(100, 0);
            texture = null;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("1f388");
        }

        public void Update(GameTime gameTime)
        {
            position += (velocity + windSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
