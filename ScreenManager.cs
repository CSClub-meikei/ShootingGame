using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionGame
{
    public class ScreenManager
    {
        Game1 game;

        bool isScreenChanging = false;
        int animationType;
        int step = 0;
        float duration;
        float delay = 0;
        double time;
        public ScreenManager(Game1 game)
        {
            this.game = game;
        }

        public void setScreen(Screen screen, int animation, float duration,float delay)
        {

            isScreenChanging = true;
            screen.screenAlpha = 0F;
            game.NextScreen = screen;
            animationType = animation;
            this.duration = duration;
            this.delay = delay;
        }

        public void setScreenUpdate(double deltaTime)
        {
           
        }
        public void update(double deltaTime)
        {
            if (!isScreenChanging) return;
            if (delay != 0)
            {
                time += deltaTime/1000;
                if (time < delay) return;
            }
            if (animationType == 1)
            {
                Console.WriteLine((float)deltaTime / 1000);
                switch (step)
                {
                    case 0:
                        if (game.MainScreen.screenAlpha < 0) step = 1;
                        game.MainScreen.screenAlpha -= ((float)deltaTime/1000)* (1 / duration);
                        break;
                    case 1:
                        game.MainScreen = game.NextScreen;
                        game.NextScreen = null;
                        step = 2;
                        break;
                    case 2:
                        if (game.MainScreen.screenAlpha >= 1) step = 3;
                        game.MainScreen.screenAlpha += ((float)deltaTime/1000) * (1 / duration);
                        break;
                    case 3:
                        isScreenChanging = false;
                        step = 0;
                        time = 0;
                        break;
                }







            }
        }
    }
}
