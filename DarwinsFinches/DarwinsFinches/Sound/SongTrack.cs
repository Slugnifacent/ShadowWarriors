using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace DarwinsFinches
{
    class SongTrack : Sound
    {
        Song song;
        public SongTrack(string FileLocation)
        {
            song = Game1.content.Load<Song>(FileLocation);
        }

        public override void Play()
        {
            if (!Playing() || Paused())
            {
                MediaPlayer.Play(song);
            }
        }

        public override void Puase()
        {
            MediaPlayer.Pause();
        }

        public override void Stop()
        {
            MediaPlayer.Stop();
        }

        public override bool Paused()
        {
            return MediaPlayer.State == MediaState.Paused;
        }

        public override bool Playing()
        {
            return MediaPlayer.State == MediaState.Playing;
        }

        public override bool Finished()
        {
            return MediaPlayer.State == MediaState.Stopped;
        }
    }
}
