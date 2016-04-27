using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ActionGame
{
    class SelectModeScreen:Screen
    {

        GraphicalGameObject back;
        GraphicalGameObject gs;
        Button button1;
        Button button2;
        TextObject t1,t2;
        TextObject active;


        public SelectModeScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            back = new GraphicalGameObject(game, this, game.assets.MSback);
            gs = new GraphicalGameObject(game, this, game.assets.GameSelect);
            button1 = new Button(game,this, new Point(1280, 400));
            button2 = new Button(game, this, new Point(1280, 600));
            t1 = new TextObject(game, this, game.assets.font, "１人で遊ぶシングルモードです\n戦闘機を操作して、敵を倒します。", Color.White);
            t2 = new TextObject(game, this, game.assets.font, "２人で遊ぶ対戦モードです\n戦闘機を操作して、対戦相手と対決します。", Color.White);
            t1.setLocation(100, 200);
            t2.setLocation(100, 200);
            back.alpha = 0.1f;
            back.setSize(1280, 720);
            gs.setLocation(400, 50);
            gs.setSize(500, 150);
            button1.setSize(350, 100);
            button2.setSize(350, 100);
            button1.text.text = "シングルプレイ";
            button2.text.text = "マルチプレイ";
            button1.setTextLocation(65, 23);
            button2.setTextLocation(65, 23);
            button1.Hover+= new EventHandler(this.set1);
            button2.Hover += new EventHandler(this.set2);
            button1.Click += new EventHandler(this.Click1);

            back.addAnimator(1);
            back.animator[0].setDelay(2);
            back.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 0, 0.3f });
            gs.addAnimator(2);
            gs.animator[0].setDelay(2);
            gs.animator[1].setDelay(2);
            gs.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 0, 0.3f });
            gs.animator[1].start(GameObjectAnimator.SLIDE, new float[] { 1, 200, 50,-1, -1, 1, 0.5f });
            button1.addAnimator(1);
            button2.addAnimator(1);
            button1.animator[0].setDelay(2);
            button2.animator[0].setDelay(2.1f);
            button1.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 1, 800,400, -1, -1, 1, 0.8f });
            button2.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 1, 600, 600, -1, -1, 1, 0.8f });
        }
        public override void update(float deltaTime)
        {
            back.update(deltaTime);
            gs.update(deltaTime);
            button1.update(deltaTime);
            button2.update(deltaTime);
            if(active!= null) active.update(deltaTime);
            base.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
            gs.Draw(batch, screenAlpha);
            button1.Draw(batch, screenAlpha);
            button2.Draw(batch, screenAlpha);
            if (active != null) active.Draw(batch, screenAlpha);
            base.Draw(batch);
        }
        public void set1(Object sender, EventArgs e)
        {
            active = t1;

        }
        public void set2(Object sender, EventArgs e)
        {
            active = t2;
        }
        public void Click1(Object sender, EventArgs e)
        {
            button2.animator[0].FinishAnimation += new EventHandler(this.Next);
            back.animator[0].setDelay(1);
            back.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 1, 0.3f });
            gs.animator[0].setDelay(1);
            gs.animator[1].setDelay(1);
            gs.animator[0].start(GameObjectAnimator.fadeInOut, new float[] { 1, 0.3f });
            gs.animator[1].start(GameObjectAnimator.SLIDE, new float[] { 1, -300, 50, -1, -1, 1, 0.5f });
            button1.animator[0].setDelay(1);
            button2.animator[0].setDelay(1.1f);
            button1.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 0, -500, 400, 0.2f, -1, 1, 0.8f });
            button2.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 0, -500, 600, 0.2f, -1, 1, 0.8f });
        }
        public void Next(Object sender, EventArgs e)
        {
            game.FloatScreen.Clear();
            game.screenManager.setScreen(new GameScreen(game, Content), ScreenAnimation.fadeInOut, 1, 1);
            
           // game.FloatScreen.Add(new machineSelectScreen(game, Content));
        }
    }
}
