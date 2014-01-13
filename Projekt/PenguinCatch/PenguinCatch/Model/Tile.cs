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

        public Tile(tileState tileState)
        {
            state = tileState;
        }

        public static Tile createEmptyTile(int x, int y)
        {
            return new Tile(tileState.EMPTY);
        }

        public static Tile createFilledTile(int x, int y)
        {
            return new Tile(tileState.FILLED);
        }

        public bool isFilled()
        {
            return state == tileState.FILLED;
        }
    }
}
