using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class SplitterSystem
    {
        private SplitterParticle[] particles;
        private const int MAX_PARTICLES = 50;

        public SplitterSystem(Vector2 modelStartPosition)
        {
            particles = new SplitterParticle[MAX_PARTICLES];

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i] = new SplitterParticle(i, modelStartPosition);
            }
        }

        public void Update(float elapsedTime)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                particles[i].Draw(spriteBatch, camera, texture);
            }
        }
    }
}
