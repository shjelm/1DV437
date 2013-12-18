using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class BallSystem
    {
        private Ball[] balls;
        private const int MAX_BALLS = 10;

        public BallSystem(Vector2 modelStartPosition)
        {
            balls = new Ball[MAX_BALLS];

            for (int i = 0; i < MAX_BALLS; i++)
            {
                balls[i] = new Ball(i,modelStartPosition);
            }
        }

        public void Update(float elapsedTime)
        {
            for (int i = 0; i < MAX_BALLS; i++)
            {
                balls[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture, Ball ball)
        {
            for (int i = 0; i < MAX_BALLS; i++)
            {
               balls[i].Draw(spriteBatch, camera, texture, ball);
            }
        }
    }
}
