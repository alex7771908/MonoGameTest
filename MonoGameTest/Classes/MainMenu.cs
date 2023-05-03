using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSpaceWar.Classes.Components;
using MonoGameTest;
using System.Collections.Generic;


namespace MonoGameSpaceWar.Classes
{
    public class MainMenu
    {
        private List<Label> buttonList = new List<Label>();
        private int selected;
        private KeyboardState keyboardState; // present state
        private KeyboardState prevKeyboardState; // previous state

        private Vector2 position = new Vector2(400, 250);

        public MainMenu()
        {
            selected = 0;
            buttonList.Add(new Label("Play", position, Color.White));
            buttonList.Add(new Label("Exit", new Vector2(position.X, position.Y + 60), Color.White));
            buttonList.Add(new Label("SPACEWARS", new Vector2(position.X, position.Y - 60), Color.White));
        }

        public void LoadContent(ContentManager content)
        {
            foreach(var item in buttonList)
            {
                item.LoadContent(content);
            }

            for(int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Position = new Vector2(buttonList[i].Position.X - buttonList[i].Width / 2, buttonList[i].Position.Y);
            }
        }

        public void Update()
        {
            keyboardState = Keyboard.GetState();



            if (prevKeyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyUp(Keys.S))
            {
                if(selected < buttonList.Count - 1)
                {
                    selected++;
                }
            }
            if (prevKeyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyUp(Keys.W))
            {
                if (selected > 0)
                {
                    selected--;
                }
            }
            

            //Event Click
            if (prevKeyboardState.IsKeyDown(Keys.Enter) && keyboardState.IsKeyUp(Keys.Enter))
            {
                if (selected == 0)
                {
                    Game1.gameMode = GameMode.GamePlay;
                    //Game1.SpaceSpeedChange(5f);
                }
                else if(selected == 1)
                {
                    Game1.gameMode = GameMode.GameExit;
                }
            }

            prevKeyboardState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color colorSelected;
            for(int i = 0; i < buttonList.Count; i++)
            {
                if(selected == i)
                {
                    colorSelected = Color.Yellow;
                }
                else
                {
                    colorSelected = Color.White;
                }

                buttonList[i].Color = colorSelected;
                buttonList[i].Draw(spriteBatch);
            }
        }
    }
}
