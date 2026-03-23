using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Arga_Fåglar_2
{
    internal abstract class Fågel : PhysicalObject
    {
        //medlemsvariabler

        //konstruktor
        /// <summary>
        /// Fågel(), konstrutor för att skapa ett fågel objekt
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="speedX"></param>
        /// <param name="speedY"></param>
        /// <param name="vinkel"></param>
        public Fågel(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {
        }

        //update
        public void UpdateFågel(GameWindow window, GameTime gameTime)
        {
            if (vector.X > window.ClientBounds.Width - texture.Width || vector.Y > window.ClientBounds.Height)
            {
                IsAlive = false;
            }
            else if (vector.X > 590 - texture.Width && vector.X < 777 - texture.Width && vector.Y > 942 - texture.Height)
            {
                IsAlive = false;
            }
            else if (vector.X > 777 - texture.Width && vector.X < 1090 - texture.Width && vector.Y > 808 - texture.Height)
            {
                IsAlive = false;
            }
            else if (vector.X > 1090 - texture.Width && vector.X < 1392 - texture.Width && vector.Y > 508 - texture.Height)
            {
                IsAlive = false;
            }
            else if (vector.X > 1642 - texture.Width && vector.X < 1920 - texture.Width && vector.Y > 638 - texture.Height)
            {
                IsAlive = false;
            }
            else
            {
                float tid = (float)gameTime.ElapsedGameTime.TotalSeconds; //tid

                vector.X += BeräknaNästaPosition(1, speed.X, speed.Y, gameTime); //position X
                vector.Y += BeräknaNästaPosition(2, speed.X, speed.Y, gameTime); //position Y

                speed.Y += 4f * tid; //gravitation
            }
        }

        //metoder
        public virtual float BeräknaNästaPosition(int val, float speedX, float speedY, GameTime gameTime) //använder fysik formler för att beräkna ut nästa position i X och Y led
        {
            float tid = (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (val) //1 är för position X och 2 för position Y
            {
                case 1:
                    return speedX * tid;
                case 2:
                    return speedY * tid;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
