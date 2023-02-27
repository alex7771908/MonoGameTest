using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    internal class Mine
    {
        private Vector2 position;

        private Rectangle collision;
        public Vector2 Position { set { position = value; } get { return position; } }
        private Texture2D texture;
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        public Rectangle Collision
        {
            get { return collision; }
        }
        public Mine()
        {
            position = Vector2.Zero;
            texture = null;
        }
        public Mine(Vector2 position)
        {
            this.position = position;
            texture = null;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mine");
        }

        public void Update()
        {
            position.X -= 2;

            //update collision
            collision = new Rectangle((int)position.X, (int)position.Y, Width, Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
