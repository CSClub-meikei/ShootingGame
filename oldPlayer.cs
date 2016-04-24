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
    class oldPlayer:GraphicalGameObject
    {
        public oldPlayer(Game1 game) : base(game, game.assets.player)
        {

        }
        public override void update(float delta)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {

                if (-5 < velocityX && velocityX < 5) velocityX += 0.2f;

            }
            else if (state.IsKeyDown(Keys.Left))
            {

                if (-5 < velocityX && velocityX < 5) velocityX -= 0.2f;

            }
            else
            {
                if (velocityX == 0) { velocityX = 0; }
                else if (velocityX < 0) { velocityX += 0.1f; }
                else if (velocityX > 0) { velocityX -= 0.1f; }

            }
            if (state.IsKeyDown(Keys.Down))
            {

                if (-5 < velocityY && velocityY < 5) velocityY += 0.2f;

            }
            else if (state.IsKeyDown(Keys.Up))
            {

                if (-5 < velocityY && velocityY < 5) velocityY -= 0.2f;

            }
            else
            {
                if (velocityY == 0) { velocityY = 0; }
                else if (velocityY < 0) { velocityY += 0.1f; }
                else if (velocityY > 0) { velocityY -= 0.1f; }

            }

            X += (velocityX * delta * 0.1f);
            Y += (velocityY * delta * 0.1f);
            Console.WriteLine((velocityX).ToString());
            base.update(delta);
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {

            base.Draw(batch, screenAlpha);
        }
    }
}
