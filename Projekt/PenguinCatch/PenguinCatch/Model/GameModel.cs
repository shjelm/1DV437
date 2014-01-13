using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class GameModel
    {
        private Level level;
        private Player player;

        private CollisionDetails details;

        public static int maxTime;

        public static int levelCount = 0;

        private int timeLeft;
        public bool playWinSound;

        public GameModel()
        {
            level = new Level();
            player = new Player();
        }

        public void Update(float elapsedTimeSeconds)
        {
            if(level.CollidedWithEnemy(player.GetPosition(), level.GetEnemies(), level.GetMonster())){
                player.LostLife();
                MasterController.gameState = MasterController.GameStates.Retry;
            }
            if (player.life <= 0)
            {
                MasterController.gameState = MasterController.GameStates.GameOver;
            }
            float timeStep = 0.001f;
            if (elapsedTimeSeconds > 0)
            {
                int numIterations = (int)(timeStep / elapsedTimeSeconds);

                for (int i = 0; i < numIterations; i++)
                {
                    UpdatePlayer(timeStep);
                }

                float timeLeft = elapsedTimeSeconds - timeStep * numIterations;
                UpdatePlayer(timeLeft);
            }
            if (level.LevelWon(level.caughtFish.Count))
            {
                if (levelCount == 2)
                {
                    playWinSound = true;
                    MasterController.gameState = MasterController.GameStates.Won;
                }
                else
                {
                    MasterController.gameState = MasterController.GameStates.NextLevel;
                }
            }
            if (GetTimeLeft()<= 0)
            {
                MasterController.gameState = MasterController.GameStates.GameOver;
            }
        }

        public void UpdateMonster()
        {
            for (int i = 0; i < level.GetMonster().Count; i++)
            {
                Enemy monster = level.GetMonster()[i];

                if (monster.GetPositon().X <= 17 && monster.GetPositon().Y <= 2)
                {
                    monster.SetPosition(0.1f, 0);
                }
                else if (monster.GetPositon().Y <= 17 && monster.GetPositon().X >= 17)
                {
                    monster.SetPosition(0, 0.1f);
                }
                else if (monster.GetPositon().Y >= 17 && monster.GetPositon().X <= 18 && monster.GetPositon().X >= 2)
                {
                    monster.SetPosition(-0.1f, 0);
                }
                else if (monster.GetPositon().X <= 17 && monster.GetPositon().Y <= 18 && monster.GetPositon().Y >= 2)
                {
                    monster.SetPosition(0, -0.1f);
                }
            }
        }

        private void UpdatePlayer(float elapsedTimeSeconds)
        {
            Vector2 previousPosition = player.GetPosition();

            player.Update(elapsedTimeSeconds);

            Vector2 newPosition = player.GetPosition();

            Vector2 speed = player.GetSpeed();

            if (didCollide(newPosition))
            {
                details = GetCollisionDetails(previousPosition, newPosition, speed);

                player.SetNewPosition(details.positionAfterCollision);
            }
        }

        public bool CollidedWithIce()
        {
            if (details != null){
                details = null;
                return true;
            }
            return false;
        }

        //Kodgrund från Daniel Toll
        //https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/Model/Model.cs

        private bool didCollide(Vector2 position)
        {
            if (level.CollidingAt(position))
            {
                return true;
            }
            return false;
        }

        private CollisionDetails GetCollisionDetails(Vector2 previousPosition, Vector2 newPosition, Vector2 speed)
        {
            CollisionDetails ret = new CollisionDetails(speed, previousPosition);

            Vector2 xPosition = new Vector2(newPosition.X, previousPosition.Y); 
            Vector2 yPosition = new Vector2(previousPosition.X, newPosition.Y); 

            if (didCollide(xPosition) == false)
            {
                return MoveRightOrLeft(speed, ret);
            }
            else if (didCollide(yPosition) == false)
            {
                return MoveUpOrDown(speed, ret, yPosition);
            }
            else
            {
                return Stop(ret, speed);
            }

        }

        private static CollisionDetails Stop(CollisionDetails ret, Vector2 speed)
        {
            ret.speedAfterCollision = new Vector2(0, 0);

            return ret;
        }

        private static CollisionDetails MoveUpOrDown(Vector2 speed, CollisionDetails ret, Vector2 yPosition)
        {
            ret.positionAfterCollision = yPosition;

            return ret;
        }

        private static CollisionDetails MoveRightOrLeft(Vector2 speed, CollisionDetails ret)
        {

            ret.speedAfterCollision = SetSpeedX(speed);

            return ret;
        }

        private static Vector2 SetSpeedX(Vector2 speed)
        {
            speed.X = 0.10f;

            return speed;
        }
        //Slut på kod från Daniel Toll

        public bool CaughtFish()
        {
            List<Fish> fish = GetFish();
            Vector2 position = player.GetPosition();

            if (level.CaughtFish(position, fish))
            {
                return true;
            }
            return false;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Level GetLevel()
        {
            return level;
        }

        internal void Restart() 
        {
            level.GetFish().Clear();
            level.caughtFish.Clear();
            level.GetMonster().Clear();
            level.GetEnemies().Clear();
            MasterController.timer = 0;
            player.SetNewPosition(new Vector2(Level.LEVEL_HEIGHT/2, Level.LEVEL_WIDTH/2));
            level.CreateLevel();
        }

        internal void NextLevel()
        {
            levelCount++;
        }

        internal void ResetGame()
        {
            player.life = 3;
            levelCount = 0;
        }

        internal List<Fish> GetFish()
        {
            return level.GetFish();
        }

        internal List<Enemy> GetEnemies()
        {
            return level.GetEnemies();
        }

        internal List<Enemy> GetMonster()
        {
            return level.GetMonster();
        }

        public Vector2 GetFishPosition()
        {
            return level.fishPos;
        }

        internal void MoveLeft()
        {
            player.SetSpeed(new Vector2(-5.0f, 0));
            player.angle = 0;
        }

        internal void MoveRight()
        {
            player.SetSpeed(new Vector2(5.0f, 0));
            player.angle = 91;
        }

        internal void MoveUp()
        {
            player.SetSpeed(new Vector2(0, -5.0f));
            player.angle = 171;
        }

        internal void MoveDown()
        {
            player.SetSpeed(new Vector2(0, 5.0f));
            player.angle = 80;
        }

        internal int GetTimer(int timeElapsed)
        {
            timeLeft = maxTime - timeElapsed;
            return timeLeft;
        }

        internal int GetTimeLeft()
        {
            return timeLeft;
        }
    }
}
