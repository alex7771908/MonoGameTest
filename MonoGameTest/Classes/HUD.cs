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

namespace MonoGameSpaceWar.Classes
{
    public class HUD
    {
        private HealthBar healthBar;
        private Label labelScore;

        public HUD()
        {
            Vector2 position = new Vector2(10, 10);
            healthBar = new HealthBar(position, 10, 200, 25);
            labelScore = new Label("SCORE: 0",Vector2.Zero, Color.White);
        }

        public void LoadContent(ContentManager content)
        {
            healthBar.LoadContent(content);
            labelScore.LoadContent(content);
            labelScore.Position = new Vector2(800 - labelScore.Width - 10, 10);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            healthBar.Draw(spriteBatch);
            labelScore.Draw(spriteBatch);
        }

        public void OnPlayerTakeDamage()
        {
            healthBar.NumParts--;
        }

        public void OnScoreChanging(int score)
        {
            labelScore.Text = "SCORE: " + score;
        }
    }
}
