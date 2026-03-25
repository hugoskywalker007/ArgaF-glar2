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
        static List<Grisar> grisar;
        static Gris gris;
        static Texture2D grisSprite;
        static KungGris kungGris;
        static Texture2D kungGrisSprite;
        static List<Planka> plankor;
        static TräPlanka träPlanka;
        static Texture2D träPlankaLodSprite;
        static Texture2D träPlankaVågSprite;
        static IsPlanka isPlanka;
        static Texture2D isPlankaLodSprite;
        static Texture2D isPlankaVågSprite;
        static MetalPlanka metalPlanka;
        static Texture2D metalPlankaLodSprite;
        static Texture2D metalPlankaVågSprite;
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
            grisar = new List<Grisar>();
            plankor = new List<Planka>();
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

            //grisar
            grisSprite = content.Load<Texture2D>("images/grisar/gris");
            kungGrisSprite = content.Load<Texture2D>("images/grisar/gris_kung");

            //plankor
            träPlankaLodSprite = content.Load<Texture2D>("images/planka/trä_lod");
            träPlankaVågSprite = content.Load<Texture2D>("images/planka/trä_våg");
            isPlankaLodSprite = content.Load<Texture2D>("images/planka/is_lod");
            isPlankaVågSprite = content.Load<Texture2D>("images/planka/is_våg");
            metalPlankaLodSprite = content.Load<Texture2D>("images/planka/metal_lod");
            metalPlankaVågSprite = content.Load<Texture2D>("images/planka/metal_våg");

            //map
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1080, 495));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1144, 495));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1208, 495));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1272, 495));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1336, 495));
            plankor.Add(new TräPlanka(träPlankaLodSprite, 1080, 431));
            plankor.Add(new TräPlanka(träPlankaLodSprite, 1080, 367));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1080, 350));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1144, 350));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1208, 350));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1272, 350));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1336, 350));
            plankor.Add(new TräPlanka(träPlankaLodSprite, 1383, 431));
            plankor.Add(new TräPlanka(träPlankaLodSprite, 1383, 367));
            grisar.Add(new Gris(grisSprite, 1120, 450, 0, 0));
            grisar.Add(new Gris(grisSprite, 1200, 450, 0, 0));
            grisar.Add(new Gris(grisSprite, 1280, 450, 0, 0));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1080, 430));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1144, 430));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1208, 430));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1272, 430));
            plankor.Add(new TräPlanka(träPlankaVågSprite, 1336, 430));
            grisar.Add(new Gris(grisSprite, 1120, 383, 0, 0));
            grisar.Add(new Gris(grisSprite, 1200, 383, 0, 0));
            grisar.Add(new Gris(grisSprite, 1280, 383, 0, 0));
            grisar.Add(new Gris(grisSprite, 1120, 303, 0, 0));
            grisar.Add(new Gris(grisSprite, 1200, 303, 0, 0));
            grisar.Add(new Gris(grisSprite, 1280, 303, 0, 0));

            plankor.Add(new IsPlanka(isPlankaVågSprite, 812, 800));
            plankor.Add(new IsPlanka(isPlankaVågSprite, 876, 800));
            plankor.Add(new IsPlanka(isPlankaVågSprite, 940, 800));
            plankor.Add(new IsPlanka(isPlankaLodSprite, 812, 736));
            plankor.Add(new IsPlanka(isPlankaLodSprite, 812, 672));
            plankor.Add(new IsPlanka(isPlankaLodSprite, 987, 736));
            plankor.Add(new IsPlanka(isPlankaLodSprite, 987, 672));

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

                    int nästaFågel = random.Next(1, 5);
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

            foreach (Fågel f in fåglar.ToList())
            {
                foreach (Gris g in grisar.ToList())
                {
                    if (g.CheckCollision(f))
                    {
                        g.IsAlive = false;
                        grisar.Remove(g);
                    }
                }
                foreach (Planka p in plankor.ToList())
                {
                    if (p.CheckCollision(f))
                    {
                        p.IsAlive = false;
                        plankor.Remove(p);
                    }
                }
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

            foreach (Grisar g in  grisar.ToList())
            {
                g.Draw(spriteBatch);
            }

            foreach (Slangbella s in slangbellor.ToList())
            {
                s.Draw(spriteBatch);
            }

            foreach (Planka p in plankor.ToList())
            {
                p.Draw(spriteBatch);
            }
        }


        //highscore update


        //highscore draw



    }
}
