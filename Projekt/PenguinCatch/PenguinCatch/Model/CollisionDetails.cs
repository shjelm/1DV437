using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class CollisionDetails
    { 
        public Vector2 speedAfterCollision;
        public Vector2 positionAfterCollision;

        public CollisionDetails(Vector2 speed, Vector2 position)
        {
            speedAfterCollision = speed;
            positionAfterCollision = position;
        }
    }
}
