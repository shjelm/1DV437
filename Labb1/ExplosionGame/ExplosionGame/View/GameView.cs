using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ExplosionGame.View
{
    class GameView
    {
        //private ExplosionSystem explosionSystem;
        private Explosion explosion;
        private SpriteBatch spriteBatch;
        private Camera cam;
        private Texture2D texture;
        Vector2 modelStartPosition = new Vector2(0.5f, 0.2f);

        public GameView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.cam = camera;
            //explosionSystem = new ExplosionSystem(modelStartPosition);
            explosion = new Explosion(modelStartPosition);
        }

        internal void Draw(float elapsedTimeSeconds)
        {
            explosion.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            explosion.Draw(spriteBatch, cam, texture);
            spriteBatch.End();
        }
    }
}
