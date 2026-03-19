using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    internal class RödFågel : Fågel
    {
        //konstruktor
        /// <summary>
        /// RödFågel(), konstruktor för att skapa RödFågel objekt
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="speedX"></param>
        /// <param name="speedY"></param>
        /// <param name="vinkel"></param>
        public RödFågel(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY)
        {
            
        }

        //draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }

        //metoder
        

        //update
        public void Update(GameWindow window, GameTime gameTime)
        {
            float tid = (float)gameTime.ElapsedGameTime.TotalSeconds; //tid

            vector.X += BeräknaNästaPosition(1, speed.X, speed.Y, gameTime); //position X
            vector.Y += BeräknaNästaPosition(2, speed.X, speed.Y, gameTime); //position Y

            speed.Y += 4f * tid; //gravitation
        }
    }
}
