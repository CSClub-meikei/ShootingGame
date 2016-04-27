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

    class pauseScreen:Screen
    {
        GraphicalGameObject pause;
        GraphicalGameObject back;
        GraphicalGameObject bottom;
        Button button1;

        public pauseScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            pause = new GraphicalGameObject(game, this, game.assets.pause);
            pause.setLocation(490, 280);
            pause.setSize(300, 160);
            back = new GraphicalGameObject(game, this, game.assets.black);
            back.setSize(1280, 720);
            back.alpha = 0.5f;
            bottom = new GraphicalGameObject(game, this, game.assets.bottomBack);
            bottom.setLocation(0, 300);
            bottom.setSize(1280, 720);
            bottom.addAnimator(1);
            bottom.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 2, 0, -0, 5, 1, 1, 1F });
            button1 = new Button(game, this, new Point(540, 720));
            button1.setLocation(490, 720);
            button1.setSize(300, 100);
            button1.text.text = "タイトルに戻る";
            button1.setTextLocation(40, 20);
            button1.addAnimator(2);
            button1.animator[1].start(GameObjectAnimator.SLIDE, new float[] { 2,0, 620, 5, 1, 2f, 2F });
            button1.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 0, 0.5f });
            button1.Click += new EventHandler ( (sender, e) => { game.screenManager.setScreen(new TitleScreen(game, Content), ScreenAnimation.fadeInOut, 0.2F, 0); game.FloatScreen.Clear(); });
        }
        public override void update(float deltaTime)
        {
            base.update(deltaTime);
            back.update(deltaTime);
            pause.update(deltaTime);
            bottom.update(deltaTime);
            button1.update(deltaTime);
            base.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
            pause.Draw(batch, screenAlpha);
            bottom.Draw(batch, screenAlpha);
            button1.Draw(batch, screenAlpha);
            base.Draw(batch);
        }
    }
}
