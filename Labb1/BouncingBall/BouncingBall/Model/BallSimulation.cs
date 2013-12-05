using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BouncingBall
{
    class BallSimulation
    {
        public Ball ball;

        public BallSimulation()
        {
            ball = new Ball();
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            ball.logicalPosition.X += elapsedTime * ball.speed.X;
            ball.logicalPosition.Y += elapsedTime * ball.speed.Y;

            if (ball.GetCenterPosition().X - ball.radius*0.5 > 1.0f)
            {
                ball.speed.X = -ball.speed.X;
            }
            if (ball.GetCenterPosition().Y - ball.radius * 0.5 > 1.0f)
            {
                ball.speed.Y = -ball.speed.Y;
            }

            if (ball.logicalPosition.X - ball.radius * 2 <= 0)
            {
                ball.speed.X = -ball.speed.X;
            }
            if (ball.logicalPosition.Y - ball.radius * 2 <= 0)    
            {
                ball.speed.Y = -ball.speed.Y;
            }

        }
    }
}
