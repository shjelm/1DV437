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


namespace BallGame2
{
    class BallView
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private ContentManager content;
        private GraphicsDevice graphicsDevice;

        private Camera camera;
        private BallSimulation ballSim;

        //float logicalX;
        //float logicalY;

        public BallView(GraphicsDevice graphicsDevice, ContentManager content)
        {
            camera = new Camera();
            this.content = content;
            this.graphicsDevice = graphicsDevice;

            this.spriteBatch = new SpriteBatch(graphicsDevice);

            //logicalX = camera.GetX();
            //logicalY = camera.GetY();
        }

        internal void Draw()
        {
            camera.SetVisualPositions();
            float visualX = camera.GetX();
            float visualY = camera.GetY();

            texture = content.Load<Texture2D>("ball");
            Rectangle rec = new Rectangle(640, 640, 16, 16);
            spriteBatch.Begin();

            spriteBatch.Draw(texture, rec, Color.White);
            // TODO: Add your drawing code here

            spriteBatch.End();
        }
        
        //public float GetX()
        //{
        //    return logicalX;
        //}

        //public float GetY()
        //{
        //    return logicalY;
        //}
    }
}
