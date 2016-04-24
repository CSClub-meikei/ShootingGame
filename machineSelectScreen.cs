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
    class machineSelectScreen:Screen
    {
        GraphicalGameObject back;
        GraphicalGameObject title;

        public machineSelectScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            back = new GraphicalGameObject(game, game.assets.topBack);
            title = new GraphicalGameObject(game, game.assets.MachineSelect);
            back.setSize(1280, 720);
            title.setLocation(300, 50);
            title.setSize(600, 150);
        }
        public override void update(float deltaTime)
        {
            back.update(deltaTime);
            title.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
            title.Draw(batch, screenAlpha);
        }
    }
}
