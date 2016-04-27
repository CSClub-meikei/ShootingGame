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
        }
        public override void update(float deltaTime)
        {
            
            if (game.input.onKeyDown(Keys.Escape))
            {
                if (Status == RUNNING) { Status = PAUSE; game.FloatScreen.Add(new pauseScreen(game, Content)); }
                else if  (Status == PAUSE) { Status = RUNNING; game.FloatScreen.Clear(); }
            }
            if (game.input.onKeyDown(Keys.U)) HP.setValue(10);
                


                if (Status == RUNNING)
            {
                updateObject(deltaTime);
                updateUI(deltaTime);
            }
        }
        public override void Draw(SpriteBatch batch)
        {
           
            DrawObject(batch);
            DrawUI(batch);
            
        }
        public void  updateUI(float deltaTime)
        {
            HP.update(deltaTime);
            scoreLabel.text = "score : " + score;

        }
        public void updateObject(float deltaTime)
        {
            world.update(deltaTime);
        }
        public void DrawUI(SpriteBatch batch)
        {
            HP.Draw(batch, 1);
            scoreLabel.Draw(batch, 1);
        }
        public void DrawObject(SpriteBatch batch)
        {
            world.draw(batch);
        }
    }
}
