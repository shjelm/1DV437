using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ClickExplodeGame.View
{
    class GameView
    {
        internal bool PlayerClicks()
        {
            MouseState mouseState = Mouse.GetState();
            //Console.WriteLine(mouseState.LeftButton == ButtonState.Pressed);
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
