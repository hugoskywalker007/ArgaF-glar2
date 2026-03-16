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

        ////update
        //public virtual void Update(GameWindow window, GameTime gameTime)
        //{
        //    vector.X += speed.X;
        //    vector.Y += speed.Y;
        //}

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
