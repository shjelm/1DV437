using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ClickExplodeGame.View
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;

        private Vector2 startPos = new Vector2(0.5f, 0.5f);

        private Rectangle rectangle;
        private Camera camera;

        private BallSystem ballSystem;

        public BallView(SpriteBatch spriteBatch, Texture2D texture, Camera camera)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.camera = camera;
            ballSystem = new BallSystem(startPos);
        }

        internal void Update(float elapsedTimeSeconds)
        {
            ballSystem.Update(elapsedTimeSeconds);
        }

        internal void DrawBall(Ball ball, float elapsedTimeSeconds)
        {
            this.Update(elapsedTimeSeconds);

            spriteBatch.Begin();
            ballSystem.Draw(spriteBatch, camera, texture, ball);
            spriteBatch.End();
        }

        internal void DrawBorder(Texture2D borderTexture)
        {
            int box = (int)camera.gameBox;
            this.rectangle = new Rectangle(0, 0, box, box);
            this.rectangle.Offset((int)camera.borderSize, (int)camera.borderSize);

            spriteBatch.Begin();
            spriteBatch.Draw(borderTexture, rectangle, Color.White);
            spriteBatch.End();
        }
    }
}
