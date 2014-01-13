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

        public const int MAX_FISH = 15;
        private const int MAX_MONSTER = 4;

        public Tile[,] tiles = new Tile[LEVEL_WIDTH, LEVEL_HEIGHT];

        private List<Fish> fish = new List<Fish>();
        private List<Enemy> enemiesList = new List<Enemy>();
        private List<Enemy> monsterList = new List<Enemy>();
        public List<Fish> caughtFish = new List<Fish>();

        public Vector2 fishPos;
        public Vector2 enemyPos;
        public Vector2 monsterPos = new Vector2(1,2);
        public Vector2 monsterPos2 = new Vector2(17, 17);

        public int border = 3;

        public bool collidedWithEnemy = false;

        private Player player;

        public Level()
        {
            CreateLevel();
            player = new Player();
        }

        public void CreateLevel()
        {
            String level = string.Empty;
            String line = string.Empty;
            String numberLevel = string.Empty;
            
            //FÖR TEST TA BORT
            //GameModel.levelCount = 2;

            //Läser in level från textfil
            if (GameModel.levelCount == 0)
            {
                GameModel.maxTime = 45;
                numberLevel = "level1.txt";
            }
            else if (GameModel.levelCount == 1)
            {
                GameModel.maxTime = 45;
                numberLevel = "level2.txt";
            }
            else if (GameModel.levelCount == 2)
            {
                GameModel.maxTime = 50;
                numberLevel = "level3.txt";

                for (int i = 0; i < MAX_MONSTER; i++)
                {
                    Vector2 delay = new Vector2(monsterPos.X, i*5 );
                    CreateMonster(monsterPos + delay);
                }
            }
            else
            {
                numberLevel = string.Empty;
            }

            if (numberLevel != string.Empty)
            {
                using (StreamReader sr = new StreamReader(numberLevel))
                {
                    line = sr.ReadLine();
                    level += line;
                }
            }

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

                    if (level[index] == 'E')
                    {
                        CreateEnemy(x,y);
                    }
                }
            }
            if (GetFish().Count == 0 && caughtFish.Count == 0)
            {
                CreateFish();
            }
        }

        public bool IsFilled(int x, int y)
        {
            bool isFilled = tiles[x, y].isFilled();
            return isFilled;
        }

        internal bool CollidingAt(Vector2 position)
        {
            Vector2 tileSize = new Vector2(0.9f, 0.9f);

            MyRectangle posRect = MyRectangle.createFromTopLeft(position,tileSize);
            for (int x = 0; x < LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < LEVEL_HEIGHT; y++)
                {
                    MyRectangle rect = MyRectangle.createFromTopLeft(new Vector2(x,y),tileSize);
                    if (posRect.isIntersecting(rect))
                    {
                        if (tiles[x,y].isFilled())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        internal List<Fish> GetFish()
        {          
            return fish;
        }

        internal List<Enemy> GetEnemies()
        {
            return enemiesList;
        }

        private bool GetEnemy(int x, int y)
        {
            for (int i = 0; i < enemiesList.Count; i++)
            {
                if (enemiesList[i].GetPositon().X == x && enemiesList[i].GetPositon().Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreateFish() {
            Random rand = new Random();

            for (int count = 0; count < MAX_FISH; )
            {
                int x = rand.Next(1, 18);
                int y = rand.Next(1, 18);

                Vector2 vec = new Vector2(x, y);
                
                if (!tiles[x, y].isFilled() && GetEnemy(x,y) == false)
                {
                    count++;
                    fish.Add(new Fish(vec));
                }
            }
        }

        private void CreateEnemy(int x, int y)
        {
            Vector2 vec = new Vector2(x, y);

            if (!tiles[x, y].isFilled())
            {
                enemiesList.Add(new Enemy(vec));
            }
        }

        private void CreateMonster(Vector2 startPos)
        {
            monsterList.Add(new Enemy(startPos));
        }

        public List<Enemy> GetMonster()
        {
            return monsterList;
        }

        internal bool CaughtFish(Vector2 position, List<Fish> fish)
        {
            Vector2 tileSize = new Vector2(1, 1);
            MyRectangle posRect = MyRectangle.createFromTopLeft(position, tileSize);

            for (int i = 0; i < fish.Count; i++)
            {
                fishPos = fish[i].GetPositon();

                MyRectangle fishPosRect = MyRectangle.createFromTopLeft(fishPos, tileSize);

                if (posRect.isIntersecting(fishPosRect))
                {
                    caughtFish.Add(fish[i]);
                    fish.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        internal bool CollidedWithEnemy(Vector2 position, List<Enemy> enemies, List<Enemy> monster)
        {
            Vector2 tileSize = new Vector2(0.8f,0.8f);
            MyRectangle posRect = MyRectangle.createFromTopLeft(position, tileSize);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemyPos = enemies[i].GetPositon();

                MyRectangle enemyPosRect = MyRectangle.createFromTopLeft(enemyPos, tileSize);

                if (posRect.isIntersecting(enemyPosRect))
                {
                    collidedWithEnemy = true;
                    return true;
                }
            }
            for (int i = 0; i < monster.Count; i++)
            {
                enemyPos = monster[i].GetPositon();
                MyRectangle enemyPosRect = MyRectangle.createFromTopLeft(enemyPos, tileSize);

                if (posRect.isIntersecting(enemyPosRect))
                {
                    collidedWithEnemy = true;
                    return true;
                }
            }
            return false;
        }

        internal bool LevelWon(int FishCount)
        {
            if (FishCount == MAX_FISH)
            {
                return true;
            }
            return false;
        }
    }
}
