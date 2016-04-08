using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace DarwinsFinches
{
    class SFX : Sound
    {
        SoundEffect sound;
        SoundEffectInstance instance;
        public SFX(string FileLocation) {
            sound = Game1.content.Load<SoundEffect>(FileLocation);
            instance = sound.CreateInstance();
        }
        
        public override void Play()
        {
            if (!Playing() || Paused())
            {
                instance.Play();
            }
        }

        public override void Puase()
        {
            instance.Pause();
        }
        
        public override void Stop()
        {
            instance.Stop();
        }

        public override bool Paused()
        {
            return instance.State == SoundState.Paused;
        }

        public override bool Playing()
        {
            return instance.State == SoundState.Playing;
        }
       
        public override bool Finished()
        {
            return instance.State == SoundState.Stopped;
        } 
    }
}
