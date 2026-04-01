using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    internal class MovingObject : GameObject //ärver från MovingObject
    {
        //medlemsvariabler
        public Vector2 speed; //ett rörligt objekt behöver en hastighet i formen av en vektor i dimensionerna X och Y (upp ner och höger vänster)

        //konstruktor
        /// <summary>
        /// MovingObject(), konstruktor för att skapa rörliga objekt i spelet
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="speedX"></param>
        /// <param name="speedY"></param>
        public MovingObject(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y)
        {
            this.speed.X = speedX;
            this.speed.Y = speedY;
        }

        //egenskaper
        public float speedX { get { return speedX; } set { speedX = value; } }
        public float speedY { get { return speedY; } set { speedY = value; } }
    }
}
