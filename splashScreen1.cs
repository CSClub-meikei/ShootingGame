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
    class splashScreen1:Screen
    {

        GraphicalGameObject sp;
        double time;

        public splashScreen1(Game1 game ,ContentManager Content):base(game,Content)
        {
            sp = new GraphicalGameObject(this.game, this, game.assets.sp1);
            sp.setSize(1280, 720);
            
        }

        public override void update(float deltaTime)
        {

            sp.update(deltaTime);

            time += deltaTime/1000;
            if (time > 3F) game.screenManager.setScreen(new splashScreen2(game, Content),ScreenAnimation.fadeInOut,0.3F,0);
           // Console.WriteLine(time);
        }
        public override void Draw(SpriteBatch batch)
        {

            sp.Draw(batch, screenAlpha);


        }
    }
}
