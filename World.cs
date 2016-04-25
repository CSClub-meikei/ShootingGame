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
    class World
    {
        Game1 game;
        GameScreen screen;
        public player player;
        public List<enemy> enemys;
        public List<enemy> Renemys;
        public List<shot>shots;
        public List<shot> Rshots;
        overlapTester lap;

        public GraphicalGameObject back1, back2; 


        public World(Game1 game,GameScreen screen)
        {
            this.game = game;
            this.screen = screen;
            player = new player(this.game,this, new Point(640,500));
            enemys = new List<enemy>();
            Renemys = new List<enemy>();
            shots = new List<shot>();
            Rshots = new List<shot>();
            lap = new overlapTester();
            player.addAnimator(1);

            back1 = new gameBack(game, this,new Point(0,0));
            back2 = new gameBack(game, this,new Point(0,-720));
        }
        public void update(float deltaTime)
        {
            player.update(deltaTime);
            if (enemys.Count < 5){
                int i = 0;
               
                for (i = 0; i < 5 - enemys.Count; i++)
                {
                    Random rnd = new Random();
                    Random rnd2 = new Random();
                    Random rnd3 = new Random();
                    enemys.Add(new enemy(game, this, new Point(rnd.Next(0, 1200), rnd2.Next(-300,-100)),rnd.Next(1,5)));
                }
            }
          
                foreach (enemy e in enemys) e.update(deltaTime);
                foreach (shot s in shots) s.update(deltaTime);
                foreach(enemy e in enemys)
                {
                    foreach(shot s in shots)
                    {
                        if (!e.isExplosion && lap.overlapRectangles(new Rectangle((int)s.X, (int)s.Y, (int)s.Width, (int)s.Height), new Rectangle((int)e.X, (int)e.Y, (int)e.Width, (int)e.Height)))
                        {
                        e.hit();
                            Rshots.Add(s);
                        }
                    }
                if (e.Y > 500)
                {
                    if (!e.isExplosion && lap.overlapRectangles(new Rectangle((int)player.X, (int)player.Y, (int)player.Width, (int)player.Height), new Rectangle((int)e.X, (int)e.Y, (int)e.Width, (int)e.Height)))
                    {
                        screen.HP.setValue((int)screen.HP.Value-1);
                        player.animator[0].setLimit(1f);
                        player.animator[0].start(GameObjectAnimator.FLASH, new float[] { 0.05f, 0.05f, 0.05f, 0.05f, -1 });
                        Renemys.Add(e);
                    }

                    
                }
                }

            foreach (enemy e in Renemys) enemys.Remove(e);
            foreach (shot s in Rshots) shots.Remove(s);

            back1.update(deltaTime);
            back2.update(deltaTime);

           

        }
        public void draw(SpriteBatch batch)
        {
            back1.Draw(batch, 1);
            back2.Draw(batch, 1);

            player.Draw(batch, 1);
            foreach (enemy e in enemys) e.Draw(batch,1);
            foreach (shot s in shots) s.Draw(batch,1);
            
        }
    }
}
