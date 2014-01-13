using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    //Kodgrund från Daniel Toll
    //https://code.google.com/p/1dv437arkanoid/source/browse/trunk/Collisions/Collisions2/Model/FloatRectangle.cs 

    class MyRectangle
    {        
        Vector2 topLeft;
        Vector2 bottomRight;

        public MyRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public static MyRectangle createFromTopLeft(Vector2 a_topLeft, Vector2 a_size)
        {
            Vector2 topLeft = a_topLeft;
            Vector2 bottomRight = a_topLeft+a_size;

            return new MyRectangle(topLeft, bottomRight);
        }

        public float Right {
            get { return bottomRight.X; }
        }

        public float Bottom {
            get { return bottomRight.Y; }
        }

        public float Left
        {
            get { return topLeft.X; }
        }

        public float Top
        {
            get { return topLeft.Y; }
        }

        internal bool isIntersecting(MyRectangle other)
        {
            if (Right< other.Left)
                return false;
            if (Bottom< other.Top)
                return false;
            if (Left > other.Right)
                return false;
            if (Top > other.Bottom)
                return false;

            return true;
        }
    }
}
