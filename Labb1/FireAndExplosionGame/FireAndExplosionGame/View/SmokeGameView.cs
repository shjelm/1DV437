using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FireAndExplosionGame.View
{
    class SmokeGameView
    {
        private SmokeSystem smokeSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;
        Vector2 modelStartPosition = new Vector2(0.5f, 0.8f);

        public SmokeGameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            smokeSystem = new SmokeSystem(modelStartPosition);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            smokeSystem.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            smokeSystem.Draw(spriteBatch, cam, texture);
            spriteBatch.End();
        }
    }
}
