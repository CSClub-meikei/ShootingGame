using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ActionGame
{
    class Slider:GraphicalGameObject
    {

        //public float value;
        public float MaxValue=10;

        float CircleX=0;
        float lastCircleX;
        Rectangle area;
        Point firstMousePosition;
        bool move = false;
        public bool toInt;

        public Slider(Game1 game, Screen screen, Point point) : base(game, screen, game.assets.sliderBack)
        {
            setLocation(point.X, point.Y);
            setSize(300, 15);
            area = new Rectangle((int)(actX + CircleX - 12), (int)(actY - 45), 100, 100);

        }
        public override void update(float delta)
        {
           
            if(game.input.IsHover(area) && game.input.OnMouseDown(Input.LeftButton))
            {
                lastCircleX = CircleX;
                firstMousePosition = game.input.getPosition();
                move = true;
            }
            if (move && game.input.IsMouseDown(Input.LeftButton))
            {
                CircleX = lastCircleX + ( game.input.getPosition().X - firstMousePosition.X );

            }
            if (game.input.OnMouseUp(Input.LeftButton)){
                move = false;
            }

            if (CircleX >= Width) CircleX = (float)Width ;
            if (CircleX <= 0) CircleX = 0;
            area = new Rectangle((int)(actX + CircleX - 63), (int)(actY - 40), 100, 100);

            base.update(delta);

        }
        public override void Draw(SpriteBatch batch, float screenAlpha)
        {
            
            base.Draw(batch, screenAlpha);
            batch.Begin(transformMatrix: game.GetScaleMatrix());
            
            batch.Draw(game.assets.sliderCircle, area,Color.White);

            batch.End();
        }
        public float getValue()
        {
           return (float)((CircleX/Width)*MaxValue);
        }
        public void setValue(float value)
        {
            CircleX   = (float)(value/MaxValue*Width);
        }
    }
}
