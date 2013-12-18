using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace ClickExplodeGame.View
{
    class SoundView
    {        
        private SoundEffect soundEffect;
        private FireSound sound;

        public SoundView(SoundEffect soundEffect)
        {
            this.soundEffect = soundEffect;
            sound = new FireSound();
        }

        internal void Play()
        {
            sound.PlaySound(soundEffect);
        }
    }
}
