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

        internal Collision Collide(Vector2 position, float radius)
        {
            Collision wallsCollision = CollidingWithWall(position, radius);
            if (wallsCollision != null)
            {
                return wallsCollision;
            }

            Collision filledTileCollision = CollidingWithFilledTile(position, radius);
            if (filledTileCollision != null)
            {
                return filledTileCollision;
            }
            return null;
        }

        private Collision CollidingWithWall(Vector2 position, float radius)
        {
            if (position.X + radius*2 > LEVEL_WIDTH -1) {
                return new Collision(position + (new Vector2(radius, 0)));
            }
            else if (position.X - radius < 1)
            {
                return new Collision(position + (new Vector2(-radius, 0)));
            }

            if (position.Y + radius*2 > LEVEL_HEIGHT-1)
            {
                return new Collision(position + (new Vector2(0, -radius)));
            }
            else if (position.Y - radius < 1)
            {
                return new Collision(position + (new Vector2(0, -radius)));
            }
            return null;
        }

        private Collision CollidingWithFilledTile(Vector2 position, float radius)
        {
            for (int x = 0; x < LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < LEVEL_HEIGHT; y++)
                {
                    if (tiles[x, y].isFilled())
                    {
                        if(tiles[x,y].isCollidingWith(position, radius))
                        {
                            return new Collision(position);
                        }
                    }
                }
            }
            return null;
        }

    }
}
