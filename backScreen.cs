using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ActionGame
{
    class backScreen:Screen

    {
        GraphicalGameObject back;
        public backScreen(Game1 game, ContentManager Content,int action) : base(game, Content)
        {
            back = new GraphicalGameObject(game,this, game.assets.Blurback);
            back.setSize(1280, 720);
            switch (action)
            {
                case 0:
                    game.FloatScreen.Add(new SelectModeScreen(game, Content));

                        break;
            }

        }
        public override void update(float deltaTime)
        {
            
            back.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
        }


    }
}
