using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class GameView
    {
        Camera cam;
        Rectangle clickableArea;
        SpriteBatch spriteBatch;
        Rectangle aim;

        public GameView(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            aim = new Rectangle(0, 0, 50, 50);
        }

        internal bool PlayerClicks(Camera cam)
        {
            clickableArea = new Rectangle(0, 0, (int)cam.windowHeight, (int)cam.windowWidth);
            MouseState currentMouseState = Mouse.GetState();
            Point mousePos = new Point(Mouse.GetState().X, Mouse.GetState().Y);

            if (currentMouseState.LeftButton == ButtonState.Pressed 
                && clickableArea.Contains(mousePos))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal Vector2 GetMousePos()
        {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public void UpdateAim(Vector2 mousePos)
        {
            aim.Offset((int)mousePos.X, (int)mousePos.Y);
        }

        public void DrawAim(Texture2D texture, Vector2 mousePos)
        {            
            aim.Offset((int)mousePos.X, (int)mousePos.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, aim, Color.White);
            spriteBatch.End(); 
        }
    }
}
