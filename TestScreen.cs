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
        player player;
        SpriteFont font;
        


        public TestScreen(Game1 game,ContentManager Content):base (game,Content)
        {
            font = this.Content.Load<SpriteFont>("font");
          //  player = new player(this.game);
        }
        public override void update(float deltaTime)
        {


            base.update(deltaTime);

            player.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {

            // TODO: Add your drawing code here
            batch.Begin( transformMatrix: game.GetScaleMatrix());
            batch.DrawString(font, "座標 : " + ((int)player.X).ToString() + "," + ((int)player.Y).ToString(), Vector2.Zero, Color.Blue*screenAlpha);
            batch.End();
            player.Draw(batch, screenAlpha);
           
        }
    }
}
