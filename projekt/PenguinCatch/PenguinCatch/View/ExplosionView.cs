using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PenguinCatch.View
{
    class ExplosionView
    {
        private SplitterSystem splitterSystem;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D sparkTexture;
        private float maxLifeTime = 5.0f;
        private float life;

        public ExplosionView(SpriteBatch spriteBatch, Texture2D sparkTexture, Camera camera, Vector2 position)
        {
            this.spriteBatch = spriteBatch;
            this.sparkTexture = sparkTexture;
            this.cam = camera;
            splitterSystem = new SplitterSystem(position);

            life = maxLifeTime;
        }

        internal void Update(float elapsedTimeSeconds)
        {
            life -= elapsedTimeSeconds;

            splitterSystem.Update(elapsedTimeSeconds);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            this.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            splitterSystem.Draw(spriteBatch, cam, sparkTexture);
            spriteBatch.End();
        } 
    }
}
