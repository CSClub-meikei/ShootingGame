using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionGame
{
    class Button:GraphicalGameObject
    {

        public event EventHandler Click;
        public event EventHandler Hover;
        public event EventHandler Leave;
        SpriteFont font;
        public TextObject text;
        Texture2D def;
        Texture2D hov;
       Texture2D onC;

        Point textL;

        public Button(Game1 game,Screen screen, Point point) : base(game,screen, game.assets.buttonD){
            setLocation(point.X, point.Y);
            font = this.Content.Load<SpriteFont>("Font");
            text = new TextObject(game, parent,font, "button", Color.White);

            def = game.assets.buttonD;
            hov = game.assets.buttonH;
            onC = game.assets.buttonC;
            text.setLocation(point.X, point.Y);
            addAnimator(2);
        }
        public override void update(float delta)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            Rectangle area = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);

            if (game.input.onHover(area)) { game.assets.HoverSound.Play(); Texture = hov;if (Hover != null) Hover(this, EventArgs.Empty); }
            if (game.input.onLeave(area)) Texture = def;
            if (game.input.IsHover(area) && game.input.OnMouseDown(Input.LeftButton)) {
                Texture = onC;
            }
            if (game.input.IsHover(area) && game.input.OnMouseUp(Input.LeftButton)) { game.assets.ClickSound.Play();if(Click!=null) Click(this, EventArgs.Empty); }
                base.update(delta);
            text.update(delta);
            text.X =actX+textL.X;
            text.Y = actY+textL.Y;
        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            base.Draw(batch, screenAlpha);
            text.Draw(batch, screenAlpha);
        }
        public void setTextLocation(int tx,int ty)
        {
            textL = new Point(tx, ty);
        }
    }
}
