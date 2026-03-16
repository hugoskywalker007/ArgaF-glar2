using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arga_Fåglar_2
{
    internal class PhysicalObject : MovingObject //ärver från MovingObject
    {
        //medlemsvariabler
        bool isAlive = true; //måste veta om ett objekt lever eller ej (eller ska försvinna)

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

        public bool CheckCollision(PhysicalObject other) //kolla kollsion mellan två objekt 
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height)); //skapar en rektangle med platsen och dimensionerna av objektet som matas in
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height)); //skapar en rektangle med platsen och dimensionerna av det andra objektet som matas in
            return myRect.Intersects(otherRect); //kollar om objeketen snuddar eller överlappar varandra och returnerar en boolisk variabel
        }

        //egenskaper
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
    }
}
