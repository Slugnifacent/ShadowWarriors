using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DarwinsFinches
{
    abstract class Sound
    {
        abstract public void Play();
        abstract public void Stop();
        abstract public void Puase();
        abstract public bool Playing();
        abstract public bool Paused();
        abstract public bool Finished();


    }
}
