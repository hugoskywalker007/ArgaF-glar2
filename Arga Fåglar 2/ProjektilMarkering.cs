using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    internal class ProjektilMarkering : GameObject
    {
        //konstruktor
        public ProjektilMarkering(Texture2D texture, float X, float Y) : base(texture, X, Y) 
        {
            
        }

        //draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
    }
}
