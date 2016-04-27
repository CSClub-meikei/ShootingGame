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
        public pauseScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            pause = new GraphicalGameObject(game, this, game.assets.pause);
            pause.setLocation(490, 280);
            pause.setSize(300, 160);
            back = new GraphicalGameObject(game, this, game.assets.black);
            back.setSize(1280, 720);
            back.alpha = 0.5f;
        }
        public override void update(float deltaTime)
        {
            base.update(deltaTime);
            back.update(deltaTime);
            pause.update(deltaTime);
            base.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
            pause.Draw(batch, screenAlpha);
            base.Draw(batch);
        }
    }
}
