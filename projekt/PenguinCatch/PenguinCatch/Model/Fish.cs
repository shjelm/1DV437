﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PenguinCatch.Model
{
    class Fish
    {
        private Vector2 position;

        public Fish(Vector2 position) {

            this.position = position;
        }

        public Vector2 GetPositon()
        {
            return position;
        }
    }
}
