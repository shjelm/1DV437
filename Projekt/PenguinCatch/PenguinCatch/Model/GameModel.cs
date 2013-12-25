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

        private bool collidedWithGround = false;

        public GameModel()
        {
            level = new Level();
            player = new Player();
        }

        public void Update(float elapsedTimeSeconds) 
        {
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
        }

        private void UpdatePlayer(float elapsedTimeSeconds)
        {
            Vector2 previousPosition = player.GetPosition();

            player.Update(elapsedTimeSeconds);

            Vector2 newPosition = player.GetPosition();

            Vector2 speed = player.GetSpeed();

            if (didCollide(newPosition))
            {
                CollisionDetails details = getCollisionDetails(previousPosition, newPosition, speed);
                collidedWithGround = details.collidedWithGround;

                player.SetNewPosition(details.positionAfterCollision);
                player.SetSpeed(details.speedAfterCollision);
            }
        }

        private bool didCollide(Vector2 position)
        {
            if (level.CollidingAt(position))
            {
                return true;
            }
            return false;
        }

        private CollisionDetails getCollisionDetails(Vector2 previousPosition, Vector2 newPosition, Vector2 speed)
        {
            CollisionDetails ret = new CollisionDetails(previousPosition, speed);

            Vector2 slidingXPosition = new Vector2(newPosition.X, previousPosition.Y); //Y movement ignored
            Vector2 slidingYPosition = new Vector2(previousPosition.X, newPosition.Y); //X movement ignored

            if (didCollide(slidingXPosition) == false)
            {
                return doOnlyXMovement(ref speed, ret, ref slidingXPosition);
            }
            else if (didCollide(slidingYPosition) == false)
            {

                return doOnlyYMovement(ref speed, ret, ref slidingYPosition);
            }
            else
            {
                return doStandStill(ret, speed);
            }

        }

        private static CollisionDetails doStandStill(CollisionDetails ret, Vector2 speed)
        {
            if (speed.Y > 0)
            {
                ret.collidedWithGround = true;
            }
            ret.speedAfterCollision = new Vector2(0, 0);
            return ret;
        }

        private static CollisionDetails doOnlyYMovement(ref Vector2 speed, CollisionDetails ret, ref Vector2 slidingYPosition)
        {
            speed.X *= -0.5f; //bounce from wall
            ret.speedAfterCollision = speed;
            ret.positionAfterCollision = slidingYPosition;
            return ret;
        }

        private static CollisionDetails doOnlyXMovement(ref Vector2 speed, CollisionDetails ret, ref Vector2 slidingXPosition)
        {
            ret.positionAfterCollision = slidingXPosition;
            //did we slide on ground?
            if (speed.Y > 0)
            {
                ret.collidedWithGround = true;
            }

            ret.speedAfterCollision = doSetSpeedOnVerticalCollision(speed);
            return ret;
        }

        private static Vector2 doSetSpeedOnVerticalCollision(Vector2 speed)
        {
            //did we collide with ground?
            if (speed.Y > 0)
            {
                speed.Y = 0; //no bounce
            }
            else
            {
                //collide with roof
                speed.Y *= -1.0f;
            }

            speed.X *= 0.10f;

            return speed;
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Level GetLevel()
        {
            return level;
        }

        internal void Jump()
        {
            player.Jump();
        }

        internal void MoveLeft()
        {
            player.SetSpeed(new Vector2(-5.0f, player.GetSpeed().Y));
        }

        internal void MoveRight()
        {
            player.SetSpeed(new Vector2(5.0f, player.GetSpeed().Y));
        }
    }
}
