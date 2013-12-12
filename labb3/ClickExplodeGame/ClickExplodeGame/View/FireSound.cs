using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace ClickExplodeGame.View
{
    class FireSound
    {
        internal void PlaySound(SoundEffect soundEffect)
        {
            soundEffect.Play();
        }
    }
}
