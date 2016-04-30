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
    class player:GraphicalGameObject
    {
        public bool isKeyL,isKeyR,isSpace;
        World world;
        float shotTime=0;

        public player(Game1 game,Screen screen ,World world,Point point) : base(game,screen, game.assets.player)
        {
            setLocation(point.X, point.Y);
            setSize(80, 120);
            setAngle(45);
            this.world = world;
        }
        public override void update(float delta)
        {
            base.update(delta);

            if (world.animatorOnly) return;
            if (game.input.onKeyDown(Keys.Right)) isKeyR = true;
            if (game.input.onKeyUp(Keys.Right)) isKeyR = false;
            if (game.input.onKeyDown(Keys.Left)) isKeyL = true;
            if (game.input.onKeyUp(Keys.Left)) isKeyL = false;

            if (game.input.onKeyDown(Keys.Space)) isSpace=true;
            if (game.input.onKeyUp(Keys.Space)) isSpace = false;

            if (isKeyR)
            {

                if( velocityX<5f)velocityX += 0.5f;

            }
            if (isKeyL)
            {

                if (-5f < velocityX) velocityX -= 0.5f;

            }
            if(!isKeyR && !isKeyL)
            {
                if (velocityX == 0) { velocityX = 0; }
                else if (velocityX < 0) { velocityX += 0.25f; }
                else if (velocityX > 0) { velocityX -= 0.25f; }

            }
           

            

            X +=(velocityX * delta*0.1f);
            Y += (velocityY * delta*0.1f);

            if (X <= 0)
            {
                velocityX = 0;
                X = 0;
            }
            if (X >= 1180)
            {
                velocityX = 0;
                X = 1180;
            }
            shotTime += delta/1000;
            if (shotTime >= 0.1f && isSpace) { world.shots.Add(new shot(game, parent, world, new Point((int)X + 60, (int)Y + 50))); shotTime = 0;game.assets.shotSound.Play(0.5f,0,0); }

            Console.WriteLine((velocityX).ToString());
            
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {

            base.Draw(batch,screenAlpha);
        }
    }
}
