using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ClickExplodeGame.View;

namespace ClickExplodeGame
{
    class Ball
    {

        private int seed;
        private Vector2 startPosition;
        public Vector2 position;
        private Vector2 velocity;
        public Vector2 logialCenterPosition;
        public float radius = 0.05f;
        public Vector2 speed = new Vector2(0.4f,0.3f);
        public static float ball = 0.05f;

        public Ball(int seed,Vector2 startPosition)
        {
            this.seed = seed;
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);

            Random rand = new Random(seed);
            Vector2 randomDirection = new Vector2((float)rand.Next(-5, 5), (float)rand.Next(-4, 1));
            randomDirection.Normalize();
            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            velocity *= speed;
            
        }

        internal void Update(float elapsedTimeSeconds)
        {
            position = position + velocity * elapsedTimeSeconds;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture, Ball ball)
        {
            Vector2 screenPositions = camera.GetVisualPositions(ball.position);

            int screenX = (int)screenPositions.X;
            int screenY = (int)screenPositions.Y;

            int ballSize = (int)camera.ball;

            Rectangle rectangle = new Rectangle(screenX, screenY, ballSize, ballSize);

            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public Vector2 GetCenterPosition()
        {
            float x = (float)Math.Sqrt(2.0)*radius;

            logialCenterPosition = position + new Vector2(x,x);

            return logialCenterPosition;
        }
    }
}
