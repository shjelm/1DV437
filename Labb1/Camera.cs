using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstGame
{
    class Camera2
    {
        private float scaleX, scaleY;
        private float borderSize = 64;
        private float sizeOfTile = 64;
        private Vector2 visual;

        internal Vector2 GetVisualPositions(Vector2 logical)
        {
            visual.X = (logical.X * sizeOfTile) + borderSize;
            visual.Y = (logical.Y * sizeOfTile) + borderSize;

            return visual;
        }

        internal Vector2 GetRotatedPositions(Vector2 logical)
        {
            visual.X = ((sizeOfTile * 7) - (logical.X * sizeOfTile)) + borderSize;
            visual.Y = ((sizeOfTile * 7) - (logical.Y * sizeOfTile)) + borderSize;

            return visual;
        }

        internal Vector2 GetScaledPositions(Vector2 logical)
        {
            scaleX = 320.0f / 640.0f;
            scaleY = 240.0f / 640.0f;

            visual.X = (logical.X * scaleX) + (borderSize * scaleX);
            visual.Y = (logical.Y * scaleY) + (borderSize * scaleY);

            return visual;
        }

        public Camera2()
        {
            Vector2 v = new Vector2 (0,0);
            Vector2 v2 = GetVisualPositions(v);
            Console.WriteLine("hej");

        }
    }
}
