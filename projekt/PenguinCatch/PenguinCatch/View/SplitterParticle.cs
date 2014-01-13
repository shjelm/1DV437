using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PenguinCatch.View
{
    class SplitterParticle
    {
        private Vector2 startPosition;
        private Vector2 position;
        private Vector2 radius = new Vector2(1f,1f);

        public SplitterParticle(Vector2 startPosition)
        {
            Restart(startPosition);
        }

        private void Restart(Vector2 startPosition)
        {
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            Vector2 viewPosition = camera.GetVisualPositions(position);
            Vector2 visualRadius = camera.GetVisualPositions(radius);

            Rectangle rect = new Rectangle((int)viewPosition.X, (int)viewPosition.Y, (int)visualRadius.X, (int)visualRadius.Y);

            spriteBatch.Draw(texture, rect, Color.White);
        }
    }
}
