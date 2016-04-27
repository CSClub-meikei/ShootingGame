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
    class shot:GraphicalGameObject
    {
        World world;
        public shot(Game1 game,Screen screen, World world,Point point) : base(game, screen,game.assets.shot)
        {

            this.world = world;
            setLocation(point.X, point.Y);
            setSize(15, 20);
            velocityY = -0.8f;
        }
        public override void update(float delta)
        {
            Y += velocityY * delta;
            if (Y < -100) world.Rshots.Add(this);
            base.update(delta);
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            base.Draw(batch, screenAlpha);
        }


    }
}
