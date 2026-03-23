using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arga_Fåglar_2
{
    internal class GameElements
    {
        //medlemsvariabler
        static List<Fågel> fåglar;
        static RödFågel rödFågel;
        static Texture2D rödFågelSprite;
        static BlåFågel blåFågel;
        static Texture2D blåFågelSprite;
        static GulFågel gulFågel;
        static Texture2D gulFågelSprite;
        static SvartFågel svartFågel;
        static Texture2D svartFågelSprite;
        static List<ProjektilMarkering> markeringar;
        static Texture2D markeringSprite;
        static Background bakgrund;
        static Bar bar;
        static BarBallForce ballForce;
        static BarBallAngle ballAngle;
        static Slangbella slangbella;
        static List<Slangbella> slangbellor;
        static Slangbella slangbella0;
        static Slangbella slangbella25;
        static Slangbella slangbella50;
        static Slangbella slangbella75;
        static Slangbella slangbella100;
        //static Texture2D slangbella0;
        //static Texture2D slangbella25;
        //static Texture2D slangbella50;
        //static Texture2D slangbella75;
        //static Texture2D slangbella100;
        static Random random;
        static float force;
        static float angle;
        static bool hasShot = false;
        static int ballSpeed = 1;


        //olika gamestates
        public enum State { Menu, Run, HighScore, Quit }; //de olika statesen i spelet
        public static State currentState; //det nuvarande staten

        //initialize
        public static void Initialize()
        {
            fåglar = new List<Fågel>();
            slangbellor = new List<Slangbella>();
            random = new Random();
        }

        //menu
        static Menu menu;

        //load
        public static void LoadContent(ContentManager content, GameWindow window)
        {
            //fåglar
            rödFågelSprite = content.Load<Texture2D>("images/fåglar/röd_fågel");
            blåFågelSprite = content.Load<Texture2D>("images/fåglar/blå_fågel");
            gulFågelSprite = content.Load<Texture2D>("images/fåglar/gul_fågel");
            svartFågelSprite = content.Load<Texture2D>("images/fåglar/svart_fågel");

            //markeringar
            markeringar = new List<ProjektilMarkering>();
            markeringSprite = content.Load<Texture2D>("images/vfx/markering");
            
            //bakgrund
            bakgrund = new Background(content.Load<Texture2D>("images/background/background"), 0, 0);

            //bar
            bar = new Bar(content.Load<Texture2D>("images/bar/bar"), 0, 880); //nere i vänstra hörnet
            int x1 = random.Next(6, 157);
            int x2 = random.Next(6, 157);
            ballForce = new BarBallForce(content.Load<Texture2D>("images/bar/bar_ball"), x1, 1036, ballSpeed, 0);
            ballAngle = new BarBallAngle(content.Load<Texture2D>("images/bar/bar_ball"), x2, 936, ballSpeed, 0);

            //slangbella
            slangbella0 = new Slangbella(content.Load<Texture2D>("images/slangbella/slangbella_0%"), 38, 605);
            slangbella25 = new Slangbella(content.Load<Texture2D>("images/slangbella/slangbella_25%"), 38, 605);
            slangbella50 = new Slangbella(content.Load<Texture2D>("images/slangbella/slangbella_50%"), 38, 605);
            slangbella75 = new Slangbella(content.Load<Texture2D>("images/slangbella/slangbella_75%"), 38, 605);
            slangbella100 = new Slangbella(content.Load<Texture2D>("images/slangbella/slangbella_100%"), 38, 605);

            slangbellor.Add(slangbella0);

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
            bakgrund.Update(window, gameTime); //bakgrund
            bar.Update(window, gameTime); //bar
            ballForce.UpdateBar(window, gameTime);
            ballAngle.UpdateBar(window, gameTime);
            

            if (hasShot == false && ballForce.Ready == true && ballAngle.Ready == true)
            {
                hasShot = true;
                ballForce.Ready = false;
                ballAngle.Ready = false;
                force = 50f * (156f / ballForce.X);
                angle = (float)((Math.PI / 2) * (ballAngle.X / 156));

                float tmpSpeedX = (float)(force * Math.Cos(angle));
                float tmpSpeedY = (float)(force * Math.Sin(angle));
                int nästaFågel = random.Next(1, 5);

                if (force > 0 && force <= 65)
                {
                    slangbellor.Add(slangbella25);
                }
                else if (force > 65 && force <= 104)
                {
                    slangbellor.Add(slangbella50);
                }
                else if (force > 104 && force <= 156)
                {
                    slangbellor.Add(slangbella75);
                }
                else if (force > 156)
                {
                    slangbellor.Add(slangbella100);
                }

                    switch (nästaFågel)
                    {
                        case 1:
                            rödFågel = new RödFågel(rödFågelSprite, 100, 600, tmpSpeedX, -tmpSpeedY);
                            fåglar.Add(rödFågel);
                            break;
                        case 2:
                            blåFågel = new BlåFågel(blåFågelSprite, 100, 600, tmpSpeedX, -tmpSpeedY);
                            fåglar.Add(blåFågel);
                            break;
                        case 3:
                            gulFågel = new GulFågel(gulFågelSprite, 100, 600, tmpSpeedX, -tmpSpeedY);
                            fåglar.Add(gulFågel);
                            break;
                        case 4:
                            svartFågel = new SvartFågel(svartFågelSprite, 100, 600, tmpSpeedX, -tmpSpeedY);
                            fåglar.Add(svartFågel);
                            break;
                    } 
            }

            
            foreach (Fågel f in fåglar.ToList())
            {
                f.UpdateFågel(window, gameTime);
                if (f.IsAlive == false)
                {
                    hasShot = false;
                    fåglar.Remove(f);
                    markeringar.Clear();
                    ballForce.Ready = false;
                    ballAngle.Ready = false;
                    ballForce.speed.X = ballSpeed;
                    ballAngle.speed.X = ballSpeed;
                    slangbellor.Remove(slangbella25);
                    slangbellor.Remove(slangbella50);
                    slangbellor.Remove(slangbella75);
                    slangbellor.Remove(slangbella100);
                }

                if (hasShot == true && gameTime.TotalGameTime.Milliseconds % 200 == 0)
                {
                    ProjektilMarkering temp = new ProjektilMarkering(markeringSprite, f.X + 12, f.Y + f.Height / 2);
                    markeringar.Add(temp);
                }
            }

            

            foreach (ProjektilMarkering p in markeringar.ToList())
            {
                p.Update(window, gameTime);
            }

            


            return State.Run;
        }

        //run draw
        public static void RunDraw(SpriteBatch spriteBatch)
        {
            bakgrund.Draw(spriteBatch); //bakgrund
            bar.Draw(spriteBatch); //bar
            ballForce.Draw(spriteBatch);
            ballAngle.Draw(spriteBatch);

            foreach (Fågel f in fåglar.ToList())
            {
                f.Draw(spriteBatch);
            }
            
            
            foreach (ProjektilMarkering p in markeringar.ToList())
            {
                p.Draw(spriteBatch);
            }

            foreach (Slangbella s in slangbellor.ToList())
            {
                s.Draw(spriteBatch);
            }
        }


        //highscore update


        //highscore draw



    }
}
