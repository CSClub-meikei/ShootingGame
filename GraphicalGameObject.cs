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
    class GraphicalGameObject:GameObject

    {
        public Texture2D Texture;
        public List<GameObjectAnimator> animator;
        public int animatorLayor=0;//0で後ろ1で手前
        public float angle=0;
        public Vector2 origin = new Vector2(-100,-100);
        public GraphicalGameObject(Game1 game,Texture2D Texture):base(game)
        {
            this.Texture = Texture;
            origin = new Vector2((float)(this.Width / 2), (float)(this.Height / 2));
            animator = new List<GameObjectAnimator>();
        }

        public override void update(float delta)
        {
            foreach(GameObjectAnimator a in animator)
            {
                a.update(delta);
            }
           
        }

        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            batch.Begin(transformMatrix: game.GetScaleMatrix(), blendState: BlendState.Additive);
            if (animatorLayor == 0)
            {
                foreach (GameObjectAnimator a in animator)
                {
                    a.Draw(batch, screenAlpha);
                }
            }
            batch.End();
            batch.Begin(transformMatrix: game.GetScaleMatrix());

            batch.Draw(Texture,destinationRectangle: new Rectangle((int)X+(int)((Texture.Width/2)*(Width/Texture.Width)), (int)Y+(int)((Texture.Height/2)*(Height / Texture.Height)), (int)Width, (int)Height) , color:  Color.White * alpha*screenAlpha,rotation :angle,origin:origin);
            
            batch.End();
            batch.Begin(transformMatrix: game.GetScaleMatrix(), blendState: BlendState.Additive);
            if (animatorLayor == 1 )
            {
                foreach (GameObjectAnimator a in animator)
                {
                    a.Draw(batch, screenAlpha);
                }
            }
            batch.End();
        }
           public void addAnimator(int num)
        {
            int i = 0;
            for (i = 0; i != num ; i++) { 
            animator.Add(new GameObjectAnimator(this,game));
            }
        }
        public void removeAnimator(int num)
        {
            animator.RemoveAt(num);
        }
        public void removeAnimator(GameObjectAnimator a)
        {
            animator.Remove(a);
        }
        public override void setLocation(double x, double y)
        {
            this.X = x; this.Y = y;

        }
        public override void setSize(double w, double h)
        {
            this.Width = w; this.Height = h;
            origin = new Vector2((float)(Texture.Width / 2), (float)(Texture.Height / 2));
        }
        public void  setAngle(float a)
        {
            angle = a;
            origin = new Vector2((float)(Texture.Width / 2), (float)(Texture.Height / 2));
        }
    }
    }

