using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ClickExplodeGame
{
    class BallSimulation
    {
        public Ball ball;
        private Vector2 velocity;
        private Vector2 position;

        public BallSimulation(Vector2 startPos)
        {
            for (int i = 0; i <= 10; i++)
            {
                ball = new Ball(i, startPos);
            }
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            float elapsedTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Random rand = new Random(10);
            Vector2 randomDirection = new Vector2((float)rand.Next(-5, 5), (float)rand.Next(-4, 1));
            randomDirection.Normalize();

            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            position = position + velocity * elapsedTimeSeconds;
            

            ball.position.X += elapsedTimeSeconds * ball.speed.X;
            ball.position.Y += elapsedTimeSeconds * ball.speed.Y;

            if (ball.GetCenterPosition().X - ball.radius*0.5 > 1.0f)
            {
                ball.speed.X = -ball.speed.X;
            }
            if (ball.GetCenterPosition().Y - ball.radius * 0.5 > 1.0f)
            {
                ball.speed.Y = -ball.speed.Y;
            }

            if (ball.position.X - ball.radius * 2 <= 0)
            {
                ball.speed.X = -ball.speed.X;
            }
            if (ball.position.Y - ball.radius * 2 <= 0)    
            {
                ball.speed.Y = -ball.speed.Y;
            }

        }
    }
}
