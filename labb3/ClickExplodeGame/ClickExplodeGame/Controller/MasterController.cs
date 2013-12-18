using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ClickExplodeGame.View;

namespace ClickExplodeGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MasterController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera cam;
        SoundEffect soundEffect;
        private Texture2D sparkTexture;
        private Texture2D smokeTexture;
        private Texture2D borderTexture;
        private Texture2D ballTexture;
        private Texture2D aimTexture;
        
        private Vector2 mousePos;

        private List<ExplosionView> exViews = new List<ExplosionView>();
        
        GameView view;
        BallView ballView;
       
        SoundView soundView;
        BallSimulation ballSim;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
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
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sparkTexture = Content.Load<Texture2D>("spark");
            smokeTexture = Content.Load<Texture2D>("particlesmoke");
            soundEffect = Content.Load<SoundEffect>("fire");
            ballTexture = Content.Load<Texture2D>("ball");
            borderTexture = Content.Load<Texture2D>("border");
            aimTexture = Content.Load<Texture2D>("sikte");

            this.ballSim = new BallSimulation();

            view = new GameView(spriteBatch);
            cam = new View.Camera(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);
            soundView = new SoundView(soundEffect);
            ballView = new BallView(spriteBatch, ballTexture,cam);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                this.Exit();

            // TODO: Add your update logic here
            if (view.PlayerClicks(cam))
            {
                mousePos = view.GetMousePos();
                exViews.Add(new View.ExplosionView(spriteBatch,sparkTexture, smokeTexture, cam, cam.GetModelPositions(mousePos)));
                soundView.Play();
            }

            view.UpdateAim(mousePos);
            ballSim.Update(gameTime, cam.GetModelPositions(mousePos), view.PlayerClicks(cam));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(38, 40, 42));

            // TODO: Add your drawing code here
            //ballView.DrawBorder(borderTexture);
            if (exViews != null)
            {
                for (int i = 0; i < exViews.Count; i++)
                {
                    exViews[i].Draw((float)gameTime.ElapsedGameTime.TotalSeconds, exViews);
                }
            }

            view.DrawAim(aimTexture, mousePos);
            ballView.DrawBall(ballSim.balls);
            base.Draw(gameTime);
        }
    }
}
