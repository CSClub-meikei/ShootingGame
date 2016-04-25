using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace ActionGame
{
    public class Assets
    {
        Game1 game;

        public Texture2D Blurback;
        public Texture2D MSback;
        public Texture2D ball;
        public Texture2D bar;
        public Texture2D barBack;
        public Texture2D black;
        public Texture2D block;
        public Texture2D buttonC;
        public Texture2D buttonD;
        public Texture2D buttonH;
        public Texture2D clickEffect;
        public Texture2D cursor;
        public Texture2D enemy;
        public Texture2D exAnimaton;
        public Texture2D gameBack;
        public Texture2D GameSelect;
        public Texture2D titlelogo;
        public Texture2D MachineSelect;
        public Texture2D msgbox;
        public Texture2D player;
        public Texture2D pressSpace;
        public Texture2D pause;
        public Texture2D shot;
        public Texture2D sp1;
        public Texture2D sp2;
        public Texture2D topBack;
        public Texture2D universe;
        public Texture2D white;

        public SpriteFont font;

        public Song title;

        public SoundEffect StartSound;
        public SoundEffect ClickSound;
        public SoundEffect HoverSound;
        public SoundEffect shotSound;
        public SoundEffect bombSound;

        public Assets(Game1 game)
        {
            this.game = game;

        }
        public void Load()
        {
            MSback = game.Content.Load<Texture2D>("backMS");
            Blurback = game.Content.Load<Texture2D>("back");
            ball = game.Content.Load<Texture2D>("ball");
            bar = game.Content.Load<Texture2D>("bar");
            barBack = game.Content.Load<Texture2D>("barBack");
            black = game.Content.Load<Texture2D>("black");
            block = game.Content.Load<Texture2D>("block");
            buttonC = game.Content.Load<Texture2D>("button3C");
            buttonD = game.Content.Load<Texture2D>("button3D");
            buttonH = game.Content.Load<Texture2D>("button3H");
            clickEffect = game.Content.Load<Texture2D>("cf");
            cursor = game.Content.Load<Texture2D>("cursor");
            enemy = game.Content.Load<Texture2D>("Enemy");
            exAnimaton = game.Content.Load<Texture2D>("exAnimation");
            titlelogo = game.Content.Load<Texture2D>("logo2");
            gameBack = game.Content.Load <Texture2D> ("gameBack");
            GameSelect = game.Content.Load<Texture2D>("GameSelect");
            MachineSelect = game.Content.Load<Texture2D>("MachineSelect");
            msgbox = game.Content.Load<Texture2D>("msgbox");
            player = game.Content.Load<Texture2D>("player");
            pressSpace = game.Content.Load<Texture2D>("Press space");
            pause = game.Content.Load<Texture2D>("pause");
            shot = game.Content.Load<Texture2D>("shot");
            sp1 = game.Content.Load<Texture2D>("sp1");
            sp2 = game.Content.Load<Texture2D>("sp2");
            topBack = game.Content.Load<Texture2D>("topBack");
            universe = game.Content.Load<Texture2D>("universe");
            white = game.Content.Load<Texture2D>("white");

            font = game.Content.Load<SpriteFont>("Font");

            title = Song.FromUri("ELIMINATE_LOCKED.mp3" ,new Uri("Content/ELIMINATE_LOCKED.mp3", UriKind.Relative));
            
            StartSound = game.Content.Load<SoundEffect>("decision27");
            ClickSound = game.Content.Load<SoundEffect>("decision23");
            HoverSound = game.Content.Load<SoundEffect>("cursor8");
            shotSound = game.Content.Load<SoundEffect>("shot1");
            bombSound= game.Content.Load<SoundEffect>("bomb1");
        }
    }
}
