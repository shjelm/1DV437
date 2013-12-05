using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ParticleGame.View
{
    class Camera
    {
        public float borderSize;
        private Vector2 visual;
        public Vector2 scale;
        public float gameBox;
        public float ball = 0.05f;
        private int maxLogicalCoordinate = 1;

        public Camera(float windowHeight, float windowWidth)
        {
            if (windowHeight > windowWidth)
            {
                windowHeight = windowWidth;
                gameBox = windowWidth;
            }
            else
            {
                windowWidth = windowHeight;
                gameBox = windowWidth;
            }

            float x = windowHeight * maxLogicalCoordinate;
            scale = new Vector2(x,x);
            borderSize = windowHeight*0.05f;

            gameBox = gameBox - borderSize * 2;
            ball = ball * scale.X;

        }

        internal Vector2 GetVisualPositions(Vector2 logical)
        {
            visual.X = (logical.X * scale.X) - borderSize;
            visual.Y = (logical.Y * scale.Y) - borderSize;

            return visual;
        } 
    }
}