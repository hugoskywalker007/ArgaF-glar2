using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Arga_Fåglar_2
{
    internal class GameObject
    {
        //medlemsvariabler
        protected Texture2D texture; //objekt behöver ett utseende
        protected Vector2 vector; //objekt behöver en position (X, Y)
        bool isAlive = true; //måste veta om ett objekt lever eller ej (eller ska försvinna)

        //konstruktor
        /// <summary>
        /// GameObject(), konstruktor för att skapa ett objekt i spelet
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public GameObject(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = Y;
        }

        //update
        public void Update(GameWindow window, GameTime gameTime)
        {

        }

        //draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }

        //egenskaper
        public float X { get { return this.vector.X; } }
        public float Y { get { return this.vector.Y; } }
        public float Width { get { return this.texture.Width; } }
        public float Height { get { return this.texture.Height; } }
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public Texture2D Texture { get { return texture; } set { texture = value; } }

        //metoder
        public bool CheckCollision(PhysicalObject other) //kolla kollsion mellan två objekt 
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height)); //skapar en rektangle med platsen och dimensionerna av objektet som matas in
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height)); //skapar en rektangle med platsen och dimensionerna av det andra objektet som matas in
            return myRect.Intersects(otherRect); //kollar om objeketen snuddar eller överlappar varandra och returnerar en boolisk variabel
        }
    }
}
