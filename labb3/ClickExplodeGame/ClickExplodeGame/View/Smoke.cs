using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class Smoke
    {
        private int seed;
        private Vector2 startPosition;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 acceleration;
        private float timeLivedSeconds;
        private float maxLifeTime;
        private Vector2 smokeSize;
        private float life = 0;
        private float visibility;
        private float delaySeconds;
        public float delay;
        public static float MAX_DELAY = 5.0f;
        private float particleSpeed;
        private float rotation;
        private float origin = 6.0f;
        private float size;
        private float lifePercent;

        public Smoke(int seed, Vector2 startPosition)
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

            delay = (float)rand.NextDouble() * MAX_DELAY;

            Vector2 randomDirection = new Vector2((float)rand.Next(-5, 5), (float)rand.Next(-4,1));
            randomDirection.Normalize();
            velocity = new Vector2(randomDirection.X, randomDirection.Y);

            float maxRotation = 10.0f;
            rotation = (float)rand.NextDouble() * maxRotation;

            timeLivedSeconds = 0.0f;
            maxLifeTime = 3.0f;
            life = maxLifeTime;

            float min = 0.01f;
            float max = 0.3f;
            particleSpeed = particleSpeed * min + ((float)(rand.NextDouble()) * max - min);

            velocity *= particleSpeed;
            acceleration = new Vector2(0.0f, -0.5f);

            delaySeconds = (float)(rand.NextDouble()) * 0.1f;
        }

        internal void Update(float elapsedTimeSeconds)
        {
            life -= elapsedTimeSeconds;

            if (life < 0.0f)
            {
                if (delay > 0)
                {
                    delay -= elapsedTimeSeconds;
                    return;
                }
                Restart(seed, startPosition);
            }

            velocity = velocity + acceleration * elapsedTimeSeconds;
            position = position + velocity * elapsedTimeSeconds;

            timeLivedSeconds += elapsedTimeSeconds;

            float t = timeLivedSeconds / maxLifeTime;

            if (t > 1.0)
            {
                t = 1.0f;
            }

            float endValue = 0.01f;
            float startValue = 1.0f;
            visibility = t * endValue +(1-t) * startValue;

            float minSize = 1.0f;
            float maxSize = 5.0f;

            timeLivedSeconds += elapsedTimeSeconds;
            lifePercent = timeLivedSeconds / maxLifeTime;
            size = minSize + lifePercent * maxSize;

            smokeSize = new Vector2(size, size);
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            Vector2 viewPosition = camera.GetVisualPositions(position);

            Vector2 visualRadius = camera.GetVisualPositions(smokeSize);

            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, (int)visualRadius.X, (int)visualRadius.Y);

            Color color = new Color(visibility, visibility, visibility, visibility);

            spriteBatch.Draw(texture, viewPosition, null, color, rotation, new Vector2(origin, origin), size, SpriteEffects.None, 0);
        }
    }
}
