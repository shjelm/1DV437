using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using System.Timers;

namespace PenguinCatch.View
{
    class SoundView
    {
        public void PlaySound(SoundEffect sound) 
        {
            SoundEffectInstance soundEffectInstance = sound.CreateInstance();
            soundEffectInstance.Play();
        }
    }
}
