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
    class Menu
    {
        KeyboardState keyboard;
        KeyboardState previousKeyboard;
        MasterController masterController = new MasterController();
        Texture2D instructionsTexture;

        List<string> buttonList = new List<string>();

        SpriteFont spriteFont; 

        int selected = 0;

        public Menu()   
        {
            buttonList.Add("Play");
            buttonList.Add("Exit");
        }

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("SpriteFont");
            //instructionsTexture = Content.Load<Texture2D>("Instructions");
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

        public void Draw(SpriteBatch spriteBatch)
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

                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((masterController.graphics.PreferredBackBufferWidth / 2)
                                        - (spriteFont.MeasureString(buttonList[i]).X / 2), (masterController.graphics.PreferredBackBufferHeight/2)
                                        - (spriteFont.LineSpacing * buttonList.Count) / 2 + ((spriteFont.LineSpacing + linePadding) * i)), color);
                spriteBatch.End();
                
            }
        }
    }
}
