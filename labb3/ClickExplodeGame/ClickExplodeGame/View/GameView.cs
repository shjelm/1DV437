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
        internal bool PlayerClicks()
        {
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Pressed)
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
    }
}
