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
    public class GameController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera cam;
        SoundEffect soundEffect;
        private Texture2D sparkTexture;
        private Texture2D smokeTexture;
        GameView view;
        SparkGameView sparkView;
        SmokeGameView smokeView;
        SparkGameView sparkView2;
        SoundView soundView;
        //SwGameView swView;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
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
            //swTexture = Content.Load<Texture2D>("shockwave");

            cam = new View.Camera(400, 400);

            sparkView = new View.SparkGameView(spriteBatch, sparkTexture, cam);
            smokeView = new View.SmokeGameView(spriteBatch, smokeTexture, cam);
            view = new View.GameView();
            soundView = new SoundView(soundEffect);
            //swView = new View.SwGameView(spriteBatch, swTexture, cam);

            // TODO: use this.Content to load your game content here
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
            if (view.PlayerClicks())
            {
                smokeView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
                //sparkView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);

                soundView.Play();
            }

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
            smokeView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            sparkView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            //swView.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Draw(gameTime);
        }
    }
}
