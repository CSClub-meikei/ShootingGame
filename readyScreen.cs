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
    class readyScreen:Screen
    {
        GraphicalGameObject ready;
        GraphicalGameObject back;
        GraphicalGameObject go;
        TextObject count;
        GameScreen screen;
        float down=9f;
        public readyScreen(Game1 game, ContentManager Content,GameScreen screen) : base(game, Content)
        {
            this.screen = screen;
            ready = new GraphicalGameObject(game, game.assets.ready);
            ready.setLocation(490, 280);
            ready.setSize(300, 160);
            back = new GraphicalGameObject(game, game.assets.black);
            back.setSize(1280, 720);
            back.alpha = 0.5f;
            go = new GraphicalGameObject(game, game.assets.go);
            go.setLocation(490, 280);
            go.setSize(300, 160);
            count = new TextObject(game, game.assets.font, "3", Color.White);
            count.setLocation(490, 280);
            go.addAnimator(6);
        }
        public override void update(float deltaTime)
        {
            down -= deltaTime / 1000;
            back.update(deltaTime);
            ready.update(deltaTime);
            count.text=((int)down-1).ToString();
            go.update(deltaTime);
            base.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            if (down > 6) return;
            back.Draw(batch, screenAlpha);
            if (down > 5)
            {
                ready.Draw(batch, 1);
            }
            else if(down>2)
            {
                count.Draw(batch, 1);
            }
            else
            {
                if (!go.animator[0].isAnimate)
                {
                    go.animator[0].start(GameObjectAnimator.GLOW, new float[] { 1, 1F, 1F, 0F, 0.3F, 1.5F, 0F });
                    go.animator[4].start(GameObjectAnimator.GLOW, new float[] { 1, 1F, 1F, 0F, 0.3F, 1.5F, 0F });
                    go.animator[1].start(GameObjectAnimator.FLASH, new float[] { 0.1F, 0.2F, 1.5F, 0F, 0 });
                    go.animator[5].start(GameObjectAnimator.FLASH, new float[] { 0.1F, 0.2F, 1.5F, 0F, 4 });
                }
                
                go.Draw(batch, 1);
            }
            if (down <= 0.7f)
            {
              
                screen.Status = GameScreen.RUNNING;
            
                game.FloatScreen.Clear();
            }
            
            base.Draw(batch);
        }
    }
}
