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
using MonoGameSpaceWar.Classes;

 public class Weapon
{
    private Texture2D textureBullet;
    private Vector2 position;

    private List<Bullet> listBullet = new List<Bullet>();

    private Vector2 vectorDirection = new Vector2(0, -1);

    private int time = 0;
    private int maxTime = 30;  // ms

    public Weapon()
    {
        position = new Vector2(200, 200);
    }

    public Weapon(Vector2 pos, Vector2 dir)
    {
        position = pos;
        vectorDirection = dir;
    }

    public void LoadContent(ContentManager content)
    {
        textureBullet = content.Load<Texture2D>("asteroid");
    }

    public void Update(GameTime gameTime)
    {
        // weapon
        time++;

        if (time > maxTime)
        {
            // generate bullet
            Bullet bullet = new Bullet(textureBullet, vectorDirection);

            bullet.Position = position;

            listBullet.Add(bullet);

            time = 0;
        }

        // работа со всеми пульками в игре
        for (int i = 0; i < listBullet.Count; i++)
        {
            Bullet bullet = listBullet[i];
            bullet.Update(gameTime);
        }

        // зачистка листа
        for (int i = 0; i < listBullet.Count; i++)
        {
            if (!listBullet[i].IsAlive)
            {
                listBullet.RemoveAt(i);
                i--;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var bullet in listBullet)
        {
            bullet.Draw(spriteBatch);
        }
    }
}

