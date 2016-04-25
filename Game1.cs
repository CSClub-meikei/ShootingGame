using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace ActionGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       
        FPSCounter counter;
        
        public Screen MainScreen;
        public Screen NextScreen;
        public List<Screen> FloatScreen;
        public  Point screensize = new Point(1280,720);
        public bool isFullScreen;
        public ScreenManager screenManager;
        public Input input;
        public Assets assets;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            //this.IsMouseVisible = true;
            counter = new FPSCounter();
            FloatScreen = new List<Screen>();
            input = new Input(this);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainScreen = new BrankScreen(this, Content);
            assets = new Assets(this);
            assets.Load();

            screenManager = new ScreenManager(this);
            screenManager.setScreen(new splashScreen1(this, Content),ScreenAnimation.fadeInOut,0.5F,0);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           

            // TODO: Add your update logic here
            float delta = counter.getDeltaTime(gameTime);
            this.Window.Title = "FPS : " + counter.fpsCounter(delta).ToString();
           try
           {
                foreach (Screen s in FloatScreen)
                {
                    s.update(delta);
                }
          }
           catch (System.Exception) { }

            if (MainScreen != null ) MainScreen.update(delta);

            
          
            
            if (input.onKeyDown(Keys.Q)) {
                SizeForm f = new SizeForm(this);f.ShowDialog();
                if (isFullScreen)
                {
                    this.Window.IsBorderless = true;
                    this.Window.Position = Point.Zero;
                    screensize = new Point(GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                    graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                    graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
                }
                else {
                    this.Window.IsBorderless = false;
                    graphics.PreferredBackBufferWidth = screensize.X;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = screensize.Y;   // set this value to the desired height of your window
                }
                graphics.ApplyChanges();
              
            }
            if (input.onKeyDown(Keys.T)) { screenManager.setScreen(new TitleScreen(this, Content), ScreenAnimation.fadeInOut, 0.2F, 0); FloatScreen.Clear(); }
            if (input.onKeyDown(Keys.G)) { screenManager.setScreen(new GameScreen(this, Content), ScreenAnimation.fadeInOut, 0.2F, 0); FloatScreen.Clear(); }

            screenManager.update(delta);



            
            input.update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (MainScreen != null) MainScreen.Draw(spriteBatch);
            foreach (Screen s in FloatScreen)
            {
                s.Draw(spriteBatch);
            }

            // if(input.OnMouseDown)
            spriteBatch.Begin(transformMatrix: GetScaleMatrix());
            spriteBatch.Draw(assets.cursor, new Rectangle(input.getPosition().X,input.getPosition().Y, 80, 80), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public Matrix GetScaleMatrix()
        {
            var scaleX = (float)screensize.X / 1280;
            var scaleY = (float)screensize.Y / 720;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }

    }
}
