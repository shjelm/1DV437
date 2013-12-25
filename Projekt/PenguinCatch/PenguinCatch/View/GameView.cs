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
        private Camera camera;

        private KeyboardState previousState;

        public GameView(GameModel model, SpriteBatch spriteBatch, Texture2D tileTexture, Camera camera)
        {
            this.model = model;
            this.spriteBatch = spriteBatch;
            this.tileTexture = tileTexture;
            this.camera = camera;
        }

        public void Draw(float elapsedTimeSeconds)
        {
            spriteBatch.Begin();
            for (int x = 0; x < Level.LEVEL_WIDTH; x++)
            {
                for(int y = 0; y < Level.LEVEL_HEIGHT; y++)
                {
                    Vector2 vec = new Vector2(x, y);
                    Rectangle rect = camera.getRectangle(vec, 0.49f);

                    if(model.GetLevel().isFilled(x,y))
                    {
                        spriteBatch.Draw(tileTexture, rect, Color.White);
                    }
                }            
            }
            DrawPlayer(this.model.GetPlayer().GetPosition());
            spriteBatch.End();
        }

        private void DrawPlayer(Vector2 position)
        {
            Rectangle rec = camera.getRectangle(position, 0.5f);
            spriteBatch.Draw(tileTexture, rec, Color.Tomato);
        }

        internal bool PlayerWantsToJump()
        {
            Keys jump = Keys.Space;

            KeyboardState newState = Keyboard.GetState();
            previousState = newState;

            if (previousState.IsKeyDown(jump))
            {
                return true;
            }
            return false;
        }

        internal bool PlayerWantsToMoveLeft()
        {
            return previousState.IsKeyDown(Keys.Left);
        }

        internal bool PlayerWantsToMoveRight()
        {
            return previousState.IsKeyDown(Keys.Right);
        }
    }
}
