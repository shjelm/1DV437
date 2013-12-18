using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ClickExplodeGame.View
{
    class Camera
    {
        public float borderSize;
        private Vector2 visual;
        private Vector2 logical;
        public Vector2 scale;
        public float gameBox;
        private int maxLogicalCoordinate = 1;
        public float ball;
        public float windowHeight;
        public float windowWidth;

        public Camera(float windowHeight, float windowWidth)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;

            if (windowHeight > windowWidth)
            {
                windowHeight = windowWidth;
                gameBox = windowWidth;
            }
            else
            {
                windowWidth = windowHeight;
                gameBox = windowHeight;
            }

            float x = windowHeight * maxLogicalCoordinate;
            scale = new Vector2(x,x);

            borderSize = windowHeight * 0.05f;

            gameBox = gameBox - borderSize * 2;
            ball = Ball.ball;
            ball = ball * scale.X;
        }

        internal Vector2 GetVisualPositions(Vector2 logical)
        {
            visual.X = (logical.X * scale.X) - borderSize;
            visual.Y = (logical.Y * scale.Y) - borderSize;

            return visual;
        }

        internal Vector2 GetModelPositions(Vector2 visual)
        {
            logical.X = (visual.X  + borderSize)/scale.X;
            logical.Y = (visual.Y  + borderSize)/scale.Y;

            return logical;
        }
    }
}