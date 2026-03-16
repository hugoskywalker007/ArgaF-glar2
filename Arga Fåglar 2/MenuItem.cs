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
    internal class MenuItem
    {
        //medlemsvariabler
        Texture2D texture; //menun behöver en texture för att den ska synas
        Vector2 position; //menun behöver en position på skärmen
        int currentState; //vilken del som spelet är i, t.ex i menyn eller i själva spelet

        //konstruktor
        /// <summary>
        /// MenuItem(), konstruktor för att skapa MenuItem objekt
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="CurrentState"></param>
        public MenuItem(Texture2D texture, Vector2 position, int CurrentState)
        {
            this.texture = texture;
            this.position = position;
            this.currentState = CurrentState;
        }
        
        //egenskaper
        public Texture2D Texture { get { return texture; } }
        public Vector2 Position { get { return position; } }
        public int CurrentState { get { return currentState; } }
    }
}
