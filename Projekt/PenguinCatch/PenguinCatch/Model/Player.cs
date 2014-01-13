using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Player
    {
        Vector2 leftBottomPos = new Vector2(10.0f, 10.0f);
        Vector2 speed = new Vector2(0, 0);
        public int life;
        public float angle;

        public Player()
        {
            life = 3;
        }

        internal Vector2 GetPosition()
        {
            return leftBottomPos;
        }

        internal void Update(float elapsedTimeSeconds)
        {
            leftBottomPos = leftBottomPos + speed * elapsedTimeSeconds;
        }

        internal void SetNewPosition(Vector2 position)
        {
            leftBottomPos = position;
        }

        internal Vector2 GetSpeed()
        {
            return speed;
        }

        internal void SetSpeed(Vector2 newSpeed)
        {
            speed = newSpeed;
        }

        internal void LostLife()
        {
            life--;
        }

        public int GetLife()
        {
            return life;
        }
    }
}
