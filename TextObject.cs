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
    class TextObject:GraphicalGameObject
    {
        protected SpriteFont font;
        public String text;
        public Color color;
        public TextObject(Game1 game, SpriteFont font, String text,Color color):base(game,null)
        {
            this.font = font;
            this.text = text;
            this.color = color;
        }
        public override void update(float delta)
        {

            base.update(delta);
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            batch.Begin(transformMatrix: game.GetScaleMatrix());
            batch.DrawString(font, text, new Vector2((float)X,(float)Y), color*screenAlpha);
            batch.End();
        }
    }
}
