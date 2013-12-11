using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FireAndExplosionGame.View
{
    class SwGameView
    {
        private ShockwaveSystem swSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;
        Vector2 modelStartPosition = new Vector2(0.5f, 0.8f);

        public SwGameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            swSystem = new ShockwaveSystem(modelStartPosition);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            swSystem.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            swSystem.Draw(spriteBatch, cam, texture);
            spriteBatch.End();
        }
    }
}
