using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Level
    {
        public const int LEVEL_HEIGHT = 20;
        public const int LEVEL_WIDTH = 20;

        public Tile[,] tiles = new Tile[LEVEL_WIDTH, LEVEL_HEIGHT];

        private Vector2 tileCollided;

        public Level()
        {
            createLevel();
        }

        public void createLevel()
        {
            String level = string.Empty;
            String line = string.Empty;

            //Läser in level från textfil
            using (StreamReader sr = new StreamReader("../../../level1.txt"))
            {
                line = sr.ReadLine();
                level += line;
            }
            //String level = "XXXXXXXXXXXXXXXXXXXX";
            //level += "XX  XXXX        XX X";
            //level += "XXXXX   XXXXXX  XXXX";
            //level += "X    XX  X   X  XXXX";
            //level += "X     XX XX       XX";
            //level += "XXX XX       XXXXXXX";
            //level += "X    XXXX    XXX   X";
            //level += "XXXXX   XXXXXXXXX  X";
            //level += "X        XX  XXXXXXX";
            //level += "XX  XXXXXXXXXX     X";
            //level += "XXXXX   XXXXXXX  XXX";
            //level += "X  XXXX   XXX      X";
            //level += "X     XXXX  X    X X";
            //level += "XXX XX        XXXXXX";
            //level += "X    X     XXXXXXXXX";
            //level += "XXXXX X   XX  XX  XX";
            //level += "X  XX   XXXX     XXX";
            //level += "X         XX  XX  XX";
            //level += "X  XXXX          XXX";
            //level += "XXXXXXXXXXXXXXXXXXXX";

            for (int x = 0; x < LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < LEVEL_HEIGHT; y++)
                {
                    int index = y * LEVEL_WIDTH + x;

                    if (level[index] == 'X')
                    {
                        tiles[x, y] = Tile.createFilledTile(x,y);
                    }
                    else
                    {
                        tiles[x, y] = Tile.createEmptyTile(x, y);
                    }

                }

            }
        }

        public bool isFilled(int x, int y)
        {
            return tiles[x, y].isFilled();

        }

        internal bool CollidingAt(Vector2 position)
        {
            Vector2 tileSize = new Vector2(1, 1);
            FloatRectangle posRect = FloatRectangle.createFromTopLeft(position,tileSize);
            for (int x = 0; x < LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < LEVEL_HEIGHT; y++)
                {
                    FloatRectangle rect = FloatRectangle.createFromTopLeft(new Vector2(x,y),tileSize);
                    if (posRect.isIntersecting(rect))
                    {
                        if (tiles[x, y].isFilled())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
