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

        public Collision(Vector2 position)
        {
            this.position = position;
        }

        internal Vector2 GetCollisionPosition()
        {
            return position;
        }

        internal bool DidCollide(Vector2 otherPosition)
        {
            float distance = Vector2.Distance(position, otherPosition);

            if (distance <= 0.05)
            {
                return true;
            }
            return false;
        }
    }
}
