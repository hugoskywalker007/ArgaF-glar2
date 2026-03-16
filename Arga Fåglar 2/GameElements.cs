using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arga_Fåglar_2
{
    internal class GameElements
    {
        //medlemsvariabler
        static RödFågel rödFågel;
        static List<ProjektilMarkering> markeringar;

        //olika gamestates
        public enum State { Menu, Run, HighScore, Quit }; //de olika statesen i spelet
        public static State currentState; //det nuvarande staten

        //initialize
        public static void Initialize()
        {

        }

        //background


        //menu
        static Menu menu;

        //load
        public static void LoadContet(ContentManager content, GameWindow window)
        {
            //fåglar
            rödFågel = new RödFågel(content.Load<Texture2D>("images/fåglar/röd_fågel"), 100, 1000, 50, -50);

            //markeringar
            markeringar = new List<ProjektilMarkering>();
            Texture2D tmpSprite = content.Load<Texture2D>("images/vfx/markering");
            ProjektilMarkering temp = new ProjektilMarkering(tmpSprite, rödFågel.X, rödFågel.Y);
            markeringar.Add(temp);

            //menu
            menu = new Menu((int)State.Menu);
            menu.AddItem(content.Load<Texture2D>("images/menu/start"), (int)State.Run);
            menu.AddItem(content.Load<Texture2D>("images/menu/highscore"), (int)State.HighScore);
            menu.AddItem(content.Load<Texture2D>("images/menu/exit"), (int)State.Quit);
        }

        //menu update
        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);
        }

        //menu draw
        public static void menuDraw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }

        //run update
        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {
            rödFågel.Update(window, gameTime);
            foreach (ProjektilMarkering p in markeringar.ToList())
            {
                p.Update(window, gameTime);
            }
            return State.Run;
        }

        //run draw
        public static void RunDraw(SpriteBatch spriteBatch)
        {
            rödFågel.Draw(spriteBatch);
            foreach (ProjektilMarkering p in markeringar)
            {
                p.Draw(spriteBatch);
            }
        }


        //highscore update


        //highscore draw



    }
}
