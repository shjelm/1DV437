using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FireAndExplosionGame.View
{
    class SparkGameView
    {
        private SplitterSystem splitterSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;
        Vector2 modelStartPosition = new Vector2(0.5f, 0.8f);

        public SparkGameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            splitterSystem = new SplitterSystem(modelStartPosition);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            splitterSystem.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            splitterSystem.Draw(spriteBatch, cam, texture);           
            spriteBatch.End();
        }
    }
}
