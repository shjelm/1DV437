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
        public enum GameStates { 
            Menu,
            Game,
            Won,
            GameOver,
            NextLevel,
            Pause,
            Retry
        }

        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static GameStates gameState = GameStates.Menu;

        private GameModel model;
        private GameView view;
        private SoundView soundView;
        private Camera camera;
        private Menu menu;

        private Texture2D tileTexture;
        private Texture2D penguinTexture;
        private Texture2D fishTexture;
        private Texture2D canTexture;
        private Texture2D monsterTexture; 
        private Texture2D sparkTexture;
        private Texture2D fishBoneTexture;

        private SpriteFont spriteFont;

        private SoundEffect eatSound;
        private SoundEffect winSound;
        

        public static float timer;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
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

            tileTexture = Content.Load<Texture2D>("tile");
            penguinTexture = Content.Load<Texture2D>("penguin");
            canTexture = Content.Load<Texture2D>("can");
            fishTexture = Content.Load<Texture2D>("fish2");
            sparkTexture = Content.Load<Texture2D>("sparkblue");
            fishBoneTexture = Content.Load<Texture2D>("fishbone");
            monsterTexture = Content.Load<Texture2D>("seal");

            spriteFont = Content.Load<SpriteFont>("SpriteFont");

            eatSound = Content.Load<SoundEffect>("burp");
            winSound = Content.Load<SoundEffect>("applause");

            menu = new Menu(spriteBatch);

            menu.LoadContent(Content);
            camera = new Camera(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, Level.LEVEL_WIDTH, 
                                Level.LEVEL_HEIGHT);
            view = new GameView(model,spriteBatch,tileTexture,fishTexture,sparkTexture, 
                                fishBoneTexture,penguinTexture, canTexture, monsterTexture, camera);
            soundView = new SoundView();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (view.PlayerWantsToExitGame(menu.GetSelected())|| Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (gameState == GameStates.Game)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (view.PlayerWantsToMoveUp())
                {
                    model.MoveUp();
                    model.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (view.PlayerWantsToMoveDown())
                {
                    model.MoveDown();
                    model.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (view.PlayerWantsToMoveLeft())
                {
                    model.MoveLeft();
                    model.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (view.PlayerWantsToMoveRight())
                {
                    model.MoveRight();
                    model.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (view.PlayerWantsToPauseGame())
                {
                    gameState = GameStates.Pause;
                }

                model.UpdateMonster();
            }
            else if (gameState == GameStates.Menu || gameState == GameStates.Pause)
            {
                menu.Update(gameTime);
                if(view.PlayerWantsToStartGame(menu.GetSelected())){
                    gameState = GameStates.Game;
                }
            }
            else if (gameState == GameStates.Won)
            {
                menu.Update(gameTime);
                if (view.PlayerWantsToStartGame(menu.GetSelected()))
                {
                    model.ResetGame();
                    model.Restart();
                    gameState = GameStates.Game;
                }
            }
            else if (gameState == GameStates.NextLevel)
            {
                menu.Update(gameTime);
                if (view.PlayerWantsToStartGame(menu.GetSelected()))
                {
                    model.NextLevel();
                    model.Restart();
                    gameState = GameStates.Game;
                }
            }
            else if (gameState == GameStates.GameOver)
            {
                menu.Update(gameTime);
                if (view.PlayerWantsToStartGame(menu.GetSelected()))
                {
                    model.ResetGame();
                    model.Restart();
                    gameState = GameStates.Game;
                }
            }
            else if (gameState == GameStates.Retry)
            {
                menu.Update(gameTime);
                if (view.PlayerWantsToStartGame(menu.GetSelected()))
                {
                    model.Restart();
                    gameState = GameStates.Game;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (gameState == GameStates.Game)
            {
                Color background = new Color(181, 209, 232);
                GraphicsDevice.Clear(background);

                view.DrawGame(model.GetFish(), model.GetEnemies(), model.GetMonster(), model.GetTimer((int)timer), 
                              model.GetPlayer().GetLife());

                if (view.PlayerCaugtFish())
                {
                    view.RevomeFish(model.GetFishPosition());
                    soundView.PlaySound(eatSound);
                }
                if (model.CollidedWithIce())
                {
                    view.DrawSpark((int)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            else if (gameState == GameStates.Menu)
            {
                menu.Start();
            }
            else if (gameState == GameStates.Won)
            {
                if (model.playWinSound)
                {
                    soundView.PlaySound(winSound);
                    model.playWinSound = false;
                }
                menu.Won();
            }
            else if (gameState == GameStates.NextLevel)
            {
                menu.NextLevel();
            }
            else if (gameState == GameStates.GameOver)
            {
                menu.GameOver();
            }
            else if (gameState == GameStates.Pause)
            {
                menu.PauseMenu();
            }
            else if (gameState == GameStates.Retry)
            {
                menu.Retry();
            }
           
            base.Draw(gameTime);
        }
    }
}
