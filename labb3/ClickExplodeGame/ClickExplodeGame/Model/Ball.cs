using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BouncingBall
{
    class Ball
    { 
        public Vector2 logicalPosition = new Vector2(0.2f, 0.6f);
        public Vector2 logialCenterPosition;
        public float radius = 0.05f;
        public Vector2 speed = new Vector2(0.4f,0.3f);
        public float ball = 0.05f;

        public Vector2 GetCenterPosition()
        {
            float x = (float)Math.Sqrt(2.0)*radius;

            logialCenterPosition = logicalPosition + new Vector2(x,x);

            return logialCenterPosition;
        }
    }
}
