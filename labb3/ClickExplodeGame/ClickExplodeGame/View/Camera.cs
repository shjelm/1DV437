﻿using System;
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
        public Vector2 scale;
        private int maxLogicalCoordinate = 1;

        public Camera(float windowHeight, float windowWidth)
        {
            if (windowHeight > windowWidth)
            {
                windowHeight = windowWidth;
            }
            else
            {
                windowWidth = windowHeight;
            }

            float x = windowHeight * maxLogicalCoordinate;
            scale = new Vector2(x,x);
        }

        internal Vector2 GetVisualPositions(Vector2 logical)
        {
            visual.X = (logical.X * scale.X) - borderSize;
            visual.Y = (logical.Y * scale.Y) - borderSize;

            return visual;
        }

        internal void getCenterPosition()
        {

        }
    }
}