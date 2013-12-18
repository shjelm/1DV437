using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ClickExplodeGame.View
{
    class SmokeGameView
    {
        private SmokeSystem smokeSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;
        Vector2 modelStartPosition = new Vector2(1.2f, 1.8f);

        public SmokeGameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera, Vector2 mousePos)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            smokeSystem = new SmokeSystem(mousePos);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            smokeSystem.Update(elapsedTimeSeconds);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            this.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            smokeSystem.Draw(spriteBatch, cam, texture);
            spriteBatch.End();
        }
    }
}
