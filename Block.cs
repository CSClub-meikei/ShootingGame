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
    class Block:GraphicalGameObject
    {
        public Block(Game1 game,Screen screen,Point point) : base(game,screen,game.assets.block)
        {
            setLocation(point.X, point.Y);
            setSize(50, 50);
        }
        public override void update(float delta)
        {
            base.update(delta);
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            base.Draw(batch, screenAlpha);
        }
    }
}
