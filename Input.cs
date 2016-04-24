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
    public class Input
    {

        KeyboardState KeyOldState;
        MouseState MouseOldState;

        public const int LeftButton = 1;
        public const int RightButton = 2;

        Game1 game;
        public Input(Game1 game)
        {
            this.game = game;
        }
        
        public bool onKeyDown(Keys key)
        {
            KeyboardState newState = Keyboard.GetState();  // get the newest state
            bool res;

            // handle the input
            if (KeyOldState.IsKeyUp(key) && newState.IsKeyDown(key)) res=true;
            else res = false;


            

            return res;

        }
        public bool onKeyUp(Keys key)
        {
            KeyboardState newState = Keyboard.GetState();  // get the newest state
            bool res;

            // handle the input
            if (KeyOldState.IsKeyDown(key) && newState.IsKeyUp(key)) res = true;
            else res = false;


            

            return res;

        }
        public bool onHover(Rectangle rect)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position);
            var old = GlobalToLocal(MouseOldState.Position);
            if (rect.Contains(newm) && !rect.Contains(old)) return true;
            else return false;

            

        }
        public bool onLeave(Rectangle rect)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position);
            var old = GlobalToLocal(MouseOldState.Position);
            if (!rect.Contains(newm) && rect.Contains(old)) return true;
            else return false;



        }
        public bool IsHover(Rectangle rect)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position);
           
            if (rect.Contains(newm)) return true;
            else return false;



        }
        public Point getPosition()
        {
            
            return GlobalToLocal(Mouse.GetState().Position);
        }
        public bool OnMouseDown(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton == ButtonState.Pressed && MouseOldState.LeftButton != ButtonState.Pressed) return true;
                else return false;

            }else if (button == RightButton)
            {
                if (newState.RightButton == ButtonState.Pressed && MouseOldState.RightButton != ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        public bool OnMouseUp(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton != ButtonState.Pressed && MouseOldState.LeftButton == ButtonState.Pressed) return true;
                else return false;

            }
            else if (button == RightButton)
            {
                if (newState.RightButton != ButtonState.Pressed && MouseOldState.RightButton == ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        public bool IsMouseDown(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton == ButtonState.Pressed) return true;
                else return false;

            }
            else if (button == RightButton)
            {
                if (newState.RightButton == ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        private Point GlobalToLocal(Point point)
        {
            var scaleX = 1280/(float)game.screensize.X ;
            var scaleY = 720/(float)game.screensize.Y ;

            return new Point((int)(point.X * scaleX), (int)(point.Y * scaleY));


        }
        public void update()
        {
            KeyboardState KnewState = Keyboard.GetState();  // get the newest state
            KeyOldState = KnewState;  // set the new state as the old state for next time
            MouseState MnewState = Mouse.GetState();
            MouseOldState = MnewState;

        }

    }
}
