using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arga_Fåglar_2
{
    internal class Menu
    {
        //medlemsvariabler
        List<MenuItem> menu; //lista över alla menu saker
        int selected = 0; //default valda menu itemet är 0
        float currentHeight = 0; //det nuvarande höjden av menun
        double lastChange = 0; //den senaste ändringen av listan
        int defaultMenuState; //default menu

        //konstruktor
        /// <summary>
        /// Menu(), konstruktor för att skapa Menu objekt
        /// </summary>
        /// <param name="defaultMenuState"></param>
        public Menu(int defaultMenuState)
        {
            menu = new List<MenuItem>();
            this.defaultMenuState = defaultMenuState;
        }

        //metoder
        public void AddItem(Texture2D itemTexture, int state)
        {
            float X = 0;                                //position för menu item i X-led
            float Y = 0 + currentHeight;                //position för menu item i Y-led

            currentHeight += itemTexture.Height + 20;   //lägger till på den nuvarande höjden så att det blir mellanrum mellan menu items:en

            MenuItem temp = new MenuItem(itemTexture, new Vector2(X, Y), state); //skapar ny menu item med de nya värdena
            menu.Add(temp);                                                      //lägger till den i listan
        }

        //update
        public int Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState(); //tangetbord input

            if (lastChange + 130 < gameTime.TotalGameTime.TotalMilliseconds) //kollar så att man inte byter för snabbt
            {
                if (keyboardState.IsKeyDown(Keys.Down)) //kollar om användaren går ner ett meny val
                {
                    selected++; //ökar räknaren som håller koll på vilken som är vald med 1

                    if (selected > menu.Count - 1) //om man bläddrar längre än vad meny items som finns
                    {
                        selected = 0; //så loopar den tillbaka till första meny itemet
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Up)) //kollar om användaren går upp ett meny val
                {
                    selected--; //minskar räknaren som håller koll på vilken som är vald med 1

                    if (selected < 0) //om bläddrar längre än vad meny items som finns
                    {
                        selected = menu.Count - 1; //sänker mängden med meny val med 1
                    }
                }
                lastChange = gameTime.TotalGameTime.TotalMilliseconds; //ändrar lastChange till att vara den riktiga senaste ändringen
            }

            if (keyboardState.IsKeyDown(Keys.Enter)) //kollar om användaren vill välja ett meny val
            {
                return menu[selected].CurrentState; //returnerar det valda meny valet och det körs
            }

            return defaultMenuState; //om inget ändra till default meny
        }

        //draw
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < menu.Count; i++) //loopar igenom alla meny val
            {
                if (i == selected) //om den hittar det valda meny valet
                {
                    spriteBatch.Draw(menu[i].Texture, menu[i].Position, Color.RosyBrown); //ritar ut det valda meny valet
                }
                else //annars
                {
                    spriteBatch.Draw(menu[i].Texture, menu[i].Position, Color.White); //ritar ut resten
                }
            }
        }
    }
}
