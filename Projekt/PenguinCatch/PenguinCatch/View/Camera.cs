using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.View
{
    class Camera
    {
        private Vector2 visual;
        private Vector2 logical;
        public Vector2 scale;
        public float windowHeight;
        public float windowWidth;

        public Camera(float windowHeight, float windowWidth, int maxLogicalCoordinateX, int maxLogicalCoordinateY)
        {
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;

            if (windowHeight > windowWidth)
            {
                windowHeight = windowWidth;
            }
            else
            {
                windowWidth = windowHeight;
            }

            float x = windowHeight / maxLogicalCoordinateY;
            float y = windowWidth / maxLogicalCoordinateX;

            scale = new Vector2(x,y);
        }

        internal Vector2 GetVisualPositions(Vector2 logical)
        {
            visual.X = (logical.X * scale.X);
            visual.Y = (logical.Y * scale.Y);

            return visual;
        }

        internal Vector2 GetModelPositions(Vector2 visual)
        {
            logical.X = visual.X /scale.X;
            logical.Y = visual.Y/scale.Y;

            return logical;
        }

        internal Rectangle getRectangle(Vector2 logicalTopLeft, float logicalRadius)
        {
            float visualRadiusX = logicalRadius * scale.X;
            float visualRadiusY = logicalRadius * scale.Y;

            int visualX = (int)(logicalTopLeft.X * scale.X );
            int visualY = (int)(logicalTopLeft.Y * scale.Y);

            return new Rectangle(visualX, visualY, (int)(visualRadiusX * 2.0f), (int)(visualRadiusY * 2.0f));

        }
    }
}