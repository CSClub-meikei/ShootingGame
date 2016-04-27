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
    class blackScreen:Screen
    {
        GraphicalGameObject black;
        public blackScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            black = new GraphicalGameObject(game, this, game.assets.black);
            black.setLocation(0, 0);
            black.setSize(1280, 720);
        }
        public override void update(float deltaTime)
        {
            base.update(deltaTime);
            black.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {

            black.Draw(batch, screenAlpha);

        }
    }
}
