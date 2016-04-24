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
    class GameObject
    {
        
        protected ContentManager Content;
        public double X = 0;
        public double Y = 0;
        public double Width = 100;
        public double Height = 100;
        public double velocityX = 0;
        public double velocityY = 0;
        public float alpha = 1.0F;
        protected Game1 game;

        public GameObject(Game1 game) 
        {
            this.game=game;
            this.Content = game.Content;
           
        }
        public virtual void update(float delta)
        {
            
        }
        public virtual void Draw(SpriteBatch batch,float screenAlpha)
        {

        }
        public virtual void setLocation(double x,double y)
        {
            this.X = x;this.Y = y;
            
        }
        public virtual void setSize(double w,double h)
        {
            this.Width = w;this.Height = h;
        }
    }
}
