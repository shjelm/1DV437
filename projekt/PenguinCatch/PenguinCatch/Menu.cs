using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace PenguinCatch
{
    //Med hjälp av tutorials 
    //http://www.youtube.com/watch?v=sSbIF3dd0pQ
    //http://www.youtube.com/watch?v=AAPxaqs9CQM

    class Menu
    {
        KeyboardState keyboard;
        KeyboardState previousKeyboard;
        MasterController masterController = new MasterController();
        Texture2D instructionsTexture;

        private SpriteBatch spriteBatch;

        List<string> buttonList = new List<string>();

        public static SpriteFont spriteFont; 

        int selected = 0;

        public Menu(SpriteBatch spriteBatch)   
        {
            buttonList.Add("Play");
            buttonList.Add("Exit");
            this.spriteBatch = spriteBatch;
        }

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("SpriteFont");
            instructionsTexture = Content.Load<Texture2D>("Instructions");
        }

        public void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();

            if (CheckKeyboard(Keys.Up))
            {
                if (selected > 0)
                {
                    selected--;
                }
            }
            if (CheckKeyboard(Keys.Down))
            {
                if (selected < buttonList.Count-1)
                {        
                    selected++;
                }
            }
            previousKeyboard = keyboard;
        }

        public bool CheckKeyboard(Keys key)
        {
            return (keyboard.IsKeyDown(key) && !previousKeyboard.IsKeyDown(key));
        }

        public int GetSelected()
        {
            return selected;
        }

        public void Draw()
        {
            int linePadding = 3;
            Color color;
 
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (i == selected)
                {
                    color = Color.Yellow;
                }
                else
                {
                    color = Color.White;
                }
                string text = "Welcome to Penguin Catch!";
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, text, new Vector2(masterController.graphics.PreferredBackBufferWidth/2 - spriteFont.MeasureString(text).X/2, spriteFont.MeasureString(text).Y*2),Color.White);
                spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((masterController.graphics.PreferredBackBufferWidth / 2)
                                        - (spriteFont.MeasureString(buttonList[i]).X / 2), (masterController.graphics.PreferredBackBufferHeight/2)
                                        - (spriteFont.LineSpacing * buttonList.Count) / 2 + ((spriteFont.LineSpacing + linePadding) * i)), color);
                spriteBatch.End();                
            }
        }

        internal void Won()
        {
            string text = "You won! Press play to play again!";
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text, new Vector2((masterController.graphics.PreferredBackBufferWidth / 2 - spriteFont.MeasureString(text).X/2), masterController.graphics.PreferredBackBufferHeight / 4), Color.White);
            spriteBatch.End();
            Draw();
        }

        internal void Start()
        {
            Draw();
            spriteBatch.Begin();
            spriteBatch.Draw(instructionsTexture, new Vector2(masterController.graphics.PreferredBackBufferWidth/2 - instructionsTexture.Width/2, masterController.graphics.PreferredBackBufferHeight - instructionsTexture.Height), Color.White);
            spriteBatch.End();
        }

        internal void NextLevel()
        {
            string text = "You made it! Press play to start next level!";
            Draw();
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text , new Vector2((masterController.graphics.PreferredBackBufferWidth/2 - spriteFont.MeasureString(text).X/2), masterController.graphics.PreferredBackBufferHeight / 4), Color.White);
            spriteBatch.End();
        }

        internal void PauseMenu()
        {
            string text = "Press play to resume the game!";
            Draw();
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text, new Vector2((masterController.graphics.PreferredBackBufferWidth / 2 - spriteFont.MeasureString(text).X / 2), masterController.graphics.PreferredBackBufferHeight / 4), Color.White);
            spriteBatch.End();
        }

        internal void GameOver()
        {
            string text = "Game Over";
            string restartText = "Press play to try again!";
            Draw();
            spriteBatch.Begin();
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2((masterController.graphics.PreferredBackBufferWidth / 2 - spriteFont.MeasureString(text).X / 2), masterController.graphics.PreferredBackBufferHeight / 6), Color.Red);
            spriteBatch.DrawString(Menu.spriteFont, restartText, new Vector2((masterController.graphics.PreferredBackBufferWidth / 2 - spriteFont.MeasureString(text).X / 2), masterController.graphics.PreferredBackBufferHeight / 4), Color.White);
            spriteBatch.End();
        }
    }
}
