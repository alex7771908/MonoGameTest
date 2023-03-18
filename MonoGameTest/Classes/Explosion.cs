using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MonoGameSpaceWar.Classes
{
    public class Explosion
    {
        private Texture2D texture; // 1983 * 117
        private Vector2 position;

        private int frameNumber = 1;
        private int width = 117;
        private int height = 117;

        private bool isLoop = true;

        private double timeTotalSeconds = 0;
        private double duration = 0.05;

        private Rectangle sourceRectangle; // нужно для рисования области текстуры

        public Explosion(Vector2 position)
        {
            texture = null;
            this.position = position;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("explosion3");
        }

        public void Update(GameTime gameTime)
        {
            //Debug.WriteLine("Time: " + gameTime.ElapsedGameTime.Seconds);
            timeTotalSeconds += gameTime.ElapsedGameTime.TotalSeconds;

            if(timeTotalSeconds > duration)
            {
                frameNumber++;
                timeTotalSeconds = 0;
            }

            if(frameNumber == 17 && isLoop)
            {
                frameNumber = 0;
            }

            sourceRectangle = new Rectangle(frameNumber * width, 0, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
        }
    }
}
