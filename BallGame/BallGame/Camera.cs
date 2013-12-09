using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallGame2
{
    class Camera
    {
        private float logicalPositionX = 7;
        private float logicalPositionY = 7;
        private float scaleX, scaleY;
        private int borderSize = 64;
        private int sizeOfTile = 64;
        private float visualX;
        private float visualY;

        internal float GetX()
        {
            return visualX;
        }

        internal float GetY()
        {
            return visualY;
        } 

        internal void SetRotatedPositions()
        {
            visualX = (sizeOfTile * 8) - (logicalPositionX * sizeOfTile);
            visualY = (sizeOfTile * 8) - (logicalPositionY * sizeOfTile);
        }

        internal void SetScaledPositions()
        {
            scaleX = 640.0f / 320.0f;
            scaleY = 640.0f / 240.0f;

            visualX = (logicalPositionX / scaleX) + (borderSize / scaleX);
            visualY = (logicalPositionY / scaleY) + (borderSize / scaleY);
        }

        internal void SetVisualPositions()
        {
            visualX = (logicalPositionX * sizeOfTile) + borderSize;
            visualY = (logicalPositionY * sizeOfTile) + borderSize;
        }

        public Camera()
        {
        }
    }
}