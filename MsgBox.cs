using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ActionGame
{
    class MsgBox:Screen
    {
        GraphicalGameObject back;
        GraphicalGameObject black;
        TextObject text;
        Button button;
        SpriteFont font;
        public MsgBox(Game1 game, ContentManager Content) : base(game, Content)
        {
            font = this.Content.Load<SpriteFont>("Font");
            black = new GraphicalGameObject(game, this, game.assets.black);
            text = new TextObject(game, this, font, "メッセージ\nこんにちは",Color.White);
            text.setLocation(400, 300);
            black.setSize(1280, 720);
            black.alpha = 0.2F;
            back = new GraphicalGameObject(game, this, game.assets.msgbox);
            button = new Button(game,this, new Point(400, 350));
            button.setSize(150, 50);
            back.setLocation(340, 210);
                back.setSize(600, 300);
            //screenAlpha = 0.4F;
            back.alpha = 0.8f;
            black.alpha = 0.5f;
            button.Click+= new EventHandler(this.buttonClick);
        }
        public override void update(float deltaTime)
        {
            base.update(deltaTime);
            back.update(deltaTime);
            button.update(deltaTime);
            text.update(deltaTime);
            

        }
        public override void Draw(SpriteBatch batch)
        {
            black.Draw(batch, screenAlpha);
            back.Draw(batch, screenAlpha);

            button.Draw(batch, screenAlpha);
            text.Draw(batch, screenAlpha);
          

           
          
        }
        public void buttonClick(Object sender,EventArgs e)
        {
            game.screenManager.setScreen(new TestScreen(game, Content),ScreenAnimation.fadeInOut,1F,0);

            game.FloatScreen.Remove(this);
        }
    }
}
