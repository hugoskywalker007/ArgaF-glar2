using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arga_Fåglar_2
{
    internal class PhysicalObject : MovingObject //ärver från MovingObject
    {
        //medlemsvariabler
        

        //konstruktor
        /// <summary>
        /// PhysicalObject(), konstruktor för att ska fysiska objekt i spelet med hitbox 
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="speedX"></param>
        /// <param name="speedY"></param>
        public PhysicalObject(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {
            
        }

        //metoder

        

        //egenskaper
        
    }
}
