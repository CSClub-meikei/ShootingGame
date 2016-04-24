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
    class splashScreen2:Screen
    {

        GraphicalGameObject sp;
        double time;

        public splashScreen2(Game1 game ,ContentManager Content):base(game,Content)
        {
            sp = new GraphicalGameObject(this.game, game.assets.sp2);
            sp.setSize(1280, 720);
            sp.addAnimator(2);
            sp.animator[0].start(GameObjectAnimator.GLOW, new float[] { 1, 0.5F, 0.5F, 0F, 0.4F, 0.0F, 1F });
            sp.animator[1].start(GameObjectAnimator.FLASH, new float[] { 0.2F, 0.2F, 1F, 0.0F, 0 });
            sp.animatorLayor = 1;
        }

        public override void update(float deltaTime)
        {

            sp.update(deltaTime);

            time += deltaTime/1000;
            if (time > 3F) game.screenManager.setScreen(new TitleScreen(game, Content),ScreenAnimation.fadeInOut,0.3F,0);
            Console.WriteLine(time);        }
        public override void Draw(SpriteBatch batch)
        {
           
            sp.Draw(batch, screenAlpha);
          

        }
    }
}
