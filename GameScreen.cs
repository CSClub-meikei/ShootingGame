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
    class GameScreen:Screen
    {

        World world;
        public progressBar HP;
        public TextObject scoreLabel;
        public int Status=PAUSE;
        public const int READY = 0;
        public const int RUNNING = 1;
        public const int PAUSE = 2;

        Screen black;
        pauseScreen ps;
        public int score = 0;

        public GameScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            world = new World(game,this);
            HP = new progressBar(game, this, new Rectangle(0, 0, 500,50),game.assets.black,game.assets.barBack,game.assets.bar);
            HP.MaxValue = 10;
            HP.Value = 10;
            HP.animationSpeed = 0.5f;
            HP.showSplit = true;
            scoreLabel = new TextObject(game, this, game.assets.font, "score : 0",Color.White);
            scoreLabel.setLocation(1000, 0);
            game.FloatScreen.Add(new readyScreen(game,Content,this));
            black = new blackScreen(game, Content);
            black.Y = 720;
        }
        public override void update(float deltaTime)
        {
            base.update(deltaTime);
            if (game.input.onKeyDown(Keys.Escape))
            {
                if (Status == RUNNING) {
                    Status = PAUSE;
                  ps = new pauseScreen(game, Content);
                    ps.screenAlpha =0;
                    ps.animator.start(ScreenAnimator.fadeInOut, new float[] { 0, 0.2f });
                    game.FloatScreen.Add(ps);
                    animator.start(ScreenAnimator.SLIDE, new float[] { 2, 340, -100, 5, 1, 1,1F });
                    //black.animator.start(ScreenAnimator.SLIDE, new float[] { 2, 340, 620, 5, 1, 1, 1F });
                    world.animatorOnly = true; }
                else if  (Status == PAUSE) {
                    ps.animator.start(ScreenAnimator.fadeInOut, new float[] { 1, 0.2f });
                    EventHandler h;
                    h = (sender, e) =>
                    {
                        game.FloatScreen.Clear();
                    };
                    ps.animator.FinishAnimation += h;
                    Status = RUNNING; 
                    animator.start(ScreenAnimator.SLIDE, new float[] { 2, 340, 0, 5, 1, 1, 1F });
                   // black.animator.start(ScreenAnimator.SLIDE, new float[] { 2, 340, 720, 5, 1, 1, 1F });
                    world.animatorOnly = false;
                }
            }
            if (game.input.onKeyDown(Keys.U)) HP.setValue(10);
                


            
                updateObject(deltaTime);
                updateUI(deltaTime);
            
        }
        public override void Draw(SpriteBatch batch)
        {
           
            DrawObject(batch);
            DrawUI(batch);
            
        }
        public void  updateUI(float deltaTime)
        {
            HP.update(deltaTime);
            scoreLabel.update(deltaTime);
            scoreLabel.text = "score : " + score;
            black.update(deltaTime);
        }
        public void updateObject(float deltaTime)
        {
            world.update(deltaTime);
        }
        public void DrawUI(SpriteBatch batch)
        {
            HP.Draw(batch, 1);
            scoreLabel.Draw(batch, 1);
            black.Draw(batch);
        }
        public void DrawObject(SpriteBatch batch)
        {
            world.draw(batch);
        }
    }
}
