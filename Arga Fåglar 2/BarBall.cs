using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arga_Fåglar_2
{
    internal class BarBall : MovingObject
    {
        //konstruktor
        public BarBall(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        //update
        public void UpdateBar(GameWindow window, GameTime gameTime)
        {
            if (vector.X <= 0)
            {
                vector.X += speed.X;
            }
            else if (vector.X >= 194)
            {
                vector.X -= speed.X;
            }
        }
    }
}
