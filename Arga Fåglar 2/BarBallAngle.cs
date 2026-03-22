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
    internal class BarBallAngle : BarBall
    {
        //medlemsvariabler
        

        //konstruktor
        public BarBallAngle(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        //update
        public void UpdateBar(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.E))
            {
                speed.X = 0;
                Ready = true;
            }
            else
            {
                vector.X += speed.X;

                if (vector.X <= 6 || vector.X >= 156)
                {
                    speed.X *= -1; // vänd riktning
                }
            }
        }

        

    }
}
