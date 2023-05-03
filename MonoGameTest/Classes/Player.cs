using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameTest;

namespace MonoGameSpaceWar.Classes
{
    public enum TypePlayer { Beginner, Intermediate, Advanced, Pro, God}
    
    public class Player
    {
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        private TypePlayer playerType;
        private Rectangle collision;
        private ContentManager content;

        private List<Bullet> bulletList = new List<Bullet>();

        private int time = 0;
        private int maxTime = 60;

        //data
        private int health = 10;
        private int score = 12;

        //events
        public event Action TakeDamage;
        public event Action<int> ScoreUpdated;
        
        public Rectangle Collision
        {
            get { return collision; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public List<Bullet> BulletList { get { return bulletList; } }

        public Player(ContentManager manager)
        {
            position = new Vector2(350 , 175);
            texture = null;
            speed = 3;
            playerType = TypePlayer.Beginner;
            content = manager; 
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
            
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            #region Control
            if (keyboardState.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            else if (keyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;

            }
            #endregion

            #region Boundaries
            if (position.X < 0)
            {
                position.X = 0;
            }else if(position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }

            if(position.Y < 0)
            {
                position.Y = 0;
            }
            else if (position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }
            #endregion

            //collision
            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            time++;

            if(time > maxTime & Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Bullet bullet = new Bullet(new Vector2(0, -1));
                bullet.Position = new Vector2(position.X + texture.Width / 2 - bullet.Width / 2,
                    position.Y - bullet.Height / 2);
                bullet.LoadContent(content);
                bulletList.Add(bullet);

                time = 0;
            }

            for(int i = 0; i < bulletList.Count; i++)
            {
                Bullet bullet = bulletList[i];
                bullet.Update(gameTime);
            }

            for(int i =0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].IsAlive)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }
            spriteBatch.Draw(texture, position, Color.White);
        }

        //business logic
        public void Damage()
        {
            health--;

            if(TakeDamage != null)
            {
                TakeDamage();
            }

            if(health <= 0)
            {
                Game1.gameMode = GameMode.GameOver;
          
            }
        }

        public void Score(int score)
        {
            this.score ++;
            if(ScoreUpdated != null)
            {
                ScoreUpdated(score);
            }
        }

    }
}
