using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleGame.View
{
    class SplitterParticle
    {
        private int seed;
        private Vector2 startPosition;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private float timeLivedSeconds;
        private float maxLifeTime;

        public SplitterParticle(int seed, Vector2 startPosition)
        {
            //@TODO: startposition ska vara viewcoord
            this.seed = seed;
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
            Random rand = new Random(seed);

            Vector2 randomDirection = new Vector2((float)rand.NextDouble() * 2.0f - 1.0f, (float)rand.NextDouble() * 2.0f - 1.0f);
            randomDirection.Normalize();
            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            timeLivedSeconds = 0.0f;
            maxLifeTime = 2;

            float min = 0.01f;
            float max = 1.0f;
            float particleSpeed = min + ((float)(rand.NextDouble()) * max - min);

            velocity *= particleSpeed;
            acceleration = new Vector2(0, 4);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            position = position + velocity * elapsedTimeSeconds;
            velocity = velocity + acceleration * elapsedTimeSeconds;

            timeLivedSeconds += elapsedTimeSeconds;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            //sista två int storlekt på particle
            Vector2 viewPosition = camera.GetVisualPositions(position);
            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, 15, 15);

            float t = timeLivedSeconds/maxLifeTime;
            if (t > 1.0)
            {
                t = 1.0f;
            }
            float endValue = 0.0f;
            float startValue = 1.0f;
            float visibility = endValue * t + (1.0f - t) * startValue;

            Color color = new Color(visibility, visibility, visibility, visibility);

            spriteBatch.Draw(texture, rect, color);
        }
    }
}
