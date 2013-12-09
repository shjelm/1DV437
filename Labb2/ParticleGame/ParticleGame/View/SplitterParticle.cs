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
        private Vector2 radius = new Vector2(0.05f,0.05f);
        private float life = 0;

        public SplitterParticle(int seed, Vector2 startPosition)
        {
            Restart(seed, startPosition);
            life = 0;
        }

        private void Restart(int seed, Vector2 startPosition)
        {
            this.seed = seed;
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
            Random rand = new Random(seed);

            Vector2 randomDirection = new Vector2((float)rand.NextDouble() * 2.0f - 1.0f, (float)rand.NextDouble() * 2.0f - 1.0f);
            randomDirection.Normalize();
            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            timeLivedSeconds = 0.0f;
            maxLifeTime = 2.0f;
            life = maxLifeTime;

            float min = 0.01f;
            float max = 1.0f;
            float particleSpeed = min + ((float)(rand.NextDouble()) * max - min);

            velocity *= particleSpeed;
            acceleration = new Vector2(0, 4);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            life -= elapsedTimeSeconds;
            if (life < 0.0f)
            {
                Restart(seed, startPosition);
            }
            position = position + velocity * elapsedTimeSeconds;
            velocity = velocity + acceleration * elapsedTimeSeconds;

            timeLivedSeconds += elapsedTimeSeconds;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            Vector2 viewPosition = camera.GetVisualPositions(position);

            Vector2 visualRadius = camera.GetVisualPositions(radius);

            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, (int)visualRadius.X, (int)visualRadius.Y);

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
