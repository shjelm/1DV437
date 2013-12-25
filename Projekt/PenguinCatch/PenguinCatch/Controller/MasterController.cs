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
using PenguinCatch.Model;
using PenguinCatch.View;

namespace PenguinCatch
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MasterController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameModel model;
        private GameView view;
        private Camera camera;

        private Texture2D tileTexture;

        private string level;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 700;
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
            model = new GameModel();
            IsMouseVisible = true;

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

            // TODO: use this.Content to load your game content here
            tileTexture = Content.Load<Texture2D>("tile");

            camera = new Camera(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, Level.LEVEL_WIDTH, Level.LEVEL_HEIGHT);
            view = new GameView(model,spriteBatch,tileTexture,camera);
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
            if (view.PlayerWantsToJump())
            {
                model.Jump();
            }
            if (view.PlayerWantsToMoveLeft())
            {
                model.MoveLeft();
            }
            if (view.PlayerWantsToMoveRight())
            {
                model.MoveRight();
            }

            model.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            view.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Draw(gameTime);
        }
    }
}
