using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arga_Fåglar_2
{
    internal class SvartFågel : Fågel
    {
        //konstruktor
        public SvartFågel(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        //update
        public void UpdateFågel(GameWindow window, GameTime gameTime)
        {
            float tid = (float)gameTime.ElapsedGameTime.TotalSeconds; //tid

            vector.X += BeräknaNästaPosition(1, speed.X, speed.Y, gameTime); //position X
            vector.Y += BeräknaNästaPosition(2, speed.X, speed.Y, gameTime); //position Y

            speed.Y += 4f * tid; //gravitation
        }
    }
}
