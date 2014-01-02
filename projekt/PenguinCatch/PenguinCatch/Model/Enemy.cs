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
    }
}
