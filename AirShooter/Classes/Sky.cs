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
    internal class Sky
    {
        #region Private variables
        private Vector2 position1;
        private Vector2 position2;
        private Texture2D texture;
        private float speed;
        #endregion

        public Sky(int speed)
        {
            position1 = Vector2.Zero;
            position2 = new Vector2(800, 0);
            this.speed = speed;
        }

        public void LoadContent(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public void Update()
        {
            #region Movement
            position1.X -= speed;
            position2.X -= speed;
            if(position1.X <= 0)
            {
                position1.X = 800;
                position2.X = 0;
            }
     
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }
    }
}
