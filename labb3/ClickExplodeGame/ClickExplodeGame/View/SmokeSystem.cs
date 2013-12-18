using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class SmokeSystem
    {
        private Smoke[] smokeClouds;
        private const int MAX_SMOKE = 25;

        public SmokeSystem(Vector2 mousePos)
        {
            smokeClouds = new Smoke[MAX_SMOKE];

            for (int i = 0; i < MAX_SMOKE; i++)
            {
                smokeClouds[i] = new Smoke(i, mousePos);
            }
        }

        public void Update(float elapsedTime)
        {
            for (int i = 0; i < MAX_SMOKE; i++)
            {
                smokeClouds[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            for (int i = 0; i < MAX_SMOKE; i++)
            {
                smokeClouds[i].Draw(spriteBatch, camera, texture);
            }
        }
    }
}
