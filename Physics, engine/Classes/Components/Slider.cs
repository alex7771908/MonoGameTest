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
    public class Slider
    {
        private float value;
        private Vector2 positionLine;
        private Vector2 positionCircle;
        private int lengthLine;
        private Texture2D textureCircle;
        private Texture2D textureLine;

        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private float maxValue;

        public float MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public Slider()
        {
        }

        public Slider(Vector2 position, int length)
        {
            positionLine = position;
            lengthLine = length;   
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyUp(Keys.S) && state.IsKeyDown(Keys.S))
            {
            }
            KeyboardState prevState = Keyboard.GetState();
        }
        public void LoadContent(ContentManager content)
        {
            textureCircle = content.Load<Texture2D>("sliderCircle");
            textureLine = content.Load<Texture2D>("sliderLine");
            positionCircle = new Vector2(positionLine.X - textureCircle.Width / 2, positionLine.Y - textureCircle.Height / 2 + 15);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureLine, positionLine, Color.White);
            spriteBatch.Draw(textureCircle, positionCircle, Color.White);
        }
    }
}