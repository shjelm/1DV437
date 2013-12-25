using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Collision
    {
        private Vector2 position;
        private float radius = 0.5f;

        public Collision(Vector2 position, float radius)
        {
            this.position = position;
            this.radius = radius;
        }

        internal bool Collide(Collision otherCollision)
        {
            Vector2 line = position - otherCollision.position;
            float distance = line.Length();

            if (distance < radius*2 + otherCollision.radius*2)
            {
                return true;
            }
            return false;
        }
    }
}
