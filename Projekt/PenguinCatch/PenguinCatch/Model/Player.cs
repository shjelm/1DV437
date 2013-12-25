using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Player
    {
        Vector2 centerBottomPos = new Vector2(1.0f, 18.0f);
        Vector2 speed = new Vector2(0, 0);
        Vector2 acceleration;

        internal Vector2 GetPosition()
        {
            return centerBottomPos;
        }

        internal void Update(float elapsedTimeSeconds)
        {
            acceleration = new Vector2(0.0f, 2.0f);

            centerBottomPos = centerBottomPos + speed * elapsedTimeSeconds + acceleration * elapsedTimeSeconds * elapsedTimeSeconds;

            speed = speed + elapsedTimeSeconds * acceleration;
        }

        internal void Jump()
        {
            speed.Y = -2.0f;
        }

        internal void SetNewPosition(Vector2 position)
        {
            centerBottomPos = position;
        }

        internal Vector2 GetSpeed()
        {
            return speed;
        }

        internal void SetSpeed(Vector2 newSpeed)
        {
            speed = newSpeed;
        }

        internal void StopPlayer()
        {
            speed = new Vector2(0,0);
        }

        internal void Collide()
        {
            //Vector2 R = 2.0f * (-Vector2.Dot(ballVelocity, normal)) * normal + ballVelocity;

            this.speed = new Vector2(0,0);
        }
    }
}
