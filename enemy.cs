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
    class enemy:GraphicalGameObject

    {
        //testc
        World world;
        progressBar bar;
        public bool isExplosion = false;
        public int HP=1;
        public enemy(Game1 game,Screen screen, World world, Point point,int HP) : base(game,screen, game.assets.enemy)
        {
            this.world = world;
            this.HP = HP;
            setLocation(point.X, point.Y);
            setSize(80,80);
            velocityY = 0.3f;
            addAnimator(2);
            bar = new progressBar(game,parent, new Rectangle((int)X, (int)Y, 100, 20), game.assets.black, game.assets.barBack, game.assets.bar);
            bar.MaxValue = HP;
            bar.Value = HP;
            
            bar.animationSpeed = 2f;
            bar.addAnimator(1);
            bar.showSplit = true;
        }
        public override void update(float delta)
        {

            base.update(delta);

            if (!world.animatorOnly)
            {
                X += velocityX * delta;
                Y += velocityY * delta;
                if (Y > 800) world.Renemys.Add(this);
            }
            bar.X = X;
            bar.Y = Y - 50;
            bar.update(delta);

        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            bar.Draw(batch, 1);
            base.Draw(batch, screenAlpha);
        }
        public void hit()
        {
            if (HP != 1) {
                HP--;
                bar.setValue(HP);
                animator[0].setLimit(1f);
                animator[0].start(GameObjectAnimator.FLASH, new float[] { 0.05f, 0.05f, 0.05f, 0.05f, -1 });
            }
            else
            {
                world.screen.score += 10;
                HP = 0;
                bar.setValue(HP);
                bar.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 1, 1 });
                game.assets.bombSound.Play();
                velocityY = 0.1f;
                isExplosion = true;
                animator[1].FinishAnimation += new EventHandler(this.die);
                animator[1].start(GameObjectAnimator.EXPLOSION, new float[] { });
            }
            
        }
        public void die(Object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("die");
          
            world.Renemys.Add(this);
        }
    }
}
