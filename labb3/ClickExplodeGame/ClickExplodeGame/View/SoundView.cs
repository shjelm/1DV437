using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace ClickExplodeGame.View
{
    class SoundView
    {        
        private SoundSytem soundSystem;
        private SoundEffect soundEffect;

        public SoundView(SoundEffect soundEffect)
        {
            this.soundEffect = soundEffect;
            soundSystem = new SoundSytem(this.soundEffect);
        }

        internal void Play()
        {
            soundSystem.PlaySound(soundEffect);
        }
    }
}
