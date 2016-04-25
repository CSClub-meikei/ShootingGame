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
    class TitleScreen:Screen
    {
        GraphicalGameObject titleLogo;
        GraphicalGameObject pressStart;
        GraphicalGameObject back;
        TextObject ver;
        SpriteFont font;
       
        

        public TitleScreen(Game1 game, ContentManager Content) : base(game, Content)
        {
            font = this.Content.Load<SpriteFont>("Font");
            titleLogo = new GraphicalGameObject(this.game, game.assets.titlelogo);
            pressStart = new GraphicalGameObject(this.game, game.assets.pressSpace);
            back = new GraphicalGameObject(this.game, game.assets.universe);
            ver = new TextObject(this.game, font, "build " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString(), Color.White);
            ver.X = 1000;
            ver.Y = 650;
            ver.addAnimator(1);
            ver.animator[0].setDelay(2);
            ver.animator[0].start(GameObjectAnimator.fadeInOut,new float[] { 0, 1 });
            titleLogo.setLocation(340, 300);
            titleLogo.setSize(600, 300);
            
            pressStart.setLocation(440, 600);
            pressStart.setSize(400, 100);
            back.setLocation(0, -100);
            back.setSize(1920, 1080);
            pressStart.addAnimator(6);
            
            pressStart.animator[2].start(GameObjectAnimator.FLASH,new float[] { 1, 0.3F, 0.2F, 0.3F,-1 });

            titleLogo.addAnimator(5);
            
            titleLogo.animator[1].start(GameObjectAnimator.GLOW, new float[] { 1, 0.5F, 0.8F, 0F, 0.4F, 0.0F, 1F });
            titleLogo.animator[2].start(GameObjectAnimator.FLASH, new float[] { 0.2F, 0.2F, 1F, 0.0F,1 });
            titleLogo.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 2, 340, 100, 5, 1,1,0.5F });
            //titleLogo.animator[3].setDelay(0.5f);
            titleLogo.animator[3].start(GameObjectAnimator.fadeInOut, new float[] { 0, 1f });
            back.animatorLayor = 1;
            back.addAnimator(3);
            back.animator[0].start(GameObjectAnimator.SLIDE, new float[] { 2, 0, 0,-1, 1,0.05F });
             back.animator[1].start(GameObjectAnimator.GLOW, new float[] { 1, 0.5F, 0.8F, 0F, 0.4F, 0.0F, 1F });
            back.animator[2].start(GameObjectAnimator.FLASH, new float[] { 0.2F, 0.2F, 1F, 0.0F, 1 });
           
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(game.assets.title);
        }
        public override void update(float deltaTime)
        {
           
            if (game.input.onKeyDown(Keys.Space) && game.FloatScreen.Count ==0)
            {
                game.assets.StartSound.Play(1,1,1);
                game.screenManager.setScreen(new backScreen(game, Content,0), ScreenAnimation.fadeInOut, 0.5f,1);
                pressStart.animator[2].stop();
                pressStart.alpha = 1;
               // game.FloatScreen.Add(new MsgBox(game, Content));
                //game.FloatScreen[0].screenAlpha = 0.1f;
                pressStart.animator[0].start(GameObjectAnimator.GLOW, new float[] { 1, 1F, 1F, 0F, 0.3F, 1.5F, 0F });
                pressStart.animator[4].start(GameObjectAnimator.GLOW, new float[] { 1, 1F, 1F, 0F, 0.3F, 1.5F, 0F });
                pressStart.animator[1].start(GameObjectAnimator.FLASH, new float[] { 0.1F, 0.2F, 1.5F, 0F, 0 });
                pressStart.animator[5].start(GameObjectAnimator.FLASH, new float[] { 0.1F, 0.2F, 1.5F, 0F, 4 });
                titleLogo.animator[4].setDelay(1);
                titleLogo.animator[4].start(GameObjectAnimator.SLIDE, new float[] { 0, 340, -400, 0.5f ,-1});
            }
            
            // System.Windows.Forms.MessageBox.Show("update");
            titleLogo.update(deltaTime);
            titleLogo.setAngle(titleLogo.angle );
            pressStart.update(deltaTime);
            back.update(deltaTime);
            ver.update(deltaTime);
          
        }
        public override void Draw(SpriteBatch batch)
        {
            
            back.Draw(batch, screenAlpha);
           // System.Windows.Forms.MessageBox.Show("draw");
            titleLogo.Draw(batch,screenAlpha);
           
            pressStart.Draw(batch, screenAlpha);
            ver.Draw(batch, screenAlpha);

        }
    }
}
