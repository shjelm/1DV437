using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickExplodeGame.View
{
    class ExplosionView
    {
        private SmokeSystem smokeSystem;
        private SplitterSystem splitterSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D sparkTexture;
        private Texture2D smokeTexture;

        public ExplosionView(SpriteBatch spriteBatch, Texture2D sparkTexture, Texture2D smokeTexture, Camera camera, Vector2 mousePos)
        {
            this.spriteBatch = spriteBatch;
            this.sparkTexture = sparkTexture;
            this.smokeTexture = smokeTexture;
            this.cam = camera;
            smokeSystem = new SmokeSystem(mousePos);
            splitterSystem = new SplitterSystem(mousePos);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            smokeSystem.Update(elapsedTimeSeconds);
            splitterSystem.Update(elapsedTimeSeconds);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            this.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            smokeSystem.Draw(spriteBatch, cam, smokeTexture);
            splitterSystem.Draw(spriteBatch, cam, sparkTexture);
            spriteBatch.End();
        } 
    }
}
