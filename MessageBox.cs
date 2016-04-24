using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ActionGame
{
    class MessageBox:Screen
    {
        List<GraphicalGameObject> Controlls;


        public MessageBox(Game1 game, ContentManager Content) : base(game, Content)
        {
            Controlls = new List<GraphicalGameObject>();



        }
    }
}
