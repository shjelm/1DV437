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

        public GameModel()
        {
            level = new Level();
            player = new Player();
        }

        public Level GetLevel()
        {
            return level;
        }

        public void Update(float elapsedTimeSeconds) 
        {
            float timeStep = 0.001f;
            if (elapsedTimeSeconds > 0)
            {
                int numIterations = (int)(timeStep / elapsedTimeSeconds);

                for (int i = 0; i < numIterations; i++)
                {
                    UpdateInternal(timeStep);
                }

                float timeLeft = elapsedTimeSeconds - timeStep * numIterations;
                UpdateInternal(timeLeft);
            }
        }

        private void UpdateInternal(float elapsedTimeSeconds)
        {
            player.Update(elapsedTimeSeconds);

            Collision levelCollision = level.Collide(player.GetPosition(), 0.5f);

            if (levelCollision != null)
            {
                player.Collide();
            }
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

        internal Player GetPlayer()
        {
            return player;
        }

        internal void StopPlayer()
        {
            player.StopPlayer();
        }
    }
}
