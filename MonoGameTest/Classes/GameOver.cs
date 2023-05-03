using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSpaceWar.Classes.Components;
using MonoGameTest;

namespace MonoGameSpaceWar.Classes
{
    public class GameOver
    {
        private Label label;
        private Label label2;
        private KeyboardState keyboardState; // present state
        private KeyboardState prevKeyboardState; // previous state


        public GameOver()
        {
            label = new Label("GAME OVER", new Vector2(200, 300), Color.White);
            label2 = new Label("Replay", new Vector2(500, 300), Color.Yellow);
        }

        public void LoadContent(ContentManager content)
        {
            label.LoadContent(content);
            label2.LoadContent(content);
        }

        public void Update() 
        {
            keyboardState = Keyboard.GetState();
            if (prevKeyboardState.IsKeyDown(Keys.Enter) && keyboardState.IsKeyUp(Keys.Enter))
            {
                Game1.gameMode = GameMode.GameMenu;
            }
            prevKeyboardState = Keyboard.GetState();
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            label.Draw(spriteBatch);
            label2.Draw(spriteBatch);
        }
    }
}
