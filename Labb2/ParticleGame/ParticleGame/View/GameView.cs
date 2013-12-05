using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleGame.View
{
    class GameView
    {
        private SplitterSystem splitterSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;

        public GameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            Vector2 systemStartPosition = new Vector2(0.5f, 0.5f);
            splitterSystem = new SplitterSystem(systemStartPosition);
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
