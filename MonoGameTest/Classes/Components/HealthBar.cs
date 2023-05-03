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
    internal class HealthBar
    {
        private Texture2D texture;
        private Vector2 position;
        private int height;
        private int numParts;
        private int widthSegment;

        public int NumParts
        {
            set { numParts = value; }
            get { return numParts; }
        }

        public Rectangle DestinationRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, widthSegment * numParts, height);
            }
        }

        public HealthBar(Vector2 position, int numParts, int width, int height)
        {
            this.position = position;
            this.height = height;
            this.numParts = numParts;

            widthSegment = width / numParts;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("healthbar");
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, DestinationRectangle, Color.White);
        }
    }
}
