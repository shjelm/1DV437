using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ClickExplodeGame
{
    class BallSimulation
    {
        public Ball[] balls;
        public const int MAX_BALLS = 10;
        public List<Ball> ballList;

        public BallSimulation()
        {
            balls = new Ball[MAX_BALLS];
            for(int i = 0; i < MAX_BALLS; i++){
                balls[i] = new Ball(i);
            }
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gameTime, Vector2 mousePos, bool clicked)
        {
            for (int i = 0; i < MAX_BALLS; i++)
            {
                Point ball = new Point((int)balls[i].logicalPosition.X, (int)balls[i].logicalPosition.Y);
                
                float elapsedTimeSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;                

                balls[i].logicalPosition += balls[i].velocity * elapsedTimeSeconds;

                if (balls[i].GetCenterPosition().X - balls[i].radius * 0.5 > 1.0f)
                {
                    balls[i].velocity.X = -balls[i].velocity.X;
                }
                if (balls[i].GetCenterPosition().Y - balls[i].radius * 0.5 > 1.0f)
                {
                    balls[i].velocity.Y = -balls[i].velocity.Y;
                }

                if (balls[i].logicalPosition.X - balls[i].radius * 2 <= 0)
                {
                    balls[i].velocity.X = -balls[i].velocity.X;
                }
                if (balls[i].logicalPosition.Y - balls[i].radius * 2 <= 0)
                {
                    balls[i].velocity.Y = -balls[i].velocity.Y;
                }

                if (clicked == true)
                {
                    if (Vector2.Distance(mousePos,balls[i].logicalPosition) < 0.15)
                    {
                        balls[i].velocity = new Vector2(0.0f, 0.0f);
                    }
                }
            }

        }
    }
}
