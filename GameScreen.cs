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

        public GameScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            world = new World(game,this);
            HP = new progressBar(game, new Rectangle(0, 0, 300,50),game.assets.black,game.assets.barBack,game.assets.bar);
            HP.MaxValue = 10;
            HP.Value = 10;
        }
        public override void update(float deltaTime)
        {

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
        }
        public void updateObject(float deltaTime)
        {
            world.update(deltaTime);
        }
        public void DrawUI(SpriteBatch batch)
        {
            HP.Draw(batch, 1);
        }
        public void DrawObject(SpriteBatch batch)
        {
            world.draw(batch);
        }
    }
}
