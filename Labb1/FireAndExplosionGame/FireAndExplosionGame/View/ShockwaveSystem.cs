using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FireAndExplosionGame.View
{
    class ShockwaveSystem
    {
        private Shockwave[] shockwaves;
        private const int MAX_WAVE = 1;

        public ShockwaveSystem(Vector2 modelStartPosition)
        {
            shockwaves = new Shockwave[MAX_WAVE];

            for (int i = 0; i < MAX_WAVE; i++)
            {
                shockwaves[i] = new Shockwave(modelStartPosition);
            }
        }

        public void Update(float elapsedTime)
        {
            for (int i = 0; i < MAX_WAVE; i++)
            {
                shockwaves[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            for (int i = 0; i < MAX_WAVE; i++)
            {
                shockwaves[i].Draw(spriteBatch, camera, texture);
            }
        }
    }
}
