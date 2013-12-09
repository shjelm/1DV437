using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SmokeGame.View
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

            //Vector2 randomDirection = new Vector2((float)rand.Next(-1, 1), (float)rand.Next(-1, 1));
            //randomDirection.Normalize();
            //velocity = new Vector2(randomDirection.X, randomDirection.Y);

            velocity = new Vector2(0.0f, 0.1f);

            timeLivedSeconds = 0.0f;
            maxLifeTime = 5.0f;
            life = maxLifeTime;

            float min = 0.01f;
            float max = 0.5f;
            float particleSpeed = min + ((float)(rand.NextDouble()) * max - min);

            velocity *= particleSpeed;
            acceleration = new Vector2(0.0f, -0.3f);
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

            float t = timeLivedSeconds / maxLifeTime;

            if (t > 1.0)
            {
                t = 1.0f;
            }

            float endValue = 0.0f;
            float startValue = 1.0f;
            visibility = t * endValue +(1-t) * startValue;

            float minSize = 0.01f;
            float maxSize = 1.0f;
            float size = maxSize * t + minSize;

            smokeSize = new Vector2(size, size);
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {

            Vector2 viewPosition = camera.GetVisualPositions(position);

            Vector2 visualRadius = camera.GetVisualPositions(smokeSize);

            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, (int)visualRadius.X, (int)visualRadius.Y);

            Color color = new Color(visibility, visibility, visibility, visibility);

            spriteBatch.Draw(texture, rect, color);
            //spriteBatch.Draw(texture,viewPosition,null,color,8.2f,new Vector2(8, 8),visualRadius.X,SpriteEffects.None,0);
        }
    }
}
