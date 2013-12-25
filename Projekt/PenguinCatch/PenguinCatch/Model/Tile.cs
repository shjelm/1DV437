using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Tile
    {
        public enum tileState
        {
            EMPTY = 0,
            FILLED
        };

        private tileState state;
        private int tileLeftInX;
        private int tileTopInY;

        public Tile(tileState tileState, int x, int y)
        {
            state = tileState;
            tileLeftInX = x;
            tileTopInY = y;
        }

        public static Tile createEmptyTile(int x, int y)
        {
            return new Tile(tileState.EMPTY, x, y);
        }

        public static Tile createFilledTile(int x, int y)
        {
            return new Tile(tileState.FILLED,x ,y );
        }

        public bool isFilled()
        {
            return state == tileState.FILLED;
        }

        internal bool isCollidingWith(Vector2 position, float radius)
        {
            if (position.X - radius > tileLeftInX + 1.0f)
            {
                return false;
            }
            if (position.X + radius < tileLeftInX)
            {
                return false;
            }

            if (position.Y - radius > tileTopInY + 1.0f)
            {
                return false;
            }
            if (position.Y + radius < tileTopInY)
            {
                return false;
            }

            return true;
        }
    }
}
