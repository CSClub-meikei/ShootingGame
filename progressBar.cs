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

        Color[] frameC,backC,barC,bar2C,splitC;
        Texture2D frame, back, bar, bar2,split;
        public float MaxValue=100;
        public float Value=0;
        float newvalue;
        bool isAnimating;
        int Aframe = 0;
        public float edge=2;
        public int mode = 0;
        public float animationSpeed=0.8f;
        public bool showSplit;


        public progressBar(Game1 game,Screen screen, Rectangle r,Color frameC, Color backC, Color barC, Color bar2C) : base(game,screen, null)
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
            this.splitC[0] = Color.White;

            frame = new Texture2D(game.GraphicsDevice, 1, 1);
            frame.SetData<Color>(this.frameC);
            back = new Texture2D(game.GraphicsDevice, 1, 1);
            back.SetData<Color>(this.backC);
            bar = new Texture2D(game.GraphicsDevice, 1, 1);
            bar.SetData<Color>(this.barC);
            bar2 = new Texture2D(game.GraphicsDevice, 1, 1);
            bar2.SetData<Color>(this.bar2C);
            split = new Texture2D(game.GraphicsDevice, 1, 1);
            split.SetData<Color>(this.splitC);
        }
        public progressBar(Game1 game,Screen screen, Rectangle r, Texture2D frame, Texture2D back, Texture2D bar) : base(game,screen, null)
        {
            mode = 1;

            setLocation(r.X, r.Y);
            setSize(r.Width, r.Height);

            this.frame = frame;
            this.back = back;
            this.bar = bar;

            this.splitC = new Color[1 * 1];
            this.splitC[0] = Color.White;
            split = new Texture2D(game.GraphicsDevice, 1, 1);
            split.SetData<Color>(this.splitC);
        }

        public override void update(float delta)
        {

            if(getWidth()/Width > 0.6f)
            {
                bar = game.assets.bar;
            }else if (getWidth() / Width < 0.6f && 0.3f < getWidth() / Width)
            {
                bar = game.assets.bar2;
            }
            else if (getWidth() / Width < 0.3f)
            {
                bar = game.assets.bar3;
            }

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

            
            if (showSplit)
            {
                int i = 0;
               
                for (i =1; i <=(int) (getWidth() / ((1 / MaxValue) * Width)) ; i++)
                {
                    batch.Draw(split, new Rectangle((int)(X + i * (Width-edge*2) / MaxValue), (int) (Y + edge), 2, (int)(Height - edge * 2)),Color.White*0.5f);

                }
                
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
                if (Value > newvalue)
                {
                    res -= animationSpeed * Aframe;

                    if ((newvalue / MaxValue) * Width - edge * 2 >= res)
                    {
                        isAnimating = false;
                        Value = newvalue;
                        res = (float)((Value / MaxValue) * Width - edge * 2);
                        Aframe = 0;
                    }
                }
                else
                {
                    res += animationSpeed * Aframe;

                    if ((newvalue / MaxValue) * Width - edge * 2 <= res)
                    {
                        isAnimating = false;
                        Value = newvalue;
                        res = (float)((Value / MaxValue) * Width - edge * 2);
                        Aframe = 0;
                    }
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
