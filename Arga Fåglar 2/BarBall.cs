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
    internal class BarBall : MovingObject
    {
        //medlemsvariabler
        bool ready = false;

        //konstruktor
        public BarBall(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {

        }

        //update


        //egenskaper
        public bool Ready { get { return ready; } set { ready = value; } }
    }
}
