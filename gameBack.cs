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
    class gameBack:GraphicalGameObject
    {
        public gameBack(Game1 game, World world, Point point) : base(game, game.assets.gameBack)
        {
            setLocation(point.X, point.Y);
            setSize(1280, 720);

            velocityY = 0.1f;
        }
        public override void update(float delta)
        {
            Y += velocityY * delta;
            if (Y > 720) Y = -720;
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            base.Draw(batch, screenAlpha);
        }
    }
}
