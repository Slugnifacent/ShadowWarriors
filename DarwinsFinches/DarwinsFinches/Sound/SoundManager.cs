using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace DarwinsFinches
{
    class SoundManager
    {
        static SoundManager manager;
        List<Sound> sounds;
        Sound bgm;
        SoundManager() {
            sounds = new List<Sound>();
        }

        public static SoundManager Instance(){
            if (manager == null) {
                manager = new SoundManager();
            }
            return manager;
        }

        public void Update() {
            for (int index = 0; index < sounds.Count; index++) {
                Sound current = sounds.ElementAt<Sound>(index);
                if (!current.Finished())
                {
                   current.Play();
                }
                else {
                    sounds.RemoveAt(index);
                    index--;
                }
            }
        }
        public void Volume(float Value) {
            MediaPlayer.Volume = Value;
        }

        public void AddSound(SFX sound) {
            sound.Play();
            sounds.Add(sound);
        }

        public void BGM(SongTrack Track)
        {
            bgm = Track;
        }

        public Sound BGM() {
            return bgm;
        }
    }
}
