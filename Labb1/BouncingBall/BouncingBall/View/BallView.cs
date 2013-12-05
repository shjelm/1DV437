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


namespace BouncingBall
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Texture2D borderTexture;

        private Rectangle rectangle;
        private Camera camera;
        private Vector2 scale;

        private int windowWidth;
        private int windowHeight;

        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            

            windowWidth = graphicsDevice.Viewport.Width;
            windowHeight = graphicsDevice.Viewport.Height;
            camera = new Camera(windowHeight, windowWidth);

            this.spriteBatch = new SpriteBatch(graphicsDevice);
            texture = content.Load<Texture2D>("ball");
            borderTexture = content.Load<Texture2D>("border");
        }

        internal void DrawBall(Ball ball)
        {
            Vector2 screenPositions = camera.GetVisualPositions(ball.logicalPosition);

            int screenX = (int)screenPositions.X;
            int screenY = (int)screenPositions.Y;

            int ballSize = (int)camera.ball;

            this.rectangle = new Rectangle(screenX, screenY, ballSize, ballSize);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();
        }

        internal void DrawBorder()
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
