using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace ClickExplodeGame.View
{
    class SoundSytem
    {
        private FireSound sound;

        public SoundSytem(SoundEffect soundEffect)
        {
            sound = new FireSound();
        }

        public void PlaySound(SoundEffect soundEffect)
        {
            sound.PlaySound(soundEffect);
        }
    }
}
