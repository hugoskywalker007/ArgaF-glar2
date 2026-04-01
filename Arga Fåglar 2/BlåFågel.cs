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
    internal class BlåFågel : Fågel
    {
        //konstruktor
        public BlåFågel(Texture2D texture, float X, float Y, float speedX, float speedY, int hitPoints) : base(texture, X, Y, speedX, speedY, hitPoints)
        {

        }

        //update
        //public void UpdateFågel(GameWindow window, GameTime gameTime)
        //{
        //    float tid = (float)gameTime.ElapsedGameTime.TotalSeconds; //tid

        //    vector.X += BeräknaNästaPosition(1, speed.X, speed.Y, gameTime); //position X
        //    vector.Y += BeräknaNästaPosition(2, speed.X, speed.Y, gameTime); //position Y

        //    speed.Y += 4f * tid; //gravitation
        //}

        //metoder
        public void ÖkaHastighetY(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                speed.Y += 100f;
            }

        }
    }
}
