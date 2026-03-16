using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    internal class GameObject
    {
        //medlemsvariabler
        protected Texture2D texture; //objekt behöver ett utseende
        protected Vector2 vector; //objekt behöver en position (X, Y)

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
    }
}
