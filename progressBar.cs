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
    class progressBar:GraphicalGameObject
    {

        Color[] frameC,backC,barC,bar2C;
        Texture2D frame, back, bar, bar2;
        public float MaxValue=100;
        public float Value=0;
        float newvalue;
        bool isAnimating;
        int Aframe = 0;
        public float edge=2;
        public int mode = 0;
        public float animationSpeed=0.8f;
        public progressBar(Game1 game, Rectangle r,Color frameC, Color backC, Color barC, Color bar2C) : base(game, null)
        {
            mode = 0;
            setLocation(r.X, r.Y);
            setSize(r.Width, r.Height);


            this.frameC = new Color[1*1];
            this.backC = new Color[1 * 1];
            this.barC = new Color[1 * 1];
            this.bar2C = new Color[1 * 1];

            this.frameC[0] = frameC;
            this.backC[0] = backC;
            this.barC[0] = barC;
            this.bar2C[0] = bar2C;

            frame = new Texture2D(game.GraphicsDevice, 1, 1);
            frame.SetData<Color>(this.frameC);
            back = new Texture2D(game.GraphicsDevice, 1, 1);
            back.SetData<Color>(this.backC);
            bar = new Texture2D(game.GraphicsDevice, 1, 1);
            bar.SetData<Color>(this.barC);
            bar2 = new Texture2D(game.GraphicsDevice, 1, 1);
            bar2.SetData<Color>(this.bar2C);

        }
        public progressBar(Game1 game, Rectangle r, Texture2D frame, Texture2D back, Texture2D bar) : base(game, null)
        {
            mode = 1;

            setLocation(r.X, r.Y);
            setSize(r.Width, r.Height);

            this.frame = frame;
            this.back = back;
            this.bar = bar;
        }

        public override void update(float delta)
        {
            base.update(delta);
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            batch.Begin(transformMatrix: game.GetScaleMatrix());
            if (mode == 0)
            {
                batch.Draw(frame, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), Color.White * alpha);
                batch.Draw(back, new Rectangle((int)(X + edge), (int)(Y + edge), (int)(Width - edge * 2), (int)(Height - edge * 2)), Color.White*alpha);
                batch.Draw(bar, new Rectangle((int)(X + edge), (int)(Y + edge), getWidth(), (int)(Height - edge * 2) / 2), Color.White * alpha);
                batch.Draw(bar2, new Rectangle((int)(X + edge), (int)(Y + edge + (Height - edge * 2) / 2), getWidth(), (int)(Height - edge * 2) / 2), Color.White * alpha);
            }
            else if (mode == 1)
            {
                batch.Draw(frame, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), Color.White * alpha);
                batch.Draw(back, new Rectangle((int)(X + edge), (int)(Y + edge), (int)(Width - edge * 2), (int)(Height - edge * 2)), Color.White * alpha);
                batch.Draw(texture :bar, destinationRectangle: new Rectangle((int)(X + edge), (int)(Y + edge), getWidth(), (int)(Height - edge * 2)),sourceRectangle :new Rectangle(0,0,getWidth()*3,200),color:Color.White * alpha);
                
            }
           
            batch.End();
        }
        public override void setSize(double w, double h)
        {
            this.Width = w; this.Height = h;
           
        }
        public int getWidth()
        {
            
            float res = (float)((Value / MaxValue) * Width - edge * 2);
            if (isAnimating)
            {
                
                res -= animationSpeed*Aframe;
                if ((newvalue / MaxValue) * Width - edge * 2 >= res)
                {
                    isAnimating = false;
                    Value = newvalue;
                    res = (float)((Value / MaxValue) * Width - edge * 2);
                    Aframe = 0;
                }
                Aframe++;
            }
            return (int)res;
        }
        public void setValue(int v)
        {
            newvalue = v;
            isAnimating = true;
        }
    }
}
