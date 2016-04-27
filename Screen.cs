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
    public class Screen
    {
        protected ContentManager Content;
        protected Game1 game;
        public float screenAlpha = 1.0F;
        public int X, Y;

        public Screen(Game1 game, ContentManager Content)
        {
            this.Content = Content;
            this.game = game;
        }
        public virtual void update(float deltaTime)
        {

        }
        public virtual void Draw(SpriteBatch batch)
        {

        }
        
    }
}
