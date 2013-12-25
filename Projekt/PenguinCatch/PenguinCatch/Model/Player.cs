using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Player
    {
        Vector2 leftBottomPos = new Vector2(1.0f, 18.0f);
        Vector2 speed = new Vector2(0, 0);
        Vector2 acceleration;

        internal Vector2 GetPosition()
        {
            return leftBottomPos;
        }

        internal void Update(float elapsedTimeSeconds)
        {
            acceleration = new Vector2(0.0f, 2.0f);

            leftBottomPos = leftBottomPos + speed * elapsedTimeSeconds + acceleration * elapsedTimeSeconds * elapsedTimeSeconds;

            speed = speed + elapsedTimeSeconds * acceleration;
        }

        internal void Jump()
        {
            speed.Y = -2.0f;
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
    }
}
