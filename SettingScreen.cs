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
    class SettingScreen:Screen
    {
        TextObject title, vl, el;
        Slider bgm, effect;
        GraphicalGameObject back;
        public SettingScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            X = 1280;
            title = new TextObject(game, this, game.assets.font, "Option", Color.White);
            vl = new TextObject(game, this, game.assets.font, "BGM", Color.White);
            el = new TextObject(game, this, game.assets.font, "Effect", Color.White);
            back = new GraphicalGameObject(game, this, game.assets.black);
            back.setSize(1280, 720);
            
            bgm = new Slider(game, this, new Point(200, 200));
            bgm.MaxValue = 1;
            bgm.setValue(MediaPlayer.Volume);
            effect= new Slider(game, this, new Point(200, 400));
            title.setLocation(100, 100);
            vl.setLocation(20, 200);
            el.setLocation(20, 400);

        }
        public override void update(float deltaTime)
        {
            title.update(deltaTime);
            vl.update(deltaTime);
            el.update(deltaTime);
            back.update(deltaTime);
            bgm.update(deltaTime);
            effect.update(deltaTime);

            MediaPlayer.Volume = bgm.getValue();
            base.update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            back.Draw(batch, screenAlpha);
            title.Draw(batch, screenAlpha);
            vl.Draw(batch, screenAlpha);
            el.Draw(batch, screenAlpha);
            
            bgm.Draw(batch, screenAlpha);
            effect.Draw(batch, screenAlpha);




            base.Draw(batch);
        }
    }
}
