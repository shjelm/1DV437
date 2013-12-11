using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ExplosionGame.View;

namespace ExplosionGame
{
    class Explosion
    {
        private Vector2 startPosition;
        private int numberOfFrames = 24;
        private float timeElapsed;
        private int frameX = 0;
        private int frameY = 0;
        private int numFramesX = 4;
        private float maxTime = 0.5f;
        private Vector2 position;
        private Vector2 explosionSize = new Vector2(0.6f, 0.6f);
        private int size = 128;

        public Explosion(Vector2 startPosition)
        {
            Restart(startPosition);
        }

        private void Restart(Vector2 startPosition)
        {
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            timeElapsed += elapsedTimeSeconds;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            Vector2 viewPosition = camera.GetVisualPositions(position);
            Vector2 explosionViewSize = camera.GetVisualPositions(explosionSize);

            Rectangle explosionRect = new Rectangle(frameX * size, frameY * size, size, size);
            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, (int)explosionViewSize.X, (int)explosionViewSize.Y);

            spriteBatch.Draw(texture, rect, explosionRect, Color.White);
        }
    }
}
