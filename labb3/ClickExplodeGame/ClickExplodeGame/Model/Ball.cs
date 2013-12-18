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
        public Vector2 logicalPosition = new Vector2(0.2f, 0.2f);
        public Vector2 logialCenterPosition;
        public float radius = 0.05f;
        public Vector2 randomDirection;
        public Vector2 velocity;
        public static float ball = 0.05f;
        private float minSpeed = 0.1f;
        private float maxSpeed= 0.3f;
        private float speed;

        public Ball(int i)
        {
            Random rand = new Random(i);
            randomDirection = new Vector2((float)rand.Next(), (float)rand.Next());
            randomDirection.Normalize();
            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            speed = speed * minSpeed + ((float)(rand.NextDouble()) * maxSpeed - minSpeed);

        }
        public Vector2 GetCenterPosition()
        {
            float x = (float)Math.Sqrt(2.0) * radius;

            logialCenterPosition = logicalPosition + new Vector2(x, x);

            return logialCenterPosition;
        }
    }
}
