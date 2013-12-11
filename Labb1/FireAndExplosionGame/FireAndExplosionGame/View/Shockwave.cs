using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FireAndExplosionGame.View
{
    class Shockwave
    {
        private Vector2 pos;
        private Vector2 viewPosition;
        private float minSize;
        private float maxSize;
        private float size;
        private float timeLivedSeconds;
        private float lifePercent;
        private float maxLifeTime = 5.0f;
        private float visibility;
        private float origin = 1.0f;
        public float radius = 0.5f;

        public Shockwave(Vector2 startPos)
        {
            pos = new Vector2(startPos.X, startPos.Y);
                       
        }

        internal void Update(float elapsedTimeSeconds)
        {
            timeLivedSeconds += elapsedTimeSeconds;
            float t = timeLivedSeconds / maxLifeTime;

            if (t > 1.0)
            {
                t = 1.0f;
            }

            float endValue = 0.01f;
            float startValue = 1.0f;
            visibility = t * endValue + (1 - t) * startValue;

            minSize = 0.0f;
            maxSize = 3.8f;

            timeLivedSeconds += elapsedTimeSeconds;
            lifePercent = timeLivedSeconds / maxLifeTime;
            size = minSize + lifePercent * maxSize;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            viewPosition = camera.GetVisualPositions(pos);
            Console.WriteLine(size);

            Vector2 visualSize = camera.GetVisualPositions(new Vector2(size,size));

            Rectangle rect = new Rectangle((int)viewPosition.X - (int)visualSize.X / 2, (int)viewPosition.Y - (int)visualSize.Y / 2, (int)visualSize.X, (int)visualSize.Y);

            Color color = new Color(visibility, visibility, visibility, visibility);

            spriteBatch.Draw(texture, rect, color);
        }        
    }
}
