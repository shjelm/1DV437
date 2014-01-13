using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PenguinCatch.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PenguinCatch.View
{
    class GameView
    {
        private GameModel model;
        private SpriteBatch spriteBatch;
        private Texture2D tileTexture;
        private Texture2D fishTexture;
        private Texture2D fishBoneTexture;
        private Texture2D penguinTexture;
        private Texture2D canTexture;
        private Texture2D sparkTexture;
        private Texture2D monsterTexture;
        private Camera camera;
        private ExplosionView exView;   

        public GameView(GameModel model, SpriteBatch spriteBatch, Texture2D tileTexture, Texture2D fishTexture, 
                        Texture2D sparkTexture, Texture2D fishBoneTexture, Texture2D penguinTexture, 
                        Texture2D canTexture, Texture2D monsterTexture, Camera camera)
        {
            this.model = model;
            this.spriteBatch = spriteBatch;
            this.tileTexture = tileTexture;
            this.fishTexture = fishTexture;
            this.sparkTexture = sparkTexture;
            this.canTexture = canTexture;
            this.fishBoneTexture = fishBoneTexture;
            this.penguinTexture = penguinTexture;
            this.monsterTexture = monsterTexture;
            this.camera = camera;
        }

        public void DrawGame(List<Fish> fish, List<Enemy> enemies, List<Enemy> monster, int timeLeft, int life)
        {
            spriteBatch.Begin();
            for (int x = 0; x < Level.LEVEL_WIDTH; x++)
            {
                for(int y = 0; y < Level.LEVEL_HEIGHT; y++)
                {
                    Vector2 vec = new Vector2(x, y);
                    Rectangle rect = camera.getRectangle(vec, 0.5f);

                    if(model.GetLevel().IsFilled(x,y))
                    {
                        spriteBatch.Draw(tileTexture, rect, Color.White);
                    }
                }
            }

            DrawElements(enemies, null, canTexture);
            DrawElements(null, fish, fishTexture);
            DrawElements(monster, null, monsterTexture);
            DrawText(timeLeft, life, fish);
            DrawPlayer(this.model.GetPlayer().GetPosition(), model.GetPlayer().angle);
            spriteBatch.End();
        }

        private void DrawText(int timeLeft, int life, List<Fish> fish)
        {
            DrawTimer(timeLeft);
            DrawLife(life);
            DrawFishCount(Level.MAX_FISH, Level.MAX_FISH - fish.Count);
            DrawPause();
        }

        private void DrawElements(List<Enemy> listOfEnemyElements, List<Fish> listOfFish, Texture2D texture)
        {
            if (listOfEnemyElements == null)
            {
                for (int i = 0; i < listOfFish.Count(); i++)
                {
                    Vector2 pos = listOfFish[i].GetPositon();

                    Rectangle rect = camera.getRectangle(pos, 0.45f);

                    spriteBatch.Draw(texture, rect, Color.White);
                }
            }
            else
            {
                for (int i = 0; i < listOfEnemyElements.Count(); i++)
                {
                    Vector2 pos = listOfEnemyElements[i].GetPositon();

                    Rectangle rect = camera.getRectangle(pos, 0.45f);

                    spriteBatch.Draw(texture, rect, Color.White);
                }
            }
        }

        public void DrawSpark(int elapsedTimeSeconds)
        {
            Vector2 pos = model.GetPlayer().GetPosition();
            this.exView = new ExplosionView(spriteBatch, sparkTexture, this.camera, pos);
            exView.Draw(elapsedTimeSeconds);
        }

        private void DrawPlayer(Vector2 position, float angle)
        {
            float radius = 0.45f;
            Rectangle rec = camera.getRectangle(position + new Vector2(radius, radius), radius);
            spriteBatch.Draw(penguinTexture, rec, null, Color.White, angle, new Vector2(penguinTexture.Width/2, penguinTexture.Height/2), SpriteEffects.None, 0f); 
        }

        internal bool PlayerWantsToMoveUp()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Up);

        }

        internal bool PlayerWantsToMoveDown()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Down);
        }

        internal bool PlayerWantsToMoveLeft()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Left);
        }

        internal bool PlayerWantsToMoveRight()
        {
            return Keyboard.GetState().IsKeyDown(Keys.Right);
        }

        internal bool PlayerWantsToStartGame(int selected)
        {
            KeyboardState newState = Keyboard.GetState();
            return newState.IsKeyDown(Keys.Enter) && selected == 0;
        }

        internal bool PlayerWantsToPauseGame()
        {
            KeyboardState newState = Keyboard.GetState();
            return newState.IsKeyDown(Keys.P);
        }

        internal bool PlayerWantsToExitGame(int selected)
        {
            KeyboardState newState = Keyboard.GetState();
            return newState.IsKeyDown(Keys.Enter) && selected == 1;
        }

        internal bool PlayerCaugtFish()
        {
            return model.CaughtFish();
        }

        internal void RevomeFish(Vector2 position)
        {
            Color background = new Color(181, 209, 232);
            Rectangle rec = camera.getRectangle(position, 0.45f);

            spriteBatch.Begin();
            spriteBatch.Draw(fishBoneTexture, rec, Color.White);
            spriteBatch.End();
        }

        private void DrawTimer(int timeLeft)
        {
            string text = "Seconds left: ";
            int y = MasterController.graphics.PreferredBackBufferHeight - 50;
            int x = 20;

            spriteBatch.DrawString(Menu.spriteFont, text + timeLeft.ToString(), new Vector2(x+1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text + timeLeft.ToString(), new Vector2(x-1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text + timeLeft.ToString(), new Vector2(x, y+1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text + timeLeft.ToString(), new Vector2(x, y-1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text + timeLeft.ToString(), new Vector2(x,y), Color.White);
        }

        private void DrawFishCount(int maxFish, int fishCaught)
        {
            string text = "Fish : ";
            text += fishCaught.ToString() + "/" + maxFish.ToString();
            int y = MasterController.graphics.PreferredBackBufferHeight - 50;
            int x = 300;

            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x+1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x-1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y+1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y-1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y), Color.White);
        }

        private void DrawPause()
        {
            string text = "Press 'P' to pause";
            int y = MasterController.graphics.PreferredBackBufferHeight - 80;
            int x = MasterController.graphics.PreferredBackBufferWidth / 2 - (int)Menu.spriteFont.MeasureString(text).X / 2;

            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x + 1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x - 1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y + 1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y - 1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y), Color.White);
        }

        private void DrawLife(int life)
        {
            string text = "Life: " + life.ToString() + "/3";
            int y = MasterController.graphics.PreferredBackBufferHeight - 50;
            int x = MasterController.graphics.PreferredBackBufferWidth - 160;

            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x + 1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x - 1, y), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y + 1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y - 1), Color.Black);
            spriteBatch.DrawString(Menu.spriteFont, text, new Vector2(x, y), Color.White);
        }
    }
}
