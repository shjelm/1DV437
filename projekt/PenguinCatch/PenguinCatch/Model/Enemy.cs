using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Enemy
    {        
        private Vector2 position;

        public Enemy(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPositon()
        {
            return position;
        }

        public void SetPosition(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        internal void SetSolidPosition(int x, int y)
        {
            position = new Vector2(x, y);
        }
    }
}
