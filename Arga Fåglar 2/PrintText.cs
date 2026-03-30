using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arga_Fåglar_2
{
    internal class PrintText
    {
        //medlemsvariabler
        SpriteFont font;

        //konstruktor
        public PrintText(SpriteFont font)
        {
            this.font = font;
        }

        //skriva
        public void Print(string text, SpriteBatch spriteBatch, int X, int Y)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y), Color.Black);
        }
    }
}
