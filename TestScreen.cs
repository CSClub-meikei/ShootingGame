using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


namespace ActionGame
{
    class TestScreen :Screen
    {

        Slider slider;
        GraphicalGameObject back;
        TextObject text;


        public TestScreen(Game1 game,ContentManager Content):base (game,Content)
        {
            slider = new Slider(game, this, new Point(100, 400));
            back = new GraphicalGameObject(game, this, game.assets.white);
            back.setSize(1280, 720);
            text = new TextObject(game, this, game.assets.font, "", Color.Black);
        }
        public override void update(float deltaTime)
        {

            slider.update(deltaTime);
            text.update(deltaTime);
            base.update(deltaTime);
            text.text = slider.getValue().ToString();
           
        }
        public override void Draw(SpriteBatch batch)
        {

            back.Draw(batch, screenAlpha);
            slider.Draw(batch, screenAlpha);
            text.Draw(batch, screenAlpha);
        }
    }
}
